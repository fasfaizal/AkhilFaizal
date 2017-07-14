using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InventoryManagement
{
    public class DBConnectExecute
    {
        private SqlConnection myConn;
        private SqlConnection connect()
        {            
            string MyConnection2 = "Data Source=KL-DEV6;Initial Catalog=Inventory;User ID=sa;Password=!QAZ2wsx";
            myConn = new SqlConnection(MyConnection2);
            return myConn;
        }

        public void InsertNewItem(string id,string name, string batch, string quantity)
        {
            connect();
            myConn.Open();
            string Query = string.Format("INSERT INTO ITEMS VALUES({0},'{1}');INSERT INTO STOCK VALUES({0},'{2}',0,0,{3},NULL,{4})",id, name, batch, quantity,200+Convert.ToInt32(id));
            SqlCommand myCommand = new SqlCommand(Query, myConn);
             myCommand.ExecuteNonQuery();
            myConn.Close();
        }
        public void InsertNewBatch(string id, string name,string batchId, string batch, string quantity)
        {
            connect();
            myConn.Open();
            string Query = string.Format("INSERT INTO STOCK VALUES({0},'{2}',0,0,{3},NULL,{4})", id, name, batch, quantity, batchId);
            SqlCommand myCommand = new SqlCommand(Query, myConn);
            myCommand.ExecuteNonQuery();
            myConn.Close();
        }

        public SqlDataReader FetchItems()
        {
            SqlConnection con = connect();
            con.Open();
            string Query = string.Format("exec Pro_Stock_BatchView");
            SqlCommand MyCommand2 = new SqlCommand(Query, con);
            SqlDataReader dr = MyCommand2.ExecuteReader();
            //MyCommand2.ExecuteNonQuery();
            return dr;
        }
    }
}