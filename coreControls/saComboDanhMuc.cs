using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace coreControls
{
    public partial class saComboDanhMuc : Infragistics.Win.UltraWinEditors.UltraComboEditor
    {
        public Boolean IsNullable = false;
        public Boolean IsModified = false;
        //
        public DataTable dtValid = null;
        //
        public Func<DataTable> listProcedure;
        public Func<DataRow> insertProcedure;
        public saComboDanhMuc()
        {
            InitializeComponent();
            this.AutoSize = false;
            this.Nullable = true;
            this.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            this.Appearance.ForeColorDisabled = Color.Black;
        }
        protected override void OnEnter(EventArgs e)
        {
            this.SelectAll();
            base.OnEnter(e);
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if ((keyData == Keys.Enter | keyData == Keys.Tab) && keyData != Keys.Shift)
            {
                return base.ProcessDialogKey(Keys.Tab);
            }
            else
                return base.ProcessDialogKey(keyData);
        }
    }
}
