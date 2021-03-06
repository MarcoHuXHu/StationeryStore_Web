﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Windows.Forms;
using System.Configuration;
using System.Web.Mail;
using System.Threading;

public partial class NewDiscrepancy : System.Web.UI.Page
{
    Work work;
    protected void Page_Load(object sender, EventArgs e)
    {
        string userId = (string)Session["user"];
        if (userId == null)
        {
            Response.Redirect("~/login.aspx");
        }
        work = new Work();
        TextBox1.Text = Request.QueryString["id"];
        TextBox2.Text = Request.QueryString["description"];
        TextBox3.Text = work.getMaxPrice(Request.QueryString["id"]).ToString();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!work.isNormalStockNumber(TextBox1.Text, TextBox4.Text).Equals(""))
        {
            Label7.Visible = true;
            Label7.Text = work.isNormalStockNumber(TextBox1.Text, TextBox4.Text);
        }
        else
        {
            string staffId = (string)Session["user"];
            Staff staff = work.getSpecificStaff(staffId);
            int i = work.saveDiscrepancy(String.Format("{0:d5}", (Convert.ToInt32(work.getMaxDiscrepancyId()) + 1)), Convert.ToInt32(TextBox4.Text), TextBox5.Text, "Pending Approval", work.getItem(TextBox1.Text), staff, DateTime.Now);
            if (i > 0)
            {
                //DialogResult dr = MessageBox.Show("Updated Successfully!", "New Discrepancy", MessageBoxButtons.OK, MessageBoxIcon.Question);
                //string message = "Updated Successfully";
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + message + "')</script>");

                // Multi Thread
                //ThreadStart childref = new ThreadStart(sendemail);
                //Thread childThread = new Thread(childref);
                //childThread.Start();
                AsyncEmail ae = sendemail;
                ae.BeginInvoke(null, null);

                Response.Write("<script>alert('Updated Successfully!');location.href='ViewDiscrepancy.aspx';</script>");

                //if (dr == DialogResult.OK)
                //{
                //Response.Redirect("ViewDiscrepancy.aspx");
                //}
            }
        }
    }
    private delegate void AsyncEmail();
    private void sendemail()
    {
        string headID = work.getEmailToPersonId(TextBox3.Text);
        string subject = "Discrepancy " + work.getMaxDiscrepancyId() + " for approval";
        string body = "Dear Sir/ Madam,<br />" + "<br />Discrepancy " + work.getMaxDiscrepancyId() + " is pending your approval.Please click <a href = 'http://localhost/StationeryStore/Discrepancy/ApproveDiscrepancy.aspx'>here</a> to see more details.<br />" + "<br />Thanks & regards.";
        SendEmail sm = new SendEmail(headID, subject, body);
        sm.initEmail();
        sm.sendEmail();
    }
}