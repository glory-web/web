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
using Businesslayer;
using Common;
using DataAccess;
public partial class FrontEnd_ar_AboutUS : System.Web.UI.Page
{
    OrganizationsDS org_ds = new OrganizationsDS();
    OrganizationsBiz org_biz = new OrganizationsBiz();
    protected void Page_Load(object sender, EventArgs e)
    {
        BaseDAL.ConnectionString = ConfigurationManager.ConnectionStrings["GovsFEConnString"].ToString();
        org_ds = org_biz.PopulateList("ORG_ID = 1 ");//+ Session["Org_ID"].ToString());
        Telephone.Text = org_ds.Organizations[0].ORG_Telephone;
        Adreess.Text = org_ds.Organizations[0].ORG_English_Address;
        Fax.Text = org_ds.Organizations[0].ORG_Fax;
        Mail.Text = org_ds.Organizations[0].ORG_Email;
        test.HRef = "mailto:" + org_ds.Organizations[0].ORG_Email;

        ///////////////////////////////////////////////
        HyperLink HLLanguages = (HyperLink)Master.FindControl("EnglishHL");
        if (Request.QueryString.Count == 0)
            HLLanguages.NavigateUrl = Request.Url.LocalPath.ToString().Replace("/en/", "/ar/");
        else
            HLLanguages.NavigateUrl = Request.Url.LocalPath.ToString().Replace("/en/", "/ar/") + "?ID=" + Request.QueryString["ID"];
        HtmlGenericControl left_div = (HtmlGenericControl)Master.FindControl("leftColumn");
        left_div.Visible = false;
        HtmlGenericControl body_content = (HtmlGenericControl)Master.FindControl("bodyContent");
        body_content.Attributes["class"] = String.Format("content2");
    }
}
