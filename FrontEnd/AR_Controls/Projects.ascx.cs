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

public partial class Projects : System.Web.UI.UserControl
{
    ProjectsDS pro_ds = new ProjectsDS();
    ProjectsBiz pro_biz = new ProjectsBiz();

    ProjectFilesDS files_ds = new ProjectFilesDS();
    ProjectFilesBiz files_biz = new ProjectFilesBiz();

    //string StartTag = "<span style='background-color: #ffff66'>", EndTag = "</span>";
    string StartTag = "<b><i>", EndTag = "</b></i>";
    string build_string(string text, string key)
    {
        //return text;
        string new_string = text;
        int new_index = 0;
        if (text == key)
        {
            new_string = new_string.Insert(0, StartTag);
            new_string = new_string.Insert(key.Length + StartTag.Length, EndTag);

            return new_string;

        }
        if (key == "")
            return text;

        int c = 1;
        int index = text.IndexOf(key);
        if (index == -1)
            return text;
        new_string = new_string.ToLower();
        text = text.ToLower();
        string temp = text.Trim();
        while (temp.Contains(key))
        {
            c++;
            index = temp.IndexOf(key, 0);
            if (temp.StartsWith(key))
            {
                new_string = new_string.Insert(new_index, StartTag);
                new_string = new_string.Insert(new_index + key.Length + StartTag.Length, EndTag);
                new_index += key.Length + StartTag.Length + EndTag.Length + index;
                temp = temp.Substring(index + key.Length);
            }
            else
            {
                temp = temp.Substring(index);
                new_index += index;
            }
        }
        return new_string;

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        BaseDAL.ConnectionString = ConfigurationManager.ConnectionStrings["GovsFEConnString"].ToString();
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
            int Index = 0;
            Label_Proj_Discreption.Text = Operations.Key_Search_Color(pro_ds.Projects[Index].Project_Arabic_Discreption.Replace("\n", "<br/>"), txt);
            Label_Proj_Name.Text =Operations.Key_Search_Color(pro_ds.Projects[Index].Project_Arabic_Name,txt);
            Label_Project_EndDate.Text = Operations.Key_Search_Color(pro_ds.Projects[Index].Project_End_Date.ToShortDateString(), txt);
            Label_Project_StartDate.Text =Operations.Key_Search_Color(pro_ds.Projects[Index].Project_Start_Date.ToShortDateString (), txt);
            //maryam
            //Project_Link.NavigateUrl = pro_ds.Projects[Index].Project_URL;
            //Project_Link.Text = pro_ds.Projects[Index].Project_URL;
            //files_ds = files_biz.PopulateList("Project_ID = " + pro_ds.Projects[Index].Project_ID);
            //Repeater1.DataSource = files_ds.ProjectFiles;
            //Repeater1.DataBind();

            Project_Link.NavigateUrl = pro_ds.Projects[Index].Project_URL;
            Project_Link.Text = pro_ds.Projects[Index].Project_URL;

            Project_Files.NavigateUrl = "~/FrontEnd/ar/ProjectFiles.aspx?id=" + pro_ds.Projects[Index].Project_ID;
            
            MultiView1.ActiveViewIndex = 1;

            return;

        }
        pro_ds = pro_biz.PopulateList("Org_ID = " + Session["Org_ID"]);
        projects_grid.DataSource = pro_ds.Projects;
        projects_grid.DataBind();
        if (pro_ds.Projects.Rows.Count == 0)
            NoProject.Visible = true;
        else
            NoProject.Visible = false;
        //ViewState["projects"] = pro_ds;
        MultiView1.ActiveViewIndex = 0;

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //pro_ds = (ProjectsDS)ViewState["projects"];
        pro_ds = pro_biz.PopulateList("Org_ID = " + Session["Org_ID"]);
        int Index = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        Label_Proj_Discreption.Text = pro_ds.Projects[Index].Project_Arabic_Discreption.Replace("\n", "<br/>");
        Label_Proj_Name.Text = pro_ds.Projects[Index].Project_Arabic_Name;
        Label_Project_EndDate.Text = pro_ds.Projects[Index].Project_End_Date.ToShortDateString();
        Label_Project_StartDate.Text = pro_ds.Projects[Index].Project_Start_Date.ToShortDateString();
        Project_Link.NavigateUrl = pro_ds.Projects[Index].Project_URL;
        Project_Link.Text = pro_ds.Projects[Index].Project_URL;
        //maryam
        Project_Files.NavigateUrl = "~/FrontEnd/ar/ProjectFiles.aspx?id=" + pro_ds.Projects[Index].Project_ID;
        //files_ds = files_biz.PopulateList("Project_ID = " + pro_ds.Projects[Index].Project_ID);
        //Repeater1.DataSource = files_ds.ProjectFiles ;
        //Repeater1.DataBind();
        MultiView1.ActiveViewIndex = 1;

    }
    public string FilePath()
    {

        return "~/GovsFiles/ORG_" + Session["Org_ID"] + "_Files/Projects/";
    }
}
