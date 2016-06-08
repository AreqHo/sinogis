using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRQ.Utils;
using System.IO;
using System.Threading;

namespace HRQ.Modules
{
    public partial class DrawControl : UserControl
    {
        private string imgPath = "";
        List<string> dirsH = null;
        List<string> dirsK = null;
        public DrawControl()
        {
            InitializeComponent();
        }

        private string poleID = "";
        private string poleLoop = "";


        private DrawTools dtK;
        private DrawTools dtH;
        private string sTypeK;//绘图样式
        private string sTypeH;//绘图样式
        private string sFileName;//打开的文件名
        private bool bReSize = false;//是否改变画布大小
        private Size DefaultPicSizeK;//储存原始画布大小，用来新建文件时使用
        private Size DefaultPicSizeH;//储存原始画布大小，用来新建文件时使用

        private int picNO = 0;

        private void directoryFile()
        {
            string dirPath = App.GetInstance().SystemFoldPath + "\\"+poleID+"\\"+poleLoop;
            try
            {
                dirsK = new List<string>(Directory.GetFiles(dirPath + "\\k", "*.JPG", System.IO.SearchOption.TopDirectoryOnly));
                dirsH = new List<string>(Directory.GetFiles(dirPath + "\\h", "*.JPG", System.IO.SearchOption.TopDirectoryOnly));
            }
            catch (Exception e)
            {
            }
        }
        private void loadImg(int index, List<string> dirs , PictureBox pb,DrawTools dt)
        {
            Bitmap bmpformfile = new Bitmap(dirs[index]);//获取打开的文件
            panel2.AutoScrollPosition = new Point(0, 0);//将滚动条复位
            pb.Size = bmpformfile.Size;//调整绘图区大小为图片大小

            dt.DrawTools_Graphics = pb.CreateGraphics();

            Bitmap bmp = new Bitmap(pb.Width, pb.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(new SolidBrush(pb.BackColor), new Rectangle(0, 0, pb.Width, pb.Height));//不使用这句话，那么这个bmp的背景就是透明的
            g.DrawImage(bmpformfile, 0, 0, bmpformfile.Width, bmpformfile.Height);//将图片画到画板上
            g.Dispose();//释放画板所占资源
                        //不直接使用pbImg.Image = Image.FormFile(ofd.FileName)是因为这样会让图片一直处于打开状态，也就无法保存修改后的图片；详见http://www.wanxin.org/redirect.php?tid=3&goto=lastpost
            bmpformfile.Dispose();//释放图片所占资源
            g = pb.CreateGraphics();
            g.DrawImage(bmp, 0, 0);
            g.Dispose();
            dt.OrginalImg = bmp;
            bmp.Dispose();
            sFileName = dirs[index];//储存打开的图片文件的详细路径，用来稍后能覆盖这个文件
            //ofd.Dispose();
        }

        //窗体移动最小化等造成的pbimg＂重画＂事件处理方法
        private void pbImgK_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(dtK.OrginalImg, 0, 0);
            //g.Dispose();切不可使用,这个Graphics是系统传入的变量，不是我们自己创建的，如果dispose就会出错
        }

        private void pbImgH_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(dtH.OrginalImg, 0, 0);
            //g.Dispose();切不可使用,这个Graphics是系统传入的变量，不是我们自己创建的，如果dispose就会出错

        }

        //＂绘图工具选用＂事件处理方法
        private void toolK_Click(object sender, EventArgs e)
        {
            ToolStripButton tsb = sender as ToolStripButton;
            if (tsb != null)
            {
                sTypeK = tsb.Name;
                if (sTypeK == "Eraser")
                {
                    pbImgK.Cursor = new Cursor(Application.StartupPath + @"\img\pb.cur");
                }
                else if (sTypeK == "prevK")
                {
                    var picN = picNO - 1;
                    if(picN >= 0)
                    {
                        loadImg(picN, dirsK, pbImgK, dtK);
                        loadImg(picN, dirsH, pbImgH, dtH);
                        picNO--;
                    }
                }
                else if (sTypeK == "nextK")
                {
                    var picN = picNO + 1;
                    if (picN <= dirsK.Count-1)
                    {
                        loadImg(picN, dirsK, pbImgK, dtK);
                        loadImg(picN, dirsH, pbImgH, dtH);
                        picNO++;
                    }
                }
                else
                {
                    pbImgK.Cursor = Cursors.Cross;
                }
            }
        }

