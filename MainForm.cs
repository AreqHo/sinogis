using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraEditors.ColorWheel;
using TerraExplorerX;
using HRQ.SubForm;
using Timer = System.Timers.Timer;
using System.Timers;

namespace HRQ {
    public partial class MainForm : RibbonForm {
        public static Size HoverSkinImageSize = new Size(116, 86);
        public static Size SkinImageSize = new Size(58, 43);

        public static SGWorld66 sgworld = null;

        public static String TEMP_GROUP_ID = String.Empty;

        private String pbhander = "";

        private TransectForm mTransectFrom = null;

        private ITerrain3DPolygon66 pIT3DPolygon = null;

        private ITerrainPolygon66 pITPolygon = null;

        private IWorldPointInfo66 pFirstPoint = null;

        private LineProperties mLineProperties = null;

        public MainForm() {
            InitializeComponent();

            InitSkins();
            SelectDefaultPage();
            Icon = DevExpress.Utils.ResourceImageHelper.CreateIconFromResourcesEx("appIcon.ico", typeof(MainForm).Assembly);
            rand = new Random();
        }

        #region 其他
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            SplashScreenManager.CloseForm();
        }
        GalleryItem rightClickItem;
        NavBarItemLink customizableLink;
        List<GalleryItem> markedItems;
        Random rand;

        protected List<GalleryItem> MarkedItems {
            get {
                if (markedItems == null)
                    markedItems = new List<GalleryItem>();
                return markedItems;
            }
        }
        protected string GetDataDir() {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            for (int i = 0; i < 10; i++) {
                path += "..\\";
                if (Directory.Exists(path + "Data"))
                    return path + "Data";
            }
            return string.Empty;
        }
        protected string DataPath {
            get {
                string dataPath = GetDataDir() + "\\PhotoViewer";
                if (Directory.Exists(dataPath))
                    return dataPath;
                return string.Empty;
            }
        }
        protected GalleryItem RightClickItem { get { return rightClickItem; } set { rightClickItem = value; } }
        protected NavBarItemLink CustomizableLink { get { return customizableLink; } set { customizableLink = value; } }


        private void InitSkins() {
            SkinHelper.InitSkinGallery(skinGalleryBarItem, true);
            UserLookAndFeel.Default.SetSkinStyle("Stardust");
        }
        private Bitmap GetSkinImage(UserLookAndFeel userLF, Size sz, int indent) {
            Bitmap image = new Bitmap(sz.Width, sz.Height);
            using (Graphics g = Graphics.FromImage(image)) {
                StyleObjectInfoArgs info = new StyleObjectInfoArgs(new GraphicsCache(g));
                info.Bounds = new Rectangle(Point.Empty, sz);
                userLF.Painter.Button.DrawObject(info);
                info.Bounds = new Rectangle(indent, indent, sz.Width - indent * 2, sz.Height - indent * 2);
            }
            return image;
        }
        private void SelectDefaultPage() {
            ribbonControl1.SelectedPage = rpHomePage;
        }

        private void OnExitButtonClick(object sender, EventArgs e) {
            if (XtraMessageBox.Show(this, "Exit Application?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Close();
            }
        }

        private void OnAboutItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            BarManager.About();
        }

        private RectangleF InflateClip(GraphicsCache cache) {
            RectangleF clipBounds = cache.Graphics.ClipBounds;
            RectangleF rect = cache.Graphics.ClipBounds;
            rect.Inflate(50, 50);
            cache.Graphics.SetClip(rect);
            return clipBounds;
        }

        private void HideViewCategory() {
            if (viewPageCategory.Pages.Count == 1)
                viewPageCategory.Visible = false;
        }

        private List<string> GetFilesInSelection() {
            List<GalleryItem> items = MarkedItems;
            List<string> res = new List<string>(items.Count);
            foreach (GalleryItem item in items) {
                res.Add((string)item.Tag);
            }
            return res;
        }

        private void UpdateAddToLibraryItem(BarItem item) {

        }

