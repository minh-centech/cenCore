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
        public static DataTable dtUpdate;
        public Action InsertToList, UpdateToList;
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
                    CapNhat = coreCommon.ThaoTacDuLieu.Them;
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
            if (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy)
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
            bool OK = (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy) ? coreBUS.DanhMucPhanQuyenDonViBUS.Insert(obj) : coreBUS.DanhMucPhanQuyenDonViBUS.Update(obj);
            if (OK && obj != null && Int64.TryParse(obj.ID.ToString(), out Int64 _ID) && _ID > 0)
            {
                dtUpdate = coreBUS.DanhMucPhanQuyenDonViBUS.List(obj.ID);
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



        private void frmDanhMucDonViUpdate_Load(object sender, EventArgs e)
        {
            
            if (CapNhat >= coreCommon.ThaoTacDuLieu.Sua)
            {
                dataRow = coreBUS.DanhMucPhanQuyenDonViBUS.List(ID).Rows[0];
                if (coreCommon.coreCommon.IsNull(dataRow)) { coreCommon.coreCommon.ErrorMessageOkOnly("Không lấy được dữ liệu!"); this.DialogResult = DialogResult.Cancel; }
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
