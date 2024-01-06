using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace My_Project
{
    public partial class Login : System.Web.UI.Page
    {
        ConnectionCls obj = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Visible = true;
            string str = "select count(Reg_Id) from Login where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";
            string cid = obj.fn_Scalar(str);
            if (cid == "1")
            {
                string s1 = "select Reg_Id from Login where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
                string regid = obj.fn_Scalar(s1);
                Session["userid"] = regid;
                string s2 = "select Log_Type from Login where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";
                string Log_Type = obj.fn_Scalar(s2);
                if (Log_Type == "admin")
                {
                    Response.Redirect("Adminhome.aspx");

                }
                else if (Log_Type == "user")
                {
                    Response.Redirect("Userhome.aspx");

                }
                else
                {
                    Label1.Text = "inavlid username or password";
                }
            }
        }
    }
}