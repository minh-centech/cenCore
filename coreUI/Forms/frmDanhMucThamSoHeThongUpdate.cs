using System;
using System.Data;
using System.Windows.Forms;

namespace coreUI.Forms
{
    public partial class frmDanhMucThamSoHeThongUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        coreDTO.DanhMucThamSoHeThong obj = null;
        public static DataTable dtUpdate;
        public Action InsertToList, UpdateToList;
        public frmDanhMucThamSoHeThongUpdate()
        {
            InitializeComponent();
            //LoaiDanhMuc = "DanhMucThamSoHeThong";
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
                    txtGiaTri.Value = null;
                    txtGhiChu.Value = null;
                    txtMa.Focus();
                }
            }
        }
        private bool Save()
        {

            if (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy)
            {
                obj = new coreDTO.DanhMucThamSoHeThong
                {
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    GiaTri = txtGiaTri.Value,
                    GhiChu = txtGhiChu.Value,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new coreDTO.DanhMucThamSoHeThong
                {
                    ID = dataRow["ID"],
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    GiaTri = txtGiaTri.Value,
                    GhiChu = txtGhiChu.Value,
                    CreateDate = null,
                    EditDate = null
                };
            }
            bool OK = (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy) ? coreBUS.DanhMucThamSoHeThongBUS.Insert(obj) : coreBUS.DanhMucThamSoHeThongBUS.Update(obj);
            if (OK && obj != null && Int64.TryParse(obj.ID.ToString(), out Int64 _ID) && _ID > 0)
            {
                dtUpdate = coreBUS.DanhMucThamSoHeThongBUS.List(obj.ID);
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

        private void frmDanhMucThamSoHeThongUpdate_Load(object sender, EventArgs e)
        {
            if (CapNhat >= coreCommon.ThaoTacDuLieu.Sua)
            {
                dataRow = coreBUS.DanhMucThamSoHeThongBUS.List(ID).Rows[0];
                if (coreCommon.coreCommon.IsNull(dataRow)) { coreCommon.coreCommon.ErrorMessageOkOnly("Không lấy được dữ liệu!"); this.DialogResult = DialogResult.Cancel; }
                txtMa.Value = dataRow["Ma"];
                txtTen.Value = dataRow["Ten"];
                txtGiaTri.Value = dataRow["GiaTri"];
                txtGhiChu.Value = dataRow["GhiChu"];
            }
        }
    }
}
