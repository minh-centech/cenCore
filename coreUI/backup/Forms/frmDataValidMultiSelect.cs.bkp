using coreBUS;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
namespace coreUI.Forms
{
    public partial class frmDataValidMultiSelect : Form
    {
        public Func<DataTable> validProcedure = null;
        public Func<DataRow> insertProcedure = null;

        public string validColumn = "";
        
        public bool Them = true, Sua = true, Xoa = false, Escape = false;
        
        public List<DataRow> dataRows;

        DataTable dtValid;

        public object validValue;

        BindingSource bsData;
        
        public frmDataValidMultiSelect()
        {
            InitializeComponent();
        }
        private void FormClose(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormLoad(object sender, EventArgs e)
        {
            LoadDanhMuc();
            txtFilterBox.Value = validValue;
            UltraToolbarsManager1.Tools["btThem"].SharedProps.Visible = Them;
            UltraToolbarsManager1.Tools["btSua"].SharedProps.Visible = Sua;
            UltraToolbarsManager1.Tools["btXoa"].SharedProps.Visible = Xoa;
            dataRows = new List<DataRow>();
        }
        /// <summary>
        /// Nạp danh mục
        /// </summary>
        private void LoadDanhMuc()
        {
            //
            dtValid = validProcedure();
            //
            ug.FixedColumnsList = "[" + validColumn  +  "]";
            bsData = new BindingSource() { DataSource = dtValid };
            ug.AddCheckBoxColumn = true;
            ug.DataSource = bsData;
            ug.DisplayLayout.Override.FilterUIType = FilterUIType.Default; //Biểu tượng lọc đặt trên tiêu đề cột
            if (txtFilterBox.Value != null)
            {
                ug.DisplayLayout.Bands[0].Columns[validColumn].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                ug.DisplayLayout.Bands[0].ColumnFilters[validColumn].FilterConditions.Clear();
                ug.DisplayLayout.Bands[0].ColumnFilters[validColumn].FilterConditions.Add(FilterComparisionOperator.Contains, txtFilterBox.Text);
            }
            foreach(UltraGridRow row in ug.Rows)
            {
                row.Cells["CheckColumn"].Value = false;
            }
            if (ug.Rows.GetFilteredInNonGroupByRows().Count() > 0)
            {
                ug.ActiveRow = ug.Rows.GetFilteredInNonGroupByRows()[0];
                ug.PerformAction(UltraGridAction.ActivateCell);
            }
            Cursor.Current = Cursors.Default;
        }
        /// <summary>
        /// Refresh danh mục
        /// </summary>
        protected void RefreshDanhMuc()
        {
            LoadDanhMuc();
        }
        /// <summary>
        /// Bắt phím chức năng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.Escape):
                    Close();
                    break;
            }
        }
        /// <summary>
        /// Đóng form
        /// </summary>
        protected void CloseForm()
        {
            foreach(UltraGridRow row in ug.Rows)
            {
                if (row.IsDataRow && !row.IsFilteredOut && coreCommon.coreCommon.stringParseBoolean(row.Cells["CheckColumn"].Value))
                {
                    foreach(DataRow dataRow in dtValid.Rows)
                    {
                        if (dataRow["ID"].ToString() == row.Cells["ID"].Value.ToString())
                        {
                            dataRows.Add(dataRow);
                        }    
                    }    
                }    
            }
            if (dataRows.Count == 0 && bsData.Current != null) dataRows.Add(((DataRowView)bsData.Current).Row);
            DialogResult = DialogResult.OK;
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Escape = true;
                DialogResult = DialogResult.OK;
                dataRows = null;
                return true;
            }
            else if (keyData == Keys.Return)
            {
                CloseForm();
                return true;
            }
            else
                return base.ProcessDialogKey(keyData);
        }
        private void Ug_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            CloseForm();
        }

        private void filterBoxValueChanged(object sender, EventArgs e)
        {
            ug.DisplayLayout.Bands[0].Columns[validColumn].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            ug.DisplayLayout.Bands[0].ColumnFilters[validColumn].FilterConditions.Clear();
            ug.DisplayLayout.Bands[0].ColumnFilters[validColumn].FilterConditions.Add(FilterComparisionOperator.Contains, txtFilterBox.Text);
            if (ug.Rows.GetFilteredInNonGroupByRows().Count() > 0)
            {
                ug.Rows.GetFilteredInNonGroupByRows()[0].Selected = true;
                ug.Rows.GetFilteredInNonGroupByRows()[0].Activated = true;
            }
        }
        private void UltraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key.ToString().ToUpper())
            {
                case "BTTHEM":
                    Insert();
                    break;
                case "BTSUA":
                    Update();
                    break;
                case "BTTAILAI":
                    LoadDanhMuc();
                    break;
            }
        }
        private void Insert()
        {
            //if (insertProcedure != null)
            //{
            //    dataRow = insertProcedure();
            //    if (dataRow != null) dtValid.ImportRow(dataRow); else LoadDanhMuc();
            //}
        }
        private void Update()
        {
            //Nếu có trong DTO thì gọi form tương ứng, nếu ko thì gọi customs
        }
    }
}
