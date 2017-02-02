using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UpdateCP : System.Web.UI.Page
{
    string userId;
    Work Work = new Work();
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

    string someone;
    string point;
    protected void Button1_Click(object sender, EventArgs e)
    {

        point = RadioButtonList1.Text;
        Work.changeCollectionPoint(userId, point);


        string role = Work.getUser(userId).Role;

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


        // Multi Thread
        //ThreadStart childref = new ThreadStart(sendemail);
        //Thread childThread = new Thread(childref);
        //childThread.Start();
        AsyncEmail ae = sendemail;
        ae.BeginInvoke(null, null);

        //Response.Redirect("UpdateCP.aspx");
        Response.Write("<script>alert('An email has been sent out!');location.href='UpdateCP.aspx';</script>");

    }
    private delegate void AsyncEmail();
    private void sendemail()
    {
        string subject = "Department collectiong point has changed";
        string body = "Dear Sir/Mrs,<br/><br/>" + "Your department collection point has changed as " + point + ".<br/><br/>Regards.";
        SendEmail sm = new SendEmail(someone, subject, body);
        sm.initEmail();
        sm.sendEmail();
    }
}