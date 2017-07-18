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
        public void Save(string batch, float cp, float sp, int opStock)
        {

        }
        //public static ItemBatch Read(int id)
        //{

        //}
        public static List<ItemBatch> ReadByItemId(int id)
        {
            DBExecutor<List<ItemBatch>> db = new DBExecutor<List<ItemBatch>>();
            return db.Execute(delegate (SqlCommand cmd)
            {
                List<ItemBatch> ret = new List<ItemBatch>();
                cmd.CommandText = "SELECT * FROM STOCK WHERE ItemID="+id;
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
                    string contact = Convert.ToString(dr[0]);
                    string company = Convert.ToString(dr[1]);
                    string city = Convert.ToString(dr[2]);

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
                  cmd.CommandText = "SELECT * FROM STOCK";
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
                      string contact = Convert.ToString(dr[0]);
                      string company = Convert.ToString(dr[1]);
                      string city = Convert.ToString(dr[2]);

                  }
                  return ret;
              });
        }
    }
}