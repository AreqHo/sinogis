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
using System.Data.OleDb;
using System.Data.SQLite;
using HRQ.Utils;

namespace HRQ.Modules {
    public partial class ReportGrid : DevExpress.XtraEditors.XtraUserControl {
        public ReportGrid()
        {
            InitializeComponent();
        }

        private void ChartGrid_Load(object sender, EventArgs e) {
            HRQ.Utils.DevExpressLocalizerHelper.SetSimpleChinese();
            pivotGridControl.DataSource = GetNWindData("Report");
            //chartControl.DataSource = pivotGridControl.DataSource;
        }

        DataView dvTutorial = null;
        protected DataView GetNWindData(string tableName) {
            string DBFileName = DevExpress.Utils.FilesHelper.FindingFileName(Application.StartupPath, "db\\HVL.db");
            
            if (DBFileName != "") {
                SQLiteConnection conn = null;

                string dbPath = "Data Source =" + DBFileName;
                conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置  
                conn.Open();//打开数据库，若文件不存在会自动创建  

                string sql = "SELECT * FROM " + tableName;
                SQLiteCommand cmdQ = new SQLiteCommand(sql, conn);

                SQLiteDataReader reader = cmdQ.ExecuteReader();

                DataTable TSelectReSoult = new DataTable();  /*存放要在Gridview里面显示的最后结果*/
                TSelectReSoult.Load(reader);

                reader.Close();                        /*记得用完要关闭reader*/

                dvTutorial = TSelectReSoult.DefaultView;

                conn.Close();

                return dvTutorial;
            }
            return null;
        }
        void SetSelection() {
            //pivotGridControl.Cells.SetSelectionByFieldValues(false, new object[] { "Chocolade" });
            //pivotGridControl.Cells.SetSelectionByFieldValues(false, new object[] { "Chai" });
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

                MainForm.FlyToPosition(lon, lat);

                HRQ.SubForm.ReportForm rf = new SubForm.ReportForm(gridView1.GetDataRow(e.RowHandle));
                rf.Show();
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
}
