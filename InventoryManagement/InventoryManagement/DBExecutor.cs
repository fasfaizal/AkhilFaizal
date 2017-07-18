using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace InventoryManagement
{
    public class DBExecutor<T>
    {
        public delegate T Exec(SqlCommand myConn);
        public T Execute(Exec exeObj)
        {
            string MyConnection2 = WebConfigurationManager.AppSettings["ConnectionString"];
            SqlConnection myConn=myConn = new SqlConnection(MyConnection2);
            myConn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            T ret=exeObj.Invoke(cmd);
            myConn.Close();
            return ret;
        }
    }
}