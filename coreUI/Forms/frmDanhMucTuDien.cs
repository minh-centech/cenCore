using coreBUS;
using coreDTO;
using System;
using System.Data;
using System.Windows.Forms;
namespace coreUI.Forms
{
    public partial class frmDanhMucTuDien : coreBase.BaseForms.frmBaseDanhMuc
    {
        public frmDanhMucTuDien()
        {
            InitializeComponent();
        }
        protected override void List()
        {
            dtData = DanhMucTuDienBUS.List(null);
            tableName = DanhMucTuDien.tableName;
            dtData.TableName = tableName;

            bsDanhMuc = new BindingSource
            {
                DataSource = dtData
            };
            ug.DataSource = bsDanhMuc;
        }
        protected override void InsertDanhMuc()
        {
            base.InsertDanhMuc();
            if (!bContinue) return;
            frmDanhMucTuDienUpdate frmUpdate = new frmDanhMucTuDienUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Them,
                dataTable = dtData,
                Text = "Thêm mới danh mục từ điển",
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void CopyDanhMuc()
        {
            base.CopyDanhMuc();
            if (!bContinue) return;
            frmDanhMucTuDienUpdate frmUpdate = new frmDanhMucTuDienUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                Text = "Sao chép danh mục từ điển",
                dataTable = dtData,
                dataRow = ((DataRowView)bsDanhMuc.Current).Row
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void UpdateDanhMuc()
        {
            base.UpdateDanhMuc();
            if (!bContinue) return;
            frmDanhMucTuDienUpdate frmUpdate = new frmDanhMucTuDienUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                Text = "Chỉnh sửa danh mục từ điển",
                dataTable = dtData,
                dataRow = ((DataRowView)bsDanhMuc.Current).Row
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void DeleteDanhMuc()
        {
            if (ug.ActiveRow != null && ug.ActiveRow.IsDataRow)
            {
                deleteAction = new Action(() => { coreUI.DanhMuc.Delete(null, new Func<bool>(() => DanhMucTuDienBUS.Delete(new DanhMucTuDien() { ID = ug.ActiveRow.Cells["ID"].Value })), ug, bsDanhMuc); });
                base.DeleteDanhMuc();
            }
        }
    }
}
