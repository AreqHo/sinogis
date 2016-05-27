using System;
using System.Windows.Forms;
using DevExpress.XtraCharts;

namespace HRQ.Modules {
    public partial class PoleGrid : DevExpress.XtraEditors.XtraUserControl {
        public PoleGrid()
        {
            InitializeComponent();
        }

        private void ChartGrid_Load(object sender, EventArgs e) {
            HRQ.Utils.DevExpressLocalizerHelper.SetSimpleChinese();
            pivotGridControl.DataSource = Utils.DBOperation.GetNWindData("Pole");
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
                double lon = Double.Parse(gridView1.GetDataRow(e.RowHandle)["LON"].ToString());
                double lat = Double.Parse(gridView1.GetDataRow(e.RowHandle)["LAT"].ToString());

                Utils.TEOperation.FlyToPosition(lon, lat);

                PoleAttribute pa = new PoleAttribute();
                pa.ID = gridView1.GetDataRow(e.RowHandle)["ID"].ToString();
                pa.Lon = lon;
                pa.Lat = lat;
                pa.LName = gridView1.GetDataRow(e.RowHandle)["LNAME"].ToString();
                pa.STime = App.GetInstance().InspectionTime;

                SubForm.PoleForm pf = new SubForm.PoleForm(pa);
                pf.ShowDialog();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }

        private void sbExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                pivotGridControl.ExportToXls(fileDialog.FileName);
                DevExpress.XtraEditors.XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    public class PoleAttribute
    {
        private string id = "";

        public string ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public double Lon
        {
            get
            {
                return lon;
            }

            set
            {
                lon = value;
            }
        }

        public double Lat
        {
            get
            {
                return lat;
            }

            set
            {
                lat = value;
            }
        }

        public string LName
        {
            get
            {
                return lName;
            }

            set
            {
                lName = value;
            }
        }

        public string STime
        {
            get
            {
                return sTime;
            }

            set
            {
                sTime = value;
            }
        }

        private double lon = 0.0;

        private double lat = 0.0;

        private string lName = "";

        private string sTime = "";

    }
}
