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

public partial class inner : System.Web.UI.Page
{
    bool? isPostedBool = null;
    public new bool IsPostBack
    {
        get
        {
            if (isPostedBool.HasValue)
                return isPostedBool.Value;
            if (base.IsPostBack == false)
            {
                isPostedBool = false;
                return false;
            }
            if (ViewState["LoadedOnce"] == null)
            {
                ViewState["LoadedOnce"] = "yes";
                isPostedBool = false;
                return false;
            }
            else
            {
                isPostedBool = true;
                return true;
            }
        }
    }

    private string LastLoadedControl
    {
        get
        {
            return Session["LastLoaded"] as string;
        }
        set
        {
            Session["LastLoaded"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null && Session["UserName"] == null && Session["UserPassword"] == null)
            Response.Redirect("~/default.aspx");
        LoadTopNav();
        LoadContent();
        
    }
    //--------------------
    public void LoadTopNav()
    {
        //UserControl cTopNav = (UserControl)LoadControl("UserControls/topnav.ascx");
        //cTopNav.ID = "TopControl";
        //Master.FindControl("TopNav").FindControl("PlaceHolder1").Controls.Add(cTopNav);
    }
    //----------------

    public void LoadContent()
    {
        try
        {
            if (IsPostBack)
            {
                string controlPath = LastLoadedControl;
                if (controlPath == null)
                    return;
                UserControl cContent = (UserControl)LoadControl(controlPath);
                cContent.ID = "Control";
                cContent.EnableViewState = true;
                try
                {
                    Master.FindControl("ContentPlaceHolder1").Controls[1].FindControl("UserControlPlaceHolder").Controls.Add(cContent);
                }
                catch
                {
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
}
