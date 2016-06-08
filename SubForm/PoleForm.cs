using HRQ.Modules;

namespace HRQ.SubForm
{
    public partial class PoleForm : DevExpress.XtraEditors.XtraForm
    {
        private PoleAttribute pa = null;
        private DrawControl dc = null;
        public PoleForm(PoleAttribute pa)
        {
            InitializeComponent();
            this.Load += PoleForm_Load;
        }

        private void PoleForm_Load(object sender, System.EventArgs e)
        {
            DrawControl dc = new DrawControl();
            dc.Name = "dc";
            dc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Panel1.Controls.Add(dc);
        }

        private void sbJJUpload_Click(object sender, System.EventArgs e)
        {
            string faultDesc = this.tePoleNO.Text + "号杆塔在第"
                + cbeJJLoop.Text + "回路，第" + cbeJJPlug.Text + "相"
                + cbeJJPosition.Text +"位置，"+cbeJJFaultClass.Text + cbeJJFaultType.Text+"。\n";

            rtbJJDesc.Text += faultDesc;
        }

        private void sbFaultSave_Click(object sender, System.EventArgs e)
        {
            //ID
            string ID = pa.ID;
            //string FPATH = 
        }
    }
}