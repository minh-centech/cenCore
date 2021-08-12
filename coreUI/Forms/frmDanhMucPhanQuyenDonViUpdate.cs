using coreBUS;
using coreControls;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using static coreUI.coreUI;
namespace coreUI.Forms
{
    public partial class frmDanhMucPhanQuyenDonViUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        public Object IDDanhMucPhanQuyen = null;
        coreDTO.DanhMucPhanQuyenDonVi obj = null;
        public frmDanhMucPhanQuyenDonViUpdate()
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
                    txtMaDanhMucDonVi.Value = null;
                    txtTenDanhMucDonVi.Value = null;
                    chkXem.Checked = false;
                    txtMaDanhMucDonVi.Focus();
                }
            }
        }
        private bool Save()
        {
            if (CapNhat == 1 || CapNhat == 3)
            {
                obj = new coreDTO.DanhMucPhanQuyenDonVi
                {
                    IDDanhMucPhanQuyen = IDDanhMucPhanQuyen,
                    IDDanhMucDonVi = txtMaDanhMucDonVi.ID,
                    MaDanhMucDonVi = txtMaDanhMucDonVi.Value,
                    TenDanhMucDonVi = txtTenDanhMucDonVi.Value,
                    Xem = chkXem.Checked,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new coreDTO.DanhMucPhanQuyenDonVi
                {
                    ID = dataRow["ID"],
                    IDDanhMucPhanQuyen = IDDanhMucPhanQuyen,
                    IDDanhMucDonVi = txtMaDanhMucDonVi.ID,
                    MaDanhMucDonVi = txtMaDanhMucDonVi.Value,
                    TenDanhMucDonVi = txtTenDanhMucDonVi.Value,
                    Xem = chkXem.Checked,
                    CreateDate = null,
                    EditDate = null
                };
            }
            bool OK = (CapNhat == 1 || CapNhat == 3) ? coreBUS.DanhMucPhanQuyenDonViBUS.Insert(ref obj) : coreBUS.DanhMucPhanQuyenDonViBUS.Update(ref obj);
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
                IDDanhMucPhanQuyen = dataRow["IDDanhMucPhanQuyen"];
                txtMaDanhMucDonVi.Value = dataRow["MaDanhMucDonVi"];
                txtMaDanhMucDonVi.ID = dataRow["IDDanhMucDonVi"];
                txtTenDanhMucDonVi.Value = dataRow["TenDanhMucDonVi"];
                chkXem.Checked = bool.Parse(dataRow["Xem"].ToString());
            }
            coreUI.validData.SetValidTextbox(txtMaDanhMucDonVi, new saTextBox[1] { txtTenDanhMucDonVi }, new Func<DataTable>(() => DanhMucDonViBUS.List(null)), "Ma", "ID", "Ten", null, null, null);
        }
    }
}
