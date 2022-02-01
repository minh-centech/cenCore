using coreBUS;
using coreCommon;
using coreDTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace coreUI.Forms
{
    public partial class frmDanhMucPhanQuyen : coreBase.BaseForms.frmBaseDanhMucChiTiet
    {
        BindingSource bsLoaiDoiTuong = null, bsChungTu = null, bsBaoCao = null;
        public frmDanhMucPhanQuyen()
        {
            InitializeComponent();
        }
        protected override void List()
        {

            dsData = DanhMucPhanQuyenBUS.List(null);

            bsData = new BindingSource
            {
                DataSource = dsData,
                DataMember = DanhMucPhanQuyen.tableName
            };

            bsDataChiTiet = new BindingSource
            {
                DataSource = bsData,
                DataMember = GlobalVariables.prefix_DataRelation + DanhMucPhanQuyenDonVi.tableName
            };

            bsLoaiDoiTuong = new BindingSource
            {
                DataSource = bsData,
                DataMember = GlobalVariables.prefix_DataRelation + DanhMucPhanQuyenLoaiDoiTuong.tableName
            };

            bsChungTu = new BindingSource
            {
                DataSource = bsData,
                DataMember = GlobalVariables.prefix_DataRelation + DanhMucPhanQuyenChungTu.tableName
            };

            bsBaoCao = new BindingSource
            {
                DataSource = bsData,
                DataMember = GlobalVariables.prefix_DataRelation + DanhMucPhanQuyenBaoCao.tableName
            };

            ug.DataSource = bsData;
            ugChiTiet.DataSource = bsDataChiTiet;
            ugLoaiDoiTuong.DataSource = bsLoaiDoiTuong;
            ugChungTu.DataSource = bsChungTu;
            ugBaoCao.DataSource = bsBaoCao;

            tabChiTiet.Tabs["tabChiTiet"].Text = coreCommon.coreCommon.TraTuDien(DanhMucPhanQuyenDonVi.tableName);
            tabChiTiet.Tabs["tabLoaiDoiTuong"].Text = coreCommon.coreCommon.TraTuDien(DanhMucPhanQuyenLoaiDoiTuong.tableName);
            tabChiTiet.Tabs["tabChungTu"].Text = coreCommon.coreCommon.TraTuDien(DanhMucPhanQuyenChungTu.tableName);
            tabChiTiet.Tabs["tabBaoCao"].Text = coreCommon.coreCommon.TraTuDien(DanhMucPhanQuyenBaoCao.tableName);
        }

        protected override void Insert()
        {
            frmDanhMucPhanQuyenUpdate frmUpdate = new frmDanhMucPhanQuyenUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Them,
                TenDanhMucLoaiDoiTuong = "Thêm mới Danh mục phân quyền",
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void Copy()
        {
            frmDanhMucPhanQuyenUpdate frmUpdate = new frmDanhMucPhanQuyenUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                TenDanhMucLoaiDoiTuong = "Sao chép Danh mục phân quyền",
                dataRow = ((DataRowView)bsData.Current).Row
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void Update()
        {
            frmDanhMucPhanQuyenUpdate frmUpdate = new frmDanhMucPhanQuyenUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                TenDanhMucLoaiDoiTuong = "Chỉnh sửa Danh mục phân quyền",
                dataRow = ((DataRowView)bsData.Current).Row
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void Delete()
        {
            //if (ug.ActiveRow != null && ug.ActiveRow.IsDataRow)
            //{
            //    deleteAction = new Action(() => { coreUI.DanhMuc.Delete(null, new Func<bool>(() => DanhMucPhanQuyenBUS.Delete(new DanhMucPhanQuyen() { ID = ug.ActiveRow.Cells["ID"].Value })), ug, bsData); });
            //    base.Delete();
            //}
        }

        protected override void UpdateChiTiet()
        {
            switch (tabChiTiet.SelectedTab.Key.ToUpper())
            {
                case "TABCHITIET":
                    if (ugChiTiet.ActiveRow == null || !ugChiTiet.ActiveRow.IsDataRow) return;
                    frmDanhMucPhanQuyenDonViUpdate frmDanhMucPhanQuyenDonViUpdate = new frmDanhMucPhanQuyenDonViUpdate
                    {
                        CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                        TenDanhMucLoaiDoiTuong = "Chỉnh sửa Danh mục phân quyền đơn vị",
                        IDDanhMucPhanQuyen = ((DataRowView)bsDataChiTiet.Current).Row["IDDanhMucPhanQuyen"],
                        dataRow = ((DataRowView)bsDataChiTiet.Current).Row,
                    };
                    frmDanhMucPhanQuyenDonViUpdate.ShowDialog();
                    frmDanhMucPhanQuyenDonViUpdate.Dispose();
                    break;
                case "TABLOAIDOITUONG":
                    if (ugLoaiDoiTuong.ActiveRow == null || !ugLoaiDoiTuong.ActiveRow.IsDataRow) return;
                    frmDanhMucPhanQuyenLoaiDoiTuongUpdate frmDanhMucPhanQuyenLoaiDoiTuongUpdate = new frmDanhMucPhanQuyenLoaiDoiTuongUpdate
                    {
                        CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                        TenDanhMucLoaiDoiTuong = "Chỉnh sửa Danh mục phân quyền loại đối tượng",
                        IDDanhMucPhanQuyen = ((DataRowView)bsLoaiDoiTuong.Current).Row["IDDanhMucPhanQuyen"],
                        dataRow = ((DataRowView)bsLoaiDoiTuong.Current).Row,
                    };
                    frmDanhMucPhanQuyenLoaiDoiTuongUpdate.ShowDialog();
                    frmDanhMucPhanQuyenLoaiDoiTuongUpdate.Dispose();
                    break;
                case "TABCHUNGTU":
                    if (ugChungTu.ActiveRow == null || !ugChungTu.ActiveRow.IsDataRow) return;
                    frmDanhMucPhanQuyenChungTuUpdate frmDanhMucPhanQuyenChungTuUpdate = new frmDanhMucPhanQuyenChungTuUpdate
                    {
                        CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                        TenDanhMucLoaiDoiTuong = "Chỉnh sửa Danh mục phân quyền chứng từ",
                        IDDanhMucPhanQuyen = ((DataRowView)bsChungTu.Current).Row["IDDanhMucPhanQuyen"],
                        dataRow = ((DataRowView)bsChungTu.Current).Row,
                    };
                    frmDanhMucPhanQuyenChungTuUpdate.ShowDialog();
                    frmDanhMucPhanQuyenChungTuUpdate.Dispose();
                    break;
                case "TABBAOCAO":
                    if (ugBaoCao.ActiveRow == null || !ugBaoCao.ActiveRow.IsDataRow) return;
                    frmDanhMucPhanQuyenBaoCaoUpdate frmDanhMucPhanQuyenBaoCaoUpdate = new frmDanhMucPhanQuyenBaoCaoUpdate
                    {
                        CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                        TenDanhMucLoaiDoiTuong = "Chỉnh sửa Danh mục phân quyền báo cáo",
                        IDDanhMucPhanQuyen = ((DataRowView)bsDataChiTiet.Current).Row["IDDanhMucPhanQuyen"],
                        dataRow = ((DataRowView)bsDataChiTiet.Current).Row,
                    };
                    frmDanhMucPhanQuyenBaoCaoUpdate.ShowDialog();
                    frmDanhMucPhanQuyenBaoCaoUpdate.Dispose();
                    break;
            }
        }

        //private void ugChiTiet_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        //{
        //    base.UpdateChiTiet();
        //    if (!bContinue) return;
        //    frmDanhMucPhanQuyenDonViUpdate frmDanhMucPhanQuyenDonViUpdate = new frmDanhMucPhanQuyenDonViUpdate
        //    {
        //        CapNhat = coreCommon.ThaoTacDuLieu.Sua,
        //        TenDanhMucLoaiDoiTuong = "Chỉnh sửa Danh mục phân quyền đơn vị",
        //        IDDanhMucPhanQuyen = ((DataRowView)bsDataChiTiet.Current).Row["IDDanhMucPhanQuyen"],
        //        dataTable = dsData.Tables[DanhMucPhanQuyenDonVi.tableName],
        //        dataRow = ((DataRowView)bsDataChiTiet.Current).Row,
        //    };
        //    frmDanhMucPhanQuyenDonViUpdate.ShowDialog();
        //    frmDanhMucPhanQuyenDonViUpdate.Dispose();
        //}

        private void ugBaoCao_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (ugBaoCao.ActiveRow == null || !ugBaoCao.ActiveRow.IsDataRow) return;
            frmDanhMucPhanQuyenBaoCaoUpdate frmDanhMucPhanQuyenBaoCaoUpdate = new frmDanhMucPhanQuyenBaoCaoUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                TenDanhMucLoaiDoiTuong = "Chỉnh sửa Danh mục phân quyền báo cáo",
                IDDanhMucPhanQuyen = ((DataRowView)bsBaoCao.Current).Row["IDDanhMucPhanQuyen"],
                dataRow = ((DataRowView)bsBaoCao.Current).Row,
            };
            frmDanhMucPhanQuyenBaoCaoUpdate.ShowDialog();
            frmDanhMucPhanQuyenBaoCaoUpdate.Dispose();
        }

        private void ugChungTu_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (ugChungTu.ActiveRow == null || !ugChungTu.ActiveRow.IsDataRow) return;
            frmDanhMucPhanQuyenChungTuUpdate frmDanhMucPhanQuyenChungTuUpdate = new frmDanhMucPhanQuyenChungTuUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                TenDanhMucLoaiDoiTuong = "Chỉnh sửa Danh mục phân quyền chứng từ",
                IDDanhMucPhanQuyen = ((DataRowView)bsChungTu.Current).Row["IDDanhMucPhanQuyen"],
                dataRow = ((DataRowView)bsChungTu.Current).Row,
            };
            frmDanhMucPhanQuyenChungTuUpdate.ShowDialog();
            frmDanhMucPhanQuyenChungTuUpdate.Dispose();
        }
        private void ugLoaiDoiTuong_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (ugLoaiDoiTuong.ActiveRow == null || !ugLoaiDoiTuong.ActiveRow.IsDataRow) return;
            frmDanhMucPhanQuyenLoaiDoiTuongUpdate frmDanhMucPhanQuyenLoaiDoiTuongUpdate = new frmDanhMucPhanQuyenLoaiDoiTuongUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                TenDanhMucLoaiDoiTuong = "Chỉnh sửa Danh mục phân quyền loại đối tượng",
                IDDanhMucPhanQuyen = ((DataRowView)bsLoaiDoiTuong.Current).Row["IDDanhMucPhanQuyen"],
                dataRow = ((DataRowView)bsLoaiDoiTuong.Current).Row,
            };
            frmDanhMucPhanQuyenLoaiDoiTuongUpdate.ShowDialog();
            frmDanhMucPhanQuyenLoaiDoiTuongUpdate.Dispose();
        }
        protected override void DeleteChiTiet()
        {
            //switch (tabChiTiet.SelectedTab.Key.ToUpper())
            //{
            //    case "TABCHITIET":
            //        if (ugChiTiet.ActiveRow != null && ugChiTiet.ActiveRow.IsDataRow)
            //        {
            //            deleteAction = new Action(() => { coreUI.DanhMuc.Delete(null, new Func<bool>(() => DanhMucPhanQuyenDonViBUS.Delete(new DanhMucPhanQuyenDonVi() { ID = ugChiTiet.ActiveRow.Cells["ID"].Value })), ugChiTiet, bsDataChiTiet); });
            //            base.Delete();
            //        }
            //        break;
            //    case "TABLOAIDOITUONG":
            //        if (ugLoaiDoiTuong.ActiveRow != null && ugLoaiDoiTuong.ActiveRow.IsDataRow)
            //        {
            //            deleteAction = new Action(() => { coreUI.DanhMuc.Delete(null, new Func<bool>(() => DanhMucPhanQuyenLoaiDoiTuongBUS.Delete(new DanhMucPhanQuyenLoaiDoiTuong() { ID = ugLoaiDoiTuong.ActiveRow.Cells["ID"].Value })), ugLoaiDoiTuong, bsLoaiDoiTuong); });
            //            base.Delete();
            //        }
            //        break;
            //    case "TABCHUNGTU":
            //        if (ugChungTu.ActiveRow != null && ugChungTu.ActiveRow.IsDataRow)
            //        {
            //            deleteAction = new Action(() => { coreUI.DanhMuc.Delete(null, new Func<bool>(() => DanhMucPhanQuyenChungTuBUS.Delete(new DanhMucPhanQuyenChungTu() { ID = ugChungTu.ActiveRow.Cells["ID"].Value })), ugChungTu, bsChungTu); });
            //            base.Delete();
            //        }
            //        break;
            //    case "TABBAOCAO":
            //        if (ugBaoCao.ActiveRow != null && ugBaoCao.ActiveRow.IsDataRow)
            //        {
            //            deleteAction = new Action(() => { coreUI.DanhMuc.Delete(null, new Func<bool>(() => DanhMucPhanQuyenBaoCaoBUS.Delete(new DanhMucPhanQuyenBaoCao() { ID = ugBaoCao.ActiveRow.Cells["ID"].Value })), ugBaoCao, bsBaoCao); });
            //            base.Delete();
            //        }
            //        break;
            //}
        }
    }
}
