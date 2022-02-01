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
        static object IDDanhMucDoiTuong;
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
        public void InsertToList(DataTable dtUpdate)
        {
            dtData.Merge(dtUpdate);
        }
        public void UpdateToList(DataTable dtUpdate)
        {
            if (!coreCommon.coreCommon.IsNull(dtUpdate))
            {
                bool Found = false;
                for (int i = dtData.Rows.Count - 1; i >= 0; i--)
                {
                    Found = false;
                    //Cập nhật dòng chỉnh sửa
                    foreach (DataRow drChungTuUpdate in dtUpdate.Rows)
                    {
                        if (dtData.Rows[i].RowState != DataRowState.Deleted && dtData.Rows[i]["ID"].ToString() == drChungTuUpdate["ID"].ToString())
                        {
                            dtData.Rows[i].ItemArray = drChungTuUpdate.ItemArray;
                            Found = true;
                        }
                    }
                    //Xóa dòng bị xóa
                    if (!coreCommon.coreCommon.IsNull(IDDanhMucDoiTuong))
                        if (!Found && dtData.Rows[i].RowState != DataRowState.Deleted && dtData.Columns.Contains("ID") && dtData.Rows[i]["ID"].ToString() == IDDanhMucDoiTuong.ToString()) dtData.Rows[i].Delete();
                }
                //Thêm mới những dòng được thêm
                foreach (DataRow drChungTuUpdate in dtUpdate.Rows)
                {
                    Found = false;
                    foreach (DataRow drData in dtData.Rows)
                    {
                        if (drData.RowState != DataRowState.Deleted && drChungTuUpdate["ID"].ToString() == drData["ID"].ToString())
                        {
                            Found = true;
                        }
                    }
                    if (!Found) dtData.ImportRow(drChungTuUpdate);
                }
                dtData.AcceptChanges();
            }
        }
        protected override void Insert()
        {
            DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucLoaiDoiTuong, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Xem)
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
            DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucLoaiDoiTuong, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
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
            DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucLoaiDoiTuong, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
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
            DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucLoaiDoiTuong, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Xoa)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền xóa dữ liệu danh mục này!");
                return;
            }

            if (ug.ActiveRow == null || !ug.ActiveRow.IsDataRow || fDelete == null) return;
            if (coreCommon.coreCommon.QuestionMessage("Bạn chắc chắn muốn xóa danh mục này?", 0) == DialogResult.No) return;
            //Nếu ID = null thì xóa theo ID chứng từ
            bool OK = false;
            if (fDelete != null)
                OK = fDelete();
            if (OK)
            {
                int i = ug.ActiveRow.Index;
                bsData.RemoveCurrent();
                while (i > ug.Rows.Count - 1) i -= 1;
                if (i <= ug.Rows.Count - 1 && i >= 0)
                {
                    ug.Focus();
                    ug.Rows[i].Activate();
                }
                bsData.EndEdit();
            }
        }
    }
}