        private void bBColorMix_ItemClick(object sender, ItemClickEventArgs e) {
            ColorWheelForm form = new ColorWheelForm();
            form.StartPosition = FormStartPosition.CenterParent;
            form.SkinMaskColor = UserLookAndFeel.Default.SkinMaskColor;
            form.SkinMaskColor2 = UserLookAndFeel.Default.SkinMaskColor2;
            form.ShowDialog(this);
        }

        private void CheckItemContextButton(GalleryItem galleryItem, CheckContextButton checkItem) {
            if (checkItem.Checked && !MarkedItems.Contains(galleryItem))
                MarkedItems.Add(galleryItem);
            if (!checkItem.Checked && MarkedItems.Contains(galleryItem))
                MarkedItems.Remove(galleryItem);
        }

        private void galleryControlGallery1_GetThumbnailImage(object sender, DevExpress.XtraBars.Ribbon.Gallery.GalleryThumbnailImageEventArgs e) {
            e.ThumbnailImage = e.CreateThumbnailImage(Image.FromFile((string)e.Item.Tag));
        }
        #endregion
        private void MainForm_Load(object sender, EventArgs e) {

            HRQ.Utils.DevExpressLocalizerHelper.SetSimpleChinese();

            string tMsg = String.Empty;

            string tAppRoot = Path.GetDirectoryName(Application.ExecutablePath);

            string tProjectUrl = Path.Combine(tAppRoot, @"Fly\Default.fly");
            //string tProjectUrl = @"D:\\Changzhi\\default.fly";

            bool bIsAsync = false;

            string tUser = String.Empty;

            string tPassword = String.Empty;

            try {
                sgworld = new SGWorld66();

                sgworld.OnLoadFinished += new _ISGWorld66Events_OnLoadFinishedEventHandler(OnProjectLoadFinished);

                sgworld.Project.Open(tProjectUrl, bIsAsync, tUser, tPassword);

                sgworld.OnLButtonDown += new _ISGWorld66Events_OnLButtonDownEventHandler(OnLButtonDown);

                sgworld.OnLButtonUp += new _ISGWorld66Events_OnLButtonUpEventHandler(OnLButtonUp);

                sgworld.OnFrame += new _ISGWorld66Events_OnFrameEventHandler(OnFrame);

                var hid = sgworld.ProjectTree.HiddenGroupID;

                TEMP_GROUP_ID = sgworld.ProjectTree.CreateLockedGroup("TEMP", hid);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                sgworld.Command.Execute(1001, String.Empty);//打开FLY工程
            }
        }

