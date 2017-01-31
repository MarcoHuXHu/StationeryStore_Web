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
        

        string role = Work.getUser(userId).Role;
        string someone;

        if (role == "DeptRep")
        {
            string headid = Work.getDeptHeadId(Work.getUser(userId).DepartmentID);
            someone = headid;
        }
        else
        {
            string repid = Work.getDeptRep(userId);
            someone = repid;
        }

        string subject = "Department collectiong point has changed";
        string body = "Dear Sir/Mrs,<br/><br/>" + "Your department collection point has changed as " + point + ".<br/><br/>Regards.";
        SendEmail sm = new SendEmail(someone, subject, body);
        sm.initEmail();
        sm.sendEmail();

        Response.Redirect("UpdateCP.aspx");

    }
}