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
using Common;
using Businesslayer;
using DataAccess;
public partial class FrontEnd_AR_Controls_ProjectDownload : System.Web.UI.UserControl
{
    ProjectFilesDS files_ds = new ProjectFilesDS();
    ProjectFilesBiz files_biz = new ProjectFilesBiz();

    ProjectsDS pro_ds = new ProjectsDS();
    ProjectsBiz pro_biz = new ProjectsBiz();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count != 0)
        {

            int temp;
            string txt;
            if (string.IsNullOrEmpty(Request.QueryString["ID"]))
                return;
            if (string.IsNullOrEmpty(Request.QueryString["txt"]))
                txt = "";
            else
                txt = Request.QueryString["txt"];
            if (!int.TryParse(Request.QueryString[0], out temp))
                return;
            pro_ds = pro_biz.PopulateList("Project_ID = " + Request.QueryString["ID"]);
            if (pro_ds.Projects.Count == 0)
                return;
            ProjectName.Text = pro_ds.Projects[0].Project_English_Name;
            
            ////////////////////////////////////////////////////////////////////////////////
            files_ds = files_biz.PopulateList("Project_ID = " + pro_ds.Projects[0].Project_ID);
            Repeater1.DataSource = files_ds.ProjectFiles;
            Repeater1.DataBind();
        }
       
    }
    

    public string FilePath()
    {

        return "~/GovsFiles/ORG_" + Session["Org_ID"] + "_Files/Projects/Project_";
    }
}