        #region TE event
        private void OnFrame() {
            var mouseInfo = sgworld.Window.GetMouseInfo();
            IWorldPointInfo66 pIWPInfo = sgworld.Window.PixelToWorld(mouseInfo.X, mouseInfo.Y, WorldPointType.WPT_TERRAIN);
            this.bsiMouseLon.Caption = "经度：" + Math.Round(pIWPInfo.Position.X, 6);
            this.bsiMouseLat.Caption = "纬度：" + Math.Round(pIWPInfo.Position.Y, 6);
            this.bsiMouseAltitude.Caption = "高程：" + Math.Round(pIWPInfo.Position.Altitude, 4);
        }
        private bool OnLButtonUp(int Flags, int X, int Y)
        {
            if (pbhander == "transectPolygon")
            {
                if (pIT3DPolygon != null)
                {
                    pbhander = "";
                    sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
                    sgworld.ProjectTree.EndEdit();

                    List<LineAttribute> pointList = new List<LineAttribute>();

                    IFeatureLayer66 iLineLayer = sgworld.ProjectTree.GetLayer(sgworld.ProjectTree.FindItem("电力线\\line"));
                    IFeatures66 lineLayerFeature = iLineLayer.ExecuteSpatialQuery(pIT3DPolygon.Geometry, IntersectionType.IT_INTERSECT);
                    for (int i = 0; i < lineLayerFeature.Count; i++)
                    {
                        LineAttribute la = new LineAttribute();
                        IFeature66 lineFeature = lineLayerFeature[i] as IFeature66;
                        var objLine = lineFeature.Geometry as ILineString;
                        var intersectionGeo = objLine.SpatialOperator.Intersection(pIT3DPolygon.Geometry) as ILineString;
                        var point = (IPoint)intersectionGeo.Points[0];
                        la.X = point.X;
                        la.Y = point.Y;
                        la.Z = point.Z * 2;
                        la.ArcLength = objLine.Length;
                        la.Height = point.Z * 2;
                        if (i == 0)
                        {
                            la.Distance = 0;
                        }
                        else {
                            var dis = sgworld.CoordServices.GetDistance(point.X, point.Y,
                                    pointList[0].X, pointList[0].Y);
                            la.Distance = dis;
                        }
                        pointList.Add(la);
                    }
                    if (pointList.Count > 0)
                    {
                        if (mTransectFrom != null)
                        {
                            mTransectFrom.Close();
                            mTransectFrom.Dispose();
                        }
                        mTransectFrom = new TransectForm();
                        mTransectFrom.LineAttribute = pointList;
                        mTransectFrom.ShowDialog();
                        mTransectFrom.Focus();
                    }
                }
            }
            return false;
        }
        private bool OnLButtonDown(int Flags, int X, int Y) {
            if (pbhander == "QUERYPROPERTY")
            {
                IWorldPointInfo66 pIWPInfo = sgworld.Window.PixelToWorld(X, Y, WorldPointType.WPT_MODEL);
                pbhander = "";
                sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
                if (pIWPInfo.ObjectID != "") { 
                    var obj = sgworld.Creator.GetObject(pIWPInfo.ObjectID);
                    var ot = obj.ObjectType;
                    var objFeature = obj as ITerrainModel66;

                    if (objFeature != null)
                    {
                        if (objFeature.ObjectType.Equals(ObjectTypeCode.OT_MODEL))
                        {
                            string name = objFeature.Tooltip.Text;
                            long ias = long.Parse(name);
                            //弹出属性窗口
                            PropertiesForm pf = new PropertiesForm(ias);
                            pf.ShowDialog();
                        }
                    }
                }
            }
            uint nLineColor = 0x3F0000FF;
            uint nFillColor = 0x6F646464;
            if (pbhander == "TransectAnalysisFeature")
            {
                IWorldPointInfo66 pIWPInfo = sgworld.Window.PixelToWorld(X, Y, WorldPointType.WPT_TERRAIN);
                IPosition66 pIPosition = sgworld.Navigate.GetPosition(AltitudeTypeCode.ATC_ON_TERRAIN);
                if (pITPolygon == null)
                {
                    ILinearRing cRing = null;
                    double[] cVerticesArray = null;
                    cVerticesArray = new double[] {
                        pIPosition.X,  pIPosition.Y,  0,
                        pIWPInfo.Position.X,  pIWPInfo.Position.Y,  0,
                        pIWPInfo.Position.X,  pIWPInfo.Position.Y,  0,
                    };

                    pFirstPoint = pIWPInfo;

                    cRing = sgworld.Creator.GeometryCreator.CreateLinearRingGeometry(cVerticesArray);

                    AltitudeTypeCode eAltitudeTypeCode = AltitudeTypeCode.ATC_ON_TERRAIN;

                    pITPolygon = sgworld.Creator.CreatePolygon(cRing, nLineColor, nFillColor, eAltitudeTypeCode, TEMP_GROUP_ID, "Polygon");

                    IPolygon polygonGeometry = pITPolygon.Geometry as IPolygon;
                    polygonGeometry.StartEdit();
                    foreach (ILinearRing ring in polygonGeometry.Rings)
                    {
                        double dx = pIWPInfo.Position.X;
                        double dy = pIWPInfo.Position.Y;
                        double dh = 0;
                        ring.Points.AddPoint(dx, dy, dh);
                        ring.Points.DeletePoint(0);
                    }
                    IGeometry editedGeometry = polygonGeometry.EndEdit();
                    pITPolygon.Geometry = editedGeometry;
                }
                else {
                    IPolygon polygonGeometry = pITPolygon.Geometry as IPolygon;
                    polygonGeometry.StartEdit();
                    foreach (ILinearRing ring in polygonGeometry.Rings)
                    {
                        double dx = pIWPInfo.Position.X;
                        double dy = pIWPInfo.Position.Y;
                        double dh = pIWPInfo.Position.Distance;

                        ring.Points.AddPoint(dx, dy, 0);

                        ring.Points.AddPoint(dx + 0.0000000000001, dy + 0.0000000000001, 0);

                        ring.Points.AddPoint(pFirstPoint.Position.X + 0.0000000000001, pFirstPoint.Position.Y + 0.0000000000001, 0);
                    }
                    IGeometry editedGeometry = polygonGeometry.EndEdit();
                    pITPolygon.Geometry = editedGeometry;
                    pIT3DPolygon = sgworld.Creator.Create3DPolygon(pITPolygon.Geometry, 100, nLineColor, nFillColor, AltitudeTypeCode.ATC_ON_TERRAIN, TEMP_GROUP_ID, "3DPolygon");
                    pbhander = "transectPolygon";
                }
            }
            //点选查询电力线
            else if (pbhander.Equals("SelectedAnalysisFeature"))
            {
                IWorldPointInfo66 pIWPInfo = sgworld.Window.PixelToWorld(X, Y, WorldPointType.WPT_PRIMITIVE);
                pbhander = "";
                sgworld.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT);
                var obj = sgworld.Creator.GetObject(pIWPInfo.ObjectID);
                var objFeature = obj as IFeature66;
                if (objFeature != null)
                {
                    if (objFeature.Geometry.GeometryType.Equals(SGGeometryTypeId.SG_LINESTRING))
                    {
                        //objFeature.Tint.abgrColor = 0xFFFF0000;
                        List<LineAttribute> pointList = new List<LineAttribute>();
                        List<LinePointProperties> points = new List<LinePointProperties>();
                        var objLine = objFeature.Geometry as ILineString;
                        IPoint compareMinPoint = null;
                        IPoint compareMaxPoint = null;

                        for (int j = 0; j < objLine.Points.Count; j++)
                        {
                            LinePointProperties lpp = new LinePointProperties();
                            IPoint iPoint = objLine.Points[j] as IPoint;

                            double pointHeight = iPoint.Z;
                            if (pointHeight > 0)
                            {
                                lpp.X = iPoint.X;
                                lpp.Y = iPoint.Y;
                                lpp.Z = iPoint.Z;
                                lpp.Height = pointHeight;

                                IPoint iPointClone = iPoint.Clone() as IPoint;
                                iPointClone.Z = pointHeight;

                                if (j == 0)
                                {
                                    lpp.Distance = 0;
                                    compareMinPoint = iPointClone;
                                    compareMaxPoint = iPointClone;
                                }
                                else {
                                    var dis = sgworld.CoordServices.GetDistance(iPoint.X, iPoint.Y,
                                        points[0].X, points[0].Y);
                                    lpp.Distance = dis;

                                    if (compareMinPoint.Z > iPointClone.Z)
                                    {
                                        compareMinPoint = iPointClone;
                                    }
                                    if (compareMaxPoint.Z < iPointClone.Z)
                                    {
                                        compareMaxPoint = iPointClone;
                                    }
                                }
                                points.Add(lpp);
                            }
                        }
                        if (compareMinPoint != null && compareMaxPoint != null)
                        {
                            LineAttribute minLA = getLA(compareMinPoint);
                            LineAttribute maxLA = getLA(compareMaxPoint);
                            double disHeight = maxLA.Height - minLA.Height;
                            minLA.DisHeight = disHeight;
                            maxLA.DisHeight = disHeight;

                            minLA.ArcLength = objLine.Length;
                            maxLA.ArcLength = objLine.Length;

                            var disMin = sgworld.CoordServices.GetDistance(compareMinPoint.X, compareMinPoint.Y,
                                       points[0].X, points[0].Y);

                            minLA.Distance = disMin;

                            var disMax = sgworld.CoordServices.GetDistance(compareMaxPoint.X, compareMaxPoint.Y,
                                       points[0].X, points[0].Y);

                            maxLA.Distance = disMax;

                            pointList.Add(minLA);
                            pointList.Add(maxLA);
                        }

                        if (pointList.Count > 0 && points.Count > 0)
                        {
                            if (mLineProperties != null)
                            {
                                mLineProperties.Close();
                                mLineProperties.Dispose();
                            }
                            mLineProperties = new LineProperties();
                            mLineProperties.LineAttribute = pointList;
                            mLineProperties.LinePoint = points;
                            mLineProperties.Show();
                            mLineProperties.Focus();
                        }
                    }
                }
            }

