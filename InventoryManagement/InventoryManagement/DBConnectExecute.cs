using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InventoryManagement
{
    public class DBConnectExecute
    {
        public SqlConnection Connect()
        {
            SqlConnection Myconn;
            string MyConnection2 = "Data Source=KL-DEV6;Initial Catalog=Inventory;User ID=sa";
            Myconn = new SqlConnection(MyConnection2);
            return Myconn;
        }
    }
}