using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;

namespace HRQ.SubForm
{
    public partial class ImgEdit : DevExpress.XtraEditors.XtraForm
    {
        private bool isMoving = false;
        private Point mouseDownPosition = Point.Empty;
        private Point mouseMovePosition = Point.Empty;
        private Dictionary<Point, Point> Circles = new Dictionary<Point, Point>();
        private string imgPath = "";
        private Image mImage = null;
        private Image preImage = null;
        public ImgEdit(string _imgPath)
        {
            InitializeComponent();
            this.imgPath = _imgPath;
            preImage = Image.FromFile(_imgPath);
            this.pictureBox1.Image = preImage;
            //this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            //this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            //this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            //this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Red);
            //Graphics gfx = Graphics.FromImage ( this.pictureBox1.Image )
            //var g = Graphics.FromImage(this.pictureBox1.Image);
            var g = e.Graphics;
            //g.DrawImage(
            //            BackgroundImage,
            //            Point.Empty);
            //g.DrawImage(pictureBox1.Image, 0, 0);
            if (isMoving)
            {
                //g.Clear(pictureBox1.BackColor);
                g.DrawEllipse(p, new Rectangle(mouseDownPosition, new Size(mouseMovePosition.X - mouseDownPosition.X, mouseMovePosition.Y - mouseDownPosition.Y)));
                foreach (var circle in Circles)
                {
                    g.DrawEllipse(p, new Rectangle(circle.Key, new Size(circle.Value.X - circle.Key.X, circle.Value.Y - circle.Key.Y)));
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.Cursor = Cursors.Cross;
            isMoving = true;
            mouseDownPosition = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMoving)
            {
                mouseMovePosition = e.Location;
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.Cursor = Cursors.Default;
            if (isMoving)
            {
                Circles.Add(mouseDownPosition, mouseMovePosition);
                DrawLastImage();
            }
            //pictureBox1.Invalidate();
            isMoving = false;
        }

        private void DrawLastImage()
        {
            using (Bitmap allBmp = new Bitmap(
                preImage.Width, preImage.Height, PixelFormat.Format32bppArgb))
            {
                using (Graphics allGraphics = Graphics.FromImage(allBmp))
                {
                    allGraphics.InterpolationMode =
                        InterpolationMode.HighQualityBicubic;
                    allGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                    allGraphics.DrawImage(
                        preImage,
                        Point.Empty);
                    //DrawOperate(allGraphics);
                    Pen p = new Pen(Color.Red);
                    allGraphics.DrawEllipse(p, new Rectangle(Circles.Keys.Last(), new Size(Circles.Last().Value.X - Circles.Last().Key.X, Circles.Last().Value.Y - Circles.Last().Key.Y)));
                    allGraphics.Flush();

                    Bitmap bmp = new Bitmap(
                       preImage.Width,
                       preImage.Height,
                       PixelFormat.Format32bppArgb);
                    Graphics g = Graphics.FromImage(bmp);
                    g.DrawImage(allBmp, Point.Empty);
                    g.Flush();
                    g.Dispose();
                    mImage = bmp;
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Save(imgPath);
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(imgPath);
            string path = imgPath.Split('.')[0] + "-1.jpg";
            mImage.Save(path);
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
        }
    }
}