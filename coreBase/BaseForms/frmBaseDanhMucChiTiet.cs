using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
namespace coreBase.BaseForms
{
    public partial class frmBaseDanhMucChiTiet : Form
    {
        public object IDDanhMucDoiTuong;
        public object IDDanhMucLoaiDoiTuong;
        public string TenDanhMucLoaiDoiTuong;

        protected DataSet dsData = null;
        protected BindingSource bsData = null, bsDataChiTiet = null;

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
        }
        protected virtual void Copy()
        {
        }
        protected new virtual void Update()
        {
        }

        protected virtual void Delete()
        {
        }


        protected virtual void InsertChiTiet()
        {
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
