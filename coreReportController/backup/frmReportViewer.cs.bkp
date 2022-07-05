using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using CrystalDecisions.ReportAppServer.DataDefModel;
using CrystalDecisions.ReportAppServer.DataSetConversion;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.ReportAppServer.ReportDefModel;

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
        public System.Data.DataSet dsData = new System.Data.DataSet();
        System.Data.DataSet dsChungTuDetail;

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

        public CrystalDecisions.CrystalReports.Engine.ReportDocument rpt;

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
            ugBaoCao.AddSummaryRow = true;
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
            if (dsData.Tables.Count > 1)
            {
                Boolean OK = PrintProcess_Parameter(ReportFileName, dsData, ChuoiThamSoHienThi, out String GeneratedReportFile, out String XMLDataFile);
                rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                rpt.Load(GeneratedReportFile, CrystalDecisions.Shared.OpenReportMethod.OpenReportByTempCopy);
                SetDataSourceUsingSchemaFile(rpt.ReportClientDocument, XMLDataFile);
                crystalReportViewer.ReportSource = rpt;
            }
        }
        private void frmReportViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeleteReportAfterUse();
            rpt.Close();
            rpt.Dispose();
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
                    System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
                    coreDAO.ConnectionDAO connectionDAO = new coreDAO.ConnectionDAO();
                    System.Data.DataSet dsData = connectionDAO.dsList(sqlParameters, reportProcedureName);
                    if (dsData != null)
                    {
                        dsData.Tables[0].TableName = coreCommon.GlobalVariables.tblReportDataGridName;
                        if (dsData.Tables.Count >= 2)
                            dsData.Tables[1].TableName = coreCommon.GlobalVariables.tblReportHeaderName;
                        if (dsData.Tables.Count == 3)
                            dsData.Tables[2].TableName = coreCommon.GlobalVariables.tblReportDataName;
                    }
                    dtData = dsData.Tables[coreCommon.GlobalVariables.tblReportDataGridName];
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

        public Boolean PrintProcess_Parameter(String FileReport, System.Data.DataSet dsData, string ChuoiThamSoHienThi, out String GeneratedReportFile, out String XMLDataFile)
        {
            Boolean OK = false;
            //Tên file report được sinh ra
            XMLDataFile = "";

            GeneratedReportFile = coreCommon.GlobalVariables.TempDir + "\\" + Guid.NewGuid().ToString() + ".rpt";//cenCommon.GlobalVariables.TempDir + Guid.NewGuid().ToString() + ".rpt";
            String FormattedValue = ""; //Chuỗi giá trị sau khi định dạng
            String NumberFormatString = "";

            //Bắt đầu xử lý in chứng từ
            if (dsData != null && dsData.Tables.Count > 1 && dsData.Tables[coreCommon.GlobalVariables.tblReportHeaderName].Rows.Count > 0)
            {
                String ChungTuDetailDataXMLPath = "";
                //Mở file Report
                CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                rpt.Load(FileReport, CrystalDecisions.Shared.OpenReportMethod.OpenReportByTempCopy);
                //Lưu vào file tạm
                rpt.SaveAs(GeneratedReportFile);
                rpt.Close();
                //Mở file tạm để ghi thông tin
                rpt.Load(GeneratedReportFile, CrystalDecisions.Shared.OpenReportMethod.OpenReportByTempCopy);
                //
                CrystalDecisions.ReportAppServer.ClientDoc.ISCDReportClientDocument rptClientDoc = rpt.ReportClientDocument;
                CrystalDecisions.ReportAppServer.Controllers.ReportDefController2 reportDefController = rptClientDoc.ReportDefController;
                CrystalDecisions.ReportAppServer.Controllers.ReportObjectController reportObjectController = rptClientDoc.ReportDefController.ReportObjectController;
                CrystalDecisions.ReportAppServer.ReportDefModel.ReportObjects reportObjects = reportObjectController.GetReportObjectsByKind(CrReportObjectKindEnum.crReportObjectKindText);
                //Gán dữ liệu cho Header Chứng từ
                DataRow drChungTu = dsData.Tables[coreCommon.GlobalVariables.tblReportHeaderName].Rows[0];
                DataTable dtChungTuDetail = dsData.Tables[coreCommon.GlobalVariables.tblReportDataName].Copy();
                foreach (FormulaField formulaObject in rptClientDoc.DataDefController.DataDefinition.FormulaFields)
                {
                    if (formulaObject.Name.ToUpper().StartsWith("F"))
                    {
                        String DataFieldName = formulaObject.Name.Substring(1).ToUpper();
                        switch (DataFieldName)
                        {
                            case "DIEUKIEN":
                                rpt.DataDefinition.FormulaFields[formulaObject.Name].Text = "\"" + ChuoiThamSoHienThi + "\"";
                                break;
                            case "NGAY":
                                if (drChungTu.Table.Columns.Contains("NgayHachToan"))
                                {
                                    rpt.DataDefinition.FormulaFields[formulaObject.Name].Text = "\"" + Convert.ToDateTime(drChungTu["NgayHachToan"]).Day + "\"";
                                }
                                else
                                    rpt.DataDefinition.FormulaFields[formulaObject.Name].Text = "\"" + Convert.ToDateTime(drChungTu["NgayLap"]).Day + "\"";
                                break;
                            case "THANG":
                                if (drChungTu.Table.Columns.Contains("NgayHachToan"))
                                {
                                    rpt.DataDefinition.FormulaFields[formulaObject.Name].Text = "\"" + Convert.ToDateTime(drChungTu["NgayHachToan"]).Month + "\"";
                                }
                                else
                                    rpt.DataDefinition.FormulaFields[formulaObject.Name].Text = "\"" + Convert.ToDateTime(drChungTu["NgayLap"]).Month + "\"";
                                break;
                            case "NAM4":
                                if (drChungTu.Table.Columns.Contains("NgayHachToan"))
                                {
                                    rpt.DataDefinition.FormulaFields[formulaObject.Name].Text = "\"" + Convert.ToDateTime(drChungTu["NgayHachToan"]).Year + "\"";
                                }
                                else
                                    rpt.DataDefinition.FormulaFields[formulaObject.Name].Text = "\"" + Convert.ToDateTime(drChungTu["NgayLap"]).Year + "\"";
                                break;
                            case "NAM2":
                                if (drChungTu.Table.Columns.Contains("NgayHachToan"))
                                {
                                    rpt.DataDefinition.FormulaFields[formulaObject.Name].Text = "\"" + Convert.ToDateTime(drChungTu["NgayHachToan"]).Year.ToString("0#") + "\"";
                                }
                                else
                                    rpt.DataDefinition.FormulaFields[formulaObject.Name].Text = "\"" + Convert.ToDateTime(drChungTu["NgayLap"]).Year.ToString("0#") + "\"";
                                break;
                            case "SOTIENBANGCHU":
                                if (drChungTu.Table.Columns.Contains("SoTienTong") && drChungTu["SoTienTong"] != DBNull.Value)
                                    rpt.DataDefinition.FormulaFields[formulaObject.Name].Text = "\"" + coreCommon.coreCommon.SoTienBangChu(Math.Round(Double.Parse(drChungTu["SoTienTong"].ToString()), 0).ToString()) + " đồng." + "\"";
                                break;
                            default:
                                //Lấy giá trị từ DataSet
                                if (!drChungTu.Table.Columns.Contains(DataFieldName) || drChungTu[DataFieldName] == DBNull.Value) break;
                                FormattedValue = drChungTu[DataFieldName].ToString();
                                //Sửa lại làm tròn theo tham số cụ thể như độ rộng cột
                                if (DataFieldName.ToUpper().StartsWith("SOLUONG") || DataFieldName.ToUpper().StartsWith("KHOILUONG") || DataFieldName.ToUpper().StartsWith("CBM")) //Định dạng số lượng
                                {
                                    NumberFormatString = "n2";
                                    FormattedValue = Convert.ToDecimal(drChungTu[DataFieldName]).ToString(NumberFormatString, coreCommon.GlobalVariables.ci);
                                }
                                if (DataFieldName.ToUpper().StartsWith("SOTIEN")) //Định dạng tiền
                                {
                                    NumberFormatString = "n0";
                                    FormattedValue = Convert.ToDecimal(drChungTu[DataFieldName]).ToString(NumberFormatString, coreCommon.GlobalVariables.ci);
                                }
                                rpt.DataDefinition.FormulaFields[formulaObject.Name].Text = "\"" + FormattedValue + "\"";
                                break;
                        }
                    }
                }
                //Xử lý in chi tiết chứng từ, chỉ dùng cho những chứng từ có phần chi tiết
                if (dtChungTuDetail != null && dtChungTuDetail.Rows.Count > 0)
                {
                    //Lưu chi tiết chứng từ ra XML
                    ChungTuDetailDataXMLPath = coreCommon.GlobalVariables.TempDir + "\\" + Guid.NewGuid().ToString() + ".xml";
                    dtChungTuDetail.TableName = "ChungTuChiTiet";
                    dsChungTuDetail = new System.Data.DataSet();
                    dsChungTuDetail.Tables.Add(dtChungTuDetail);
                    dsChungTuDetail.WriteXml(ChungTuDetailDataXMLPath);
                    //Gán DataSource cho file report
                    AddDataSourceUsingSchemaFile(rpt.ReportClientDocument, ChungTuDetailDataXMLPath, "ChungTuChiTiet", dsChungTuDetail, false);
                    //Gán dataField cho các formula
                    foreach (FormulaField formulaObject in rptClientDoc.DataDefController.DataDefinition.FormulaFields)
                    {
                        if (formulaObject.Name.ToUpper().StartsWith("DT") && dtChungTuDetail.Columns.Contains(formulaObject.Name.Substring(2)))
                        {
                            String ColumnName = formulaObject.Name.Substring(2);
                            String DataFieldName = "{" + dtChungTuDetail.TableName + "." + ColumnName + "}";
                            //Sửa lại làm tròn theo tham số cụ thể như độ rộng cột
                            if (ColumnName.ToUpper().StartsWith("SOLUONG") || ColumnName.ToUpper().StartsWith("KHOILUONG") || ColumnName.ToUpper().StartsWith("CBM")) //Định dạng số lượng
                            {
                                rpt.DataDefinition.FormulaFields[formulaObject.Name].Text = "IIF(" + DataFieldName + "=0,\"-\",ToText(" + DataFieldName + ", " + "2" + ", \"" + coreCommon.GlobalVariables.DigitSymbol + "\", \"" + coreCommon.GlobalVariables.DecimalSymbol + "\"))";
                            }
                            else if (ColumnName.ToUpper().StartsWith("SOTIEN") || ColumnName.ToUpper().StartsWith("THUESUAT")) //Định dạng số lượng
                            {
                                rpt.DataDefinition.FormulaFields[formulaObject.Name].Text = "IIF(" + DataFieldName + "=0,\"-\",ToText(" + DataFieldName + ", " + "0" + ", \"" + coreCommon.GlobalVariables.DigitSymbol + "\", \"" + coreCommon.GlobalVariables.DecimalSymbol + "\"))";
                            }
                            else
                            {
                                rpt.DataDefinition.FormulaFields[formulaObject.Name].Text = DataFieldName;
                            }
                        }
                    }
                    XMLDataFile = ChungTuDetailDataXMLPath;
                }
                rptClientDoc.Save();
                rpt.Close();
                rpt.Dispose();
                OK = true;
            }
            return OK;
        }

        private void SetDataSourceUsingSchemaFile(CrystalDecisions.ReportAppServer.ClientDoc.ISCDReportClientDocument rcDoc, string schema_file_name)
        {
            PropertyBag crLogonInfo;			// logon info 
            PropertyBag crAttributes;			// logon attributes 
            CrystalDecisions.ReportAppServer.DataDefModel.ConnectionInfo crConnectionInfo;	// connection info 
            if (rcDoc.DataDefController.Database.Tables.Count > 0)
            {
                CrystalDecisions.ReportAppServer.DataDefModel.ISCRTable crTable = rcDoc.DataDefController.Database.Tables[0];
                // database table 
                // create logon property 
                crLogonInfo = new PropertyBag();
                crLogonInfo["XML File Path"] = schema_file_name;
                // create logon attributes 
                crAttributes = new PropertyBag();
                crAttributes["Database DLL"] = "crdb_adoplus.dll";
                crAttributes["QE_DatabaseType"] = "ADO.NET (XML)";
                crAttributes["QE_ServerDescription"] = "NewDataSet";
                crAttributes["QE_SQLDB"] = true;
                crAttributes["QE_LogonProperties"] = crLogonInfo;
                // create connection info 
                crConnectionInfo = new CrystalDecisions.ReportAppServer.DataDefModel.ConnectionInfo();
                crConnectionInfo.Kind = CrConnectionInfoKindEnum.crConnectionInfoKindCRQE;
                crConnectionInfo.Attributes = crAttributes;
                // create a table 
                crTable.ConnectionInfo = crConnectionInfo;
                rcDoc.DatabaseController.SetDataSource(DataSetConverter.Convert(dsChungTuDetail), "ChungTuChiTiet", "ChungTuChiTiet");
            }
        }
        public static void AddDataSourceUsingSchemaFile(CrystalDecisions.ReportAppServer.ClientDoc.ISCDReportClientDocument rcDoc, string schema_file_name, string table_name, System.Data.DataSet data, Boolean Added)
        {
            PropertyBag crLogonInfo;            // logon info 
            PropertyBag crAttributes;           // logon attributes 
            CrystalDecisions.ReportAppServer.DataDefModel.ConnectionInfo crConnectionInfo;  // connection info 
            CrystalDecisions.ReportAppServer.DataDefModel.Table crTable;
            // database table 
            // create logon property 
            crLogonInfo = new PropertyBag();
            crLogonInfo["XML File Path"] = schema_file_name;
            // create logon attributes 
            crAttributes = new PropertyBag();
            crAttributes["Database DLL"] = "crdb_adoplus.dll";
            crAttributes["QE_DatabaseType"] = "ADO.NET (XML)";
            crAttributes["QE_ServerDescription"] = "NewDataSet";
            crAttributes["QE_SQLDB"] = true;
            crAttributes["QE_LogonProperties"] = crLogonInfo;
            // create connection info 
            crConnectionInfo = new CrystalDecisions.ReportAppServer.DataDefModel.ConnectionInfo
            {
                Kind = CrConnectionInfoKindEnum.crConnectionInfoKindCRQE,
                Attributes = crAttributes
            };
            // create a table 
            crTable = new CrystalDecisions.ReportAppServer.DataDefModel.Table
            {
                ConnectionInfo = crConnectionInfo,
                Name = table_name,
                Alias = table_name
            };
            // add a table 
            if (!Added)
                rcDoc.DatabaseController.AddTable(crTable, null);
            // pass dataset 
            rcDoc.DatabaseController.SetDataSource(DataSetConverter.Convert(data), table_name, table_name);
        }
    }
}
