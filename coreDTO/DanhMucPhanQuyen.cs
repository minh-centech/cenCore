namespace coreDTO
{
    public class DanhMucPhanQuyen : BaseDTO
    {
        public object Ma { get; set; }
        public object Ten { get; set; }

        public const string tableName = "DanhMucPhanQuyen";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;

        public const string getDanhMucPhanQuyenDonViProcedureName = "Get_" + DanhMucPhanQuyenDonVi.tableName;
        public const string getDanhMucPhanQuyenLoaiDoiTuongProcedureName = "Get_" + DanhMucPhanQuyenLoaiDoiTuong.tableName;
        public const string getDanhMucPhanQuyenChungTuProcedureName = "Get_" + DanhMucPhanQuyenChungTu.tableName;
        public const string getDanhMucPhanQuyenBaoCaoProcedureName = "Get_" + DanhMucPhanQuyenBaoCao.tableName;

        public DanhMucPhanQuyen()
        {
            ID = null;
            Ma = null;
            Ten = null;
            CreateDate = null;
            EditDate = null;
        }
    }
    public class DanhMucPhanQuyenDonVi : BaseDTO
    {
        public object IDDanhMucPhanQuyen { get; set; }
        public object IDDanhMucDonVi { get; set; }
        public object MaDanhMucDonVi { get; set; }
        public object TenDanhMucDonVi { get; set; }
        public bool Xem { get; set; }

        public const string tableName = "DanhMucPhanQuyenDonVi";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;
        public DanhMucPhanQuyenDonVi()
        {
            ID = null;
            IDDanhMucPhanQuyen = null;
            IDDanhMucDonVi = null;
            MaDanhMucDonVi = null;
            TenDanhMucDonVi = null;
            Xem = false;
            CreateDate = null;
            EditDate = null;
        }
    }
    public class DanhMucPhanQuyenLoaiDoiTuong : BaseDTO
    {
        public object IDDanhMucPhanQuyen { get; set; }
        public object IDDanhMucLoaiDoiTuong { get; set; }
        public object MaDanhMucLoaiDoiTuong { get; set; }
        public object TenDanhMucLoaiDoiTuong { get; set; }
        public bool Xem { get; set; }
        public bool Them { get; set; }
        public bool Sua { get; set; }
        public bool Xoa { get; set; }

        public const string tableName = "DanhMucPhanQuyenLoaiDoiTuong";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;

        public DanhMucPhanQuyenLoaiDoiTuong()
        {
            ID = null;
            IDDanhMucPhanQuyen = null;
            IDDanhMucLoaiDoiTuong = null;
            MaDanhMucLoaiDoiTuong = null;
            TenDanhMucLoaiDoiTuong = null;
            Xem = false;
            Them = false;
            Sua = false;
            Xoa = false;
            CreateDate = null;
            EditDate = null;
        }
    }
    public class DanhMucPhanQuyenChungTu : BaseDTO
    {
        public object IDDanhMucPhanQuyen { get; set; }
        public object IDDanhMucChungTu { get; set; }
        public object MaDanhMucChungTu { get; set; }
        public object TenDanhMucChungTu { get; set; }
        public bool Xem { get; set; }
        public bool Them { get; set; }
        public bool Sua { get; set; }
        public bool Xoa { get; set; }

        public const string tableName = "DanhMucPhanQuyenChungTu";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;

        public DanhMucPhanQuyenChungTu()
        {
            ID = null;
            IDDanhMucPhanQuyen = null;
            IDDanhMucChungTu = null;
            MaDanhMucChungTu = null;
            TenDanhMucChungTu = null;
            Xem = false;
            Them = false;
            Sua = false;
            Xoa = false;
            CreateDate = null;
            EditDate = null;
        }
    }
    public class DanhMucPhanQuyenBaoCao : BaseDTO
    {
        public object IDDanhMucPhanQuyen { get; set; }
        public object IDDanhMucBaoCao { get; set; }
        public object MaDanhMucBaoCao { get; set; }
        public object TenDanhMucBaoCao { get; set; }
        public bool Xem { get; set; }

        public const string tableName = "DanhMucPhanQuyenBaoCao";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;

        public DanhMucPhanQuyenBaoCao()
        {
            ID = null;
            IDDanhMucPhanQuyen = null;
            IDDanhMucBaoCao = null;
            MaDanhMucBaoCao = null;
            TenDanhMucBaoCao = null;
            Xem = false;
            CreateDate = null;
            EditDate = null;
        }
    }
}
