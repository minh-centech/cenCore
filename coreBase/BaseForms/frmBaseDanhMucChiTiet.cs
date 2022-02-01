using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
namespace coreBase.BaseForms
{
    public partial class frmBaseDanhMucChiTiet : Form
    {
        public object IDDanhMucLoaiDoiTuong;
        public string TenDanhMucLoaiDoiTuong;

        protected DataSet dsData = null;
        protected BindingSource bsData = null, bsDataChiTiet = null;

        protected Action deleteAction;

        protected String tableNameDanhMucChiTiet = String.Empty;
        protected Boolean bContinue = true;
        public frmBaseDanhMucChiTiet()
        {
            InitializeComponent();
        }
        private void frmQuanLy_Load(object sender, EventArgs e)
        {
            UltraToolbarsManager1.Tools["btTimKiem"].SharedProps.Visible = false;
            List();
        }

        private void UltraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key.ToString().ToUpper())
            {
                case "BTXOA":
                    Delete();
                    break;
                case "BTTHEM":
                    Insert();
                    break;
                case "BTCOPY":
                    Copy();
                    break;
                case "BTSUA":
                    Update();
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
        protected virtual void Insert()
        {
            bContinue = (bsData != null);
        }
        protected virtual void Copy()
        {
            bContinue = (ug.ActiveRow != null && ug.ActiveRow.IsDataRow);
        }
        protected virtual void Update()
        {
            bContinue = (ug.ActiveRow != null && ug.ActiveRow.IsDataRow);
        }
        protected bool CanDelete(UltraGrid ugCanDelete)
        {
            return ((ugCanDelete.ActiveRow != null && ugCanDelete.ActiveRow.IsDataRow && coreCommon.coreCommon.QuestionMessage("Bạn có chắc chắn muốn xóa mục dữ liệu này?", 0) == DialogResult.Yes));
        }

        protected virtual void Delete()
        {
            if (!coreCommon.coreCommon.IsNull(deleteAction))
                deleteAction();
        }


        protected virtual void InsertChiTiet()
        {
            bContinue = (ug.ActiveRow != null && ug.ActiveRow.IsDataRow);
        }
        protected virtual void UpdateChiTiet()
        {
        }
        protected virtual void DeleteChiTiet()
        {
            Delete();
        }
        private void frmBaseDanhMuc_KeyDown(object sender, KeyEventArgs e)
        {
            //Chi tiết danh mục
            if (e.Modifiers == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.Insert:
                        InsertChiTiet();
                        break;
                    case Keys.Enter:
                        UpdateChiTiet();
                        break;
                    case Keys.Delete:
                        DeleteChiTiet();
                        break;
                }
            }
        }

        private void ug_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            Update();
        }

        private void txtChiTietfilterBox_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            switch (e.Button.Key.ToUpper())
            {
                case "BTTHEMCHITIET":
                    InsertChiTiet();
                    break;
                case "BTSUACHITIET":
                    UpdateChiTiet();
                    break;
                case "BTXOACHITIET":
                    DeleteChiTiet();
                    break;
            }
        }

        private void ugChiTiet_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            UpdateChiTiet();
        }
        
    }
}
