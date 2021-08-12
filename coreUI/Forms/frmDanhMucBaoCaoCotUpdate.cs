using System;
using System.Data;
using System.Windows.Forms;

namespace coreUI.Forms
{
    public partial class frmDanhMucBaoCaoCotUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        public Object IDDanhMucBaoCao = null;
        coreDTO.DanhMucBaoCaoCot obj = null;
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
                    CapNhat = 1;
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

            if (CapNhat == 1 || CapNhat == 3)
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
            bool OK = (CapNhat == 1 || CapNhat == 3) ? coreBUS.DanhMucBaoCaoCotBUS.Insert(ref obj) : coreBUS.DanhMucBaoCaoCotBUS.Update(ref obj);
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
        private void frmDanhMucDonViUpdate_Load(object sender, EventArgs e)
        {
            cboKieuDuLieu.Items.Add(1, "Text");
            cboKieuDuLieu.Items.Add(2, "Ngày tháng");
            cboKieuDuLieu.Items.Add(3, "Số nguyên");
            cboKieuDuLieu.Items.Add(4, "Số thực");
            cboKieuDuLieu.Items.Add(5, "Check");

            txtTenCotExcel.Enabled = false;
            cboKieuDuLieu.Enabled = false;

            if (CapNhat >= 2)
            {
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
