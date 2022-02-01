using coreBUS;
using coreDTO;
using System;
using System.Data;
using System.Windows.Forms;
namespace coreUI.Forms
{
    public partial class frmDanhMucThamSoHeThong : coreBase.BaseForms.frmBaseDanhMuc
    {
        public frmDanhMucThamSoHeThong()
        {
            InitializeComponent();
        }
        protected override void List()
        {
            dtData = DanhMucThamSoHeThongBUS.List(null);
            bsData = new BindingSource
            {
                DataSource = dtData
            };
            ug.DataSource = bsData;
        }
        protected override void Insert()
        {
            frmDanhMucThamSoHeThongUpdate frmUpdate = new frmDanhMucThamSoHeThongUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Them,
                Text = "Thêm mới danh mục tham số hệ thống",
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void Copy()
        {
            frmDanhMucThamSoHeThongUpdate frmUpdate = new frmDanhMucThamSoHeThongUpdate
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
            frmDanhMucThamSoHeThongUpdate frmUpdate = new frmDanhMucThamSoHeThongUpdate
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
            //    deleteAction = new Action(() => { coreUI.DanhMuc.Delete(null, new Func<bool>(() => DanhMucThamSoHeThongBUS.Delete(new DanhMucThamSoHeThong() { ID = ug.ActiveRow.Cells["ID"].Value })), ug, bsData); });
            //    base.Delete();
            //}
        }
    }
}
