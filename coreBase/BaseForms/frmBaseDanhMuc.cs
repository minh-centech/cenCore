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

        public DataTable dtData = null;
        public BindingSource bsData = null;
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
            try
            {
                Cursor.Current = Cursors.WaitCursor;
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
            catch (Exception ex)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void UltraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key.ToString().ToUpper())
            {
                case "BTXOA":
                    Delete();
                    break;
                case "BTTHEM":
                    Cursor.Current = Cursors.WaitCursor;
                    Insert();
                    break;
                case "BTCOPY":
                    Cursor.Current = Cursors.WaitCursor;
                    Copy();
                    break;
                case "BTSUA":
                    Cursor.Current = Cursors.WaitCursor;
                    Update();
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
            Update();
        }
        protected virtual void List()
        {
        }
        protected virtual void Insert()
        {
        }
        protected virtual void Copy()
        {
            bContinue = (ug.ActiveRow != null && ug.ActiveRow.IsDataRow);
        }
        protected virtual void Update()
        {
            bContinue = (tableName.ToUpper() != "SYSNHATKYDULIEU" && ug.ActiveRow != null && ug.ActiveRow.IsDataRow);
        }
        protected virtual void Delete()
        {
            if (!coreCommon.coreCommon.IsNull(deleteAction))
                deleteAction();    
        }
    }
}
