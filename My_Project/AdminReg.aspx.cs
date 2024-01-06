using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace My_Project
{
    public partial class AdminReg : System.Web.UI.Page
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
            string s1 = "insert into Admin_Reg values(" + reg_id + ",'" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "')";
            int i = obj.fn_Nonquery(s1);
            string s2 = "insert into Login values(" + reg_id+ ",'" + TextBox4.Text + "','" + TextBox5.Text + "','admin','active')";
            int j = obj.fn_Nonquery(s2);
            Response.Redirect("Adminhome.aspx");  
        }
    }
}