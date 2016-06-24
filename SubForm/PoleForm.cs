using HRQ.Modules;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace HRQ.SubForm
{
    public partial class PoleForm : DevExpress.XtraEditors.XtraForm
    {
        //处理后的位图变量
        private Bitmap pic_dest;
        //处理前的位图变量
        private Bitmap pic_src;

        private Image current_Image;


        //位图备份
        private Bitmap pic_backup;
        private Bitmap linshibeifen1;
        private Bitmap linshibeifen2;
        private Bitmap linshibeifen3;

        //位图路径
        private string pic_path;

        private Color current_color;
        private int current_SelectedItem;
        private int current_X;
        private int current_Y;
        private System.Drawing.Font current_zt;

        private bool bl;
        private int bssize;

        private PoleAttribute pa = null;
        private string imgPath = "";
        List<string> dirsH = null;
        List<string> dirsK = null;
        private int picNO = 0;
        public PoleForm(PoleAttribute pa)
        {
            this.pa = pa;
            InitializeComponent();
            this.Load += PoleForm_Load;
        }

        private void PoleForm_Load(object sender, System.EventArgs e)
        {
            directoryFile();

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            this.tePoleNO.Text = pa.ID;

            init();
        }

        private void init()
        {
            panel_p.AutoScroll = true;
            panel_p.VerticalScroll.Visible = true;

            current_SelectedItem = 0;
            current_color = Color.Yellow;
            bl = true;
            bssize = 1;
            current_X = 0;
            current_Y = 0;

            panel_p.HorizontalScroll.Visible = true;

            //存储文件路径
            pic_path = dirsK[picNO];
            //处理为源图像
            pic_src = new System.Drawing.Bitmap(pic_path);
            current_Image = pic_src;
            //留作备份
            pic_backup = new System.Drawing.Bitmap(pic_src);

            //调入picture box显示

            pictureBox_main.Image = pic_src;
            pictureBox_main.Height = pic_src.Height;
            pictureBox_main.Width = pic_src.Width;
        }

        private void sbJJUpload_Click(object sender, System.EventArgs e)
        {
            //金具
            if (xtcFault.SelectedTabPageIndex == 0 && cbeJJFaultClass.SelectedIndex > -1 && cbeJJFaultType.SelectedIndex > -1)
            {
                rtbDesc.Text += "金具故障中" + cbeJJFaultClass.Text + cbeJJFaultType.Text + "。\n";
            }
            //绝缘子
            if (xtcFault.SelectedTabPageIndex == 1 && cbeJYZFaultClass.SelectedIndex > -1 && cbeJYZFaultType.SelectedIndex > -1)
            {
                rtbDesc.Text += "绝缘子故障中" + cbeJYZFaultClass.Text + cbeJYZFaultType.Text + "。\n";
            }
            //杆塔
            if (xtcFault.SelectedTabPageIndex == 2 &&  cbeGTFaultType.SelectedIndex > -1)
            {
                rtbDesc.Text += "杆塔故障中" + cbeGTFaultType.Text + "。\n";
            }
            //基础
            if (xtcFault.SelectedTabPageIndex == 3 && cbeJCFaultType.SelectedIndex > -1)
            {
                rtbDesc.Text += "基础故障中" + cbeJCFaultType.Text + "。\n";
            }
            //接地
            if (xtcFault.SelectedTabPageIndex == 4 && cbeJDFaultType.SelectedIndex > -1)
            {
                rtbDesc.Text += "接地故障中" + cbeJDFaultType.Text + "。\n";
            }
        }

        private void sbFaultSave_Click(object sender, System.EventArgs e)
        {
            string appPath = HRQ.App.GetInstance().SystemFoldPath;
            //ID
            string ID = pa.ID;
            //FPATH
            string FPath = dirsK[picNO].Substring(appPath.Length + 1, dirsK[picNO].Length - appPath.Length - 1);
            //FPOSITION
            string FPosition = this.tePoleNO.Text + "号杆塔在第"
                + cbeJJLoop.Text + "回路，第" + cbeJJPlug.Text + "相"
                + cbeJJPosition.Text + "位置";
            //FCLASS
            //string FClass = cbeJJFaultClass.Text;
            //FDESC
            string FDesc = rtbDesc.Text;
            //FTIME
            string FTime = HRQ.App.GetInstance().InspectionTime;

            string condition = "'" + ID + "','" + FPath + "','" + FPosition + "','" + FDesc + "','" + FTime + "'";

            HRQ.Utils.DBOperation.UpdatePoleFault(condition);

            //Save Image
            string errImgPath = HRQ.App.GetInstance().SystemFoldPath + "//" + pa.ID + "//" + (cbeJJLoop.SelectedIndex + 1) + "//e";
            if (Directory.Exists(errImgPath) == false)//如果不存在就创建file文件夹
            {
                Directory.CreateDirectory(errImgPath);
            }
            if (pictureBox_main.Image != null)
            {
                Image im = this.pictureBox_main.Image;

                Bitmap bit = new Bitmap(im);
                bit.Save(errImgPath+"//"+Path.GetFileName(pic_path), System.Drawing.Imaging.ImageFormat.Bmp);
            }
            else
            {
                MessageBox.Show("没有图像！");
            }
        }
        //-----------------------------------------------------------------------------------------
        private void directoryFile()
        {
            string dirPath = App.GetInstance().SystemFoldPath + "\\" + this.pa.ID + "\\"+(cbeJJLoop.SelectedIndex+1);
            try
            {
                dirsK = new List<string>(Directory.GetFiles(dirPath + "\\k", "*.JPG", System.IO.SearchOption.TopDirectoryOnly));
                dirsH = new List<string>(Directory.GetFiles(dirPath + "\\h", "*.JPG", System.IO.SearchOption.TopDirectoryOnly));
            }
            catch (Exception e)
            {
            }
        }

        private void pictureBox_main_MouseDown(object sender, MouseEventArgs e)
        {
            bl = true;


            if (pictureBox_main.Image == null)
            {
                Bitmap bm = new Bitmap(400, 300);// 新建一个 Bitmap 位图
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bm); // 根据新建的 Bitmap 位图，创建画布
                g.Clear(System.Drawing.Color.White);// 使用白色重置画布
                pictureBox_main.Image = bm;
                pic_src = new Bitmap(pictureBox_main.Image);
                #region 直方图
                #endregion
            }


            #region 画点


            if (current_SelectedItem == 1)
            {

                Graphics g1 = pictureBox_main.CreateGraphics();

                Graphics g = Graphics.FromImage(pic_src);


                //创建画板,这里的画板是由Form提供的.

                System.Drawing.Point DownPoint = new System.Drawing.Point(e.X, e.Y);//保存鼠标按下坐标

                Pen p = new Pen(current_color, 1);//义了一个蓝色,宽度为的画笔

                g.DrawLine(p, e.X, e.Y, e.X + 1, e.Y);//在画板上画直线,


                pictureBox_main.Image = pic_src;

            }

            #endregion



            current_X = e.X;
            current_Y = e.Y;

        }

        private void button_xzys_Click(object sender, EventArgs e)
        {
            colorDialog_sy.ShowDialog();
            pictureBox_xuanzheyanshe.BackColor = colorDialog_sy.Color;
            current_color = colorDialog_sy.Color;
            richTextBox_zt.ForeColor = colorDialog_sy.Color;

        }

        private void pictureBox_xuanzheyanshe_Click(object sender, EventArgs e)
        {
            //current_color = pictureBox_xuanzheyanshe.BackColor;
            colorDialog_sy.ShowDialog();
            pictureBox_xuanzheyanshe.BackColor = colorDialog_sy.Color;
            current_color = colorDialog_sy.Color;
            richTextBox_zt.ForeColor = colorDialog_sy.Color;
        }

        private void toolStripButton_xiezi_Click_1(object sender, EventArgs e)
        {
            current_SelectedItem = 1;
            this.Cursor = Cursors.Cross;
        }


        private void pictureBox_main_MouseMove(object sender, MouseEventArgs e)
        {

            #region 画xiang


            if (bl)
            {
                if (current_SelectedItem == 1)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        Graphics g1 = pictureBox_main.CreateGraphics();

                        Graphics g = Graphics.FromImage(pic_src);


                        //创建画板,这里的画板是由Form提供的.

                        Pen p = new Pen(current_color);
                        for (int i = 0; i <= bssize; i++)
                            g.DrawLine(p, current_X + i, current_Y + i, e.X + i, e.Y + i);



                        current_X = e.X;
                        current_Y = e.Y;

                        pictureBox_main.Image = pic_src;

                    }

                }
            }

            #endregion

            #region 画zi线
            if (current_SelectedItem == 2)
            {
                Graphics g = Graphics.FromImage(pic_src);
                //创建画板,这里的画板是由Form提供的.
                Pen p = new Pen(current_color);

                pictureBox_main.Image = pic_src;

            }

            #endregion

            #region 画矩形
            if (current_SelectedItem == 3)
            {

                Graphics g = Graphics.FromImage(pic_src);


                //创建画板,这里的画板是由Form提供的.

                Pen p = new Pen(current_color);


                pictureBox_main.Image = pic_src;


            }

            #endregion

            #region 画实体矩形
            if (current_SelectedItem == 4)
            {

                Graphics g = Graphics.FromImage(pic_src);


                //创建画板,这里的画板是由Form提供的.

                Pen p = new Pen(current_color);


                pictureBox_main.Image = pic_src;


            }

            #endregion

            #region 画椭圆
            if (current_SelectedItem == 5)
            {

                Graphics g = Graphics.FromImage(pic_src);


                //创建画板,这里的画板是由Form提供的.

                Pen p = new Pen(current_color);


                pictureBox_main.Image = pic_src;


            }
            #endregion

            #region 画实体椭圆
            if (current_SelectedItem == 6)
            {

                Graphics g = Graphics.FromImage(pic_src);


                //创建画板,这里的画板是由Form提供的.

                Pen p = new Pen(current_color);


                pictureBox_main.Image = pic_src;


            }
            #endregion

            #region 写字
            if (current_SelectedItem == 8)
            {

                Graphics g = Graphics.FromImage(pic_src);


                //创建画板,这里的画板是由Form提供的.

                Pen p = new Pen(current_color);

                Brush b = new SolidBrush(current_color);

                //  g.DrawString(richTextBox_zt.Text, richTextBox_zt.Font, b,e.X,e.Y);

                current_X = e.X;
                current_Y = e.Y;

                pictureBox_main.Image = pic_src;


            }

            #endregion

            #region 橡皮

            if (bl)
            {
                if (current_SelectedItem == 7)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        Graphics g1 = pictureBox_main.CreateGraphics();

                        Graphics g = Graphics.FromImage(pic_src);


                        //创建画板,这里的画板是由Form提供的.

                        Pen p = new Pen(current_color);

                        g.FillRectangle(new SolidBrush(Color.White), e.X, e.Y, 20, 20);



                        current_X = e.X;
                        current_Y = e.Y;

                        pictureBox_main.Image = pic_src;

                    }

                }
            }

            #endregion

        }

        private void pictureBox_main_MouseUp(object sender, MouseEventArgs e)
        {

            bl = false;

            #region huazxian
            if (current_SelectedItem == 2)
            {

                Graphics g = Graphics.FromImage(pic_src);


                //创建画板,这里的画板是由Form提供的.

                Pen p = new Pen(current_color);

                g.DrawLine(p, current_X, current_Y, e.X, e.Y);


                current_X = e.X;
                current_Y = e.Y;

            }

            #endregion

            #region 画矩形
            if (current_SelectedItem == 3)
            {

                Graphics g = Graphics.FromImage(pic_src);


                //创建画板,这里的画板是由Form提供的.

                Pen p = new Pen(current_color);
                if (e.Button == MouseButtons.Left)
                {
                    g.DrawRectangle(p, current_X, current_Y, e.X - current_X, e.Y - current_Y);

                }


                current_X = e.X;
                current_Y = e.Y;




            }

            #endregion

            #region 画实体矩形
            if (current_SelectedItem == 4)
            {

                Graphics g = Graphics.FromImage(pic_src);


                //创建画板,这里的画板是由Form提供的.


                Brush b = new SolidBrush(current_color);

                if (e.Button == MouseButtons.Left)
                {
                    g.FillRectangle(b, current_X, current_Y, e.X - current_X, e.Y - current_Y);

                }


                current_X = e.X;
                current_Y = e.Y;




            }

            #endregion

            #region 画椭圆
            if (current_SelectedItem == 5)
            {

                Graphics g = Graphics.FromImage(pic_src);


                //创建画板,这里的画板是由Form提供的.

                Pen p = new Pen(current_color);
                if (e.Button == MouseButtons.Left)
                {
                    g.DrawEllipse(p, current_X, current_Y, e.X - current_X, e.Y - current_Y);

                }


                current_X = e.X;
                current_Y = e.Y;




            }
            #endregion

            #region 画实体椭圆
            if (current_SelectedItem == 6)
            {

                Graphics g = Graphics.FromImage(pic_src);


                //创建画板,这里的画板是由Form提供的.


                Brush b = new SolidBrush(current_color);

                if (e.Button == MouseButtons.Left)
                {
                    g.FillEllipse(b, current_X, current_Y, e.X - current_X, e.Y - current_Y);

                }


                current_X = e.X;
                current_Y = e.Y;




            }

            #endregion

            #region 写字
            if (current_SelectedItem == 8)
            {

                Graphics g = Graphics.FromImage(pic_src);


                //创建画板,这里的画板是由Form提供的.

                Pen p = new Pen(current_color);

                Brush b = new SolidBrush(current_color);

                g.DrawString(richTextBox_zt.Text, richTextBox_zt.Font, b, e.X, e.Y);

                current_X = e.X;
                current_Y = e.Y;

            }

            #endregion

        }
        private void button_bsbd_Click(object sender, EventArgs e)
        {
            if (bssize < 100)
            {
                bssize++;

            }
            else
            {
                bssize = 1;
            }
        }

        private void button_bsbx_Click(object sender, EventArgs e)
        {
            if (bssize > 0)
            {
                bssize--;
            }
            else
            {
                bssize = 1;
            }
        }

        private void toolStripButton_line_Click(object sender, EventArgs e)
        {
            current_SelectedItem = 2;
            this.Cursor = Cursors.Cross;
        }

        private void toolStripButton_rect_Click(object sender, EventArgs e)
        {
            current_SelectedItem = 3;
            this.Cursor = Cursors.Cross;
        }
        private void toolStripButton_Circle_Click(object sender, EventArgs e)
        {
            current_SelectedItem = 5;
            this.Cursor = Cursors.Cross;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            current_SelectedItem = 8;
            this.Cursor = Cursors.Cross;
        }

        private void toolStripButton_eraser_Click(object sender, EventArgs e)
        {
            current_SelectedItem = 7;
            this.Cursor = new Cursor(System.Windows.Forms.Application.StartupPath + @"\img\pb.cur");

        }

        private void toolStripButton_fangda_Click(object sender, EventArgs e)
        {
            int Height = this.pictureBox_main.Image.Height;

            int Width = this.pictureBox_main.Image.Width;
            if ((Height < 3000) || (Width < 3000))
            {

                Bitmap bm = (Bitmap)this.pictureBox_main.Image;

                int w = (int)(Width * 1.1);
                int h = (int)(Height * 1.1);
                Bitmap bm1 = new Bitmap(bm, w, h);

                pictureBox_main.Width = w;
                pictureBox_main.Height = h;
                pictureBox_main.Image = bm1;
                pic_src = bm1;

            }
            else
            {
                MessageBox.Show("图片已经是最大了");
            }
        }

        private void toolStripButton_suoixao_Click(object sender, EventArgs e)
        {
            int Height = this.pictureBox_main.Image.Height;

            int Width = this.pictureBox_main.Image.Width;
            if ((Height > 50) && (Width > 50))
            {
                Bitmap bm = (Bitmap)this.pictureBox_main.Image;
                int w = (int)(Width * 0.8);
                int h = (int)(Height * 0.8);
                Bitmap bm1 = new Bitmap(bm, w, h);

                pictureBox_main.Width = w;
                pictureBox_main.Height = h;
                pictureBox_main.Image = bm1;
                pic_src = bm1;
            }
            else
            {
                MessageBox.Show("图片已经是最小了");
            }
        }

        private void tsbPrev_Click(object sender, EventArgs e)
        {
            var picN = picNO - 1;
            if (picN >= 0)
            {
                init();
                picNO--;
            }
        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
            var picN = picNO + 1;
            if (picN <= dirsK.Count - 1)
            {
                init();
                picNO++;
            }
        }

        private void sbFaultExport_Click(object sender, EventArgs e)
        {
            CreateWordFile();
            //_Application app = new Microsoft.Office.Interop.Word.Application();
            //string tAppRoot = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            //string tProjectUrl = Path.Combine(tAppRoot, @"DocModel\"+pa.ID+".docx");
            ////app.Documents.Open(tProjectUrl);

            //System.Diagnostics.Process proc = new System.Diagnostics.Process();
            //proc.EnableRaisingEvents = false;
            //proc.StartInfo.FileName = "winword";
            //proc.StartInfo.Arguments = tProjectUrl;
            //proc.Start();
        }

        public string CreateWordFile()
        {
            string message = "";
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();

                //设置文件类型 
                sfd.Filter = "word文件（*.doc）|*.doc";
                //设置默认文件类型显示顺序 
                sfd.FilterIndex = 1;
                //保存对话框是否记忆上次打开的目录 
                sfd.RestoreDirectory = true;
                //点了保存按钮进入 
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string localFilePath = sfd.FileName.ToString(); //获得文件路径 
                    string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径

                    Object Nothing = System.Reflection.Missing.Value;
                    //Directory.CreateDirectory("C:/CNSI");  //创建文件所在目录
                    string name = fileNameExt;
                    object filename = localFilePath;  //文件保存路径
                                                            //创建Word文档
                    Microsoft.Office.Interop.Word.Application WordApp = new Microsoft.Office.Interop.Word.Application();
                    Microsoft.Office.Interop.Word.Document WordDoc = WordApp.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);

                    //添加页眉
                    WordApp.ActiveWindow.View.Type = WdViewType.wdOutlineView;
                    WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekPrimaryHeader;
                    WordApp.ActiveWindow.ActivePane.Selection.InsertAfter("NEW3S");
                    WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;//设置右对齐
                    WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekMainDocument;//跳出页眉设置

                    WordApp.Selection.ParagraphFormat.LineSpacing = 15f;//设置文档的行间距

                    //移动焦点并换行
                    object count = 14;
                    object WdLine = Microsoft.Office.Interop.Word.WdUnits.wdLine;//换一行;
                    WordApp.Selection.MoveDown(ref WdLine, ref count, ref Nothing);//移动焦点
                    WordApp.Selection.TypeParagraph();//插入段落

                    //文档中创建表格
                    Microsoft.Office.Interop.Word.Table newTable = WordDoc.Tables.Add(WordApp.Selection.Range, 12, 3, ref Nothing, ref Nothing);
                    //设置表格样式
                    newTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleThickThinLargeGap;
                    newTable.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                    newTable.Columns[1].Width = 100f;
                    newTable.Columns[2].Width = 220f;
                    newTable.Columns[3].Width = 105f;

                    //填充表格内容
                    newTable.Cell(1, 1).Range.Text = "产品详细信息表";
                    newTable.Cell(1, 1).Range.Bold = 2;//设置单元格中字体为粗体
                                                       //合并单元格
                    newTable.Cell(1, 1).Merge(newTable.Cell(1, 3));
                    WordApp.Selection.Cells.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;//垂直居中
                    WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;//水平居中

                    //填充表格内容
                    newTable.Cell(2, 1).Range.Text = "产品基本信息";
                    newTable.Cell(2, 1).Range.Font.Color = Microsoft.Office.Interop.Word.WdColor.wdColorDarkBlue;//设置单元格内字体颜色
                                                                                                                 //合并单元格
                    newTable.Cell(2, 1).Merge(newTable.Cell(2, 3));
                    WordApp.Selection.Cells.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                    //填充表格内容
                    newTable.Cell(3, 1).Range.Text = "品牌名称：";
                    newTable.Cell(3, 2).Range.Text = "BrandName";
                    //纵向合并单元格
                    newTable.Cell(3, 3).Select();//选中一行
                    object moveUnit = Microsoft.Office.Interop.Word.WdUnits.wdLine;
                    object moveCount = 5;
                    object moveExtend = Microsoft.Office.Interop.Word.WdMovementType.wdExtend;
                    WordApp.Selection.MoveDown(ref moveUnit, ref moveCount, ref moveExtend);
                    WordApp.Selection.Cells.Merge();
                    //插入图片
                    string FileName = @"c:\picture.jpg";//图片所在路径
                    object LinkToFile = false;
                    object SaveWithDocument = true;
                    object Anchor = WordDoc.Application.Selection.Range;
                    WordDoc.Application.ActiveDocument.InlineShapes.AddPicture(FileName, ref LinkToFile, ref SaveWithDocument, ref Anchor);
                    WordDoc.Application.ActiveDocument.InlineShapes[1].Width = 100f;//图片宽度
                    WordDoc.Application.ActiveDocument.InlineShapes[1].Height = 100f;//图片高度
                                                                                     //将图片设置为四周环绕型
                    Microsoft.Office.Interop.Word.Shape s = WordDoc.Application.ActiveDocument.InlineShapes[1].ConvertToShape();
                    s.WrapFormat.Type = Microsoft.Office.Interop.Word.WdWrapType.wdWrapSquare;

                    newTable.Cell(12, 1).Range.Text = "产品特殊属性";
                    newTable.Cell(12, 1).Merge(newTable.Cell(12, 3));
                    //在表格中增加行
                    WordDoc.Content.Tables[1].Rows.Add(ref Nothing);

                    WordDoc.Paragraphs.Last.Range.Text = "文档创建时间：" + DateTime.Now.ToString();//“落款”
                    WordDoc.Paragraphs.Last.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;

                    //文件保存
                    WordDoc.SaveAs(ref filename, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing);
                    WordDoc.Close(ref Nothing, ref Nothing, ref Nothing);
                    WordApp.Quit(ref Nothing, ref Nothing, ref Nothing);
                    message = name + "文档生成成功，以保存到C:CNSI下";
                    //获取文件路径，不带文件名 
                    //FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\"));

                    //给文件名前加上时间 
                    //newFileName = DateTime.Now.ToString("yyyyMMdd") + fileNameExt;

                    //在文件名里加字符 
                    //saveFileDialog1.FileName.Insert(1,"dameng");

                    //System.IO.FileStream fs = (System.IO.FileStream)sfd.OpenFile();//输出文件

                    ////fs输出带文字或图片的文件，就看需求了 
                }

                
            }
            catch
            {
                message = "文件导出异常！";
            }
            return message;
        }

        private void cbeFaultClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}