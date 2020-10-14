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

public partial class Master : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["OrgID"] == null)
        {
            Response.Redirect("~/BackEnd/default.aspx");
        }
        else
        {
            lnkLogout.Visible = true;

            AdministrationBiz AdministrationBizObject = new AdministrationBiz();
            AdministrationDS AdministrationDSObject = AdministrationBizObject.Populate(Int32.Parse(Session["UserID"].ToString()));

            if (AdministrationDSObject != null)
            {
                if (AdministrationDSObject.Administration.Rows.Count > 0)
                {
                    lblUserName.Text = AdministrationDSObject.Administration[0].Admin_Name;

                    OrganizationsBiz OrganizationsBizObject = new OrganizationsBiz();
                    OrganizationsDS OrganizationsDSObject = OrganizationsBizObject.Populate(Int32.Parse(Session["OrgID"].ToString()));
                    lblProjectName.Text = OrganizationsDSObject.Organizations[0].ORG_Arabic_Name;
                }
            }
        }
    }
    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Session["OrgID"] = null;
        Session["UserName"] = null;
        Session["UserPassword"] = null;
        Session["UserID"] = null;
        Response.Redirect("~/BackEnd/Default.aspx");
    }
    protected void lnkProfile_Click(object sender, EventArgs e)
    {
        Response.Redirect("Users.aspx");
    }
}
