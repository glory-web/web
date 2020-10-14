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

public partial class AR_Controls_AdvancedSearch : System.Web.UI.UserControl
{
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

    }

    void Book_Start(string search_txt)
    {
        book_ds = book_biz.PopulateList(@"Book_Arabic_Name like '" + search_txt + "%'" +
                                   " or Authour_Arabic_Name like '" + search_txt + "%'" +
                                   " or Publication_Year like '" + search_txt + "%'");
        book_grid.DataSource = book_ds.Books;
        ViewState["Books"] = book_ds;
        book_grid.DataBind();
    }
    void Book_End(string search_txt)
    {
        book_ds = book_biz.PopulateList(@"Book_Arabic_Name like '%" + search_txt + "'" +
                                   " or Authour_Arabic_Name like '%" + search_txt + "'" +
                                   " or Publication_Year like '%" + search_txt + "'");
        book_grid.DataSource = book_ds.Books;
        ViewState["Books"] = book_ds;
        book_grid.DataBind();
    }
    void Book_Contain(string search_txt)
    {
        book_ds = book_biz.PopulateList(@"Book_Arabic_Name like '%" + search_txt + "%'" +
                                   " or Authour_Arabic_Name like '%" + search_txt + "%'" +
                                   " or Publication_Year like '%" + search_txt + "%'");
        book_grid.DataSource = book_ds.Books;
        ViewState["Books"] = book_ds;
        book_grid.DataBind();
    }
    void Book_Identical(string search_txt)
    {
        book_ds = book_biz.PopulateList(@"Book_Arabic_Name like '" + search_txt + "'" +
                                   " or Authour_Arabic_Name like '" + search_txt + "'" +
                                   " or Publication_Year like '" + search_txt + "'");
        book_grid.DataSource = book_ds.Books;
        ViewState["Books"] = book_ds;
        book_grid.DataBind();
    }
    /////////////--------------------------------------------------///////////////////
    /////////////--------------------------------------------------///////////////////
    void Services_Start(string search_txt)
    {
        serv_files_ds = serv_files_biz.PopulateList("File_Arabic_Name like'" + search_txt + "%'");
        if (serv_files_ds.ServiceFiles.Rows.Count != 0)
        {
            string condition = "";
            for (int i = 0; i < serv_files_ds.ServiceFiles.Rows.Count; i++)
                condition += " or Service_ID = " + serv_files_ds.ServiceFiles[i].Service_ID;
            serv_ds = serv_biz.PopulateList(@"Service_Arabic_Name like'" + search_txt + "%'" +
                                         " or Service_Arabic_Conditions like '" + search_txt + "%'" +
                                         " or Service_Arabic_Procedures like '" + search_txt + "%'" + condition);

        }
        else
            serv_ds = serv_biz.PopulateList(@"Service_Arabic_Name like'" + search_txt + "%'" +
                                         " or Service_Arabic_Conditions like '" + search_txt + "%'" +
                                         " or Service_Arabic_Procedures like '" + search_txt + "%'");
        services_grid.DataSource = serv_ds.Services;
        ViewState["Services"] = serv_ds;
        services_grid.DataBind();
    }
    void Services_End(string search_txt)
    {
        serv_files_ds = serv_files_biz.PopulateList("File_Arabic_Name like'" + search_txt + "%'");
        if (serv_files_ds.ServiceFiles.Rows.Count != 0)
        {
            string condition = "";
            for (int i = 0; i < serv_files_ds.ServiceFiles.Rows.Count; i++)
                condition += " or Service_ID = " + serv_files_ds.ServiceFiles[i].Service_ID;
            serv_ds = serv_biz.PopulateList(@"Service_Arabic_Name like '%" + search_txt + "'" +
                                         " or Service_Arabic_Conditions like '%" + search_txt + "'" +
                                         " or Service_Arabic_Procedures like '%" + search_txt + "'" + condition);

        }
        else
            serv_ds = serv_biz.PopulateList(@"Service_Arabic_Name like '%" + search_txt + "'" +
                                         " or Service_Arabic_Conditions like '%" + search_txt + "'" +
                                         " or Service_Arabic_Procedures like '%" + search_txt + "'");
        services_grid.DataSource = serv_ds.Services;
        ViewState["Services"] = serv_ds;
        services_grid.DataBind();
    }
    void Services_Contain(string search_txt)
    {

        serv_files_ds = serv_files_biz.PopulateList("File_Arabic_Name like'" + search_txt + "%'");
        if (serv_files_ds.ServiceFiles.Rows.Count != 0)
        {
            string condition = "";
            for (int i = 0; i < serv_files_ds.ServiceFiles.Rows.Count; i++)
                condition += " or Service_ID = " + serv_files_ds.ServiceFiles[i].Service_ID;
            serv_ds = serv_biz.PopulateList(@"Service_Arabic_Name like '%" + search_txt + "%'" +
                                         " or Service_Arabic_Conditions like '%" + search_txt + "%'" +
                                         " or Service_Arabic_Procedures like '%" + search_txt + "%'" + condition);

        }
        else
            serv_ds = serv_biz.PopulateList(@"Service_Arabic_Name like '%" + search_txt + "%'" +
                                         " or Service_Arabic_Conditions like '%" + search_txt + "%'" +
                                         " or Service_Arabic_Procedures like '%" + search_txt + "%'");
        services_grid.DataSource = serv_ds.Services;
        ViewState["Services"] = serv_ds;
        services_grid.DataBind();
    }
    void Services_Identical(string search_txt)
    {
        serv_files_ds = serv_files_biz.PopulateList("File_Arabic_Name like'" + search_txt + "%'");
        if (serv_files_ds.ServiceFiles.Rows.Count != 0)
        {
            string condition = "";
            for (int i = 0; i < serv_files_ds.ServiceFiles.Rows.Count; i++)
                condition += " or Service_ID = " + serv_files_ds.ServiceFiles[i].Service_ID;
            serv_ds = serv_biz.PopulateList(@"Service_Arabic_Name like '" + search_txt + "'" +
                                         " or Service_Arabic_Conditions like '" + search_txt + "'" +
                                         " or Service_Arabic_Procedures like '" + search_txt + "'" + condition);

        }
        else
            serv_ds = serv_biz.PopulateList(@"Service_Arabic_Name like '" + search_txt + "'" +
                                         " or Service_Arabic_Conditions like '" + search_txt + "'" +
                                         " or Service_Arabic_Procedures like '" + search_txt + "'");
        services_grid.DataSource = serv_ds.Services;
        ViewState["Services"] = serv_ds;
        services_grid.DataBind();
    }
    /////////////--------------------------------------------------///////////////////
    /////////////--------------------------------------------------///////////////////
    void Projects_Start(string search_txt)
    {
        proj_files_ds = proj_files_biz.PopulateList("File_Arabic_Name like '" + search_txt + "%'");
        if (proj_files_ds.ProjectFiles.Rows.Count != 0)
        {
            string condition = "";
            for (int i = 0; i < proj_files_ds.ProjectFiles.Rows.Count; i++)
                condition += " or Project_ID = " + proj_files_ds.ProjectFiles[i].Project_ID;
            proj_ds = proj_biz.PopulateList("Project_Arabic_Name like'" + search_txt + "%'" +
                                        " or Project_Arabic_Discreption like '" + search_txt + "%'" +
                                        " or Project_Start_Date like '" + search_txt + "%'" + condition);
        }
        else
            proj_ds = proj_biz.PopulateList(@"Project_Arabic_Name like'" + search_txt + "%'" +
                                        " or Project_Arabic_Discreption like '" + search_txt + "%'" +
                                        " or Project_Start_Date like '" + search_txt + "%'");
        projects_grid.DataSource = proj_ds.Projects;
        ViewState["Projects"] = proj_ds;
        projects_grid.DataBind();
    }
    void Projects_End(string search_txt)
    {
        proj_files_ds = proj_files_biz.PopulateList("File_Arabic_Name like '%" + search_txt + "'");
        if (proj_files_ds.ProjectFiles.Rows.Count != 0)
        {
            string condition = "";
            for (int i = 0; i < proj_files_ds.ProjectFiles.Rows.Count; i++)
                condition += " or Project_ID = " + proj_files_ds.ProjectFiles[i].Project_ID;
            proj_ds = proj_biz.PopulateList("Project_Arabic_Name like '%" + search_txt + "'" +
                                        " or Project_Arabic_Discreption like '%" + search_txt + "'" +
                                        " or Project_Start_Date like '%" + search_txt + "'" + condition);
        }
        else
            proj_ds = proj_biz.PopulateList(@"Project_Arabic_Name like '%" + search_txt + "'" +
                                        " or Project_Arabic_Discreption like '%" + search_txt + "'" +
                                        " or Project_Start_Date like '%" + search_txt + "'");
        projects_grid.DataSource = proj_ds.Projects;
        ViewState["Projects"] = proj_ds;
        projects_grid.DataBind();
    }
    void Projects_Contain(string search_txt)
    {

        proj_files_ds = proj_files_biz.PopulateList("File_Arabic_Name like '%" + search_txt + "%'");
        if (proj_files_ds.ProjectFiles.Rows.Count != 0)
        {
            string condition = "";
            for (int i = 0; i < proj_files_ds.ProjectFiles.Rows.Count; i++)
                condition += " or Project_ID = " + proj_files_ds.ProjectFiles[i].Project_ID;
            proj_ds = proj_biz.PopulateList("Project_Arabic_Name like '%" + search_txt + "%'" +
                                        " or Project_Arabic_Discreption like '%" + search_txt + "%'" +
                                        " or Project_Start_Date like '%" + search_txt + "%'" + condition);
        }
        else
            proj_ds = proj_biz.PopulateList(@"Project_Arabic_Name like '%" + search_txt + "%'" +
                                        " or Project_Arabic_Discreption like '%" + search_txt + "%'" +
                                        " or Project_Start_Date like '%" + search_txt + "%'");
        projects_grid.DataSource = proj_ds.Projects;
        ViewState["Projects"] = proj_ds;
        projects_grid.DataBind();
    }
    void Projects_Identical(string search_txt)
    {
        proj_files_ds = proj_files_biz.PopulateList("File_Arabic_Name like '" + search_txt + "'");
        if (proj_files_ds.ProjectFiles.Rows.Count != 0)
        {
            string condition = "";
            for (int i = 0; i < proj_files_ds.ProjectFiles.Rows.Count; i++)
                condition += " or Project_ID = " + proj_files_ds.ProjectFiles[i].Project_ID;
            proj_ds = proj_biz.PopulateList("Project_Arabic_Name like '" + search_txt + "'" +
                                        " or Project_Arabic_Discreption like '" + search_txt + "'" +
                                        " or Project_Start_Date like '" + search_txt + "'" + condition);
        }
        else
            proj_ds = proj_biz.PopulateList(@"Project_Arabic_Name like '" + search_txt + "'" +
                                        " or Project_Arabic_Discreption like '" + search_txt + "'" +
                                        " or Project_Start_Date like '" + search_txt + "'");
        projects_grid.DataSource = proj_ds.Projects;
        ViewState["Projects"] = proj_ds;
        projects_grid.DataBind();
    }
    /////////////--------------------------------------------------///////////////////
    /////////////--------------------------------------------------///////////////////
    void Laws_Start(string search_txt)
    {
        laws_files_ds = laws_files_biz.PopulateList("File_Arabic_Name like '" + search_txt + "%'");
        if (laws_files_ds.LawFiles.Rows.Count != 0)
        {
            string condition = "";
            for (int i = 0; i < laws_files_ds.LawFiles.Rows.Count; i++)
                condition += " or Law_ID = " + laws_files_ds.LawFiles[i].Law_ID;
            laws_ds = laws_biz.PopulateList("Law_Arabic_Name like '" + search_txt + "%'" +
                                        " or Law_Arabic_Title like '" + search_txt + "%'" +
                                        " or Law_Version_Year like '" + search_txt + "%'" + condition);
        }
        else
            laws_ds = laws_biz.PopulateList("Law_Arabic_Name like '" + search_txt + "%'" +
                                        " or Law_Arabic_Title like '" + search_txt + "%'" +
                                        " or Law_Version_Year like '" + search_txt + "%'");
        laws_grid.DataSource = laws_ds.Laws;
        ViewState["Laws"] = laws_ds;
        laws_grid.DataBind();

    }
    void Laws_End(string search_txt)
    {
        laws_files_ds = laws_files_biz.PopulateList("File_Arabic_Name like '%" + search_txt + "'");
        if (laws_files_ds.LawFiles.Rows.Count != 0)
        {
            string condition = "";
            for (int i = 0; i < laws_files_ds.LawFiles.Rows.Count; i++)
                condition += " or Law_ID = " + laws_files_ds.LawFiles[i].Law_ID;
            laws_ds = laws_biz.PopulateList("Law_Arabic_Name like '%" + search_txt + "'" +
                                        " or Law_Arabic_Title like '%" + search_txt + "'" +
                                        " or Law_Version_Year like '%" + search_txt + "'" + condition);
        }
        else
            laws_ds = laws_biz.PopulateList("Law_Arabic_Name like '%" + search_txt + "'" +
                                        " or Law_Arabic_Title like '%" + search_txt + "'" +
                                        " or Law_Version_Year like '%" + search_txt + "'");
        laws_grid.DataSource = laws_ds.Laws;
        ViewState["Laws"] = laws_ds;
        laws_grid.DataBind();
    }
    void Laws_Contain(string search_txt)
    {

        laws_files_ds = laws_files_biz.PopulateList("File_Arabic_Name like '%" + search_txt + "%'");
        if (laws_files_ds.LawFiles.Rows.Count != 0)
        {
            string condition = "";
            for (int i = 0; i < laws_files_ds.LawFiles.Rows.Count; i++)
                condition += " or Law_ID = " + laws_files_ds.LawFiles[i].Law_ID;
            laws_ds = laws_biz.PopulateList("Law_Arabic_Name like '%" + search_txt + "%'" +
                                        " or Law_Arabic_Title like '%" + search_txt + "%'" +
                                        " or Law_Version_Year like '%" + search_txt + "%'" + condition);
        }
        else
            laws_ds = laws_biz.PopulateList("Law_Arabic_Name like '%" + search_txt + "%'" +
                                        " or Law_Arabic_Title like '%" + search_txt + "%'" +
                                        " or Law_Version_Year like '%" + search_txt + "%'");
        laws_grid.DataSource = laws_ds.Laws;
        ViewState["Laws"] = laws_ds;
        laws_grid.DataBind();
    }
    void Laws_Identical(string search_txt)
    {
        laws_files_ds = laws_files_biz.PopulateList("File_Arabic_Name like '" + search_txt + "'");
        if (laws_files_ds.LawFiles.Rows.Count != 0)
        {
            string condition = "";
            for (int i = 0; i < laws_files_ds.LawFiles.Rows.Count; i++)
                condition += " or Law_ID = " + laws_files_ds.LawFiles[i].Law_ID;
            laws_ds = laws_biz.PopulateList("Law_Arabic_Name like '" + search_txt + "'" +
                                        " or Law_Arabic_Title like '" + search_txt + "'" +
                                        " or Law_Version_Year like '" + search_txt + "'" + condition);
        }
        else
            laws_ds = laws_biz.PopulateList("Law_Arabic_Name like '" + search_txt + "'" +
                                        " or Law_Arabic_Title like '" + search_txt + "'" +
                                        " or Law_Version_Year like '" + search_txt + "'");
        laws_grid.DataSource = laws_ds.Laws;
        ViewState["Laws"] = laws_ds;
        laws_grid.DataBind();

    }
    /////////////--------------------------------------------------///////////////////
    /////////////--------------------------------------------------///////////////////
    void Brochures_Start(string search_txt)
    {
        broch_files_ds = broch_files_biz.PopulateList("File_Arabic_Name like '%" + search_txt + "%'");
        if (broch_files_ds.BrochureFiles.Rows.Count != 0)
        {
            string condition = "";
            for (int i = 0; i < broch_files_ds.BrochureFiles.Rows.Count; i++)
                condition += " or Brochure_ID = " + broch_files_ds.BrochureFiles[i].Brochure_ID;
            broch_ds = broch_biz.PopulateList("Brochure_Arabic_Name like '%" + search_txt + "%'" +
                                          " or Brochure_Date like '%" + search_txt + "%'" + condition);
        }
        else
            broch_ds = broch_biz.PopulateList("Brochure_Arabic_Name like '%" + search_txt + "%'" +
                                          " or Brochure_Date like '%" + search_txt + "%'");
        Brochures_grid.DataSource = broch_ds.Brochures;
        ViewState["Brochures"] = broch_ds;
        Brochures_grid.DataBind();

    }
    void Brochures_End(string search_txt)
    {
        broch_files_ds = broch_files_biz.PopulateList("File_Arabic_Name like '%" + search_txt + "%'");
        if (broch_files_ds.BrochureFiles.Rows.Count != 0)
        {
            string condition = "";
            for (int i = 0; i < broch_files_ds.BrochureFiles.Rows.Count; i++)
                condition += " or Brochure_ID = " + broch_files_ds.BrochureFiles[i].Brochure_ID;
            broch_ds = broch_biz.PopulateList("Brochure_Arabic_Name like '%" + search_txt + "%'" +
                                          " or Brochure_Date like '%" + search_txt + "%'" + condition);
        }
        else
            broch_ds = broch_biz.PopulateList("Brochure_Arabic_Name like '%" + search_txt + "%'" +
                                          " or Brochure_Date like '%" + search_txt + "%'");
        Brochures_grid.DataSource = broch_ds.Brochures;
        ViewState["Brochures"] = broch_ds;
        Brochures_grid.DataBind();
    }
    void Brochures_Contain(string search_txt)
    {

        broch_files_ds = broch_files_biz.PopulateList("File_Arabic_Name like '%" + search_txt + "%'");
        if (broch_files_ds.BrochureFiles.Rows.Count != 0)
        {
            string condition = "";
            for (int i = 0; i < broch_files_ds.BrochureFiles.Rows.Count; i++)
                condition += " or Brochure_ID = " + broch_files_ds.BrochureFiles[i].Brochure_ID;
            broch_ds = broch_biz.PopulateList("Brochure_Arabic_Name like '%" + search_txt + "%'" +
                                          " or Brochure_Date like '%" + search_txt + "%'" + condition);
        }
        else
            broch_ds = broch_biz.PopulateList("Brochure_Arabic_Name like '%" + search_txt + "%'" +
                                          " or Brochure_Date like '%" + search_txt + "%'");
        Brochures_grid.DataSource = broch_ds.Brochures;
        ViewState["Brochures"] = broch_ds;
        Brochures_grid.DataBind();
    }
    void Brochures_Identical(string search_txt)
    {
        broch_files_ds = broch_files_biz.PopulateList("File_Arabic_Name like '%" + search_txt + "%'");
        if (broch_files_ds.BrochureFiles.Rows.Count != 0)
        {
            string condition = "";
            for (int i = 0; i < broch_files_ds.BrochureFiles.Rows.Count; i++)
                condition += " or Brochure_ID = " + broch_files_ds.BrochureFiles[i].Brochure_ID;
            broch_ds = broch_biz.PopulateList("Brochure_Arabic_Name like '%" + search_txt + "%'" +
                                          " or Brochure_Date like '%" + search_txt + "%'" + condition);
        }
        else
            broch_ds = broch_biz.PopulateList("Brochure_Arabic_Name like '%" + search_txt + "%'" +
                                          " or Brochure_Date like '%" + search_txt + "%'");
        Brochures_grid.DataSource = broch_ds.Brochures;
        ViewState["Brochures"] = broch_ds;
        Brochures_grid.DataBind();

    }
    /////////////--------------------------------------------------///////////////////
    /////////////--------------------------------------------------///////////////////
    void Cooperations_Start(string search_txt)
    {
        coop_ds  = coop_biz.PopulateList(@"Coop_Arabic_Name like '" + search_txt + "%'" +
                                  " or Coop_Arabic_Content like '" + search_txt + "%'" +
                                  " or Coop_Date like '" + search_txt + "%'");
        cooperation_grid.DataSource = coop_ds.Cooporations;
        ViewState["Cooperations"] = coop_ds;
        cooperation_grid.DataBind();

    }
    void Cooperations_End(string search_txt)
    {
        coop_ds = coop_biz.PopulateList(@"Coop_Arabic_Name like '%" + search_txt + "'" +
                                  " or Coop_Arabic_Content like '%" + search_txt + "'" +
                                  " or Coop_Date like '%" + search_txt + "'");
        cooperation_grid.DataSource = coop_ds.Cooporations;
        ViewState["Cooperations"] = coop_ds;
        cooperation_grid.DataBind();
    }
    void Cooperations_Contain(string search_txt)
    {

        coop_ds = coop_biz.PopulateList(@"Coop_Arabic_Name like '%" + search_txt + "%'" +
                                  " or Coop_Arabic_Content like '%" + search_txt + "%'" +
                                  " or Coop_Date like '%" + search_txt + "%'");
        cooperation_grid.DataSource = coop_ds.Cooporations;
        ViewState["Cooperations"] = coop_ds;
        cooperation_grid.DataBind();
    }
    void Cooperations_Identical(string search_txt)
    {
        coop_ds = coop_biz.PopulateList(@"Coop_Arabic_Name like '" + search_txt + "'" +
                                  " or Coop_Arabic_Content like '" + search_txt + "'" +
                                  " or Coop_Date like '" + search_txt + "'");
        cooperation_grid.DataSource = coop_ds.Cooporations;
        ViewState["Cooperations"] = coop_ds;
        cooperation_grid.DataBind();

    }
    protected void book_grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        book_grid.PageIndex = e.NewPageIndex;
    }
    protected void Cooperation_Click(object sender, EventArgs e)
    {
        coop_ds = (CooporationsDS)ViewState["Cooperations"];
        int Index = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        Response.Redirect("Cooperation.aspx?id=" + coop_ds.Cooporations[Index].Coop_ID + "&txt=" + txtSearch.Text );

    }
    protected void Project_Click(object sender, EventArgs e)
    {
        proj_ds = (ProjectsDS)ViewState["Projects"];
        int Index = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        Response.Redirect("Projects.aspx?id=" + proj_ds.Projects[Index].Project_ID);

    }
    protected void Brochures_Click(object sender, EventArgs e)
    {
        broch_ds = (BrochuresDS)ViewState["Brochures"];
        int Index = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        Response.Redirect("Publications.aspx?id=" + broch_ds.Brochures[Index].Brochure_ID);

    }
    protected void Services_Click(object sender, EventArgs e)
    {
        serv_ds = (ServicesDS)ViewState["Services"];
        int Index = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        Response.Redirect("Service.aspx?id=" + serv_ds.Services[Index].Service_ID + "&txt=aaaaaaaaaaaaaaaaaaaa");
    }

    protected void Laws_Click(object sender, EventArgs e)
    {
        laws_ds = (LawsDS)ViewState["Laws"];
        int Index = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        Response.Redirect("Laws.aspx?id=" + laws_ds.Laws[Index].Law_ID + "&txt=" + txtSearch.Text);
    }
    protected void Search_Click(object sender, EventArgs e)
    {
        switch ( int.Parse ( DDLWhere.SelectedValue) )
        {
            case 0:   //all
                if (int.Parse(DDLType.SelectedValue) == 0)          //  Contane
                {
                    Book_Contain(txtSearch.Text);
                    Projects_Contain(txtSearch.Text);
                    Brochures_Contain(txtSearch.Text);
                    Services_Contain(txtSearch.Text);
                    Laws_Contain(txtSearch.Text);
                    Cooperations_Contain(txtSearch.Text);
                }
               
                else if (int.Parse(DDLType.SelectedValue) == 1)      // start
                {
                    Book_Start(txtSearch.Text);
                    Projects_Start(txtSearch.Text);
                    Brochures_Start(txtSearch.Text);
                    Services_Start(txtSearch.Text);
                    Laws_Start(txtSearch.Text);
                    Cooperations_Start(txtSearch.Text);
                }
                else if (int.Parse(DDLType.SelectedValue) == 2)      // end 
                {
                    Book_End(txtSearch.Text);
                    Projects_End(txtSearch.Text);
                    Brochures_End(txtSearch.Text);
                    Services_End(txtSearch.Text);
                    Laws_End(txtSearch.Text);
                    Cooperations_End(txtSearch.Text);
                }
               
                else if (int.Parse(DDLType.SelectedValue) == 3)      // identical
                {
                    Book_Identical(txtSearch.Text);
                    Projects_Identical(txtSearch.Text);
                    Brochures_Identical(txtSearch.Text);
                    Services_Identical(txtSearch.Text);
                    Laws_Identical(txtSearch.Text);
                    Cooperations_Identical(txtSearch.Text);
                }
                return;
            case 1:   // library
                if (int.Parse ( DDLType.SelectedValue )== 0)          //  Contane
                    Book_Contain(txtSearch.Text );
                else if (int.Parse (DDLType.SelectedValue )== 1)      // start
                    Book_Start(txtSearch.Text );
                else if (int.Parse (DDLType.SelectedValue )== 2)      // end 
                    Book_End(txtSearch.Text);
                else if (int.Parse (DDLType.SelectedValue )== 3)      // identical
                    Book_Identical(txtSearch.Text);
                return;
            case 2:   //projects
                if (int.Parse ( DDLType.SelectedValue )== 0)          //  Contane
                    Projects_Contain(txtSearch.Text);
                else if (int.Parse (DDLType.SelectedValue )== 1)      // start
                    Projects_Start(txtSearch.Text);
                else if (int.Parse (DDLType.SelectedValue )== 2)      // end 
                    Projects_End(txtSearch.Text);
                else if (int.Parse (DDLType.SelectedValue )== 3)      // identical
                    Projects_Identical(txtSearch.Text);
                return;
            case 3:   //brochures
                if (int.Parse ( DDLType.SelectedValue )== 0)          //  Contane
                    Brochures_Contain(txtSearch.Text);
                else if (int.Parse (DDLType.SelectedValue )== 1)      // start
                    Brochures_Start(txtSearch.Text);
                else if (int.Parse (DDLType.SelectedValue )== 2)      // end 
                    Brochures_End(txtSearch.Text);
                else if (int.Parse (DDLType.SelectedValue )== 3)      // identical
                    Brochures_Identical(txtSearch.Text);
                return;
            case 4:  //serivces
                if (int.Parse ( DDLType.SelectedValue )== 0)          //  Contane
                    Services_Contain(txtSearch.Text);
                else if (int.Parse (DDLType.SelectedValue )== 1)      // start
                    Services_Start(txtSearch.Text);
                else if (int.Parse (DDLType.SelectedValue )== 2)      // end 
                    Services_End(txtSearch.Text);
                else if (int.Parse (DDLType.SelectedValue )== 3)      // identical
                    Services_Identical(txtSearch.Text);
                return;
            case 5:  // laws
                if (int.Parse ( DDLType.SelectedValue )== 0)          //  Contane
                    Laws_Contain(txtSearch.Text);
                else if (int.Parse (DDLType.SelectedValue )== 1)      // start
                    Laws_Start(txtSearch.Text);
                else if (int.Parse (DDLType.SelectedValue )== 2)      // end 
                    Laws_End(txtSearch.Text);
                else if (int.Parse (DDLType.SelectedValue )== 3)      // identical
                    Laws_Identical(txtSearch.Text);
                return;
            case 6:  // cooperation
                if (int.Parse ( DDLType.SelectedValue )== 0)          //  Contane
                    Cooperations_Contain(txtSearch.Text);
                else if (int.Parse (DDLType.SelectedValue )== 1)      // start
                    Cooperations_Start(txtSearch.Text);
                else if (int.Parse (DDLType.SelectedValue )== 2)      // end 
                    Cooperations_End(txtSearch.Text);
                else if (int.Parse (DDLType.SelectedValue )== 3)      // identical
                    Cooperations_Identical(txtSearch.Text);
                return;
            default:
                return;
        }

    }
}
