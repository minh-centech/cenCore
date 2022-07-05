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
        public static void runReport(string reportProcedureName, string TenDanhMucBaoCao, Form MDIParent, string reportFileName)
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
            using (SqlConnection sqlConnection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
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
            System.Data.DataSet dsData = connectionDAO.dsList(sqlParameters, reportProcedureName);
            if (dsData != null)
            {
                dsData.Tables[0].TableName = coreCommon.GlobalVariables.tblReportDataGridName;
                if (dsData.Tables.Count >= 2)
                    dsData.Tables[1].TableName = coreCommon.GlobalVariables.tblReportHeaderName;
                if (dsData.Tables.Count == 3)
                    dsData.Tables[2].TableName = coreCommon.GlobalVariables.tblReportDataName;
            }
            System.Windows.Forms.Cursor.Current = Cursors.Default;

            frmReportViewer frmReportViewer = new frmReportViewer();
            frmReportViewer.Text = TenDanhMucBaoCao;
            frmReportViewer.dtData = dsData.Tables[coreCommon.GlobalVariables.tblReportDataGridName];
            frmReportViewer.dsData = dsData;
            frmReportViewer.dtParameters = dtParameters;
            frmReportViewer.reportProcedureName = reportProcedureName;
            frmReportViewer.ReportFileName = reportFileName;
            frmReportViewer.ChuoiThamSoHienThiGrid = ChuoiThamSoHienThi;
            frmReportViewer.ChuoiThamSoHienThi = ChuoiThamSoHienThiCrystalReport;
            frmReportViewer.MDIParent = MDIParent;
            frmReportViewer.Show();
        }
    }
}
