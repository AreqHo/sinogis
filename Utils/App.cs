using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRQ
{
    public class App
    {
        private static App instance;

        private App()
        {

        }

        public static App GetInstance()
        {
            if (instance == null)
            {
                instance = new App();
            }
            return instance;
        }
        private string systemFoldPath = "";

        public string SystemFoldPath
        {
            get
            {
                return systemFoldPath;
            }

            set
            {
                systemFoldPath = value;
            }
        }

        public string InspectionTime
        {
            get
            {
                var length = systemFoldPath.Split('\\').Length;
                return systemFoldPath.Split('\\')[length - 1];
            }

            set
            {
                inspectionTime = value;
            }
        }

        private string inspectionTime = "";

    }
}
