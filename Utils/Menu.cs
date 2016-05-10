using System;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraCharts;

namespace HRQ.Utils {
	struct Strings {
		public struct LegendAlignmentHorizontal {
			public const string leftOutside = "Left Outside   ";
			public const string left = "Left   ";
			public const string center = "Center   ";
			public const string rigth = "Right   ";
			public const string rightOutside = "Right Outside   ";
		}
	
		public struct LegendAlignmentVertical {
			public const string topOutside = "Top Outside   ";
			public const string top = "Top   ";
			public const string center = "Center   ";
			public const string bottom = "Bottom   ";
			public const string bottomOutside = "Bottom Outside   ";
		}
	
		public struct LegendDirection {
			public const string topToBottom = "Top To Bottom   ";
			public const string bottomToTop = "Bottom To Top   ";
			public const string leftToRight = "Left To Right   ";
			public const string rigthToLeft = "Right To Left   ";
		}

		public struct Axis {
			public const string reverse = "Reverse   ";
			public const string showGridLines = "Show Grid Lines   ";
			public const string showMinorGridLines = "Show Minor Grid Lines   ";
			public const string interlaced = "Interlaced   ";
			public const string showTitle = "Show Title   ";
			public const string showLabels = "Show Labels   ";
		}

		public struct Main {
			public const string rotated = "Rotated   ";
			public const string axisX = "Axis X   ";
			public const string axisY = "Axis Y   ";
			public const string legend = "Legend   ";
		}

		public struct Legend {
			public const string alignmentHorizontal = "Alignment Horizontal   ";
			public const string alignmentVertical = "Alignment Vertical   ";
			public const string direction = "Direction   ";
			public const string visible = "Visible   ";
		}

		public struct SecondaryAxes {
			public const string secondaryAxisX = "Secondary Axis X";
			public const string secondaryAxisY = "Secondary Axis Y";
		}
	}

	abstract class DXMenuBase : DXPopupMenu {
		protected ChartControl chart;

		public DXMenuBase(ChartControl chartControl, string caption, Image image) : base() {
			this.chart = chartControl;
            this.Caption = caption;
            this.Image = image;
		}
	}

	abstract class DXCheckItemBase : DXMenuCheckItem {
		protected ChartControl chart;

		public DXCheckItemBase(ChartControl chartControl, string caption) : base(caption) {
			this.chart = chartControl;
		}
	}

    abstract class DXCheckItemMainAxis : DXCheckItemBase {
        protected static Axis2D GetAxis(ChartControl chart, XYDiagramPaneBase pane, bool isAxisX) {
            foreach (Series series in chart.Series) {
                XYDiagramSeriesViewBase view = series.View as XYDiagramSeriesViewBase;
                if (view != null && view.Pane.Equals(pane))
                    return isAxisX ? (Axis2D)view.AxisX : (Axis2D)view.AxisY;
            }
            return null;
        }

        readonly XYDiagramPaneBase pane;

        protected XYDiagramPaneBase Pane { get { return pane; } }
        protected abstract Axis2D Axis2D { get; }

        public DXCheckItemMainAxis(ChartControl chartControl, XYDiagramPaneBase pane, string caption) : base(chartControl, caption) {
            this.pane = pane;
            Checked = Axis2D.GetVisibilityInPane(Pane);
        }
        protected override void OnCheckedChanged() {
            base.OnCheckedChanged();
            Axis2D.SetVisibilityInPane(Checked, Pane);
        }
    }

	class DXMenuLegendAlignmentHorizontal : DXMenuBase {
		class DXCheckItem : DXCheckItemBase {
			LegendAlignmentHorizontal alignment;
		
			public DXCheckItem(LegendAlignmentHorizontal alignment, string caption, ChartControl chartControl) : base(chartControl, caption) {
				this.alignment = alignment;
				Checked = object.Equals(this.chart.Legend.AlignmentHorizontal, this.alignment);
			}

			protected override void OnCheckedChanged() {
				base.OnCheckedChanged();
				if(Checked)
					this.chart.Legend.AlignmentHorizontal = this.alignment;
			}
		}

