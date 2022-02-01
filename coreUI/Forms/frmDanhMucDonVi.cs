using coreBUS;
using coreDTO;
using System;
using System.Data;
using System.Windows.Forms;
namespace coreUI.Forms
{
    public partial class frmDanhMucDonVi : coreBase.BaseForms.frmBaseDanhMuc
    {
        public frmDanhMucDonVi()
        {
            InitializeComponent();
        }
        protected override void List()
        {
            dtData = DanhMucDonViBUS.List(null);
            tableName = DanhMucDonVi.tableName;
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
            frmDanhMucDonViUpdate frmUpdate = new frmDanhMucDonViUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Them,
                dataTable = dtData,
                TenDanhMucLoaiDoiTuong = "Thêm mới Danh mục đơn vị",
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void Copy()
        {
            base.Copy();
            if (!bContinue) return;
            frmDanhMucDonViUpdate frmUpdate = new frmDanhMucDonViUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                dataTable = dtData,
                TenDanhMucLoaiDoiTuong = "Sao chép Danh mục đơn vị",
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void Update()
        {
            base.Update();
            if (!bContinue) return;
            frmDanhMucDonViUpdate frmUpdate = new frmDanhMucDonViUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                dataTable = dtData,
                dataRow = ((DataRowView)bsData.Current).Row,
                TenDanhMucLoaiDoiTuong = "Chỉnh sửa Danh mục đơn vị",
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void Delete()
        {
            if (ug.ActiveRow != null && ug.ActiveRow.IsDataRow)
            {
                deleteAction = new Action(() => { coreUI.DanhMuc.Delete(null, new Func<bool>(() => DanhMucDonViBUS.Delete(new DanhMucDonVi() { ID = ug.ActiveRow.Cells["ID"].Value })), ug, bsData); });
                base.Delete();
            }
        }
    }
}
