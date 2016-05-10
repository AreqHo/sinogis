using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HRQ {
    public partial class ProgressControl : XtraUserControl {
        public ProgressControl() {
            InitializeComponent();
        }

        public int Maximum { get { return progressBarControl1.Properties.Maximum; } set { progressBarControl1.Properties.Maximum = value; } }
        public int Value { get { return (int)progressBarControl1.EditValue; } set { progressBarControl1.EditValue = value; } }
        public string ProgressText { get { return labelControl1.Text; } set { labelControl1.Text = value; } }
    }
}
