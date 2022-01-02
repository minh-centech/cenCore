using System;
using System.Data;
using System.Windows.Forms;
namespace coreBase.BaseForms
{
    public partial class frmBaseChungTuSingleList : Form
    {
        public object IDDanhMucChungTu = null, LoaiManHinh = null;
        public DataTable dtData;
        public BindingSource bsData = null;
        protected Boolean bContinue = true;
        protected String tableName = "";
        //
        protected string ReportFileName, spName;
        protected Int16 SoLien;
        //
        public frmBaseChungTuSingleList()
        {
            InitializeComponent();
            txtTuNgay.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            txtDenNgay.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);
        }

        private void frmQuanLy_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                List();
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
                case "BTEXCEL":
                    coreCommon.coreCommon.ExportGrid2Excel(ug);
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
                        //runNext(IDDanhMucChungTuLienQuan, MaDanhMucChungTuLienQuan, LoaiManHinhLienQuan, e.Tool.SharedProps.Caption);
                    }
                    if (LoaiChucNang == "_RPT_")
                    {
                        //MessageBox.Show(e.Tool.Key);
                        ReportFileName = e.Tool.Key.Substring(5, TenChucNang.IndexOf("ID:"));
                        //TenMayIn = e.Tool.Key.Substring(TenChucNang.IndexOf("PRINTER:") + 8, TenChucNang.IndexOf("SOLIEN:"));
                        SoLien = Convert.ToInt16(e.Tool.Key.Substring(TenChucNang.IndexOf("SOLIEN:") + 12, TenChucNang.IndexOf("SPNAME:") - TenChucNang.IndexOf("SOLIEN:") - 7));
                        spName = e.Tool.Key.Substring(TenChucNang.IndexOf("SPNAME:") + 12, e.Tool.Key.Length - TenChucNang.IndexOf("SPNAME:") - 12);
                        inChungTu();
                    }
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
        }
        protected virtual void UpdateDanhMuc()
        {
        }
        protected virtual void DeleteDanhMuc()
        {
        }
        protected virtual void ViewDanhMuc()
        {
        }
        protected virtual void inChungTu()
        {
        }
        private void ultraButton1_Click(object sender, EventArgs e)
        {
            List();
        }
    }
}
