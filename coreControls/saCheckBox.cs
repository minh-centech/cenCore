using System;
using System.Windows.Forms;

namespace coreControls
{
    public partial class saCheckBox : Infragistics.Win.UltraWinEditors.UltraCheckEditor
    {
        public Boolean IsModified = false;

        public saCheckBox()
        {
            InitializeComponent();
            base.Appearance.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            base.AutoSize = true;
        }

        protected override void OnCheckedValueChanged()
        {
            IsModified = true;
            if (this.DataBindings.Count > 0)
            {
                foreach (Binding bd in this.DataBindings)
                    bd.WriteValue();
            }
            base.OnCheckedValueChanged();
        }
        public void SetDataBinding(object DataSource, string ColumnName)
        {
            this.DataBindings.Clear();
            this.DataBindings.Add("CheckedValue", DataSource, ColumnName);
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter && keyData != (Keys.Shift | Keys.Tab))
            {
                return base.ProcessDialogKey(Keys.Tab);
            }
            else
                return base.ProcessDialogKey(keyData);
        }
    }
}
