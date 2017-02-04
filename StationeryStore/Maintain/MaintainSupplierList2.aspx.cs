using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MaintainSupplierList2 : System.Web.UI.Page
{
    Work Work = new Work();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        Page.Validate();
        List<Supplier> listofSupplier = Work.GetSupplier();
        foreach (Supplier supplier in listofSupplier)
        {
            if (TextBox1.Text == supplier.SupplierID)
            {
                Label1.Text = "SupplierID already exists! please change ID!";
            }
            else
            {
                Label1.Text = "";
            }
        }
        if (Page.IsValid == true)
        {
            string SupplierCode = TextBox1.Text;
            string SupplierName = TextBox2.Text;
            string ContactName = TextBox3.Text;
            string PhoneNo = TextBox4.Text;
            string FaxNo = TextBox5.Text;
            string Address = TextBox6.Text;
            string GSTNo = TextBox7.Text;
            string email = TextBox8.Text;
            Work.CreateSupplier(SupplierCode, SupplierName, ContactName, PhoneNo,
                FaxNo, Address, GSTNo, email);
            Response.Redirect("MaintainSupplierList1.aspx");
        }

        else
        {
            //throw new Exception("please fill all compulsory fields!");
        }

       
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("MaintainSupplierList1.aspx");
    }
}