using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace HRQ.SubForm {
    public partial class TerraAnalysis : DevExpress.XtraEditors.XtraForm {
        public TerraAnalysis() {

            InitializeComponent();

            string tAppRoot = Path.GetDirectoryName(Application.ExecutablePath);

            MainForm.sgworld.Command.Execute(1149,28);

        }
    }
}