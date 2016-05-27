using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HRQ.SubForm
{
    public partial class SettingForm : DevExpress.XtraEditors.XtraForm
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void sbBrowsePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                MessageBox.Show("已选择文件夹:" + foldPath, "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                teFoldPath.Text = foldPath;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (teFoldPath.Text.Length > 0)
            {
                var app = App.GetInstance();
                app.SystemFoldPath = teFoldPath.Text;
            }
            this.Close();
        }
    }
}