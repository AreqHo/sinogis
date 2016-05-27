namespace HRQ.Modules
{
    partial class PicControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mousePostion = new System.Windows.Forms.ToolStripStatusLabel();
            this.status = new System.Windows.Forms.StatusStrip();
            this.currentDrawType = new System.Windows.Forms.ToolStripStatusLabel();
            this.prev = new System.Windows.Forms.ToolStripButton();
            this.next = new System.Windows.Forms.ToolStripButton();
            this.zoomIn = new System.Windows.Forms.ToolStripButton();
            this.zoomOut = new System.Windows.Forms.ToolStripButton();
            this.Eraser = new System.Windows.Forms.ToolStripButton();
            this.Circle = new System.Windows.Forms.ToolStripButton();
            this.Rect = new System.Windows.Forms.ToolStripButton();
            this.Dot = new System.Windows.Forms.ToolStripButton();
            this.Line = new System.Windows.Forms.ToolStripButton();
            this.DrawtoolStrip = new System.Windows.Forms.ToolStrip();
            this.save = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.colorHatch1 = new ColorHatch.ColorHatch();
            this.reSize = new System.Windows.Forms.PictureBox();
            this.pbImg = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.status.SuspendLayout();
            this.DrawtoolStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImg)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mousePostion
            // 
            this.mousePostion.Name = "mousePostion";
            this.mousePostion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mousePostion.Size = new System.Drawing.Size(0, 17);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentDrawType,
            this.mousePostion});
            this.status.Location = new System.Drawing.Point(66, 480);
            this.status.Name = "status";
            this.status.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.status.Size = new System.Drawing.Size(563, 22);
            this.status.TabIndex = 9;
            this.status.Text = "statusStrip1";
            // 
            // currentDrawType
            // 
            this.currentDrawType.Name = "currentDrawType";
            this.currentDrawType.Size = new System.Drawing.Size(0, 17);
            // 
            // prev
            // 
            this.prev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.prev.Image = global::HRQ.Properties.Resources.arrowleft24;
            this.prev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.prev.Name = "prev";
            this.prev.Size = new System.Drawing.Size(23, 20);
            this.prev.Text = "toolStripButton1";
            this.prev.ToolTipText = "上一张";
            this.prev.Click += new System.EventHandler(this.tool_Click);
            // 
            // next
            // 
            this.next.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.next.Image = global::HRQ.Properties.Resources.arrowright24;
            this.next.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(23, 20);
            this.next.Text = "toolStripButton1";
            this.next.ToolTipText = "下一张";
            this.next.Click += new System.EventHandler(this.tool_Click);
            // 
            // zoomIn
            // 
            this.zoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomIn.Image = global::HRQ.Properties.Resources.zoomin24;
            this.zoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomIn.Name = "zoomIn";
            this.zoomIn.Size = new System.Drawing.Size(23, 20);
            this.zoomIn.Text = "toolStripButton1";
            this.zoomIn.ToolTipText = "放大";
            this.zoomIn.Click += new System.EventHandler(this.tool_Click);
            // 
            // zoomOut
            // 
            this.zoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomOut.Image = global::HRQ.Properties.Resources.zoomout24;
            this.zoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomOut.Name = "zoomOut";
            this.zoomOut.Size = new System.Drawing.Size(23, 20);
            this.zoomOut.Text = "toolStripButton1";
            this.zoomOut.ToolTipText = "缩小";
            this.zoomOut.Click += new System.EventHandler(this.tool_Click);
            // 
            // Eraser
            // 
            this.Eraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Eraser.Image = global::HRQ.Properties.Resources.eraser1;
            this.Eraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Eraser.Name = "Eraser";
            this.Eraser.Size = new System.Drawing.Size(23, 20);
            this.Eraser.Text = "橡皮";
            this.Eraser.Click += new System.EventHandler(this.tool_Click);
            // 
            // Circle
            // 
            this.Circle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Circle.Image = global::HRQ.Properties.Resources.Circle1;
            this.Circle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Circle.Name = "Circle";
            this.Circle.Size = new System.Drawing.Size(23, 20);
            this.Circle.Text = "空心圆";
            this.Circle.Click += new System.EventHandler(this.tool_Click);
            // 
            // Rect
            // 
            this.Rect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Rect.Image = global::HRQ.Properties.Resources.rect;
            this.Rect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Rect.Name = "Rect";
            this.Rect.Size = new System.Drawing.Size(23, 20);
            this.Rect.Text = "空心矩形";
            this.Rect.Click += new System.EventHandler(this.tool_Click);
            // 
            // Dot
            // 
            this.Dot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Dot.Image = global::HRQ.Properties.Resources.Pencil;
            this.Dot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Dot.Name = "Dot";
            this.Dot.Size = new System.Drawing.Size(23, 20);
            this.Dot.Text = "铅笔";
            this.Dot.Click += new System.EventHandler(this.tool_Click);
            // 
            // Line
            // 
            this.Line.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Line.Image = global::HRQ.Properties.Resources.line;
            this.Line.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Line.Name = "Line";
            this.Line.Size = new System.Drawing.Size(23, 20);
            this.Line.Text = "直线";
            this.Line.Click += new System.EventHandler(this.tool_Click);
            // 
            // DrawtoolStrip
            // 
            this.DrawtoolStrip.AutoSize = false;
            this.DrawtoolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Line,
            this.Dot,
            this.Rect,
            this.Circle,
            this.Eraser,
            this.save,
            this.zoomOut,
            this.zoomIn,
            this.prev,
            this.next});
            this.DrawtoolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.DrawtoolStrip.Location = new System.Drawing.Point(0, 0);
            this.DrawtoolStrip.Name = "DrawtoolStrip";
            this.DrawtoolStrip.Padding = new System.Windows.Forms.Padding(8, 0, 1, 0);
            this.DrawtoolStrip.Size = new System.Drawing.Size(64, 140);
            this.DrawtoolStrip.TabIndex = 0;
            this.DrawtoolStrip.Text = "toolStrip1";
            // 
            // save
            // 
            this.save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.save.Image = global::HRQ.Properties.Resources.Save_16x16;
            this.save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(23, 20);
            this.save.Text = "toolStripButton1";
            this.save.ToolTipText = "保存";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.colorHatch1);
            this.panel1.Controls.Add(this.DrawtoolStrip);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(66, 502);
            this.panel1.TabIndex = 7;
            // 
            // colorHatch1
            // 
            this.colorHatch1.Dock = System.Windows.Forms.DockStyle.Top;
            this.colorHatch1.HatchColor = System.Drawing.Color.Red;
            this.colorHatch1.Location = new System.Drawing.Point(0, 140);
            this.colorHatch1.Name = "colorHatch1";
            this.colorHatch1.Size = new System.Drawing.Size(64, 253);
            this.colorHatch1.TabIndex = 2;
            // 
            // reSize
            // 
            this.reSize.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.reSize.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.reSize.Image = global::HRQ.Properties.Resources.stopzoom;
            this.reSize.Location = new System.Drawing.Point(434, 379);
            this.reSize.Name = "reSize";
            this.reSize.Size = new System.Drawing.Size(17, 17);
            this.reSize.TabIndex = 1;
            this.reSize.TabStop = false;
            this.reSize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.reSize_MouseDown);
            this.reSize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.reSize_MouseMove);
            this.reSize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.reSize_MouseUp);
            // 
            // pbImg
            // 
            this.pbImg.BackColor = System.Drawing.Color.White;
            this.pbImg.Location = new System.Drawing.Point(0, 0);
            this.pbImg.Name = "pbImg";
            this.pbImg.Size = new System.Drawing.Size(434, 379);
            this.pbImg.TabIndex = 0;
            this.pbImg.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Controls.Add(this.reSize);
            this.panel2.Controls.Add(this.pbImg);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(629, 502);
            this.panel2.TabIndex = 8;
            // 
            // PicControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.status);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "PicControl";
            this.Size = new System.Drawing.Size(629, 502);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.DrawtoolStrip.ResumeLayout(false);
            this.DrawtoolStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImg)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel mousePostion;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel currentDrawType;
        private System.Windows.Forms.ToolStripButton prev;
        private System.Windows.Forms.ToolStripButton next;
        private System.Windows.Forms.ToolStripButton zoomIn;
        private System.Windows.Forms.ToolStripButton zoomOut;
        private System.Windows.Forms.ToolStripButton Eraser;
        private System.Windows.Forms.ToolStripButton Circle;
        private System.Windows.Forms.ToolStripButton Rect;
        private System.Windows.Forms.ToolStripButton Dot;
        private System.Windows.Forms.ToolStripButton Line;
        private System.Windows.Forms.ToolStrip DrawtoolStrip;
        private System.Windows.Forms.Panel panel1;
        private ColorHatch.ColorHatch colorHatch1;
        private System.Windows.Forms.PictureBox reSize;
        private System.Windows.Forms.PictureBox pbImg;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripButton save;
    }
}
