namespace coreDTO
{
    public class DanhMucNhomBaoCao : BaseDTO
    {
        public object Ma { get; set; }
        public object Ten { get; set; }

        public const string tableName = "DanhMucNhomBaoCao";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;
        public DanhMucNhomBaoCao()
        {
            ID = null;
            Ma = null;
            Ten = null;
            CreateDate = null;
            EditDate = null;
        }
    }
    public class DanhMucBaoCao : BaseDTO
    {
        public object Ma { get; set; }
        public object Ten { get; set; }
        public object ReportProcedureName { get; set; }
        public object FixedColumnList { get; set; }
        public object KhoGiay { get; set; }
        public object HuongIn { get; set; }
        public object ChucDanhKy { get; set; }
        public object DienGiaiKy { get; set; }
        public object TenNguoiKy { get; set; }
        public bool ThamChieuChungTu { get; set; }
        public object IDDanhMucBaoCaoThamChieu { get; set; }
        public object MaDanhMucBaoCaoThamChieu { get; set; }
        public object TenDanhMucBaoCaoThamChieu { get; set; }
        public object FileExcelMau { get; set; }
        public object SheetExcelMau { get; set; }
        public object SoDongBatDau { get; set; }
        public object IDDanhMucNhomBaoCao { get; set; }
        public object MaDanhMucNhomBaoCao { get; set; }
        public object TenDanhMucNhomBaoCao { get; set; }
        public object IDDanhMucBaoCaoCopyCot { get; set; }

        public const string tableName = "DanhMucBaoCao";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;
        public const string getMaProcedureName = "GetMa_" + tableName + "_ByID";
        public DanhMucBaoCao()
        {
            ID = null;
            Ma = null;
            Ten = null;
            ReportProcedureName = null;
            FixedColumnList = null;
            KhoGiay = 1;
            HuongIn = 1;
            ChucDanhKy = null;
            DienGiaiKy = null;
            TenNguoiKy = null;
            ThamChieuChungTu = false;
            IDDanhMucBaoCaoThamChieu = null;
            MaDanhMucBaoCaoThamChieu = null;
            TenDanhMucBaoCaoThamChieu = null;
            FileExcelMau = null;
            SheetExcelMau = null;
            SoDongBatDau = null;
            IDDanhMucNhomBaoCao = null;
            MaDanhMucNhomBaoCao = null;
            TenDanhMucNhomBaoCao = null;
            IDDanhMucBaoCaoCopyCot = null;
            CreateDate = null;
            EditDate = null;
        }
    }
    public class DanhMucBaoCaoCot : BaseDTO
    {
        public object IDDanhMucBaoCao { get; set; }
        public object Ma { get; set; }
        public object Ten { get; set; }
        public object ColumnWidth { get; set; }
        public object HeaderHeight { get; set; }
        public object TenNhomCot { get; set; }
        public object ThuTu { get; set; }
        public object TenCotExcel { get; set; }
        public object KieuDuLieu { get; set; }

        public const string tableName = "DanhMucBaoCaoCot";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;

        public DanhMucBaoCaoCot()
        {
            ID = null;
            IDDanhMucBaoCao = null;
            Ma = null;
            Ten = null;
            ColumnWidth = 1;
            HeaderHeight = 1;
            TenNhomCot = null;
            ThuTu = 0;
            TenCotExcel = null;
            KieuDuLieu = null;
            CreateDate = null;
            EditDate = null;
        }
    }
}
