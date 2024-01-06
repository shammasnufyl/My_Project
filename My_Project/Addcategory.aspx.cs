using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace My_Project
{
    public partial class Addcategory : System.Web.UI.Page
    {
        ConnectionCls obj=new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string catimg = "~/CategoryImage/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(catimg));
            string s = "insert into Category values('" + TextBox1.Text + "','" + catimg + "','" + TextBox2.Text + "','available')";
            int i = obj.fn_Nonquery(s);
            if (i == 1)
            {
                Label1.Visible = true;
                Label1.Text = "Category added successfully";
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditCategory.aspx");
        }
    }
}