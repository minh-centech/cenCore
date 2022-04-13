using CrystalDecisions.ReportAppServer.DataDefModel;
using CrystalDecisions.ReportAppServer.DataSetConversion;
using CrystalDecisions.Windows.Forms;
using System;
using System.Windows.Forms;
namespace coreBase.Forms
{
    public partial class frmChungTuPrintPreview : Form
    {
        public String FileReport;
        public System.Data.DataSet dsData;
        public String XMLFilePath = "";
        public String TenMayIn = @"\\maytinh\CFS";
        public Int32 SoLien = 1;
        public CrystalDecisions.CrystalReports.Engine.ReportDocument rpt;
        public frmChungTuPrintPreview()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmChungTuPrintPreview_Load(object sender, EventArgs e)
        {
            rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            rpt.Load(FileReport, CrystalDecisions.Shared.OpenReportMethod.OpenReportByTempCopy);
            SetDataSourceUsingSchemaFile(rpt.ReportClientDocument, XMLFilePath);
            crystalReportViewer.ReportSource = rpt;
        }
        private void SetDataSourceUsingSchemaFile(
            CrystalDecisions.ReportAppServer.ClientDoc.ISCDReportClientDocument rcDoc,		// report client document 
            string schema_file_name)		// xml schema file location 
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
                rcDoc.DatabaseController.SetDataSource(DataSetConverter.Convert(dsData), "ChungTuChiTiet", "ChungTuChiTiet");
            }
        }

        private void frmChungTuPrintPreview_FormClosing(object sender, FormClosingEventArgs e)
        {
            rpt.Close();
            rpt.Dispose();
        }


        //private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        //{
        //    if (e.Tool.Key == "btIn")
        //    {
        //        if (TenMayIn.Trim() == "")
        //        {
        //            PrintDialog prnDlg = new PrintDialog();
        //            if (prnDlg.ShowDialog() == DialogResult.Cancel) return;
        //                TenMayIn = prnDlg.PrinterSettings.PrinterName;
        //        }
        //        rpt.PrintOptions.PrinterName = TenMayIn;
        //        rpt.PrintToPrinter(1, false, 1, 99);
        //        this.Dispose();
        //    }
        //}

    }
}
