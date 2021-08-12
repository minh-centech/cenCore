namespace coreDTO
{
    public class DanhMucThamSoNguoiSuDung : BaseDTO
    {
        public object IDDanhMucDonVi { get; set; }
        public object IDDanhMucNguoiSuDung { get; set; }
        public object Ma { get; set; }
        public object Ten { get; set; }
        public object GiaTri { get; set; }
        public object GhiChu { get; set; }

        public const string tableName = "DanhMucThamSoNguoiSuDung";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string updateGiaTriProcedureName = "Update_" + tableName + "_GiaTri";
        public const string deleteProcedureName = "Delete_" + tableName;
        public const string getGiaTriProcedureName = "Get_" + tableName + "_GiaTri";
        public DanhMucThamSoNguoiSuDung()
        {
            ID = null;
            IDDanhMucDonVi = null;
            IDDanhMucNguoiSuDung = null;
            Ma = null;
            Ten = null;
            GiaTri = null;
            GhiChu = null;
            CreateDate = null;
            EditDate = null;
        }
    }
}
