using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangeRep : System.Web.UI.Page
{

    Work Work = new Work();
    string userId;
    string oldRep;
    protected void Page_Load(object sender, EventArgs e)
    {
        userId = (string)Session["user"];
        if (userId == null)
        {
            Response.Redirect("~/login.aspx");
        }

        if (!IsPostBack)
        {
            DropDownList1.DataSource = Work.getDptSfInfo(userId).Select(x => x.Name).ToList();
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("Please Select"));
            oldRep = Work.getUser(Work.getDeptRep(userId)).Name;
            TextBox1.Text = oldRep;
        }

    }

    string newRep;
    protected void Button1_Click(object sender, EventArgs e)
    {
        newRep = DropDownList1.Text;
        Work.ChangeRep(Work.getUser(Work.getDeptRep(userId)).Name, newRep);

        // Multi Thread
        //ThreadStart childref = new ThreadStart(sendemail);
        //Thread childThread = new Thread(childref);
        //childThread.Start();
        AsyncEmail ae = sendemail;
        ae.BeginInvoke(null, null);

        //Response.Redirect("ChangeRep.aspx");
        Response.Write("<script>alert('An email has been sent out!');location.href='ChangeRep.aspx';</script>");
    }
    private delegate void AsyncEmail();
    private void sendemail()
    {
        string oldrepID = Work.getUser(Work.getDeptRep(userId)).UserID;
        string subject = "You Role has been changed";
        string body = "Dear " + Work.getUser(Work.getDeptRep(userId)).Name + ",<br />You Department Rep task has been cancelled.<br />Thanks & regards.";
        SendEmail sm = new SendEmail(oldrepID, subject, body);
        sm.initEmail();
        sm.sendEmail();
        string newrepID = Work.getUserbyName(newRep).UserID;
        string subject1 = "You Role has been changed";
        string body1 = "Dear " + newRep + ",<br />Congraduation!You are seleced as Department Rep!<br/><br/>Thanks & regards.";
        SendEmail osm = new SendEmail(newrepID, subject1, body1);
        osm.initEmail();
        osm.sendEmail();
    }
}