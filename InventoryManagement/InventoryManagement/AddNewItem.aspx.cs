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
            if (!dbConnectExecute.validate(name))
                valid = false;
            return valid;
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            dbConnectExecute = new DBConnectExecute();
            if (validate(Name.Text))
            {                
                dbConnectExecute.InsertNewItem(ItemID.Text,Name.Text,Batch.Text,Quantity.Text);
            }
        }
    }
}