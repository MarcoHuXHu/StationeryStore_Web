using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Notification : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            Team5ADProjectEntities ctx = new Team5ADProjectEntities();
            GridView1.DataSource = ctx.Notification.Where(x => x.UserID == "00242").Select(x => new { x.NotificationID, x.Subject, x.Status, x.Date }).ToList();
            GridView1.DataBind();
        }
    }
    
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Team5ADProjectEntities ctx = new Team5ADProjectEntities();
        int NotificationID= Convert.ToInt32(e.CommandArgument.ToString());
        var sql = from n in ctx.Notification where n.NotificationID == NotificationID && n.UserID == "00242" select n.Message;
        List<string> list = sql.ToList();
        TextBox1.Text = list[0];

    }
}