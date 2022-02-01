using coreBUS;
using coreDTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace coreUI.Forms
{
    public partial class frmDanhMucDoiTuong : coreBase.BaseForms.frmBaseDanhMuc
    {
        public frmDanhMucDoiTuong()
        {
            InitializeComponent();
        }
        protected override void List()
        {
            DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucLoaiDoiTuong, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Xem)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền xem dữ liệu danh mục này!");
                return;
            }
            dtData = DanhMucDoiTuongBUS.List(null, IDDanhMucLoaiDoiTuong, null);
            bsData = new BindingSource
            {
                DataSource = dtData
            };
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
            if (!coreCommon.GlobalVariables.isAdmin && !Them)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền thêm mới dữ liệu danh mục này!");
                return;
            }
            frmDanhMucDoiTuongUpdate frmUpdate = new frmDanhMucDoiTuongUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Them,
                IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                TenDanhMucLoaiDoiTuong = TenDanhMucLoaiDoiTuong,
                InsertToList = new Action(() => InsertToList(frmDanhMucDoiTuongUpdate.dtUpdate)),
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void Copy()
        {
            DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucLoaiDoiTuong, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Them)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền thêm mới dữ liệu danh mục này!");
                return;
            }
            base.Copy();
            frmDanhMucDoiTuongUpdate frmUpdate = new frmDanhMucDoiTuongUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                dataRow = ((DataRowView)bsData.Current).Row,
                IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                TenDanhMucLoaiDoiTuong = TenDanhMucLoaiDoiTuong,
                InsertToList = new Action(() => InsertToList(frmDanhMucDoiTuongUpdate.dtUpdate)),
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void Update()
        {
            DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucLoaiDoiTuong, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Sua)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền sửa dữ liệu danh mục này!");
                return;
            }
            frmDanhMucDoiTuongUpdate frmUpdate = new frmDanhMucDoiTuongUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                dataRow = ((DataRowView)bsData.Current).Row,
                ID = IDDanhMucDoiTuong,
                IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                TenDanhMucLoaiDoiTuong = TenDanhMucLoaiDoiTuong,
                UpdateToList = new Action(() => UpdateToList(frmDanhMucDoiTuongUpdate.dtUpdate)),
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void Delete()
        {
            DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucLoaiDoiTuong, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Xoa)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền sửa dữ liệu danh mục này!");
                return;
            }
            if (ug.ActiveRow == null || !ug.ActiveRow.IsDataRow) return;
            if (coreCommon.coreCommon.QuestionMessage("Bạn chắc chắn muốn xóa dữ liệu danh mục này?", 0) == DialogResult.No) return;
            //Nếu ID = null thì xóa theo ID chứng từ
            bool OK = DanhMucDoiTuongBUS.Delete(new DanhMucDoiTuong() { ID = ug.ActiveRow.Cells["ID"].Value });
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
