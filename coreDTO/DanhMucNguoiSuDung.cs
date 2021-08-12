namespace coreDTO
{
    public class DanhMucNguoiSuDung : BaseDTO
    {
        public object IDDanhMucPhanQuyen { get; set; }
        public object MaDanhMucPhanQuyen { get; set; }
        public object TenDanhMucPhanQuyen { get; set; }

        public object Ma { get; set; }
        public object Ten { get; set; }
        public object Password { get; set; }
        public bool isAdmin { get; set; }

        public const string tableName = "DanhMucNguoiSuDung";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;
        public const string getIDProcedureName = "Get_" + tableName + "_ID";
        public const string updatePasswordProcedureName = "Update_" + tableName + "_Password";
        public const string listValidMaProcedureName = "List_" + tableName + "_ValidMa";
    }
}
