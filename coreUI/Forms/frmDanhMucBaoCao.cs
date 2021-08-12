using coreBUS;
using coreCommon;
using coreDTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace coreUI.Forms
{
    public partial class frmDanhMucBaoCao : coreBase.BaseForms.frmBaseDanhMucChiTiet
    {
        public frmDanhMucBaoCao()
        {
            InitializeComponent();
        }
        protected override void List()
        {
            dsData = DanhMucBaoCaoBUS.List(null);

            bsDanhMuc = new BindingSource
            {
                DataSource = dsData,
                DataMember = DanhMucBaoCao.tableName
            };

            bsDanhMucChiTiet = new BindingSource
            {
                DataSource = bsDanhMuc,
                DataMember = GlobalVariables.prefix_DataRelation + DanhMucBaoCaoCot.tableName
            };
            ug.DataSource = bsDanhMuc;
            ugChiTiet.DataSource = bsDanhMucChiTiet;
            tabChiTiet.Tabs["tabChiTiet"].Text = coreCommon.coreCommon.TraTuDien(DanhMucBaoCaoCot.tableName);
        }

        protected override void InsertDanhMuc()
        {
            base.InsertDanhMuc();
            if (!bContinue) return;
            frmDanhMucBaoCaoUpdate frmUpdate = new frmDanhMucBaoCaoUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Them,
                dataTable = dsData.Tables[DanhMucBaoCao.tableName],
                Text = "Thêm mới danh mục báo cáo",
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();

        }
        protected override void CopyDanhMuc()
        {
            base.CopyDanhMuc();
            if (!bContinue) return;
            frmDanhMucBaoCaoUpdate frmUpdate = new frmDanhMucBaoCaoUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                Text = "Thêm mới danh mục báo cáo",
                dataTable = dsData.Tables[DanhMucBaoCao.tableName],
                dataRow = ((DataRowView)bsDanhMuc.Current).Row
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void UpdateDanhMuc()
        {
            base.UpdateDanhMuc();
            if (!bContinue) return;
            frmDanhMucBaoCaoUpdate frmUpdate = new frmDanhMucBaoCaoUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                Text = "Chỉnh sửa danh mục báo cáo",
                dataTable = dsData.Tables[DanhMucBaoCao.tableName],
                dataRow = ((DataRowView)bsDanhMuc.Current).Row
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void DeleteDanhMuc()
        {
            if (ug.ActiveRow != null && ug.ActiveRow.IsDataRow)
            {
                deleteAction = new Action(() => { coreUI.DanhMuc.Delete(null, new Func<bool>(() => DanhMucBaoCaoBUS.Delete(new DanhMucBaoCao() { ID = ug.ActiveRow.Cells["ID"].Value })), ug, bsDanhMuc); });
                base.DeleteDanhMuc();
            }
        }

        protected override void InsertDanhMucChiTiet()
        {
            base.InsertDanhMucChiTiet();
            if (!bContinue) return;
            frmDanhMucBaoCaoCotUpdate frmUpdate = new frmDanhMucBaoCaoCotUpdate
            {
                CapNhat = 1,
                Text = "Thêm mới danh mục cột báo cáo",
                dataTable = dsData.Tables[DanhMucBaoCaoCot.tableName],
                IDDanhMucBaoCao = ((DataRowView)bsDanhMuc.Current).Row["ID"],
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void UpdateDanhMucChiTiet()
        {
            if (ugChiTiet.ActiveRow == null || !ugChiTiet.ActiveRow.IsDataRow) return;
            frmDanhMucBaoCaoCotUpdate frmUpdate = new frmDanhMucBaoCaoCotUpdate
            {
                CapNhat = 2,
                Text = "Chỉnh sửa danh mục cột báo cáo",
                IDDanhMucBaoCao = ((DataRowView)bsDanhMucChiTiet.Current).Row["IDDanhMucBaoCao"],
                dataTable = dsData.Tables[DanhMucBaoCaoCot.tableName],
                dataRow = ((DataRowView)bsDanhMucChiTiet.Current).Row,
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void DeleteDanhMucChiTiet()
        {
            if (ugChiTiet.ActiveRow != null && ugChiTiet.ActiveRow.IsDataRow)
            {
                deleteAction = new Action(() => { coreUI.DanhMuc.Delete(null, new Func<bool>(() => DanhMucBaoCaoCotBUS.Delete(new DanhMucBaoCaoCot() { ID = ugChiTiet.ActiveRow.Cells["ID"].Value })), ugChiTiet, bsDanhMucChiTiet); });
                base.DeleteDanhMuc();
            }
        }
    }
}
