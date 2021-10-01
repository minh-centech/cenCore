using coreBUS;
using coreControls;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using static coreUI.coreUI;

namespace coreUI.Forms
{
    public partial class frmDanhMucMenuChungTuUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        public Object IDDanhMucMenu = null;
        coreDTO.DanhMucMenuChungTu obj = null;
        public frmDanhMucMenuChungTuUpdate()
        {
            InitializeComponent();
            //LoaiDanhMuc = "DanhMucChungTu";
        }
        protected override void SaveData(bool AddNew)
        {
            if (Save())
            {
                if (!AddNew)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    CapNhat = 1;
                    //Xóa text box
                    txtMaDanhMucChungTu.Value = null;
                    txtTenDanhMucChungTu.Value = null;
                    txtNoiDungHienThi.Value = null;
                    chkTachNhom.Checked = false;
                    txtThuTuHienThi.Value = 0;
                    txtMaDanhMucChungTu.Focus();
                }
            }
        }
        private bool Save()
        {

            if (CapNhat == 1 || CapNhat == 3)
            {
                obj = new coreDTO.DanhMucMenuChungTu
                {
                    IDDanhMucMenu = IDDanhMucMenu,
                    IDDanhMucChungTu = txtMaDanhMucChungTu.ID,
                    MaDanhMucChungTu = txtMaDanhMucChungTu.Value,
                    TenDanhMucChungTu = txtTenDanhMucChungTu.Value,
                    NoiDungHienThi = txtNoiDungHienThi.Value,
                    PhanCachNhom = chkTachNhom.Checked,
                    ThuTuHienThi = txtThuTuHienThi.Value,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new coreDTO.DanhMucMenuChungTu
                {
                    ID = dataRow["ID"],
                    IDDanhMucMenu = IDDanhMucMenu,
                    IDDanhMucChungTu = txtMaDanhMucChungTu.ID,
                    MaDanhMucChungTu = txtMaDanhMucChungTu.Value,
                    TenDanhMucChungTu = txtTenDanhMucChungTu.Value,
                    NoiDungHienThi = txtNoiDungHienThi.Value,
                    PhanCachNhom = chkTachNhom.Checked,
                    ThuTuHienThi = txtThuTuHienThi.Value,
                    CreateDate = null,
                    EditDate = null
                };
            }
            bool OK = (CapNhat == 1 || CapNhat == 3) ? coreBUS.DanhMucMenuChungTuBUS.Insert(ref obj) : coreBUS.DanhMucMenuChungTuBUS.Update(ref obj);
            if (OK && obj != null && Int64.TryParse(obj.ID.ToString(), out Int64 _ID) && _ID > 0)
            {
                if (dataTable != null)
                {
                    if (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy)
                    {
                        DataRow dr = dataTable.NewRow();
                        foreach (var prop in obj.GetType().GetProperties())
                        {
                            if (dataTable.Columns.Contains(prop.Name))
                                dr[prop.Name] = !coreCommon.coreCommon.IsNull(prop.GetValue(obj, null)) ? prop.GetValue(obj, null) : DBNull.Value;
                        }
                        dataTable.Rows.Add(dr);
                        dataTable.AcceptChanges();
                    }
                    else
                    {
                        foreach (var prop in obj.GetType().GetProperties())
                        {
                            if (dataTable.Columns.Contains(prop.Name))
                                dataRow[prop.Name] = !coreCommon.coreCommon.IsNull(prop.GetValue(obj, null)) ? prop.GetValue(obj, null) : DBNull.Value;
                        }
                    }
                }
                ID = _ID;
                return true;
            }
            else
            {
                ID = null;
                return false;
            }
        }



        private void frmDanhMucChungTuUpdate_Load(object sender, EventArgs e)
        {
            coreUI.validData.SetValidTextbox(txtMaDanhMucChungTu, new saTextBox[1] { txtTenDanhMucChungTu }, new Func<DataTable>(() => DanhMucChungTuBUS.List(null).Tables[0]), "Ma", "ID", "Ten", null, null, null);
            if (CapNhat >= 2)
            {
                IDDanhMucMenu = dataRow["IDDanhMucMenu"];
                txtMaDanhMucChungTu.Value = dataRow["MaDanhMucChungTu"];
                txtMaDanhMucChungTu.ID = dataRow["IDDanhMucChungTu"];
                txtTenDanhMucChungTu.Value = dataRow["TenDanhMucChungTu"];
                txtNoiDungHienThi.Value = dataRow["NoiDungHienThi"];
                chkTachNhom.Checked = coreCommon.coreCommon.stringParseBoolean(dataRow["PhanCachNhom"]);
                txtThuTuHienThi.Value = int.Parse(dataRow["ThuTuHienThi"].ToString());
            }
        }

        private void txtTenDanhMucChungTu_ValueChanged(object sender, EventArgs e)
        {
            if (CapNhat == 1) txtNoiDungHienThi.Value = txtTenDanhMucChungTu.Value;
        }
    }
}
