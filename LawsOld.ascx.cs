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
using DataAccess;
using Common;
using Businesslayer;

public partial class WebUserControl : System.Web.UI.UserControl
{
    LawsDS laws_ds = new LawsDS();
    LawsBiz laws_biz = new LawsBiz();

    LawFilesDS files_ds = new LawFilesDS();
    LawFilesBiz files_biz = new LawFilesBiz();

    DataTable Law_Year_DT = new DataTable();
    DataTable Law_Owners = new DataTable();

 
    //string WLawDec ; 
    //string ALawDec ;
    //string LawDec  ;

    string StartTag = "<span style='background-color: #ffff66'>", EndTag = "</span>";
    // string StartTag = "<b>", EndTag = "</b>";
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
            return "";

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

    public string Law_Owner(string Org_ID)
    {
        //decimal num = decimal.Parse(Org_ID);
        OrganizationsDS org_ds = new OrganizationsDS();
        OrganizationsBiz org_biz = new OrganizationsBiz();
        org_ds = org_biz.PopulateList("Org_ID = " + Org_ID);
        if (org_ds.Organizations.Count == 0)
            return "";
        else
            return org_ds.Organizations[0].ORG_Arabic_Name;


    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            WLawDec.Text = " WHERE  (IsLegislation = 0)"; //Law
            ALawDec.Text =  " and IsLegislation = 0 "; //Law
            LawDec.Text = "Low";
            //test.Text = LawDec.Text;
            YearL.Text = " Óäå ÇÕÏÇÑ ÇáÞÇäæä     ";
            FillComp();
            test.Text = test.Text + " 2 " + LawDec.Text;
        }
        if (LawDec.Text == "Low")
            FillGrid();
        else
            FillGridD();
        //test.Text = test.Text + " 3 " + LawDec.Text;
    }
    void FillGrid()
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
            laws_ds = laws_biz.PopulateList("Law_ID = " + Request.QueryString["ID"]);
            if (laws_ds.Laws.Count == 0)
                return;
            int Index = 0;
            Label_Laws_Title.Text = Operations.Key_Search_Color(laws_ds.Laws[Index].Law_Arabic_Title, txt);
            Label_Laws_date.Text = Operations.Key_Search_Color(laws_ds.Laws[Index].Law_Version_Year, txt);
            Label_Laws_Name.Text = Operations.Key_Search_Color(laws_ds.Laws[Index].Law_Arabic_Name, txt);
            Label_Laws_date2.Text = Operations.Key_Search_Color(laws_ds.Laws[Index].Release_Date.ToString(), txt);
            Label_Laws_date3.Text = Operations.Key_Search_Color(laws_ds.Laws[Index].Publish_Date.ToString(), txt);
            //Label_Laws_D.Text = Operations.Key_Search_Color(laws_ds.Laws[Index].Law_Arabic_Name, txt);
            if (Operations.Key_Search_Color(laws_ds.Laws[Index].Law_Type.ToString(), txt) == "1")
            {
                Label_Laws_Cancel.Text = Operations.Key_Search_Color(laws_ds.Laws[Index].Law_Arabic_Name, txt);
                Label_Laws_Cancel.Visible = true;
                Label18.Visible = true;
            }
            else
            {
                Label_Laws_Cancel.Visible = false;
                Label19.Visible = false;
            }
            //test.Text = "grad";
            return;
        }
        laws_ds = laws_biz.PopulateList(" ORG_ID = " + DDLDepart.SelectedValue +  " and Law_Version_Year = " + DDLYear.SelectedValue + ALawDec.Text); //Low
        laws_grid.DataSource = laws_ds.Laws;
        laws_grid.DataBind();
        MultiView1.ActiveViewIndex = 0;
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //laws_ds = (LawsDS)ViewState["laws"];
        laws_ds = laws_biz.PopulateList(" ORG_ID = " + DDLDepart.SelectedValue +  " and Law_Version_Year = " + DDLYear.SelectedValue + ALawDec.Text);
        int Index = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        Label_Laws_date.Text = laws_ds.Laws[Index].Law_Version_Year;
        Label_Laws_Name.Text = laws_ds.Laws[Index].Law_Arabic_Name;
        Label_Laws_Title.Text = laws_ds.Laws[Index].Law_Arabic_Title;


        Label_Laws_date2.Text = laws_ds.Laws[Index].Release_Date.ToString();
        Label_Laws_date3.Text = laws_ds.Laws[Index].Publish_Date.ToString();
        //Label_Decs_D.Text =  ;
        if (laws_ds.Laws[Index].Law_Type)
        {
            Label_Laws_Cancel.Text = laws_ds.Laws[Index].Law_CancelationLawNumbe.ToString();
            Label_Laws_Cancel.Visible = true;
            Label18.Visible = true;
            //test.Text = "law" + laws_ds.Laws[Index].Law_Type.ToString() + "yes";
        }
        else
        {
            Label_Laws_Cancel.Visible = false;
            Label18.Visible = false;
            //test.Text = "law" + laws_ds.Laws[Index].Law_Type.ToString() + "no";
        }

        files_ds = files_biz.PopulateList("Law_ID = " + laws_ds.Laws[Index].Law_ID);
        Repeater1.DataSource = files_ds.LawFiles;
        Repeater1.DataBind();
        MultiView1.ActiveViewIndex = 1;

    }
    //maryam

    void FillGridD()
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
            laws_ds = laws_biz.PopulateList("Law_ID = " + Request.QueryString["ID"]);
            if (laws_ds.Laws.Count == 0)
                return;
            int Index = 0;
            Label_Decs_Title.Text = Operations.Key_Search_Color(laws_ds.Laws[Index].Law_Arabic_Title, txt);
            Label_Decs_date.Text = Operations.Key_Search_Color(laws_ds.Laws[Index].Law_Version_Year, txt);
            Label_Decs_Name.Text = Operations.Key_Search_Color(laws_ds.Laws[Index].Law_Arabic_Name, txt);
            Label_Decs_date2.Text = Operations.Key_Search_Color(laws_ds.Laws[Index].Release_Date.ToString(), txt);
            Label_Decs_date3.Text = Operations.Key_Search_Color(laws_ds.Laws[Index].Publish_Date.ToString(), txt);
            //Label_Decs_D.Text = Operations.Key_Search_Color(laws_ds.Laws[Index].Law_Arabic_Name, txt);
            if (Operations.Key_Search_Color(laws_ds.Laws[Index].Law_Type.ToString(), txt) == "1")
            {
                Label_Decs_Cancel.Text = Operations.Key_Search_Color(laws_ds.Laws[Index].Law_Arabic_Name, txt);
                Label_Decs_Cancel.Visible = true;
                Label19.Visible = true;
            }
            else
            {
                Label_Decs_Cancel.Visible = false;
                Label19.Visible = false;
            }
            test.Text = "gradf";
            return;
        }
        laws_ds = laws_biz.PopulateList(" ORG_ID = " + DDLDepart.SelectedValue +  " and Law_Version_Year = " + DDLYear.SelectedValue + ALawDec.Text); //Low
        decs_grid.DataSource = laws_ds.Laws;
        //laws_ds = Populate("SELECT * FROM [GOVS].[dbo].[LawView] where ORG_ID = " + DDLDepart.SelectedValue + " and Law_Version_Year = " + DDLYear.SelectedValue + ALawDec.Text);
        
        decs_grid.DataBind();
        //test.Text = test.Text + " ORG_ID = " + DDLDepart.SelectedValue +  " and Law_Version_Year = " + DDLYear.SelectedValue + ALawDec.Text;
        //test.Visible = true;
        MultiView1.ActiveViewIndex = 2;
    }
    protected void LinkButtonD_Click(object sender, EventArgs e)
    {
        //laws_ds = (LawsDS)ViewState["laws"];
        laws_ds = laws_biz.PopulateList(" ORG_ID = " + DDLDepart.SelectedValue +  " and Law_Version_Year = " + DDLYear.SelectedValue + ALawDec.Text);
        int Index = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        Label_Decs_date.Text = laws_ds.Laws[Index].Law_Version_Year;
        Label_Decs_Name.Text = laws_ds.Laws[Index].Law_Arabic_Name;
        Label_Decs_Title.Text = laws_ds.Laws[Index].Law_Arabic_Title;

        Label_Decs_date2.Text = laws_ds.Laws[Index].Release_Date.ToString();
        Label_Decs_date3.Text = laws_ds.Laws[Index].Publish_Date.ToString();
        //Label_Decs_D.Text = ;
        if (laws_ds.Laws[Index].Law_Type)
        {
            Label_Decs_Cancel.Text = laws_ds.Laws[Index].Law_CancelationLawNumbe.ToString();
            Label_Decs_Cancel.Visible = true;
            Label19.Visible = true;
        }
        else
        {
            Label_Decs_Cancel.Visible = false;
            Label19.Visible = false;
        }

        files_ds = files_biz.PopulateList("Law_ID = " + laws_ds.Laws[Index].Law_ID);
        Repeater2.DataSource = files_ds.LawFiles;
        Repeater2.DataBind();
        MultiView1.ActiveViewIndex = 3;

    }

    void FillComp()
    {
        BaseDAL.ConnectionString = ConfigurationManager.ConnectionStrings["GovsFEConnString"].ToString();
        Law_Year_DT = Populate("SELECT  Law_Version_Year FROM [GOVS].[dbo].[Laws]" + WLawDec.Text);

        DDLYear.DataTextField = "Law_Version_Year";
        DDLYear.DataValueField = "Law_Version_Year";
        DDLYear.DataSource = Law_Year_DT;
        DDLYear.DataBind();


        ////////////////////////////////////////////////////////////////////////////////////
        //maryam Law_Owners = Populate("SELECT   [ORG_ID] as ID  FROM [GOVS].[dbo].[Laws]" + WLawDec.Text);
        Law_Owners = Populate("SELECT   [ORG_ID] as ID  FROM [GOVS].[dbo].[LawView]" + WLawDec.Text);
        Law_Owners.Columns.Add("Place_Name");
        foreach (DataRow dr in Law_Owners.Rows)
            dr["Place_Name"] = Law_Owner(dr["ID"].ToString());
        //test.Text = "SELECT   [ORG_ID] as ID  FROM [GOVS].[dbo].[LawView]" + WLawDec.Text + "   "; 
        //DataRow datarow = book_places.NewRow();
        //datarow["Place_Name"] = "ßá ÇáãßÊÈÇÊ";
        //datarow["ID"] = "0";
        //book_places.Rows.Add(datarow);

        DDLDepart.DataTextField = "Place_Name";
        DDLDepart.DataValueField = "ID";
        DDLDepart.DataSource = Law_Owners;
        DDLDepart.DataBind();
    }
    protected void Lows_Click(object sender, EventArgs e)
    {
        WLawDec.Text = " WHERE  (IsLegislation = 0)"; //Law
        ALawDec.Text =  " and IsLegislation = 0 "; //Law
        LawDec.Text = "Low";
        YearL.Text = "Óäå ÇÕÏÇÑ ÇáÞÇäæä    ";
        FillComp();
        FillGrid();
    }
    protected void Decisions_Click(object sender, EventArgs e)
    {
        WLawDec.Text = " WHERE  (IsLegislation = 1)"; //Dec
        ALawDec.Text =  " and IsLegislation = 1 "; //Dec
        LawDec.Text = "Dec";
        YearL.Text = "Óäå ÇÕÏÇÑ ÇáÞÑÇÑ     ";
        FillComp();
        FillGridD();
    }
    //maryam
    public string FilePath()
    {

        return "~/GovsFiles/ORG_" + Session["Org_ID"] + "_Files/Laws/";
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
