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

            bsData = new BindingSource
            {
                DataSource = dsData,
                DataMember = DanhMucBaoCao.tableName
            };

            bsDataChiTiet = new BindingSource
            {
                DataSource = bsData,
                DataMember = GlobalVariables.prefix_DataRelation + DanhMucBaoCaoCot.tableName
            };
            ug.DataSource = bsData;
            ugChiTiet.DataSource = bsDataChiTiet;
            tabChiTiet.Tabs["tabChiTiet"].Text = coreCommon.coreCommon.TraTuDien(DanhMucBaoCaoCot.tableName);
        }

        protected override void Insert()
        {
            frmDanhMucBaoCaoUpdate frmUpdate = new frmDanhMucBaoCaoUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Them,
                Text = "Thêm mới danh mục báo cáo",
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();

        }
        protected override void Copy()
        {
            frmDanhMucBaoCaoUpdate frmUpdate = new frmDanhMucBaoCaoUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                Text = "Thêm mới danh mục báo cáo",
                dataRow = ((DataRowView)bsData.Current).Row
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void Update()
        {
            frmDanhMucBaoCaoUpdate frmUpdate = new frmDanhMucBaoCaoUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                Text = "Chỉnh sửa danh mục báo cáo",
                dataRow = ((DataRowView)bsData.Current).Row
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void Delete()
        {
            //if (ug.ActiveRow != null && ug.ActiveRow.IsDataRow)
            //{
            //    deleteAction = new Action(() => { coreUI.DanhMuc.Delete(null, new Func<bool>(() => DanhMucBaoCaoBUS.Delete(new DanhMucBaoCao() { ID = ug.ActiveRow.Cells["ID"].Value })), ug, bsData); });
            //    base.Delete();
            //}
        }

        protected override void InsertChiTiet()
        {
            base.InsertChiTiet();
            frmDanhMucBaoCaoCotUpdate frmUpdate = new frmDanhMucBaoCaoCotUpdate
            {
                CapNhat = 1,
                Text = "Thêm mới danh mục cột báo cáo",
                IDDanhMucBaoCao = ((DataRowView)bsData.Current).Row["ID"],
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void UpdateChiTiet()
        {
            if (ugChiTiet.ActiveRow == null || !ugChiTiet.ActiveRow.IsDataRow) return;
            frmDanhMucBaoCaoCotUpdate frmUpdate = new frmDanhMucBaoCaoCotUpdate
            {
                CapNhat = 2,
                Text = "Chỉnh sửa danh mục cột báo cáo",
                IDDanhMucBaoCao = ((DataRowView)bsDataChiTiet.Current).Row["IDDanhMucBaoCao"],
                dataRow = ((DataRowView)bsDataChiTiet.Current).Row,
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void DeleteChiTiet()
        {
            //if (ugChiTiet.ActiveRow != null && ugChiTiet.ActiveRow.IsDataRow)
            //{
            //    deleteAction = new Action(() => { coreUI.DanhMuc.Delete(null, new Func<bool>(() => DanhMucBaoCaoCotBUS.Delete(new DanhMucBaoCaoCot() { ID = ugChiTiet.ActiveRow.Cells["ID"].Value })), ugChiTiet, bsDataChiTiet); });
            //    base.Delete();
            //}
        }
    }
}
