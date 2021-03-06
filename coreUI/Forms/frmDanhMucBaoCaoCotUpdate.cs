using System;
using System.Data;
using System.Windows.Forms;

namespace coreUI.Forms
{
    public partial class frmDanhMucBaoCaoCotUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        public Object IDDanhMucBaoCao = null;
        coreDTO.DanhMucBaoCaoCot obj = null;
        public static DataTable dtUpdate;
        public Action InsertToList, UpdateToList;
        public frmDanhMucBaoCaoCotUpdate()
        {
            InitializeComponent();
        }
        protected override void SaveData(bool AddNew)
        {
            if (Save())
            {
                if (!AddNew)
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them;
                    //Xóa text box
                    txtMa.Value = null;
                    txtTen.Value = null;
                    txtDoRong.Value = 1;
                    txtChieuCao.Value = 1;
                    txtNhom.Value = null;
                    txtThuTu.Value = 0;
                    txtTenCotExcel.Value = null;
                    cboKieuDuLieu.Value = 1;
                    txtMa.Focus();
                }
            }
        }

        private bool Save()
        {

            if (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy)
            {
                obj = new coreDTO.DanhMucBaoCaoCot
                {
                    IDDanhMucBaoCao = IDDanhMucBaoCao,
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    ColumnWidth = txtDoRong.Value,
                    HeaderHeight = txtChieuCao.Value,
                    TenNhomCot = txtNhom.Value,
                    ThuTu = txtThuTu.Value,
                    TenCotExcel = txtTenCotExcel.Value,
                    KieuDuLieu = cboKieuDuLieu.Value,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new coreDTO.DanhMucBaoCaoCot
                {
                    ID = dataRow["ID"],
                    IDDanhMucBaoCao = IDDanhMucBaoCao,
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    ColumnWidth = txtDoRong.Value,
                    HeaderHeight = txtChieuCao.Value,
                    TenNhomCot = txtNhom.Value,
                    ThuTu = txtThuTu.Value,
                    TenCotExcel = txtTenCotExcel.Value,
                    KieuDuLieu = cboKieuDuLieu.Value,
                    CreateDate = null,
                    EditDate = null
                };
            }
            bool OK = (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy) ? coreBUS.DanhMucBaoCaoCotBUS.Insert(obj) : coreBUS.DanhMucBaoCaoCotBUS.Update(obj);
            if (OK && obj != null && Int64.TryParse(obj.ID.ToString(), out Int64 _ID) && _ID > 0)
            {
                dtUpdate = coreBUS.DanhMucBaoCaoCotBUS.List(obj.ID);
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
            cboKieuDuLieu.Items.Add(1, "Text");
            cboKieuDuLieu.Items.Add(2, "Ngày tháng");
            cboKieuDuLieu.Items.Add(3, "Số nguyên");
            cboKieuDuLieu.Items.Add(4, "Số thực");
            cboKieuDuLieu.Items.Add(5, "Check");

            txtTenCotExcel.Enabled = false;
            cboKieuDuLieu.Enabled = false;

            if (CapNhat >= coreCommon.ThaoTacDuLieu.Sua)
            {
                dataRow = coreBUS.DanhMucBaoCaoCotBUS.List(ID).Rows[0];
                if (coreCommon.coreCommon.IsNull(dataRow)) { coreCommon.coreCommon.ErrorMessageOkOnly("Không lấy được dữ liệu!"); this.DialogResult = DialogResult.Cancel; }
                IDDanhMucBaoCao = dataRow["IDDanhMucBaoCao"];
                txtMa.Value = dataRow["Ma"];
                txtTen.Value = dataRow["Ten"];
                txtDoRong.Value = dataRow["ColumnWidth"];
                txtChieuCao.Value = dataRow["HeaderHeight"];
                txtNhom.Value = dataRow["TenNhomCot"];
                txtThuTu.Value = dataRow["ThuTu"];
                txtTenCotExcel.Value = dataRow["TenCotExcel"];
                cboKieuDuLieu.Value = dataRow["KieuDuLieu"];
            }
        }
    }
}
