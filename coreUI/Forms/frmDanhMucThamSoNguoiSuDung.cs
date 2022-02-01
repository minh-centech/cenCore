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
            tableName = DanhMucThamSoNguoiSuDung.tableName;
            dtData.TableName = tableName;

            bsData = new BindingSource
            {
                DataSource = dtData
            };
            ug.DataSource = bsData;
        }
        protected override void Insert()
        {
            base.Insert();
            if (!bContinue) return;
            frmDanhMucThamSoNguoiSuDungUpdate frmUpdate = new frmDanhMucThamSoNguoiSuDungUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Them,
                dataTable = dtData,
                Text = "Thêm mới danh mục tham số hệ thống",
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void Copy()
        {
            base.Copy();
            if (!bContinue) return;
            frmDanhMucThamSoNguoiSuDungUpdate frmUpdate = new frmDanhMucThamSoNguoiSuDungUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                Text = "Sao chép danh mục tham số hệ thống",
                dataTable = dtData,
                dataRow = ((DataRowView)bsData.Current).Row
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void Update()
        {
            base.Update();
            if (!bContinue) return;
            frmDanhMucThamSoNguoiSuDungUpdate frmUpdate = new frmDanhMucThamSoNguoiSuDungUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                Text = "Chỉnh sửa danh mục tham số hệ thống",
                dataTable = dtData,
                dataRow = ((DataRowView)bsData.Current).Row
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void Delete()
        {
            if (ug.ActiveRow != null && ug.ActiveRow.IsDataRow)
            {
                deleteAction = new Action(() => { coreUI.DanhMuc.Delete(null, new Func<bool>(() => DanhMucThamSoNguoiSuDungBUS.Delete(new DanhMucThamSoNguoiSuDung() { ID = ug.ActiveRow.Cells["ID"].Value })), ug, bsData); });
                base.Delete();
            }
        }
    }
}
