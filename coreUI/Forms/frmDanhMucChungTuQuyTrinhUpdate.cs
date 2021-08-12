using coreBUS;
using coreControls;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using static coreUI.coreUI;

namespace coreUI.Forms
{
    public partial class frmDanhMucChungTuQuyTrinhUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        public Object IDDanhMucChungTu = null;
        coreDTO.DanhMucChungTuQuyTrinh obj = null;
        public frmDanhMucChungTuQuyTrinhUpdate()
        {
            InitializeComponent();
            //LoaiDanhMuc = "DanhMucDonVi";
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
                    txtMaDanhMucChungTuQuyTrinh.Value = null;
                    txtTenDanhMucChungTuQuyTrinh.Value = null;
                    txtMaDanhMucChungTuQuyTrinh.Focus();
                }
            }
        }
        private bool Save()
        {
            if (CapNhat == 1 || CapNhat == 3)
            {
                obj = new coreDTO.DanhMucChungTuQuyTrinh
                {
                    IDDanhMucChungTu = IDDanhMucChungTu,
                    IDDanhMucChungTuQuyTrinh = txtMaDanhMucChungTuQuyTrinh.ID,
                    MaDanhMucChungTuQuyTrinh = txtMaDanhMucChungTuQuyTrinh.Value,
                    TenDanhMucChungTuQuyTrinh = txtTenDanhMucChungTuQuyTrinh.Value,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new coreDTO.DanhMucChungTuQuyTrinh
                {
                    ID = dataRow["ID"],
                    IDDanhMucChungTu = IDDanhMucChungTu,
                    IDDanhMucChungTuQuyTrinh = txtMaDanhMucChungTuQuyTrinh.ID,
                    MaDanhMucChungTuQuyTrinh = txtMaDanhMucChungTuQuyTrinh.Value,
                    TenDanhMucChungTuQuyTrinh = txtTenDanhMucChungTuQuyTrinh.Value,
                    CreateDate = null,
                    EditDate = null
                };
            }
            bool OK = (CapNhat == 1 || CapNhat == 3) ? coreBUS.DanhMucChungTuQuyTrinhBUS.Insert(ref obj) : coreBUS.DanhMucChungTuQuyTrinhBUS.Update(ref obj);
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



        private void frmDanhMucDonViUpdate_Load(object sender, EventArgs e)
        {
            if (CapNhat >= 2)
            {
                IDDanhMucChungTu = dataRow["IDDanhMucChungTu"];
                txtMaDanhMucChungTuQuyTrinh.Value = dataRow["MaDanhMucChungTuQuyTrinh"];
                txtMaDanhMucChungTuQuyTrinh.ID = dataRow["IDDanhMucChungTuQuytrinh"];
                txtTenDanhMucChungTuQuyTrinh.Value = dataRow["TenDanhMucChungTuQuyTrinh"];
            }
            coreUI.validData.SetValidTextbox(txtMaDanhMucChungTuQuyTrinh, new saTextBox[1] { txtTenDanhMucChungTuQuyTrinh }, new Func<DataTable>(() => DanhMucChungTuBUS.List(null).Tables[0]), "Ma", "ID", "Ten", null, null, null);
        }
    }
}
