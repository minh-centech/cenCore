using coreBase.Forms;
using coreBUS;
using coreDTO;
using coreUI.Forms;
using Infragistics.Win.UltraWinToolbars;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
namespace coreUI.Forms
{
    public partial class frmMain : Form
    {
        public Action runCustomMenu;
        public string LoaiChucNang = string.Empty, TenChucNang = string.Empty, FormCaption = string.Empty;
        public List<string[]> listLoaiManHinh;
        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            //Load file giao diện từ app.config
            if (File.Exists(Application.StartupPath + "\\Office2007Blue.isl"))
            {
                Infragistics.Win.AppStyling.StyleManager.Load(Application.StartupPath + "\\Office2007Blue.isl");
            }
            frmLogin frmLogin = new frmLogin();
            frmLogin.listLoaiManHinh = listLoaiManHinh;
            frmLogin.ShowDialog();
            if (!frmLogin.OK)
            {
                Application.Exit();
                return;
            }
            coreCommon.GlobalVariables.Logged = true;
            if (coreCommon.GlobalVariables.Logged)
            {
                this.Text = coreCommon.GlobalVariables.SolutionName;
                //Tạo folder output nếu chưa có
                if (!Directory.Exists(coreCommon.GlobalVariables.OutputDir))
                    Directory.CreateDirectory(coreCommon.GlobalVariables.OutputDir);
                //Disable menu quản trị nếu không phải người dùng quản trị
                PopupMenuTool mnuHeThong = (PopupMenuTool)this.ultraToolbarsManager1.Toolbars[0].Tools["mnuHeThong"];
                mnuHeThong.Tools["_sys_DanhMucQuanTri"].SharedProps.Enabled = coreCommon.GlobalVariables.isAdmin;
                //Nạp danh mục từ điển
                coreCommon.GlobalVariables.dtTuDien = new DataTable();
                coreCommon.GlobalVariables.dtTuDien = DanhMucTuDienBUS.List(null);
                LoadMenu();
                //InitParameters();
                frmDesktop frmDesktop = new frmDesktop
                {
                    MdiParent = this
                };
                frmDesktop.Show();
                //Hiển thị trạng thái
                this.ultraStatusBar1.Panels["sttTenDuLieu"].Text = "Dữ liệu: " + coreCommon.GlobalVariables.TenDuLieu;
                this.ultraStatusBar1.Panels["sttTenDonVi"].Text = "Đơn vị: " + coreCommon.GlobalVariables.TenDonVi;
                this.ultraStatusBar1.Panels["sttTenDanhMucNguoiSuDung"].Text = "User: " + coreCommon.GlobalVariables.MaDanhMucNguoiSuDung;
            }
        }
        public void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            LoaiChucNang = e.Tool.Key.ToUpper();
            TenChucNang = e.Tool.Key.Substring(5);
            FormCaption = e.Tool.SharedProps.Caption;

