using System.Timers;
using TerraExplorerX;

namespace HRQ.Utils
{
    class TEFunction
    {
        private static int flashFlag = 0;
        private static Timer timer = new Timer();
        private static string path = "";
        public static void splashObj(string _path)
        {
            path = _path;
            timer.Enabled = true;
            timer.Interval = 500; //执行间隔时间,单位为毫秒; 这里实际间隔为10分钟  
            timer.Start();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_splash);
        }

        private static void timer_splash(object sender, ElapsedEventArgs e)
        {
            flashFlag++;

            if(flashFlag == 3)
            {
                timer.Close();
                timer.Enabled = false;
                flashFlag = 0;
            }
            else
            {
                SGWorld66 sgworld = new SGWorld66();
                var objID = sgworld.ProjectTree.FindItem(path);
                var isVisible = sgworld.ProjectTree.GetVisibility(objID);
                if (isVisible == 0)
                {
                    sgworld.ProjectTree.SetVisibility(objID, true);
                }
                else
                {
                    sgworld.ProjectTree.SetVisibility(objID, false);
                }
            }
        }
    }
}
