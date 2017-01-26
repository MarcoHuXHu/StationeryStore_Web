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

public partial class Reports_Ordertrendreport : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Team5ADProjectConnectionString"].ConnectionString);
    ReportDocument rdoc = new ReportDocument();

    protected void Page_Init(object sender, EventArgs e)
    {

        ReportDocument rdoc = (ReportDocument)Session["order"];
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
            SqlCommand cmd = new SqlCommand("suppliertrend", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            rdoc.Load(Server.MapPath("suppliertrends.rpt"));
            rdoc.SetDataSource(ds);
            
            List<string> list1 = new List<string>();
            foreach (ListItem item in LBperiod.Items)
            {
                if (item.Selected)
                {
                    list1.Add(item.Value);
                }
            }
            string[] result = list1.ToArray();
            rdoc.SetParameterValue("period", result);


            List<string> list2 = new List<string>();
            foreach (ListItem item in LBss.Items)
            {
                if (item.Selected)
                {
                    list2.Add(item.Value);
                }
            }
            string[] result2 = list2.ToArray();
            rdoc.SetParameterValue("suppliername", result2);

            List<string> list3 = new List<string>();
            foreach (ListItem item in LBcate.Items)
            {
                if (item.Selected)
                {
                    list3.Add(item.Value);
                }
            }
            string[] result3 = list3.ToArray();
            rdoc.SetParameterValue("category", result3);

            Session["order"] = rdoc;
            cn.Close();
            Response.Redirect("Ordertrendreport.aspx");
        }
        catch (DataSourceException)
        {

            Response.Write("<script>alert('An error has occurred while connecting to the database.');</script>");
        }


    }
}