            switch (LoaiChucNang)
            {
                case "_SYS_DANHMUCDONVI": //Các chức năng quản trị, hệ thống
                    frmDanhMucDonVi frmDanhMucDonVi = new frmDanhMucDonVi
                    {
                        Text = coreCommon.coreCommon.TraTuDien(TenChucNang),
                        MdiParent = this
                    };
                    frmDanhMucDonVi.Show();
                    break;
                case "_SYS_DANHMUCCHUNGTU": //Các chức năng quản trị, hệ thống
                    frmDanhMucChungTu frmDanhMucChungTu = new frmDanhMucChungTu
                    {
                        Text = coreCommon.coreCommon.TraTuDien(TenChucNang),
                        MdiParent = this
                    };
                    frmDanhMucChungTu.Show();
                    break;
                case "_SYS_DANHMUCLOAIDOITUONG": //Các chức năng quản trị, hệ thống
                    frmDanhMucLoaiDoiTuong frmDanhMucLoaiDoiTuong = new frmDanhMucLoaiDoiTuong
                    {
                        Text = coreCommon.coreCommon.TraTuDien(TenChucNang),
                        MdiParent = this
                    };
                    frmDanhMucLoaiDoiTuong.Show();
                    break;
                case "_SYS_DANHMUCNHOMBAOCAO": //Các chức năng quản trị, hệ thống
                    frmDanhMucNhomBaoCao frmDanhMucNhomBaoCao = new frmDanhMucNhomBaoCao
                    {
                        Text = coreCommon.coreCommon.TraTuDien(TenChucNang),
                        MdiParent = this
                    };
                    frmDanhMucNhomBaoCao.Show();
                    break;
                case "_SYS_DANHMUCBAOCAO": //Các chức năng quản trị, hệ thống
                    frmDanhMucBaoCao frmDanhMucBaoCao = new frmDanhMucBaoCao
                    {
                        Text = coreCommon.coreCommon.TraTuDien(TenChucNang),
                        MdiParent = this
                    };
                    frmDanhMucBaoCao.Show();
                    break;
                case "_SYS_DANHMUCPHANQUYEN": //Các chức năng quản trị, hệ thống
                    frmDanhMucPhanQuyen frmDanhMucPhanQuyen = new frmDanhMucPhanQuyen
                    {
                        Text = coreCommon.coreCommon.TraTuDien(TenChucNang),
                        MdiParent = this
                    };
                    frmDanhMucPhanQuyen.Show();
                    break;
                case "_SYS_DANHMUCMENU": //Các chức năng quản trị, hệ thống
                    frmDanhMucMenu frmDanhMucMenu = new frmDanhMucMenu
                    {
                        Text = coreCommon.coreCommon.TraTuDien(TenChucNang),
                        MdiParent = this
                    };
                    frmDanhMucMenu.Show();
                    break;
                case "_SYS_DANHMUCTUDIEN": //Các chức năng quản trị, hệ thống
                    frmDanhMucTuDien frmDanhMucTuDien = new frmDanhMucTuDien
                    {
                        Text = coreCommon.coreCommon.TraTuDien(TenChucNang),
                        MdiParent = this
                    };
                    frmDanhMucTuDien.Show();
                    break;
                case "_SYS_DANHMUCTHAMSOHETHONG": //Các chức năng quản trị, hệ thống
                    frmDanhMucThamSoHeThong frmDanhMucThamSoHeThong = new frmDanhMucThamSoHeThong
                    {
                        Text = coreCommon.coreCommon.TraTuDien(TenChucNang),
                        MdiParent = this
                    };
                    frmDanhMucThamSoHeThong.Show();
                    break;
                case "_SYS_DANHMUCNGUOISUDUNG": //Các chức năng quản trị, hệ thống
                    frmDanhMucNguoiSuDung frmDanhMucNguoiSuDung = new frmDanhMucNguoiSuDung
                    {
                        Text = coreCommon.coreCommon.TraTuDien(TenChucNang),
                        MdiParent = this
                    };
                    frmDanhMucNguoiSuDung.Show();
                    break;
                case "_SYS_DANHMUCTHAMSONGUOISUDUNG": //Các chức năng quản trị, hệ thống
                    frmDanhMucThamSoNguoiSuDung frmDanhMucThamSoNguoiSuDung = new frmDanhMucThamSoNguoiSuDung
                    {
                        Text = coreCommon.coreCommon.TraTuDien(TenChucNang),
                        MdiParent = this
                    };
                    frmDanhMucThamSoNguoiSuDung.Show();
                    break;
                case "_SYS_THAYDOIMATKHAU": //Các chức năng quản trị, hệ thống
                    frmChangePassword frmChangePassword = new frmChangePassword();
                    frmChangePassword.ShowDialog();
                    break;
                case "_SYS_NHATKYDULIEU": //Các chức năng quản trị, hệ thống
                    frmNhatKyDuLieu frmNhatKyDuLieu = new frmNhatKyDuLieu()
                    {
                        Text = "Nhật ký dữ liệu",
                        MdiParent = this
                    };
                    frmNhatKyDuLieu.Show();
                    break;
                case "_SYS_DANGXUAT": //Đăng xuất
                    Application.Exit();
                    Application.Restart();
                    break;
                case "_SYS_THOAT": //Các chức năng quản trị, hệ thống
                    Application.Exit();
                    break;
                default:
                    runCustomMenu();
                    break;
            }
        }
        public void LoadMenu()
        {
            Boolean CoChungTu = false;

            DataSet dsMenu = DanhMucMenuBUS.List(null);

            if (dsMenu == null) return;

            //Load menu các phân hệ
            foreach (DataRow drMenu in dsMenu.Tables[DanhMucMenu.tableName].Rows)
            {
                Int32 OrderNo = 1;
                PopupMenuTool pmtPhanHe = new PopupMenuTool("_div_" + drMenu["ID"].ToString());
                pmtPhanHe.SharedProps.Caption = drMenu["Ten"].ToString();
                pmtPhanHe.SharedProps.DisplayStyle = ToolDisplayStyle.ImageAndText;
                //pmtPhanHe.SharedProps.AppearancesSmall.Appearance.Image = coreCommon.GlobalVariables.ImageFromByte((Byte[])drMenu["Anh"]);
                //pmtPhanHe.SharedProps.AppearancesLarge.Appearance.Image = coreCommon.GlobalVariables.ImageFromByte((Byte[])drMenu["Anh"]);
                this.ultraToolbarsManager1.Tools.Add(pmtPhanHe);
                this.ultraToolbarsManager1.Toolbars[0].Tools.AddTool(pmtPhanHe.Key);
                OrderNo += 1;
                //Add các button là chứng từ
                foreach (DataRow drChungTu in dsMenu.Tables[DanhMucMenuChungTu.tableName].Rows)
                {
                    if (drChungTu["IDDanhMucMenu"].ToString() == drMenu["ID"].ToString())
                    {
                        ButtonTool btChungTu = new ButtonTool("_dct_" + drChungTu["IDDanhMucChungTu"].ToString() + "ID:" + drChungTu["ID"].ToString() + "MA:" + drChungTu["MaDanhMucChungTu"].ToString() + "LOAIMANHINH:" + drChungTu["LoaiManHinh"].ToString());
                        //ButtonTool btChungTu = new ButtonTool("_dct_" + drChungTu["ID"].ToString() + "_IDDanhMuc" + drChungTu["IDDanhMucChungTu"].ToString());
                        //if (drChungTu["Anh"] != DBNull.Value)
                        //    btChungTu.SharedProps.AppearancesSmall.Appearance.Image = coreCommon.GlobalVariables.ImageFromByte((Byte[])drChungTu["Anh"]);
                        btChungTu.SharedProps.Caption = drChungTu["NoiDungHienThi"].ToString();
                        this.ultraToolbarsManager1.Tools.Add(btChungTu);
                        pmtPhanHe.Tools.AddTool(btChungTu.Key);
                        pmtPhanHe.Tools[btChungTu.Key].InstanceProps.IsFirstInGroup = coreCommon.coreCommon.stringParseBoolean(drChungTu["PhanCachNhom"].ToString());
                    }
                }
                //Add các button là danh mục
                foreach (DataRow drDanhMuc in dsMenu.Tables[DanhMucMenuLoaiDoiTuong.tableName].Rows)
                {
                    if (drDanhMuc["IDDanhMucMenu"].ToString() == drMenu["ID"].ToString())
                    {
                        ButtonTool btDanhMuc = new ButtonTool("_ddm_" + drDanhMuc["IDDanhMucLoaiDoiTuong"].ToString() + "ID:" + drDanhMuc["ID"].ToString());
                        //if (drDanhMuc["Anh"] != DBNull.Value)
                        //    btDanhMuc.SharedProps.AppearancesSmall.Appearance.Image = coreCommon.GlobalVariables.ImageFromByte((Byte[])drDanhMuc["Anh"]);
                        btDanhMuc.SharedProps.Caption = drDanhMuc["NoiDungHienThi"].ToString();
                        this.ultraToolbarsManager1.Tools.Add(btDanhMuc);
                        pmtPhanHe.Tools.AddTool(btDanhMuc.Key);
                        pmtPhanHe.Tools[btDanhMuc.Key].InstanceProps.IsFirstInGroup = coreCommon.coreCommon.stringParseBoolean(drDanhMuc["PhanCachNhom"].ToString());
                    }
                }
                //Add các button là báo cáo
                foreach (DataRow drBaoCao in dsMenu.Tables[DanhMucMenuBaoCao.tableName].Rows)
                {

                    if (drBaoCao["IDDanhMucMenu"].ToString() == drMenu["ID"].ToString())
                    {
                        if (drBaoCao["IDDanhMucNhomBaoCao"] != DBNull.Value && !pmtPhanHe.Tools.Exists("_ref_" + drBaoCao["IDDanhMucNhomBaoCao"].ToString() + "_" + drMenu["ID"].ToString()))
                        {
                            //Nếu nhóm báo cáo khác null thì add group tương ứng với nhóm
                            PopupMenuTool pmtBaoCao = new PopupMenuTool("_ref_" + drBaoCao["IDDanhMucNhomBaoCao"].ToString() + "_" + drMenu["ID"].ToString());
                            pmtBaoCao.SharedProps.Caption = drBaoCao["TenDanhMucNhomBaoCao"].ToString();
                            this.ultraToolbarsManager1.Tools.Add(pmtBaoCao);
                            pmtPhanHe.Tools.AddTool(pmtBaoCao.Key);
                            pmtPhanHe.Tools[pmtBaoCao.Key].InstanceProps.IsFirstInGroup = coreCommon.coreCommon.stringParseBoolean(drBaoCao["PhanCachNhom"].ToString());

                        }
                        ButtonTool btBaoCao = new ButtonTool("_dbc_" + drBaoCao["IDDanhMucBaoCao"].ToString() + "ID:" + drBaoCao["ID"].ToString());
                        btBaoCao.SharedProps.Caption = drBaoCao["TenDanhMucBaoCao"].ToString();
                        this.ultraToolbarsManager1.Tools.Add(btBaoCao);
                        PopupMenuTool ppBaoCao = (PopupMenuTool)pmtPhanHe.Tools["_ref_" + drBaoCao["IDDanhMucNhomBaoCao"].ToString() + "_" + drMenu["ID"].ToString()];
                        ppBaoCao.Tools.AddTool(btBaoCao.Key);
                    }
                }
            }
        }
        /// <summary>
        /// Load giá trị tham số hệ thống khi chạy chương trình
        /// </summary>
        public static void InitParameters()
        {
            //DanhMucBUS _DanhMucBUS = new DanhMucBUS();
            //coreCommon.GlobalVariables.TenCotNgayThang = _DanhMucBUS.GetGiaTriThamSoHeThong(coreCommon.ThamSoHeThong.MaThamSoTenCotNgayThang);
            //coreCommon.GlobalVariables.TenCotThoiGian = _DanhMucBUS.GetGiaTriThamSoHeThong(coreCommon.ThamSoHeThong.MaThamSoTenCotThoiGian);
            //coreCommon.GlobalVariables.TenCotSoLuong = _DanhMucBUS.GetGiaTriThamSoHeThong(coreCommon.ThamSoHeThong.MaThamSoTenCotSoLuong);
            //coreCommon.GlobalVariables.TenCotKhoiLuong = _DanhMucBUS.GetGiaTriThamSoHeThong(coreCommon.ThamSoHeThong.MaThamSoTenCotKhoiLuong);
            //coreCommon.GlobalVariables.TenCotTrongLuong = _DanhMucBUS.GetGiaTriThamSoHeThong(coreCommon.ThamSoHeThong.MaThamSoTenCotTrongLuong);
            //coreCommon.GlobalVariables.TenCotTien = _DanhMucBUS.GetGiaTriThamSoHeThong(coreCommon.ThamSoHeThong.MaThamSoTenCotSoTien);
            //coreCommon.GlobalVariables.TenCotGia = _DanhMucBUS.GetGiaTriThamSoHeThong(coreCommon.ThamSoHeThong.MaThamSoTenCotDonGia);
            //coreCommon.GlobalVariables.TenCotMaSo = _DanhMucBUS.GetGiaTriThamSoHeThong(coreCommon.ThamSoHeThong.MaThamSoTenCotMaSo);
            //coreCommon.GlobalVariables.TenCotDienGiai = _DanhMucBUS.GetGiaTriThamSoHeThong(coreCommon.ThamSoHeThong.MaThamSoTenCotDienGiai);
            //coreCommon.GlobalVariables.TenCotDropdown = _DanhMucBUS.GetGiaTriThamSoHeThong(coreCommon.ThamSoHeThong.MaThamSoTenCotDropdown);

            //Int16.TryParse(_DanhMucBUS.GetGiaTriThamSoHeThong(coreCommon.ThamSoHeThong.MaThamSoDoRongCotNgayThangGrid), out coreCommon.GlobalVariables.DoRongCotNgayThangGrid);
            //Int16.TryParse(_DanhMucBUS.GetGiaTriThamSoHeThong(coreCommon.ThamSoHeThong.MaThamSoDoRongCotSoLuongGrid), out coreCommon.GlobalVariables.DoRongCotSoLuongGrid);
            //Int16.TryParse(_DanhMucBUS.GetGiaTriThamSoHeThong(coreCommon.ThamSoHeThong.MaThamSoDoRongCotKhoiLuongGrid), out coreCommon.GlobalVariables.DoRongCotKhoiLuongGrid);
            //Int16.TryParse(_DanhMucBUS.GetGiaTriThamSoHeThong(coreCommon.ThamSoHeThong.MaThamSoDoRongCotTrongLuongGrid), out coreCommon.GlobalVariables.DoRongCotTrongLuongGrid);
            //Int16.TryParse(_DanhMucBUS.GetGiaTriThamSoHeThong(coreCommon.ThamSoHeThong.MaThamSoDoRongCotSoTienGrid), out coreCommon.GlobalVariables.DoRongCotTienGrid);
            //Int16.TryParse(_DanhMucBUS.GetGiaTriThamSoHeThong(coreCommon.ThamSoHeThong.MaThamSoDoRongCotDonGiaGrid), out coreCommon.GlobalVariables.DoRongCotGiaGrid);
            //Int16.TryParse(_DanhMucBUS.GetGiaTriThamSoHeThong(coreCommon.ThamSoHeThong.MaThamSoDoRongCotMaSoGrid), out coreCommon.GlobalVariables.DoRongCotMaSoGrid);
            //Int16.TryParse(_DanhMucBUS.GetGiaTriThamSoHeThong(coreCommon.ThamSoHeThong.MaThamSoDoRongCotDienGiaiGrid), out coreCommon.GlobalVariables.DoRongCotDienGiaiGrid);

            //Double.TryParse(_DanhMucBUS.GetGiaTriThamSoHeThong(coreCommon.ThamSoHeThong.MaThamSoDoRongCotNgayThangReport), out coreCommon.GlobalVariables.DoRongCotNgayThangReport);
            //Double.TryParse(_DanhMucBUS.GetGiaTriThamSoHeThong(coreCommon.ThamSoHeThong.MaThamSoDoRongCotSoLuongReport), out coreCommon.GlobalVariables.DoRongCotSoLuongReport);
            //Double.TryParse(_DanhMucBUS.GetGiaTriThamSoHeThong(coreCommon.ThamSoHeThong.MaThamSoDoRongCotKhoiLuongReport), out coreCommon.GlobalVariables.DoRongCotKhoiLuongReport);
            //Double.TryParse(_DanhMucBUS.GetGiaTriThamSoHeThong(coreCommon.ThamSoHeThong.MaThamSoDoRongCotTrongLuongReport), out coreCommon.GlobalVariables.DoRongCotTrongLuongReport);
            //Double.TryParse(_DanhMucBUS.GetGiaTriThamSoHeThong(coreCommon.ThamSoHeThong.MaThamSoDoRongCotSoTienReport), out coreCommon.GlobalVariables.DoRongCotTienReport);
            //Double.TryParse(_DanhMucBUS.GetGiaTriThamSoHeThong(coreCommon.ThamSoHeThong.MaThamSoDoRongCotDonGiaReport), out coreCommon.GlobalVariables.DoRongCotGiaReport);
            //Double.TryParse(_DanhMucBUS.GetGiaTriThamSoHeThong(coreCommon.ThamSoHeThong.MaThamSoDoRongCotMaSoReport), out coreCommon.GlobalVariables.DoRongCotMaSoReport);
            //Double.TryParse(_DanhMucBUS.GetGiaTriThamSoHeThong(coreCommon.ThamSoHeThong.MaThamSoDoRongCotDienGiaiReport), out coreCommon.GlobalVariables.DoRongCotDienGiaiReport);
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (coreCommon.GlobalVariables.Logged)
            {
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.Name.ToUpper() != "FRMDESKTOP" && frm.Name.ToUpper() != "FRMMAIN")
                    {
                        coreCommon.coreCommon.ErrorMessageOkOnly("Bạn cần đóng hết cửa sổ đang mở trước khi thoát!");
                        coreCommon.GlobalVariables.CanLogout = false;
                        e.Cancel = true;
                        break;
                    }
                }
                if (coreCommon.GlobalVariables.CanLogout)
                {
                    coreCommon.GlobalVariables.CanLogout = (coreCommon.coreCommon.QuestionMessage("Bạn chắc chắn muốn thoát?", 0) == DialogResult.Yes);
                    e.Cancel = !coreCommon.GlobalVariables.CanLogout;
                }
            }
        }

        private void Logout()
        {
            this.Close();
            if (coreCommon.GlobalVariables.CanLogout)
            {
                Application.Restart();
                Application.ExitThread();
            }
        }
    }
}
