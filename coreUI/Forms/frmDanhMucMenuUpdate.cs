using System;
using System.Data;
using System.Windows.Forms;

namespace coreUI.Forms
{
    public partial class frmDanhMucMenuUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        coreDTO.DanhMucMenu obj = null;
        public static DataTable dtUpdate;
        public Action InsertToList, UpdateToList;
        public frmDanhMucMenuUpdate()
        {
            InitializeComponent();
            //LoaiDanhMuc = "DanhMucMenu";
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
                    txtThuTuHienThi.Value = 1;
                    txtMa.Focus();
                }
            }
        }
        private bool Save()
        {
            if (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy)
            {
                obj = new coreDTO.DanhMucMenu
                {
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    ThuTuHienThi = txtThuTuHienThi.Value,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new coreDTO.DanhMucMenu
                {
                    ID = dataRow["ID"],
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    ThuTuHienThi = txtThuTuHienThi.Value,
                    CreateDate = null,
                    EditDate = null
                };
            }
            bool OK = (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy) ? coreBUS.DanhMucMenuBUS.Insert(obj) : coreBUS.DanhMucMenuBUS.Update(obj);
            if (OK && obj != null && Int64.TryParse(obj.ID.ToString(), out Int64 _ID) && _ID > 0)
            {
                dtUpdate = coreBUS.DanhMucMenuBUS.List(obj.ID).Tables[coreDTO.DanhMucMenu.tableName];
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

        private void frmDanhMucMenuUpdate_Load(object sender, EventArgs e)
        {
            if (CapNhat >= coreCommon.ThaoTacDuLieu.Sua)
            {
                dataRow = coreBUS.DanhMucMenuBUS.List(ID).Tables[coreDTO.DanhMucMenu.tableName].Rows[0];
                if (coreCommon.coreCommon.IsNull(dataRow)) { coreCommon.coreCommon.ErrorMessageOkOnly("Không lấy được dữ liệu!"); this.DialogResult = DialogResult.Cancel; }
                txtMa.Value = dataRow["Ma"];
                txtTen.Value = dataRow["Ten"];
                txtThuTuHienThi.Value = coreCommon.coreCommon.stringParseInt(dataRow["ThuTuHienThi"].ToString());
            }
        }
    }
}
