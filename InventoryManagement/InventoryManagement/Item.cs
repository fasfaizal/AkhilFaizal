using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InventoryManagement
{
    public class Item
    {
        public int id{ get; set; }
        public string Name{ get; set; }

        public void Save(string name)
        {
            DBExecutor<int> dbExecutor = new DBExecutor<int>();
            dbExecutor.Execute(delegate (SqlCommand myCommand)
            {
                int updatedRows;
                myCommand.CommandText =string.Format("INSERT INTO Items VALUES('{0}')",name);
                updatedRows = myCommand.ExecuteNonQuery();
                return updatedRows;
            }
            );
        }
        public static void Delete(int id)
        {
            DBExecutor<int> dbExecutor = new DBExecutor<int>();
            dbExecutor.Execute(delegate (SqlCommand myCommand)
            {
                int updatedRows;
                myCommand.CommandText = string.Format("DELETE FROM Items WHERE id={0}", id);
                updatedRows = myCommand.ExecuteNonQuery();
                return updatedRows;
            }
            );
        }
        public static string Read(int id)
        {
            string itemName=string.Empty;
            DBExecutor<string> dbExecutor = new DBExecutor<string>();
            dbExecutor.Execute(delegate (SqlCommand myCommand)
            {
                SqlDataReader tableData;
                myCommand.CommandText = string.Format("SELECT * FROM Items WHERE id={0}", id);
                tableData = myCommand.ExecuteReader();
                while(tableData.Read())
                {
                    itemName=Convert.ToString(tableData["Name"]);
                }
                return itemName;
            }
            );
            return itemName;
        }
        public static List<Item> ReadAll()
        {
            List<Item> items = new List<Item>();
            DBExecutor<List<Item>> dbExecutor = new DBExecutor<List<Item>>();
            dbExecutor.Execute(delegate (SqlCommand myCommand)
            {
                SqlDataReader tableData;
                myCommand.CommandText = string.Format("SELECT * FROM Items");
                tableData = myCommand.ExecuteReader();
                while (tableData.Read())
                {
                    Item item = new Item();
                    item.id = Convert.ToInt32(tableData["ID"]);
                    item.Name = Convert.ToString(tableData["Name"]);
                    items.Add(item);
                }

                return items;
            }
            );
            return items;
        }
    }
}