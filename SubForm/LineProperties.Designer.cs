namespace HRQ.SubForm {
    partial class LineProperties {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.RangeColorizer rangeColorizer1 = new DevExpress.XtraCharts.RangeColorizer();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel1 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.SeriesPoint seriesPoint1 = new DevExpress.XtraCharts.SeriesPoint("1", new object[] {
            ((object)(0D)),
            ((object)(0D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint2 = new DevExpress.XtraCharts.SeriesPoint("2", new object[] {
            ((object)(1D)),
            ((object)(1D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint3 = new DevExpress.XtraCharts.SeriesPoint("3", new object[] {
            ((object)(2D)),
            ((object)(2D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint4 = new DevExpress.XtraCharts.SeriesPoint("4", new object[] {
            ((object)(3D)),
            ((object)(3D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint5 = new DevExpress.XtraCharts.SeriesPoint("5", new object[] {
            ((object)(4D)),
            ((object)(4D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint6 = new DevExpress.XtraCharts.SeriesPoint("6", new object[] {
            ((object)(5D)),
            ((object)(5D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint7 = new DevExpress.XtraCharts.SeriesPoint("7", new object[] {
            ((object)(6D)),
            ((object)(6D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint8 = new DevExpress.XtraCharts.SeriesPoint("8", new object[] {
            ((object)(7D)),
            ((object)(7D))});
            DevExpress.XtraCharts.PointSeriesView pointSeriesView1 = new DevExpress.XtraCharts.PointSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SeriesPoint seriesPoint9 = new DevExpress.XtraCharts.SeriesPoint("1", new object[] {
            ((object)(0D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint10 = new DevExpress.XtraCharts.SeriesPoint("2", new object[] {
            ((object)(1D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint11 = new DevExpress.XtraCharts.SeriesPoint("3", new object[] {
            ((object)(2D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint12 = new DevExpress.XtraCharts.SeriesPoint("4", new object[] {
            ((object)(3D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint13 = new DevExpress.XtraCharts.SeriesPoint("5", new object[] {
            ((object)(4D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint14 = new DevExpress.XtraCharts.SeriesPoint("6", new object[] {
            ((object)(5D))});
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView1 = new DevExpress.XtraCharts.SplineSeriesView();
            DevExpress.XtraCharts.BubbleSeriesLabel bubbleSeriesLabel1 = new DevExpress.XtraCharts.BubbleSeriesLabel();
            DevExpress.XtraCharts.BubbleSeriesView bubbleSeriesView1 = new DevExpress.XtraCharts.BubbleSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            DevExpress.XtraCharts.ChartTitle chartTitle2 = new DevExpress.XtraCharts.ChartTitle();
            this.chart = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(bubbleSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(bubbleSeriesView1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            xyDiagram1.AxisX.DateTimeScaleOptions.AggregateFunction = DevExpress.XtraCharts.AggregateFunction.None;
            xyDiagram1.AxisX.DateTimeScaleOptions.AutoGrid = false;
            xyDiagram1.AxisX.DateTimeScaleOptions.GridAlignment = DevExpress.XtraCharts.DateTimeGridAlignment.Year;
            xyDiagram1.AxisX.DateTimeScaleOptions.MeasureUnit = DevExpress.XtraCharts.DateTimeMeasureUnit.Year;
            xyDiagram1.AxisX.GridLines.Visible = true;
            xyDiagram1.AxisX.Interlaced = true;
            xyDiagram1.AxisX.Label.TextPattern = "{A:#.00}";
            xyDiagram1.AxisX.Tickmarks.MinorVisible = false;
            xyDiagram1.AxisX.Title.Text = "点位";
            xyDiagram1.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.Label.TextPattern = "{V}M";
            xyDiagram1.AxisY.Title.Text = "高度";
            xyDiagram1.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chart.Diagram = xyDiagram1;
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
            this.chart.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside;
            this.chart.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chart.Name = "chart";
            rangeColorizer1.PaletteName = "Concourse";
            series1.Colorizer = rangeColorizer1;
            pointSeriesLabel1.LineVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.Label = pointSeriesLabel1;
            series1.Name = "Series 1";
            seriesPoint1.ColorSerializable = "Red";
            seriesPoint2.ColorSerializable = "Yellow";
            seriesPoint3.ColorSerializable = "#00FF40";
            seriesPoint4.ColorSerializable = "Aqua";
            seriesPoint5.ColorSerializable = "Black";
            seriesPoint6.ColorSerializable = "#808040";
            seriesPoint7.ColorSerializable = "#8000FF";
            seriesPoint8.ColorSerializable = "Fuchsia";
            series1.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] {
            seriesPoint1,
            seriesPoint2,
            seriesPoint3,
            seriesPoint4,
            seriesPoint5,
            seriesPoint6,
            seriesPoint7,
            seriesPoint8});
            series1.ToolTipPointPattern = "{S:#.00}\n{S:#.00}";
            pointSeriesView1.ColorEach = true;
            pointSeriesView1.PointMarkerOptions.Size = 12;
            series1.View = pointSeriesView1;
            series2.CrosshairLabelVisibility = DevExpress.Utils.DefaultBoolean.False;
            series2.Name = "Series 2";
            series2.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] {
            seriesPoint9,
            seriesPoint10,
            seriesPoint11,
            seriesPoint12,
            seriesPoint13,
            seriesPoint14});
            series2.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.False;
            series2.View = splineSeriesView1;
            this.chart.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            bubbleSeriesLabel1.LineVisibility = DevExpress.Utils.DefaultBoolean.True;
            this.chart.SeriesTemplate.Label = bubbleSeriesLabel1;
            this.chart.SeriesTemplate.View = bubbleSeriesView1;
            this.chart.Size = new System.Drawing.Size(802, 487);
            this.chart.TabIndex = 7;
            chartTitle1.Text = "电力线";
            chartTitle2.Alignment = System.Drawing.StringAlignment.Far;
            chartTitle2.Dock = DevExpress.XtraCharts.ChartTitleDockStyle.Bottom;
            chartTitle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartTitle2.Text = "";
            chartTitle2.TextColor = System.Drawing.Color.Gray;
            this.chart.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1,
            chartTitle2});
            this.chart.CustomDrawCrosshair += new DevExpress.XtraCharts.CustomDrawCrosshairEventHandler(this.chart_CustomDrawCrosshair);
            // 
            // LineProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 487);
            this.Controls.Add(this.chart);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LineProperties";
            this.Text = "电力线属性";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LineProperties_Load);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(bubbleSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(bubbleSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chart;
    }
}