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
using System.Globalization;

public partial class Reports_chargenbackreport : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Team5ADProjectConnectionString"].ConnectionString);
    ReportDocument rdoc = new ReportDocument();
    DateTime start;
    DateTime end;

    Work Work = new Work();
    protected void Page_Init(object sender, EventArgs e)
    {

        ReportDocument rdoc = (ReportDocument)Session["charge"];
        CrystalReportViewer1.ReportSource = rdoc;
        CrystalReportViewer1.DataBind();

    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void btnGenrpt_Click(object sender, EventArgs e)
    {
        DateTime result;
        if (!DateTime.TryParse(txtstartdate.Text, out result) || !DateTime.TryParse(txtenddate.Text, out result))
        {
            Label1.Visible = true;
            Label1.Text = "*Please key in vaild dates";
        }

        else
        {
            string[] format = { "dd/MM/yyyy" };
            if (DateTime.TryParseExact(txtstartdate.Text,
                           format,
                           System.Globalization.CultureInfo.InvariantCulture,
                           System.Globalization.DateTimeStyles.None,
                           out start))
                if (DateTime.TryParseExact(txtenddate.Text,
                             format,
                             System.Globalization.CultureInfo.InvariantCulture,
                             System.Globalization.DateTimeStyles.None,
                             out end))

                    if (DateTime.Compare(Convert.ToDateTime(txtstartdate.Text), Convert.ToDateTime(txtenddate.Text)) <= 0)
                    {
                        try
                        {
                            cn.Open();
                            SqlCommand cmd = new SqlCommand("chargebackd", cn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable ds = new DataTable();
                            da.Fill(ds);
                            rdoc.Load(Server.MapPath("chargeback.rpt"));
                            rdoc.SetDataSource(ds);

                            rdoc.SetParameterValue("startdate", Convert.ToDateTime(txtstartdate.Text));
                            rdoc.SetParameterValue("enddate", Convert.ToDateTime(txtenddate.Text));



                            List<string> list1 = new List<string>();
                            foreach (ListItem item in LBdept.Items)
                            {
                                if (item.Selected)
                                {
                                    list1.Add(item.Value);
                                }
                            }
                            string[] outcome = list1.ToArray();
                            rdoc.SetParameterValue("departmentID", outcome);


                            Session["charge"] = rdoc;
                            cn.Close();
                            Response.Redirect("chargebackreport.aspx");
                        }

                        catch (DataSourceException)
                        {

                            Response.Write("<script>alert('An error has occurred while connecting to the database.');</script>");
                        }



                    }
                    else
                    {
                        Label1.Visible = true;
                        Label1.Text = "End date cannot be earlier than Start date";
                    }
        }
    }
}