namespace HRQ.Modules {
    partial class LineGrid {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridSplitContainer1 = new DevExpress.XtraGrid.GridSplitContainer();
            this.pivotGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVTYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLAREA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLLENGTH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBTIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCLON = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCLAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fieldExtendedPrice = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.sbExport = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer1)).BeginInit();
            this.gridSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridSplitContainer1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.sbExport);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(864, 477);
            this.splitContainerControl1.SplitterPosition = 31;
            this.splitContainerControl1.TabIndex = 8;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridSplitContainer1
            // 
            this.gridSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSplitContainer1.Grid = this.pivotGridControl;
            this.gridSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.gridSplitContainer1.Name = "gridSplitContainer1";
            this.gridSplitContainer1.Panel1.Controls.Add(this.pivotGridControl);
            this.gridSplitContainer1.Size = new System.Drawing.Size(864, 441);
            this.gridSplitContainer1.TabIndex = 0;
            // 
            // pivotGridControl
            // 
            this.pivotGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl.Location = new System.Drawing.Point(0, 0);
            this.pivotGridControl.MainView = this.gridView1;
            this.pivotGridControl.Name = "pivotGridControl";
            this.pivotGridControl.Size = new System.Drawing.Size(864, 441);
            this.pivotGridControl.TabIndex = 0;
            this.pivotGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colLNAME,
            this.colVTYPE,
            this.colLAREA,
            this.colLLENGTH,
            this.colBTIME,
            this.colPNAME,
            this.colCLON,
            this.colCLAT});
            this.gridView1.GridControl = this.pivotGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindNullPrompt = "输入查询内容...";
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // colID
            // 
            this.colID.Caption = "线路编号";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            // 
            // colLNAME
            // 
            this.colLNAME.Caption = "线路名称";
            this.colLNAME.FieldName = "LNAME";
            this.colLNAME.Name = "colLNAME";
            this.colLNAME.Visible = true;
            this.colLNAME.VisibleIndex = 1;
            // 
            // colVTYPE
            // 
            this.colVTYPE.Caption = "电压类型";
            this.colVTYPE.FieldName = "VTYPE";
            this.colVTYPE.Name = "colVTYPE";
            this.colVTYPE.Visible = true;
            this.colVTYPE.VisibleIndex = 2;
            // 
            // colLAREA
            // 
            this.colLAREA.Caption = "所属区域";
            this.colLAREA.FieldName = "LAREA";
            this.colLAREA.Name = "colLAREA";
            this.colLAREA.Visible = true;
            this.colLAREA.VisibleIndex = 3;
            // 
            // colLLENGTH
            // 
            this.colLLENGTH.Caption = "长度";
            this.colLLENGTH.FieldName = "LLENGTH";
            this.colLLENGTH.Name = "colLLENGTH";
            this.colLLENGTH.Visible = true;
            this.colLLENGTH.VisibleIndex = 4;
            // 
            // colBTIME
            // 
            this.colBTIME.Caption = "建设时间";
            this.colBTIME.FieldName = "BTIME";
            this.colBTIME.Name = "colBTIME";
            this.colBTIME.Visible = true;
            this.colBTIME.VisibleIndex = 5;
            // 
            // colPNAME
            // 
            this.colPNAME.Caption = "负责人";
            this.colPNAME.FieldName = "PNAME";
            this.colPNAME.Name = "colPNAME";
            this.colPNAME.Visible = true;
            this.colPNAME.VisibleIndex = 6;
            // 
            // colCLON
            // 
            this.colCLON.Caption = "中心经度";
            this.colCLON.FieldName = "CLON";
            this.colCLON.Name = "colCLON";
            this.colCLON.Visible = true;
            this.colCLON.VisibleIndex = 7;
            // 
            // colCLAT
            // 
            this.colCLAT.Caption = "中心纬度";
            this.colCLAT.FieldName = "CLAT";
            this.colCLAT.Name = "colCLAT";
            this.colCLAT.Visible = true;
            this.colCLAT.VisibleIndex = 8;
            // 
            // fieldExtendedPrice
            // 
            this.fieldExtendedPrice.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldExtendedPrice.AreaIndex = 0;
            this.fieldExtendedPrice.CellFormat.FormatString = "c";
            this.fieldExtendedPrice.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldExtendedPrice.FieldName = "Extended Price";
            this.fieldExtendedPrice.Name = "fieldExtendedPrice";
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.AreaIndex = 0;
            this.pivotGridField1.Caption = "Order Year";
            this.pivotGridField1.FieldName = "OrderDate";
            this.pivotGridField1.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateYear;
            this.pivotGridField1.Name = "pivotGridField1";
            this.pivotGridField1.Options.IsFilterRadioMode = DevExpress.Utils.DefaultBoolean.True;
            this.pivotGridField1.UnboundFieldName = "pivotGridField1";
            // 
            // sbExport
            // 
            this.sbExport.Image = global::HRQ.Properties.Resources.Export_16x16;
            this.sbExport.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.sbExport.Location = new System.Drawing.Point(3, 1);
            this.sbExport.Name = "sbExport";
            this.sbExport.Size = new System.Drawing.Size(89, 23);
            this.sbExport.TabIndex = 2;
            this.sbExport.Text = "导出";
            this.sbExport.Click += new System.EventHandler(this.sbExport_Click);
            // 
            // LineGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "LineGrid";
            this.Size = new System.Drawing.Size(864, 477);
            this.Load += new System.EventHandler(this.ChartGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer1)).EndInit();
            this.gridSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldExtendedPrice;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
        private DevExpress.XtraGrid.GridControl pivotGridControl;
        private DevExpress.XtraGrid.GridSplitContainer gridSplitContainer1;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colLNAME;
        private DevExpress.XtraGrid.Columns.GridColumn colVTYPE;
        private DevExpress.XtraGrid.Columns.GridColumn colLAREA;
        private DevExpress.XtraGrid.Columns.GridColumn colLLENGTH;
        private DevExpress.XtraGrid.Columns.GridColumn colBTIME;
        private DevExpress.XtraGrid.Columns.GridColumn colPNAME;
        private DevExpress.XtraGrid.Columns.GridColumn colCLON;
        private DevExpress.XtraGrid.Columns.GridColumn colCLAT;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton sbExport;

    }
}
