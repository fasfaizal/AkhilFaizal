using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagement
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var dr = ItemBatch.ReadAll();
            //DBConnectExecute con = new DBConnectExecute();
            //SqlDataReader dr = con.FetchItems();
            GridView1.DataSource = dr;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "AddBatch") return;
            int id = Convert.ToInt32(e.CommandArgument);
            Response.Write(id);
        }

        protected void Add_Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNewItem.aspx");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            Response.Redirect("AddBatch.aspx?ItemId=" + grdrow.Cells[0].Text + "&ItemName=" + grdrow.Cells[1].Text);
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            for (int i = GridView1.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = GridView1.Rows[i];
                GridViewRow previousRow = GridView1.Rows[i - 1];
                if (row.Cells[1].Text == previousRow.Cells[1].Text)
                {
                    if (previousRow.Cells[1].RowSpan == 0)
                    {
                        if (row.Cells[1].RowSpan == 0)
                        {
                            previousRow.Cells[0].RowSpan += 2;
                            previousRow.Cells[1].RowSpan += 2;
                            previousRow.Cells[4].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
                            previousRow.Cells[1].RowSpan = row.Cells[1].RowSpan + 1;
                            previousRow.Cells[4].RowSpan = row.Cells[4].RowSpan + 1;

                        }
                        row.Cells[0].Visible = false;
                        row.Cells[1].Visible = false;
                        row.Cells[4].Visible = false;
                    }
                }

            }
        }

        protected void DelBtn_Click(object sender, EventArgs e)
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            int del_id = Convert.ToInt32(grdrow.Cells[0].Text);
            Item.Delete(del_id);
            ItemBatch.Delete(del_id);
            Response.Redirect("Default.aspx");
        }
    }
}