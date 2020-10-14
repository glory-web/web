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

public partial class User_Controls_ControlPanel : System.Web.UI.UserControl
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
    public User_Controls_ControlPanel(string OrganizatioName)
    {
    }
    public User_Controls_ControlPanel():base()
    {
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BaseDAL.ConnectionString = ConfigurationManager.ConnectionStrings["VSConnectionString"].ToString();

            // Get Administrator name and organization name
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

            // Load Items in Control Panel GridView
            XmlDocument ControlPanelDoc = new XmlDocument();
            ControlPanelDoc.Load(Server.MapPath("~//App_Data//TasksMenue.xml"));
            if (ControlPanelDoc != null)
            {
                AdministrationGV.DataSource = XMLHelper.xml2Table(ControlPanelDoc, "/Items/Item", "TaskName,TaskLink", "TaskName,TaskLink", null);
                AdministrationGV.DataBind();
            }
        }
    }

    /// <summary>
    /// /////////////////
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void Link_OnClick(object sender, EventArgs e)
    {
        try
        {
            string virtualPath = ((LinkButton)(sender)).ToolTip;
            string controlPath = virtualPath;
            if (controlPath == null)
            {
                return;
            }
            Session["LastLoaded"] = virtualPath;
            UserControl c = (UserControl)LoadControl(controlPath);
            c.ID = "Control";
            this.FindControl("UserControlPlaceHolder").Controls.Clear();
            this.FindControl("UserControlPlaceHolder").Controls.Add(c);
        }
        catch (Exception ex)
        {
        }
    }
}
