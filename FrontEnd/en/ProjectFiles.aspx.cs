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

public partial class FrontEnd_en_ProjectFiles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        HyperLink HLLanguages = (HyperLink)Master.FindControl("EnglishHL");
        if (Request.QueryString.Count == 0)
            HLLanguages.NavigateUrl = Request.Url.LocalPath.ToString().Replace("/en/", "/ar/");
        else
            HLLanguages.NavigateUrl = Request.Url.LocalPath.ToString().Replace("/en/", "/ar/") + "?ID=" + Request.QueryString["ID"];
    }
}
