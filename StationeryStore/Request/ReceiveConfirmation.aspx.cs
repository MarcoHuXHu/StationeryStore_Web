using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Request_ReceiveConfirmation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string userId = (string)Session["user"];
            if (userId == null)
            {
                Response.Redirect("~/login.aspx");
            }
            string departmentID = Work.getUser(userId).DepartmentID;
            // Get Data
            List<DisbursementModel> list = Work.viewRequestByDept();
            Work.GetRetrieveLog(new List<DisbursementModel>(), list);
            List<DisbursementModel> listByDepartment = new List<DisbursementModel>();
            foreach (DisbursementModel dm in list)
            {
                // in case log waiting for changing
                if (dm.GivenNumber < 0)
                    dm.GivenNumber = 0;
                if (dm.DepartmentID == departmentID)
                    listByDepartment.Add(dm);
            }
            ViewState["list"] = listByDepartment;
            GridViewDept.DataSource = listByDepartment;
            GridViewDept.DataBind();
        }
    }

    protected void Button0_Click(object sender, EventArgs e)
    {
        List<DisbursementModel> listByDepartment = (List<DisbursementModel>)ViewState["list"];
        int res = Work.SubmitReceive(listByDepartment);
        if (res < -1000)
        {
            //System.Windows.Forms.MessageBox.Show("There is discrepency in Delivery, please contact clerk");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('There is discrepency in Delivery, please contact clerk')</script>");
        }
        if (res < 0)
        {
            //System.Windows.Forms.MessageBox.Show("Updating database failed, Please try again");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Updating database failed, Please try again')</script>");
        }
        if (res == 0)
        {
            Response.Redirect("~/Request/ReceiveConfirmation.aspx");
        }
    }
}