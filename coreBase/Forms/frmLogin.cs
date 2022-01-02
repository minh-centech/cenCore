using coreBUS;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
namespace coreBase.Forms
{
    public partial class frmLogin : Form
    {
        public Boolean OK = false;
        public Boolean QuanTri = false;
        public DataTable dtDonVi;
        public List<string[]> listLoaiManHinh;
        DataTable dtConnects;
        public frmLogin()
        {
            InitializeComponent();
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult msgboxResult = coreCommon.coreCommon.QuestionMessage("Bạn chắc chắn muốn thoát?", 0);
            if (msgboxResult == DialogResult.Yes)
            {
                OK = false;
                //Xóa thư mục Temp
                if (Directory.Exists(coreCommon.GlobalVariables.TempDir))
                    Directory.Delete(coreCommon.GlobalVariables.TempDir, true);
                Close();
                Application.Exit();
            }
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (dtConnects.Rows.Count == 0) { coreCommon.coreCommon.ErrorMessageOkOnly("Không tìm thấy thông tin kết nối!"); return; }

                bool ConnectionFound = false;
                foreach (DataRow dr in dtConnects.Rows)
                {
                    if (dr["ID"].ToString() == cboConnect.SelectedItem.DataValue.ToString())
                    {
                        coreCommon.GlobalVariables.ConnectionString = coreCommon.coreCommon.DecryptString(dr["ConnectionString"].ToString());
                        ConnectionFound = true;
                        break;
                    }
                }
                if (!ConnectionFound) { coreCommon.coreCommon.ErrorMessageOkOnly("Không tìm thấy thông tin kết nối!"); return; }

                coreCommon.GlobalVariables.IDDanhMucNguoiSuDung = DanhMucNguoiSuDungBUS.GetID(txtUserName.Value, coreCommon.coreCommon.EncryptString(txtPassword.Text), out coreCommon.GlobalVariables.IDDanhMucPhanQuyen, out coreCommon.GlobalVariables.isAdmin);
                OK = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung != null;
                if (OK)
                {
                    coreCommon.GlobalVariables.MaDanhMucNguoiSuDung = txtUserName.Text;
                    coreCommon.GlobalVariables.Password = coreCommon.coreCommon.EncryptString(txtPassword.Text);
                    if (coreCommon.GlobalVariables.IDDanhMucPhanQuyen == null)
                    {
                        coreCommon.coreCommon.ErrorMessageOkOnly("Người sử dụng chưa được cấp quyền!");
                        OK = false;
                    }
                    else
                    {
                        dtDonVi = DanhMucPhanQuyenDonViBUS.List(null, coreCommon.GlobalVariables.IDDanhMucPhanQuyen);
                        if (dtDonVi == null || dtDonVi.Rows.Count == 0)
                        {
                            coreCommon.coreCommon.ErrorMessageOkOnly("Người sử dụng chưa được khai báo đơn vị!");
                            OK = false;
                            coreCommon.GlobalVariables.Logged = false;
                        }
                        else
                        {
                            Close();
                            OK = true;
                            coreCommon.GlobalVariables.Logged = true;

                            coreCommon.coreCommon.listLoaiManHinh = listLoaiManHinh;
                            frmLoginExtended frmLoginExtended = new frmLoginExtended
                            {
                                dtDonVi = dtDonVi
                            };
                            frmLoginExtended.ShowDialog();
                            coreCommon.GlobalVariables.TenDuLieu = cboConnect.Text;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không hợp lệ!", "ChuY", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void cmdSQLConnect_Click(object sender, EventArgs e)
        {
            frmSQLConnect frmSQLConnectUpdate = new frmSQLConnect();
            frmSQLConnectUpdate.ShowDialog();
            LoadData();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            LoadData();
            if (dtConnects.Rows.Count == 0)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Không tìm thấy kết nối dữ liệu, bạn hãy khai báo ít nhất 1 kết nối!");
            }
            else
            {
                cboConnect.SelectedItem = cboConnect.Items[0];
            }
        }
        private void LoadData()
        {
            cboConnect.Items.Clear();
            dtConnects = new DataTable("DataConnects");
            dtConnects.Columns.Add(new DataColumn("ID", typeof(long)));
            dtConnects.Columns["ID"].AutoIncrement = true;
            dtConnects.Columns["ID"].AutoIncrementStep = 1;
            dtConnects.Columns.Add(new DataColumn("Name", typeof(String)));
            dtConnects.Columns.Add(new DataColumn("ConnectionString", typeof(String)));
            if (!File.Exists(Application.StartupPath + @"\DataConnects.xml"))
            {
                dtConnects.WriteXml(coreCommon.GlobalVariables.ConnectionFileName, XmlWriteMode.WriteSchema);
            }
            if (File.Exists(Application.StartupPath + @"\DataConnects.xml"))
            {
                dtConnects.ReadXml(coreCommon.GlobalVariables.ConnectionFileName);
            }
            foreach (DataRow dr in dtConnects.Rows)
            {
                cboConnect.Items.Add(dr["ID"], coreCommon.coreCommon.DecryptString(dr["Name"].ToString()));
            }
        }
    }
}