		public DXMenuLegendAlignmentHorizontal(ChartControl chartControl, Image image) : base(chartControl, Strings.Legend.alignmentHorizontal, image) {
			DXCheckItem item = new DXCheckItem(LegendAlignmentHorizontal.LeftOutside, Strings.LegendAlignmentHorizontal.leftOutside, this.chart);
			Items.Add(item);

			item = new DXCheckItem(LegendAlignmentHorizontal.Left, Strings.LegendAlignmentHorizontal.left, this.chart);
			Items.Add(item);

			item = new DXCheckItem(LegendAlignmentHorizontal.Center, Strings.LegendAlignmentHorizontal.center, this.chart);
			Items.Add(item);
						
			item = new DXCheckItem(LegendAlignmentHorizontal.Right, Strings.LegendAlignmentHorizontal.rigth, this.chart);
			Items.Add(item);

			item = new DXCheckItem(LegendAlignmentHorizontal.RightOutside, Strings.LegendAlignmentHorizontal.rightOutside, this.chart);
			Items.Add(item);
		}
	}

	class DXMenuLegendAlignmentVertical : DXMenuBase {
		class DXCheckItem : DXCheckItemBase {
			LegendAlignmentVertical alignment;
		
			public DXCheckItem(LegendAlignmentVertical alignment, string caption, ChartControl chartControl) : base(chartControl, caption) {
				this.alignment = alignment;
				Checked = object.Equals(this.chart.Legend.AlignmentVertical, this.alignment);
			}
			
			protected override void OnCheckedChanged() {
				base.OnCheckedChanged();
				if (Checked)
					this.chart.Legend.AlignmentVertical = this.alignment;
			}
		}

		public DXMenuLegendAlignmentVertical(ChartControl chartControl, Image image) : base(chartControl, Strings.Legend.alignmentVertical, image) {
			DXCheckItem item = new DXCheckItem(LegendAlignmentVertical.TopOutside, Strings.LegendAlignmentVertical.topOutside, this.chart);
			Items.Add(item);

			item = new DXCheckItem(LegendAlignmentVertical.Top, Strings.LegendAlignmentVertical.top, this.chart);
			Items.Add(item);

			item = new DXCheckItem(LegendAlignmentVertical.Center, Strings.LegendAlignmentVertical.center, this.chart);
			Items.Add(item);

			item = new DXCheckItem(LegendAlignmentVertical.Bottom, Strings.LegendAlignmentVertical.bottom, this.chart);
			Items.Add(item);

			item = new DXCheckItem(LegendAlignmentVertical.BottomOutside, Strings.LegendAlignmentVertical.bottomOutside, this.chart);
			Items.Add(item);
		}
	}

	class DXMenuLegendDirection : DXMenuBase {
		class DXCheckItem : DXCheckItemBase {
			LegendDirection direction;

			public DXCheckItem(LegendDirection direction, string caption, ChartControl chartControl) : base(chartControl, caption) {
				this.direction = direction;
				Checked = object.Equals(this.chart.Legend.Direction, this.direction);
			}
			
			protected override void OnCheckedChanged() {
				base.OnCheckedChanged();
				if(Checked)
					this.chart.Legend.Direction = this.direction;
			}
		}

		public DXMenuLegendDirection(ChartControl chartControl, Image image) : base(chartControl, Strings.Legend.direction, image) {
			DXCheckItem item = new DXCheckItem(LegendDirection.TopToBottom, Strings.LegendDirection.topToBottom, this.chart);
			Items.Add(item);

			item = new DXCheckItem(LegendDirection.BottomToTop, Strings.LegendDirection.bottomToTop, this.chart);
			Items.Add(item);

			item = new DXCheckItem(LegendDirection.LeftToRight, Strings.LegendDirection.leftToRight, this.chart);
			Items.Add(item);
			
			item = new DXCheckItem(LegendDirection.RightToLeft, Strings.LegendDirection.rigthToLeft, this.chart);
			Items.Add(item);
		}
	}

	class DXMenuLegend : DXMenuBase {
		public DXMenuLegend(ChartControl chartControl, Image legendImage, Image alignmentHorizontalImage, Image alignmentVerticalImage, Image directionImage) : base(chartControl, Strings.Main.legend, legendImage) {
			Items.Add(new DXMenuLegendAlignmentHorizontal(this.chart, alignmentHorizontalImage));
			Items.Add(new DXMenuLegendAlignmentVertical(this.chart, alignmentVerticalImage));
			Items.Add(new DXMenuLegendDirection(this.chart, directionImage));
		}
	}

