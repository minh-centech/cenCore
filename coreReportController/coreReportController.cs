using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CrystalDecisions.ReportAppServer.ReportDefModel;
using CrystalDecisions.ReportAppServer.DataDefModel;
using CrystalDecisions.ReportAppServer.DataSetConversion;

namespace coreReportController
{
    public class coreReportController
    {
        public static void runReport(string reportProcedureName, string TenDanhMucBaoCao, Form MDIParent)
        {
            //Lấy parameter
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            DataTable dtParameters = new DataTable();
            dtParameters.Columns.Add(new DataColumn("TenThamSo", typeof(string))); //Tên tham số trong procedure
            dtParameters.Columns.Add(new DataColumn("DienGiaiThamSo", typeof(string))); //Tên tham số tiếng Việt
            dtParameters.Columns.Add(new DataColumn("GiaTri", typeof(string))); //Giá trị tham số do người dùng nhập
            dtParameters.Columns.Add(new DataColumn("GiaTriThamSo", typeof(string))); //Giá trị tham số truyền vào procedure
            dtParameters.Columns.Add(new DataColumn("KieuDuLieu", typeof(string))); //Kiểu dữ liệu
            dtParameters.Columns.Add(new DataColumn("GhiChu", typeof(string)));
            SqlParameterCollection sqlParameterCollection;
            using(SqlConnection sqlConnection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandText = reportProcedureName,
                    CommandType = CommandType.StoredProcedure
                };
                SqlCommandBuilder.DeriveParameters(sqlCommand);
                sqlParameterCollection = sqlCommand.Parameters;
                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {
                    if (sqlParameter.ParameterName != "@RETURN_VALUE" && sqlParameter.ParameterName != "@IDDanhMucDonVi")
                    {
                        DataRow drParameter = dtParameters.NewRow();
                        drParameter["TenThamSo"] = sqlParameter.ParameterName;
                        drParameter["DienGiaiThamSo"] = coreCommon.coreCommon.TraTuDien(sqlParameter.ParameterName.Substring(1));
                        drParameter["KieuDuLieu"] = sqlParameter.SqlDbType.ToString().ToUpper();
                        if (sqlParameter.SqlDbType.ToString().ToUpper() == "DATE")
                        {
                            if (drParameter["TenThamSo"].ToString().StartsWith("@TuNgay"))
                            {
                                DateTime TuNgay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                                drParameter["GiaTri"] = TuNgay.Day.ToString("0#") + "/" + TuNgay.Month.ToString("0#") + "/" + TuNgay.Year;
                            }
                            else if (drParameter["TenThamSo"].ToString().StartsWith("@DenNgay"))
                            {
                                DateTime DenNgay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);
                                drParameter["GiaTri"] = DenNgay.Day.ToString("0#") + "/" + DenNgay.Month.ToString("0#") + "/" + DenNgay.Year;
                            }
                            else
                            {
                                DateTime Ngay = DateTime.Now;
                                drParameter["GiaTri"] = Ngay.Day.ToString("0#") + "/" + Ngay.Month.ToString("0#") + "/" + Ngay.Year;
                            }
                            drParameter["GiaTriThamSo"] = drParameter["GiaTri"];
                            drParameter["GhiChu"] = "Nhập theo định dạng DD/MM/YYYY";
                        }
                        dtParameters.Rows.Add(drParameter);
                    }
                }
            }
            Boolean OK = true;
            DataTable dtData;
            string ChuoiThamSoHienThi = "", ChuoiThamSoHienThiCrystalReport = "";

            System.Windows.Forms.Cursor.Current = Cursors.Default;

            if (dtParameters.Rows.Count > 0)
            {
                frmReportParameters frmReportParameters = new frmReportParameters()
                {
                    Text = TenDanhMucBaoCao,
                    dtParameters = dtParameters
                };
                frmReportParameters.ShowDialog();
                OK = frmReportParameters.OK;
                if (OK)
                {
                    dtParameters = frmReportParameters.dtParameters;
                    ChuoiThamSoHienThi = frmReportParameters.ChuoiThamSoHienThiGrid;
                    ChuoiThamSoHienThiCrystalReport = frmReportParameters.ChuoiThamSoHienThiCrystalReport;
                }
                frmReportParameters.Dispose();
            }
            if (!OK) return;

            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            SqlParameter[] sqlParameters = new SqlParameter[dtParameters.Rows.Count + 1];
            sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", coreCommon.GlobalVariables.IDDonVi);
            if (dtParameters.Rows.Count > 0)
            {
                for (int i = 0; i <= dtParameters.Rows.Count - 1; i++)
                {
                    sqlParameters[i + 1] = new SqlParameter(dtParameters.Rows[i]["TenThamSo"].ToString(), dtParameters.Rows[i]["GiaTriThamSo"]);
                }
            }
            coreDAO.ConnectionDAO connectionDAO = new coreDAO.ConnectionDAO();
            dtData = connectionDAO.tableList(sqlParameters, reportProcedureName, reportProcedureName);
            System.Windows.Forms.Cursor.Current = Cursors.Default;

            frmReportViewer frmReportViewer = new frmReportViewer();
            frmReportViewer.Text = TenDanhMucBaoCao;
            frmReportViewer.dtData = dtData;
            frmReportViewer.dtParameters = dtParameters;
            frmReportViewer.reportProcedureName = reportProcedureName;
            frmReportViewer.ChuoiThamSoHienThiGrid = ChuoiThamSoHienThi;
            frmReportViewer.MDIParent = MDIParent;
            frmReportViewer.Show();
        }



        public static Boolean PrintProcess_Parameter(String FileReport, System.Data.DataSet dsData, string ChuoiThamSoHienThi, out String GeneratedReportFile, out String XMLDataFile)
        {
            Boolean OK = false;
            //Tên file report được sinh ra
            XMLDataFile = "";

            GeneratedReportFile = coreCommon.GlobalVariables.TempDir + "\\" + Guid.NewGuid().ToString() + ".rpt";//cenCommon.GlobalVariables.TempDir + Guid.NewGuid().ToString() + ".rpt";
            String FormattedValue = ""; //Chuỗi giá trị sau khi định dạng
            String NumberFormatString = "";

            //Bắt đầu xử lý in chứng từ
            if (dsData != null && dsData.Tables[coreCommon.GlobalVariables.tblReportHeaderName].Rows.Count > 0)
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
                DataTable dtChungTuDetail = dsData.Tables[coreCommon.GlobalVariables.tblReportDataName];
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
                    System.Data.DataSet dsChungTuDetail = new System.Data.DataSet();
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
