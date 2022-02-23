using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace coreReportController
{
    public partial class frmReportViewer : Form
    {
        public object dTuNgay = null, dDenNgay = null, IDDanhMucSale = null, IDDanhMucKhachHang = null, IDDanhMucXe = null, IDDanhMucNhomHangVanChuyen = null, IDDanhMucChuXe = null;

        public Int16 LoaiBaoCao = 0;
        public Int16 LoaiApDung = 0; //Loại áp dụng nếu là báo cáo động
        //Danh sách file báo cáo
        public String ReportFileName = "";
        //XML chứa dữ liệu báo cáo
        public String DataXMLPath = "";
        //Chuối chứa danh sách cột hiển thị trên grid
        public String DanhSachCot;
        public String DanhSachTieuDeCot;
        //XML chứa tham số & giá trị tham số
        public String ThamSoXMLPath = "";
        //Có tham chiếu tới chứng từ hay không
        public Boolean ThamChieuChungTu = false;
        //ID danh mục báo cáo drill-down
        public String IDDanhMucBaoCaoThamChieu = "";
        public String TieuDeBaoCao = "";
        public String IDDanhMucBaoCao = "";
        public String TenMayIn = "";
        public String FixedColumnList = "";


        public String reportProcedureName = "";
        public DataTable dtParameters = null;
        public DataTable dtData = new DataTable();
        
        //Lấy cấu trúc cột report để test
        public DataTable dtCauTrucCot = new DataTable();
        // Màu
        public String MauHeaderColumn = "";
        public String MauDetailBold = "";
        //Có phải được mở từ phân hệ quản trị hay không
        public Boolean PhanHeQuanTri = false;
        //
        public Form MDIParent = null;
        public Byte[] LogoImage;
        //
        public String ChuoiThamSoHienThi, ChuoiThamSoHienThiGrid;
        //CrystalDecisions.CrystalReports.Engine.ReportDocument rpt;
        public string MaDanhMucBaoCao = String.Empty, TenFileExcel = String.Empty, TenSheetExcel = String.Empty, fName = String.Empty;
        public int SoDongBatDau = 1;
        bool bRefresh = false;
        public frmReportViewer()
        {
            InitializeComponent();
            ugBaoCao.HiddenColumnsList = "[LoaiManHinh][TenDanhMucChungTu]";
        }
        private void cmdClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        private void DeleteReportAfterUse()
        {
            if (File.Exists(ReportFileName))
                File.Delete(ReportFileName);
            if (File.Exists(DataXMLPath))
                File.Delete(DataXMLPath);

        }
        private void LoadReport()
        {
            if (bRefresh)
            {
                //switch (MaDanhMucBaoCao)
                //{
                //    case cenCommon.LoaiBaoCao.BC_DOANHTHU_KD:
                //        dtData = Reports.rep_BC_DOANHTHU_KD(dTuNgay, dDenNgay, IDDanhMucKhachHang, IDDanhMucSale);
                //        break;
                //    case cenCommon.LoaiBaoCao.BC_DOANHTHU_KD_CNKH:
                //        dtData = Reports.rep_BC_DOANHTHU_KD_CNKH(dTuNgay, dDenNgay, IDDanhMucKhachHang, IDDanhMucSale);
                //        break;
                //    case cenCommon.LoaiBaoCao.BC_CHI_PHI_VAN_TAI:
                //        dtData = Reports.rep_BC_CHI_PHI_VAN_TAI(dTuNgay, dDenNgay, IDDanhMucNhomHangVanChuyen, IDDanhMucSale);
                //        break;
                //    case cenCommon.LoaiBaoCao.BC_CHI_PHI_VAN_TAI_BO_SUNG:
                //        dtData = Reports.rep_BC_CHI_PHI_VAN_TAI_BO_SUNG(dTuNgay, dDenNgay, IDDanhMucNhomHangVanChuyen, IDDanhMucSale);
                //        break;
                //    case cenCommon.LoaiBaoCao.BC_DOANHTHU_KT:
                //        dtData = Reports.rep_BC_DOANHTHU_KT(dTuNgay, dDenNgay, IDDanhMucKhachHang, IDDanhMucSale);
                //        break;
                //    case cenCommon.LoaiBaoCao.BC_LOINHUAN_KD:
                //        dsData = Reports.rep_BC_LOINHUAN_KD(dTuNgay, dDenNgay, IDDanhMucKhachHang, IDDanhMucSale);
                //        dtData = dsData.Tables[0];
                //        break;
                //    case cenCommon.LoaiBaoCao.BC_SUACHUA:
                //        dtData = Reports.rep_BC_SUACHUA(dTuNgay, dDenNgay, IDDanhMucXe);
                //        break;
                //    case cenCommon.LoaiBaoCao.BC_TU_QT:
                //        dtData = Reports.rep_BC_TU_QT(dTuNgay, dDenNgay, IDDanhMucKhachHang);
                //        break;
                //    case cenCommon.LoaiBaoCao.BC_TU_TIENDUONG:
                //        dtData = Reports.rep_BC_TU_TIENDUONG(dTuNgay, dDenNgay, IDDanhMucChuXe);
                //        break;
                //}
            }
            ugBaoCao.FixedColumnsList = FixedColumnList;
            ugBaoCao.AddSummaryRow = false;
            ugBaoCao.isReport = true;
            ugBaoCao.DataSource = dtData;
            ugBaoCao.DisplayLayout.Bands[0].Override.FilterUIType = FilterUIType.Default;
            //ugBaoCao.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.True; //WrapText
            foreach (UltraGridColumn uc in ugBaoCao.DisplayLayout.Bands[0].Columns)
            {
                if (uc.Key.ToUpper() == "RGROUP" | uc.Key.ToUpper() == "BOLD" | uc.Key.ToUpper() == "FIXDONG" | uc.Key.ToUpper() == "COLOR")
                {
                    uc.Hidden = true;
                }
                else
                {
                    coreCommon.coreCommon.SetGridColumnMask(uc);
                    coreCommon.coreCommon.SetGridColumnWidth(uc);
                }
            }
            if (ugBaoCao.Rows.Count > 0)
                ugBaoCao.Rows[0].Selected = true;
        }
        private void frmReportViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeleteReportAfterUse();
            //rpt.Close();
            //rpt.Dispose();
        }
        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            if (MDIParent != null) this.MdiParent = MDIParent;
            txtDieuKien.Text = ChuoiThamSoHienThiGrid;
            LoadReport();
        }
        private void ugBaoCao_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            //if (!bRefresh)
            //{
            if (e.Row.Band.Columns.Exists("rBold") && e.Row.Cells["rBold"].Value != DBNull.Value && Convert.ToInt16(e.Row.Cells["rBold"].Value) == 1)
            {
                e.Row.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                e.Row.Appearance.BackColor = Color.SteelBlue;
                //if (MauDetailBold != "")
                //    e.Row.Appearance.BackColor = cenCommon.GlobalVariables.UIntToColor(Convert.ToUInt32(MauDetailBold));
            }


            if (e.Row.Band.Columns.Exists("rBold") && e.Row.Cells["rBold"].Value != DBNull.Value && Convert.ToInt16(e.Row.Cells["rBold"].Value) == 2)
            {
                e.Row.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                e.Row.Appearance.BackColor = Color.LightBlue;
                ////if (MauDetailBold != "")
                //    e.Row.Appearance.BackColor = cenCommon.GlobalVariables.UIntToColor(Convert.ToUInt32(MauDetailBold));
            }

            if (e.Row.Band.Columns.Exists("rBold") && e.Row.Cells["rBold"].Value != DBNull.Value && Convert.ToInt16(e.Row.Cells["rBold"].Value) == 3)
            {
                e.Row.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                //e.Row.Appearance.BackColor = Color.Orange;
                //if (MauDetailBold != "")
                //    e.Row.Appearance.BackColor = cenCommon.GlobalVariables.UIntToColor(Convert.ToUInt32(MauDetailBold));
            }

            if (e.Row.Band.Columns.Exists("FixDong") && e.Row.Cells["FixDong"].Value != DBNull.Value && Convert.ToBoolean(e.Row.Cells["FixDong"].Value) == true)
            {
                e.Row.Fixed = true;
            }

            if (e.Row.Band.Columns.Exists("Color") && e.Row.Cells["Color"].Value != DBNull.Value)
            {
                e.Row.Appearance.BackColor = coreCommon.coreCommon.UIntToColor(Convert.ToUInt32(e.Row.Cells["Color"].Value));
            }

            //}
        }
        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key.ToUpper())
            {
                case "BTEXCEL":
                    coreCommon.coreCommon.ExportGrid2Excel(ugBaoCao);
                    //switch (MaDanhMucBaoCao)
                    //{
                    //    case cenCommon.LoaiBaoCao.BC_DOANHTHU_KD:
                    //        fName = cenCommon.GlobalVariables.OutputDir + @"\" + "BC_DOANHTHU_KD" + DateTime.Now.Day.ToString("00") + DateTime.Now.Month.ToString("00") + DateTime.Now.Year.ToString("0000") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00");
                    //        ExportTemplate();
                    //        break;
                    //    case cenCommon.LoaiBaoCao.BC_DOANHTHU_KD_CNKH:
                    //        fName = cenCommon.GlobalVariables.OutputDir + @"\" + "BC_DOANHTHU_KD_CNKH" + DateTime.Now.Day.ToString("00") + DateTime.Now.Month.ToString("00") + DateTime.Now.Year.ToString("0000") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00");
                    //        ExportTemplate();
                    //        break;
                    //    case cenCommon.LoaiBaoCao.BC_CHI_PHI_VAN_TAI:
                    //        fName = cenCommon.GlobalVariables.OutputDir + @"\" + "BC_CHI_PHI_VAN_TAI" + DateTime.Now.Day.ToString("00") + DateTime.Now.Month.ToString("00") + DateTime.Now.Year.ToString("0000") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00");
                    //        ExportTemplate();
                    //        break;
                    //    case cenCommon.LoaiBaoCao.BC_CHI_PHI_VAN_TAI_BO_SUNG:
                    //        fName = cenCommon.GlobalVariables.OutputDir + @"\" + "BC_CHI_PHI_VAN_TAI_BO_SUNG" + DateTime.Now.Day.ToString("00") + DateTime.Now.Month.ToString("00") + DateTime.Now.Year.ToString("0000") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00");
                    //        ExportTemplate();
                    //        break;
                    //    case cenCommon.LoaiBaoCao.BC_DOANHTHU_KT:
                    //        fName = cenCommon.GlobalVariables.OutputDir + @"\" + "BC_DOANHTHU_KT" + DateTime.Now.Day.ToString("00") + DateTime.Now.Month.ToString("00") + DateTime.Now.Year.ToString("0000") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00");
                    //        ExportTemplate();
                    //        break;
                    //    case cenCommon.LoaiBaoCao.BC_LOINHUAN_KD:
                    //        fName = cenCommon.GlobalVariables.OutputDir + @"\" + "BC_LOINHUAN_KD" + DateTime.Now.Day.ToString("00") + DateTime.Now.Month.ToString("00") + DateTime.Now.Year.ToString("0000") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00");
                    //        ExportBC_LOINHUAN_KD();
                    //        break;
                    //    case cenCommon.LoaiBaoCao.BC_SUACHUA:
                    //        fName = cenCommon.GlobalVariables.OutputDir + @"\" + "BC_SUACHUA" + DateTime.Now.Day.ToString("00") + DateTime.Now.Month.ToString("00") + DateTime.Now.Year.ToString("0000") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00");
                    //        ExportTemplate();
                    //        break;
                    //    case cenCommon.LoaiBaoCao.BC_TU_QT:
                    //        fName = cenCommon.GlobalVariables.OutputDir + @"\" + "BC_TU_QT" + DateTime.Now.Day.ToString("00") + DateTime.Now.Month.ToString("00") + DateTime.Now.Year.ToString("0000") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00");
                    //        ExportTemplate();
                    //        break;
                    //    case cenCommon.LoaiBaoCao.BC_TU_TIENDUONG:
                    //        fName = cenCommon.GlobalVariables.OutputDir + @"\" + "BC_TU_TIENDUONG" + DateTime.Now.Day.ToString("00") + DateTime.Now.Month.ToString("00") + DateTime.Now.Year.ToString("0000") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00");
                    //        ExportTemplate();
                    //        break;
                    //}
                    break;
                case "BTTAILAI":
                    bool OK = true;
                    if (dtParameters.Rows.Count > 0)
                    {
                        frmReportParameters frmReportParameters = new frmReportParameters()
                        {
                            Text = Text,
                            dtParameters = dtParameters
                        };
                        frmReportParameters.ShowDialog();
                        OK = frmReportParameters.OK;
                        if (OK)
                        {
                            dtParameters = frmReportParameters.dtParameters;
                            ChuoiThamSoHienThiGrid = frmReportParameters.ChuoiThamSoHienThiGrid;
                        }
                        frmReportParameters.Dispose();

                    }
                    if (!OK) return;
                    txtDieuKien.Text = ChuoiThamSoHienThiGrid;
                    SqlParameter[] sqlParameters = new SqlParameter[dtParameters.Rows.Count + 1];
                    sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", coreCommon.GlobalVariables.IDDonVi);
                    if (dtParameters.Rows.Count > 0)
                    {
                        for (int i = 0; i <= dtParameters.Rows.Count - 1; i++)
                        {
                            sqlParameters[i + 1] = new SqlParameter(dtParameters.Rows[i]["TenThamSo"].ToString(), dtParameters.Rows[i]["GiaTriThamSo"]);
                        }
                    }
                    Cursor.Current = Cursors.WaitCursor;
                    coreDAO.ConnectionDAO connectionDAO = new coreDAO.ConnectionDAO();
                    dtData = connectionDAO.tableList(sqlParameters, reportProcedureName, reportProcedureName);
                    Cursor.Current = Cursors.Default;
                    LoadReport();
                    break;
            }
        }
        private void ugBaoCao_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            //Nếu tham chiếu tới chứng từ thì mở chứng từ
            if (ThamChieuChungTu && e.Row.Band.Columns.Exists("IDChungTu") && e.Row.Cells["IDChungTu"].Value != DBNull.Value)
            {
                //cenCommonUIapps.cenCommonUIapps.runChungTu(e.Row.Cells["LoaiManHinh"].Value.ToString(), e.Row.Cells["TenDanhMucChungTu"].Value.ToString(), e.Row.Cells["IDDanhMucChungTu"].Value.ToString(), e.Row.Cells["MaDanhMucChungTu"].Value.ToString(), this.MDIParent, e.Row.Cells["IDChungTu"].Value);
            }
        }
        ////Mẫu không có footer
        //private void ExportTemplate()
        //{
        //    if (dtData.Rows.Count == 0) { { cenCommon.cenCommon.ErrorMessageOkOnly("Không có dữ liệu!"); return; } }
        //    IWorkbook wbMau;
        //    IRow ro;
        //    ISheet sh;

        //    string FullExcelTemplateFileName = TenFileExcel;

        //    //1. Mở file mẫu
        //    if (string.IsNullOrEmpty(FullExcelTemplateFileName) || string.IsNullOrWhiteSpace(FullExcelTemplateFileName))
        //    {
        //        FullExcelTemplateFileName = cenCommon.cenCommon.OpenFileDialog("Chọn file mẫu", "", "Excel file (*.xlsx)|*.xlsx");
        //    }
        //    else
        //        FullExcelTemplateFileName = cenCommon.GlobalVariables.ExcelTemplateDir + TenFileExcel;

        //    if (!File.Exists(FullExcelTemplateFileName)) { cenCommon.cenCommon.ErrorMessageOkOnly("Không tìm thấy file mẫu " + FullExcelTemplateFileName + "!"); return; }

        //    //2.Tạo file kết quả
        //    String FileName = cenCommon.cenCommon.OpenSaveFileDialog("Chọn file lưu kết quả export", fName, "Excel file (*.xlsx)|*.xlsx");
        //    if (FileName == "") return;
        //    if (File.Exists(FileName)) File.Delete(FileName);
        //    using (FileStream fsMau = new FileStream(FullExcelTemplateFileName, FileMode.Open, FileAccess.Read, FileShare.Read))
        //    {
        //        wbMau = new XSSFWorkbook(fsMau);
        //        if (wbMau == null) throw new Exception($"Không mở được file Excel: {FullExcelTemplateFileName}");
        //        fsMau.Close();
        //    }

        //    sh = wbMau.GetSheet(TenSheetExcel);
        //    int lastRowIndexOrig = sh.LastRowNum;
        //    int soDongFooter = sh.LastRowNum - SoDongBatDau;

        //    int i = 1;
        //    // Tạo thêm số dòng cần chèn vào + footer sẽ copy đến
        //    int soDongCanThem = dtData.Rows.Count - 1; // 1 dòng mẫu đã có
        //    while (i <= soDongCanThem)
        //    {
        //        sh.CreateRow(lastRowIndexOrig + i);
        //        i++;
        //    }
        //    // Chuyển Footer đi
        //    for (i = soDongFooter; i > 0; i--)
        //    {
        //        RemoveMergedRegionOnRow(sh, sh.GetRow(sh.LastRowNum - (soDongFooter - i)));
        //        CopyRow(wbMau, sh, SoDongBatDau + i, sh.LastRowNum - (soDongFooter - i));
        //    }

        //    // Copy định dạng
        //    for (i = 1; i <= dtData.Rows.Count - 1; i++)
        //    {
        //        ro = sh.GetRow(SoDongBatDau + i);

        //        if (ro != null)
        //            RemoveMergedRegionOnRow(sh, ro);
        //        else
        //            sh.CreateRow(SoDongBatDau + i);

        //        CopyRow(wbMau, sh, SoDongBatDau, SoDongBatDau + i);
        //    }
        //    //Điền câu điều kiện
        //    switch (MaDanhMucBaoCao)
        //    {
        //        case cenCommon.LoaiBaoCao.BC_DOANHTHU_KD:
        //            sh.GetRow(2).GetCell(0).SetCellValue(ChuoiThamSoHienThiGrid);
        //            break;
        //        case cenCommon.LoaiBaoCao.BC_DOANHTHU_KD_CNKH:
        //            sh.GetRow(3).GetCell(0).SetCellValue(ChuoiThamSoHienThiGrid);
        //            break;
        //        case cenCommon.LoaiBaoCao.BC_CHI_PHI_VAN_TAI:
        //        case cenCommon.LoaiBaoCao.BC_CHI_PHI_VAN_TAI_BO_SUNG:
        //            sh.GetRow(2).GetCell(0).SetCellValue(ChuoiThamSoHienThiGrid);
        //            break;
        //        case cenCommon.LoaiBaoCao.BC_DOANHTHU_KT:
        //            sh.GetRow(2).GetCell(0).SetCellValue(ChuoiThamSoHienThiGrid);
        //            break;
        //        case cenCommon.LoaiBaoCao.BC_LOINHUAN_KD:
        //            sh.GetRow(3).GetCell(0).SetCellValue(ChuoiThamSoHienThiGrid);
        //            break;
        //        case cenCommon.LoaiBaoCao.BC_SUACHUA:
        //            sh.GetRow(5).GetCell(0).SetCellValue(ChuoiThamSoHienThiGrid);
        //            break;
        //        case cenCommon.LoaiBaoCao.BC_TU_QT:
        //            sh.GetRow(2).GetCell(0).SetCellValue(ChuoiThamSoHienThiGrid);
        //            break;
        //        case cenCommon.LoaiBaoCao.BC_TU_TIENDUONG:
        //            sh.GetRow(2).GetCell(0).SetCellValue(ChuoiThamSoHienThiGrid);
        //            break;
        //    }
        //    // Điền dữ liệu
        //    for (i = 0; i <= dtData.Rows.Count - 1; i++)
        //    {
        //        ro = sh.GetRow(SoDongBatDau + i);
        //        foreach (DataRow dc in dtCauTrucCot.Rows)
        //        {
        //            if (!cenCommon.cenCommon.IsNull(dc["TenCotExcel"]) && !String.IsNullOrWhiteSpace(dc["TenCotExcel"].ToString()))
        //            {
        //                int SoCotExcel = int.Parse(dc["TenCotExcel"].ToString());
        //                //byte.TryParse(dsData.Tables[0].Rows[i]["rBold"].ToString(), out byte rBold);
        //                switch (dc["KieuDuLieu"].ToString())
        //                {
        //                    case "3": //Số nguyên
        //                        if (!cenCommon.cenCommon.IsNull(dtData.Rows[i][dc["Ma"].ToString()]))
        //                        {
        //                            long.TryParse(dtData.Rows[i][dc["Ma"].ToString()].ToString(), out long lGiaTri);
        //                            ro.GetCell(SoCotExcel).SetCellValue(lGiaTri);
        //                        }
        //                        break;
        //                    case "4": //Số thực
        //                        if (!cenCommon.cenCommon.IsNull(dtData.Rows[i][dc["Ma"].ToString()]))
        //                        {
        //                            double.TryParse(dtData.Rows[i][dc["Ma"].ToString()].ToString(), out double dGiaTri);
        //                            ro.GetCell(SoCotExcel).SetCellValue(dGiaTri);
        //                        }
        //                        break;
        //                    case "2": //Ngày thàng
        //                        if (!cenCommon.cenCommon.IsNull(dtData.Rows[i][dc["Ma"].ToString()]))
        //                        {
        //                            DateTime.TryParse(dtData.Rows[i][dc["Ma"].ToString()].ToString(), out DateTime dGiaTri);
        //                            ro.GetCell(SoCotExcel).SetCellValue(dGiaTri);
        //                        }
        //                        break;
        //                    default:
        //                        ro.GetCell(SoCotExcel).SetCellValue(dtData.Rows[i][dc["Ma"].ToString()].ToString());
        //                        break;
        //                }
        //                if (dtData.Columns.Contains("rBold") && !cenCommon.cenCommon.IsNull(dtData.Rows[i]["rBold"]))
        //                {
        //                    IFont font = wbMau.CreateFont();
        //                    font.FontHeightInPoints = 10;
        //                    font.FontName = "Times New Roman";
        //                    font.IsBold = true;
        //                    ro.GetCell(SoCotExcel).CellStyle.SetFont(font);
        //                }
        //            }
        //        }
        //    }
        //    // Save            
        //    using (var fskq = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write))
        //    {
        //        wbMau.Write(fskq);
        //    }
        //    wbMau.Close();
        //    //
        //    if (cenCommon.cenCommon.QuestionMessage("Đã kết xuất báo cáo, bạn có muốn mở file ra không?", 0) == DialogResult.Yes)
        //    {
        //        System.Diagnostics.Process.Start(FileName);
        //    }
        //}
        //private void ExportBC_LOINHUAN_KD()
        //{
        //    if (dtData.Rows.Count == 0) { { cenCommon.cenCommon.ErrorMessageOkOnly("Không có dữ liệu!"); return; } }
        //    IWorkbook wbMau;
        //    IRow ro;
        //    ISheet sh;

        //    string FullExcelTemplateFileName = TenFileExcel;
        //    //1. Mở file mẫu
        //    if (string.IsNullOrEmpty(FullExcelTemplateFileName) || string.IsNullOrWhiteSpace(FullExcelTemplateFileName))
        //    {
        //        FullExcelTemplateFileName = cenCommon.cenCommon.OpenFileDialog("Chọn file mẫu", "", "Excel file (*.xlsx)|*.xlsx");
        //    }
        //    else
        //        FullExcelTemplateFileName = cenCommon.GlobalVariables.ExcelTemplateDir + TenFileExcel;

        //    if (!File.Exists(FullExcelTemplateFileName)) { cenCommon.cenCommon.ErrorMessageOkOnly("Không tìm thấy file mẫu " + FullExcelTemplateFileName + "!"); return; }
        //    //2.Tạo file kết quả
        //    String FileName = cenCommon.cenCommon.OpenSaveFileDialog("Chọn file lưu kết quả export", fName, "Excel file (*.xlsx)|*.xlsx");
        //    if (FileName == "") return;
        //    if (File.Exists(FileName)) File.Delete(FileName);
        //    using (FileStream fsMau = new FileStream(FullExcelTemplateFileName, FileMode.Open, FileAccess.Read, FileShare.Read))
        //    {
        //        wbMau = new XSSFWorkbook(fsMau);
        //        if (wbMau == null) throw new Exception($"Không mở được file Excel: {FullExcelTemplateFileName}");
        //        fsMau.Close();
        //    }
        //    //CHI_TIET
        //    sh = wbMau.GetSheet(TenSheetExcel);
        //    int lastRowIndexOrig = sh.LastRowNum;
        //    int soDongFooter = sh.LastRowNum - SoDongBatDau;
        //    int i = 1;
        //    // Tạo thêm số dòng cần chèn vào + footer sẽ copy đến
        //    int soDongCanThem = dtData.Rows.Count - 1; // 1 dòng mẫu đã có
        //    while (i <= soDongCanThem)
        //    {
        //        sh.CreateRow(lastRowIndexOrig + i);
        //        i++;
        //    }
        //    // Chuyển Footer đi
        //    for (i = soDongFooter; i > 0; i--)
        //    {
        //        RemoveMergedRegionOnRow(sh, sh.GetRow(sh.LastRowNum - (soDongFooter - i)));
        //        CopyRow(wbMau, sh, SoDongBatDau + i, sh.LastRowNum - (soDongFooter - i));
        //    }

        //    // Copy định dạng
        //    for (i = 1; i <= dtData.Rows.Count - 1; i++)
        //    {
        //        ro = sh.GetRow(SoDongBatDau + i);

        //        if (ro != null)
        //            RemoveMergedRegionOnRow(sh, ro);
        //        else
        //            sh.CreateRow(SoDongBatDau + i);

        //        CopyRow(wbMau, sh, SoDongBatDau, SoDongBatDau + i);
        //    }
        //    //Điền câu điều kiện
        //    sh.GetRow(3).GetCell(0).SetCellValue(ChuoiThamSoHienThiGrid);
        //    // Điền dữ liệu
        //    for (i = 0; i <= dtData.Rows.Count - 1; i++)
        //    {
        //        ro = sh.GetRow(SoDongBatDau + i);
        //        foreach (DataRow dc in dtCauTrucCot.Rows)
        //        {
        //            if (!cenCommon.cenCommon.IsNull(dc["TenCotExcel"]) && !String.IsNullOrWhiteSpace(dc["TenCotExcel"].ToString()))
        //            {
        //                int SoCotExcel = int.Parse(dc["TenCotExcel"].ToString());
        //                //byte.TryParse(dsData.Tables[0].Rows[i]["rBold"].ToString(), out byte rBold);
        //                switch (dc["KieuDuLieu"].ToString())
        //                {
        //                    case "3": //Số nguyên
        //                        if (!cenCommon.cenCommon.IsNull(dtData.Rows[i][dc["Ma"].ToString()]))
        //                        {
        //                            long.TryParse(dtData.Rows[i][dc["Ma"].ToString()].ToString(), out long lGiaTri);
        //                            ro.GetCell(SoCotExcel).SetCellValue(lGiaTri);
        //                        }
        //                        break;
        //                    case "4": //Số thực
        //                        if (!cenCommon.cenCommon.IsNull(dtData.Rows[i][dc["Ma"].ToString()]))
        //                        {
        //                            double.TryParse(dtData.Rows[i][dc["Ma"].ToString()].ToString(), out double dGiaTri);
        //                            ro.GetCell(SoCotExcel).SetCellValue(dGiaTri);
        //                        }
        //                        break;
        //                    case "2": //Ngày thàng
        //                        if (!cenCommon.cenCommon.IsNull(dtData.Rows[i][dc["Ma"].ToString()]))
        //                        {
        //                            DateTime.TryParse(dtData.Rows[i][dc["Ma"].ToString()].ToString(), out DateTime dGiaTri);
        //                            ro.GetCell(SoCotExcel).SetCellValue(dGiaTri);
        //                        }
        //                        break;
        //                    default:
        //                        ro.GetCell(SoCotExcel).SetCellValue(dtData.Rows[i][dc["Ma"].ToString()].ToString());
        //                        break;
        //                }
        //                if (dtData.Columns.Contains("rBold") && !cenCommon.cenCommon.IsNull(dtData.Rows[i]["rBold"]))
        //                {
        //                    IFont font = wbMau.CreateFont();
        //                    font.FontHeightInPoints = 10;
        //                    font.FontName = "Times New Roman";
        //                    font.IsBold = true;
        //                    ro.GetCell(SoCotExcel).CellStyle.SetFont(font);
        //                }
        //            }
        //        }
        //    }
        //    // Save            
        //    using (var fskq = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write))
        //    {
        //        wbMau.Write(fskq);
        //    }
        //    wbMau.Close();
        //    //VIEW
        //    FullExcelTemplateFileName = FileName;
        //    //2.Tạo file kết quả
        //    FileName = cenCommon.GlobalVariables.OutputDir + @"\" + "BC_LOINHUAN_KD" + DateTime.Now.Day.ToString("00") + DateTime.Now.Month.ToString("00") + DateTime.Now.Year.ToString("0000") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00") + ".xlsx";
        //    if (File.Exists(FileName)) File.Delete(FileName);
        //    using (FileStream fsMau = new FileStream(FullExcelTemplateFileName, FileMode.Open, FileAccess.Read, FileShare.Read))
        //    {
        //        wbMau = new XSSFWorkbook(fsMau);
        //        if (wbMau == null) throw new Exception($"Không mở được file Excel: {FullExcelTemplateFileName}");
        //        fsMau.Close();
        //    }
        //    sh = wbMau.GetSheet("VIEW");
        //    SoDongBatDau = 6;
        //    lastRowIndexOrig = sh.LastRowNum;
        //    soDongFooter = sh.LastRowNum - SoDongBatDau;
        //    i = 1;
        //    // Tạo thêm số dòng cần chèn vào + footer sẽ copy đến
        //    soDongCanThem = dsData.Tables[1].Rows.Count - 1; // 1 dòng mẫu đã có
        //    while (i <= soDongCanThem)
        //    {
        //        sh.CreateRow(lastRowIndexOrig + i);
        //        i++;
        //    }
        //    // Chuyển Footer đi
        //    for (i = soDongFooter; i > 0; i--)
        //    {
        //        RemoveMergedRegionOnRow(sh, sh.GetRow(sh.LastRowNum - (soDongFooter - i)));
        //        CopyRow(wbMau, sh, SoDongBatDau + i, sh.LastRowNum - (soDongFooter - i));
        //    }

        //    // Copy định dạng
        //    for (i = 1; i <= dsData.Tables[1].Rows.Count - 1; i++)
        //    {
        //        ro = sh.GetRow(SoDongBatDau + i);

        //        if (ro != null)
        //            RemoveMergedRegionOnRow(sh, ro);
        //        else
        //            sh.CreateRow(SoDongBatDau + i);

        //        CopyRow(wbMau, sh, SoDongBatDau, SoDongBatDau + i);
        //    }
        //    //Điền câu điều kiện
        //    sh.GetRow(3).GetCell(0).SetCellValue(ChuoiThamSoHienThiGrid);
        //    // Điền dữ liệu
        //    for (i = 0; i <= dsData.Tables[1].Rows.Count - 1; i++)
        //    {
        //        ro = sh.GetRow(SoDongBatDau + i);
        //        foreach (DataRow dc in dtCauTrucCot.Rows)
        //        {
        //            ro.GetCell(0).SetCellValue(dsData.Tables[1].Rows[i]["Stt"].ToString());
        //            ro.GetCell(1).SetCellValue(dsData.Tables[1].Rows[i]["SoDonHang"].ToString());
        //            ro.GetCell(2).SetCellValue(dsData.Tables[1].Rows[i]["DebitNote"].ToString());
        //            ro.GetCell(3).SetCellValue(dsData.Tables[1].Rows[i]["MaDanhMucKhachHang"].ToString());
        //            ro.GetCell(4).SetCellValue(dsData.Tables[1].Rows[i]["MaDanhMucTuyenVanTai"].ToString());
        //            ro.GetCell(5).SetCellValue(dsData.Tables[1].Rows[i]["TenDanhMucTuyenVanTai"].ToString());
        //            ro.GetCell(6).SetCellValue(dsData.Tables[1].Rows[i]["MaDanhMucChuXe"].ToString());
        //            ro.GetCell(7).SetCellValue(dsData.Tables[1].Rows[i]["BienSo_ChuXeNgoai"].ToString());
        //            ro.GetCell(8).SetCellValue(dsData.Tables[1].Rows[i]["TenDanhMucTaiXe"].ToString());
        //            ro.GetCell(9).SetCellValue(dsData.Tables[1].Rows[i]["NgayDongTraHang"].ToString());
        //            double dGiaTri;
        //            double.TryParse(dsData.Tables[1].Rows[i]["SoTienLoiNhuan"].ToString(), out dGiaTri);
        //            ro.GetCell(10).SetCellValue(dGiaTri);
        //            double.TryParse(dsData.Tables[1].Rows[i]["SoTienCuoc"].ToString(), out dGiaTri);
        //            ro.GetCell(11).SetCellValue(dGiaTri);
        //            double.TryParse(dsData.Tables[1].Rows[i]["SoTienThuTuc"].ToString(), out dGiaTri);
        //            ro.GetCell(12).SetCellValue(dGiaTri);
        //            double.TryParse(dsData.Tables[1].Rows[i]["SoTienDoanhThuKhac"].ToString(), out dGiaTri);
        //            ro.GetCell(13).SetCellValue(dGiaTri);
        //            double.TryParse(dsData.Tables[1].Rows[i]["SoTienDoanhThuTong"].ToString(), out dGiaTri);
        //            ro.GetCell(14).SetCellValue(dGiaTri);
        //            double.TryParse(dsData.Tables[1].Rows[i]["SoTienChiPhiVanTai"].ToString(), out dGiaTri);
        //            ro.GetCell(15).SetCellValue(dGiaTri);
        //            double.TryParse(dsData.Tables[1].Rows[i]["SoTienChiPhiThuTuc"].ToString(), out dGiaTri);
        //            ro.GetCell(16).SetCellValue(dGiaTri);
        //            double.TryParse(dsData.Tables[1].Rows[i]["SoTienChiPhiKhac"].ToString(), out dGiaTri);
        //            ro.GetCell(17).SetCellValue(dGiaTri);
        //            double.TryParse(dsData.Tables[1].Rows[i]["SoTienChiPhiTong"].ToString(), out dGiaTri);
        //            ro.GetCell(18).SetCellValue(dGiaTri);
        //            ro.GetCell(19).SetCellValue(dsData.Tables[1].Rows[i]["GhiChu"].ToString());
        //        }
        //    }
        //    // Save            
        //    using (var fskq = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write))
        //    {
        //        wbMau.Write(fskq);
        //    }
        //    wbMau.Close();
        //    //
        //    if (cenCommon.cenCommon.QuestionMessage("Đã kết xuất báo cáo, bạn có muốn mở file ra không?", 0) == DialogResult.Yes)
        //    {
        //        System.Diagnostics.Process.Start(FileName);
        //    }
        //}
        //private void RemoveMergedRegionOnRow(ISheet sh, IRow ro)
        //{
        //    for (var i = sh.NumMergedRegions - 1; i >= 0; i--)
        //    {
        //        var cellRangeAddress = sh.GetMergedRegion(i);
        //        if (cellRangeAddress.FirstRow == ro.RowNum) sh.RemoveMergedRegion(i);
        //    }
        //}
        //private IRow CopyRow(IWorkbook workbook, ISheet worksheet, int sourceRowNum, int destinationRowNum)
        //{
        //    // Get the source / new row

        //    var sourceRow = worksheet.GetRow(sourceRowNum);
        //    if (sourceRow == null) return null;

        //    var newRow = worksheet.GetRow(destinationRowNum);

        //    // If the row exist in destination, push down all rows by 1 else create a new row
        //    if (newRow == null)
        //    {
        //        newRow = worksheet.CreateRow(destinationRowNum);
        //    }

        //    // Loop through source columns to add to new row
        //    for (var i = sourceRow.FirstCellNum; i <= sourceRow.LastCellNum; i++)
        //    //for (var i = 0; i <= sourceRow.LastCellNum; i++)
        //    {
        //        // Grab a copy of the old/new cell
        //        var oldCell = sourceRow.GetCell(i);
        //        var newCell = newRow.CreateCell(i);

        //        // If the old cell is null jump to next cell
        //        if (oldCell == null) continue;

        //        // Copy style from old cell and apply to new cell
        //        //var newCellStyle = workbook.CreateCellStyle();
        //        //newCellStyle.CloneStyleFrom(oldCell.CellStyle);
        //        //newCell.CellStyle = newCellStyle;
        //        newCell.CellStyle = oldCell.CellStyle;

        //        // If there is a cell comment, copy
        //        if (newCell.CellComment != null) newCell.CellComment = oldCell.CellComment;

        //        // If there is a cell hyperlink, copy
        //        if (oldCell.Hyperlink != null) newCell.Hyperlink = oldCell.Hyperlink;

        //        // Set the cell data type
        //        newCell.SetCellType(oldCell.CellType);

        //        // Set the cell data value

        //        switch (oldCell.CellType)
        //        {
        //            case CellType.Blank:
        //                //
        //                newCell.SetCellValue(oldCell.StringCellValue);
        //                break;
        //            case CellType.Boolean:
        //                newCell.SetCellValue(oldCell.BooleanCellValue);
        //                break;
        //            case CellType.Error:
        //                newCell.SetCellErrorValue(oldCell.ErrorCellValue);
        //                break;
        //            case CellType.Formula:
        //                newCell.CellFormula = oldCell.CellFormula;
        //                break;
        //            case CellType.Numeric:
        //                newCell.SetCellValue(oldCell.NumericCellValue);
        //                break;
        //            case CellType.String:
        //                newCell.SetCellValue(oldCell.RichStringCellValue);
        //                break;
        //            case CellType.Unknown:
        //                newCell.SetCellValue(oldCell.StringCellValue);
        //                break;
        //        }
        //    }

        //    // If there are are any merged regions in the source row, copy to new row
        //    for (var i = 0; i < worksheet.NumMergedRegions; i++)
        //    {
        //        var cellRangeAddress = worksheet.GetMergedRegion(i);
        //        if (cellRangeAddress.FirstRow != sourceRow.RowNum) continue;
        //        var newCellRangeAddress = new CellRangeAddress(newRow.RowNum,
        //                                                       (newRow.RowNum +
        //                                                        (cellRangeAddress.FirstRow -
        //                                                         cellRangeAddress.LastRow)),
        //                                                       cellRangeAddress.FirstColumn,
        //                                                       cellRangeAddress.LastColumn);
        //        worksheet.AddMergedRegion(newCellRangeAddress);
        //    }

        //    return newRow;
        //}
    }
}
