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
            bsData = new BindingSource
            {
                DataSource = dtData
            };
            ug.DataSource = bsData;
        }
        protected override void Insert()
        {
            frmDanhMucLoaiDoiTuongUpdate frmUpdate = new frmDanhMucLoaiDoiTuongUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Them,
                Text = "Thêm mới danh mục loại đối tượng",
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void Copy()
        {
            frmDanhMucLoaiDoiTuongUpdate frmUpdate = new frmDanhMucLoaiDoiTuongUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                dataRow = ((DataRowView)bsData.Current).Row,
                Text = "Sao chép danh mục loại đối tượng",
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void Update()
        {
            frmDanhMucLoaiDoiTuongUpdate frmUpdate = new frmDanhMucLoaiDoiTuongUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                dataRow = ((DataRowView)bsData.Current).Row,
                Text = "Sửa đổi danh mục loại đối tượng",
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void Delete()
        {
            //if (ug.ActiveRow != null && ug.ActiveRow.IsDataRow)
            //{
            //    deleteAction = new Action(() => { coreUI.DanhMuc.Delete(null, new Func<bool>(() => DanhMucLoaiDoiTuongBUS.Delete(new DanhMucLoaiDoiTuong() { ID = ug.ActiveRow.Cells["ID"].Value })), ug, bsData); });
            //    base.Delete();
            //}
        }
    }
}
