using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace My_Project
{
    public partial class Addproduct : System.Web.UI.Page
    {
        ConnectionCls obj = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string s = "select Cat_Id,Cat_Name from Category";
                DataSet ds = obj.fn_DataAdapter(s);
                DropDownList1.DataSource = ds;
                DropDownList1.DataTextField = "Cat_Name";
                DropDownList1.DataValueField = "Cat_Id";
                DropDownList1.DataBind();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditProduct.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string pdtimg = "~/ProductImage/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(pdtimg));
            string sel = "insert into Product values(" + DropDownList1.SelectedItem.Value + ",'" + TextBox1.Text + "','" + pdtimg + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','available')";
            int i = obj.fn_Nonquery(sel);
            if (i == 1)
            {
                Label1.Visible = true;
                Label1.Text = "Product added successfully";
            }
        }
    }
}