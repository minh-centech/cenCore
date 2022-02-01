using coreBUS;
using coreDTO;
using System;
using System.Data;
using System.Windows.Forms;
namespace coreUI.Forms
{
    public partial class frmDanhMucNhomBaoCao : coreBase.BaseForms.frmBaseDanhMuc
    {
        public frmDanhMucNhomBaoCao()
        {
            InitializeComponent();
        }
        protected override void List()
        {
            dtData = DanhMucNhomBaoCaoBUS.List(null);
            tableName = DanhMucNhomBaoCao.tableName;
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
            frmDanhMucNhomBaoCaoUpdate frmUpdate = new frmDanhMucNhomBaoCaoUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Them,
                dataTable = dtData,
                TenDanhMucLoaiDoiTuong = "Danh mục nhóm báo cáo",
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void Copy()
        {
            base.Copy();
            if (!bContinue) return;
            frmDanhMucNhomBaoCaoUpdate frmUpdate = new frmDanhMucNhomBaoCaoUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                TenDanhMucLoaiDoiTuong = "Danh mục nhóm báo cáo",
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
            frmDanhMucNhomBaoCaoUpdate frmUpdate = new frmDanhMucNhomBaoCaoUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                TenDanhMucLoaiDoiTuong = "Danh mục nhóm báo cáo",
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
                deleteAction = new Action(() => { coreUI.DanhMuc.Delete(null, new Func<bool>(() => DanhMucNhomBaoCaoBUS.Delete(new DanhMucNhomBaoCao() { ID = ug.ActiveRow.Cells["ID"].Value })), ug, bsData); });
                base.Delete();
            }
        }
    }
}
