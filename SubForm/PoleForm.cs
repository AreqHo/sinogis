using HRQ.Modules;

namespace HRQ.SubForm
{
    public partial class PoleForm : DevExpress.XtraEditors.XtraForm
    {
        private PoleAttribute pa = null;
        public PoleForm(PoleAttribute pa)
        {
            this.pa = pa;
            InitializeComponent();
        }
    }
}