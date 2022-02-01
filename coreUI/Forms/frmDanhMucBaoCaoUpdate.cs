using coreControls;
using coreDTO;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using static coreUI.coreUI;
namespace coreUI.Forms
{
    public partial class frmDanhMucBaoCaoUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        coreDTO.DanhMucBaoCao obj = null;
        public object DefaultValue;
        public static DataTable dtUpdate;
        public Action InsertToList, UpdateToList;
        public frmDanhMucBaoCaoUpdate()
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
                    CapNhat = 1;
                    //Xóa text box
                    txtMa.Value = null;
                    txtTen.Value = null;
                    txtTenStore.Value = null;
                    cboKhoGiay.Value = 1;
                    cboKieuIn.Value = 1;
                    txtChucDanhKi.Value = null;
                    txtDienGiaiKi.Value = null;
                    txtTenNguoiKi.Value = null;
                    txtMaDanhMucBaoCaoThamChieu.ID = null;
                    txtMaDanhMucBaoCaoThamChieu.Value = null;
                    txtTenDanhMucBaoCaoThamChieu.Value = null;
                    txtMaDanhMucBaoCaoCopyCot.ID = null;
                    txtMaDanhMucBaoCaoCopyCot.Value = null;
                    txtTenDanhMucBaoCaoCopyCot.Value = null;
                    txtFileExcelMau.Value = null;
                    txtSheetExcelMau.Value = null;
                    txtSoDongBatDau.Value = null;
                    txtMaDanhMucNhomBaoCao.ID = null;
                    txtMaDanhMucNhomBaoCao.Value = null;
                    txtTenDanhMucNhomBaoCao.Value = null;
                    txtTenDanhMucBaoCaoCopyCot.Enabled = true;
                    txtMa.Focus();
                }
            }
        }
        private bool Save()
        {

            if (CapNhat == 1 || CapNhat == 3)
            {
                obj = new coreDTO.DanhMucBaoCao
                {
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    ReportProcedureName = txtTenStore.Value,
                    FixedColumnList = txtFixedColumn.Value,
                    KhoGiay = cboKhoGiay.Value,
                    HuongIn = cboKieuIn.Value,
                    ChucDanhKy = txtChucDanhKi.Value,
                    DienGiaiKy = txtDienGiaiKi.Value,
                    TenNguoiKy = txtTenNguoiKi.Value,
                    ThamChieuChungTu = chkThamChieuChungTu.Checked,
                    IDDanhMucBaoCaoThamChieu = txtMaDanhMucBaoCaoThamChieu.ID,
                    MaDanhMucBaoCaoThamChieu = txtMaDanhMucBaoCaoThamChieu.Value,
                    TenDanhMucBaoCaoThamChieu = txtTenDanhMucBaoCaoThamChieu.Value,
                    FileExcelMau = txtFileExcelMau.Value,
                    SheetExcelMau = txtSheetExcelMau.Value,
                    SoDongBatDau = txtSoDongBatDau.Value,
                    IDDanhMucNhomBaoCao = txtMaDanhMucNhomBaoCao.ID,
                    MaDanhMucNhomBaoCao = txtMaDanhMucNhomBaoCao.Value,
                    TenDanhMucNhomBaoCao = txtTenDanhMucNhomBaoCao.Value,
                    IDDanhMucBaoCaoCopyCot = txtMaDanhMucBaoCaoCopyCot.ID,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new coreDTO.DanhMucBaoCao
                {
                    ID = dataRow["ID"],
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    ReportProcedureName = txtTenStore.Value,
                    FixedColumnList = txtFixedColumn.Value,
                    KhoGiay = cboKhoGiay.Value,
                    HuongIn = cboKieuIn.Value,
                    ChucDanhKy = txtChucDanhKi.Value,
                    DienGiaiKy = txtDienGiaiKi.Value,
                    TenNguoiKy = txtTenNguoiKi.Value,
                    ThamChieuChungTu = chkThamChieuChungTu.Checked,
                    IDDanhMucBaoCaoThamChieu = txtMaDanhMucBaoCaoThamChieu.ID,
                    MaDanhMucBaoCaoThamChieu = txtMaDanhMucBaoCaoThamChieu.Value,
                    TenDanhMucBaoCaoThamChieu = txtTenDanhMucBaoCaoThamChieu.Value,
                    FileExcelMau = txtFileExcelMau.Value,
                    SheetExcelMau = txtSheetExcelMau.Value,
                    SoDongBatDau = txtSoDongBatDau.Value,
                    IDDanhMucNhomBaoCao = txtMaDanhMucNhomBaoCao.ID,
                    MaDanhMucNhomBaoCao = txtMaDanhMucNhomBaoCao.Value,
                    TenDanhMucNhomBaoCao = txtTenDanhMucNhomBaoCao.Value,
                    CreateDate = null,
                    EditDate = null
                };
            }
            bool OK = (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy) ? coreBUS.DanhMucBaoCaoBUS.Insert(ref obj) : coreBUS.DanhMucBaoCaoBUS.Update(ref obj);
            if (OK && obj != null && Int64.TryParse(obj.ID.ToString(), out Int64 _ID) && _ID > 0)
            {
                dtUpdate = coreBUS.DanhMucBaoCaoBUS.List(obj.ID).Tables[DanhMucBaoCao.tableName];
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
            txtMaDanhMucBaoCaoCopyCot.Enabled = (CapNhat != 2);
            //
            txtMa.Value = DefaultValue;
            txtTen.Value = DefaultValue;
            if (CapNhat >= 2)
            {
                txtMa.Value = dataRow["Ma"];
                txtTen.Value = dataRow["Ten"];
                txtTenStore.Value = dataRow["ReportProcedureName"];
                txtFixedColumn.Value = dataRow["FixedColumnList"];
                cboKhoGiay.Value = dataRow["KhoGiay"];
                cboKieuIn.Value = dataRow["HuongIn"];
                txtChucDanhKi.Value = dataRow["ChucDanhKy"];
                txtDienGiaiKi.Value = dataRow["DienGiaiKy"];
                txtTenNguoiKi.Value = dataRow["TenNguoiKy"];
                chkThamChieuChungTu.Checked = bool.Parse(dataRow["ThamChieuChungTu"].ToString());
                txtMaDanhMucBaoCaoThamChieu.Value = dataRow["MaDanhMucBaoCaoThamChieu"];
                txtMaDanhMucBaoCaoThamChieu.ID = dataRow["IDDanhMucBaoCaoThamChieu"];
                txtTenDanhMucBaoCaoThamChieu.Value = dataRow["TenDanhMucBaoCaoThamChieu"];
                txtFileExcelMau.Value = dataRow["FileExcelMau"];
                txtSheetExcelMau.Value = dataRow["SheetExcelMau"];
                txtSoDongBatDau.Value = dataRow["SoDongBatDau"];
                txtMaDanhMucNhomBaoCao.Value = dataRow["MaDanhMucNhomBaoCao"];
                txtMaDanhMucNhomBaoCao.ID = dataRow["IDDanhMucNhomBaoCao"];
                txtTenDanhMucNhomBaoCao.Value = dataRow["TenDanhMucNhomBaoCao"];
            }
            //Set valid
            coreUI.validData.SetValidTextbox(txtMaDanhMucNhomBaoCao, new saTextBox[1] { txtTenDanhMucNhomBaoCao }, new Func<DataTable>(() => coreBUS.DanhMucNhomBaoCaoBUS.List(null)), "Ma", "ID", "Ten", null, null, null);
            coreUI.validData.SetValidTextbox(txtMaDanhMucBaoCaoThamChieu, new saTextBox[1] { txtTenDanhMucBaoCaoThamChieu }, new Func<DataTable>(() => coreBUS.DanhMucBaoCaoBUS.List(null).Tables[0]), "Ma", "ID", "Ten", null, null, null);
            coreUI.validData.SetValidTextbox(txtMaDanhMucBaoCaoCopyCot, new saTextBox[1] { txtTenDanhMucBaoCaoCopyCot }, new Func<DataTable>(() => coreBUS.DanhMucBaoCaoBUS.List(null).Tables[0]), "Ma", "ID", "Ten", null, null, null);
            //Load danh mục khổ giấy và kiểu in
            cboKhoGiay.Items.Add(1, "A4");
            cboKhoGiay.Items.Add(2, "A3");
            cboKieuIn.Items.Add(1, "Dọc");
            cboKieuIn.Items.Add(2, "Ngang");
        }
    }
}
