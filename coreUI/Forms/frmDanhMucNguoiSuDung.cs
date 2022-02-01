using coreBUS;
using coreDTO;
using System;
using System.Data;
using System.Windows.Forms;
namespace coreUI.Forms
{
    public partial class frmDanhMucNguoiSuDung : coreBase.BaseForms.frmBaseDanhMuc
    {
        public frmDanhMucNguoiSuDung()
        {
            InitializeComponent();
        }
        protected override void List()
        {
            dtData = DanhMucNguoiSuDungBUS.List(null);
            bsData = new BindingSource
            {
                DataSource = dtData
            };
            ug.DataSource = bsData;
            ug.DisplayLayout.Bands[0].Columns["Password"].Hidden = true;
        }
        protected override void Insert()
        {
            frmDanhMucNguoiSuDungUpdate frmUpdate = new frmDanhMucNguoiSuDungUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Them,
                TenDanhMucLoaiDoiTuong = "Thêm mới Danh mục người sử dụng",
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void Copy()
        {
            frmDanhMucNguoiSuDungUpdate frmUpdate = new frmDanhMucNguoiSuDungUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                TenDanhMucLoaiDoiTuong = "Sao chép Danh mục người sử dụng",
                dataRow = ((DataRowView)bsData.Current).Row
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void Update()
        {
            frmDanhMucNguoiSuDungUpdate frmUpdate = new frmDanhMucNguoiSuDungUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                TenDanhMucLoaiDoiTuong = "Chỉnh sửa Danh mục người sử dụng",
                dataRow = ((DataRowView)bsData.Current).Row
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void Delete()
        {
            //if (ug.ActiveRow != null && ug.ActiveRow.IsDataRow)
            //{
            //    deleteAction = new Action(() => { coreUI.DanhMuc.Delete(null, new Func<bool>(() => DanhMucNguoiSuDungBUS.Delete(new DanhMucNguoiSuDung() { ID = ug.ActiveRow.Cells["ID"].Value })), ug, bsData); });
            //    base.Delete();
            //}
        }
    }
}
