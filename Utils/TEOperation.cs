using TerraExplorerX;
using Timer = System.Timers.Timer;
namespace HRQ.Utils
{
    public class TEOperation
    {
        private static SGWorld66 sgworld = null;
        private static Timer timer;
        private long syncPoint;
        private int timerCount = 0;
        private string blinkPath = "";

        public string BlinkPath
        {
            get
            {
                return blinkPath;
            }

            set
            {
                blinkPath = value;
            }
        }

        public TEOperation()
        {
            sgworld = new SGWorld66();
            timer = new Timer();
            timer.Interval = 350; //1 sec
            timer.AutoReset = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            syncPoint = 0;
        }

        public void BlinkObject()
        {
            timer.Start();
        }
        
        delegate void Blink();
        private void BlinkObj()
        {
            var objID = sgworld.ProjectTree.FindItem(blinkPath);
            var obj = sgworld.ProjectTree.GetObject(objID);

            Blink del = (Blink)delegate
            {
                //obj.vi.Visible = !label1.Visible;
                var visible = sgworld.ProjectTree.GetVisibility(objID);
                bool b = visible == 1 ? false : true;
                sgworld.ProjectTree.SetVisibility(objID, b);
                if (timerCount < 5)
                {
                    timerCount++;
                }
                else
                {
                    timerCount = 0;
                    timer.Stop();
                    timer.Close();
                }
            };
            del();
        }
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            long sync = System.Threading.Interlocked.CompareExchange(ref syncPoint, 1, 0);
            if (sync == 0)
            {
                try
                {
                    BlinkObj();
                }
                finally
                {
                    syncPoint = 0;
                }
            }
        }

        public static void FlyToPosition(double lon, double lat)
        {
            SGWorld66 sg = new SGWorld66();
            IPosition66 _pos = sg.Creator.CreatePosition(lon, lat, 0, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, -45, 0, 200);
            sg.Navigate.FlyTo(_pos);
        }
    }
}
