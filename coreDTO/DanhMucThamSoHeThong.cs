namespace coreDTO
{
    public class DanhMucThamSoHeThong : BaseDTO
    {
        public object IDDanhMucDonVi { get; set; }
        public object Ma { get; set; }
        public object Ten { get; set; }
        public object GiaTri { get; set; }
        public object GhiChu { get; set; }

        public const string tableName = "DanhMucThamSoHeThong";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;
        public const string getGiaTriProcedureName = "Get_" + tableName + "_GiaTri";
        public DanhMucThamSoHeThong()
        {
            ID = null;
            IDDanhMucDonVi = null;
            Ma = null;
            Ten = null;
            GiaTri = null;
            GhiChu = null;
            CreateDate = null;
            EditDate = null;
        }
    }
}
