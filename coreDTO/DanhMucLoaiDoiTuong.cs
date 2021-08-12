namespace coreDTO
{
    public class DanhMucLoaiDoiTuong : BaseDTO
    {
        public object Ma { get; set; }
        public object Ten { get; set; }
        public object TenBangDuLieu { get; set; }

        public const string tableName = "DanhMucLoaiDoiTuong";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;
        public const string getTenBangDuLieuProcedureName = "Get_" + tableName + "_TenBangDuLieu";
        public const string getIDProcedureName = "Get_" + tableName + "_ID";
        public const string getMaProcedureName = "Get_" + tableName + "_Ma";
        public const string validMaProcedureName = "List_" + tableName + "_ValidMa";

        public DanhMucLoaiDoiTuong()
        {
            ID = null;
            Ma = null;
            Ten = null;
            TenBangDuLieu = null;
            CreateDate = null;
            EditDate = null;
        }
    }
}
