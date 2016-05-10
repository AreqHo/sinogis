namespace HRQ.Modules {
    partial class PoleGrid {
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
            this.colLON = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVTYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPAREA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHEIGHT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYAW = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.splitContainerControl1.Size = new System.Drawing.Size(864, 471);
            this.splitContainerControl1.SplitterPosition = 35;
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
            this.gridSplitContainer1.Size = new System.Drawing.Size(864, 431);
            this.gridSplitContainer1.TabIndex = 0;
            // 
            // pivotGridControl
            // 
            this.pivotGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl.Location = new System.Drawing.Point(0, 0);
            this.pivotGridControl.MainView = this.gridView1;
            this.pivotGridControl.Name = "pivotGridControl";
            this.pivotGridControl.Size = new System.Drawing.Size(864, 431);
            this.pivotGridControl.TabIndex = 0;
            this.pivotGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colLON,
            this.colLAT,
            this.colVTYPE,
            this.colLID,
            this.colLNAME,
            this.colPAREA,
            this.colHEIGHT,
            this.colYAW});
            this.gridView1.GridControl = this.pivotGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindNullPrompt = "输入查询内容...";
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // colID
            // 
            this.colID.Caption = "杆塔编号";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            // 
            // colLON
            // 
            this.colLON.Caption = "经度";
            this.colLON.FieldName = "LON";
            this.colLON.Name = "colLON";
            this.colLON.Visible = true;
            this.colLON.VisibleIndex = 1;
            // 
            // colLAT
            // 
            this.colLAT.Caption = "纬度";
            this.colLAT.FieldName = "LAT";
            this.colLAT.Name = "colLAT";
            this.colLAT.Visible = true;
            this.colLAT.VisibleIndex = 2;
            // 
            // colVTYPE
            // 
            this.colVTYPE.Caption = "电压类型";
            this.colVTYPE.FieldName = "VTYPE";
            this.colVTYPE.Name = "colVTYPE";
            this.colVTYPE.Visible = true;
            this.colVTYPE.VisibleIndex = 3;
            // 
            // colLID
            // 
            this.colLID.Caption = "线路编号";
            this.colLID.FieldName = "LID";
            this.colLID.Name = "colLID";
            this.colLID.Visible = true;
            this.colLID.VisibleIndex = 4;
            // 
            // colLNAME
            // 
            this.colLNAME.Caption = "线路名称";
            this.colLNAME.FieldName = "LNAME";
            this.colLNAME.Name = "colLNAME";
            this.colLNAME.Visible = true;
            this.colLNAME.VisibleIndex = 5;
            // 
            // colPAREA
            // 
            this.colPAREA.Caption = "所属区域";
            this.colPAREA.FieldName = "PAREA";
            this.colPAREA.Name = "colPAREA";
            this.colPAREA.Visible = true;
            this.colPAREA.VisibleIndex = 6;
            // 
            // colHEIGHT
            // 
            this.colHEIGHT.Caption = "杆塔高度";
            this.colHEIGHT.FieldName = "HEIGHT";
            this.colHEIGHT.Name = "colHEIGHT";
            this.colHEIGHT.Visible = true;
            this.colHEIGHT.VisibleIndex = 7;
            // 
            // colYAW
            // 
            this.colYAW.Caption = "转向角";
            this.colYAW.FieldName = "YAW";
            this.colYAW.Name = "colYAW";
            this.colYAW.Visible = true;
            this.colYAW.VisibleIndex = 8;
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
            this.sbExport.TabIndex = 3;
            this.sbExport.Text = "导出";
            this.sbExport.Click += new System.EventHandler(this.sbExport_Click);
            // 
            // PoleGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "PoleGrid";
            this.Size = new System.Drawing.Size(864, 471);
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
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colLON;
        private DevExpress.XtraGrid.Columns.GridColumn colLAT;
        private DevExpress.XtraGrid.Columns.GridColumn colVTYPE;
        private DevExpress.XtraGrid.Columns.GridColumn colLID;
        private DevExpress.XtraGrid.Columns.GridColumn colLNAME;
        private DevExpress.XtraGrid.Columns.GridColumn colPAREA;
        private DevExpress.XtraGrid.Columns.GridColumn colHEIGHT;
        private DevExpress.XtraGrid.Columns.GridColumn colYAW;
        private DevExpress.XtraGrid.GridSplitContainer gridSplitContainer1;
        private DevExpress.XtraEditors.SimpleButton sbExport;

    }
}