	abstract class DXMenuAxis : DXPopupMenu {
		abstract class AxisItemBase: DXMenuCheckItem {
			protected Axis axis;

			public AxisItemBase(Axis axis, string caption) : base(caption) {
				this.axis = axis;
			}
		}
		
		class AxisItemInterlaced : AxisItemBase {
			public AxisItemInterlaced(Axis axis) : base(axis, Strings.Axis.interlaced) {
				Checked = this.axis.Interlaced;
			}
			
			protected override void OnCheckedChanged() {
				this.axis.Interlaced = Checked;
			}
		}

		class AxisItemReverse : AxisItemBase {
			public AxisItemReverse(Axis axis) : base(axis, Strings.Axis.reverse) {
				Checked = this.axis.Reverse;
			}
			
			protected override void OnCheckedChanged() {
				this.axis.Reverse = Checked;
			}
		}

		class AxisItemShowGridLines : AxisItemBase {
			public AxisItemShowGridLines(Axis axis) : base(axis, Strings.Axis.showGridLines) {
				Checked = this.axis.GridLines.Visible;
			}
			
			protected override void OnCheckedChanged() {
				this.axis.GridLines.Visible = Checked;
			}
		}

		class AxisItemShowLabels : AxisItemBase {
			public AxisItemShowLabels(Axis axis) : base(axis, Strings.Axis.showLabels) {
				Checked = this.axis.Label.Visible;
			}
			
			protected override void OnCheckedChanged() {
				this.axis.Label.Visible = Checked;
			}
		}

		class AxisItemShowMinorGridLines : AxisItemBase {
			public AxisItemShowMinorGridLines(Axis axis) : base(axis, Strings.Axis.showMinorGridLines) {
				Checked = this.axis.GridLines.MinorVisible;
			}
			
			protected override void OnCheckedChanged() {
				this.axis.GridLines.MinorVisible = Checked;
			}
		}
		
		class AxisItemShowTitle : AxisItemBase {
			public AxisItemShowTitle(Axis axis) : base(axis, Strings.Axis.showTitle) {
				Checked = this.axis.Title.Visibility == DevExpress.Utils.DefaultBoolean.True;
			}
			
			protected override void OnCheckedChanged() {
                this.axis.Title.Visibility = Checked ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;
			}
		}
		
		public DXMenuAxis(string caption, Axis axis, Image image) : base() {
			this.Caption = caption;
			Items.Add(new AxisItemInterlaced(axis));
			Items.Add(new AxisItemReverse(axis));
			Items.Add(new AxisItemShowGridLines(axis));
			Items.Add(new AxisItemShowMinorGridLines(axis));
			Items.Add(new AxisItemShowLabels(axis));
			Items.Add(new AxisItemShowTitle(axis));
		}
	}

	class DXMenuAxisX : DXMenuAxis {
		public DXMenuAxisX(AxisXBase axisX, Image image) : base(Strings.Main.axisX, axisX, image) {
		}
	}
	
	class DXMenuAxisY : DXMenuAxis {
		public DXMenuAxisY(AxisYBase axisY, Image image) : base(Strings.Main.axisY, axisY, image) {
		}
	}

  	class DXMenuMain : DXMenuBase {
		class DXCheckItemMainRotated : DXCheckItemBase {
			public DXCheckItemMainRotated(ChartControl chartControl) : base(chartControl, Strings.Main.rotated) {
				Checked = ((XYDiagram)this.chart.Diagram).Rotated;
			}
			protected override void OnCheckedChanged() {
				base.OnCheckedChanged();
				((XYDiagram)this.chart.Diagram).Rotated = Checked;
			}
		}

        protected class DXCheckItemMainAxisX : DXCheckItemMainAxis {
            public static void CreateMenuItem(DXMenuMain menu, ChartControl chartControl, XYDiagramPaneBase pane) {
                if (GetAxis(chartControl, pane, true) != null)
                    menu.Items.Add(new DXCheckItemMainAxisX(chartControl, pane));
            }

