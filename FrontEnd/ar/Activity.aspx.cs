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

public partial class ar_Activity : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HyperLink HLLanguages = (HyperLink)Master.FindControl("EnglishHL");
        HLLanguages.NavigateUrl = Request.Url.LocalPath.ToString().Replace("/ar/", "/en/");
        HtmlGenericControl left_div = (HtmlGenericControl)Master.FindControl("leftColumn");
        left_div.Visible = false;
        HtmlGenericControl body_content = (HtmlGenericControl)Master.FindControl("bodyContent");
        body_content.Attributes["class"] = String.Format("content2");
    }
}
