namespace coreDTO
{
    public class DanhMucChungTu : BaseDTO
    {
        public object Ma { get; set; }
        public object Ten { get; set; }
        public object KiHieu { get; set; }
        public object LoaiManHinh { get; set; }

        public const string tableName = "DanhMucChungTu";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;
        public const string getIDProcedureName = "Get_" + tableName + "_ID";
        public DanhMucChungTu()
        {
            ID = null;
            Ma = null;
            Ten = null;
            CreateDate = null;
            EditDate = null;
        }
    }
    public class DanhMucChungTuTrangThai : BaseDTO
    {
        public object IDDanhMucChungTu { get; set; }
        public object Ma { get; set; }
        public object Ten { get; set; }
        public bool HachToan { get; set; }
        public bool Sua { get; set; }
        public bool Xoa { get; set; }

        public const string tableName = "DanhMucChungTuTrangThai";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;

        public DanhMucChungTuTrangThai()
        {
            ID = null;
            IDDanhMucChungTu = null;
            Ma = null;
            Ten = null;
            CreateDate = null;
            EditDate = null;
        }
    }
    public class DanhMucChungTuIn : BaseDTO
    {
        public object IDDanhMucChungTu { get; set; }
        public object Ma { get; set; }
        public object Ten { get; set; }
        public object ListProcedureName { get; set; }
        public object FileMauIn { get; set; }
        public object SoLien { get; set; }
        public bool PrintPreview { get; set; }

        public const string tableName = "DanhMucChungTuIn";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;

        public DanhMucChungTuIn()
        {
            ID = null;
            Ma = null;
            Ten = null;
            ListProcedureName = null;
            FileMauIn = null;
            SoLien = 0;
            PrintPreview = false;
            CreateDate = null;
            EditDate = null;
        }
    }
    public class DanhMucChungTuQuyTrinh : BaseDTO
    {
        public object IDDanhMucChungTu { get; set; }
        public object IDDanhMucChungTuQuyTrinh { get; set; }
        public object MaDanhMucChungTuQuyTrinh { get; set; }
        public object TenDanhMucChungTuQuyTrinh { get; set; }

        public const string tableName = "DanhMucChungTuQuyTrinh";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;

        public DanhMucChungTuQuyTrinh()
        {
            ID = null;
            IDDanhMucChungTu = null;
            IDDanhMucChungTuQuyTrinh = null;
            MaDanhMucChungTuQuyTrinh = null;
            TenDanhMucChungTuQuyTrinh = null;
            CreateDate = null;
            EditDate = null;
        }
    }
}
