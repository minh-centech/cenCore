using coreBUS;
using coreDTO;
using System;
using System.Windows.Forms;
namespace coreBase.Forms
{
    public partial class frmChangePassword : Form
    {
        public Boolean PasswordChanged = false;
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtOldPassword.Value == null) txtOldPassword.Text = "";
                if (txtNewPassword1.Value == null) txtNewPassword1.Text = "";
                if (txtNewPassword2.Value == null) txtNewPassword2.Text = "";
                //Kiểm tra password cũ
                if (coreCommon.coreCommon.EncryptString(txtOldPassword.Text) != coreCommon.GlobalVariables.Password)
                {
                    coreCommon.coreCommon.ErrorMessageOkOnly("Password cũ không hợp lệ!");
                }
                //Nếu mật khẩu mới khớp
                if (txtNewPassword1.Text == txtNewPassword2.Text)
                {
                    DanhMucNguoiSuDung obj = new DanhMucNguoiSuDung
                    {
                        ID = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                        IDDanhMucPhanQuyen = coreCommon.GlobalVariables.IDDanhMucPhanQuyen,
                        Ma = coreCommon.GlobalVariables.MaDanhMucNguoiSuDung,
                        Ten = coreCommon.GlobalVariables.TenDanhMucNguoiSuDung,
                        Password = coreCommon.coreCommon.EncryptString(txtNewPassword1.Text)
                    };
                    if (DanhMucNguoiSuDungBUS.UpdatePassword(coreCommon.GlobalVariables.IDDanhMucNguoiSuDung, coreCommon.coreCommon.EncryptString(txtNewPassword1.Text)))
                    {
                        coreCommon.GlobalVariables.Password = coreCommon.coreCommon.EncryptString(obj.Password.ToString());
                        coreCommon.coreCommon.InfoMessage("Thay đổi password thành công!");
                        Dispose();
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu mới nhập không khớp nhau!\nXin hãy thử lại!", "ChuY", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "ChuY", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            //LoadDisplayLanguage
            //clsCommon.SetDisplayLanguage(this);
        }

    }
}
