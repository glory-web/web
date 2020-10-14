using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Request.Cookies.Clear();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["firstTime"] != null)
        {
            ClientScript.RegisterStartupScript(GetType(), "kk", "alert('back');", true);
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "kk", "alert('new');", true);
            Request.Cookies.Add(new HttpCookie("firstTime","false"));
        }
    }
}
