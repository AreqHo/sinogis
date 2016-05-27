using HRQ.Modules;

namespace HRQ.SubForm
{
    public partial class PoleForm : DevExpress.XtraEditors.XtraForm
    {
        private PoleAttribute pa = null;
        public PoleForm(PoleAttribute pa)
        {
            InitializeComponent();
            this.Load += PoleForm_Load;
        }

        private void PoleForm_Load(object sender, System.EventArgs e)
        {
            this.picControlH.Flag = 1;
            this.picControlK.Flag = 0;
        }
    }
}