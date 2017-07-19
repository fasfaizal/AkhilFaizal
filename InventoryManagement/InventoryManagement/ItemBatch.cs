using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InventoryManagement
{
    public class ItemBatch
    {
        public int Id { get; set; }
        public Item item { get; set; } = new Item();
        public string Batch { get; set; }
        public double CP { get; set; }
        public double SP { get; set; }
        public int OpStock { get; set; }
        public void Save(int itemid, string batch, int opStock)
        {
            DBExecutor<int> dbExecutor = new DBExecutor<int>();
            dbExecutor.Execute(delegate (SqlCommand myCommand)
            {
                int updatedRows;
                myCommand.CommandText = string.Format("INSERT INTO Stock VALUES({0},'{1}',0,0,{2},'2018-01-01')", itemid, batch, opStock);
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
                myCommand.CommandText = string.Format("DELETE FROM Stock WHERE ItemId={0}", id);
                updatedRows = myCommand.ExecuteNonQuery();
                return updatedRows;
            }
            );
        }
        public static ItemBatch Read(int id)
        {
            DBExecutor<ItemBatch> db = new DBExecutor<ItemBatch>();
            return db.Execute(delegate (SqlCommand cmd)
            {
                cmd.CommandText = "SELECT * FROM STOCK WHERE ID=" + id;
                var dr = cmd.ExecuteReader();
                ItemBatch ib = new ItemBatch();
                while (dr.Read())
                {
                    ib.Id = Convert.ToInt32(dr["ID"]);
                    ib.item.id = Convert.ToInt32(dr["ItemID"]);
                    ib.item.Name = Item.Read(ib.item.id);
                    ib.Batch = Convert.ToString(dr["BatchNo"]);
                    ib.CP = Convert.ToDouble(dr["CostPrice"]);
                    ib.SP = Convert.ToDouble(dr["SellingPrice"]);
                    ib.OpStock = Convert.ToInt32(dr["NoOfItems"]);
                }
                return ib;
            });

        }
        public static List<ItemBatch> ReadByItemId(int id)
        {
            DBExecutor<List<ItemBatch>> db = new DBExecutor<List<ItemBatch>>();
            return db.Execute(delegate (SqlCommand cmd)
            {
                List<ItemBatch> ret = new List<ItemBatch>();
                cmd.CommandText = "SELECT * FROM STOCK WHERE ItemID=" + id;
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ItemBatch ib = new ItemBatch();
                    ib.Id = Convert.ToInt32(dr["ID"]);
                    ib.item.id = Convert.ToInt32(dr["ItemID"]);
                    ib.item.Name = Item.Read(ib.item.id);
                    ib.Batch = Convert.ToString(dr["BatchNo"]);
                    ib.CP = Convert.ToDouble(dr["CostPrice"]);
                    ib.SP = Convert.ToDouble(dr["SellingPrice"]);
                    ib.OpStock = Convert.ToInt32(dr["NoOfItems"]);
                    ret.Add(ib);

                }
                return ret;
            });
        }
        public static List<ItemBatch> ReadAll()
        {
            DBExecutor<List<ItemBatch>> db = new DBExecutor<List<ItemBatch>>();
            return db.Execute(delegate (SqlCommand cmd)
              {
                  List<ItemBatch> ret = new List<ItemBatch>();
                  cmd.CommandText = "SELECT * FROM STOCK ORDER BY ItemID";
                  var dr = cmd.ExecuteReader();
                  while (dr.Read())
                  {
                      ItemBatch ib = new ItemBatch();
                      ib.Id = Convert.ToInt32(dr["ID"]);
                      ib.item.id = Convert.ToInt32(dr["ItemID"]);
                      ib.item.Name = Item.Read(ib.item.id);
                      ib.Batch = Convert.ToString(dr["BatchNo"]);
                      ib.CP = Convert.ToDouble(dr["CostPrice"]);
                      ib.SP = Convert.ToDouble(dr["SellingPrice"]);
                      ib.OpStock = Convert.ToInt32(dr["NoOfItems"]);
                      ret.Add(ib);
                  }
                  return ret;
              });
        }
    }
}