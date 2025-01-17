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
using System.Data.SqlClient;
using System.IO;
using Businesslayer;
using Common;
using DataAccess;

public partial class UserControls_Projects : System.Web.UI.UserControl
{
    
    OrganizationsBiz OrganizationsBizObject = new OrganizationsBiz();
    OrganizationsDS OrganizationsDSObject;

    protected void Page_Load(object sender, EventArgs e)
    {
        BaseDAL.ConnectionString = ConfigurationManager.ConnectionStrings["VSConnectionString"].ToString();
 
        TXTProjectEnglishName.Style["text-align"] = "left";
        TXTProjectEnglishContent.Style["text-align"] = "left";
        TXTProjectURL.Style["text-align"] = "left";

        if (Session["OrgID"] == null)
        {
            Response.Redirect("~/BackEnd/default.aspx");
        }
        if (Session["OrgID"] != null)
        {
            if (!IsPostBack)
            {
                ProjectsBiz ProjectsBizObject = new ProjectsBiz();
                ProjectsDS ProjectsDSObject = ProjectsBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());

                if (ProjectsDSObject != null && ProjectsDSObject.Projects.Rows.Count > 0)
                {
                    MultiView1.ActiveViewIndex = 0;
                }
                else
                {
                    ClearCooperationForm();
                    MultiView1.ActiveViewIndex = 1;

                    ViewState["ProjectID"] = null;
                }

                GridView1.DataSource = ProjectsDSObject;
                GridView1.DataBind();
                FillHighLights();
            }
        }
        
    }

    void ClearCooperationForm()
    {
        try
        {
            this.TXTProjectArabicName.Text = "";
            this.TXTProjectEnglishName.Text = "";
            this.TXTProjectAraicContent.Text = "";
            this.TXTProjectEnglishContent.Text = "";
            this.TXTProjectStartDate.Text = "";
            this.TXTProjectEndDate.Text = "";
            this.TXTProjectURL.Text = "http://";

            this.BTNAdd.Visible = true;
            this.BTNUpdate.Visible = false;
        }
        catch (Exception ex)
        {
        }
    }
    bool FillCooperationForm(string CooperationID)
    {
        try
        {
            ProjectsBiz ProjectsBizObject = new ProjectsBiz();
            ProjectsDS ProjectsDSOject = ProjectsBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString() + " and Project_ID = " + CooperationID);

            this.TXTProjectArabicName.Text = ProjectsDSOject.Projects.Rows[0]["Project_Arabic_Name"].ToString();
            this.TXTProjectEnglishName.Text = ProjectsDSOject.Projects.Rows[0]["Project_English_Name"].ToString();
            this.TXTProjectAraicContent.Text = ProjectsDSOject.Projects.Rows[0]["Project_Arabic_Discreption"].ToString();
            this.TXTProjectEnglishContent.Text = ProjectsDSOject.Projects.Rows[0]["Project_English_Discreption"].ToString();


            DateTime ProjectStartDate = new DateTime();
            ProjectStartDate = DateTime.Parse(ProjectsDSOject.Projects.Rows[0]["Project_Start_Date"].ToString());

            string DTProjectStartDate = ProjectStartDate.Day.ToString() + "/" + ProjectStartDate.Month + "/" + ProjectStartDate.Year;
            //string DTProjectStartDate = new DateTime(Int32.Parse(ProjectStartDate.Substring(6, 4)), Int32.Parse(ProjectStartDate.Substring(3, 2)), Int32.Parse(ProjectStartDate.Substring(0, 2))).ToShortDateString();
            //string DTProjectStartDate = DateTime.Parse(ProjectStartDate).ToShortDateString();
            this.TXTProjectStartDate.Text = DTProjectStartDate;


            DateTime ProjectEndDate = new DateTime();
            ProjectEndDate = DateTime.Parse(ProjectsDSOject.Projects.Rows[0]["Project_End_Date"].ToString());

            string DTProjectEndDate = ProjectEndDate.Day.ToString() + "/" + ProjectEndDate.Month + "/" + ProjectEndDate.Year;

            //string ProjectEndDate = ProjectsDSOject.Projects.Rows[0]["Project_End_Date"].ToString();
            //string DTProjectEndDate = new DateTime(Int32.Parse(ProjectEndDate.Substring(6, 4)), Int32.Parse(ProjectEndDate.Substring(3, 2)), Int32.Parse(ProjectEndDate.Substring(0, 2))).ToShortDateString();
            //string DTProjectEndDate = DateTime.Parse(ProjectEndDate).ToShortDateString();
            this.TXTProjectEndDate.Text = DTProjectEndDate;

            this.TXTProjectURL.Text = ProjectsDSOject.Projects.Rows[0]["Project_URL"].ToString();

            this.BTNAdd.Visible = false;
            this.BTNUpdate.Visible = true;
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public static DataTable Populate(string sql)
    {
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["VSConnectionString"].ConnectionString);

        SqlDataAdapter adapter;
        try
        {
            con.Open();
            adapter = new SqlDataAdapter(sql, con);
            adapter.Fill(ds);
            if (ds.Tables.Count > 0)
                return ds.Tables[0];
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return new DataTable();
    }
    protected void LBTNEdit_Click(object sender, EventArgs e)
    {
        try
        {
            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            ProjectsBiz ProjectsBizObject = new ProjectsBiz();
            ProjectsDS ProjectsDSOject = ProjectsBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString());

            string ProjectID = ProjectsDSOject.Projects.Rows[RowIndex]["Project_ID"].ToString();

            ViewState.Add("ProjectID", ProjectID);

            if (FillCooperationForm(ProjectID))
            {
                MultiView1.ActiveViewIndex = 1;
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void LBTNDelete_Click(object sender, EventArgs e)
    {
        try
        {
            Confirm("هل تريد الحذف ؟");

            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            ProjectsBiz ProjectsBizObject = new ProjectsBiz();
            ProjectsDS ProjectsDSObject = ProjectsBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());

            int ProjectID = Int32.Parse(ProjectsDSObject.Projects.Rows[RowIndex]["Project_ID"].ToString());

            string SQL = "delete from Projects where Project_ID=" + ProjectID.ToString();
            Populate(SQL);

            GridView1.DataSource = ProjectsBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());
            GridView1.DataBind();
            FillHighLights();
        }
        catch (Exception ex)
        {
        }
    }
    protected void LBTNShowDetails_Click(object sender, EventArgs e)
    {
        try
        {
            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            ProjectsBiz ProjectsBizObject = new ProjectsBiz();
            ProjectsDS ProjectsDSOject = ProjectsBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString());

            string ProjectID = ProjectsDSOject.Projects.Rows[RowIndex]["Project_ID"].ToString();

            ProjectsDSOject = ProjectsBizObject.Populate(Int32.Parse(ProjectID));

            ViewState.Add("ProjectID", ProjectID);

            MultiView1.ActiveViewIndex = 2;

            Repeater1.DataSource = ProjectsDSOject;
            Repeater1.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    protected void LBTNAdd_Click(object sender, EventArgs e)
    {
        try
        {
            ClearCooperationForm();
            MultiView1.ActiveViewIndex = 1;
            ViewState["ProjectID"] = null;
        }
        catch (Exception ex)
        {
        }
    }
    protected void BTNAdd_Click(object sender, EventArgs e)
    {
        try
        {
            string ProjectArabicName = TXTProjectArabicName.Text;
            string ProjectEnglishName = TXTProjectEnglishName.Text;
            string ProjectArabicContent = TXTProjectAraicContent.Text;
            string ProjectEnglishContent = TXTProjectEnglishContent.Text;
            string ProjectStartDate = TXTProjectStartDate.Text;
            string ProjectEndDate = TXTProjectEndDate.Text;
            string ProjectURL = TXTProjectURL.Text;
            int OrgID = Int32.Parse(Session["OrgID"].ToString());

            DateTime DTProjectStartDate = new DateTime(Int32.Parse(ProjectStartDate.Substring(6, 4)), Int32.Parse(ProjectStartDate.Substring(3, 2)), Int32.Parse(ProjectStartDate.Substring(0, 2)));
            //DateTime DTProjectStartDate = DateTime.Parse(ProjectStartDate);
            DateTime DTProjectEndDate = new DateTime(Int32.Parse(ProjectEndDate.Substring(6, 4)), Int32.Parse(ProjectEndDate.Substring(3, 2)), Int32.Parse(ProjectEndDate.Substring(0, 2)));
            //DateTime DTProjectEndDate = DateTime.Parse(ProjectEndDate);

            ProjectsBiz ProjectsBizObject = new ProjectsBiz();
            ProjectsDS ProjectsDSObject = new ProjectsDS();
            ProjectsDS.ProjectsRow ProjectsRowOject = ProjectsDSObject.Projects.NewProjectsRow();

            ProjectsRowOject.ORG_ID = OrgID;
            ProjectsRowOject.Project_Arabic_Name = ProjectArabicName;
            ProjectsRowOject.Project_English_Name = ProjectEnglishName;
            ProjectsRowOject.Project_Arabic_Discreption = ProjectArabicContent;
            ProjectsRowOject.Project_English_Discreption = ProjectEnglishContent;
            ProjectsRowOject.Project_Start_Date = DTProjectStartDate;
            ProjectsRowOject.Project_End_Date = DTProjectEndDate;
            ProjectsRowOject.Project_URL = ProjectURL;

            ProjectsDSObject.Projects.AddProjectsRow(ProjectsRowOject);
            ProjectsDSObject = ProjectsBizObject.InsertProjects(ProjectsDSObject);

            GridView1.DataSource = ProjectsBizObject.PopulateList("ORG_ID=" + OrgID);
            GridView1.DataBind();
            FillHighLights();

            ClearCooperationForm();

            MultiView1.ActiveViewIndex = 0;

        }
        catch (Exception ex)
        {
        }
    }
    protected void BTNUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string ProjectArabicName = TXTProjectArabicName.Text;
            string ProjectEnglishName = TXTProjectEnglishName.Text;
            string ProjectArabicContent = TXTProjectAraicContent.Text;
            string ProjectEnglishContent = TXTProjectEnglishContent.Text;
            string ProjectStartDate = TXTProjectStartDate.Text;
            string ProjectEndDate = TXTProjectEndDate.Text;
            string ProjectURL = TXTProjectURL.Text;
            int OrgID = Int32.Parse(Session["OrgID"].ToString());

            DateTime DTProjectStartDate = new DateTime(Int32.Parse(ProjectStartDate.Substring(6, 4)), Int32.Parse(ProjectStartDate.Substring(3, 2)), Int32.Parse(ProjectStartDate.Substring(0, 2)));
            //DateTime DTProjectStartDate = DateTime.Parse(ProjectStartDate);
            DateTime DTProjectEndDate = new DateTime(Int32.Parse(ProjectEndDate.Substring(6, 4)), Int32.Parse(ProjectEndDate.Substring(3, 2)), Int32.Parse(ProjectEndDate.Substring(0, 2)));
            //DateTime DTProjectEndDate = DateTime.Parse(ProjectEndDate);

            ProjectsBiz ProjectsBizObject = new ProjectsBiz();
            ProjectsDS ProjectsDSObject = ProjectsBizObject.Populate(Int32.Parse(ViewState["ProjectID"].ToString()));

            ProjectsDSObject.Projects[0].ORG_ID = OrgID;
            ProjectsDSObject.Projects[0].Project_Arabic_Name = ProjectArabicName;
            ProjectsDSObject.Projects[0].Project_English_Name = ProjectEnglishName;
            ProjectsDSObject.Projects[0].Project_Arabic_Discreption = ProjectArabicContent;
            ProjectsDSObject.Projects[0].Project_English_Discreption = ProjectEnglishContent;
            ProjectsDSObject.Projects[0].Project_Start_Date = DTProjectStartDate;
            ProjectsDSObject.Projects[0].Project_End_Date = DTProjectEndDate;
            ProjectsDSObject.Projects[0].Project_URL = ProjectURL;

            ProjectsBizObject.UpdateProjects(ProjectsDSObject);

            GridView1.EditIndex = -1;
            GridView1.DataSource = ProjectsBizObject.PopulateList("ORG_ID=" + OrgID);
            GridView1.DataBind();
            FillHighLights();

            ClearCooperationForm();

            MultiView1.ActiveViewIndex = 0;

        }
        catch (Exception ex)
        {
        }
    }
    protected void BTNCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearCooperationForm();
            MultiView1.ActiveViewIndex = 0;
        }
        catch (Exception ex)
        {
        }
    }
    protected void LBTNClose_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            try
            {
                DataRow dr = ((DataRowView)e.Item.DataItem).Row;
                string ProjectStartDate = dr["Project_Start_Date"].ToString();
                //string DTProjectStartDate = new DateTime(Int32.Parse(ProjectStartDate.Substring(6, 4)), Int32.Parse(ProjectStartDate.Substring(3, 2)), Int32.Parse(ProjectStartDate.Substring(0, 2))).ToShortDateString();
                string DTProjectStartDate = DateTime.Parse(ProjectStartDate).ToShortDateString();
                ((Literal)e.Item.FindControl("Literal16")).Text = DTProjectStartDate;

                string ProjectEndDate = dr["Project_End_Date"].ToString();
                //string DTProjectEndDate = new DateTime(Int32.Parse(ProjectEndDate.Substring(6, 4)), Int32.Parse(ProjectEndDate.Substring(3, 2)), Int32.Parse(ProjectEndDate.Substring(0, 2))).ToShortDateString();
                string DTProjectEndDate = DateTime.Parse(ProjectEndDate).ToShortDateString();
                ((Literal)e.Item.FindControl("Literal20")).Text = DTProjectEndDate;
            }
            catch (Exception ex)
            {
            }
        }
    }
    protected void LBTNFiles_Click(object sender, EventArgs e)
    {
        try
        {
            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            ProjectsBiz ProjectsBizObject = new ProjectsBiz();
            ProjectsDS ProjectsDSObject = ProjectsBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());

            int ProjectID = Int32.Parse(ProjectsDSObject.Projects.Rows[RowIndex]["Project_ID"].ToString());
            ViewState.Add("ProjectID", ProjectID);

            ProjectFilesBiz ProjectFilesBizObject = new ProjectFilesBiz();
            ProjectFilesDS ProjectFilesDSObject = ProjectFilesBizObject.PopulateList("Project_ID =" + ProjectID);

            MultiView1.ActiveViewIndex = 3;
            GridView2.DataSource = ProjectFilesDSObject;
            GridView2.DataBind();

        }
        catch (Exception ex)
        {
        }
    }
    protected void LBTNUpdate_Click1(object sender, EventArgs e)
    {
        try
        {
            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            ProjectFilesBiz ProjectFilesBizObject = new ProjectFilesBiz();
            ProjectFilesDS ProjectFilesDSObject = ProjectFilesBizObject.PopulateList("Project_ID=" + ViewState["ProjectID"].ToString());

            int FileID = Int32.Parse(ProjectFilesDSObject.ProjectFiles.Rows[RowIndex]["File_ID"].ToString());

            ViewState.Add("ProjectFileID", FileID);
            GridView2.EditIndex = RowIndex;

            GridView2.DataSource = ProjectFilesDSObject;
            GridView2.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    protected void LBTNDelete_Click1(object sender, EventArgs e)
    {
        try
        {
            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            ProjectFilesBiz ProjectFilesBizObject = new ProjectFilesBiz();
            ProjectFilesDS ProjectFilesDSObject = ProjectFilesBizObject.PopulateList("Project_ID=" + ViewState["ProjectID"].ToString());

            int FileID = Int32.Parse(ProjectFilesDSObject.ProjectFiles.Rows[RowIndex]["File_ID"].ToString());

            string SQL = "delete from ProjectFiles where File_ID=" + FileID.ToString();
            Populate(SQL);

            ///////////////////////////////////////////// CV and Photo Not Complete ////////////////////
            if (ProjectFilesDSObject.ProjectFiles.Rows[RowIndex]["File_Path"].ToString() != null || ProjectFilesDSObject.ProjectFiles.Rows[RowIndex]["File_Path"].ToString() != "")
            {
                DirectoryInfo DirectoryInfoObject = new DirectoryInfo(Server.MapPath("~//GovsFiles//ORG_" + Session["OrgID"].ToString() + "_Files//Projects//Project_"+ViewState["ProjectID"].ToString()));
                if (!DirectoryInfoObject.Exists)
                {
                    DirectoryInfoObject.Create();
                }
                try
                {
                    FileInfo ServerProjectFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + ProjectFilesDSObject.ProjectFiles.Rows[RowIndex]["File_Path"].ToString());
                    if (ServerProjectFile.Exists)
                        ServerProjectFile.Delete();
                }
                catch (Exception ex)
                {
                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////////
            GridView2.DataSource = ProjectFilesBizObject.PopulateList("Project_ID=" + ViewState["ProjectID"].ToString());
            GridView2.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    protected void LBTNSava_Click1(object sender, EventArgs e)
    {
        try
        {
            string FileName = ((TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXTFileName")).Text;
            string EnglishFileName = ((TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXTFileEnglishName")).Text;
            FileUpload FilePath = ((FileUpload)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("FUProjectFile"));

            ProjectFilesBiz ProjectFilesBizObject = new ProjectFilesBiz();
            ProjectFilesDS ProjectFilesDSObject = ProjectFilesBizObject.Populate(Int32.Parse(ViewState["ProjectFileID"].ToString()));

            //////////////////////////// Save Uploaded File To Server /////////////////////////////////////
            
            if (FilePath.HasFile)
            {
                DirectoryInfo DirectoryInfoObject = new DirectoryInfo(Server.MapPath("~//GovsFiles//ORG_" + Session["OrgID"].ToString() + "_Files//Projects//Project_"+ViewState["ProjectID"].ToString()));
                if (!DirectoryInfoObject.Exists)
                {
                    DirectoryInfoObject.Create();
                }

                FileInfo ServerOldProjectsFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + ProjectFilesDSObject.ProjectFiles[0].File_Path);
                if (ServerOldProjectsFile.Exists)
                    ServerOldProjectsFile.Delete();

                FileInfo ServerOrojectsFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + FilePath.FileName);
                if (ServerOrojectsFile.Exists)
                    ServerOrojectsFile.Delete();
                FilePath.SaveAs(DirectoryInfoObject.FullName + "\\" + FilePath.FileName);
                ProjectFilesDSObject.ProjectFiles[0].File_Path = FilePath.FileName;

                //FileInfo Projectsfile = new FileInfo(FilePath.PostedFile.FileName);
                //if (Projectsfile.Exists)
                //{
                //    try
                //    {
                //        FileInfo ServerOldProjectsFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + ProjectFilesDSObject.ProjectFiles[0].File_Path);
                //        if (ServerOldProjectsFile.Exists)
                //            ServerOldProjectsFile.Delete();

                //        FileInfo ServerOrojectsFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + Projectsfile.Name);
                //        if (ServerOrojectsFile.Exists)
                //            ServerOrojectsFile.Delete();
                //        Projectsfile.CopyTo(DirectoryInfoObject.FullName + "\\" + Projectsfile.Name);
                //        ProjectFilesDSObject.ProjectFiles[0].File_Path = Projectsfile.Name;
                //    }
                //    catch (Exception ex)
                //    {
                //    }
                //}
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////
            ProjectFilesDSObject.ProjectFiles[0].Project_ID = Int32.Parse(ViewState["ProjectID"].ToString());
            ProjectFilesDSObject.ProjectFiles[0].File_Arabic_Name = FileName;
            ProjectFilesDSObject.ProjectFiles[0].File_English_Name = EnglishFileName;

            ProjectFilesBizObject.UpdateProjectFiles(ProjectFilesDSObject);

            GridView2.EditIndex = -1;
            GridView2.DataSource = ProjectFilesBizObject.PopulateList("Project_ID=" + ViewState["ProjectID"].ToString());
            GridView2.DataBind();


        }
        catch (Exception ex)
        {
        }
    }
    protected void LBTNCancel_Click1(object sender, EventArgs e)
    {
        try
        {
            ProjectFilesBiz ProjectFilesBizObject = new ProjectFilesBiz();
            GridView2.EditIndex = -1;
            GridView2.DataSource = ProjectFilesBizObject.PopulateList("Project_ID=" + ViewState["ProjectID"].ToString());
            GridView2.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    protected void LBTNAdd_Click1(object sender, EventArgs e)
    {
        try
        {
            string FileName = ((TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXTFileName")).Text;
            string EnglishFileName = ((TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXTFileEnglishName")).Text;
            FileUpload FilePath = ((FileUpload)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("FUProjectFile"));

            if (!FilePath.HasFile)
            {
                Page.RegisterStartupScript("ErrorMsg", "<script>alert('لابد من رفع الملف');</script>");
                return;
            }
           
            ProjectFilesBiz ProjectFilesBizObject = new ProjectFilesBiz();
            ProjectFilesDS ProjectFilesDSObject = new ProjectFilesDS();
            ProjectFilesDS.ProjectFilesRow ProjectFilesRowObject = ProjectFilesDSObject.ProjectFiles.NewProjectFilesRow();

            //ProjectFilesRowObject.File_ID = Int32.Parse(ViewState["ProjectID"].ToString());
            ProjectFilesRowObject.File_Arabic_Name = FileName;
            ProjectFilesRowObject.File_English_Name = EnglishFileName;
            ProjectFilesRowObject.Project_ID = Int32.Parse(ViewState["ProjectID"].ToString());

            //////////////////////////// Save Uploaded File To Server /////////////////////////////////////
            if (FilePath.HasFile)
            {
                DirectoryInfo DirectoryInfoObject = new DirectoryInfo(Server.MapPath("~//GovsFiles//ORG_" + Session["OrgID"].ToString() + "_Files//Projects//Project_" + ViewState["ProjectID"].ToString()));
                if (!DirectoryInfoObject.Exists)
                {
                    DirectoryInfoObject.Create();
                }

                FileInfo ServerProjectFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + FilePath.FileName);
                if (ServerProjectFile.Exists)
                    ServerProjectFile.Delete();
                FilePath.SaveAs(DirectoryInfoObject.FullName + "\\" + FilePath.FileName);
                ProjectFilesRowObject.File_Path = FilePath.FileName;

                //FileInfo Projectfile = new FileInfo(FilePath.PostedFile.FileName);
                //if (Projectfile.Exists)
                //{
                //    try
                //    {
                //        FileInfo ServerProjectFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + Projectfile.Name);
                //        if (ServerProjectFile.Exists)
                //            ServerProjectFile.Delete();
                //        Projectfile.CopyTo(DirectoryInfoObject.FullName + "\\" + Projectfile.Name);
                //        ProjectFilesRowObject.File_Path = Projectfile.Name;
                //    }
                //    catch (Exception ex)
                //    {
                //    }
                //}
            }
            
            ////////////////////////////////////////////////////////////////////////////////////////////
            ProjectFilesDSObject.ProjectFiles.AddProjectFilesRow(ProjectFilesRowObject);
            ProjectFilesBizObject.InsertProjectFiles(ProjectFilesDSObject);

            GridView2.DataSource = ProjectFilesBizObject.PopulateList("Project_ID=" + ViewState["ProjectID"].ToString());
            GridView2.DataBind();

        }
        catch (Exception ex)
        {
        }
    }
    protected void CHBHighlight_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox CHBVisable = ((CheckBox)sender);
            if (CHBVisable.Checked)
            {
                int RowIndex = ((GridViewRow)((CheckBox)sender).Parent.Parent).RowIndex;

                ProjectsBiz ProjectsBizObject = new ProjectsBiz();
                ProjectsDS ProjectsDSObject = ProjectsBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());

                decimal RecordID = Decimal.Parse(ProjectsDSObject.Projects.Rows[RowIndex]["Project_ID"].ToString());
                decimal RecordType = 5;
                bool RecordVisable = true;

                HighLightsBiz HighLightsBizObject = new HighLightsBiz();
                HighLightsDS HighLightsDSObject = new HighLightsDS();
                HighLightsDS.HighLightsRow HighLightsRowObject = HighLightsDSObject.HighLights.NewHighLightsRow();
                HighLightsRowObject.RecordID = RecordID;
                HighLightsRowObject.Type = RecordType;
                HighLightsRowObject.Visible = RecordVisable;

                HighLightsDSObject.HighLights.AddHighLightsRow(HighLightsRowObject);
                HighLightsBizObject.InsertHighLights(HighLightsDSObject);
            }
            else
            {
                int RowIndex = ((GridViewRow)((CheckBox)sender).Parent.Parent).RowIndex;

                ProjectsBiz ProjectsBizObject = new ProjectsBiz();
                ProjectsDS ProjectsDSObject = ProjectsBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());

                decimal RecordID = Decimal.Parse(ProjectsDSObject.Projects.Rows[RowIndex]["Project_ID"].ToString());
                string Type = "5";

                HighLightsBiz HighLightsBizObject = new HighLightsBiz();
                HighLightsDS HighLightsDSObject = HighLightsBizObject.PopulateList("RecordID=" + RecordID + " and Type=" + Type);

                string HLID = HighLightsDSObject.HighLights.Rows[0]["HLID"].ToString();

                string SQL = "delete from HighLights where HLID=" + HLID;
                Populate(SQL);

                SQL = "delete from HighlightSet where HLID = " + HLID;
                Populate(SQL);
            }

        }
        catch (Exception ex)
        {
        }
    }
    void FillHighLights()
    {
        foreach (GridViewRow GVRow in GridView1.Rows)
        {
            int RowIndex = GVRow.RowIndex;

            ProjectsBiz ProjectsBizObject = new ProjectsBiz();
            ProjectsDS ProjectsDSObject = ProjectsBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());

            decimal RecordID = Decimal.Parse(ProjectsDSObject.Projects.Rows[RowIndex]["Project_ID"].ToString());
            string Type = "5";

            HighLightsBiz HighLightsBizObject = new HighLightsBiz();
            HighLightsDS HighLightsDSObject = HighLightsBizObject.PopulateList("RecordID=" + RecordID + " and Type=" + Type);

            if (HighLightsDSObject != null && HighLightsDSObject.HighLights.Rows.Count > 0)
            {
                ((CheckBox)((GridViewRow)(GVRow)).FindControl("CHBHighlight")).Checked = true;
            }
        }
    }
    private void Alert(string msg)
    {
        string Script = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ss", Script, true);
    }
    private void Confirm(string msg)
    {
        string Script = "return confirm('" + msg + "');";


        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ss", Script, true);
    }
}
