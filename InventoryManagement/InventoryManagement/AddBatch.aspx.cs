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
            ItemID.Text = Request.QueryString["ItemId"];
            Name.Text =Request.QueryString["ItemName"];
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            ItemBatch itemBatch = new ItemBatch();
            itemBatch.Save(Convert.ToInt32( Request.QueryString["itemId"]),Batch.Text,Convert.ToInt32(Quantity.Text));
            Response.Redirect("Default.aspx");
        }
    }
}