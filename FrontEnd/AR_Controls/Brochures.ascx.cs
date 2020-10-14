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

public partial class Brochures : System.Web.UI.UserControl
{
    BrochuresDS broch_ds = new BrochuresDS();
    BrochuresBiz broch_biz = new BrochuresBiz();

    BrochureFilesDS files_ds = new BrochureFilesDS();
    BrochureFilesBiz files_biz = new BrochureFilesBiz();

    BrochuresCategoryDS broch_cat_ds = new BrochuresCategoryDS();
    BrochuresCategoryBiz broch_cat_biz = new BrochuresCategoryBiz();

    OrganizationsDS  org_ds = new OrganizationsDS();
    OrganizationsBiz org_biz = new OrganizationsBiz();

    DataTable owners = new DataTable();
    string StartTag = "<span style='background-color: #ffff66'>", EndTag = "</span>";

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
         if (!IsPostBack)
        {
      
            BaseDAL.ConnectionString = ConfigurationManager.ConnectionStrings["GovsFEConnString"].ToString();

            broch_cat_ds  = broch_cat_biz.PopulateList("");

            //BrochuresCategoryDS.BrochuresCategoryRow BrochuresCatRow = broch_cat_ds.BrochuresCategory.NewBrochuresCategoryRow();
            //BrochuresCatRow.Cat_Arabic_Name = "ßá ÇáÊÕäíÝÇÊ";
            //BrochuresCatRow.Cat_English_Name = "All Category";
            //broch_cat_ds.BrochuresCategory.AddBrochuresCategoryRow(BrochuresCatRow);
            //broch_cat_ds = broch_cat_biz.InsertBrochuresCategory(broch_cat_ds);

            broch_cat_ds.BrochuresCategory.AddBrochuresCategoryRow("ßá ÇáÊÕäíÝÇÊ", "All Category");
            
            DDLCategory.DataTextField = "Cat_Arabic_Name";
            DDLCategory.DataValueField = "Cat_ID";   
            DDLCategory.DataSource = broch_cat_ds.BrochuresCategory;
            DDLCategory.DataBind();
            //DDLCategory.SelectedValue= 
            //////////////////////////////////////////////////////////////////////////////////

            // Mar 4/2014 owners = Populate("SELECT   [Brochure_Existance_Place] as Place  FROM [GOVS].[dbo].[Brochures] ");
                
            owners = Populate("select DISTINCT (CAST([Brochure_Existance_Place] AS NVARCHAR(4000))) as place, org_id  FROM [GOVS].[dbo].[Brochures] ");
            //owners.Columns.Add("Owner_Name");
            //foreach (DataRow dr in owners.Rows)
            //    dr["Owner_Name"] = Brochure_Owner(dr["Place"].ToString());
            DataRow row = owners.NewRow();
            row["Place"] = "ßá ÇáÇãÇßä";
            owners.Rows.Add(row);

            DDLPLace.DataTextField = "Place";
            // 5 /2014 DDLPLace.DataValueField = "Place";
            DDLPLace.DataValueField = "org_id";
            DDLPLace.DataSource = owners;
            DDLPLace.DataBind();
            ////////////////////////////////////////////////////////////////////////////////////

            //files_ds = files_biz.PopulateList("Brochure_ID = " + broch_ds.Brochures[Index].Brochure_ID);
            //Label_Brochures_Date.Text =Operations.Key_Search_Color(broch_ds.Brochures[Index].Brochure_Date.ToLongDateString(),txt );
            //Label_Brochures_Name.Text =Operations.Key_Search_Color(broch_ds.Brochures[Index].Brochure_Arabic_Name, txt);
            //Repeater1.DataSource = files_ds.BrochureFiles;
            //Repeater1.DataBind();
            //MultiView1.ActiveViewIndex = 1;
      

        }
        FillGrid();
        
    }

    void FillGrid()
    {
        if (Request.QueryString.Count != 0)
        {
            broch_ds = broch_biz.PopulateList("Brochure_ID = " + Request.QueryString["ID"]);
            int Index = 0;
            files_ds = files_biz.PopulateList("Brochure_ID = " + broch_ds.Brochures[Index].Brochure_ID);
            Label_Brochures_Date.Text = broch_ds.Brochures[Index].Brochure_Date.ToShortDateString();
            Label_Brochures_Name.Text = broch_ds.Brochures[Index].Brochure_Arabic_Name;
            Label_Brochures_place.Text = broch_ds.Brochures[Index].Brochure_Existance_Place;
            if (broch_ds.Brochures[Index].Brochure_Type)
                Label_Brochures_Price.Text = "ãÌÇäí";
            else
                Label_Brochures_Price.Text = broch_ds.Brochures[Index].Brochure_Cost;
            DDLCategory.SelectedValue = broch_ds.Brochures[Index].Cat_ID.ToString ();
            DDLPLace.SelectedValue = broch_ds.Brochures[Index].Brochure_Existance_Place.ToString();
            Repeater1.DataSource = files_ds.BrochureFiles;
            Repeater1.DataBind();
            MultiView1.ActiveViewIndex = 1;
           
            return;
        }
       
        if (DDLCategory.SelectedIndex == DDLCategory.Items.Count - 1 && DDLPLace.SelectedIndex == DDLPLace.Items.Count - 1) // all pub
            broch_ds  = broch_biz .PopulateList("");
        if (DDLCategory.SelectedIndex != DDLCategory.Items.Count - 1 && DDLPLace.SelectedIndex == DDLPLace.Items.Count - 1) // all pub for CatID
            broch_ds = broch_biz.PopulateList("Cat_ID  = " + DDLCategory.SelectedValue);
        if (DDLCategory.SelectedIndex == DDLCategory.Items.Count - 1 && DDLPLace.SelectedIndex != DDLPLace.Items.Count - 1)// all pub for Place
            // 5 /2014   broch_ds = broch_biz.PopulateList("Brochure_Existance_Place like '%" + DDLPLace.SelectedValue+"%'");
            broch_ds = broch_biz.PopulateList("org_id = " + DDLPLace.SelectedValue + " ");
        if (DDLCategory.SelectedIndex != DDLCategory.Items.Count - 1 && DDLPLace.SelectedIndex != DDLPLace.Items.Count - 1)
          // 5 /2014  broch_ds = broch_biz.PopulateList("Brochure_Existance_Place like '%" + DDLPLace.SelectedValue + "%'" + "  and Cat_ID  = " + DDLCategory.SelectedValue);
            broch_ds = broch_biz.PopulateList("org_id =" + DDLPLace.SelectedValue + " " + "  and Cat_ID  = " + DDLCategory.SelectedValue);

       
        //broch_ds = broch_biz.PopulateList(" Cat_ID  = " + DDLCategory.SelectedValue);
        //files_ds = files_biz.PopulateList("Brochure_ID = " + broch_ds.Brochures[Index].Brochure_ID);
        //if (broch_ds.Brochures[Index].Brochure_Type)
        //    Label_Brochures_Price.Text = "ãÌÇäí";
        //else
        //    Label_Brochures_Price.Text = broch_ds.Brochures[Index].Brochure_Cost;
        //Repeater1.DataSource = files_ds.BrochureFiles;
        //Repeater1.DataBind();
        Brochures_grid.DataSource = broch_ds.Brochures;
        Brochures_grid.DataBind();
        MultiView1.ActiveViewIndex = 0;
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        int Index = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        //Mtext.Visible = true;
        //Mtext.Text = "Cat_ID  = " + DDLCategory.SelectedValue + "index " + Index.ToString() + "--" + "Brochure_ID = " + broch_ds.Brochures[Index].Brochure_ID;


        //broch_ds = (BrochuresDS )ViewState["laws"];
        //if (DDLCategory.SelectedIndex == DDLCategory.Items.Count - 1 && DDLPLace.SelectedIndex == DDLPLace.Items.Count - 1)
        //    broch_ds = broch_biz.PopulateList("");
        //if (DDLCategory.SelectedIndex != DDLCategory.Items.Count - 1 && DDLPLace.SelectedIndex == DDLPLace.Items.Count - 1)
        //    broch_ds = broch_biz.PopulateList("Cat_ID  = " + DDLCategory.SelectedValue);
        //if (DDLCategory.SelectedIndex == DDLCategory.Items.Count - 1 && DDLPLace.SelectedIndex != DDLPLace.Items.Count - 1)
        //    broch_ds = broch_biz.PopulateList("Brochure_Existance_Place like '%" + DDLPLace.SelectedValue + "%'");
        //if (DDLCategory.SelectedIndex != DDLCategory.Items.Count - 1 && DDLPLace.SelectedIndex != DDLPLace.Items.Count - 1)
        //    broch_ds = broch_biz.PopulateList("Brochure_Existance_Place like '%" + DDLPLace.SelectedValue + "%'" + "  and Cat_ID  = " + DDLCategory.SelectedValue);

    

        files_ds = files_biz.PopulateList("Brochure_ID = " + broch_ds.Brochures[Index].Brochure_ID);
        Label_Brochures_Date.Text = broch_ds.Brochures[Index].Brochure_Date.ToShortDateString();
        Label_Brochures_Name.Text = broch_ds.Brochures[Index].Brochure_Arabic_Name;
        Label_Brochures_place.Text = broch_ds.Brochures[Index].Brochure_Existance_Place;
        if (broch_ds.Brochures[Index].Brochure_Type)
            Label_Brochures_Price.Text = "ãÌÇäí";
        else
            Label_Brochures_Price.Text = broch_ds.Brochures[Index].Brochure_Cost;
        Repeater1.DataSource = files_ds.BrochureFiles;
        Repeater1.DataBind();
        MultiView1.ActiveViewIndex = 1;


    }
    public string Brochure_Owner(string Org_ID)
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
    public string FilePath()
    {

        //return "../../GovsFiles/ORG_" + Session["Org_ID"] + "_Files/Brochures/";
        return "../../GovsFiles/ORG_2_Files/Brochures/";
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

    protected void DDLPLace_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] != null)
            Response.Redirect("Publications.aspx");
    }
    protected void DDLCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] != null)
            Response.Redirect("Publications.aspx");
    }
}
