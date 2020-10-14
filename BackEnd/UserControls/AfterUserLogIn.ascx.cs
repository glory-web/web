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

public partial class BackEnd_UserControls_AfterUserLogIn : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AdministrationBiz AdministrationBizObject = new AdministrationBiz();
        AdministrationDS AdministrationDSObject = AdministrationBizObject.Populate(Int32.Parse(Session["UserID"].ToString()));

        if (AdministrationDSObject != null)
        {
            if (AdministrationDSObject.Administration.Rows.Count > 0)
            {
                this.LITUserFullName.Text = AdministrationDSObject.Administration[0].Admin_Name;

                OrganizationsBiz OrganizationsBizObject = new OrganizationsBiz();
                OrganizationsDS OrganizationsDSObject = OrganizationsBizObject.Populate(Int32.Parse(Session["OrgID"].ToString()));
                this.LITUserOrganization.Text = OrganizationsDSObject.Organizations[0].ORG_Arabic_Name;
            }
        }
    }
}
