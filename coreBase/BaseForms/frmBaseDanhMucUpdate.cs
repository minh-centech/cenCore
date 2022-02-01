using System;
using System.Data;
using System.Windows.Forms;
namespace coreBase.BaseForms
{
    public partial class frmBaseDanhMucUpdate : Form
    {

        //Trạng thái cập nhật 1: Thêm mới, 2: Sửa
        public int CapNhat = coreCommon.ThaoTacDuLieu.Xem;
        public object ID;
        public object IDDanhMucLoaiDoiTuong = null;
        public string TenDanhMucLoaiDoiTuong = string.Empty;
        public DataRow dataRow = null;
        public frmBaseDanhMucUpdate()
        {
            InitializeComponent();
        }
        private void frm_donvi_capnhat_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            Text = (CapNhat == coreCommon.ThaoTacDuLieu.Sua) ? coreCommon.ThaoTacDuLieu.DienGiaiSua : coreCommon.ThaoTacDuLieu.DienGiaiThem + " " + TenDanhMucLoaiDoiTuong;
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveData(false);
        }
        private void cmdSaveAdd_Click(object sender, EventArgs e)
        {
            SaveData(true);
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        protected virtual void SaveData(Boolean AddNew)
        {
        }
        private void FormKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                if (e.KeyCode == Keys.S)
                {
                    SaveData(false);
                }
                if (e.KeyCode == Keys.N)
                {
                    SaveData(true);
                }
            }
            else
            {
                if (e.KeyCode == Keys.Escape)
                {
                    DialogResult = DialogResult.Cancel;
                }
            }
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            return base.ProcessDialogKey(keyData);
        }
        protected virtual void ClearTextBox()
        {

        }
    }
}
