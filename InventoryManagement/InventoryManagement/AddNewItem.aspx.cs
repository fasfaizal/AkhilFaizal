using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagement
{
    public partial class AddNewItem : System.Web.UI.Page
    {
        private DBConnectExecute dbConnectExecute;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool validate(string name)
        {
            bool valid = true;
            return valid;
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (validate(Name.Text))
            {
                int itemID;
                Item item = new Item();
                itemID= item.Save(Name.Text);
                ItemBatch itemBatch = new ItemBatch();
                itemBatch.Save(itemID, Batch.Text, Quantity.Text);
                Response.Redirect("Default.aspx");
            }
        }
    }
}