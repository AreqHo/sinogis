using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SQLite;
using System.IO;
using DevExpress.XtraBars.Ribbon;

namespace HRQ.SubForm
{
    public partial class ReportForm : DevExpress.XtraEditors.XtraForm
    {
        private DataRow dr = null;
        public ReportForm(DataRow _dr)
        {
            InitializeComponent();
            
            this.dr = _dr;

            getLineCheckList();
        }

        private void getLineCheckList()
        {
            //string pID = ia.GetFeatureAttribute("ID").Value;
            //string lID = ia.GetFeatureAttribute("LID").Value;

            //string dirPath = @"D:\HVL\" + lID + "\\" + pID;
            string tAppRoot = Path.GetDirectoryName(Application.ExecutablePath);
            string dirPath = Path.Combine(tAppRoot, @"Data\100000\100001\20140101");
            try
            {
                List<string> dirs = new List<string>(Directory.GetFiles(dirPath+"\\可见光", "*.JPG", System.IO.SearchOption.TopDirectoryOnly));

                if (dirs.Count > 0)
                {
                    foreach (var dir in dirs)
                    {
                        galleryControl1.Gallery.Groups[0].Items.Add(CreateGalleryItem(dir));
                    }
                }

                List<string> dirsRHW = new List<string>(Directory.GetFiles(dirPath+"\\热红外", "*.JPG", System.IO.SearchOption.TopDirectoryOnly));

                if (dirsRHW.Count > 0)
                {
                    foreach (var dir in dirsRHW)
                    {
                        galleryControl2.Gallery.Groups[0].Items.Add(CreateGalleryItem(dir));
                    }
                }
            }
            catch (Exception e)
            {
                this.Close();
            }
        }

        protected virtual GalleryItem CreateGalleryItem(string file)
        {
            string tAppRoot = Path.GetDirectoryName(Application.ExecutablePath);
            string dirPath = Path.Combine(tAppRoot, @"Data\100000\100001\Thumbs");
            GalleryItem item = new GalleryItem();
            item.Tag = file;
            item.Image = ThumbnailHelper.Default.GetThumbnail(file, 208, dirPath);
            return item;
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            this.teID.Text = this.dr["ID"].ToString();
            this.teLID.Text = this.dr["LID"].ToString();
            this.teITime.Text = this.dr["ITIME"].ToString();
            this.teIType.Text = this.dr["ITYPE"].ToString();
            this.teIProject.Text = this.dr["IPROJECT"].ToString();
            this.teStationID.Text = this.dr["STATIONID"].ToString();
            this.teILon.Text = this.dr["LON"].ToString();
            this.teIlat.Text = this.dr["LAT"].ToString();
            this.teFaultType.Text = this.dr["FAULTTYPE"].ToString();
            this.meDescription.Text = this.dr["DESCRIPTION"].ToString();
            if(this.dr["STATUS"].ToString() == "未处理"){
                this.cbeStatus.SelectedIndex = 0;
            }
            else
            {
                this.cbeStatus.SelectedIndex = 1;
            }
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sbSave_Click(object sender, EventArgs e)
        {
            try
            {
                string DBFileName = DevExpress.Utils.FilesHelper.FindingFileName(Application.StartupPath, "db\\HVL.db");
                string dbPath = "Data Source =" + DBFileName;
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {
                    conn.Open();
                    SQLiteCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "update Report set DESCRIPTION=@DESCRIPTION1,STATUS=@STATUS1 where ID=@ID1;";
                    cmd.Parameters.Add(new SQLiteParameter("ID1", dr["ID"]));
                    cmd.Parameters.Add(new SQLiteParameter("DESCRIPTION1", this.meDescription.Text));
                    cmd.Parameters.Add(new SQLiteParameter("STATUS1", this.cbeStatus.SelectedText));
                    int i = cmd.ExecuteNonQuery();
                }
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message + " \n\n" + ae.Source + "\n\n" + ae.StackTrace);
            }
            catch (Exception ex)
            {
                //Do　any　logging　operation　here　if　necessary  
                MessageBox.Show(ex.Message);
            }  
        }

        private void galleryControl1_Gallery_EndScroll(object sender, EventArgs e)
        {

        }

        PicEdit pe = null;
        private void galleryControl1_Gallery_ItemCheckedChanged(object sender, DevExpress.XtraBars.Ribbon.GalleryItemEventArgs e)
        {
            if (e.Item.Checked)
            {
                try
                {
                    //Image img = Image.FromFile(e.Item.Tag.ToString());
                    if (pe != null)
                    {
                        pe.Close();
                        pe.Dispose();
                        pe = null;
                    }
                    pe = new PicEdit(e.Item.Tag.ToString());
                    pe.Show();
                    //CaptureImageTool capture = new CaptureImageTool();
                    //capture.Image = img;
                    ////capture.SelectCursor = false;
                    //capture.Show();
                    //if (capture.ShowDialog() == DialogResult.OK)
                    //{
                    //    Image image = capture.Image;
                    //    image.Save(e.Item.Tag.ToString());
                    //}
                }
                catch (Exception ex)
                {
                    
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Word";
            fileDialog.Filter = "Word文件(*.doc)|*.doc";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                HRQ.Utils.Report report = new HRQ.Utils.Report();
                report.CreateNewDocument(Application.StartupPath + "\\DocModel\\1.doc"); //模板路径
                report.InsertValue("docID", this.teID.Text);
                report.InsertValue("docLID", this.teLID.Text);
                report.InsertValue("docTime", this.teITime.Text);
                report.InsertValue("docType", this.teIType.Text);
                report.InsertValue("docProject", this.teIProject.Text);
                report.InsertValue("docStationID", this.teStationID.Text);
                report.InsertValue("docFaultType", this.teFaultType.Text);
                report.InsertValue("docStatus", this.cbeStatus.SelectedText);
                report.InsertValue("docLon", this.teILon.Text);
                report.InsertValue("docLat", this.teIlat.Text);
                report.InsertValue("docDescription", this.meDescription.Text);
                string tAppRoot = Path.GetDirectoryName(Application.ExecutablePath);
                string dirPath = Path.Combine(tAppRoot, @"Data\100000\100001\20140101");
                try
                {
                    List<string> dirs = new List<string>(Directory.GetFiles(dirPath, "*.JPG", System.IO.SearchOption.AllDirectories));
                    int i = 0;
                    if (dirs.Count > 0)
                    {
                        foreach (var dir in dirs)
                        {
                            i++;
                            report.InsertPicture("docImg"+i, dir,800,600);
                        }
                    }
                }
                catch (Exception ex)
                {
                }
                

                report.SaveDocument(fileDialog.FileName);



                DevExpress.XtraEditors.XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}