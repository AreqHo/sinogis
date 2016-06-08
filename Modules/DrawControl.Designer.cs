namespace HRQ.Modules
{
    partial class DrawControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbImgK = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.colorHatch1 = new ColorHatch.ColorHatch();
            this.DrawtoolStripK = new System.Windows.Forms.ToolStrip();
            this.LineK = new System.Windows.Forms.ToolStripButton();
            this.DotK = new System.Windows.Forms.ToolStripButton();
            this.RectK = new System.Windows.Forms.ToolStripButton();
            this.CircleK = new System.Windows.Forms.ToolStripButton();
            this.EraserK = new System.Windows.Forms.ToolStripButton();
            this.saveK = new System.Windows.Forms.ToolStripButton();
            this.zoomOutK = new System.Windows.Forms.ToolStripButton();
            this.zoomInK = new System.Windows.Forms.ToolStripButton();
            this.prevK = new System.Windows.Forms.ToolStripButton();
            this.nextK = new System.Windows.Forms.ToolStripButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pbImgH = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.colorHatch2 = new ColorHatch.ColorHatch();
            this.DrawtoolStripH = new System.Windows.Forms.ToolStrip();
            this.LineH = new System.Windows.Forms.ToolStripButton();
            this.DotH = new System.Windows.Forms.ToolStripButton();
            this.RectH = new System.Windows.Forms.ToolStripButton();
            this.CircleH = new System.Windows.Forms.ToolStripButton();
            this.EraserH = new System.Windows.Forms.ToolStripButton();
            this.saveH = new System.Windows.Forms.ToolStripButton();
            this.zoomOutH = new System.Windows.Forms.ToolStripButton();
            this.zoomInH = new System.Windows.Forms.ToolStripButton();
            this.prevH = new System.Windows.Forms.ToolStripButton();
            this.nextH = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImgK)).BeginInit();
            this.panel1.SuspendLayout();
            this.DrawtoolStripK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImgH)).BeginInit();
            this.panel3.SuspendLayout();
            this.DrawtoolStripH.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(669, 630);
            this.splitContainerControl1.SplitterPosition = 465;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.panel2);
            this.groupControl1.Controls.Add(this.panel1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(669, 465);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "可见光";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Controls.Add(this.pbImgK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panel2.Location = new System.Drawing.Point(62, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(605, 442);
            this.panel2.TabIndex = 13;
            // 
            // pbImgK
            // 
            this.pbImgK.BackColor = System.Drawing.Color.White;
            this.pbImgK.Location = new System.Drawing.Point(0, 0);
            this.pbImgK.Name = "pbImgK";
            this.pbImgK.Size = new System.Drawing.Size(372, 325);
            this.pbImgK.TabIndex = 0;
            this.pbImgK.TabStop = false;
            this.pbImgK.Paint += new System.Windows.Forms.PaintEventHandler(this.pbImgK_Paint);
            this.pbImgK.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbImgK_MouseDown);
            this.pbImgK.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbImgK_MouseMove);
            this.pbImgK.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbImgK_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.colorHatch1);
            this.panel1.Controls.Add(this.DrawtoolStripK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Location = new System.Drawing.Point(2, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(60, 442);
            this.panel1.TabIndex = 12;
            // 
            // colorHatch1
            // 
            this.colorHatch1.Dock = System.Windows.Forms.DockStyle.Top;
            this.colorHatch1.HatchColor = System.Drawing.Color.Red;
            this.colorHatch1.Location = new System.Drawing.Point(0, 120);
            this.colorHatch1.Name = "colorHatch1";
            this.colorHatch1.Size = new System.Drawing.Size(58, 295);
            this.colorHatch1.TabIndex = 2;
            // 
            // DrawtoolStripK
            // 
            this.DrawtoolStripK.AutoSize = false;
            this.DrawtoolStripK.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LineK,
            this.DotK,
            this.RectK,
            this.CircleK,
            this.EraserK,
            this.saveK,
            this.zoomOutK,
            this.zoomInK,
            this.prevK,
            this.nextK});
            this.DrawtoolStripK.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.DrawtoolStripK.Location = new System.Drawing.Point(0, 0);
            this.DrawtoolStripK.Name = "DrawtoolStripK";
            this.DrawtoolStripK.Padding = new System.Windows.Forms.Padding(7, 0, 1, 0);
            this.DrawtoolStripK.Size = new System.Drawing.Size(58, 120);
            this.DrawtoolStripK.TabIndex = 0;
            this.DrawtoolStripK.Text = "toolStrip1";
            // 
            // LineK
            // 
            this.LineK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LineK.Image = global::HRQ.Properties.Resources.line;
            this.LineK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LineK.Name = "LineK";
            this.LineK.Size = new System.Drawing.Size(23, 20);
            this.LineK.Text = "直线";
            this.LineK.Click += new System.EventHandler(this.toolK_Click);
            // 
            // DotK
            // 
            this.DotK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DotK.Image = global::HRQ.Properties.Resources.Pencil;
            this.DotK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DotK.Name = "DotK";
            this.DotK.Size = new System.Drawing.Size(23, 20);
            this.DotK.Text = "铅笔";
            this.DotK.Click += new System.EventHandler(this.toolK_Click);
            // 
            // RectK
            // 
            this.RectK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RectK.Image = global::HRQ.Properties.Resources.rect;
            this.RectK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RectK.Name = "RectK";
            this.RectK.Size = new System.Drawing.Size(23, 20);
            this.RectK.Text = "空心矩形";
            this.RectK.Click += new System.EventHandler(this.toolK_Click);
            // 
            // CircleK
            // 
            this.CircleK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CircleK.Image = global::HRQ.Properties.Resources.Circle1;
            this.CircleK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CircleK.Name = "CircleK";
            this.CircleK.Size = new System.Drawing.Size(23, 20);
            this.CircleK.Text = "空心圆";
            this.CircleK.Click += new System.EventHandler(this.toolK_Click);
            // 
            // EraserK
            // 
            this.EraserK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EraserK.Image = global::HRQ.Properties.Resources.eraser1;
            this.EraserK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EraserK.Name = "EraserK";
            this.EraserK.Size = new System.Drawing.Size(23, 20);
            this.EraserK.Text = "橡皮";
            // 
            // saveK
            // 
            this.saveK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveK.Image = global::HRQ.Properties.Resources.Save_16x16;
            this.saveK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveK.Name = "saveK";
            this.saveK.Size = new System.Drawing.Size(23, 20);
            this.saveK.Text = "toolStripButton1";
            this.saveK.ToolTipText = "保存";
            // 
            // zoomOutK
            // 
            this.zoomOutK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomOutK.Image = global::HRQ.Properties.Resources.zoomout24;
            this.zoomOutK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomOutK.Name = "zoomOutK";
            this.zoomOutK.Size = new System.Drawing.Size(23, 20);
            this.zoomOutK.Text = "toolStripButton1";
            this.zoomOutK.ToolTipText = "缩小";
            // 
            // zoomInK
            // 
            this.zoomInK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomInK.Image = global::HRQ.Properties.Resources.zoomin24;
            this.zoomInK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomInK.Name = "zoomInK";
            this.zoomInK.Size = new System.Drawing.Size(23, 20);
            this.zoomInK.Text = "toolStripButton1";
            this.zoomInK.ToolTipText = "放大";
            // 
            // prevK
            // 
            this.prevK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.prevK.Image = global::HRQ.Properties.Resources.arrowleft24;
            this.prevK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.prevK.Name = "prevK";
            this.prevK.Size = new System.Drawing.Size(23, 20);
            this.prevK.Text = "toolStripButton1";
            this.prevK.ToolTipText = "上一张";
            this.prevK.Click += new System.EventHandler(this.toolK_Click);
            // 
            // nextK
            // 
            this.nextK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nextK.Image = global::HRQ.Properties.Resources.arrowright24;
            this.nextK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nextK.Name = "nextK";
            this.nextK.Size = new System.Drawing.Size(23, 20);
            this.nextK.Text = "toolStripButton1";
            this.nextK.ToolTipText = "下一张";
            this.nextK.Click += new System.EventHandler(this.toolK_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.panel4);
            this.groupControl2.Controls.Add(this.panel3);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(669, 160);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "红外";
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel4.Controls.Add(this.pbImgH);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panel4.Location = new System.Drawing.Point(62, 21);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(605, 137);
            this.panel4.TabIndex = 13;
            // 
            // pbImgH
            // 
            this.pbImgH.BackColor = System.Drawing.Color.White;
            this.pbImgH.Location = new System.Drawing.Point(0, 0);
            this.pbImgH.Name = "pbImgH";
            this.pbImgH.Size = new System.Drawing.Size(372, 325);
            this.pbImgH.TabIndex = 0;
            this.pbImgH.TabStop = false;
            this.pbImgH.Paint += new System.Windows.Forms.PaintEventHandler(this.pbImgH_Paint);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.colorHatch2);
            this.panel3.Controls.Add(this.DrawtoolStripH);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panel3.Location = new System.Drawing.Point(2, 21);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(60, 137);
            this.panel3.TabIndex = 12;
            // 
            // colorHatch2
            // 
            this.colorHatch2.Dock = System.Windows.Forms.DockStyle.Top;
            this.colorHatch2.HatchColor = System.Drawing.Color.Red;
            this.colorHatch2.Location = new System.Drawing.Point(0, 120);
            this.colorHatch2.Name = "colorHatch2";
            this.colorHatch2.Size = new System.Drawing.Size(58, 217);
            this.colorHatch2.TabIndex = 2;
            // 
            // DrawtoolStripH
            // 
            this.DrawtoolStripH.AutoSize = false;
            this.DrawtoolStripH.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LineH,
            this.DotH,
            this.RectH,
            this.CircleH,
            this.EraserH,
            this.saveH,
            this.zoomOutH,
            this.zoomInH,
            this.prevH,
            this.nextH});
            this.DrawtoolStripH.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.DrawtoolStripH.Location = new System.Drawing.Point(0, 0);
            this.DrawtoolStripH.Name = "DrawtoolStripH";
            this.DrawtoolStripH.Padding = new System.Windows.Forms.Padding(7, 0, 1, 0);
            this.DrawtoolStripH.Size = new System.Drawing.Size(58, 120);
            this.DrawtoolStripH.TabIndex = 0;
            this.DrawtoolStripH.Text = "toolStrip1";
            // 
            // LineH
            // 
            this.LineH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LineH.Image = global::HRQ.Properties.Resources.line;
            this.LineH.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LineH.Name = "LineH";
            this.LineH.Size = new System.Drawing.Size(23, 20);
            this.LineH.Text = "直线";
            this.LineH.Click += new System.EventHandler(this.toolH_Click);
            // 
            // DotH
            // 
            this.DotH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DotH.Image = global::HRQ.Properties.Resources.Pencil;
            this.DotH.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DotH.Name = "DotH";
            this.DotH.Size = new System.Drawing.Size(23, 20);
            this.DotH.Text = "铅笔";
            this.DotH.Click += new System.EventHandler(this.toolH_Click);
            // 
            // RectH
            // 
            this.RectH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RectH.Image = global::HRQ.Properties.Resources.rect;
            this.RectH.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RectH.Name = "RectH";
            this.RectH.Size = new System.Drawing.Size(23, 20);
            this.RectH.Text = "空心矩形";
            this.RectH.Click += new System.EventHandler(this.toolH_Click);
            // 
            // CircleH
            // 
            this.CircleH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CircleH.Image = global::HRQ.Properties.Resources.Circle1;
            this.CircleH.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CircleH.Name = "CircleH";
            this.CircleH.Size = new System.Drawing.Size(23, 20);
            this.CircleH.Text = "空心圆";
            this.CircleH.Click += new System.EventHandler(this.toolH_Click);
            // 
            // EraserH
            // 
            this.EraserH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EraserH.Image = global::HRQ.Properties.Resources.eraser1;
            this.EraserH.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EraserH.Name = "EraserH";
            this.EraserH.Size = new System.Drawing.Size(23, 20);
            this.EraserH.Text = "橡皮";
            // 
            // saveH
            // 
            this.saveH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveH.Image = global::HRQ.Properties.Resources.Save_16x16;
            this.saveH.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveH.Name = "saveH";
            this.saveH.Size = new System.Drawing.Size(23, 20);
            this.saveH.Text = "toolStripButton1";
            this.saveH.ToolTipText = "保存";
            // 
            // zoomOutH
            // 
            this.zoomOutH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomOutH.Image = global::HRQ.Properties.Resources.zoomout24;
            this.zoomOutH.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomOutH.Name = "zoomOutH";
            this.zoomOutH.Size = new System.Drawing.Size(23, 20);
            this.zoomOutH.Text = "toolStripButton1";
            this.zoomOutH.ToolTipText = "缩小";
            // 
            // zoomInH
            // 
            this.zoomInH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomInH.Image = global::HRQ.Properties.Resources.zoomin24;
            this.zoomInH.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomInH.Name = "zoomInH";
            this.zoomInH.Size = new System.Drawing.Size(23, 20);
            this.zoomInH.Text = "toolStripButton1";
            this.zoomInH.ToolTipText = "放大";
            // 
            // prevH
            // 
            this.prevH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.prevH.Image = global::HRQ.Properties.Resources.arrowleft24;
            this.prevH.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.prevH.Name = "prevH";
            this.prevH.Size = new System.Drawing.Size(23, 20);
            this.prevH.Text = "toolStripButton1";
            this.prevH.ToolTipText = "上一张";
            this.prevH.Click += new System.EventHandler(this.toolH_Click);
            // 
            // nextH
            // 
            this.nextH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nextH.Image = global::HRQ.Properties.Resources.arrowright24;
            this.nextH.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nextH.Name = "nextH";
            this.nextH.Size = new System.Drawing.Size(23, 20);
            this.nextH.Text = "toolStripButton1";
            this.nextH.ToolTipText = "下一张";
            this.nextH.Click += new System.EventHandler(this.toolH_Click);
            // 
            // DrawControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "DrawControl";
            this.Size = new System.Drawing.Size(669, 630);
            this.Load += new System.EventHandler(this.DrawControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImgK)).EndInit();
            this.panel1.ResumeLayout(false);
            this.DrawtoolStripK.ResumeLayout(false);
            this.DrawtoolStripK.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImgH)).EndInit();
            this.panel3.ResumeLayout(false);
            this.DrawtoolStripH.ResumeLayout(false);
            this.DrawtoolStripH.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbImgK;
        private System.Windows.Forms.Panel panel1;
        private ColorHatch.ColorHatch colorHatch1;
        private System.Windows.Forms.ToolStrip DrawtoolStripK;
        private System.Windows.Forms.ToolStripButton LineK;
        private System.Windows.Forms.ToolStripButton DotK;
        private System.Windows.Forms.ToolStripButton RectK;
        private System.Windows.Forms.ToolStripButton CircleK;
        private System.Windows.Forms.ToolStripButton EraserK;
        private System.Windows.Forms.ToolStripButton saveK;
        private System.Windows.Forms.ToolStripButton zoomOutK;
        private System.Windows.Forms.ToolStripButton zoomInK;
        private System.Windows.Forms.ToolStripButton prevK;
        private System.Windows.Forms.ToolStripButton nextK;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pbImgH;
        private System.Windows.Forms.Panel panel3;
        private ColorHatch.ColorHatch colorHatch2;
        private System.Windows.Forms.ToolStrip DrawtoolStripH;
        private System.Windows.Forms.ToolStripButton LineH;
        private System.Windows.Forms.ToolStripButton DotH;
        private System.Windows.Forms.ToolStripButton RectH;
        private System.Windows.Forms.ToolStripButton CircleH;
        private System.Windows.Forms.ToolStripButton EraserH;
        private System.Windows.Forms.ToolStripButton saveH;
        private System.Windows.Forms.ToolStripButton zoomOutH;
        private System.Windows.Forms.ToolStripButton zoomInH;
        private System.Windows.Forms.ToolStripButton prevH;
        private System.Windows.Forms.ToolStripButton nextH;
    }
}
