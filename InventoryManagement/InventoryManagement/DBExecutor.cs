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
        public delegate T Exec(SqlConnection myConn);
        public T Execute(Exec exeObj)
        {
            string MyConnection2 = WebConfigurationManager.AppSettings["ConnectionString"];
            SqlConnection myConn=myConn = new SqlConnection(MyConnection2);
            myConn.Open();
            T ret=exeObj.Invoke(myConn);
            myConn.Close();
            return ret;
        }
    }
}