            protected override Axis2D Axis2D { get { return GetAxis(chart, Pane, true); } }

            DXCheckItemMainAxisX(ChartControl chartControl, XYDiagramPaneBase pane) : base(chartControl, pane, Strings.Main.axisX) {
            }
        }

        protected class DXCheckItemMainAxisY : DXCheckItemMainAxis {
            public static void CreateMenuItem(DXMenuMain menu, ChartControl chartControl, XYDiagramPaneBase pane) {
                if (GetAxis(chartControl, pane, false) != null)
                    menu.Items.Add(new DXCheckItemMainAxisY(chartControl, pane));
            }

            protected override Axis2D Axis2D { get { return GetAxis(chart, Pane, false); } }

            DXCheckItemMainAxisY(ChartControl chartControl, XYDiagramPaneBase pane) : base(chartControl, pane, Strings.Main.axisY) {
            }
        }

		class DXCheckItemMainLegend : DXCheckItemBase {
			public DXCheckItemMainLegend(ChartControl chartControl) : base(chartControl, Strings.Main.legend) {
				Checked = this.chart.Legend.Visibility != DefaultBoolean.False;
			}
			protected override void OnCheckedChanged() {
				base.OnCheckedChanged();
				this.chart.Legend.Visibility = Checked ? DefaultBoolean.Default : DefaultBoolean.False;
			}
		}

        static XYDiagramPaneBase GetDefaultPane(ChartControl chart) {
            return chart.Diagram is XYDiagram ? ((XYDiagram)chart.Diagram).DefaultPane : null;
        }

        public DXMenuMain(ChartControl chartControl) : this(chartControl, GetDefaultPane(chartControl)) {            
        }
        public DXMenuMain(ChartControl chartControl, XYDiagramPaneBase pane) : base(chartControl, "", null) {
            if (pane == null && chart.Diagram is XYDiagram)
                pane = GetDefaultPane(chartControl);
            CreateMenu(this, chartControl, pane);
        }
        void CreateMenu(DXMenuMain menu, ChartControl chartControl, XYDiagramPaneBase pane) {
            if (chart.Diagram is XYDiagram) {
                Items.Add(new DXCheckItemMainRotated(chartControl));
                DXCheckItemMainAxisX.CreateMenuItem(this, chartControl, pane);
                DXCheckItemMainAxisY.CreateMenuItem(this, chartControl, pane);
            }
            Items.Add(new DXCheckItemMainLegend(chartControl));
        }
    }
    
    class DXMenuPane : DXMenuMain {
        public DXMenuPane(ChartControl chartControl, XYDiagramPaneBase pane) : base(chartControl, pane) {
        }
    }

	class DXMenuGantt : DXMenuMain {
		public DXMenuGantt(ChartControl chartControl) : base(chartControl) {
			if (chart.Diagram is XYDiagram)
				Items.RemoveAt(0);
		}
	}

	class DXMenuSideBySideGantt : DXMenuGantt {
		public DXMenuSideBySideGantt(ChartControl chartControl) : base(chartControl) {
            if (chart.Diagram is XYDiagram) {
                Items.RemoveAt(0);
                Items.RemoveAt(0);
            }
		}
	}

	class DXMenuSecondaryAxes : DXMenuMain {
		class DXCheckItemMainSecondaryAxisX : DXCheckItemBase {
			SecondaryAxisX SecondaryAxisX { 
                get {
                    XYDiagram diagram = chart.Diagram as XYDiagram;
                    if(diagram != null && diagram.SecondaryAxesX.Count > 0)
                        return diagram.SecondaryAxesX[0];
                    return null;
                } 
            }
            
            public DXCheckItemMainSecondaryAxisX(ChartControl chartControl) : base(chartControl, Strings.SecondaryAxes.secondaryAxisX) {
                XYDiagramSeriesViewBase secondSeriesView = chart.Series.Count > 1 ? chart.Series[1].View as XYDiagramSeriesViewBase : null;
                if (SecondaryAxisX != null && secondSeriesView != null && secondSeriesView.AxisX == SecondaryAxisX) {
                    Checked = SecondaryAxisX.Visibility != DefaultBoolean.False;
					Enabled = true;
				} else {
					Checked = false;
					Enabled = false;
				}
			}
			protected override void OnCheckedChanged() {
				base.OnCheckedChanged();
                if (SecondaryAxisX != null)
                    SecondaryAxisX.Visibility = Checked ? DefaultBoolean.True : DefaultBoolean.False;
			}
		}

