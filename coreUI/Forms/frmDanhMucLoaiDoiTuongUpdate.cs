using System;
using System.Data;
using System.Windows.Forms;

namespace coreUI.Forms
{
    public partial class frmDanhMucLoaiDoiTuongUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        coreDTO.DanhMucLoaiDoiTuong obj = null;
        public static DataTable dtUpdate;
        public Action InsertToList, UpdateToList;
        public frmDanhMucLoaiDoiTuongUpdate()
        {
            InitializeComponent();
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
                    txtMa.Value = null;
                    txtTen.Value = null;
                    txtTenBangDuLieu.Value = null;
                    txtMa.Focus();
                }
            }
        }
        private bool Save()
        {
            if (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy)
            {
                obj = new coreDTO.DanhMucLoaiDoiTuong
                {
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    TenBangDuLieu = txtTenBangDuLieu.Value,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new coreDTO.DanhMucLoaiDoiTuong
                {
                    ID = dataRow["ID"],
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    TenBangDuLieu = txtTenBangDuLieu.Value,
                    CreateDate = null,
                    EditDate = null
                };
            }
            bool OK = (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy) ? coreBUS.DanhMucLoaiDoiTuongBUS.Insert(obj) : coreBUS.DanhMucLoaiDoiTuongBUS.Update(obj);
            if (OK && obj != null && Int64.TryParse(obj.ID.ToString(), out Int64 _ID) && _ID > 0)
            {
                dtUpdate = coreBUS.DanhMucLoaiDoiTuongBUS.List(obj.ID);
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

        private void frmDanhMucLoaiDoiTuongUpdate_Load(object sender, EventArgs e)
        {
            if (CapNhat >= coreCommon.ThaoTacDuLieu.Sua)
            {
                dataRow = coreBUS.DanhMucLoaiDoiTuongBUS.List(ID).Rows[0];
                if (coreCommon.coreCommon.IsNull(dataRow)) { coreCommon.coreCommon.ErrorMessageOkOnly("Không lấy được dữ liệu!"); this.DialogResult = DialogResult.Cancel; }
                txtMa.Value = dataRow["Ma"];
                txtTen.Value = dataRow["Ten"];
                txtTenBangDuLieu.Value = dataRow["TenBangDuLieu"];
            }
        }
    }
}
