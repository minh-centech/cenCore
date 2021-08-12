using System;
using System.Drawing;
using System.Windows.Forms;

namespace coreControls
{
    public partial class saDateTimeBox : Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    {
        public Boolean IsNullable = false; //Có cho phép null hay không
        public Boolean IsModified = false; //Có thay đổi dữ liệu hay không
        public Boolean LeaveByKey = false; //Dùng phím hay chuột để thoát khỏi 
        public saDateTimeBox()
        {
            InitializeComponent();
            this.Value = null;
            this.Nullable = true;
            this.AutoFillDate = Infragistics.Win.UltraWinMaskedEdit.AutoFillDate.MonthAndYear;
            this.AutoFillTime = Infragistics.Win.UltraWinMaskedEdit.AutoFillTime.CurrentTime;
            this.MaskInput = coreCommon.GlobalVariables.MaskInputDate;
            this.PromptChar = char.MinValue;
            this.Appearance.ForeColorDisabled = Color.Black;
        }
        protected override void OnEnter(EventArgs e)
        {
            LeaveByKey = false;
            this.SelectAll();
            base.OnEnter(e);
        }
        protected override void OnValueChanged(EventArgs args)
        {
            IsModified = true;
            base.OnValueChanged(args);
        }
        protected override void OnValidated(EventArgs e)
        {
            if (this.DataBindings.Count > 0)
            {
                foreach (Binding bd in this.DataBindings)
                    bd.WriteValue();
            }
            base.OnValidated(e);
        }
        protected override void OnGotFocus(EventArgs e)
        {
            this.SelectAll();
            base.OnGotFocus(e);
        }
        protected override void OnTextChanged(EventArgs e)
        {
            IsModified = true;
            base.OnTextChanged(e);
        }
        public void SetDataBinding(object DataSource, string TextColumnName, bool format = false, DataSourceUpdateMode mode = DataSourceUpdateMode.OnValidation)
        {
            this.DataBindings.Clear();
            this.DataBindings.Add("Value", DataSource, TextColumnName, format, mode);
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if ((keyData == Keys.Enter | keyData == Keys.Tab) && keyData != Keys.Shift)
            {
                LeaveByKey = true;
                return base.ProcessDialogKey(Keys.Tab);
            }
            else
                return base.ProcessDialogKey(keyData);
        }
    }
}
