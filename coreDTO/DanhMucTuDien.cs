namespace coreDTO
{
    public class DanhMucTuDien : BaseDTO
    {
        public object Ma { get; set; }
        public object Ten { get; set; }

        public const string tableName = "DanhMucTuDien";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;

        public DanhMucTuDien()
        {
            ID = null;
            Ma = null;
            Ten = null;
            CreateDate = null;
            EditDate = null;
        }
    }
}
