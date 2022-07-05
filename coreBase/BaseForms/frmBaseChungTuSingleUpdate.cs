using System;
using System.Data;
using System.Windows.Forms;
namespace coreBase.BaseForms
{
    public partial class frmBaseChungTuSingleUpdate : Form
    {

        //Trạng thái cập nhật 1: Thêm mới, 2: Sửa
        public byte UpdateMode = coreCommon.ThaoTacDuLieu.Xem;
        public object IDChungTu = null, IDDanhMucChungTu = null, LoaiManHinh = null;
        public string TenDanhMucChungTu = string.Empty;
        public DataRow dataRow = null;
        public DataTable dataTable = null;

        public static DataTable dtUpdate;
        public Action InsertToList, UpdateToList;
        public object TuNgay, DenNgay;
        public frmBaseChungTuSingleUpdate()
        {
            InitializeComponent();
        }
        private void frm_donvi_capnhat_Load(object sender, EventArgs e)
        {
            //Text = (UpdateMode == coreCommon.ThaoTacDuLieu.Sua) ? coreCommon.ThaoTacDuLieu.DienGiaiSua : coreCommon.ThaoTacDuLieu.DienGiaiThem + " " + TenDanhMucChungTu;
            this.CenterToScreen();
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveData(false);
        }
        /// <summary>
        /// Lưu dữ liệu
        /// </summary>
        protected virtual void SaveData(Boolean AddNew)
        {
        }
        /// <summary>
        /// Phím chức năng F6: Lưu dữ liệu, ESC: Thoát
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormKeyDown(object sender, KeyEventArgs e)
        {
            if (UpdateMode == coreCommon.ThaoTacDuLieu.Xem) return;
            if (e.Modifiers == Keys.Control)
            {
                if (e.KeyCode == Keys.S)
                {
                    SaveData(false);
                }
                if (e.KeyCode == Keys.N)
                {
                    SaveData(false);
                }
            }
            else
            {
                if (e.KeyCode == Keys.Escape)
                {
                    Close();
                }
            }
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            return base.ProcessDialogKey(keyData);
        }
        private void cmdSaveAdd_Click(object sender, EventArgs e)
        {
            SaveData(true);
        }
    }
}
