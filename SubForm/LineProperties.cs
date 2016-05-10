using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;

namespace HRQ.SubForm {
    public partial class LineProperties : DevExpress.XtraEditors.XtraForm {
        List<LineAttribute> mLineAttribute = null;

        public List<LineAttribute> LineAttribute {
            get { return mLineAttribute; }
            set { mLineAttribute = value; }
        }

        List<LinePointProperties> mLinePoint = null;

        public List<LinePointProperties> LinePoint {
            get { return mLinePoint; }
            set { mLinePoint = value; }
        }

        public LineProperties() {
            InitializeComponent();
        }

        private void LineProperties_Load(object sender, EventArgs e) {
            chart.Series.Clear();
            if (mLinePoint.Count > 0) {
                Series pointsSeries = new Series("电力线", ViewType.Spline);
                pointsSeries.ArgumentDataMember = "Distance";//x轴
                pointsSeries.ValueDataMembers[0] = "Height";//Y轴
                pointsSeries.ColorDataMember = "Distance";
                pointsSeries.DataSource = mLinePoint;
                pointsSeries.ShowInLegend = true;
                chart.Series.Add(pointsSeries);
            }
            if (mLineAttribute.Count > 0) {
                Series pointSeries = new Series("极值点位", ViewType.Point);
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
                if (element.Series.Name.Equals("极值点位")) {
                    for (int i = 0; i < mLineAttribute.Count; i++) {
                    var la = mLineAttribute.ToArray()[i];
                        if (la.Height.ToString().Substring(0, 8).Equals(pv.Substring(0, 8))) {
                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine("经度：" + la.X);
                            sb.AppendLine("");
                            sb.AppendLine("纬度：" + la.Y);
                            sb.AppendLine("");
                            sb.AppendLine("高度：" + la.Height);
                            sb.AppendLine("");
                            sb.AppendLine("高差：" + la.DisHeight);
                            sb.AppendLine("");
                            sb.AppendLine("长度：" + la.ArcLength);
                            element.LabelElement.Text = sb.ToString();//显示要显示的文字
                        }
                    }
                }
                
            }
        }
    }
}