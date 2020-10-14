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

public partial class login : System.Web.UI.UserControl
{
    AdministrationBiz AdministrationBizObject;
    AdministrationDS AdministrationDSObject;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        BaseDAL.ConnectionString = ConfigurationManager.ConnectionStrings["VSConnectionString"].ToString();
        if (Session["UserID"] != null)
        {
            div1.Visible = false;
            litName.Text = Session["UserName"].ToString();
        }
    }
    protected void lnkLogin_Click(object sender, ImageClickEventArgs e)
    {
        AdministrationBizObject = new AdministrationBiz();
        AdministrationDSObject = AdministrationBizObject.PopulateList("Admin_UserName='" + txtUser.Text.Trim() + "' and Admin_Password='" + txtPass.Text.Trim() + "'");

        if (AdministrationDSObject.Administration.Rows.Count > 0)
        {
            if (AdministrationDSObject.Administration.Rows[0]["Admin_UserName"].ToString() == txtUser.Text.Trim() && AdministrationDSObject.Administration.Rows[0]["Admin_Password"].ToString() == txtPass.Text.Trim())
            {
                Session.Add("UserID", AdministrationDSObject.Administration.Rows[0]["Admin_ID"]);
                Session.Add("UserName", txtUser.Text.Trim());
                Session.Add("UserPassword", txtPass.Text.Trim());

                litName.Text = AdministrationDSObject.Administration.Rows[0]["Admin_Name"].ToString();

                Session.Add("OrgID", AdministrationDSObject.Administration.Rows[0]["ORG_ID"]);

                OrganizationsBiz OrganizationsBizObject = new OrganizationsBiz();
                OrganizationsDS OrganizationsDSObject = OrganizationsBizObject.Populate(Int32.Parse(AdministrationDSObject.Administration.Rows[0]["ORG_ID"].ToString()));
                Session.Add("OrgTypeID", OrganizationsDSObject.Organizations.Rows[0]["Org_Type_ID"]);

                Response.Redirect("~/BackEnd/inner.aspx");
            }
            else
            {
                Label3.Visible = true;
                return;
            }
        }
    }
    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        try
        {
            Session["OrgID"] = null;
            Session["UserName"] = null;
            Session["UserPassword"] = null;
            Session["UserID"] = null;
            div1.Visible = true;
        }
        catch (Exception ex)
        {
        }
    }
}
