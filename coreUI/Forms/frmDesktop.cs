using coreBUS;
using coreDTO;
using Infragistics.Win.UltraWinExplorerBar;
using System;
using System.Data;
using System.Windows.Forms;
namespace coreUI.Forms
{
    public partial class frmDesktop : Form
    {
        public static Action runCustomMenu;
        public static string LoaiChucNang = string.Empty, TenChucNang = string.Empty, FormCaption = string.Empty;
        public frmDesktop()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            uBarMenu.Groups.Clear();
            uBarBaoCao.Groups.Clear();
            //Load Menu, DanhMuc, ChungTu, BaoCao
            //Load danh sách phân hệ
            DataSet dsMenu = DanhMucMenuBUS.List(null);
            foreach (DataRow drMenu in dsMenu.Tables[DanhMucMenu.tableName].Rows)
            {
                UltraExplorerBarGroup uGroup = new UltraExplorerBarGroup
                {
                    Key = "mnu" + drMenu["ID"].ToString(),
                    Text = drMenu["Ten"].ToString()
                };
                //if (drMenu["Anh"] != DBNull.Value)
                //{
                //    uGroup.Settings.AppearancesSmall.HeaderAppearance.Image = coreCommon.GlobalVariables.ImageFromByte((Byte[])drMenu["Anh"]);
                //    uGroup.Settings.AppearancesSmall.NavigationPaneHeaderAppearance.Image = coreCommon.GlobalVariables.ImageFromByte((Byte[])drMenu["Anh"]);
                //}
                uBarMenu.Groups.Add(uGroup);
            }
            //Load chứng từ và danh mục tương ứng với các phân hệ
            foreach (UltraExplorerBarGroup uGroup in uBarMenu.Groups)
            {
                //Load chứng từ
                foreach (DataRow drChungTu in dsMenu.Tables[DanhMucMenuChungTu.tableName].Rows)
                {
                    if (drChungTu["IDDanhMucMenu"].ToString() == uGroup.Key.Substring(3))
                    {
                        if (coreCommon.coreCommon.stringParseBoolean(drChungTu["PhanCachNhom"].ToString()))
                        {
                            UltraExplorerBarItem uItemBr = new UltraExplorerBarItem();
                            uItemBr.Settings.Style = ItemStyle.Separator;
                            uItemBr.Key = "br" + drChungTu["ID"].ToString() + uGroup.Key;
                            uGroup.Items.Add(uItemBr);
                        }
                        UltraExplorerBarItem uItem = new UltraExplorerBarItem();
                        uItem.Settings.Style = ItemStyle.Button;
                        uItem.Key = "_dct_" + drChungTu["IDDanhMucChungTu"].ToString() + "ID:" + drChungTu["ID"].ToString() + "MA:" + drChungTu["MaDanhMucChungTu"].ToString() + "LOAIMANHINH:" + drChungTu["LoaiManHinh"].ToString();
                        uItem.Text = drChungTu["NoiDungHienThi"].ToString();
                        //if (drChungTu["Anh"] != DBNull.Value)
                        //{
                        //    uItem.Settings.AppearancesSmall.Appearance.Image = coreCommon.GlobalVariables.ImageFromByte((Byte[])drChungTu["Anh"]);
                        //}
                        //else
                        //    uItem.Settings.AppearancesSmall.Appearance.Image = null;
                        uGroup.Items.Add(uItem);
                    }
                }
                //Load danh mục
                foreach (DataRow drDanhMuc in dsMenu.Tables[DanhMucMenuLoaiDoiTuong.tableName].Rows)
                {
                    if (drDanhMuc["IDDanhMucMenu"].ToString() == uGroup.Key.Substring(3))
                    {
                        //uGroup.Items.Add("ct" + drDanhMuc["ID"].ToString(), drDanhMuc["Ten"].ToString());
                        if (coreCommon.coreCommon.stringParseBoolean(drDanhMuc["PhanCachNhom"].ToString()))
                        {
                            UltraExplorerBarItem uItemBr = new UltraExplorerBarItem();
                            uItemBr.Settings.Style = ItemStyle.Separator;
                            uItemBr.Key = "br" + drDanhMuc["ID"].ToString() + uGroup.Key;
                            uGroup.Items.Add(uItemBr);
                        }
                        UltraExplorerBarItem uItem = new UltraExplorerBarItem();
                        uItem.Settings.Style = ItemStyle.Button;
                        uItem.Key = "_ddm_" + drDanhMuc["IDDanhMucLoaiDoiTuong"].ToString() + "ID:" + drDanhMuc["ID"].ToString();
                        uItem.Text = drDanhMuc["NoiDungHienThi"].ToString();
                        uGroup.Items.Add(uItem);
                    }
                }
            }
            //Load báo cáo
            //Load các group trong báo cáo trước
            foreach (DataRow drBaoCao in dsMenu.Tables[DanhMucMenuBaoCao.tableName].Rows)
            {
                if (!uBarBaoCao.Groups.Exists("mnuGroup" + drBaoCao["IDDanhMucNhomBaoCao"].ToString()))
                {
                    UltraExplorerBarGroup uGroup = new UltraExplorerBarGroup
                    {
                        Key = "mnuGroup" + drBaoCao["IDDanhMucNhomBaoCao"].ToString(),
                        Text = drBaoCao["TenDanhMucNhomBaoCao"].ToString()
                    };
                    uBarBaoCao.Groups.Add(uGroup);
                }
            }
            //Load báo cáo vào từng group
            foreach (DataRow drBaoCao in dsMenu.Tables[DanhMucMenuBaoCao.tableName].Rows)
            {
                UltraExplorerBarItem uItem = new UltraExplorerBarItem();
                String GroupKey = "mnuGroup" + drBaoCao["IDDanhMucNhomBaoCao"].ToString();
                uItem.Settings.Style = ItemStyle.Button;
                uItem.Key = "_dbc_" + drBaoCao["IDDanhMucBaoCao"].ToString() + "ID:" + drBaoCao["ID"].ToString() + "menu:" + drBaoCao["IDDanhMucMenu"].ToString();
                uItem.Text = drBaoCao["NoiDungHienThi"].ToString();
                uBarBaoCao.Groups[GroupKey].Items.Add(uItem);
            }
            //Chọn phân hệ đầu tiên
            if (uBarMenu.Groups.Count > 0)
            {
                uBarMenu.Groups[0].Selected = true;
                ShowBaoCao(uBarMenu.Groups[0].Key.Substring(3), uBarMenu.Groups[0].Text);
            }
        }
        private void frmDesktop_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void uBarMenu_GroupClick(object sender, Infragistics.Win.UltraWinExplorerBar.GroupEventArgs e)
        {
            //Hiển thị danh sách báo cáo tương ứng với phân hệ này
            if (e != null) ShowBaoCao(e.Group.Key.Substring(3), e.Group.Text);
        }
        private void ShowBaoCao(String menuID, String menuText)
        {
            if (menuID != null)
            {
                if (uBarBaoCao.Groups.Exists("mnuGroupNull"))
                    uBarBaoCao.Groups["mnuGroupNull"].Text = menuText;
                //Ẩn hiện những mục báo cáo không thuộc phân hệ này
                foreach (UltraExplorerBarGroup uGroup in uBarBaoCao.Groups)
                {
                    uGroup.Visible = true;
                    Boolean HasVisibleChildren = false;
                    foreach (UltraExplorerBarItem uItem in uGroup.Items)
                    {
                        if (!uItem.Key.Contains("menu:" + menuID))
                            uItem.Visible = false;
                        else
                        {
                            uItem.Visible = true;
                            HasVisibleChildren = true;
                        }
                    }
                    //Nếu group báo cáo này không có báo cáo nào thì ẩn đi
                    if (!HasVisibleChildren) uGroup.Visible = false;
                }
                foreach (UltraExplorerBarGroup uGroup in uBarBaoCao.Groups)
                {
                    if (uGroup.Visible)
                    {
                        uGroup.Selected = true;
                        break;
                    }
                }
            }
        }

        private void uBarMenu_ItemClick(object sender, ItemEventArgs e)
        {
            LoaiChucNang = e.Item.Key.Substring(0, 5).ToUpper();
            TenChucNang = e.Item.Key.Substring(5);
            FormCaption = e.Item.Text;
            runCustomMenu();
        }
    }
}
