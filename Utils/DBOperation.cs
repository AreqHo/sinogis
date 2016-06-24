using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace HRQ.Utils
{
    public static class DBOperation
    {
        public static DataView GetNWindData(string tableName)
        {
            string DBFileName = DevExpress.Utils.FilesHelper.FindingFileName(Application.StartupPath, "db\\HVL.db");

            if (DBFileName != "")
            {
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

                var dvTutorial = TSelectReSoult.DefaultView;

                conn.Close();

                return dvTutorial;
            }
            return null;
        }

        public static DataView UpdatePoleFault(string condition)
        {
            string DBFileName = DevExpress.Utils.FilesHelper.FindingFileName(Application.StartupPath, "db\\HVL.db");

            if (DBFileName != "")
            {
                SQLiteConnection conn = null;

                string dbPath = "Data Source =" + DBFileName;
                conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置  
                conn.Open();//打开数据库，若文件不存在会自动创建  

                //string sql = "SELECT * FROM " + tableName;

                string sql = "REPLACE INTO PoleFault(ID,FPATH,FPOSITION,FCLASS,FDESC,FTIME)VALUES("
                    + condition+")";

                SQLiteCommand cmdQ = new SQLiteCommand(sql, conn);

                SQLiteDataReader reader = cmdQ.ExecuteReader();

                DataTable TSelectReSoult = new DataTable();  /*存放要在Gridview里面显示的最后结果*/
                TSelectReSoult.Load(reader);

                reader.Close();                        /*记得用完要关闭reader*/

                var dvTutorial = TSelectReSoult.DefaultView;

                conn.Close();

                return dvTutorial;
            }
            return null;
        }
    }
}
