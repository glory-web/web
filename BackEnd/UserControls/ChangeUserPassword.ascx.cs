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
using System.Xml;
using Businesslayer;
using Common;
using DataAccess;
using GOVS;

public partial class UserControls_ChangeUserPassword : System.Web.UI.UserControl
{
    AdministrationBiz AdministrationBizObject;
    AdministrationDS AdministrationDSObjects;

    OrganizationsBiz OrganizationsBizObject;
    OrganizationsDS OrganizationsDSObject;

    private string _OrganizatioName = "";

    public string OrganizationName
    {
        set
        {
            _OrganizatioName = value;
        }
        get
        {
            return _OrganizatioName;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        BaseDAL.ConnectionString = ConfigurationManager.ConnectionStrings["VSConnectionString"].ToString();

        int UserID = -1;
        if (Session["UserID"] != null)
        {
            try
            {
                UserID = Int32.Parse(Session["UserID"].ToString());
            }
            catch (Exception ex)
            {
            }
        }
        AdministrationBizObject = new AdministrationBiz();
        AdministrationDSObjects = AdministrationBizObject.Populate(UserID);

        if (AdministrationDSObjects.Administration.Rows.Count > 0)
        {
            this.LITAdminName.Text = AdministrationDSObjects.Administration.Rows[0]["Admin_Name"].ToString();

            int ORGID = -1;

            try
            {
                ORGID = Int32.Parse(AdministrationDSObjects.Administration.Rows[0]["ORG_ID"].ToString());
            }
            catch (Exception ex)
            {
            }
            OrganizationsBizObject = new OrganizationsBiz();
            OrganizationsDSObject = OrganizationsBizObject.Populate(ORGID);
            if (OrganizationsDSObject.Organizations.Rows.Count > 0)
            {
                this.LITAdminOrg.Text = OrganizationsDSObject.Organizations.Rows[0]["ORG_Arabic_Name"].ToString();
            }
        }
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            int UserID = -1;
            if (Session["UserID"] != null)
            {
                try
                {
                    UserID = Int32.Parse(Session["UserID"].ToString());
                }
                catch (Exception ex)
                {
                }
            }
            AdministrationBizObject = new AdministrationBiz();
            AdministrationDSObjects = AdministrationBizObject.Populate(UserID);

            if (AdministrationDSObjects.Administration.Rows.Count > 0)
            {
                if (args.Value == AdministrationDSObjects.Administration.Rows[0]["Admin_Password"].ToString())
                    args.IsValid = true;
                else
                    args.IsValid = false;
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void BTNSave_Click(object sender, EventArgs e)
    {
        try
        {
            int UserID = -1;
            if (Session["UserID"] != null)
            {
                try
                {
                    UserID = Int32.Parse(Session["UserID"].ToString());
                }
                catch (Exception ex)
                {
                }
            }
            string NewPassword = this.TXTNewPassword.Text;
            AdministrationBiz AdministrationBizObject = new AdministrationBiz();
            AdministrationDS AdministrationDSObject = AdministrationBizObject.Populate(UserID);

            AdministrationDSObject.Administration[0].Admin_Password = NewPassword;

            AdministrationBizObject.UpdateAdministration(AdministrationDSObject);

            Session.Add("UserPassword", NewPassword);

            Response.Redirect("~/BackEnd/inner.aspx");

        }
        catch (Exception ex)
        {
        }
    }
    protected void BTNCancel_Click(object sender, EventArgs e)
    {
        try
        {
            this.TXTOldPassword.Text = "";
            this.TXTNewPassword.Text = "";
            this.TXTReNewPassword.Text = "";
            Response.Redirect("~/BackEnd/inner.aspx");
        }
        catch (Exception ex)
        {
        }
    }
}