        private void toolH_Click(object sender, EventArgs e)
        {
            ToolStripButton tsb = sender as ToolStripButton;
            if (tsb != null)
            {
                sTypeH = tsb.Name;
                if (sTypeH == "EraserH")
                {
                    pbImgH.Cursor = new Cursor(Application.StartupPath + @"\img\pb.cur");
                }
                else if (sTypeH == "prevH")
                {
                    var picN = picNO - 1;
                    if (picN >= 0)
                    {
                        loadImg(picN, dirsK, pbImgK, dtK);
                        loadImg(picN, dirsH, pbImgH, dtH);
                        picNO--;
                    }
                }
                else if (sTypeH == "nextH")
                {
                    var picN = picNO + 1;
                    if (picN <= dirsK.Count - 1)
                    {
                        loadImg(picN, dirsK, pbImgK, dtK);
                        loadImg(picN, dirsH, pbImgH, dtH);
                        picNO++;
                    }
                }
                else
                {
                    pbImgH.Cursor = Cursors.Cross;
                }
            }
        }

        private void DrawControl_Load(object sender, EventArgs e)
        {
            directoryFile();

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            init(pbImgK);
            init(pbImgH);
        }

        private void init(PictureBox pb)
        {
            Bitmap bmp = new Bitmap(pb.Width, pb.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(new SolidBrush(pb.BackColor), new Rectangle(0, 0, pb.Width, pb.Height));
            g.Dispose();
            if (pb.Equals(pbImgK))
            {
                dtK = new DrawTools(pb.CreateGraphics(), colorHatch1.HatchColor, bmp);//实例化工具类
                DefaultPicSizeK = pb.Size;
                loadImg(0,dirsK,pb,dtK);
            }
            else
            {
                dtH = new DrawTools(pb.CreateGraphics(), colorHatch2.HatchColor, bmp);//实例化工具类
                DefaultPicSizeH = pb.Size;
                loadImg(0, dirsH, pb, dtH);
            }
            
        }

        //pbimg＂鼠标按下＂事件处理方法
        private void pbImgK_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (dtK != null)
                {
                    dtK.startDraw = true;//相当于所选工具被激活，可以开始绘图
                    dtK.startPointF = new PointF(e.X, e.Y);
                }
            }
        }

        private void pbImgH_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (dtH != null)
                {
                    dtH.startDraw = true;//相当于所选工具被激活，可以开始绘图
                    dtH.startPointF = new PointF(e.X, e.Y);
                }
            }
        }

        //pbimg＂鼠标移动＂事件处理方法
        private void pbImgK_MouseMove(object sender, MouseEventArgs e)
        {
            Thread.Sleep(6);//减少cpu占用率
            if (dtK.startDraw)
            {
                switch (sTypeK)
                {
                    case "DotK": dtK.DrawDot(e); break;
                    case "EraserK": dtK.Eraser(e); break;
                    default:
                        string s = sTypeK.Substring(0, sTypeK.Length - 1);
                        dtK.Draw(e, sTypeK.Substring(0,sTypeK.Length-1));
                        break;
                }
            }
        }

        private void pbImgH_MouseMove(object sender, MouseEventArgs e)
        {
            Thread.Sleep(6);//减少cpu占用率
            if (dtH.startDraw)
            {
                switch (sTypeH)
                {
                    case "DotH": dtH.DrawDot(e); break;
                    case "EraserH": dtH.Eraser(e); break;
                    default: dtH.Draw(e, sTypeH.Substring(0, sTypeH.Length - 1)); break;
                }
            }
        }

        //pbimg＂鼠标松开＂事件处理方法
        private void pbImgK_MouseUp(object sender, MouseEventArgs e)
        {
            if (dtK != null)
            {
                dtK.EndDraw();
            }
        }
        private void pbImgH_MouseUp(object sender, MouseEventArgs e)
        {
            if (dtH != null)
            {
                dtH.EndDraw();
            }
        }
        //处理后的位图变量
        private Bitmap pic_dest;
        //处理前的位图变量
        private Bitmap pic_src;

        public string PoleID
        {
            get
            {
                return poleID;
            }

            set
            {
                poleID = value;
            }
        }

        public string PoleLoop
        {
            get
            {
                return poleLoop;
            }

            set
            {
                poleLoop = value;
            }
        }

        private void zoomInK_Click(object sender, EventArgs e)
        {

        }

        private void zoomOutK_Click(object sender, EventArgs e)
        {

        }
    }
}
