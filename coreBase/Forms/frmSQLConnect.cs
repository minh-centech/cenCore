using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
namespace coreBase.Forms
{
    public partial class frmSQLConnect : coreBase.BaseForms.frmBaseDanhMuc
    {
        DataTable dtConnects;
        public frmSQLConnect()
        {
            InitializeComponent();
        }
        protected override void List()
        {
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
                dr["Name"] = coreCommon.coreCommon.DecryptString(dr["Name"].ToString());
                dr["ConnectionString"] = coreCommon.coreCommon.DecryptString(dr["ConnectionString"].ToString());
            }

            bsData = new BindingSource
            {
                DataSource = dtConnects
            };
            ug.DataSource = bsData;
        }
        protected override void InsertDanhMuc()
        {
            frmSQLConnectUpdate frmSQLConnectUpdate = new frmSQLConnectUpdate();
            frmSQLConnectUpdate.ShowDialog();
            List();
        }
        protected override void DeleteDanhMuc()
        {
            if (bsData.Current == null) return;
            if (coreCommon.coreCommon.QuestionMessage("Bạn có chắc chắn muốn xóa không?", 0) == DialogResult.Yes)
            {
                bsData.RemoveCurrent();
            }
            SaveData();
        }
        private void SaveData()
        {
            DataTable dtConnectCopy = dtConnects.Copy();
            foreach (DataRow dr in dtConnectCopy.Rows)
            {
                dr["Name"] = coreCommon.coreCommon.EncryptString(dr["Name"].ToString());
                dr["ConnectionString"] = coreCommon.coreCommon.EncryptString(dr["ConnectionString"].ToString());
            }
            dtConnectCopy.WriteXml(coreCommon.GlobalVariables.ConnectionFileName, XmlWriteMode.WriteSchema);
        }

    }
}
