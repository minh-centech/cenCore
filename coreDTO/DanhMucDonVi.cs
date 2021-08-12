namespace coreDTO
{
    public class DanhMucDonVi : BaseDTO
    {
        public object Ma { get; set; }
        public object Ten { get; set; }

        public const string tableName = "DanhMucDonVi";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;

        public DanhMucDonVi()
        {
            ID = null;
            Ma = null;
            Ten = null;
            CreateDate = null;
            EditDate = null;
        }
    }
}
