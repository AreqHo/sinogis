namespace HRQ.Modules {
    partial class ReportGrid {
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
            this.pivotGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colITIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colITYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIPROJECT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTATIONID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAULTTYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTATUS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDESCRIPTION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLON = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sbExport = new DevExpress.XtraEditors.SimpleButton();
            this.fieldExtendedPrice = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
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
            this.splitContainerControl1.Panel1.Controls.Add(this.pivotGridControl);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.sbExport);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(864, 477);
            this.splitContainerControl1.SplitterPosition = 32;
            this.splitContainerControl1.TabIndex = 8;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // pivotGridControl
            // 
            this.pivotGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl.Location = new System.Drawing.Point(0, 0);
            this.pivotGridControl.MainView = this.gridView1;
            this.pivotGridControl.Name = "pivotGridControl";
            this.pivotGridControl.Size = new System.Drawing.Size(864, 440);
            this.pivotGridControl.TabIndex = 0;
            this.pivotGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colLID,
            this.colITIME,
            this.colITYPE,
            this.colIPROJECT,
            this.colSTATIONID,
            this.colFAULTTYPE,
            this.colSTATUS,
            this.colDESCRIPTION,
            this.colLON,
            this.colLAT});
            this.gridView1.GridControl = this.pivotGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindNullPrompt = "输入查询内容...";
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // colID
            // 
            this.colID.Caption = "编号";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            // 
            // colLID
            // 
            this.colLID.Caption = "线路编号";
            this.colLID.FieldName = "LID";
            this.colLID.Name = "colLID";
            this.colLID.Visible = true;
            this.colLID.VisibleIndex = 1;
            // 
            // colITIME
            // 
            this.colITIME.Caption = "巡线时间";
            this.colITIME.FieldName = "ITIME";
            this.colITIME.Name = "colITIME";
            this.colITIME.Visible = true;
            this.colITIME.VisibleIndex = 2;
            // 
            // colITYPE
            // 
            this.colITYPE.Caption = "巡线类型";
            this.colITYPE.FieldName = "ITYPE";
            this.colITYPE.Name = "colITYPE";
            this.colITYPE.Visible = true;
            this.colITYPE.VisibleIndex = 3;
            // 
            // colIPROJECT
            // 
            this.colIPROJECT.Caption = "作业项目";
            this.colIPROJECT.FieldName = "IPROJECT";
            this.colIPROJECT.Name = "colIPROJECT";
            this.colIPROJECT.Visible = true;
            this.colIPROJECT.VisibleIndex = 4;
            // 
            // colSTATIONID
            // 
            this.colSTATIONID.Caption = "设施编号";
            this.colSTATIONID.FieldName = "STATIONID";
            this.colSTATIONID.Name = "colSTATIONID";
            this.colSTATIONID.Visible = true;
            this.colSTATIONID.VisibleIndex = 5;
            // 
            // colFAULTTYPE
            // 
            this.colFAULTTYPE.Caption = "故障类型";
            this.colFAULTTYPE.FieldName = "FAULTTYPE";
            this.colFAULTTYPE.Name = "colFAULTTYPE";
            this.colFAULTTYPE.Visible = true;
            this.colFAULTTYPE.VisibleIndex = 6;
            // 
            // colSTATUS
            // 
            this.colSTATUS.Caption = "状态";
            this.colSTATUS.FieldName = "STATUS";
            this.colSTATUS.Name = "colSTATUS";
            this.colSTATUS.Visible = true;
            this.colSTATUS.VisibleIndex = 7;
            // 
            // colDESCRIPTION
            // 
            this.colDESCRIPTION.Caption = "说明";
            this.colDESCRIPTION.FieldName = "DESCRIPTION";
            this.colDESCRIPTION.Name = "colDESCRIPTION";
            this.colDESCRIPTION.Visible = true;
            this.colDESCRIPTION.VisibleIndex = 8;
            // 
            // colLON
            // 
            this.colLON.Caption = "经度";
            this.colLON.FieldName = "LON";
            this.colLON.Name = "colLON";
            this.colLON.Visible = true;
            this.colLON.VisibleIndex = 9;
            // 
            // colLAT
            // 
            this.colLAT.Caption = "纬度";
            this.colLAT.FieldName = "LAT";
            this.colLAT.Name = "colLAT";
            this.colLAT.Visible = true;
            this.colLAT.VisibleIndex = 10;
            // 
            // sbExport
            // 
            this.sbExport.Image = global::HRQ.Properties.Resources.Export_16x16;
            this.sbExport.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.sbExport.Location = new System.Drawing.Point(3, 1);
            this.sbExport.Name = "sbExport";
            this.sbExport.Size = new System.Drawing.Size(104, 23);
            this.sbExport.TabIndex = 4;
            this.sbExport.Text = "导出";
            this.sbExport.Click += new System.EventHandler(this.sbExport_Click);
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
            // ReportGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "ReportGrid";
            this.Size = new System.Drawing.Size(864, 477);
            this.Load += new System.EventHandler(this.ChartGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
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
        private DevExpress.XtraGrid.Columns.GridColumn colLID;
        private DevExpress.XtraGrid.Columns.GridColumn colITIME;
        private DevExpress.XtraGrid.Columns.GridColumn colITYPE;
        private DevExpress.XtraGrid.Columns.GridColumn colIPROJECT;
        private DevExpress.XtraGrid.Columns.GridColumn colSTATIONID;
        private DevExpress.XtraGrid.Columns.GridColumn colFAULTTYPE;
        private DevExpress.XtraGrid.Columns.GridColumn colSTATUS;
        private DevExpress.XtraGrid.Columns.GridColumn colDESCRIPTION;
        private DevExpress.XtraGrid.Columns.GridColumn colLON;
        private DevExpress.XtraGrid.Columns.GridColumn colLAT;
        private DevExpress.XtraEditors.SimpleButton sbExport;

    }
}
