namespace coreControls
{
    public partial class saLabel : Infragistics.Win.Misc.UltraLabel
    {
        public saLabel()
        {
            InitializeComponent();
            base.Appearance.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            base.AutoSize = true;
        }
    }
}
