using System;
using DevExpress.XtraCharts;

namespace HRQ.Modules {
    public partial class ChartGrid : DevExpress.XtraEditors.XtraUserControl {
        public ChartGrid() {
            InitializeComponent();
        }

        private void ChartGrid_Load(object sender, EventArgs e) {
            HRQ.Utils.DevExpressLocalizerHelper.SetSimpleChinese();
            //this.sqlDataSource1.Fill();
            pivotGridControl.DataSource = Utils.DBOperation.GetNWindData("Intrusion");
            //chartControl.DataSource = pivotGridControl.DataSource;
        }
        void UpdateSeriesTransparency(SeriesViewBase seriesView) {
            ISupportTransparency supportTransparency = seriesView as ISupportTransparency;
            if (supportTransparency != null) {
                if ((seriesView is AreaSeriesView) || (seriesView is Area3DSeriesView)
                    || (seriesView is RadarAreaSeriesView) || (seriesView is Bar3DSeriesView))
                    supportTransparency.Transparency = 135;
                else
                    supportTransparency.Transparency = 0;
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e) {
            try {
                double lon = Double.Parse(gridView1.GetDataRow(e.RowHandle)["X"].ToString());
                double lat = Double.Parse(gridView1.GetDataRow(e.RowHandle)["Y"].ToString());

                MainForm.FlyToPosition(lon, lat);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