		class DXCheckItemMainSecondaryAxisY : DXCheckItemBase {
            SecondaryAxisY SecondaryAxisY {
                get {
                    XYDiagram diagram = chart.Diagram as XYDiagram;
                    if(diagram != null && diagram.SecondaryAxesY.Count > 0)
                        return diagram.SecondaryAxesY[0];
                    return null;
                }
            }

			public DXCheckItemMainSecondaryAxisY(ChartControl chartControl) : base(chartControl, Strings.SecondaryAxes.secondaryAxisY) {
                XYDiagramSeriesViewBase secondSeriesView = chart.Series.Count > 1 ? chart.Series[1].View as XYDiagramSeriesViewBase : null;
                if (SecondaryAxisY != null && secondSeriesView != null && secondSeriesView.AxisY == SecondaryAxisY) {
                    Checked = SecondaryAxisY.Visibility != DefaultBoolean.False;
                    Enabled = true;
                }
                else {
                    Checked = false;
                    Enabled = false;
                }
			}
			protected override void OnCheckedChanged() {
                base.OnCheckedChanged();
                if (SecondaryAxisY != null)
                    SecondaryAxisY.Visibility = Checked ? DefaultBoolean.True : DefaultBoolean.False;
			}
		}

		public DXMenuSecondaryAxes(ChartControl chartControl) : base(chartControl) {
			if (this.chart.Diagram is XYDiagram) {
				Items.Insert(3, new DXCheckItemMainSecondaryAxisY(chartControl));
				Items.Insert(3, new DXCheckItemMainSecondaryAxisX(chartControl));
			}
		}
	}

	sealed class DXMenuHelper {
		static DXPopupMenu ConstructMainMenu(DXMenuMain mainMenu, Object obj, ChartControl chartControl) {
			return ConstructMainMenu(mainMenu, obj, chartControl, null, null, null, null, null, null);
		}
		static DXPopupMenu ConstructMainMenu(DXMenuMain mainMenu, Object obj, ChartControl chartControl, Image legendImage, Image alignmentHorizontalImage, Image alignmentVerticalImage, Image directionImage, Image axisXImage, Image axisYImage) {
			DXPopupMenu extraMenu;
			if(obj is Legend)
				extraMenu = new DXMenuLegend(chartControl, legendImage, alignmentHorizontalImage, alignmentVerticalImage, directionImage);
			else if(obj is AxisXBase) 
				extraMenu = new DXMenuAxisX((AxisXBase)obj, axisXImage);
			else if(obj is AxisYBase) 
				extraMenu = new DXMenuAxisY((AxisYBase)obj, axisXImage);			
			else
				return mainMenu;
			for(int i = 0; i < extraMenu.Items.Count; i++) {
				if(i == 0)
					extraMenu.Items[i].BeginGroup = true;
				mainMenu.Items.Add(extraMenu.Items[i]);
			}
			return mainMenu;
		}
		public static DXPopupMenu ConstructMenu(Object obj, ChartControl chartControl) {
            return ConstructMainMenu(new DXMenuMain(chartControl), obj, chartControl);
		}
        public static DXPopupMenu ConstructPaneMenu(Object obj, ChartControl chartControl) {
            return ConstructMainMenu(new DXMenuPane(chartControl, obj as XYDiagramPaneBase), obj, chartControl);
        }
        public static DXPopupMenu ConstructGanttMenu(Object obj, ChartControl chartControl) {
			return ConstructMainMenu(new DXMenuGantt(chartControl), obj, chartControl);
		}
		public static DXPopupMenu ConstructSideBySideGanttMenu(Object obj, ChartControl chartControl) {
			return ConstructMainMenu(new DXMenuSideBySideGantt(chartControl), obj, chartControl);
		}
		public static DXPopupMenu ConstructSecondaryAxesMenu(Object obj, ChartControl chartControl) {
			return ConstructMainMenu(new DXMenuSecondaryAxes(chartControl), obj, chartControl);
		}

		DXMenuHelper() {
		}
	}
}
