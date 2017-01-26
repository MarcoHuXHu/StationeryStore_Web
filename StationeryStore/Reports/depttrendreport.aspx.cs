using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Data.Common;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Reporting;

public partial class Reports_depttrendreport : System.Web.UI.Page
{

    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Team5ADProjectConnectionString"].ConnectionString);
    ReportDocument rdoc = new ReportDocument();
    protected void Page_Init(object sender, EventArgs e)
    {
        
        ReportDocument rdoc = (ReportDocument)Session["dept"];
        CrystalReportViewer1.ReportSource = rdoc;
        CrystalReportViewer1.DataBind();

    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("chargebackd", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            rdoc.Load(Server.MapPath("depttrend.rpt"));
            rdoc.SetDataSource(ds);


            List<string> list = new List<string>();
            foreach (ListItem item in LBdepts.Items)
            {
                if (item.Selected)
                {
                    list.Add(item.Value);
                }
            }
            string[] result = list.ToArray();
            rdoc.SetParameterValue("department", result);


            List<string> list1 = new List<string>();
            foreach (ListItem item in LBmth.Items)
            {
                if (item.Selected)
                {
                    list1.Add(item.Value);
                }
            }
            string[] result1 = list1.ToArray();
            rdoc.SetParameterValue("YYYY/MM", result1);


            Session["dept"] = rdoc;
            cn.Close();
            Response.Redirect("depttrendreport.aspx");
        }
        catch (DataSourceException)
        {

            Response.Write("<script>alert('An error has occurred while connecting to the database.');</script>");
        }

    }
    
 
}