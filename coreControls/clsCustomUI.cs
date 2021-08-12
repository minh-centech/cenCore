using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinEditors;
using DataAccessLayer;
using System.Drawing;
namespace CustomControls
{
    public static class clsCustomUI
    {
        /// <summary>
        /// Quét các control trên form và thay đổi thuộc tính text, caption nếu có
        /// </summary>
        /// <param name="frm"></param>
        public static void SetDisplayLanguage(Control ctl)
        {
            if (ctl is Form)
            {
                Form frm = (Form)ctl;
                if (!frm.IsMdiChild)
                {
                    frm.ControlBox = true;
                    frm.ShowIcon = true;
                    frm.Icon = Common.Common.DlgIco;
                }
            }
            if (ctl is saLabel | ctl is saCheckBox | ctl is Infragistics.Win.Misc.UltraButton)
                ctl.Text = Common.Common.TraTuDien(ctl.Text);
            if (ctl is saTextBox)
            {
                saTextBox satxt = (saTextBox)ctl;
                foreach (Infragistics.Win.UltraWinEditors.EditorButtonBase ebb in satxt.ButtonsLeft)
                {
                    ebb.Appearance.Image = clsDataAccessLayer.GetIconButton(ebb.Key.ToString().ToUpper());
                    ebb.Appearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                    ebb.Appearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                }
                foreach (Infragistics.Win.UltraWinEditors.EditorButtonBase ebb in satxt.ButtonsRight)
                {
                    ebb.Appearance.Image = clsDataAccessLayer.GetIconButton(ebb.Key.ToString().ToUpper());
                    ebb.Appearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                    ebb.Appearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                }
            }
            if (ctl is Infragistics.Win.UltraWinEditors.UltraTextEditor)
            {
                Infragistics.Win.UltraWinEditors.UltraTextEditor satxt = (Infragistics.Win.UltraWinEditors.UltraTextEditor)ctl;
                foreach (Infragistics.Win.UltraWinEditors.EditorButtonBase ebb in satxt.ButtonsLeft)
                {
                    ebb.Appearance.Image = clsDataAccessLayer.GetIconButton(ebb.Key.ToString().ToUpper());
                    ebb.Appearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                    ebb.Appearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                }
                foreach (Infragistics.Win.UltraWinEditors.EditorButtonBase ebb in satxt.ButtonsRight)
                {
                    ebb.Appearance.Image = clsDataAccessLayer.GetIconButton(ebb.Key.ToString().ToUpper());
                    ebb.Appearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                    ebb.Appearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                }
            }
            if (ctl is saDateTimeBox)
                ((saDateTimeBox)ctl).FormatProvider = Common.Common.ci;
            if (ctl is saNumericBox)
                ((saNumericBox)ctl).FormatProvider = Common.Common.ci;
            if (ctl is Infragistics.Win.UltraWinTabControl.UltraTabControl)
                foreach (Infragistics.Win.UltraWinTabControl.UltraTab ut in ((Infragistics.Win.UltraWinTabControl.UltraTabControl)ctl).Tabs)
                {
                    ut.Text = Common.Common.TraTuDien(ut.Text);
                }
            if (ctl is saNonUpdateGrid)
            {
                foreach (UltraGridColumn ugc in ((saNonUpdateGrid)ctl).DisplayLayout.Bands[0].Columns)
                {
                    if (!ugc.Hidden)
                        ugc.Header.Caption = Common.Common.TraTuDien(ugc.Header.Caption);
                }
            }
            if (ctl is saUpdateGrid)
            {
                foreach (UltraGridColumn ugc in ((saUpdateGrid)ctl).DisplayLayout.Bands[0].Columns)
                {
                    if (!ugc.Hidden)
                        ugc.Header.Caption = Common.Common.TraTuDien(ugc.Header.Caption);
                }
            }
            //Đặt icon theo style cho button
            if (ctl is Infragistics.Win.Misc.UltraButton && ctl.Tag != null)
            {
                ((Infragistics.Win.Misc.UltraButton)ctl).Appearance.Image = clsDataAccessLayer.GetIconButton(ctl.Tag.ToString().ToUpper());
                ((Infragistics.Win.Misc.UltraButton)ctl).ImageSize = new Size(16, 16);
            }
            //Đặt icon theo style cho button
            if (ctl is Infragistics.Win.Misc.UltraDropDownButton && ctl.Tag != null)
            {
                ((Infragistics.Win.Misc.UltraDropDownButton)ctl).Appearance.Image = clsDataAccessLayer.GetIconButton(ctl.Tag.ToString().ToUpper());
                ((Infragistics.Win.Misc.UltraDropDownButton)ctl).ImageSize = new Size(16, 16);
            }
            if (ctl.HasChildren)
            {
                foreach (Control childControl in ctl.Controls)
                    SetDisplayLanguage(childControl);
            }
        }
        /// <summary>
        /// Đặt ảnh cho toolbar
        /// </summary>
        /// <param name="utm">Toolbar</param>
        public static void SetMenuImage(Infragistics.Win.UltraWinToolbars.UltraToolbarsManager utm)
        {
            foreach (Infragistics.Win.UltraWinToolbars.ToolBase tb in utm.Tools)
            {
                if (tb is Infragistics.Win.UltraWinToolbars.ButtonTool)
                {
                    tb.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
                    tb.SharedProps.AppearancesSmall.Appearance.Image = clsDataAccessLayer.GetIconButton(tb.Key);
                }

            }
        }
        /// <summary>
        /// Đặt trạng thái enable cho các button dựa theo quyền danh mục
        /// </summary>
        /// <param name="IDChucNang">ID Chức năng</param>
        /// <param name="cmdInsert">Button Insert</param>
        /// <param name="cmdUpdate">Button Update</param>
        /// <param name="cmdDelete">Button Delete</param>
        /// <param name="cmdPrint">Button Print</param>
        /// <param name="cmdRefresh">Buton Refresh</param>
        /// <param name="toolPrintSetup">Menu Print Setup</param>
        /// <param name="toolImport">Menu Import</param>
        /// <param name="toolExport">Menu Export</param>
        public static void SetButtonStatusDanhMuc(String IDChucNang, UltraButton cmdInsert, UltraButton cmdUpdate, UltraButton cmdDelete, UltraDropDownButton cmdPrint, UltraDropDownButton cmdRefresh, ToolBase toolPrintSetup, ToolBase toolImport, ToolBase toolExport, UltraTextEditor txtFilterDetail)
        {
            cmdInsert.Enabled = clsDataAccessLayer.CheckRightsInsert("danhmuc", IDChucNang);
            cmdUpdate.Enabled = clsDataAccessLayer.CheckRightsUpdate("danhmuc", IDChucNang);
            cmdDelete.Enabled = clsDataAccessLayer.CheckRightsDelete("danhmuc", IDChucNang);
            cmdPrint.Enabled = clsDataAccessLayer.CheckRightsPrint("danhmuc", IDChucNang);
            cmdRefresh.Enabled = clsDataAccessLayer.CheckRightsView("danhmuc", IDChucNang); ;
            toolPrintSetup.SharedProps.Enabled = clsDataAccessLayer.CheckRightsPrintSetup("danhmuc", IDChucNang);
            toolImport.SharedProps.Enabled = clsDataAccessLayer.CheckRightsImport("danhmuc", IDChucNang);
            toolExport.SharedProps.Enabled = clsDataAccessLayer.CheckRightsExport("danhmuc", IDChucNang);
            if (txtFilterDetail != null)
            {
                txtFilterDetail.ButtonsRight["cmdadddetail"].Enabled = clsDataAccessLayer.CheckRightsInsert("danhmuc", IDChucNang);
                txtFilterDetail.ButtonsRight["cmdeditdetail"].Enabled = clsDataAccessLayer.CheckRightsUpdate("danhmuc", IDChucNang);
                txtFilterDetail.ButtonsRight["cmddeletedetail"].Enabled = clsDataAccessLayer.CheckRightsDelete("danhmuc", IDChucNang);
            }
        }
        /// <summary>
        /// Đặt trạng thái enable cho các button dựa theo quyền chứng từ
        /// </summary>
        /// <param name="IDChucNang">ID Chức năng</param>
        /// <param name="cmdInsert">Button Insert</param>
        /// <param name="cmdUpdate">Button Update</param>
        /// <param name="cmdDelete">Button Delete</param>
        /// <param name="cmdPrint">Button Print</param>
        /// <param name="cmdRefresh">Buton Refresh</param>
        /// <param name="toolPrintSetup">Menu Print Setup</param>
        /// <param name="toolImport">Menu Import</param>
        /// <param name="toolExport">Menu Export</param>
        public static void SetButtonStatusChungTu(String IDChucNang, UltraButton cmdInsert, UltraButton cmdUpdate, UltraButton cmdDelete, UltraButton cmdSearch, UltraButton cmdPrint, UltraDropDownButton cmdList, ToolBase toolImport, ToolBase toolExport)
        {
            cmdInsert.Enabled = clsDataAccessLayer.CheckRightsInsert("chungtu", IDChucNang);
            cmdUpdate.Enabled = clsDataAccessLayer.CheckRightsUpdate("chungtu", IDChucNang);
            cmdDelete.Enabled = clsDataAccessLayer.CheckRightsDelete("chungtu", IDChucNang);
            cmdSearch.Enabled = clsDataAccessLayer.CheckRightsView("chungtu", IDChucNang); ;
            cmdPrint.Enabled = clsDataAccessLayer.CheckRightsPrint("chungtu", IDChucNang);
            cmdList.Enabled = clsDataAccessLayer.CheckRightsView("chungtu", IDChucNang);
            toolImport.SharedProps.Enabled = clsDataAccessLayer.CheckRightsImport("chungtu", IDChucNang);
            toolExport.SharedProps.Enabled = clsDataAccessLayer.CheckRightsExport("chungtu", IDChucNang);
        }
    }
}
