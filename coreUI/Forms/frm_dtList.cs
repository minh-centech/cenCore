using coreBUS;
using coreDTO;
using System;
using System.Data;
using System.Windows.Forms;
namespace coreUI.Forms
{
    public partial class frm_dtList : coreBase.BaseForms.frmBaseDanhMuc
    {
        public Func<DataTable> fList;
        public Action fInsert, fUpdate, fCopy;
        public Func<bool> fDelete;
        public string FixedColumnsList, HiddenColumnsList;
        public frm_dtList()
        {
            InitializeComponent();
        }
        protected override void List()
        {
            dtData = fList();
            bsData = new BindingSource();
            bsData.DataSource = dtData;
            ug.FixedColumnsList = FixedColumnsList;
            ug.HiddenColumnsList = HiddenColumnsList;
            ug.AddSummaryRow = true;
            ug.DataSource = bsData;
        }
        protected override void Insert()
        {
            bool Them = true;
            if (coreCommon.coreCommon.stringParse(IDDanhMucLoaiDoiTuong) != coreCommon.GlobalVariables.DanhMucLoaiDoiTuongTaiKhoanKeToan)
                DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucLoaiDoiTuong, out bool Xem, out Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Them)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền thêm mới dữ liệu danh mục này!");
                return;
            }
            if (fInsert != null)
            {
                fInsert();
            }
        }
        protected override void Copy()
        {
            bool Them = true;
            if (coreCommon.coreCommon.stringParse(IDDanhMucLoaiDoiTuong) != coreCommon.GlobalVariables.DanhMucLoaiDoiTuongTaiKhoanKeToan)
                DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucLoaiDoiTuong, out bool Xem, out Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Them)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền thêm mới dữ liệu danh mục này!");
                return;
            }
            if (ug.ActiveRow == null || !ug.ActiveRow.IsDataRow || fUpdate == null) return;
            IDDanhMucDoiTuong = (dtData.Columns.Contains("ID")) ? ug.ActiveRow.Cells["ID"].Value.ToString() : null;
            fCopy();
        }
        protected override void Update()
        {
            bool Sua = true;
            if (coreCommon.coreCommon.stringParse(IDDanhMucLoaiDoiTuong) != coreCommon.GlobalVariables.DanhMucLoaiDoiTuongTaiKhoanKeToan)
                DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucLoaiDoiTuong, out bool Xem, out bool Them, out Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Sua)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền sửa dữ liệu danh mục này!");
                return;
            }
            if (ug.ActiveRow == null || !ug.ActiveRow.IsDataRow || fUpdate == null) return;
            IDDanhMucDoiTuong = (dtData.Columns.Contains("ID")) ? ug.ActiveRow.Cells["ID"].Value.ToString() : null;
            fUpdate();
        }
        protected override void Delete()
        {
            bool Xoa = true;
            if (coreCommon.coreCommon.stringParse(IDDanhMucLoaiDoiTuong) != coreCommon.GlobalVariables.DanhMucLoaiDoiTuongTaiKhoanKeToan)
                DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucLoaiDoiTuong, out bool Xem, out bool Them, out bool Sua, out Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Xoa)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền xóa dữ liệu danh mục này!");
                return;
            }

            if (ug.ActiveRow == null || !ug.ActiveRow.IsDataRow || fDelete == null) return;
            if (coreCommon.coreCommon.QuestionMessage("Bạn chắc chắn muốn xóa danh mục này?", 0) == DialogResult.No) return;
            bool OK = false;
            IDDanhMucDoiTuong = (dtData.Columns.Contains("ID")) ? ug.ActiveRow.Cells["ID"].Value.ToString() : null;
            if (fDelete != null)
                OK = fDelete();
            if (OK)
                coreUI.ugDeleteRow(bsData, ug);
        }
    }
}
