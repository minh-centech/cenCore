using Infragistics.Win.UltraWinEditors;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace coreControls
{
    public partial class saNumericBox : Infragistics.Win.UltraWinEditors.UltraNumericEditor
    {
        public Boolean IsModified = false;
        public Boolean LeaveByKey = false;
        public Boolean IsNullable = false;

        public saNumericBox()
        {
            InitializeComponent();
            this.Nullable = true;
            this.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.Appearance.ForeColorDisabled = Color.Black;
            this.PromptChar = char.MinValue;
            if (this.NumericType == NumericType.Integer)
            {
                this.MaskInput = coreCommon.GlobalVariables.DinhDangNhapInteger;
                this.FormatString = coreCommon.GlobalVariables.FormatInteger;
            }
            else
            {
                this.MaskInput = coreCommon.GlobalVariables.DinhDangNhapReal;
                this.FormatString = coreCommon.GlobalVariables.FormatReal;
            }
            this.Value = null;
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
