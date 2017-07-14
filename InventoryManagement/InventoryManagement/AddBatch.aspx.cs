using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagement
{
    public partial class AddBatch : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            ItemID.Text = Convert.ToString(Session["ItemId"]);
            Name.Text = Convert.ToString(Session["ItemName"]);
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            DBConnectExecute dbConnectExecute = new DBConnectExecute();
            dbConnectExecute.InsertNewBatch(ItemID.Text, Name.Text,BatchID.Text, Batch.Text, Quantity.Text);
            Response.Redirect("Default.aspx");
        }
    }
}