using coreControls;
using Infragistics.Win.UltraWinGrid;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Data;
using System.Windows.Forms;
namespace coreReportController
{
    public partial class frmReportParameters : Form
    {
        public string ChuoiThamSoHienThiGrid = "";
        public string ChuoiThamSoHienThiCrystalReport = "";
        public DataTable dtParameters;
        bool GridValidation = true;
        //Thông tin trả về
        public Boolean OK = false;//Ok hay Cancel
        public frmReportParameters()
        {
            InitializeComponent();
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            ug.UpdateData();
            foreach (UltraGridRow row in ug.Rows)
            {
                if (row.Cells["KieuDuLieu"].Value.ToString() == "DATE")
                {
                    if (!Regex.IsMatch(row.Cells["GiaTri"].Value.ToString(), @"\d\d/\d\d/\d\d\d\d"))
                    {
                        coreCommon.coreCommon.ErrorMessageOkOnly("Ngày tháng ở dòng " + (row.Index + 1).ToString() + " không đúng định dạng DD/MM/YYYY!");
                        ug.Rows[row.Index].Activate();
                        ug.Rows[row.Index].Cells["GiaTri"].Activate();
                        ug.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }
                    else
                    {
                        string Date = row.Cells["GiaTri"].Value.ToString().Substring(6, 4) + "-" + row.Cells["GiaTri"].Value.ToString().Substring(3, 2) + "-" + row.Cells["GiaTri"].Value.ToString().Substring(0, 2);
                        row.Cells["GiaTriThamSo"].Value = Date;
                        if (!DateTime.TryParse(Date, out DateTime dDate))
                        {
                            coreCommon.coreCommon.ErrorMessageOkOnly("Ngày tháng ở dòng " + (row.Index + 1).ToString() + " không hợp lệ!");
                            ug.Rows[row.Index].Activate();
                            ug.Rows[row.Index].Cells["GiaTri"].Activate();
                            ug.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }    
                    }    
                }
                if (row.Cells["KieuDuLieu"].Value.ToString() == "NVARCHAR")
                    row.Cells["GiaTriThamSo"].Value = row.Cells["GiaTri"].Value;
                if (!coreCommon.coreCommon.IsNull(row.Cells["GiaTri"].Value))
                {
                    ChuoiThamSoHienThiGrid += row.Cells["DienGiaiThamSo"].Value.ToString() + ": " + row.Cells["GiaTri"].Value.ToString() + "; ";
                    ChuoiThamSoHienThiCrystalReport += row.Cells["DienGiaiThamSo"].Value.ToString() + ": " + row.Cells["GiaTri"].Value.ToString() + ";";
                }
            }
            OK = true;
            DialogResult = DialogResult.OK;
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }
        /// <summary>
        /// Ngừng
        /// </summary>
        private void Cancel()
        {
            OK = false;
            Close();
        }
        private void frmReportParameters_Load(object sender, EventArgs e)
        {
            ug.HiddenColumnsList = "[TenThamSo][GiaTriThamSo][KieuDuLieu]";
            ug.FixedColumnsList = "[DienGiaiThamSo]";
            ug.ReadOnlyColumnsList = "[KieuDuLieu]";
            ug.DataSource = dtParameters;
            ug.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.Default;
            ug.DisplayLayout.Bands[0].Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            ug.DisplayLayout.Bands[0].Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            ug.DisplayLayout.Bands[0].Columns["TenThamSo"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ug.DisplayLayout.Bands[0].Columns["TenThamSo"].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
            ug.DisplayLayout.Bands[0].Columns["DienGiaiThamSo"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ug.DisplayLayout.Bands[0].Columns["DienGiaiThamSo"].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
            ug.DisplayLayout.Bands[0].Columns["GiaTriThamSo"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ug.DisplayLayout.Bands[0].Columns["GiaTriThamSo"].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
            ug.DisplayLayout.Bands[0].Columns["KieuDuLieu"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ug.DisplayLayout.Bands[0].Columns["KieuDuLieu"].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
            ug.DisplayLayout.Bands[0].Columns["GhiChu"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ug.DisplayLayout.Bands[0].Columns["GhiChu"].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
        }
        private void ug_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (!GridValidation || !e.Cell.Row.IsDataRow) return;
            UltraGridRow row = e.Cell.Row;
            object cellValue = e.Cell.Value;
            
            if (e.Cell.Column.Key != "GiaTri") return;
            //Valid mã đối tượng, không cho thêm, ghi tên đối tượng vào cột ghi chú
            
            if (!coreCommon.coreCommon.IsNull(cellValue))
            {
                if (!row.Cells["TenThamSo"].Value.ToString().StartsWith("@IDDanhMuc")) return;
                string MaDanhMucLoaiDoiTuong = row.Cells["TenThamSo"].Value.ToString().Substring(10);
                DataTable dt;
                switch (MaDanhMucLoaiDoiTuong)
                {
                    case "NguoiSuDungCreate":
                    case "NguoiSuDungThanhToanTamUng":
                        //Valid mã danh mục người sử dụng
                        GridValidation = false;
                        row.Cells["GiaTriThamSo"].Value = DBNull.Value;
                        //
                        dt = coreBUS.DanhMucNguoiSuDungBUS.ListValidMa(cellValue);
                        if (dt == null) { GridValidation = true; return; }
                        if (dt.Rows.Count == 1)
                        {
                            GridValidation = false;
                            row.Cells["GiaTri"].Value = dt.Rows[0]["Ma"];
                            row.Cells["GiaTriThamSo"].Value = dt.Rows[0]["ID"];
                            row.Cells["GhiChu"].Value = dt.Rows[0]["Ten"];
                            GridValidation = true;
                        }
                        else
                        {
                            //Show valid form
                            coreUI.Forms.frmDataValid frm_ctValid = new coreUI.Forms.frmDataValid()
                            {
                                validProcedure = new Func<DataTable>(() => coreBUS.DanhMucNguoiSuDungBUS.ListValidMa(null)),
                                validColumn = "Ma",
                                validValue = cellValue
                            };
                            frm_ctValid.ShowDialog();
                            if (frm_ctValid.dataRow == null) { GridValidation = true; return; }
                            GridValidation = false;
                            row.Cells["GiaTri"].Value = frm_ctValid.dataRow["Ma"];
                            row.Cells["GiaTriThamSo"].Value = frm_ctValid.dataRow["ID"];
                            row.Cells["GhiChu"].Value = frm_ctValid.dataRow["Ten"];
                            GridValidation = true;
                        }
                        break;
                    //case "DanhMucTaiKhoan":
                    //    //Valid mã danh mục tài khoản
                    //    GridValidation = false;
                    //    row.Cells["GiaTriThamSo"].Value = DBNull.Value;
                    //    //
                    //    dt = coreBUS.DanhMucNguoiSuDungBUS.ListValidMa(cellValue);
                    //    if (dt == null) { GridValidation = true; return; }
                    //    if (dt.Rows.Count == 1)
                    //    {
                    //        GridValidation = false;
                    //        row.Cells["GiaTri"].Value = dt.Rows[0]["Ma"];
                    //        row.Cells["GiaTriThamSo"].Value = dt.Rows[0]["ID"];
                    //        row.Cells["GhiChu"].Value = dt.Rows[0]["Ten"];
                    //        GridValidation = true;
                    //    }
                    //    else
                    //    {
                    //        //Show valid form
                    //        coreUI.Forms.frmDataValid frm_ctValid = new coreUI.Forms.frmDataValid()
                    //        {
                    //            validProcedure = new Func<DataTable>(() => coreBUS.DanhMucNguoiSuDungBUS.ListValidMa(null)),
                    //            validColumn = "Ma",
                    //            validValue = cellValue
                    //        };
                    //        frm_ctValid.ShowDialog();
                    //        if (frm_ctValid.dataRow == null) { GridValidation = true; return; }
                    //        GridValidation = false;
                    //        row.Cells["GiaTri"].Value = frm_ctValid.dataRow["Ma"];
                    //        row.Cells["GiaTriThamSo"].Value = frm_ctValid.dataRow["ID"];
                    //        row.Cells["GhiChu"].Value = frm_ctValid.dataRow["Ten"];
                    //        GridValidation = true;
                    //    }
                    //    break;
                    default:
                        object IDDanhMucLoaiDoiTuong = coreBUS.DanhMucLoaiDoiTuongBUS.GetID(MaDanhMucLoaiDoiTuong);
                        //Valid mã danh mục đối tượng
                        GridValidation = false;
                        row.Cells["GiaTriThamSo"].Value = DBNull.Value;
                        //
                        dt = coreBUS.DanhMucDoiTuongBUS.List(null, IDDanhMucLoaiDoiTuong, cellValue);
                        if (dt == null) { GridValidation = true; return; }
                        if (dt.Rows.Count == 1)
                        {
                            GridValidation = false;
                            row.Cells["GiaTri"].Value = dt.Rows[0]["Ma"];
                            row.Cells["GiaTriThamSo"].Value = dt.Rows[0]["ID"];
                            row.Cells["GhiChu"].Value = dt.Rows[0]["Ten"];
                            GridValidation = true;
                        }
                        else
                        {
                            //Show valid form
                            coreUI.Forms.frmDataValid frm_ctValid = new coreUI.Forms.frmDataValid()
                            {
                                validProcedure = new Func<DataTable>(() => coreBUS.DanhMucDoiTuongBUS.List(null, IDDanhMucLoaiDoiTuong, null)),
                                validColumn = "Ma",
                                validValue = cellValue
                            };
                            frm_ctValid.ShowDialog();
                            if (frm_ctValid.dataRow == null) { GridValidation = true; return; }
                            GridValidation = false;
                            row.Cells["GiaTri"].Value = frm_ctValid.dataRow["Ma"];
                            row.Cells["GiaTriThamSo"].Value = frm_ctValid.dataRow["ID"];
                            row.Cells["GhiChu"].Value = frm_ctValid.dataRow["Ten"];
                            GridValidation = true;
                        }
                        break;
                }
            }
            else
            {
                GridValidation = false;
                row.Cells["GiaTri"].Value = DBNull.Value;
                row.Cells["GiaTriThamSo"].Value = DBNull.Value;
                if (row.Cells["KieuDuLieu"].Value.ToString() != "DATE")
                    row.Cells["GhiChu"].Value = DBNull.Value;
                GridValidation = true;
            }    
        }
    }
}
