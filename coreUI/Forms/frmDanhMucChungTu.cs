using coreBUS;
using coreCommon;
using coreDTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace coreUI.Forms
{
    public partial class frmDanhMucChungTu : coreBase.BaseForms.frmBaseDanhMucChiTiet
    {
        BindingSource bsChungTuIn = null, bsChungTuQuyTrinh = null;
        public frmDanhMucChungTu()
        {
            InitializeComponent();
        }
        protected override void List()
        {

            dsData = DanhMucChungTuBUS.List(null);

            bsDanhMuc = new BindingSource
            {
                DataSource = dsData,
                DataMember = DanhMucChungTu.tableName
            };

            bsDanhMucChiTiet = new BindingSource
            {
                DataSource = bsDanhMuc,
                DataMember = GlobalVariables.prefix_DataRelation + DanhMucChungTuTrangThai.tableName
            };

            bsChungTuIn = new BindingSource
            {
                DataSource = bsDanhMuc,
                DataMember = GlobalVariables.prefix_DataRelation + DanhMucChungTuIn.tableName
            };

            bsChungTuQuyTrinh = new BindingSource
            {
                DataSource = bsDanhMuc,
                DataMember = GlobalVariables.prefix_DataRelation + DanhMucChungTuQuyTrinh.tableName
            };

            ug.DataSource = bsDanhMuc;
            ugChiTiet.DataSource = bsDanhMucChiTiet;
            ugChungTuIn.DataSource = bsChungTuIn;
            ugChungTuQuyTrinh.DataSource = bsChungTuQuyTrinh;

            tabChiTiet.Tabs["tabChiTiet"].Text = coreCommon.coreCommon.TraTuDien(DanhMucChungTuTrangThai.tableName);
            tabChiTiet.Tabs["tabChungTuIn"].Text = coreCommon.coreCommon.TraTuDien(DanhMucChungTuIn.tableName);
            tabChiTiet.Tabs["tabChungTuQuyTrinh"].Text = coreCommon.coreCommon.TraTuDien(DanhMucChungTuQuyTrinh.tableName);

            //ug.DisplayLayout.Bands[0].PerformAutoResizeColumns(true, PerformAutoSizeType.AllRowsInBand);
            //ugChiTiet.DisplayLayout.Bands[0].PerformAutoResizeColumns(true, PerformAutoSizeType.AllRowsInBand);
            //ugChungTuIn.DisplayLayout.Bands[0].PerformAutoResizeColumns(true, PerformAutoSizeType.AllRowsInBand);
            //ugChungTuQuyTrinh.DisplayLayout.Bands[0].PerformAutoResizeColumns(true, PerformAutoSizeType.AllRowsInBand);
        }

        protected override void InsertDanhMuc()
        {
            base.InsertDanhMuc();
            if (!bContinue) return;
            frmDanhMucChungTuUpdate frmUpdate = new frmDanhMucChungTuUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Them,
                Text = "Thêm mới danh mục chứng từ",
                dataTable = dsData.Tables[DanhMucChungTu.tableName],
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void CopyDanhMuc()
        {
            base.CopyDanhMuc();
            if (!bContinue) return;
            frmDanhMucChungTuUpdate frmUpdate = new frmDanhMucChungTuUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                Text = "Sao chép danh mục chứng từ",
                dataTable = dsData.Tables[DanhMucChungTu.tableName],
                dataRow = ((DataRowView)bsDanhMuc.Current).Row
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void UpdateDanhMuc()
        {
            base.UpdateDanhMuc();
            if (!bContinue) return;
            frmDanhMucChungTuUpdate frmUpdate = new frmDanhMucChungTuUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                Text = "Chỉnh sửa danh mục chứng từ",
                dataTable = dsData.Tables[DanhMucChungTu.tableName],
                dataRow = ((DataRowView)bsDanhMuc.Current).Row
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void DeleteDanhMuc()
        {
            if (ug.ActiveRow != null && ug.ActiveRow.IsDataRow)
            {
                deleteAction = new Action(() => { coreUI.DanhMuc.Delete(null, new Func<bool>(() => DanhMucChungTuBUS.Delete(new DanhMucChungTu() { ID = ug.ActiveRow.Cells["ID"].Value })), ug, bsDanhMuc); });
                base.DeleteDanhMuc();
            }
        }

        protected override void InsertDanhMucChiTiet()
        {
            base.InsertDanhMucChiTiet();
            if (!bContinue) return;

            switch (tabChiTiet.SelectedTab.Key.ToUpper())
            {
                case "TABCHITIET":
                    frmDanhMucChungTuTrangThaiUpdate frmDanhMucChungTuTrangThaiUpdate = new frmDanhMucChungTuTrangThaiUpdate
                    {
                        CapNhat = coreCommon.ThaoTacDuLieu.Them,
                        Text = "Thêm mới danh mục chứng từ trạng thái",
                        dataTable = dsData.Tables[DanhMucChungTuTrangThai.tableName],
                        IDDanhMucChungTu = ((DataRowView)bsDanhMuc.Current).Row["ID"],
                    };
                    frmDanhMucChungTuTrangThaiUpdate.ShowDialog();
                    frmDanhMucChungTuTrangThaiUpdate.Dispose();
                    break;
                case "TABCHUNGTUIN":
                    frmDanhMucChungTuInUpdate frmDanhMucChungTuInUpdate = new frmDanhMucChungTuInUpdate
                    {
                        CapNhat = coreCommon.ThaoTacDuLieu.Them,
                        Text = "Thêm mới danh mục chứng từ in",
                        dataTable = dsData.Tables[DanhMucChungTuIn.tableName],
                        IDDanhMucChungTu = ((DataRowView)bsDanhMuc.Current).Row["ID"],
                    };
                    frmDanhMucChungTuInUpdate.ShowDialog();
                    frmDanhMucChungTuInUpdate.Dispose();
                    break;
                case "TABCHUNGTUQUYTRINH":
                    frmDanhMucChungTuQuyTrinhUpdate frmDanhMucChungTuQuyTrinhUpdate = new frmDanhMucChungTuQuyTrinhUpdate
                    {
                        CapNhat = coreCommon.ThaoTacDuLieu.Them,
                        Text = "Thêm mới danh mục chứng từ quy trình",
                        dataTable = dsData.Tables[DanhMucChungTuQuyTrinh.tableName],
                        IDDanhMucChungTu = ((DataRowView)bsDanhMuc.Current).Row["ID"],
                    };
                    frmDanhMucChungTuQuyTrinhUpdate.ShowDialog();
                    frmDanhMucChungTuQuyTrinhUpdate.Dispose();
                    break;
            }
        }
        protected override void UpdateDanhMucChiTiet()
        {
            base.UpdateDanhMucChiTiet();
            if (!bContinue) return;

            switch (tabChiTiet.SelectedTab.Key.ToUpper())
            {
                case "TABCHITIET":
                    if (ugChiTiet.ActiveRow == null || !ugChiTiet.ActiveRow.IsDataRow) return;
                    frmDanhMucChungTuTrangThaiUpdate frmDanhMucChungTuTrangThaiUpdate = new frmDanhMucChungTuTrangThaiUpdate
                    {
                        CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                        Text = "Chỉnh sửa danh mục chứng từ trạng thái",
                        IDDanhMucChungTu = ((DataRowView)bsDanhMucChiTiet.Current).Row["IDDanhMucChungTu"],
                        dataTable = dsData.Tables[DanhMucChungTuTrangThai.tableName],
                        dataRow = ((DataRowView)bsDanhMucChiTiet.Current).Row,
                    };
                    frmDanhMucChungTuTrangThaiUpdate.ShowDialog();
                    frmDanhMucChungTuTrangThaiUpdate.Dispose();
                    break;
                case "TABCHUNGTUIN":
                    if (ugChungTuIn.ActiveRow == null || !ugChungTuIn.ActiveRow.IsDataRow) return;
                    frmDanhMucChungTuInUpdate frmDanhMucChungTuInUpdate = new frmDanhMucChungTuInUpdate
                    {
                        CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                        Text = "Chỉnh sửa danh mục chứng từ in",
                        IDDanhMucChungTu = ((DataRowView)bsChungTuIn.Current).Row["IDDanhMucChungTu"],
                        dataTable = dsData.Tables[DanhMucChungTuIn.tableName],
                        dataRow = ((DataRowView)bsChungTuIn.Current).Row
                    };
                    frmDanhMucChungTuInUpdate.ShowDialog();
                    frmDanhMucChungTuInUpdate.Dispose();
                    break;
                case "TABCHUNGTUQUYTRINH":
                    if (ugChungTuQuyTrinh.ActiveRow == null || !ugChungTuQuyTrinh.ActiveRow.IsDataRow) return;
                    frmDanhMucChungTuQuyTrinhUpdate frmDanhMucChungTuQuyTrinhUpdate = new frmDanhMucChungTuQuyTrinhUpdate
                    {
                        CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                        Text = "Chỉnh sửa danh mục chứng từ quy trình",
                        IDDanhMucChungTu = ((DataRowView)bsChungTuQuyTrinh.Current).Row["IDDanhMucChungTu"],
                        dataTable = dsData.Tables[DanhMucChungTuQuyTrinh.tableName],
                        dataRow = ((DataRowView)bsChungTuQuyTrinh.Current).Row,
                    };
                    frmDanhMucChungTuQuyTrinhUpdate.ShowDialog();
                    frmDanhMucChungTuQuyTrinhUpdate.Dispose();
                    break;
            }
        }

        //private void ugChiTiet_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        //{
        //    base.UpdateDanhMucChiTiet();
        //    if (!bContinue) return;
        //    frmDanhMucChungTuTrangThaiUpdate frmDanhMucChungTuTrangThaiUpdate = new frmDanhMucChungTuTrangThaiUpdate
        //    {
        //        CapNhat = coreCommon.ThaoTacDuLieu.Sua,
        //        Text = "Chỉnh sửa danh mục chứng từ trạng thái",
        //        IDDanhMucChungTu = ((DataRowView)bsDanhMucChiTiet.Current).Row["IDDanhMucChungTu"],
        //        dataTable = dsData.Tables[DanhMucChungTuTrangThai.tableName],
        //        dataRow = ((DataRowView)bsDanhMucChiTiet.Current).Row,
        //    };
        //    frmDanhMucChungTuTrangThaiUpdate.ShowDialog();
        //    frmDanhMucChungTuTrangThaiUpdate.Dispose();
        //}
        private void ugChungTuQuyTrinh_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (ugChungTuQuyTrinh.ActiveRow == null || !ugChungTuQuyTrinh.ActiveRow.IsDataRow) return;
            frmDanhMucChungTuQuyTrinhUpdate frmDanhMucChungTuQuyTrinhUpdate = new frmDanhMucChungTuQuyTrinhUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                Text = "Chỉnh sửa danh mục chứng từ quy trình",
                IDDanhMucChungTu = ((DataRowView)bsChungTuQuyTrinh.Current).Row["IDDanhMucChungTu"],
                dataTable = dsData.Tables[DanhMucChungTuQuyTrinh.tableName],
                dataRow = ((DataRowView)bsChungTuQuyTrinh.Current).Row
            };
            frmDanhMucChungTuQuyTrinhUpdate.ShowDialog();
            frmDanhMucChungTuQuyTrinhUpdate.Dispose();
        }
        private void ugChungTuIn_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (ugChungTuIn.ActiveRow == null || !ugChungTuIn.ActiveRow.IsDataRow) return;
            frmDanhMucChungTuInUpdate frmDanhMucChungTuInUpdate = new frmDanhMucChungTuInUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                Text = "Chỉnh sửa danh mục chứng từ in",
                IDDanhMucChungTu = ((DataRowView)bsChungTuIn.Current).Row["IDDanhMucChungTu"],
                dataTable = dsData.Tables[DanhMucChungTuIn.tableName],
                dataRow = ((DataRowView)bsChungTuIn.Current).Row,
            };
            frmDanhMucChungTuInUpdate.ShowDialog();
            frmDanhMucChungTuInUpdate.Dispose();
        }

        protected override void DeleteDanhMucChiTiet()
        {
            switch (tabChiTiet.SelectedTab.Key.ToUpper())
            {
                case "TABCHITIET":
                    if (ugChiTiet.ActiveRow != null && ugChiTiet.ActiveRow.IsDataRow)
                    {
                        deleteAction = new Action(() => { coreUI.DanhMuc.Delete(null, new Func<bool>(() => DanhMucChungTuTrangThaiBUS.Delete(new DanhMucChungTuTrangThai() { ID = ugChiTiet.ActiveRow.Cells["ID"].Value })), ugChiTiet, bsDanhMucChiTiet); });
                        base.DeleteDanhMuc();
                    }
                    break;
                case "TABCHUNGTUIN":
                    if (ugChungTuIn.ActiveRow != null && ugChungTuIn.ActiveRow.IsDataRow)
                    {
                        deleteAction = new Action(() => { coreUI.DanhMuc.Delete(null, new Func<bool>(() => DanhMucChungTuInBUS.Delete(new DanhMucChungTuIn() { ID = ugChungTuIn.ActiveRow.Cells["ID"].Value })), ugChungTuIn, bsChungTuIn); });
                        base.DeleteDanhMuc();
                    }
                    break;
                case "TABCHUNGTUQUYTRINH":
                    if (ugChungTuQuyTrinh.ActiveRow != null && ugChungTuQuyTrinh.ActiveRow.IsDataRow)
                    {
                        deleteAction = new Action(() => { coreUI.DanhMuc.Delete(null, new Func<bool>(() => DanhMucChungTuQuyTrinhBUS.Delete(new DanhMucChungTuQuyTrinh() { ID = ugChungTuQuyTrinh.ActiveRow.Cells["ID"].Value })), ugChungTuQuyTrinh, bsChungTuQuyTrinh); });
                        base.DeleteDanhMuc();
                    }
                    break;
            }
        }
    }
}
