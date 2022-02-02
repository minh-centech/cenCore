using coreBUS;
using coreControls;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using static coreUI.coreUI;

namespace coreUI.Forms
{
    public partial class frmDanhMucPhanQuyenChungTuUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        public Object IDDanhMucPhanQuyen = null;
        coreDTO.DanhMucPhanQuyenChungTu obj = null;
        public static DataTable dtUpdate;
        public Action InsertToList, UpdateToList;
        public frmDanhMucPhanQuyenChungTuUpdate()
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
                    CapNhat = coreCommon.ThaoTacDuLieu.Them;
                    //Xóa text box
                    txtMaDanhMucChungTu.Value = null;
                    txtTenDanhMucChungTu.Value = null;
                    chkXem.Checked = false;
                    chkThem.Checked = false;
                    chkSua.Checked = false;
                    chkXoa.Checked = false;
                    txtMaDanhMucChungTu.Focus();
                }
            }
        }
        private bool Save()
        {

            if (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy)
            {
                obj = new coreDTO.DanhMucPhanQuyenChungTu
                {
                    IDDanhMucPhanQuyen = IDDanhMucPhanQuyen,
                    IDDanhMucChungTu = txtMaDanhMucChungTu.ID,
                    MaDanhMucChungTu = txtMaDanhMucChungTu.Value,
                    TenDanhMucChungTu = txtTenDanhMucChungTu.Value,
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
                obj = new coreDTO.DanhMucPhanQuyenChungTu
                {
                    ID = dataRow["ID"],
                    IDDanhMucPhanQuyen = IDDanhMucPhanQuyen,
                    IDDanhMucChungTu = txtMaDanhMucChungTu.ID,
                    MaDanhMucChungTu = txtMaDanhMucChungTu.Value,
                    TenDanhMucChungTu = txtTenDanhMucChungTu.Value,
                    Xem = chkXem.Checked,
                    Them = chkThem.Checked,
                    Sua = chkSua.Checked,
                    Xoa = chkXoa.Checked,
                    CreateDate = null,
                    EditDate = null
                };
            }
            bool OK = (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy) ? coreBUS.DanhMucPhanQuyenChungTuBUS.Insert(obj) : coreBUS.DanhMucPhanQuyenChungTuBUS.Update(obj);
            if (OK && obj != null && Int64.TryParse(obj.ID.ToString(), out Int64 _ID) && _ID > 0)
            {
                dtUpdate = coreBUS.DanhMucPhanQuyenChungTuBUS.List(obj.ID);
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
                dataRow = dtUpdate.Rows[0];
                ID = obj.ID;
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
            
            if (CapNhat >= coreCommon.ThaoTacDuLieu.Sua)
            {
                dataRow = coreBUS.DanhMucPhanQuyenChungTuBUS.List(ID).Rows[0];
                if (coreCommon.coreCommon.IsNull(dataRow)) { coreCommon.coreCommon.ErrorMessageOkOnly("Không lấy được dữ liệu!"); this.DialogResult = DialogResult.Cancel; }
                IDDanhMucPhanQuyen = dataRow["IDDanhMucPhanQuyen"];
                txtMaDanhMucChungTu.Value = dataRow["MaDanhMucChungTu"];
                txtMaDanhMucChungTu.ID = dataRow["IDDanhMucChungTu"];
                txtTenDanhMucChungTu.Value = dataRow["TenDanhMucChungTu"];
                chkXem.Checked = bool.Parse(dataRow["Xem"].ToString());
                chkThem.Checked = bool.Parse(dataRow["Them"].ToString());
                chkSua.Checked = bool.Parse(dataRow["Sua"].ToString());
                chkXoa.Checked = bool.Parse(dataRow["Xoa"].ToString());
            }
            coreUI.validData.SetValidTextbox(txtMaDanhMucChungTu, new saTextBox[1] { txtTenDanhMucChungTu }, new Func<DataTable>(() => DanhMucChungTuBUS.List(null).Tables[0]), "Ma", "ID", "Ten", null, null, null);
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
