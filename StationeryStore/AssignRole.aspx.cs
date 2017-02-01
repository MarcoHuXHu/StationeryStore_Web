using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Threading;

public partial class AssignRole : System.Web.UI.Page
{

    string userId;
    Delegation de = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        userId = (string) Session["user"];
        if (userId == null)
        {
            Response.Redirect("~/login.aspx");
        }
        de = Work.getDlgtInfo(userId);

        if (!IsPostBack)
        {
            DropDownList1.DataSource = Work.getDptSfInfo(userId).Select(x => x.Name).ToList();
            
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("Please Select"));

            if (de != null){
                
                TextBox5.Text = de.StartDate.ToString("dd/MM/yyyy");
                TextBox6.Text = de.EndDate.ToString("dd/MM/yyyy");
                DropDownList1.SelectedValue = Work.getUser(de.CoveringHeadID).Name;
                DropDownList1.Enabled = false; ;
            }
            else
            {
 
                Button2.Visible = false;
                
            }
                     

        }

    }


    Staff sch;
    DateTime start;
    DateTime end;

    protected void Button1_Click(object sender, EventArgs e)
    {



        sch = Work.getDptSfInfo(userId).Where(x => x.Name == DropDownList1.Text.ToString()).FirstOrDefault();//选择的临时head的一行信息   
        if (sch == null)
        {
            Label1.Text = "Please select one staff.";
        }
        else {

            string[] format = { "dd/MM/yyyy" };
            if (DateTime.TryParseExact(TextBox5.Text,
                               format,
                               System.Globalization.CultureInfo.InvariantCulture,
                               System.Globalization.DateTimeStyles.None,
                               out start)) ;
            if (DateTime.TryParseExact(TextBox6.Text,
                         format,
                         System.Globalization.CultureInfo.InvariantCulture,
                         System.Globalization.DateTimeStyles.None,
                         out end)) ;
            if (DateTime.Compare(start, DateTime.Today) >= 0)
            {
                if (DateTime.Compare(start, end) <= 0)
                {

                    Delegation dlgt = new Delegation();
                    dlgt.CoveringHeadID = sch.UserID;
                    dlgt.StartDate = start;
                    dlgt.EndDate = end;
                    dlgt.DepartmentHeadID = userId;
                    Work.addDelegation(dlgt);
                    //TextBox4.Text = sch.Name;
                    //Label1.Text = "Delegation is updated Successful!";
                    //Button2.Visible = true;

                    // Multi Thread
                    ThreadStart childref = new ThreadStart(sendemail);
                    Thread childThread = new Thread(childref);
                    childThread.Start();

                    //Response.Redirect("AssignRole.aspx");
                    Response.Write("<script>alert('An email has been sent out!');location.href='AssignRole.aspx';</script>");
                }
                else
                {
                    Label1.Text = "End Date can bot be earlier than Start Date!";
                }

            }
            else
            {
                Label1.Text = "Start day can not be earlier than today.";
            }
        }
    }

    private void sendemail()
    {
        string coveringheadID = sch.UserID;
        string subject = "Covering Head";
        string chname = sch.Name;
        string body = "Dear" + chname + ",<br />" + "<br />You are selected as new covering head. " + "<br/>From " + start + " to " + end + ".<br/><br /> Regards.";
        SendEmail sm = new SendEmail(coveringheadID, subject, body);
        sm.initEmail();
        sm.sendEmail();
    }



    protected void Button2_Click(object sender, EventArgs e)
    {
        string ochId = Work.getUser(de.CoveringHeadID).Name;
        string subject = "Assignment issuse have changed";
        string[] format = { "dd/MM/yyyy" };
        DateTime start;
        if (DateTime.TryParseExact(TextBox5.Text,
                           format,
                           System.Globalization.CultureInfo.InvariantCulture,
                           System.Globalization.DateTimeStyles.None,
                           out start));
        DateTime end;
        if (DateTime.TryParseExact(TextBox6.Text,
                     format,
                     System.Globalization.CultureInfo.InvariantCulture,
                     System.Globalization.DateTimeStyles.None,
                     out end));


        if (DateTime.Compare(start,DateTime.Today)>=0)
        {
            Work.deleteDelegation(de);

            // Multi Thread
            ThreadStart childref = new ThreadStart(sendrevokeemail);
            Thread childThread = new Thread(childref);
            childThread.Start();

            //Response.Redirect("AssignRole.aspx");
            Response.Write("<script>alert('An email has been sent out!');location.href='AssignRole.aspx';</script>");


        }
        else
        {
            Work.revokeDelegation(de);
            // Multi Thread
            ThreadStart childref = new ThreadStart(sendrevokeemail);
            Thread childThread = new Thread(childref);
            childThread.Start();

            //Response.Redirect("AssignRole.aspx");
            Response.Write("<script>alert('An email has been sent out!');location.href='AssignRole.aspx';</script>");

        }



    }
    private void sendrevokeemail()
    {
        string ochId = Work.getUser(de.CoveringHeadID).Name;
        string subject = "Assignment issuse have changed";
        string body = "Dear " + ochId + ",<br/><br />Your 'covering head'task is cancel.<br/><br />Thanks & regards.";
        SendEmail sm = new SendEmail(Work.getUser(de.CoveringHeadID).UserID, subject, body);
        sm.initEmail();
        sm.sendEmail();
    }

    //    protected void Button3_Click(object sender, EventArgs e)
    //    {
    //        Staff sch = getInfo.getDptSfInfo().Where(x => x.Name == DropDownList1.Text.ToString()).First();//选择的临时head的一行信息     
    //        DateTime start = Convert.ToDateTime(TextBox3.Text);
    //        DateTime end = Convert.ToDateTime(TextBox4.Text);
    //        string c = getInfo.getDlgtInfo().DelegationID.ToString(); // get already have delegationID
    //        Delegation d = ctx.Delegation.Where(x => x.DelegationID == c).First();

    //        if (DateTime.Compare(d.EndDate, DateTime.Now) > 0)
    //        {



    //            if (DropDownList1.Text == getInfo.someInfo("stf").Name)
    //            {
    //                d.EndDate = end;
    //                ctx.SaveChanges();
    //                Label1.Text = "Update Successful!";
    //            }
    //            else
    //            {
    //            }


}