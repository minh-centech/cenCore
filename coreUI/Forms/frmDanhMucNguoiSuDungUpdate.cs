using coreBUS;
using coreControls;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using static coreUI.coreUI;

namespace coreUI.Forms
{
    public partial class frmDanhMucNguoiSuDungUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        public Object IDDanhMucMenu = null;
        Object Password = null;
        coreDTO.DanhMucNguoiSuDung obj = null;
        public frmDanhMucNguoiSuDungUpdate()
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
                    txtMaDanhMucPhanQuyen.Value = null;
                    txtTenDanhMucPhanQuyen.Value = null;
                    txtMa.Value = null;
                    txtTen.Value = null;
                    txtMa.Focus();
                }
            }
        }
        private bool Save()
        {

            if (CapNhat == 1 || CapNhat == 3)
            {
                obj = new coreDTO.DanhMucNguoiSuDung
                {
                    IDDanhMucPhanQuyen = txtMaDanhMucPhanQuyen.ID,
                    MaDanhMucPhanQuyen = txtMaDanhMucPhanQuyen.Value,
                    TenDanhMucPhanQuyen = txtTenDanhMucPhanQuyen.Value,
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    isAdmin = chkAdmin.Checked,
                    Password = coreCommon.coreCommon.EncryptString(""),
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new coreDTO.DanhMucNguoiSuDung
                {
                    ID = dataRow["ID"],
                    IDDanhMucPhanQuyen = txtMaDanhMucPhanQuyen.ID,
                    MaDanhMucPhanQuyen = txtMaDanhMucPhanQuyen.Value,
                    TenDanhMucPhanQuyen = txtTenDanhMucPhanQuyen.Value,
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    isAdmin = chkAdmin.Checked,
                    CreateDate = null,
                    EditDate = null
                };
            }
            bool OK = (CapNhat == 1 || CapNhat == 3) ? coreBUS.DanhMucNguoiSuDungBUS.Insert(ref obj) : coreBUS.DanhMucNguoiSuDungBUS.Update(ref obj);
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
            
            //
            if (CapNhat >= 2)
            {
                txtMaDanhMucPhanQuyen.Value = dataRow["MaDanhMucPhanQuyen"];
                txtMaDanhMucPhanQuyen.ID = dataRow["IDDanhMucPhanQuyen"];
                txtTenDanhMucPhanQuyen.Value = dataRow["TenDanhMucPhanQuyen"];
                txtMa.Value = dataRow["Ma"];
                txtTen.Value = dataRow["Ten"];
                chkAdmin.Checked = Boolean.Parse(dataRow["isAdmin"].ToString());
                Password = dataRow["Password"];
            }
            coreUI.validData.SetValidTextbox(txtMaDanhMucPhanQuyen, new saTextBox[1] { txtTenDanhMucPhanQuyen }, new Func<DataTable>(() => DanhMucPhanQuyenBUS.List(null).Tables[0]), "Ma", "ID", "Ten", null, null, null);
        }
    }
}
