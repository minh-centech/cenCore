using coreBUS;
using coreControls;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using static coreUI.coreUI;

namespace coreUI.Forms
{
    public partial class frmDanhMucPhanQuyenLoaiDoiTuongUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        public Object IDDanhMucPhanQuyen = null;
        coreDTO.DanhMucPhanQuyenLoaiDoiTuong obj = null;
        public frmDanhMucPhanQuyenLoaiDoiTuongUpdate()
        {
            InitializeComponent();
            //LoaiDanhMuc = "DanhMucLoaiDoiTuong";
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
                    txtMaDanhMucLoaiDoiTuong.Value = null;
                    txtTenDanhMucLoaiDoiTuong.Value = null;
                    chkXem.Checked = false;
                    chkThem.Checked = false;
                    chkSua.Checked = false;
                    chkXoa.Checked = false;
                    txtMaDanhMucLoaiDoiTuong.Focus();
                }
            }
        }
        private bool Save()
        {

            if (CapNhat == 1 || CapNhat == 3)
            {
                obj = new coreDTO.DanhMucPhanQuyenLoaiDoiTuong
                {
                    IDDanhMucPhanQuyen = IDDanhMucPhanQuyen,
                    IDDanhMucLoaiDoiTuong = txtMaDanhMucLoaiDoiTuong.ID,
                    MaDanhMucLoaiDoiTuong = txtMaDanhMucLoaiDoiTuong.Value,
                    TenDanhMucLoaiDoiTuong = txtTenDanhMucLoaiDoiTuong.Value,
                    Xem = chkXem.Checked,
                    Them = chkThem.Checked,
                    Sua = chkSua.Checked,
                    Xoa = chkXoa.Checked,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new coreDTO.DanhMucPhanQuyenLoaiDoiTuong
                {
                    ID = dataRow["ID"],
                    IDDanhMucPhanQuyen = IDDanhMucPhanQuyen,
                    IDDanhMucLoaiDoiTuong = txtMaDanhMucLoaiDoiTuong.ID,
                    MaDanhMucLoaiDoiTuong = txtMaDanhMucLoaiDoiTuong.Value,
                    TenDanhMucLoaiDoiTuong = txtTenDanhMucLoaiDoiTuong.Value,
                    Xem = chkXem.Checked,
                    Them = chkThem.Checked,
                    Sua = chkSua.Checked,
                    Xoa = chkXoa.Checked,
                    CreateDate = null,
                    EditDate = null
                };
            }
            bool OK = (CapNhat == 1 || CapNhat == 3) ? coreBUS.DanhMucPhanQuyenLoaiDoiTuongBUS.Insert(ref obj) : coreBUS.DanhMucPhanQuyenLoaiDoiTuongBUS.Update(ref obj);
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



        private void frmDanhMucLoaiDoiTuongUpdate_Load(object sender, EventArgs e)
        {
            
            if (CapNhat >= 2)
            {
                IDDanhMucPhanQuyen = dataRow["IDDanhMucPhanQuyen"];
                txtMaDanhMucLoaiDoiTuong.Value = dataRow["MaDanhMucLoaiDoiTuong"];
                txtMaDanhMucLoaiDoiTuong.ID = dataRow["IDDanhMucLoaiDoiTuong"];
                txtTenDanhMucLoaiDoiTuong.Value = dataRow["TenDanhMucLoaiDoiTuong"];
                chkXem.Checked = bool.Parse(dataRow["Xem"].ToString());
                chkThem.Checked = bool.Parse(dataRow["Them"].ToString());
                chkSua.Checked = bool.Parse(dataRow["Sua"].ToString());
                chkXoa.Checked = bool.Parse(dataRow["Xoa"].ToString());
            }
            coreUI.validData.SetValidTextbox(txtMaDanhMucLoaiDoiTuong, new saTextBox[1] { txtTenDanhMucLoaiDoiTuong }, new Func<DataTable>(() => DanhMucLoaiDoiTuongBUS.List(null)), "Ma", "ID", "Ten", null, null, null);
        }

        private void chkXem_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkXem.Checked)
            {
                chkThem.Checked = false;
                chkSua.Checked = false;
                chkXoa.Checked = false;
            }
            chkThem.Enabled = chkXem.Checked;
            chkSua.Enabled = chkXem.Checked;
            chkXoa.Enabled = chkXem.Checked;
        }
    }
}
