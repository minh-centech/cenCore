using coreBUS;
using coreDTO;
using System;
using System.Data;
using System.Windows.Forms;
namespace coreUI.Forms
{
    public partial class frmDanhMucThamSoNguoiSuDung : coreBase.BaseForms.frmBaseDanhMuc
    {
        public frmDanhMucThamSoNguoiSuDung()
        {
            InitializeComponent();
        }
        protected override void List()
        {
            dtData = DanhMucThamSoNguoiSuDungBUS.List(null);
            bsData = new BindingSource
            {
                DataSource = dtData
            };
            ug.DataSource = bsData;
        }
        protected override void Insert()
        {
            frmDanhMucThamSoNguoiSuDungUpdate frmUpdate = new frmDanhMucThamSoNguoiSuDungUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Them,
                Text = "Thêm mới danh mục tham số hệ thống",
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void Copy()
        {
            frmDanhMucThamSoNguoiSuDungUpdate frmUpdate = new frmDanhMucThamSoNguoiSuDungUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                Text = "Sao chép danh mục tham số hệ thống",
                dataRow = ((DataRowView)bsData.Current).Row
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void Update()
        {
            frmDanhMucThamSoNguoiSuDungUpdate frmUpdate = new frmDanhMucThamSoNguoiSuDungUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                Text = "Chỉnh sửa danh mục tham số hệ thống",
                dataRow = ((DataRowView)bsData.Current).Row
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void Delete()
        {
            //if (ug.ActiveRow != null && ug.ActiveRow.IsDataRow)
            //{
            //    deleteAction = new Action(() => { coreUI.DanhMuc.Delete(null, new Func<bool>(() => DanhMucThamSoNguoiSuDungBUS.Delete(new DanhMucThamSoNguoiSuDung() { ID = ug.ActiveRow.Cells["ID"].Value })), ug, bsData); });
            //    base.Delete();
            //}
        }
    }
}
