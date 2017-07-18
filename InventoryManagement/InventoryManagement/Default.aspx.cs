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
            Session["ItemId"] = grdrow.Cells[0].Text;
            Session["ItemName"] = grdrow.Cells[1].Text;
            Response.Redirect("AddBatch.aspx");
        }
    }
}