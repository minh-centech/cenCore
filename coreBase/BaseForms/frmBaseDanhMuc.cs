using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
namespace coreBase.BaseForms
{
    public partial class frmBaseDanhMuc : Form
    {
        public object IDDanhMucLoaiDoiTuong;
        public string TenDanhMucLoaiDoiTuong;

        public static DataTable dtData = null;
        public BindingSource bsDanhMuc = null;
        protected Boolean bContinue = true;

        protected Action deleteAction = null;

        protected String tableName = "";
        protected bool Loaded = false;
        public frmBaseDanhMuc()
        {
            InitializeComponent();
        }

        private void frmQuanLy_Load(object sender, EventArgs e)
        {
            List();

            if (tableName == "SYSNHATKYDULIEU")
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ugc in ug.DisplayLayout.Bands[0].Columns)
                {
                    ugc.CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
                }
                ug.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFree;
            }
        }

        private void UltraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key.ToString().ToUpper())
            {
                case "BTXOA":
                    DeleteDanhMuc();
                    break;
                case "BTTHEM":
                    InsertDanhMuc();
                    break;
                case "BTCOPY":
                    CopyDanhMuc();
                    break;
                case "BTSUA":
                    UpdateDanhMuc();
                    break;
                case "BTTAILAI":
                    List();
                    break;
                case "BTEXCEL":
                    coreCommon.coreCommon.ExportGrid2Excel(ug);
                    break;
            }
        }
        private void ug_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            UpdateDanhMuc();
        }
        protected virtual void List()
        {
        }
        protected virtual void InsertDanhMuc()
        {
        }
        protected virtual void CopyDanhMuc()
        {
            bContinue = (ug.ActiveRow != null && ug.ActiveRow.IsDataRow);
        }
        protected virtual void UpdateDanhMuc()
        {
            bContinue = (tableName.ToUpper() != "SYSNHATKYDULIEU" && ug.ActiveRow != null && ug.ActiveRow.IsDataRow);
        }
        protected virtual void DeleteDanhMuc()
        {
            if (!coreCommon.coreCommon.IsNull(deleteAction))
                deleteAction();    
        }
    }
}
