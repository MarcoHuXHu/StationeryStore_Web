using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UpdateCP : System.Web.UI.Page
{
    string userId;
    protected void Page_Load(object sender, EventArgs e)
    {
        userId = (string)Session["user"];
        if (userId == null)
        {
            Response.Redirect("~/login.aspx");
        }

        if (!IsPostBack)
        {
            Department d = Work.getUser(userId).Department;
            TextBox1.Text = d.Collection_Point.ToString();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        string point = RadioButtonList1.Text;
        Work.changeCollectionPoint(userId, point);
        Response.Redirect("UpdateCP.aspx");




    }
}