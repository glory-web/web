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

public partial class AR_Controls_WebUserControl : System.Web.UI.UserControl
{
    OrganizationMangersDS man_ds = new OrganizationMangersDS();
    OrganizationMangersBiz man_biz = new OrganizationMangersBiz();
        

    
    protected void Page_Load(object sender, EventArgs e)
    {
        BaseDAL.ConnectionString = ConfigurationManager.ConnectionStrings["GovsFEConnString"].ToString();
        //Maryam man_ds = man_biz.PopulateList("State = 1 and  Org_ID = " + Session["Org_ID"].ToString());
        man_ds = man_biz.PopulateList("State = 0 and  Org_ID = " + Session["Org_ID"].ToString());
        if (man_ds.OrganizationMangers.Count == 0)
            return;
        Label_Manger_Word.Text = man_ds.OrganizationMangers[0].Man_Arabic_Word;
        Label_Manger_Name.Text = man_ds.OrganizationMangers[0].Man_Arabic_Name;
        Manger_Photo.ImageUrl = ImagePath ()+ man_ds.OrganizationMangers[0].Man_Photo_Path;
        if (System.IO.File.Exists(Server.MapPath(CVPath() + man_ds.OrganizationMangers[0].Man_CV_Path)))
            Label_Manger_Name.NavigateUrl = CVPath() + man_ds.OrganizationMangers[0].Man_CV_Path;
        else
            Label_Manger_Name.NavigateUrl = "";
               
        Session.Add("CVName", man_ds.OrganizationMangers[0].Man_CV_Path);
        
    }
    public string ImagePath()
    {
        return "~/GovsFiles/ORG_" + Session["Org_ID"].ToString () + "_Files/Managers/Photos/";
    }
    public string CVPath()
    {
        return "~/GovsFiles/ORG_" + Session["Org_ID"].ToString() + "_Files/Managers/CV/";
    }
    public string GetCVName()
    {
        return Session["CVName"].ToString();
    }
}
