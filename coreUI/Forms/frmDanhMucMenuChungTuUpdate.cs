using coreBUS;
using coreControls;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using static coreUI.coreUI;

namespace coreUI.Forms
{
    public partial class frmDanhMucMenuChungTuUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        public Object IDDanhMucMenu = null;
        coreDTO.DanhMucMenuChungTu obj = null;
        public static DataTable dtUpdate;
        public Action InsertToList, UpdateToList;
        public frmDanhMucMenuChungTuUpdate()
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
                    txtNoiDungHienThi.Value = null;
                    chkTachNhom.Checked = false;
                    txtThuTuHienThi.Value = 0;
                    txtMaDanhMucChungTu.Focus();
                }
            }
        }
        private bool Save()
        {

            if (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy)
            {
                obj = new coreDTO.DanhMucMenuChungTu
                {
                    IDDanhMucMenu = IDDanhMucMenu,
                    IDDanhMucChungTu = txtMaDanhMucChungTu.ID,
                    MaDanhMucChungTu = txtMaDanhMucChungTu.Value,
                    TenDanhMucChungTu = txtTenDanhMucChungTu.Value,
                    NoiDungHienThi = txtNoiDungHienThi.Value,
                    PhanCachNhom = chkTachNhom.Checked,
                    ThuTuHienThi = txtThuTuHienThi.Value,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new coreDTO.DanhMucMenuChungTu
                {
                    ID = dataRow["ID"],
                    IDDanhMucMenu = IDDanhMucMenu,
                    IDDanhMucChungTu = txtMaDanhMucChungTu.ID,
                    MaDanhMucChungTu = txtMaDanhMucChungTu.Value,
                    TenDanhMucChungTu = txtTenDanhMucChungTu.Value,
                    NoiDungHienThi = txtNoiDungHienThi.Value,
                    PhanCachNhom = chkTachNhom.Checked,
                    ThuTuHienThi = txtThuTuHienThi.Value,
                    CreateDate = null,
                    EditDate = null
                };
            }
            bool OK = (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy) ? coreBUS.DanhMucMenuChungTuBUS.Insert(obj) : coreBUS.DanhMucMenuChungTuBUS.Update(obj);
            if (OK && obj != null && Int64.TryParse(obj.ID.ToString(), out Int64 _ID) && _ID > 0)
            {
                dtUpdate = coreBUS.DanhMucMenuChungTuBUS.List(obj.ID);
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
            coreUI.validData.SetValidTextbox(txtMaDanhMucChungTu, new saTextBox[1] { txtTenDanhMucChungTu }, new Func<DataTable>(() => DanhMucChungTuBUS.List(null).Tables[0]), "Ma", "ID", "Ten", null, null, null);
            if (CapNhat >= coreCommon.ThaoTacDuLieu.Sua)
            {
                dataRow = coreBUS.DanhMucMenuChungTuBUS.List(ID).Rows[0];
                if (coreCommon.coreCommon.IsNull(dataRow)) { coreCommon.coreCommon.ErrorMessageOkOnly("Không lấy được dữ liệu!"); this.DialogResult = DialogResult.Cancel; }
                IDDanhMucMenu = dataRow["IDDanhMucMenu"];
                txtMaDanhMucChungTu.Value = dataRow["MaDanhMucChungTu"];
                txtMaDanhMucChungTu.ID = dataRow["IDDanhMucChungTu"];
                txtTenDanhMucChungTu.Value = dataRow["TenDanhMucChungTu"];
                txtNoiDungHienThi.Value = dataRow["NoiDungHienThi"];
                chkTachNhom.Checked = coreCommon.coreCommon.stringParseBoolean(dataRow["PhanCachNhom"]);
                txtThuTuHienThi.Value = int.Parse(dataRow["ThuTuHienThi"].ToString());
            }
        }

        private void txtTenDanhMucChungTu_ValueChanged(object sender, EventArgs e)
        {
            if (CapNhat == coreCommon.ThaoTacDuLieu.Them) txtNoiDungHienThi.Value = txtTenDanhMucChungTu.Value;
        }
    }
}
