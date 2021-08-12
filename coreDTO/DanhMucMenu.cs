namespace coreDTO
{
    public class DanhMucMenu : BaseDTO
    {
        public object Ma { get; set; }
        public object Ten { get; set; }
        public object ThuTuHienThi { get; set; }
        public const string tableName = "DanhMucMenu";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;

        public DanhMucMenu()
        {
            ID = null;
            Ma = null;
            Ten = null;
            ThuTuHienThi = 1;
            CreateDate = null;
            EditDate = null;
        }
    }
    public class DanhMucMenuLoaiDoiTuong : BaseDTO
    {
        public object IDDanhMucMenu { get; set; }
        public object IDDanhMucLoaiDoiTuong { get; set; }
        public object MaDanhMucLoaiDoiTuong { get; set; }
        public object TenDanhMucLoaiDoiTuong { get; set; }
        public object NoiDungHienThi { get; set; }
        public object PhanCachNhom { get; set; }
        public object ThuTuHienThi { get; set; }

        public static string tableName = "DanhMucMenuLoaiDoiTuong";
        public static string listProcedureName = "List_" + tableName;
        public static string insertProcedureName = "Insert_" + tableName;
        public static string updateProcedureName = "Update_" + tableName;
        public static string deleteProcedureName = "Delete_" + tableName;

        public DanhMucMenuLoaiDoiTuong()
        {
            ID = null;
            IDDanhMucMenu = null;
            IDDanhMucLoaiDoiTuong = null;
            MaDanhMucLoaiDoiTuong = null;
            TenDanhMucLoaiDoiTuong = null;
            NoiDungHienThi = null;
            PhanCachNhom = null;
            ThuTuHienThi = 1;
            CreateDate = null;
            EditDate = null;
        }
    }
    public class DanhMucMenuChungTu : BaseDTO
    {
        public object IDDanhMucMenu { get; set; }
        public object IDDanhMucChungTu { get; set; }
        public object MaDanhMucChungTu { get; set; }
        public object TenDanhMucChungTu { get; set; }
        public object NoiDungHienThi { get; set; }
        public object PhanCachNhom { get; set; }
        public object ThuTuHienThi { get; set; }

        public static string tableName = "DanhMucMenuChungTu";
        public static string listProcedureName = "List_" + tableName;
        public static string insertProcedureName = "Insert_" + tableName;
        public static string updateProcedureName = "Update_" + tableName;
        public static string deleteProcedureName = "Delete_" + tableName;

        public DanhMucMenuChungTu()
        {
            ID = null;
            IDDanhMucMenu = null;
            IDDanhMucChungTu = null;
            MaDanhMucChungTu = null;
            TenDanhMucChungTu = null;
            NoiDungHienThi = null;
            PhanCachNhom = null;
            ThuTuHienThi = 1;
            CreateDate = null;
            EditDate = null;
        }
    }
    public class DanhMucMenuBaoCao : BaseDTO
    {
        public object IDDanhMucMenu { get; set; }
        public object IDDanhMucBaoCao { get; set; }
        public object MaDanhMucBaoCao { get; set; }
        public object TenDanhMucBaoCao { get; set; }
        public object NoiDungHienThi { get; set; }
        public object PhanCachNhom { get; set; }
        public object ThuTuHienThi { get; set; }

        public static string tableName = "DanhMucMenuBaoCao";
        public static string listProcedureName = "List_" + tableName;
        public static string insertProcedureName = "Insert_" + tableName;
        public static string updateProcedureName = "Update_" + tableName;
        public static string deleteProcedureName = "Delete_" + tableName;

        public DanhMucMenuBaoCao()
        {
            ID = null;
            IDDanhMucMenu = null;
            IDDanhMucBaoCao = null;
            MaDanhMucBaoCao = null;
            TenDanhMucBaoCao = null;
            NoiDungHienThi = null;
            ThuTuHienThi = 1;
            CreateDate = null;
            EditDate = null;
        }
    }
}
