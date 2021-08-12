namespace coreDTO
{
    public class DanhMucDoiTuong : BaseDTO
    {
        public object IDDanhMucDonVi { get; set; }
        public object IDDanhMucLoaiDoiTuong { get; set; }
        public object Ma { get; set; }
        public object Ten { get; set; }
        public object IDDanhMucNguoiSuDungCreate { get; set; }
        public object IDDanhMucNguoiSuDungEdit { get; set; }

        public const string tableName = "DanhMucDoiTuong";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;
        public const string getIDProcedureName = "Get_" + tableName + "_ID";
        public const string validMaProcedureName = "List_" + tableName + "_ValidMa";
        public DanhMucDoiTuong()
        {
            IDDanhMucDonVi = null;
            IDDanhMucLoaiDoiTuong = null;
            ID = null;
            Ma = null;
            Ten = null;
            IDDanhMucNguoiSuDungCreate = null;
            IDDanhMucNguoiSuDungEdit = null;
            CreateDate = null;
            EditDate = null;
        }
    }
}
