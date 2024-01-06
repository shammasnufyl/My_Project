using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace My_Project
{
    public partial class Userhome : System.Web.UI.Page
    {
        ConnectionCls obj = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                datalistBind();
            }

        }
        public void datalistBind()
        {
            string selall = "select * from Category";
            DataSet ds = obj.fn_DataAdapter(selall);
            DataList1.DataSource = ds;
            DataList1.DataBind();
        }

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            int catid = Convert.ToInt32(e.CommandArgument);
            Session["catid"] = catid;
            Response.Redirect("DisplayProducts.aspx");

        }
    }
}