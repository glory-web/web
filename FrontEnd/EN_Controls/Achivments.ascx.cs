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

public partial class Achivments : System.Web.UI.UserControl
{
    OrganizationsDS org_ds = new OrganizationsDS();
    OrganizationsBiz org_biz = new OrganizationsBiz();
    protected void Page_Load(object sender, EventArgs e)
    {
        BaseDAL.ConnectionString = ConfigurationManager.ConnectionStrings["GovsFEConnString"].ToString();

        if (Request.QueryString.Count != 0)
        {
            org_ds = org_biz.PopulateList("ORG_ID = " + Request.QueryString[0]);
            Lit_Achivments.Text = org_ds.Organizations[0].ORG_English_Achivments.Replace("\n", "<br/>");
            return;

        }
        org_ds = org_biz.PopulateList("ORG_ID = " + Session["Org_ID"].ToString());
        Lit_Achivments.Text = org_ds.Organizations[0].ORG_English_Achivments.Replace("\n", "<br/>");
    }
}