using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
namespace coreBase.BaseForms
{
    public partial class frmBaseChungTuMasterDetailList : Form
    {
        public DataSet dsData = null;
        public BindingSource bsDanhMuc = null;
        protected BindingSource bsDanhMucChiTiet = null;
        protected UltraGrid ugDanhMucChiTiet = null;
        protected String tableNameDanhMucChiTiet = String.Empty;
        protected Boolean bContinue = true;
        public frmBaseChungTuMasterDetailList()
        {
            InitializeComponent();
        }
        private void frmQuanLy_Load(object sender, EventArgs e)
        {
            UltraToolbarsManager1.Tools["btTimKiem"].SharedProps.Visible = false;
            //txtTuNgay.MaskInput = coreCommon.GlobalVariables.MaskInputDate;
            //txtDenNgay.MaskInput = coreCommon.GlobalVariables.MaskInputDate;
            //txtTuNgay.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            //txtDenNgay.DateTime = txtTuNgay.DateTime.AddMonths(1).AddDays(-1);
            List();
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
                case "BTIN":
                    In();
                    break;
                case "BTEXCEL":
                    coreCommon.coreCommon.ExportGrid2Excel(ug);
                    break;
            }
        }

        protected virtual void List()
        {
        }
        protected virtual void In()
        {
        }
        protected virtual void InsertDanhMuc()
        {
            bContinue = (bsDanhMuc != null);
        }
        protected virtual void CopyDanhMuc()
        {
            bContinue = (bsDanhMuc != null && bsDanhMuc.Current != null && ug.ActiveRow != null);
        }
        protected virtual void UpdateDanhMuc()
        {
            bContinue = (bsDanhMuc != null && bsDanhMuc.Current != null && ug.ActiveRow != null && ug.ActiveRow.IsFilterRow == false);
        }
        protected virtual void ViewDanhMuc()
        {
            bContinue = (bsDanhMuc != null && bsDanhMuc.Current != null && ug.ActiveRow != null && ug.ActiveRow.IsFilterRow == false);
        }
        protected virtual void DeleteDanhMuc()
        {
            bContinue = (bsDanhMuc != null && bsDanhMuc.Current != null && ug.ActiveRow != null && coreCommon.coreCommon.QuestionMessage("Bạn có chắc chắn muốn xóa mục dữ liệu này?", 0) != DialogResult.No);
        }
        protected virtual void InsertDanhMucChiTiet()
        {
            bContinue = (bsDanhMuc != null && bsDanhMuc.Current != null && ug.ActiveRow != null);
        }
        protected virtual void UpdateDanhMucChiTiet()
        {
            bContinue = (bsDanhMucChiTiet != null && bsDanhMucChiTiet.Current != null && ugDanhMucChiTiet != null && ugDanhMucChiTiet.ActiveRow != null);
        }
        protected virtual void DeleteDanhMucChiTiet()
        {
            bContinue = (bsDanhMucChiTiet != null && bsDanhMucChiTiet.Current != null && ugDanhMucChiTiet != null && ugDanhMucChiTiet.ActiveRow != null && coreCommon.coreCommon.QuestionMessage("Bạn có chắc chắn muốn xóa mục dữ liệu này?", 0) != DialogResult.No);
        }
        private void frmBaseDanhMuc_KeyDown(object sender, KeyEventArgs e)
        {
            //Chi tiết danh mục
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.Insert:
                        InsertDanhMucChiTiet();
                        break;
                    case Keys.Enter:
                        UpdateDanhMucChiTiet();
                        break;
                    case Keys.Delete:
                        DeleteDanhMucChiTiet();
                        break;
                }
            }
        }

        private void ug_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            ViewDanhMuc();
        }

        private void txtChiTietfilterBox_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            switch (e.Button.Key.ToUpper())
            {
                case "BTTHEMCHITIET":
                    InsertDanhMucChiTiet();
                    break;
                case "BTSUACHITIET":
                    UpdateDanhMucChiTiet();
                    break;
                case "BTXOACHITIET":
                    DeleteDanhMucChiTiet();
                    break;
            }
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            List();
        }
    }
}
