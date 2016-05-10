using System;
using System.Collections.Generic;
using DevExpress.XtraCharts;
using System.Text;
using DevExpress.Utils;

namespace HRQ.SubForm
{
    public partial class TransectForm : DevExpress.XtraEditors.XtraForm {

        List<LineAttribute> mLineAttribute = null;

        public List<LineAttribute> LineAttribute {
            get { return mLineAttribute; }
            set { mLineAttribute = value; }
        }

        public TransectForm() {
            InitializeComponent();
        }

        private void TransectForm_Load(object sender, EventArgs e) {
            if (mLineAttribute.Count > 0) {
                chart.Series.Clear();
                
                Series pointSeries = new Series("剖面视图", ViewType.Point);
                pointSeries.ArgumentDataMember = "Distance";//x轴
                pointSeries.ValueDataMembers[0] = "Height";//Y轴
                pointSeries.ColorDataMember = "Distance";
                pointSeries.DataSource = mLineAttribute;
                pointSeries.ShowInLegend = true;
                chart.Series.Add(pointSeries);
            }
        }

        private void chart_CustomDrawCrosshair(object sender, CustomDrawCrosshairEventArgs e) {
            foreach (CrosshairElement element in e.CrosshairElements) {
                SeriesPoint point = element.SeriesPoint;
                var pv = point.Values[0].ToString();
                for (int i = 0; i < mLineAttribute.Count; i++) {
                    var la = mLineAttribute.ToArray()[i];
                    if (la.Height.ToString().Substring(0,8).Equals(pv.Substring(0,8))) {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("经度：" + la.X);
                        sb.AppendLine("");
                        sb.AppendLine("纬度：" + la.Y);
                        sb.AppendLine("");
                        sb.AppendLine("高度：" + la.Height);
                        sb.AppendLine("");
                        sb.AppendLine("长度：" + la.ArcLength);
                        element.LabelElement.Text = sb.ToString();//显示要显示的文字
                    }
                }
            }
        }

        private void TransectForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e) {
            MainForm.CreateGroup();
        }
    }
}