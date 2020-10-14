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
using System.Text.RegularExpressions;
using DataAccess;
using Common;
using Businesslayer;
using System.Data.SqlClient;


public partial class Services : System.Web.UI.UserControl
{
    ServicesDS serv_ds = new ServicesDS();
    ServicesBiz serv_biz = new ServicesBiz();

    ServiceFilesBiz files_biz = new ServiceFilesBiz();
    ServiceFilesDS files_ds = new ServiceFilesDS();

    ServiceTypeDS type_ds = new ServiceTypeDS();
    ServiceTypeBiz type_biz = new ServiceTypeBiz();

    OrganizationsDS org_ds = new OrganizationsDS();
    OrganizationsBiz org_biz = new OrganizationsBiz();

    string StartTag = "<span style='background-color: #ffff66'>", EndTag = "</span>";
    string build_string(string text, string key)
    {
       
        Regex reg = new Regex(key);
        return reg.Replace(text, StartTag + key + EndTag);

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        BaseDAL.ConnectionString = ConfigurationManager.ConnectionStrings["GovsFEConnString"].ToString();
        if (Request.QueryString.Count != 0)
        {

            int temp;
            string txt;
            //FillDLL_Services_Type(sender, e);
            if (string.IsNullOrEmpty(Request.QueryString["ID"]))
                return;
            if (string.IsNullOrEmpty(Request.QueryString["txt"]))
                txt = "";
            else
                txt = Request.QueryString["txt"];
                
            if (!int.TryParse(Request.QueryString["ID"], out temp))
                return;
            serv_ds = serv_biz.PopulateList("Service_ID = " + Request.QueryString["ID"]);
            if (serv_ds.Services .Count == 0)
                return;

            Label_Service_Procedures.Text = Operations.Key_Search_Color(serv_ds.Services[0].Service_English_Procedures.Replace("\n", "<br/>"), txt);
            Label_Services_Conditions.Text = Operations.Key_Search_Color(serv_ds.Services[0].Service_English_Conditions.Replace("\n", "<br/>"), txt);
            Label_Services_Name.Text = Operations.Key_Search_Color(serv_ds.Services[0].Service_English_Name, txt);

            //MAr 3 /2012 org_ds = org_biz.PopulateList("Org_ID = " + serv_ds.Services[0].ORG_ID);
            org_ds = org_biz.PopulateList("");
            if (org_ds.Organizations.Count == 0)
                Label_Services_Provider.Text = "";
            else
                Label_Services_Provider.Text = Operations.Key_Search_Color(org_ds.Organizations[0].Org_English_Name , txt);
            files_ds = files_biz.PopulateList("Service_ID = " + serv_ds.Services[0].Service_ID);

            ////////////////////// DDL ////////////////////////////////////
            type_ds = type_biz.PopulateList("");
            DDL_services.DataTextField = "Service_Type_English_Name";
            DDL_services.DataValueField = "Type_ID";
         
            DDL_services.DataSource = type_ds.ServiceType;
            DDL_services.DataBind();
            DDL_services.SelectedValue = serv_ds.Services[0].Type_ID.ToString ();
            ///////////////////////////////////////////////////////////////////////////
            // maryam Repeater1.DataSource = files_ds.ServiceFiles;
            DataTable dtm = new DataTable();
         //   dtm = Populate("SELECT * FROM [GOVS].[dbo].[ServiceFiles] INNER JOIN [GOVS].[dbo].[Services] ON [GOVS].[dbo].[ServiceFiles].Service_ID = [GOVS].[dbo].[Services].Service_ID");
            dtm = Populate("SELECT * FROM [GOVS].[dbo].[ServiceFiles] INNER JOIN [GOVS].[dbo].[Services] ON [GOVS].[dbo].[ServiceFiles].Service_ID = [GOVS].[dbo].[Services].Service_ID WHERE [GOVS].[dbo].[ServiceFiles].Service_ID = " + Request.QueryString["ID"]);

            Repeater1.DataSource = dtm; 
            Repeater1.DataBind();
    
            MultiView1.ActiveViewIndex = 1;
            return;

        }
        if (!IsPostBack)
        {
            FillDLL_Services_Type(sender, e);
        }

    }

    private void FillDLL_Services_Type(object sender, EventArgs e)
    {
        type_ds = type_biz.PopulateList("");
        DDL_services.DataTextField = "Service_Type_English_Name";
        DDL_services.DataValueField = "Type_ID";
        DDL_services.DataSource = type_ds.ServiceType;
        DDL_services.DataBind();
        DDL_services_SelectedIndexChanged(sender, e);
    }

    private void FillGrid()
    {
        // Maryam 9/2011   serv_ds = serv_biz.PopulateList("Org_ID = " + Session["Org_ID"] + "and Type_ID = " + DDL_services.SelectedValue );
        serv_ds = serv_biz.PopulateList("Type_ID = " + DDL_services.SelectedValue);
        services_grid.DataSource = serv_ds.Services;
        services_grid.DataBind();
        //ViewState["services"] = serv_ds;
        MultiView1.ActiveViewIndex = 0;
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //serv_ds = (ServicesDS )ViewState["services"];
        // Maryam 9/2011   serv_ds = serv_biz.PopulateList("Org_ID = " + Session["Org_ID"] + "and Type_ID = " + DDL_services.SelectedValue);
        serv_ds = serv_biz.PopulateList("Type_ID = " + DDL_services.SelectedValue);
        int Index = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        org_ds = org_biz.PopulateList("Org_ID = "+ serv_ds.Services[Index].ORG_ID );
        Label_Service_Procedures.Text = serv_ds.Services[Index].Service_English_Procedures.Replace("\n", "<br/>");
        Label_Services_Conditions.Text = serv_ds.Services[Index].Service_English_Conditions.Replace("\n", "<br/>");
        Label_Services_Name.Text = serv_ds.Services[Index].Service_English_Name;
        Label_Services_Provider.Text = org_ds.Organizations[0].Org_English_Name;

        //maryam files_ds = files_biz.PopulateList("Service_ID = " + serv_ds.Services[Index].Service_ID);
        //  Repeater1.DataSource = files_ds.ServiceFiles;

        DataTable dtm = new DataTable();
        dtm = Populate("SELECT * FROM [GOVS].[dbo].[ServiceFiles] INNER JOIN [GOVS].[dbo].[Services] ON [GOVS].[dbo].[ServiceFiles].Service_ID = [GOVS].[dbo].[Services].Service_ID WHERE [GOVS].[dbo].[ServiceFiles].Service_ID = " + serv_ds.Services[Index].Service_ID);
        Repeater1.DataSource = dtm;       
       
       
        Repeater1.DataBind();
    
        MultiView1.ActiveViewIndex = 1;

    }
    public string FilePath()
    {
        // Maryam 9/2011 
        return "../../GovsFiles/ORG_"; // +Session["Org_ID"].ToString() + "_Files/Services/";


    }
    protected void DDL_services_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(Request.QueryString["ID"]!=null)
            Response.Redirect("Service.aspx");

        FillGrid();
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
}
