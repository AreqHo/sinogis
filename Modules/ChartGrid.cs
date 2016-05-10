using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;

namespace HRQ.Modules {
    public partial class ChartGrid : DevExpress.XtraEditors.XtraUserControl {
        public ChartGrid() {
            InitializeComponent();
        }

        private void ChartGrid_Load(object sender, EventArgs e) {
            HRQ.Utils.DevExpressLocalizerHelper.SetSimpleChinese();
            //this.sqlDataSource1.Fill();
            pivotGridControl.DataSource = GetNWindData("Intrusion");
            //chartControl.DataSource = pivotGridControl.DataSource;
        }

        DataView dvTutorial = null;
        protected DataView GetNWindData(string tableName) {
            string DBFileName = DevExpress.Utils.FilesHelper.FindingFileName(Application.StartupPath, "db\\nwind.mdb");
            if (DBFileName != "") {
                DataSet ds = new DataSet();
                string con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName;
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM " + tableName, con);
                //SetWaitDialogCaption(string.Format("Loading {0}...", tableName));
                oleDbDataAdapter.Fill(ds, tableName);

                dvTutorial = ds.Tables[tableName].DefaultView;
                return dvTutorial;
            }
            return null;
        }
        void SetSelection() {
            //pivotGridControl.Cells.SetSelectionByFieldValues(false, new object[] { "Chocolade" });
            //pivotGridControl.Cells.SetSelectionByFieldValues(false, new object[] { "Chai" });
        }

        //private void comboChartType_SelectedIndexChanged(object sender, EventArgs e) {
        //    chartControl.SeriesTemplate.ChangeView((ViewType)comboChartType.SelectedItem);
        //    if (chartControl.SeriesTemplate.Label != null) {
        //        chartControl.SeriesTemplate.LabelsVisibility = checkShowPointLabels.Checked ?
        //            DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;
        //        chartControl.CrosshairEnabled = checkShowPointLabels.Checked ?
        //            DevExpress.Utils.DefaultBoolean.False : DevExpress.Utils.DefaultBoolean.True;
        //        checkShowPointLabels.Enabled = true;
        //    }
        //    else {
        //        checkShowPointLabels.Enabled = false;
        //    }
        //    if ((chartControl.SeriesTemplate.View as SimpleDiagramSeriesViewBase) == null)
        //        chartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
        //    if (chartControl.Diagram is Diagram3D) {
        //        Diagram3D diagram = (Diagram3D)chartControl.Diagram;
        //        diagram.RuntimeRotation = true;
        //        diagram.RuntimeZooming = true;
        //        diagram.RuntimeScrolling = true;
        //    }
        //    foreach (Series series in chartControl.Series)
        //        UpdateSeriesTransparency(series.View);
        //    UpdateSeriesTransparency(chartControl.SeriesTemplate.View);
        //}

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
