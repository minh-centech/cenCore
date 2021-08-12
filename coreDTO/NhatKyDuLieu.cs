namespace coreDTO
{
    public class NhatKyDuLieu
    {
        public object ID { get; set; }
        public object Ngay { get; set; }
        public object Gio { get; set; }
        public object AutoID { get; set; }
        public object AutoIDChungTu { get; set; }
        public object AutoIDChungTuChiTiet { get; set; }
        public object ThaoTac { get; set; }
        public object TenBangDuLieu { get; set; }
        public object DuLieu { get; set; }
        public object DuLieuGoc { get; set; }
        public object IDDanhMucNguoiSuDung { get; set; }
        public object MaDanhMucNguoiSuDung { get; set; }
        public object TenDanhMucNguoiSuDung { get; set; }

        public const string tableName = "NhatKyDuLieu";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        //public const string updateProcedureName = "Update_" + tableName;
        //public const string deleteProcedureName = "Delete_" + tableName;

        public NhatKyDuLieu()
        {
            ID = null;
            Ngay = null;
            Gio = null;
            AutoID = null;
            AutoIDChungTu = null;
            AutoIDChungTuChiTiet = null;
            ThaoTac = null;
            TenBangDuLieu = null;
            DuLieu = null;
            DuLieuGoc = null;
            IDDanhMucNguoiSuDung = null;
            MaDanhMucNguoiSuDung = null;
            TenDanhMucNguoiSuDung = null;
        }
    }
}