            return false;
        }
        private LineAttribute getLA(IPoint _iPoint) {
            LineAttribute la = new LineAttribute();
            la.X = _iPoint.X;
            la.Y = _iPoint.Y;
            la.Z = _iPoint.Z;
            la.Height = _iPoint.Z;
            return la;
        }
        public void OnProjectLoadFinished(bool bSuccess)
        {
            string tMsg = String.Empty;

            try {
                //XtraMessageBox.Show("加载工程文件" + ((bSuccess) ? "成功" : "失败") + "!");
                //var lineLayer = sgworld.ProjectTree.GetLayer(sgworld.ProjectTree.FindItem("电力线\\powerlines"));
                SettingForm sf = new SettingForm();
                sf.ShowDialog();
            }
            catch (Exception ex) {
                tMsg = String.Format("加载工程文件异常: {0}", ex.Message);
                XtraMessageBox.Show(tMsg);
            }
        }
        #endregion

        #region 公共方法
        public static String CreateGroup() {
            var hid = sgworld.ProjectTree.HiddenGroupID;
            if (TEMP_GROUP_ID != null && TEMP_GROUP_ID != "") {
                sgworld.ProjectTree.DeleteItem(TEMP_GROUP_ID);
            }
            TEMP_GROUP_ID = sgworld.ProjectTree.CreateLockedGroup("TEMP", hid);
            return TEMP_GROUP_ID;
        }
        #endregion

        #region 按钮点击事件

        private void biSave_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1003, 0, false);//保存FLY工程
        }

        private void biOpenProject_ItemClick(object sender, ItemClickEventArgs e) {
            sgworld.Command.Execute(1001, String.Empty);//打开FLY工程
        }

        private void biSaveAs_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1004, 0, false);//另存为FLY工程
        }

        private void bbSelectObj_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1021, 0, false);
        }

        private void bbCopy_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1031, 0, false);
        }

        private void bbPaste_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1030, 0, false);
        }

        private void bbDelete_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1033, 0, false);
        }

        private void bbTextMark_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1012, 0, false);
        }

        private void bbImgMark_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1012, 1, false);
        }

        private void bbGroundVideo_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1012, 2, false);
        }

        private void bbBillboardVideo_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1012, 3, false);
        }

        private void bbSun_ItemClick(object sender, ItemClickEventArgs e) {
            BarCheckItem btiSun = e.Item as BarCheckItem;
            if (btiSun.Checked) {
                sgworld.DateTime.DisplaySun = true;
            }
            else {
                sgworld.DateTime.DisplaySun = false;
            }
        }

        private void bbUnderGround_ItemClick(object sender, ItemClickEventArgs e) {
            BarCheckItem btiUnderGround = e.Item as BarCheckItem;
            if (btiUnderGround.Checked) {
                sgworld.Navigate.UndergroundMode = true;
            }
            else {
                sgworld.Navigate.UndergroundMode = false;
            }
        }

        private void bbLoadFeatureLayer_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1013, 12, false);
        }

        private void bbRasterLayerLoad_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1014, 2, false);
        }

        private void bbiImageLayerAdd_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1014, 2, false);
        }

        private void bbiElevationLayerAdd_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1014, 19, false);
        }

        private void bbSimpleModel_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1012, 14, false);
        }

        private void bbStandardModel_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1012, 13, false);
        }

        private void bb2D_Line_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1012, 4, false);
        }

        private void bb2D_Polygon_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1012, 5, false);
        }

        private void bb2D_Rectangle_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1012, 6, false);
        }

        private void bb2D_Arrow_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1012, 8, false);
        }

        private void bb2D_Circle_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1012, 9, false);
        }

        private void bb2D_Ellipse_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1012, 10, false);
        }

        private void bb2D_Arc_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1012, 11, false);
        }

        private void bb3D_Cube_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1012, 18, false);
        }

        private void bb3D_Cylinder_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1012, 20, false);
        }

        private void bb3D_Ball_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1012, 21, false);
        }

        private void bb3D_Cone_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1012, 22, false);
        }

        private void bb3D_Pyramid_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1012, 23, false);
        }

        private void bb3D_Arrow_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1012, 24, false);
        }

        private void bbGroundObj_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1012, 26, false);
        }

        private void bbAirObj_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1012, 27, false);
        }

        private void bbScreenshot_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1067, 0, false);
        }

        private void sgworldCommandExecute(int _code, int _parameter, bool isEx) {
            sgworld.Command.Execute(_code, _parameter);
        }

        private void bbLineTransectAnalysis_ItemClick(object sender, ItemClickEventArgs e) {
            pbhander = "TransectAnalysisFeature";
            pITPolygon = null;
            pFirstPoint = null;
            sgworld.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT);
        }

        private void bbiDataFind_ItemClick(object sender, ItemClickEventArgs e) {
            //find data from access
            dockData.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
        }

        private void bbHorizontal_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1034, 0, true);
        }

        private void bbVertical_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1036, 0, true);
        }
        
        private void bbi2DView_ItemClick(object sender, ItemClickEventArgs e) {

        }

        private void bbiTerraAnalysis_ItemClick(object sender, ItemClickEventArgs e) {
            TerraAnalysis ta = new TerraAnalysis();
            ta.Show();
        }

        private void bbiViewAnalysis_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1047, 0, false);
        }
        private void bbiLineSight_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1046, 0, false);
        }

        
        private void bbiViewVideo_ItemClick(object sender, ItemClickEventArgs e) {
            var _VRView = sgworld.ProjectTree.FindItem("全景视图");
            sgworld.Navigate.FlyTo(_VRView);
        }

        private void bbiViewVRImg_ItemClick(object sender, ItemClickEventArgs e) {
            var _VRVideo = sgworld.ProjectTree.FindItem("全景视频");
            sgworld.Navigate.FlyTo(_VRVideo);

            var _vrVideoID = sgworld.ProjectTree.FindItem("全景视频\\VR");
            if (_vrVideoID != null) {
                ITerrainVideo66 _itVideo = sgworld.ProjectTree.GetObject(_vrVideoID) as ITerrainVideo66;
                _itVideo.PlayVideo();
            }
        }

        private void bbiZoomGlobe_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1055, 5, true);
        }

        private void bbiZoomCountry_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1055, 4, true);
        }

        private void bbiZoomState_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1055, 3, true);
        }

        private void bbiZoomCity_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1055, 2, true);
        }

        private void bbiZoomStreet_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1055, 1, true);
        }

        private void bbiZoomHouse_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1055, 0, true);
        }

        private void bciDrag_CheckedChanged(object sender, ItemClickEventArgs e) {
            //BarCheckItem bciDrag = e.Item as BarCheckItem;
            //if (bciDrag.Checked) {
            //    sgworldCommandExecute(1055, 0);
            //}
            //else {
            //    sgworld.DateTime.DisplaySun = false;
            //}
        }

        private void bbLookAround_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1057, 0, false);
        }

        private void bbSpiral_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1057, 1, false);
        }

        private void bbArea_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1165, 0, false);
        }

        private void bbContourLine_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1039, 0, false);
        }

        private void bbiContourLineAndMap_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1040, 0, false);
        }

        private void bbiContourLegend_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1041, 0, false);
        }

        private void bbiSlopeDirection_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1093, 0, false);
        }

        private void bbiSlopeMapAndDirection_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1094, 0, false);
        }

        private void bbiSlopeLegend_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1098, 0, false);
        }

        private void bbiPropertyQuery_ItemClick(object sender, ItemClickEventArgs e)
        {
            pbhander = "QUERYPROPERTY";
            sgworldCommandExecute(1021, 0, false);
        }

        private void bbLineSelectedQuery_ItemClick(object sender, ItemClickEventArgs e)
        {
            progressC.Visible = true;
            dockData.Height = 300;
            this.controlContainer2.Controls.Clear();
            HRQ.Modules.LineGrid cg = new HRQ.Modules.LineGrid();
            cg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlContainer2.Controls.Add(cg);
            dockData.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
            progressC.Visible = false;
        }

        private void bbiTowerQuery_ItemClick(object sender, ItemClickEventArgs e) {
            progressC.Visible = true;
            dockData.Height = 300;
            this.controlContainer2.Controls.Clear();
            HRQ.Modules.PoleGrid pg = new HRQ.Modules.PoleGrid();
            pg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlContainer2.Controls.Add(pg);
            dockData.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
            progressC.Visible = false;
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            progressC.Visible = true;
            dockData.Height = 300;
            this.controlContainer2.Controls.Clear();
            HRQ.Modules.ReportGrid rg = new HRQ.Modules.ReportGrid();
            rg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlContainer2.Controls.Add(rg);
            dockData.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
            progressC.Visible = false;
        }

        private void bbiMakeCPT_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1149, 10, false);
        }

        private void bbiLoadPointCloud_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1012, 25, false);
        }

        private void bbiPresentation_ItemClick(object sender, ItemClickEventArgs e) {

            if (bciPresentationRecord.Visibility == BarItemVisibility.Never) {
                bciPresentationRecord.Visibility = BarItemVisibility.Always;
            }
            sgworldCommandExecute(1015, 0, false);
        }

        private void bciPresentationRecord_CheckedChanged(object sender, ItemClickEventArgs e) {
            BarCheckItem bciPreRecord = e.Item as BarCheckItem;
            sgworldCommandExecute(1101, 0, false);
        }

        private void bbiNavigateNorth_ItemClick(object sender, ItemClickEventArgs e) {
            sgworldCommandExecute(1056, 0, false);
        }
        

        private void bbiQueryPole_ItemClick(object sender, ItemClickEventArgs e)
        {
            progressC.Visible = true;
            dockData.Height = 300;
            this.controlContainer2.Controls.Clear();
            HRQ.Modules.LineGrid cg = new HRQ.Modules.LineGrid();
            cg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlContainer2.Controls.Add(cg);
            dockData.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
            progressC.Visible = false;
        }

        private void bbiWire_ItemClick(object sender, ItemClickEventArgs e)
        {
            pbhander = "SelectedAnalysisFeature";
            sgworldCommandExecute(1021, 0, false);
        }

        private void bbiQueryIntrusion_ItemClick(object sender, ItemClickEventArgs e)
        {
            progressC.Visible = true;
            dockData.Height = 300;
            this.controlContainer2.Controls.Clear();
            HRQ.Modules.ChartGrid cg = new HRQ.Modules.ChartGrid();
            cg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlContainer2.Controls.Add(cg);
            dockData.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
            progressC.Visible = false;
        }
        #endregion

        private void bbiSetting_ItemClick(object sender, ItemClickEventArgs e)
        {
            SettingForm sf = new SettingForm();
            sf.ShowDialog();
        }
    }

    public class LineAttribute
    {
        private double x = 0.0;

        public double X
        {
            get { return x; }
            set { x = value; }
        }
        private double y = 0.0;

        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        private double z = 0.0;

        public double Z
        {
            get { return z; }
            set { z = value; }
        }
        private double arcLength = 0.0;

        public double ArcLength
        {
            get { return arcLength; }
            set { arcLength = value; }
        }
        private double height = 0.0;

        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        private double distance = 0.0;

        public double Distance
        {
            get { return distance; }
            set { distance = value; }
        }

        private double disHeight = 0.0;

        public double DisHeight
        {
            get { return disHeight; }
            set { disHeight = value; }
        }
    }

    public class LinePointProperties
    {
        private double x = 0.0;

        public double X
        {
            get { return x; }
            set { x = value; }
        }
        private double y = 0.0;

        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        private double z = 0.0;

        public double Z
        {
            get { return z; }
            set { z = value; }
        }
        private double height = 0.0;
        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        private double distance = 0.0;

        public double Distance
        {
            get { return distance; }
            set { distance = value; }
        }
    }
}
