using coreControls;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using System;
using System.Data;
using System.Windows.Forms;
namespace coreBase.BaseForms
{
    public partial class frmBaseChungTuMasterDetail2 : Form
    {
        public short UpdateMode = coreCommon.ThaoTacDuLieu.Xem; //Chế độ cập nhật: 0: Chỉ đọc, 1: Thêm mới, 2: Sửa chứng từ
        //Loại chứng từ
        public Object IDDanhMucChungTu = null;
        public Object MaDanhMucChungTu = null;
        public Object LoaiManHinh = null;

        public DataSet dsChungTuLienQuan; //Table 0 chứa chứng từ in, Table 1 chứa chứng từ liên quan

        protected String ReportFileName = "", TenMayIn = "", spName = "";
        protected Int16 SoLien = 1;

        //
        public Boolean CallFromMain = true; //Gọi từ mainForm
        public Object GiaTriChuyenChungTuSau = null; //Giá trị truyển tới chứng từ tiếp theo
        //DataSet
        public DataSet dsChungTu = new DataSet(); //Chứa chứng từ
        //BindingSource
        public BindingSource bsChungTu = null; //Header chứng từ
        public BindingSource bsChungTuChiTiet = null; //Chi tiết chứng từ
        public BindingSource bsChungTuChiTiet2 = null; //Chi tiết chứng từ 2
        //Chứng từ
        public object IDChungTu = null;
        //
        protected bool GridValidation = true, Saved = false;
        //
        public static DataTable dtUpdate;
        public Action InsertToList, UpdateToList;
        public object TuNgay, DenNgay;
        public frmBaseChungTuMasterDetail2()
        {
            InitializeComponent();
            ugChiTiet.ConfirmDelete = false;
            //toolBar.Toolbars[0].Tools["btThem"].SharedProps.Visible = false;
            //toolBar.Toolbars[0].Tools["btXoa"].SharedProps.Visible = false;
            //toolBar.Toolbars[0].Tools["btThemDong"].SharedProps.Visible = false;
            //toolBar.Toolbars[0].Tools["btXoaDong"].SharedProps.Visible = false;
        }
        #region Methods
        //Thêm chứng từ
        protected virtual void themChungTu()
        {
        }
        //Thêm chứng từ chi tiết
        protected virtual void themChungTuChiTiet()
        {
        }
        //Xóa chứng từ chi tiết
        protected virtual void xoaChungTuChiTiet()
        {
        }
        //Sửa chứng từ
        protected virtual void suaChungTu()
        {
        }
        //Xóa chứng từ
        protected virtual void xoaChungTu()
        {

        }
        //Lưu chứng từ
        protected virtual void luuChungTu(bool Exit)
        {
        }
        //In chứng từ
        protected virtual void inChungTu()
        {
        }
        //Ngừng cập nhật dữ liệu
        protected void ngungCapNhat(bool Exit)
        {
            if (UpdateMode != coreCommon.ThaoTacDuLieu.Xem)
            {
                DialogResult dlr = coreCommon.coreCommon.QuestionMessage("Bạn chắc chắn muốn ngừng cập nhật dữ liệu?", 0);
                if (dlr == DialogResult.Yes)
                {
                    bsChungTuChiTiet.CancelEdit();
                    bsChungTu.CancelEdit();
                    UpdateMode = coreCommon.ThaoTacDuLieu.Xem;
                    Saved = false;
                    IDChungTu = null;
                    enableControl();
                    if (Exit) Close();
                }
            }
        }
        //Cho phép tương tác với controls
        protected virtual void enableControl()
        {
            Boolean ReadOnly = (UpdateMode == coreCommon.ThaoTacDuLieu.Xem);
            //Toolbar
            toolBar.Toolbars[0].Tools["btThem"].SharedProps.Enabled = ReadOnly;
            toolBar.Toolbars[0].Tools["btSua"].SharedProps.Enabled = ReadOnly;
            toolBar.Toolbars[0].Tools["btXoa"].SharedProps.Enabled = ReadOnly;
            toolBar.Toolbars[0].Tools["btImport"].SharedProps.Enabled = !ReadOnly;
            toolBar.Toolbars[0].Tools["btThemDong"].SharedProps.Enabled = !ReadOnly;
            toolBar.Toolbars[0].Tools["btXoaDong"].SharedProps.Enabled = !ReadOnly;
            toolBar.Toolbars[0].Tools["btLuu"].SharedProps.Enabled = !ReadOnly;
            toolBar.Toolbars[0].Tools["btNgung"].SharedProps.Enabled = !ReadOnly;
            toolBar.Toolbars[0].Tools["btQuyTrinh"].SharedProps.Enabled = ReadOnly;
            toolBar.Toolbars[0].Tools["btIn"].SharedProps.Enabled = true;
            //Header
            foreach (Control ctl in groupHeader.Controls)
            {

                if (ctl is saTextBox && (ctl.Name.ToUpper() != "TXTSO" && ctl.Name.ToUpper() != "TXTKYHIEU" && !ctl.Name.ToUpper().StartsWith("TXTCUS")))
                {
                    saTextBox txtBox = (saTextBox)ctl;
                    txtBox.ReadOnly = ReadOnly;
                }
                if (ctl is saDateTimeBox && (ctl.Name.ToUpper() != "TXTNGAYLAP" && !ctl.Name.ToUpper().StartsWith("TXTCUS")))
                {
                    saDateTimeBox txtBox = (saDateTimeBox)ctl;
                    txtBox.ReadOnly = ReadOnly;
                }
                if (ctl is saNumericBox)
                {
                    saNumericBox txtBox = (saNumericBox)ctl;
                    txtBox.ReadOnly = ReadOnly;
                }
                if (ctl is saComboDanhMuc)
                {
                    saComboDanhMuc txtBox = (saComboDanhMuc)ctl;
                    txtBox.ReadOnly = ReadOnly;
                }
                if (ctl is saCheckBox)
                {
                    saCheckBox txtBox = (saCheckBox)ctl;
                    txtBox.Enabled = !ReadOnly;
                }

            }
            //Grid
            ugChiTiet.SetEditableState(ReadOnly);
        }
        //Nhập dữ liệu từ Excel
        protected virtual void import()
        {
        }
        //Xuất chi tiết chứng từ ra excel
        protected void export()
        {
            coreCommon.coreCommon.ExportGrid2Excel(ugChiTiet);
        }
        //Mở chứng từ ở bước tiếp theo của quy trình
        protected virtual void runNext(String IDDanhMucChungTu, String MaDanhMucChungTu, String LoaiManHinh, String FormCaption)
        {
        }
        //Mở form chi tiết chứng từ 2
        protected virtual void openChiTietChungTu2()
        {
        }
        protected virtual void refresh()
        {
        }
        #endregion Methods
        #region FormEvents
        private void frmBaseChungTu_Load(object sender, EventArgs e)
        {
            if (dsChungTuLienQuan != null)
            {
                //Add các button là mẫu in chứng từ
                foreach (DataRow drChungTu in dsChungTuLienQuan.Tables[0].Rows)
                {
                    ButtonTool btChungTuIn = new ButtonTool("_rpt_" + drChungTu["FileMauIn"].ToString() + "ID:" + drChungTu["ID"].ToString() + "PRINTER:" + drChungTu["TenMayIn"].ToString() + "SOLIEN:" + drChungTu["SoLien"].ToString() + "SPNAME:" + drChungTu["spName"].ToString());
                    btChungTuIn.SharedProps.Caption = drChungTu["TenMauIn"].ToString();
                    toolBar.Tools.Add(btChungTuIn);
                    ((PopupMenuTool)toolBar.Toolbars[0].Tools["btIn"]).Tools.AddTool(btChungTuIn.Key);
                    btChungTuIn.SharedProps.Visible = true;
                }
                //Add các button là chứng từ liên quan
                foreach (DataRow drChungTu in dsChungTuLienQuan.Tables[1].Rows)
                {
                    ButtonTool btChungTuLienQuan = new ButtonTool("_dct_" + drChungTu["IDDanhMucChungTuLienQuan"].ToString() + "ID:" + drChungTu["ID"].ToString() + "MA:" + drChungTu["MaDanhMucChungTuLienQuan"].ToString() + "LOAIMANHINH:" + drChungTu["LoaiManHinh"].ToString());
                    btChungTuLienQuan.SharedProps.Caption = drChungTu["TenDanhMucChungTuLienQuan"].ToString();
                    toolBar.Tools.Add(btChungTuLienQuan);
                    ((PopupMenuTool)toolBar.Toolbars[0].Tools["btQuyTrinh"]).Tools.AddTool(btChungTuLienQuan.Key);
                    btChungTuLienQuan.SharedProps.Visible = true;
                }
            }
            //
            //LoadValidDataSet();
            //LoadData();
            ////
            //setDataBindings();
            //
            ugChiTiet.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(ugChiTiet_AfterCellUpdate);
            ugChiTiet.AfterRowInsert += new Infragistics.Win.UltraWinGrid.RowEventHandler(ugChiTiet_AfterRowInsert);
            //

            this.WindowState = FormWindowState.Maximized;
        }
        private void frmBaseChungTu_KeyDown(object sender, KeyEventArgs e)
        {
            //Thêm chi tiết mức 2
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.D2:
                    case Keys.NumPad2:
                        if (bsChungTuChiTiet.Current == null) return;
                        if (UpdateMode == coreCommon.ThaoTacDuLieu.Xem) return;
                        openChiTietChungTu2();
                        break;
                }
            }
            else
            {
                if (e.KeyCode == Keys.Escape)
                    Close();
            }
        }
        private void frmBaseChungTu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UpdateMode != coreCommon.ThaoTacDuLieu.Xem)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn phải kết thúc cập nhật chứng từ trước khi đóng cửa sổ!");
                e.Cancel = true;
            }
            else
            {
                if (!Saved) IDChungTu = null;
                UpdateMode = coreCommon.ThaoTacDuLieu.Xem;
            }
        }
        #endregion FormEvents
        private void toolBar_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            String buttonKey = e.Tool.Key.ToUpper();
            switch (buttonKey)
            {
                case "BTTHEM":
                    themChungTu();
                    break;
                case "BTSUA":
                    //suaChungTu();
                    break;
                case "BTLUU":
                    luuChungTu(true);
                    break;
                case "BTXOA":
                    xoaChungTu();
                    break;
                case "BTNGUNG":
                    ngungCapNhat(true);
                    break;
                case "BTXOADONG":
                    xoaChungTuChiTiet();
                    break;
                case "BTTHEMDONG":
                    themChungTuChiTiet();
                    break;
                case "BTREFRESH":
                    refresh();
                    break;
                case "BTIMPORT":
                    import();
                    break;
                case "BTEXPORT":
                    export();
                    break;
                default:
                    String LoaiChucNang = e.Tool.Key.Substring(0, 5).ToUpper(),
                            TenChucNang = e.Tool.Key.Substring(5).ToUpper();
                    if (LoaiChucNang != "_DCT_" && LoaiChucNang != "_RPT_") return;
                    if (LoaiChucNang == "_DCT_")
                    {
                        String IDDanhMucChungTuLienQuan = e.Tool.Key.Substring(5, TenChucNang.IndexOf("ID:"));
                        String MaDanhMucChungTuLienQuan = TenChucNang.Substring(TenChucNang.IndexOf("MA:") + "MA:".Length, TenChucNang.IndexOf("LOAIMANHINH:") - TenChucNang.IndexOf("MA:") - "MA:".Length);
                        String LoaiManHinhLienQuan = TenChucNang.Substring(TenChucNang.IndexOf("LOAIMANHINH:") + "LOAIMANHINH:".Length, TenChucNang.Length - TenChucNang.IndexOf("LOAIMANHINH:") - "LOAIMANHINH:".Length);
                        runNext(IDDanhMucChungTuLienQuan, MaDanhMucChungTuLienQuan, LoaiManHinhLienQuan, e.Tool.SharedProps.Caption);
                    }
                    if (LoaiChucNang == "_RPT_")
                    {
                        //MessageBox.Show(e.Tool.Key);
                        ReportFileName = e.Tool.Key.Substring(5, TenChucNang.IndexOf("ID:"));
                        //TenMayIn = e.Tool.Key.Substring(TenChucNang.IndexOf("PRINTER:") + 8, TenChucNang.IndexOf("SOLIEN:"));
                        SoLien = Convert.ToInt16(e.Tool.Key.Substring(TenChucNang.IndexOf("SOLIEN:") + 12, TenChucNang.IndexOf("SPNAME:") - TenChucNang.IndexOf("SOLIEN:") - 7));
                        spName = e.Tool.Key.Substring(TenChucNang.IndexOf("SPNAME:") + 12, e.Tool.Key.Length - TenChucNang.IndexOf("SPNAME:") - 12);
                        //"_rpt_" + drChungTu["FileMauIn"].ToString() + "ID:" + drChungTu["ID"].ToString() + "PRINTER:" + drChungTu["TenMayIn"].ToString() + "SOLIEN:" + drChungTu["SoLien"].ToString() + "SPNAME:" + drChungTu["spName"].ToString()
                        inChungTu();
                    }
                    break;
            }
        }
        #region gridDetail
        private void ugChiTiet_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (UpdateMode == coreCommon.ThaoTacDuLieu.Xem || !GridValidation) return;
            if (e.Cell == null) return;
            gridColumnDataProcess((saUpdateGrid)sender, e.Cell, out GridValidation, true);
        }
        private void ugChiTiet_AfterRowInsert(object sender, RowEventArgs e)
        {
            e.Row.Cells["ID"].Value = coreCommon.coreCommon.MaxTempID(dsChungTu.Tables[1]);
        }
        private void ugChiTiet_BeforeRowInsert(object sender, BeforeRowInsertEventArgs e)
        {
            ugChiTiet.UpdateData();
        }
        private void ugChiTiet_Enter(object sender, EventArgs e)
        {
            ugChiTiet2.UpdateData();
        }
        #endregion gridDetail
        //Valid các ô nhập dữ liệu trên lưới
        protected virtual void gridColumnDataProcess(UltraGrid ug, UltraGridCell uCell, out Boolean GridValidation, Boolean ShowLookUp)
        {
            GridValidation = true;
        }
    }
}
