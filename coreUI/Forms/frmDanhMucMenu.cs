﻿using coreBUS;
using coreCommon;
using coreDTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace coreUI.Forms
{
    public partial class frmDanhMucMenu : coreBase.BaseForms.frmBaseDanhMucChiTiet
    {
        BindingSource bsChungTu = null, bsBaoCao = null;
        public frmDanhMucMenu()
        {
            InitializeComponent();
        }
        protected override void List()
        {
            dsData = DanhMucMenuBUS.List(null);

            bsDanhMuc = new BindingSource
            {
                DataSource = dsData,
                DataMember = DanhMucMenu.tableName
            };

            bsDanhMucChiTiet = new BindingSource
            {
                DataSource = bsDanhMuc,
                DataMember = GlobalVariables.prefix_DataRelation + DanhMucMenuLoaiDoiTuong.tableName
            };

            bsChungTu = new BindingSource
            {
                DataSource = bsDanhMuc,
                DataMember = GlobalVariables.prefix_DataRelation + DanhMucMenuChungTu.tableName
            };

            bsBaoCao = new BindingSource
            {
                DataSource = bsDanhMuc,
                DataMember = GlobalVariables.prefix_DataRelation + DanhMucMenuBaoCao.tableName
            };

            ug.DataSource = bsDanhMuc;
            ugChiTiet.DataSource = bsDanhMucChiTiet;
            ugChungTu.DataSource = bsChungTu;
            ugBaoCao.DataSource = bsBaoCao;

            tabChiTiet.Tabs["tabChiTiet"].Text = coreCommon.coreCommon.TraTuDien(DanhMucMenuLoaiDoiTuong.tableName);
            tabChiTiet.Tabs["tabChungTu"].Text = coreCommon.coreCommon.TraTuDien(DanhMucMenuChungTu.tableName);
            tabChiTiet.Tabs["tabBaoCao"].Text = coreCommon.coreCommon.TraTuDien(DanhMucMenuBaoCao.tableName);
        }

        protected override void InsertDanhMuc()
        {
            base.InsertDanhMuc();
            if (!bContinue) return;
            frmDanhMucMenuUpdate frmUpdate = new frmDanhMucMenuUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Them,
                dataTable = dsData.Tables[DanhMucMenu.tableName],
                Text = "Thêm mới danh mục menu",
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void CopyDanhMuc()
        {
            base.CopyDanhMuc();
            if (!bContinue) return;
            frmDanhMucMenuUpdate frmUpdate = new frmDanhMucMenuUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                Text = "Sao chép danh mục menu",
                dataTable = dsData.Tables[DanhMucMenu.tableName],
                dataRow = ((DataRowView)bsDanhMuc.Current).Row
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void UpdateDanhMuc()
        {
            base.UpdateDanhMuc();
            if (!bContinue) return;
            frmDanhMucMenuUpdate frmUpdate = new frmDanhMucMenuUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                Text = "Chỉnh sửa danh mục menu",
                dataTable = dsData.Tables[DanhMucMenu.tableName],
                dataRow = ((DataRowView)bsDanhMuc.Current).Row
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void DeleteDanhMuc()
        {
            if (ug.ActiveRow != null && ug.ActiveRow.IsDataRow)
            {
                deleteAction = new Action(() => { coreUI.DanhMuc.Delete(null, new Func<bool>(() => DanhMucMenuBUS.Delete(new DanhMucMenu() { ID = ug.ActiveRow.Cells["ID"].Value })), ug, bsDanhMuc); });
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
                    frmDanhMucMenuLoaiDoiTuongUpdate frmDanhMucMenuLoaiDoiTuongUpdate = new frmDanhMucMenuLoaiDoiTuongUpdate
                    {
                        CapNhat = coreCommon.ThaoTacDuLieu.Them,
                        Text = "Thêm mới danh mục menu loại đối tượng",
                        dataTable = dsData.Tables[DanhMucMenuLoaiDoiTuong.tableName],
                        IDDanhMucMenu = ((DataRowView)bsDanhMuc.Current).Row["ID"],
                    };
                    frmDanhMucMenuLoaiDoiTuongUpdate.ShowDialog();
                    frmDanhMucMenuLoaiDoiTuongUpdate.Dispose();
                    break;
                case "TABCHUNGTU":
                    frmDanhMucMenuChungTuUpdate frmDanhMucMenuChungTuUpdate = new frmDanhMucMenuChungTuUpdate
                    {
                        CapNhat = coreCommon.ThaoTacDuLieu.Them,
                        Text = "Thêm mới danh mục menu loại chứng từ",
                        dataTable = dsData.Tables[DanhMucMenuChungTu.tableName],
                        IDDanhMucMenu = ((DataRowView)bsDanhMuc.Current).Row["ID"],
                    };
                    frmDanhMucMenuChungTuUpdate.ShowDialog();
                    frmDanhMucMenuChungTuUpdate.Dispose();
                    break;
                case "TABBAOCAO":
                    frmDanhMucMenuBaoCaoUpdate frmDanhMucMenuBaoCaoUpdate = new frmDanhMucMenuBaoCaoUpdate
                    {
                        CapNhat = coreCommon.ThaoTacDuLieu.Them,
                        Text = "Thêm mới danh mục menu báo cáo",
                        dataTable = dsData.Tables[DanhMucMenuBaoCao.tableName],
                        IDDanhMucMenu = ((DataRowView)bsDanhMuc.Current).Row["ID"],
                    };
                    frmDanhMucMenuBaoCaoUpdate.ShowDialog();
                    frmDanhMucMenuBaoCaoUpdate.Dispose();
                    break;
            }
        }


        protected override void UpdateDanhMucChiTiet()
        {
            //base.UpdateDanhMucChiTiet();
            //if (!bContinue) return;
            switch (tabChiTiet.SelectedTab.Key.ToUpper())
            {
                case "TABCHITIET":
                    frmDanhMucMenuLoaiDoiTuongUpdate frmDanhMucMenuLoaiDoiTuongUpdate = new frmDanhMucMenuLoaiDoiTuongUpdate
                    {
                        CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                        Text = "Chỉnh sửa danh mục menu loại đối tượng",
                        IDDanhMucMenu = ((DataRowView)bsDanhMucChiTiet.Current).Row["IDDanhMucMenu"],
                        dataTable = dsData.Tables[DanhMucMenuLoaiDoiTuong.tableName],
                        dataRow = ((DataRowView)bsDanhMucChiTiet.Current).Row,
                    };
                    frmDanhMucMenuLoaiDoiTuongUpdate.ShowDialog();
                    frmDanhMucMenuLoaiDoiTuongUpdate.Dispose();
                    break;
                case "TABCHUNGTU":
                    frmDanhMucMenuChungTuUpdate frmDanhMucMenuChungTuUpdate = new frmDanhMucMenuChungTuUpdate
                    {
                        CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                        Text = "Chỉnh sửa danh mục menu chứng từ",
                        IDDanhMucMenu = ((DataRowView)bsChungTu.Current).Row["IDDanhMucMenu"],
                        dataTable = dsData.Tables[DanhMucMenuChungTu.tableName],
                        dataRow = ((DataRowView)bsChungTu.Current).Row,
                    };
                    frmDanhMucMenuChungTuUpdate.ShowDialog();
                    frmDanhMucMenuChungTuUpdate.Dispose();
                    break;
                case "TABBAOCAO":
                    frmDanhMucMenuBaoCaoUpdate frmDanhMucMenuBaoCaoUpdate = new frmDanhMucMenuBaoCaoUpdate
                    {
                        CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                        Text = "Chỉnh sửa danh mục menu loại báo cáo",
                        IDDanhMucMenu = ((DataRowView)bsBaoCao.Current).Row["IDDanhMucMenu"],
                        dataTable = dsData.Tables[DanhMucMenuBaoCao.tableName],
                        dataRow = ((DataRowView)bsBaoCao.Current).Row,
                    };
                    frmDanhMucMenuBaoCaoUpdate.ShowDialog();
                    frmDanhMucMenuBaoCaoUpdate.Dispose();
                    break;
            }
        }

        protected override void DeleteDanhMucChiTiet()
        {
            switch (tabChiTiet.SelectedTab.Key.ToUpper())
            {
                case "TABCHITIET":
                    if (ugChiTiet.ActiveRow != null && ugChiTiet.ActiveRow.IsDataRow)
                    {
                        deleteAction = new Action(() => { coreUI.DanhMuc.Delete(null, new Func<bool>(() => DanhMucMenuLoaiDoiTuongBUS.Delete(new DanhMucMenuLoaiDoiTuong() { ID = ugChiTiet.ActiveRow.Cells["ID"].Value })), ugChiTiet, bsDanhMucChiTiet); });
                        base.DeleteDanhMuc();
                    }
                    break;
                case "TABCHUNGTU":
                    if (ugChungTu.ActiveRow != null && ugChungTu.ActiveRow.IsDataRow)
                    {
                        deleteAction = new Action(() => { coreUI.DanhMuc.Delete(null, new Func<bool>(() => DanhMucMenuChungTuBUS.Delete(new DanhMucMenuChungTu() { ID = ugChungTu.ActiveRow.Cells["ID"].Value })), ugChungTu, bsChungTu); });
                        base.DeleteDanhMuc();
                    }
                    break;
                case "TABBAOCAO":
                    if (ugBaoCao.ActiveRow != null && ugBaoCao.ActiveRow.IsDataRow)
                    {
                        deleteAction = new Action(() => { coreUI.DanhMuc.Delete(null, new Func<bool>(() => DanhMucMenuBaoCaoBUS.Delete(new DanhMucMenuBaoCao() { ID = ugBaoCao.ActiveRow.Cells["ID"].Value })), ugBaoCao, bsBaoCao); });
                        base.DeleteDanhMuc();
                    }
                    break;
            }
        }

        private void ugBaoCao_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (ugBaoCao.ActiveRow == null || !ugBaoCao.ActiveRow.IsDataRow) return;
            frmDanhMucMenuBaoCaoUpdate frmDanhMucMenuBaoCaoUpdate = new frmDanhMucMenuBaoCaoUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                Text = "Chỉnh sửa danh mục menu báo cáo",
                IDDanhMucMenu = ((DataRowView)bsBaoCao.Current).Row["IDDanhMucMenu"],
                dataTable = dsData.Tables[DanhMucMenuBaoCao.tableName],
                dataRow = ((DataRowView)bsBaoCao.Current).Row,
            };
            frmDanhMucMenuBaoCaoUpdate.ShowDialog();
            frmDanhMucMenuBaoCaoUpdate.Dispose();
        }

        //private void ugChiTiet_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        //{
        //    if (ugChiTiet.ActiveRow == null || !ugChiTiet.ActiveRow.IsDataRow) return;
        //    frmDanhMucMenuLoaiDoiTuongUpdate frmDanhMucMenuLoaiDoiTuongUpdate = new frmDanhMucMenuLoaiDoiTuongUpdate
        //    {
        //        CapNhat = coreCommon.ThaoTacDuLieu.Sua,
        //        Text = "Chỉnh sửa danh mục menu loại đối tượng",
        //        IDDanhMucMenu = ((DataRowView)bsDanhMucChiTiet.Current).Row["IDDanhMucMenu"],
        //        dataTable = dsData.Tables[DanhMucMenuLoaiDoiTuong.tableName],
        //        dataRow = ((DataRowView)bsDanhMucChiTiet.Current).Row,
        //    };
        //    frmDanhMucMenuLoaiDoiTuongUpdate.ShowDialog();
        //    frmDanhMucMenuLoaiDoiTuongUpdate.Dispose();
        //}

        private void ugChungTu_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (ugChungTu.ActiveRow == null || !ugChungTu.ActiveRow.IsDataRow) return;
            frmDanhMucMenuChungTuUpdate frmDanhMucMenuChungTuUpdate = new frmDanhMucMenuChungTuUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                Text = "Chỉnh sửa danh mục menu chứng tù",
                IDDanhMucMenu = ((DataRowView)bsChungTu.Current).Row["IDDanhMucMenu"],
                dataTable = dsData.Tables[DanhMucMenuChungTu.tableName],
                dataRow = ((DataRowView)bsChungTu.Current).Row,
            };
            frmDanhMucMenuChungTuUpdate.ShowDialog();
            frmDanhMucMenuChungTuUpdate.Dispose();
        }
    }
}
