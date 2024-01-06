using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace My_Project
{
    public partial class UserReg : System.Web.UI.Page
    {
        ConnectionCls obj = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "select max(Reg_Id) from Login";
            string regid = obj.fn_Scalar(s);
            int reg_id = 0;
            if (regid == "")
            {
                reg_id = 1;
            }
            else
            {
                int newregid = Convert.ToInt32(regid);
                reg_id = newregid + 1;
            }
            string s1 = "insert into User_Reg values(" + reg_id + ",'" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','"+TextBox4.Text+"')";
            int i = obj.fn_Nonquery(s1);
            string s2 = "insert into Login values(" + reg_id + ",'" + TextBox5.Text + "','" + TextBox6.Text + "','user','active')";
            int j = obj.fn_Nonquery(s2);
            Response.Redirect("Userhome.aspx");
        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {
            string sel = "select count(Reg_Id) from Login where username='" + TextBox5.Text + "'";
            string cid = obj.fn_Scalar(sel);
            if (cid == "1")
            {
                Label8.Visible = true;
                Label8.Text = "Username already exist!";
            }
        }
    }
}