using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace My_Project
{
    public partial class DisplayProducts : System.Web.UI.Page
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
            string selall = "select * from Product where Cat_Id="+Session["catid"];
            DataSet ds = obj.fn_DataAdapter(selall);
            DataList1.DataSource = ds;
            DataList1.DataBind();
        }
    }
}