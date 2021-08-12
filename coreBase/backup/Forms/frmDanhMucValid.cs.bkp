using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using cenControls;
using cenCommon;
using cenBase.Classes;
namespace cenBase.Forms
{
    public partial class frmDanhMucValid : Form
    {

        public String LoaiDanhMuc, IDDanhMucLoaiDoiTuong;
        //Bảng dữ liệu
        public DataTable dtValid = null;
        //DataSource
        protected Object DoiTuong=null; 
        //Chỉ số dòng được update
        protected Int32 rowIndex = 0;
        //Cho phép lựa chọn nhiều dòng
        public Boolean MultiSelect = false;
        //Danh sách mã nếu chọn nhiều dòng
        public string DanhSachMa = "";
        //Trả về DataRow
        public List<DataRow> listDoiTuong = null;
        //Các biến dùng cho look-up
        Boolean Escape = false; //Bấm phím ESC để thoát
        public String ID = "";
        public String Ma = "";
        public String Ten = "";

        public BindingSource bsDanhMuc;

        public frmDanhMucValid()
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
            if (!MultiSelect)
            {
                txtFilterBox.Text = Ma;
            }
        }
        /// <summary>
        /// Nạp danh mục
        /// </summary>
        protected void LoadDanhMuc()
        {
            //try
            //{
            //ug = new cenControls.saNonUpdateGrid(cenCommon.GlobalVariables.connectionStr, IDDonVi, IDNgonNgu, cenCommon.GlobalVariables.IDDanhMucNguoiSuDung);
            Cursor.Current = Cursors.WaitCursor;
            Int32 donghientai = 0;
            if (ug.ActiveRow != null)
            {
                donghientai = ug.ActiveRow.Index;
            }
            if (dtValid != null)
            {
                bsDanhMuc = new BindingSource
                {
                    DataSource = dtValid
                };
                ug.AddCheckBoxColumn = MultiSelect;
                ug.AddfilterColumn = true;
                ug.DataSource = bsDanhMuc;
                //Đặt giá trị ở tất cả các cột check=false
                if (MultiSelect)
                {
                    foreach (UltraGridRow ugr in ug.Rows)
                    {
                        ugr.Cells["CheckColumn"].Value = false;
                    }
                    ug.UpdateData();
                }
                //Nếu có danh mục được load
                if (ug.Rows.VisibleRowCount >= 1)
                {
                    //Nếu valid nhiều đối tượng thì check lại những đối tượng cũ
                    if (MultiSelect)
                    {
                        ug.UpdateData();
                        if (DanhSachMa.Length > 0)
                        {
                            String[] sDanhSachMa = DanhSachMa.Split(';');
                            foreach (String iDanhSachMa in sDanhSachMa)
                            {
                                if (iDanhSachMa.Trim() != "")
                                {
                                    if (ug.FindRow("Ma", iDanhSachMa.Trim()))
                                    {
                                        ug.ActiveRow.Cells["CheckColumn"].Value = true;
                                    }
                                }
                            }
                        }
                    }
                    ug.UpdateData();
                    //Chọn dòng visible đầu tiên
                    Int32 FirstVisibleRow = 0;
                    foreach (UltraGridRow ugr in ug.Rows)
                    {
                        if (!ugr.IsFilteredOut)
                        {
                            FirstVisibleRow = ugr.Index;
                            break;
                        }
                    }
                    if (ug.Rows.Count>0)
                        ug.Rows[FirstVisibleRow].Selected = true;
                    ug.Focus();
                }
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
                case (Keys.F2): //Thêm danh mục mới
                    break;
                case (Keys.F5): //Nạp lại danh mục
                    RefreshDanhMuc();
                    break;
                case (Keys.F12): //Clear filter box
                    txtFilterBox.Text = "";
                    txtFilterBox.Focus();
                    break;
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
            ug.UpdateData();
            if (Escape)
            {
                listDoiTuong = null;
                return;
            }
            listDoiTuong = new List<DataRow>();
            if (!MultiSelect)
                if (ug.ActiveRow != null && (!ug.ActiveRow.IsFilteredOut & !Escape))
                {
                    if (ug.DisplayLayout.Bands[0].Columns.Exists("ID")) ID = ug.ActiveRow.Cells["ID"].Value.ToString();
                    listDoiTuong.Add(dtValid.Rows[ug.ActiveRow.Index]);
                    Ma = ID.ToString();
                    if (ug.DisplayLayout.Bands[0].Columns.Exists("Ma")) Ma = ug.ActiveRow.Cells["Ma"].Value.ToString();
                    if (ug.DisplayLayout.Bands[0].Columns.Exists("Ten")) Ten = ug.ActiveRow.Cells["Ten"].Value.ToString();
                }
                else
                {
                    listDoiTuong = null;
                    ID = "";
                    Ma = "";
                    Ten = "";
                }
            else
            {
                //Chọn nhiều dòng
                DanhSachMa = "";
                foreach (UltraGridRow selectedRow in ug.Rows)
                {
                    if (Convert.ToBoolean(selectedRow.Cells["CheckColumn"].Value) == true)
                    {
                        if (ug.DisplayLayout.Bands[0].Columns.Exists("ID")) ID = ug.ActiveRow.Cells["ID"].Value.ToString();
                        listDoiTuong.Add(dtValid.Rows[selectedRow.Index]);
                        Ma = ID.ToString();
                        if (ug.DisplayLayout.Bands[0].Columns.Exists("Ma")) Ma = Ma + "; " + ug.ActiveRow.Cells["Ma"].Value.ToString();
                        if (ug.DisplayLayout.Bands[0].Columns.Exists("Ten")) Ten = Ten + "; " + ug.ActiveRow.Cells["Ten"].Value.ToString();
                        DanhSachMa += Ma + "; ";
                    }
                }
                if (DanhSachMa.Length > 0)
                    DanhSachMa = DanhSachMa.Substring(0, DanhSachMa.Length - 2);
            }
        }
        private void FFormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForm();
        }
        
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Return | keyData == Keys.Escape)
            {
                Escape = (keyData == Keys.Escape);
                Close();
                return true;
            }
            else
                return base.ProcessDialogKey(keyData);
        }
        private void Ug_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            Close();
        }
        private void filterBoxValueChanged(object sender, EventArgs e)
        {
            cenCommon.cenCommon.filterGrid(ug, txtFilterBox.Text);
        }
        private void UltraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key.ToString().ToUpper())
            {
                case "BTTHEM":
                    break;
                case "BTTAILAI":
                    break;
            }
        }

        private void frmDanhMucValid_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
