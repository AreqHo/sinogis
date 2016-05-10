namespace HRQ.Modules {
    partial class ChartGrid {
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
            this.components = new System.ComponentModel.Container();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.pivotGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colF_REGION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colF_TYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colF_COSTATUS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colF_VTYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTE_HEIGHT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colF_DANGTYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colF_CL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colF_VOLUME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colT_AREA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colF_NEARPOLE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colF_DISPOLE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colF_BAYID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colF_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.intrusionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.paddingPanel = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.checkShowPointLabels = new DevExpress.XtraEditors.CheckEdit();
            this.comboChartType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.fieldExtendedPrice = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.intrusionBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intrusionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paddingPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkShowPointLabels.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboChartType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intrusionBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 45);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.pivotGridControl);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(864, 432);
            this.splitContainerControl1.SplitterPosition = 0;
            this.splitContainerControl1.TabIndex = 8;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // pivotGridControl
            // 
            this.pivotGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl.Location = new System.Drawing.Point(0, 0);
            this.pivotGridControl.MainView = this.gridView1;
            this.pivotGridControl.Name = "pivotGridControl";
            this.pivotGridControl.Size = new System.Drawing.Size(864, 427);
            this.pivotGridControl.TabIndex = 0;
            this.pivotGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colF_REGION,
            this.colF_TYPE,
            this.colF_COSTATUS,
            this.colF_VTYPE,
            this.colX,
            this.colY,
            this.colTE_HEIGHT,
            this.colF_DANGTYPE,
            this.colF_CL,
            this.colF_VOLUME,
            this.colT_AREA,
            this.colF_NEARPOLE,
            this.colF_DISPOLE,
            this.colF_BAYID,
            this.colF_DATE});
            this.gridView1.GridControl = this.pivotGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // colID
            // 
            this.colID.Caption = "危险域编码";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            // 
            // colF_REGION
            // 
            this.colF_REGION.Caption = "植被区域";
            this.colF_REGION.FieldName = "F_REGION";
            this.colF_REGION.Name = "colF_REGION";
            this.colF_REGION.Visible = true;
            this.colF_REGION.VisibleIndex = 1;
            // 
            // colF_TYPE
            // 
            this.colF_TYPE.Caption = "植被区域类型";
            this.colF_TYPE.FieldName = "F_TYPE";
            this.colF_TYPE.Name = "colF_TYPE";
            this.colF_TYPE.Visible = true;
            this.colF_TYPE.VisibleIndex = 2;
            // 
            // colF_COSTATUS
            // 
            this.colF_COSTATUS.Caption = "采集状态";
            this.colF_COSTATUS.FieldName = "F_COSTATUS";
            this.colF_COSTATUS.Name = "colF_COSTATUS";
            this.colF_COSTATUS.Visible = true;
            this.colF_COSTATUS.VisibleIndex = 3;
            // 
            // colF_VTYPE
            // 
            this.colF_VTYPE.Caption = "电线组电压类型";
            this.colF_VTYPE.FieldName = "F_VTYPE";
            this.colF_VTYPE.Name = "colF_VTYPE";
            this.colF_VTYPE.Visible = true;
            this.colF_VTYPE.VisibleIndex = 4;
            // 
            // colX
            // 
            this.colX.Caption = "危险域经度";
            this.colX.FieldName = "X";
            this.colX.Name = "colX";
            this.colX.Visible = true;
            this.colX.VisibleIndex = 5;
            // 
            // colY
            // 
            this.colY.Caption = "危险域纬度";
            this.colY.FieldName = "Y";
            this.colY.Name = "colY";
            this.colY.Visible = true;
            this.colY.VisibleIndex = 6;
            // 
            // colTE_HEIGHT
            // 
            this.colTE_HEIGHT.Caption = "危险域离地高度";
            this.colTE_HEIGHT.FieldName = "TE_HEIGHT";
            this.colTE_HEIGHT.Name = "colTE_HEIGHT";
            this.colTE_HEIGHT.Visible = true;
            this.colTE_HEIGHT.VisibleIndex = 7;
            // 
            // colF_DANGTYPE
            // 
            this.colF_DANGTYPE.Caption = "危险域类型";
            this.colF_DANGTYPE.FieldName = "F_DANGTYPE";
            this.colF_DANGTYPE.Name = "colF_DANGTYPE";
            this.colF_DANGTYPE.Visible = true;
            this.colF_DANGTYPE.VisibleIndex = 8;
            // 
            // colF_CL
            // 
            this.colF_CL.Caption = "危险域的CL值";
            this.colF_CL.FieldName = "F_CL";
            this.colF_CL.Name = "colF_CL";
            this.colF_CL.Visible = true;
            this.colF_CL.VisibleIndex = 9;
            // 
            // colF_VOLUME
            // 
            this.colF_VOLUME.Caption = "危险域的CL值";
            this.colF_VOLUME.FieldName = "F_VOLUME";
            this.colF_VOLUME.Name = "colF_VOLUME";
            this.colF_VOLUME.Visible = true;
            this.colF_VOLUME.VisibleIndex = 10;
            // 
            // colT_AREA
            // 
            this.colT_AREA.Caption = "危险域水平面积";
            this.colT_AREA.FieldName = "T_AREA";
            this.colT_AREA.Name = "colT_AREA";
            this.colT_AREA.Visible = true;
            this.colT_AREA.VisibleIndex = 11;
            // 
            // colF_NEARPOLE
            // 
            this.colF_NEARPOLE.Caption = "距离最近的电线杆编码";
            this.colF_NEARPOLE.FieldName = "F_NEARPOLE";
            this.colF_NEARPOLE.Name = "colF_NEARPOLE";
            this.colF_NEARPOLE.Visible = true;
            this.colF_NEARPOLE.VisibleIndex = 12;
            // 
            // colF_DISPOLE
            // 
            this.colF_DISPOLE.Caption = "最近的电线杆距离";
            this.colF_DISPOLE.FieldName = "F_DISPOLE";
            this.colF_DISPOLE.Name = "colF_DISPOLE";
            this.colF_DISPOLE.Visible = true;
            this.colF_DISPOLE.VisibleIndex = 13;
            // 
            // colF_BAYID
            // 
            this.colF_BAYID.Caption = "电线组编码";
            this.colF_BAYID.FieldName = "F_BAYID";
            this.colF_BAYID.Name = "colF_BAYID";
            this.colF_BAYID.Visible = true;
            this.colF_BAYID.VisibleIndex = 14;
            // 
            // colF_DATE
            // 
            this.colF_DATE.Caption = "采集日期";
            this.colF_DATE.FieldName = "F_DATE";
            this.colF_DATE.Name = "colF_DATE";
            this.colF_DATE.Visible = true;
            this.colF_DATE.VisibleIndex = 15;
            // 
            // intrusionBindingSource
            // 
            this.intrusionBindingSource.DataMember = "intrusion";
            // 
            // paddingPanel
            // 
            this.paddingPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.paddingPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.paddingPanel.Location = new System.Drawing.Point(0, 37);
            this.paddingPanel.Name = "paddingPanel";
            this.paddingPanel.Size = new System.Drawing.Size(864, 8);
            this.paddingPanel.TabIndex = 7;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.checkShowPointLabels);
            this.panelControl1.Controls.Add(this.comboChartType);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(5);
            this.panelControl1.Size = new System.Drawing.Size(864, 37);
            this.panelControl1.TabIndex = 6;
            this.panelControl1.Visible = false;
            // 
            // checkShowPointLabels
            // 
            this.checkShowPointLabels.Location = new System.Drawing.Point(238, 10);
            this.checkShowPointLabels.Name = "checkShowPointLabels";
            this.checkShowPointLabels.Properties.AutoWidth = true;
            this.checkShowPointLabels.Properties.Caption = "显示点位值";
            this.checkShowPointLabels.Size = new System.Drawing.Size(82, 19);
            this.checkShowPointLabels.TabIndex = 4;
            this.checkShowPointLabels.ToolTip = "Toggles whether value labels are shown in the Chart control";
            // 
            // comboChartType
            // 
            this.comboChartType.EditValue = "Line";
            this.comboChartType.Location = new System.Drawing.Point(78, 10);
            this.comboChartType.Name = "comboChartType";
            this.comboChartType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboChartType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboChartType.Size = new System.Drawing.Size(154, 20);
            this.comboChartType.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 13);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "图标类型:";
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
            // intrusionBindingSource1
            // 
            this.intrusionBindingSource1.DataMember = "intrusion";
            // 
            // ChartGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.paddingPanel);
            this.Controls.Add(this.panelControl1);
            this.Name = "ChartGrid";
            this.Size = new System.Drawing.Size(864, 477);
            this.Load += new System.EventHandler(this.ChartGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intrusionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paddingPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkShowPointLabels.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboChartType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intrusionBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl paddingPanel;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckEdit checkShowPointLabels;
        private DevExpress.XtraEditors.ComboBoxEdit comboChartType;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraPivotGrid.PivotGridField fieldExtendedPrice;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
        private DevExpress.XtraGrid.GridControl pivotGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource intrusionBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colF_REGION;
        private DevExpress.XtraGrid.Columns.GridColumn colF_TYPE;
        private DevExpress.XtraGrid.Columns.GridColumn colF_COSTATUS;
        private DevExpress.XtraGrid.Columns.GridColumn colF_VTYPE;
        private DevExpress.XtraGrid.Columns.GridColumn colX;
        private DevExpress.XtraGrid.Columns.GridColumn colY;
        private DevExpress.XtraGrid.Columns.GridColumn colTE_HEIGHT;
        private DevExpress.XtraGrid.Columns.GridColumn colF_DANGTYPE;
        private DevExpress.XtraGrid.Columns.GridColumn colF_CL;
        private DevExpress.XtraGrid.Columns.GridColumn colF_VOLUME;
        private DevExpress.XtraGrid.Columns.GridColumn colT_AREA;
        private DevExpress.XtraGrid.Columns.GridColumn colF_NEARPOLE;
        private DevExpress.XtraGrid.Columns.GridColumn colF_DISPOLE;
        private DevExpress.XtraGrid.Columns.GridColumn colF_BAYID;
        private DevExpress.XtraGrid.Columns.GridColumn colF_DATE;
        private System.Windows.Forms.BindingSource intrusionBindingSource1;

    }
}
