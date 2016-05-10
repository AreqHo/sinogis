using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using System.IO;
using TerraExplorerX;
using DevExpress.XtraBars.Ribbon;
using System.Data.SQLite;

namespace HRQ.SubForm
{
    public partial class PropertiesForm : DevExpress.XtraEditors.XtraForm
    {
        long ia = 100000;
        public PropertiesForm(long _id)
        {
            InitializeComponent();
            this.ia = _id;
        }

        private void PropertiesForm_Load(object sender, EventArgs e)
        {
            PoleParams pp = new PoleParams(GetNWindData("Pole",this.ia));
            propertyGridControl1.SelectedObject= pp;
            getLineCheckList();
        }

        protected DataTable GetNWindData(string tableName,long _id)
        {
            string DBFileName = DevExpress.Utils.FilesHelper.FindingFileName(Application.StartupPath, "db\\HVL.db");

            if (DBFileName != "")
            {
                SQLiteConnection conn = null;

                string dbPath = "Data Source =" + DBFileName;
                conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置  
                conn.Open();//打开数据库，若文件不存在会自动创建  

                string sql = "SELECT * FROM " + tableName +" where ID="+_id;
                SQLiteCommand cmdQ = new SQLiteCommand(sql, conn);

                SQLiteDataReader reader = cmdQ.ExecuteReader();

                DataTable TSelectReSoult = new DataTable();  /*存放要在Gridview里面显示的最后结果*/
                TSelectReSoult.Load(reader);

                reader.Close();                        /*记得用完要关闭reader*/

                conn.Close();

                return TSelectReSoult;
            }
            return null;
        }
        private void getLineCheckList()
        {
            //string pID = ia.GetFeatureAttribute("ID").Value;
            //string lID = ia.GetFeatureAttribute("LID").Value;

            //string dirPath = @"D:\HVL\" + lID + "\\" + pID;
            //string dirPath = @"D:\HVL\100000\100001";
            string tAppRoot = Path.GetDirectoryName(Application.ExecutablePath);

            string dirPath = Path.Combine(tAppRoot, @"Data\100000\100001\20140101");
            try
            {
                List<string> dirs = new List<string>(Directory.GetDirectories(dirPath, "*", System.IO.SearchOption.AllDirectories));

                if (dirs.Count > 0)
                {
                    foreach (var dir in dirs)
                    {
                        Console.WriteLine("{0}", dir);
                        SimpleButton sb = new SimpleButton();
                        sb.Image = global::HRQ.Properties.Resources.folder48;
                        sb.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
                        sb.Text = dir.Split('\\').Last();
                        sb.Size = new System.Drawing.Size(71, 71);
                        sb.Click += sb_Click;
                        this.flowLayoutPanel1.Controls.Add(sb);
                    }
                }
            }
            catch (Exception e)
            {
                this.Close();
            }
        }

        private void sb_Click(object sender, EventArgs e)
        {
            SimpleButton sb =  (SimpleButton) sender;
            PrintTool(sb.Text);
        }

        private void PrintTool(String _imgPath)
        {
            List<Image> images = new List<Image>();
            string tAppRoot = Path.GetDirectoryName(Application.ExecutablePath);

            string dirPath = Path.Combine(tAppRoot, @"Data\100000\100001\20140101\" + _imgPath);

            try
            {
                foreach (string Path in Directory.GetFiles(dirPath))
                {
                    images.Add(Image.FromFile(Path));
                }
            }
            catch (Exception ex)
            {
                ;
            }
            
            PrintingSystem ps = new PrintingSystem();

            ps.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A5;
            ps.PageSettings.Landscape = true;
            ps.PageSettings.LeftMargin = 0;
            ps.PageSettings.RightMargin = 0;
            ps.PageSettings.TopMargin = 0;
            ps.PageSettings.BottomMargin = 0;

            BrickGraphics gr = ps.Graph;
            ps.Begin();

            float offsetY = 0;
            foreach (Image image in images)
            {
                ImageBrick imageBrick = new ImageBrick();
                imageBrick.Image = image;
                imageBrick.BorderWidth = 0;
                imageBrick.BorderStyle = BrickBorderStyle.Inset;
                imageBrick.Sides = BorderSide.All;

                imageBrick.SizeMode = ImageSizeMode.Squeeze;
                gr.DrawBrick(imageBrick, new RectangleF(new  PointF(0, offsetY), ps.PageSettings.UsablePageSizeInPixels));
                offsetY += ps.PageSettings.UsablePageSizeInPixels.Height;
            }
            ps.End();

            new PrintTool(ps).ShowPreviewDialog();
        }

        private Image GetImage(string fileName)
        {
            byte[] bytes = File.ReadAllBytes(fileName);
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            PrintTool("");
        }
    }

    public class PoleParams
    {
        [CategoryAttribute("杆塔属性"),
     ReadOnlyAttribute(true),
     DefaultValueAttribute("00000"), DisplayName("编号")]  
        public String ID { get; set; }
        [CategoryAttribute("杆塔属性"),
     ReadOnlyAttribute(true),
     DefaultValueAttribute("000.0000"), DisplayName("经度")]  
        public String PLon { get; set; }
        [CategoryAttribute("杆塔属性"),
     ReadOnlyAttribute(true),
     DefaultValueAttribute("00.0000"), DisplayName("纬度")]  
        public String PLat { get; set; }
        [CategoryAttribute("杆塔属性"),
     ReadOnlyAttribute(true),
     DefaultValueAttribute("00.00"), DisplayName("转向角")] 
        public String PYaw { get; set; }
        [CategoryAttribute("所属线路"),
     ReadOnlyAttribute(true),
     DefaultValueAttribute("00000"), DisplayName("线路编号")] 
        public String LID { get; set; }
        [CategoryAttribute("所属线路"),
     ReadOnlyAttribute(true),
     DefaultValueAttribute("****"), DisplayName("线路名称")] 
        public String LName { get; set; }
        [CategoryAttribute("所属线路"),
     ReadOnlyAttribute(true),
     DefaultValueAttribute("****"), DisplayName("电压类型")] 
        public String VType { get; set; }
        [CategoryAttribute("所属区域"),
     ReadOnlyAttribute(true),
     DefaultValueAttribute("****"),DisplayName("所属区域")] 
        public String PArea { get; set; }

        public PoleParams(DataTable _ia)
        {
            ID = _ia.Rows[0]["ID"].ToString();
            PLon = _ia.Rows[0]["LON"].ToString(); ;
            PLon = PLon.Substring(0, 9);
            PLat = _ia.Rows[0]["LAT"].ToString();
            PLat = PLat.Substring(0, 9);
            PYaw = _ia.Rows[0]["Yaw"].ToString();
            PYaw = PYaw.Substring(0, 9);
            LID = _ia.Rows[0]["LID"].ToString();
            LName = _ia.Rows[0]["LNAME"].ToString();
            VType = _ia.Rows[0]["VTYPE"].ToString();
            PArea = _ia.Rows[0]["PAREA"].ToString();
        }
    }
}