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
using System.Data.SqlClient;

public partial class AR_Controls_Search : System.Web.UI.UserControl
{
    OrganizationsDS org_ds = new OrganizationsDS();
    OrganizationsBiz org_biz = new OrganizationsBiz();



    BooksDS book_ds = new BooksDS();
    BooksBiz book_biz = new BooksBiz();

    CooporationsDS coop_ds = new CooporationsDS();
    CooporationsBiz coop_biz = new CooporationsBiz();

    BrochuresDS broch_ds = new BrochuresDS();
    BrochuresBiz broch_biz = new BrochuresBiz();

    BrochureFilesDS broch_files_ds = new BrochureFilesDS();
    BrochureFilesBiz broch_files_biz = new BrochureFilesBiz();


    ServicesDS serv_ds = new ServicesDS();
    ServicesBiz serv_biz = new ServicesBiz();

    ServiceFilesDS serv_files_ds = new ServiceFilesDS();
    ServiceFilesBiz serv_files_biz = new ServiceFilesBiz();

    ProjectsDS proj_ds = new ProjectsDS();
    ProjectsBiz proj_biz = new ProjectsBiz();

    ProjectFilesDS proj_files_ds = new ProjectFilesDS();
    ProjectFilesBiz proj_files_biz = new ProjectFilesBiz();

    LawsDS laws_ds = new LawsDS();
    LawsBiz laws_biz = new LawsBiz(); 

