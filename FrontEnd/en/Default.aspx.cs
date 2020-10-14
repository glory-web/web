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
using DataAccess;
using Common;
using Businesslayer;

public partial class en_Default : System.Web.UI.Page
{
    /*public static  int Get_Org_ID(int Org_ID)
    {
        OrganizationsDS org_ds = new OrganizationsDS();
        OrganizationsBiz org_biz = new OrganizationsBiz();
        org_ds = org_biz.PopulateList("Org_ID = " +Org_ID );
        if (org_ds.Organizations.Count > 0)
            return org_ds.Organizations[0].ORG_Type_ID;
        else
            return -1;

    }*/
    protected void Page_Load(object sender, EventArgs e)
    {
        HyperLink HLLanguages = (HyperLink)Master.FindControl("EnglishHL");
        HLLanguages.NavigateUrl = Request.Url.LocalPath.ToString().Replace("/en/", "/ar/");
        Session["Org_Type_ID"] = 1;

    }
}
