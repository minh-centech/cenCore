using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
namespace coreBase.Forms
{
    public partial class frmLoginExtended : Form
    {
        public Boolean OK = false;
        public Boolean QuanTri = false;
        public DataTable dtDonVi;
        public frmLoginExtended()
        {
            InitializeComponent();
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult msgboxResult = coreCommon.coreCommon.QuestionMessage("Bạn chắc chắn muốn thoát?", 0);
            if (msgboxResult == DialogResult.Yes)
            {
                OK = false;
                coreCommon.GlobalVariables.Logged = false;
                //Xóa thư mục Temp
                if (Directory.Exists(coreCommon.GlobalVariables.TempDir))
                    Directory.Delete(coreCommon.GlobalVariables.TempDir, true);
                Application.Exit();
            }
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (this.cboDonVi.SelectedItem != null)
            {
                OK = true;

                coreBUS.DanhMucPhanQuyenBUS.GetPhanQuyenDonVi(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, cboDonVi.Value, out bool Xem);
                if (!Xem)
                {
                    coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền truy cập số liệu của đơn vị này!");
                    return;
                }
                coreCommon.GlobalVariables.IDDonVi = this.cboDonVi.Value.ToString();
                coreCommon.GlobalVariables.TenDonVi = this.cboDonVi.Text;
                //Tạo thư mục Temp
                if (!Directory.Exists(coreCommon.GlobalVariables.TempDir))
                    Directory.CreateDirectory(coreCommon.GlobalVariables.TempDir);
                Close();
            }
            else
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn chưa chọn đơn vị sử dụng!");
            coreCommon.GlobalVariables.Logged = OK;

        }

        private void frmLoginExtended_Load(object sender, EventArgs e)
        {

            this.cboDonVi.DataSource = dtDonVi;
            this.cboDonVi.ValueMember = "IDDanhMucDonVi";
            this.cboDonVi.DisplayMember = "TenDanhMucDonVi";
            if (this.cboDonVi.Items.Count > 0)
            {
                this.cboDonVi.SelectedItem = this.cboDonVi.Items[0];
                this.cboDonVi.Enabled = (this.cboDonVi.Items.Count > 1);
            }
        }
    }
}
