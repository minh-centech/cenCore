using coreBUS;
using coreDTO;
using System;
using System.Data;
using System.Windows.Forms;
namespace coreUI.Forms
{
    public partial class frmDanhMucLoaiDoiTuong : coreBase.BaseForms.frmBaseDanhMuc
    {
        public frmDanhMucLoaiDoiTuong()
        {
            InitializeComponent();
        }
        protected override void List()
        {
            dtData = DanhMucLoaiDoiTuongBUS.List(null);
            tableName = DanhMucLoaiDoiTuong.tableName;
            dtData.TableName = tableName;
            bsData = new BindingSource
            {
                DataSource = dtData
            };
            ug.DataSource = bsData;
        }
        protected override void InsertDanhMuc()
        {
            base.InsertDanhMuc();
            if (!bContinue) return;
            frmDanhMucLoaiDoiTuongUpdate frmUpdate = new frmDanhMucLoaiDoiTuongUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Them,
                dataTable = dtData,
                Text = "Thêm mới danh mục loại đối tượng",
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void CopyDanhMuc()
        {
            base.CopyDanhMuc();
            if (!bContinue) return;
            frmDanhMucLoaiDoiTuongUpdate frmUpdate = new frmDanhMucLoaiDoiTuongUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                dataTable = dtData,
                dataRow = ((DataRowView)bsData.Current).Row,
                Text = "Sao chép danh mục loại đối tượng",
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void UpdateDanhMuc()
        {
            base.UpdateDanhMuc();
            if (!bContinue) return;
            frmDanhMucLoaiDoiTuongUpdate frmUpdate = new frmDanhMucLoaiDoiTuongUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                dataTable = dtData,
                dataRow = ((DataRowView)bsData.Current).Row,
                Text = "Sửa đổi danh mục loại đối tượng",
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void DeleteDanhMuc()
        {
            if (ug.ActiveRow != null && ug.ActiveRow.IsDataRow)
            {
                deleteAction = new Action(() => { coreUI.DanhMuc.Delete(null, new Func<bool>(() => DanhMucLoaiDoiTuongBUS.Delete(new DanhMucLoaiDoiTuong() { ID = ug.ActiveRow.Cells["ID"].Value })), ug, bsData); });
                base.DeleteDanhMuc();
            }
        }
    }
}
