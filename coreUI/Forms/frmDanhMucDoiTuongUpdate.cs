using System;
using System.Data;
using System.Windows.Forms;

namespace coreUI.Forms
{
    public partial class frmDanhMucDoiTuongUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        public object DefaultValue = null;
        public Action InsertToList, UpdateToList;
        public static DataTable dtUpdate;
        coreDTO.DanhMucDoiTuong obj = null;
        public frmDanhMucDoiTuongUpdate()
        {
            InitializeComponent();
            //LoaiDanhMuc = "DanhMucDoiTuong";
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
                    CapNhat = coreCommon.ThaoTacDuLieu.Them;
                    //Xóa text box
                    txtMa.Value = null;
                    txtTen.Value = null;
                    txtMa.Focus();
                }
            }
        }
        private bool Save()
        {
            if (coreCommon.coreCommon.IsNull(txtMa.Value)) { coreCommon.coreCommon.ErrorMessageOkOnly("Thiếu mã đối tượng!"); txtMa.Focus(); return false; }
            if (coreCommon.coreCommon.IsNull(txtTen.Value)) { coreCommon.coreCommon.ErrorMessageOkOnly("Thiếu tên đối tượng!"); txtTen.Focus(); return false; }
            obj = new coreDTO.DanhMucDoiTuong
            {
                ID = dataRow != null ? dataRow["ID"] : null,
                Ma = txtMa.Value,
                Ten = txtTen.Value,
                IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                CreateDate = null,
                EditDate = null
            };
            bool OK = (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy) ? coreBUS.DanhMucDoiTuongBUS.Insert(ref obj) : coreBUS.DanhMucDoiTuongBUS.Update(ref obj);
            if (OK && obj != null && Int64.TryParse(obj.ID.ToString(), out Int64 _ID) && _ID > 0)
            {
                dtUpdate = coreBUS.DanhMucDoiTuongBUS.List(obj.ID, IDDanhMucLoaiDoiTuong, null);
                if (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy)
                {
                    if (InsertToList != null)
                        InsertToList();
                }   
                else
                {
                    if (UpdateToList != null)
                        UpdateToList();
                }

                if (dataTable != null)
                {
                    if (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy)
                    {
                        dataRow = dataTable.NewRow();
                        foreach (var prop in obj.GetType().GetProperties())
                        {
                            if (dataTable.Columns.Contains(prop.Name))
                                dataRow[prop.Name] = !coreCommon.coreCommon.IsNull(prop.GetValue(obj, null)) ? prop.GetValue(obj, null) : DBNull.Value;
                        }
                        dataTable.Rows.Add(dataRow);
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
                ID = obj.ID;
                return true;
            }
            else
            {
                ID = null;
                return false;
            }
        }

        private void frmDanhMucDoiTuongUpdate_Load(object sender, EventArgs e)
        {
            if (CapNhat == coreCommon.ThaoTacDuLieu.Sua)
            {
                txtMa.Value = dataRow["Ma"];
                txtTen.Value = dataRow["Ten"];
            }
            else
            {
                txtMa.Value = DefaultValue;
                txtTen.Value = DefaultValue;
            }
        }
    }
}
