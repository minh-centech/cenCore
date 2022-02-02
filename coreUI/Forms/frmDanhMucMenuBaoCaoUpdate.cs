using coreBUS;
using coreControls;
using coreDTO;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using static coreUI.coreUI;

namespace coreUI.Forms
{
    public partial class frmDanhMucMenuBaoCaoUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        public Object IDDanhMucMenu = null;
        coreDTO.DanhMucMenuBaoCao obj = null;
        public static DataTable dtUpdate;
        public Action InsertToList, UpdateToList;
        public frmDanhMucMenuBaoCaoUpdate()
        {
            InitializeComponent();
            //LoaiDanhMuc = "DanhMucBaoCao";
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
                    txtMaDanhMucBaoCao.Value = null;
                    txtTenDanhMucBaoCao.Value = null;
                    txtNoiDungHienThi.Value = null;
                    chkTachNhom.Checked = false;
                    txtThuTuHienThi.Value = 0;
                }
            }
        }
        private bool Save()
        {

            if (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy)
            {
                obj = new coreDTO.DanhMucMenuBaoCao
                {
                    IDDanhMucMenu = IDDanhMucMenu,
                    IDDanhMucBaoCao = txtMaDanhMucBaoCao.ID,
                    MaDanhMucBaoCao = txtMaDanhMucBaoCao.Value,
                    TenDanhMucBaoCao = txtTenDanhMucBaoCao.Value,
                    NoiDungHienThi = txtNoiDungHienThi.Value,
                    PhanCachNhom = chkTachNhom.Checked,
                    ThuTuHienThi = txtThuTuHienThi.Value,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new coreDTO.DanhMucMenuBaoCao
                {
                    ID = dataRow["ID"],
                    IDDanhMucMenu = IDDanhMucMenu,
                    IDDanhMucBaoCao = txtMaDanhMucBaoCao.ID,
                    MaDanhMucBaoCao = txtMaDanhMucBaoCao.Value,
                    TenDanhMucBaoCao = txtTenDanhMucBaoCao.Value,
                    NoiDungHienThi = txtNoiDungHienThi.Value,
                    PhanCachNhom = chkTachNhom.Checked,
                    ThuTuHienThi = txtThuTuHienThi.Value,
                    CreateDate = null,
                    EditDate = null
                };
            }
            coreBUS.DanhMucMenuBaoCaoBUS _BUS = new coreBUS.DanhMucMenuBaoCaoBUS();
            bool OK = (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy) ? coreBUS.DanhMucMenuBaoCaoBUS.Insert(obj) : coreBUS.DanhMucMenuBaoCaoBUS.Update(obj);
            if (OK && obj != null && Int64.TryParse(obj.ID.ToString(), out Int64 _ID) && _ID > 0)
            {
                dtUpdate = coreBUS.DanhMucMenuBaoCaoBUS.List(obj.ID);
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



        private void frmDanhMucBaoCaoUpdate_Load(object sender, EventArgs e)
        {
            coreUI.validData.SetValidTextbox(txtMaDanhMucBaoCao, new saTextBox[1] { txtTenDanhMucBaoCao }, new Func<DataTable>(() => DanhMucBaoCaoBUS.List(null).Tables[0]), "Ma", "ID", "Ten", null, null, null);
            if (CapNhat >= coreCommon.ThaoTacDuLieu.Sua)
            {
                dataRow = coreBUS.DanhMucMenuBaoCaoBUS.List(ID).Rows[0];
                if (coreCommon.coreCommon.IsNull(dataRow)) { coreCommon.coreCommon.ErrorMessageOkOnly("Không lấy được dữ liệu!"); this.DialogResult = DialogResult.Cancel; }
                IDDanhMucMenu = dataRow["IDDanhMucMenu"];
                txtMaDanhMucBaoCao.Value = dataRow["MaDanhMucBaoCao"];
                txtMaDanhMucBaoCao.ID = dataRow["IDDanhMucBaoCao"];
                txtTenDanhMucBaoCao.Value = dataRow["TenDanhMucBaoCao"];
                txtNoiDungHienThi.Value = dataRow["NoiDungHienThi"];
                chkTachNhom.Checked = coreCommon.coreCommon.stringParseBoolean(dataRow["PhanCachNhom"]);
                txtThuTuHienThi.Value = int.Parse(dataRow["ThuTuHienThi"].ToString());
            }
            
        }

        private void txtTenDanhMucBaoCao_ValueChanged(object sender, EventArgs e)
        {
            if (CapNhat == coreCommon.ThaoTacDuLieu.Them) txtNoiDungHienThi.Value = txtTenDanhMucBaoCao.Value;
        }
    }
}