    LawFilesDS laws_files_ds = new LawFilesDS();
    LawFilesBiz laws_files_biz = new LawFilesBiz();
 
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewState["txt"] = Request.QueryString["txt"];
        if (!IsPostBack)
        {
            ViewState["txt"] = Request.QueryString["txt"];
            Search();
        }
        
        

    }
    /////////////--------------------------------------------------///////////////////
    /////////////--------------------------------------------------///////////////////

    
   

    /////////////--------------------------------------------------///////////////////
    /////////////--------------------------------------------------///////////////////
    /////////////--------------------------------------------------///////////////////
    /////////////--------------------------------------------------///////////////////
    /////////////--------------------------------------------------///////////////////
    /////////////--------------------------------------------------///////////////////
    /////////////--------------------------------------------------///////////////////
    /////////////--------------------------------------------------///////////////////
    /////////////--------------------------------------------------///////////////////
    /////////////--------------------------------------------------///////////////////
    protected void book_grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        book_grid.PageIndex = e.NewPageIndex;
    }
    protected void Achivment_Click(object sender, EventArgs e)
    {
        org_ds = (OrganizationsDS)ViewState["Achivments"];
        int Index = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        Response.Redirect("Achivments.aspx?id=" + org_ds.Organizations[Index].ORG_ID + "&txt=" + Request.QueryString["txt"]);

    }
    protected void History_Click(object sender, EventArgs e)
    {
        org_ds = (OrganizationsDS)ViewState["History"];
        int Index = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        Response.Redirect("History.aspx?id=" + org_ds.Organizations[Index].ORG_ID + "&txt=" + Request.QueryString["txt"]);

    }
    protected void Activity_Click(object sender, EventArgs e)
    {
        org_ds = (OrganizationsDS)ViewState["Activity"];
        int Index = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        Response.Redirect("Activity.aspx?id=" + org_ds.Organizations[Index].ORG_ID + "&txt=" + Request.QueryString["txt"]);

    }
    protected void Goals_Click(object sender, EventArgs e)
    {
        org_ds = (OrganizationsDS)ViewState["Goals"];
        int Index = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        Response.Redirect("Goals.aspx?id=" + org_ds.Organizations[Index].ORG_ID + "&txt=" + Request.QueryString["txt"]);

    }

    /////////////////////////////////////////////////////////////////////////////////////////////////

    protected void Cooperation_Click(object sender, EventArgs e)
    {
        coop_ds = (CooporationsDS)ViewState["Cooperation"];
        int Index = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        Response.Redirect("Cooperation.aspx?id=" + coop_ds.Cooporations[Index].Coop_ID + "&txt=" + Request.QueryString["txt"]);

    }
    protected void Project_Click(object sender, EventArgs e)
    {
        proj_ds = (ProjectsDS)ViewState["Projects"];
        int Index = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        Response.Redirect("Projects.aspx?id=" + proj_ds.Projects[Index].Project_ID + "&txt=" + Request.QueryString["txt"]);

    }
    protected void Brochures_Click(object sender, EventArgs e)
    {
        broch_ds = (BrochuresDS)ViewState["Brochures"];
        int Index = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        Response.Redirect("Publications.aspx?id=" + broch_ds.Brochures[Index].Brochure_ID + "&txt=" + Request.QueryString["text"]);
        //////////////////////////////////////////////////////////
        //DataTable dt = (DataTable)ViewState["Brochures"];
        //int Index = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        //Response.Redirect("Publications.aspx?id=" + dt.Rows[Index][0].ToString () + "&txt=" + Request.QueryString["text"]);

    }
    protected void Services_Click(object sender, EventArgs e)
    {
        serv_ds = (ServicesDS)ViewState["Services"];
        int Index = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        Response.Redirect("Service.aspx?id=" + serv_ds.Services[Index].Service_ID + "&txt=" + Request.QueryString["txt"]);
    }

    protected void Laws_Click(object sender, EventArgs e)
    {
        laws_ds   = (LawsDS)ViewState["Laws"];
        int Index = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        Response.Redirect("Laws.aspx?id=" + laws_ds.Laws[Index].Law_ID + "&txt=" + Request.QueryString["txt"]);
    }
    public static DataTable Populate(string sql)
    {
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GovsFEConnString"].ConnectionString);

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
    protected void Search()
    {
        //string text = "a";// Session["SearchTXT"].ToString();
        //TextBox mpTextBox = (TextBox)Page.Master.FindControl("txtSearch");
        //if (mpTextBox != null)
        //{
        //    text = mpTextBox.Text;
        //}

        string text = Session["SearchTXT"].ToString();
        //txtSearch.Text = "f"; 
        //add Achivments , goals , Activity , History
        //org_ds = org_biz.PopulateList("ORG_Arabic_Achivments like'%" + text + "%'");
        //Achivment_Grid.DataSource  = org_ds.Organizations;
        //Achivment_Grid.DataBind();
        //ViewState["Achivments"] = org_ds; 
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //org_ds = org_biz.PopulateList("ORG_Arabic_Goals like'%" + text + "%'");
        //Goals_Grid.DataSource = org_ds.Organizations;
        //Goals_Grid.DataBind();
        //ViewState["Goals"] = org_ds; 
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        //org_ds = org_biz.PopulateList("ORG_Arabic_Activity like'%" + text + "%'");
        //Activity_Grid.DataSource = org_ds.Organizations;
        //Activity_Grid.DataBind();
        //ViewState["Activity"] = org_ds; 
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        //org_ds = org_biz.PopulateList("ORG_Arabic_History like'%" + text + "%'");
        //History_Grid.DataSource = org_ds.Organizations;
        //History_Grid.DataBind();
        //ViewState["History"] = org_ds; 
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        //coop_ds = coop_biz.PopulateList("Coop_Arabic_Name like'%" + text + "%'");
        //cooperation_grid.DataSource = coop_ds.Cooporations;
        //ViewState["Cooperation"] = coop_ds;
        //cooperation_grid.DataBind();
        /////////////////////////////////////////////////////////////////////////////////////////////////
        //dr maryam
        //broch_files_ds = broch_files_biz.PopulateList("File_Path like'%" + text + "%'");
        //if (broch_files_ds.BrochureFiles.Rows.Count != 0)
        //{
        //    string condition = "";
        //    for (int i = 0; i < broch_files_ds.BrochureFiles.Rows.Count; i++)
        //        condition += " or Brochure_ID = " + broch_files_ds.BrochureFiles[i].Brochure_ID;
        //    broch_ds = broch_biz.PopulateList("Brochure_Arabic_Name like '%" + text + "%'" + condition);
        //}
        //else
        broch_ds = broch_biz.PopulateList("(Brochure_Arabic_Name LIKE N'%" + text + "%')");
        Brochures_grid.DataSource = broch_ds.Brochures;
        //DataTable dt = Populate("select * from Brochures where Brochure_Arabic_Name LIKE N'%" + text + "%'");
        Brochures_grid.DataSource = broch_ds;
        ViewState["Brochures"] = broch_ds;
        Brochures_grid.DataBind();
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        //dr maryam
        //serv_files_ds = serv_files_biz.PopulateList("File_Arabic_Name like'%" + text + "%'");
        //if (serv_files_ds.ServiceFiles.Rows.Count != 0)
        //{
        //    string condition = "";
        //    for (int i = 0; i < serv_files_ds.ServiceFiles.Rows.Count; i++)
        //        condition += " or Service_ID = " + serv_files_ds.ServiceFiles[i].Service_ID;
        //    serv_ds = serv_biz.PopulateList("Service_Arabic_Name like'%" + text + "%'" + condition);
        //}
        //else
            serv_ds = serv_biz.PopulateList("Service_Arabic_Name like N'%" + text + "%'");
        services_grid.DataSource = serv_ds.Services;
        ViewState["Services"] = serv_ds;
        services_grid.DataBind();
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        //dr maryam
        //proj_files_ds = proj_files_biz.PopulateList("File_Arabic_Name like'%" + text + "%'");
        //if (proj_files_ds.ProjectFiles.Rows.Count != 0)
        //{
        //    string condition = "";
        //    for (int i = 0; i < proj_files_ds.ProjectFiles.Rows.Count; i++)
        //        condition += " or Project_ID = " + proj_files_ds.ProjectFiles[i].Project_ID;
        //    proj_ds = proj_biz.PopulateList("Project_Arabic_Name like'%" + text + "%'" + condition);
        //}
        //else
            proj_ds = proj_biz.PopulateList("Project_Arabic_Name like N'%" + text + "%'");
        projects_grid.DataSource = proj_ds.Projects;
        ViewState["Projects"] = proj_ds;
        projects_grid.DataBind();
        ///////////////-----------------------------------------------///////////////////////////////////
        //dr maryam
        //laws_files_ds = laws_files_biz.PopulateList("File_Path like'%" + text + "%'");
        //if (laws_files_ds.LawFiles.Rows.Count != 0)
        //{
        //    string condition = "";
        //    for (int i = 0; i < laws_files_ds.LawFiles.Rows.Count; i++)
        //        condition += " or Law_ID = " + laws_files_ds.LawFiles[i].Law_ID;
        //    laws_ds = laws_biz.PopulateList("Law_Arabic_Name like'%" + text + "%'" + condition);
        //}
        //else
            laws_ds = laws_biz.PopulateList("Law_Arabic_Name like N'%" + text + "%'");
        laws_grid.DataSource = laws_ds.Laws;
        ViewState["Laws"] = laws_ds;
        laws_grid.DataBind();
        ///////////////////////////////////////////////////////////////////////////////////////////////////

        if (broch_ds.Brochures.Count==0 && coop_ds.Cooporations.Count == 0 && proj_ds.Projects.Count == 0 && laws_ds.Laws.Count == 0 && serv_ds.Services.Count == 0 && book_ds.Books.Count == 0)
           // ((OrganizationsDS)ViewState["Achivments"]).Organizations.Count == 0 && ((OrganizationsDS)ViewState["Goals"]).Organizations.Count == 0 && 
            //((OrganizationsDS)ViewState["Activity"]).Organizations.Count == 0 && ((OrganizationsDS)ViewState["History"]).Organizations.Count == 0 )
            NoResultLabel.Visible = true;
        else
           NoResultLabel.Visible = false ;
        
        //NoResultLabel.Visible = true ;
     //   NoResultLabel.Text = Session["SearchTXT"].ToString();
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {

    }
}
