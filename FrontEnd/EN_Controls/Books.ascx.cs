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
using Businesslayer;
using Common;
using DataAccess;
using System.Data.SqlClient ;

public partial class Books : System.Web.UI.UserControl
{
    BooksBiz books_biz = new BooksBiz();
    BooksDS book_ds = new BooksDS();

    Books_CategoryDS book_cat_ds = new Books_CategoryDS();
    Books_CategoryBiz book_cat_biz = new Books_CategoryBiz();

    DataTable book_places = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BaseDAL.ConnectionString = ConfigurationManager.ConnectionStrings["GovsFEConnString"].ToString();
            
            book_cat_ds = book_cat_biz.PopulateList("");
            
            //Books_CategoryDS.Books_CategoryRow bookCatRow = book_cat_ds.Books_Category.NewBooks_CategoryRow();
            //bookCatRow.Category_Name_Ar = "ßá ÇáÊÕäíÝÇÊ";
            //bookCatRow.Category_Name_En = "All Category";
            //book_cat_ds.Books_Category.AddBooks_CategoryRow(bookCatRow);
            //book_cat_ds = book_cat_biz.InsertBooks_Category(book_cat_ds);
            
            book_cat_ds.Books_Category.AddBooks_CategoryRow("All Category", "All Category");
            //book_cat_ds.Books_Category.AddBooks_CategoryRow

            DDLCategory.DataTextField = "Category_Name_En";
            DDLCategory.DataValueField = "Category_ID";
            DDLCategory.DataSource = book_cat_ds.Books_Category;
            DDLCategory.DataBind();

            // Mar 4/2014 book_places = Populate("SELECT   [ORG_ID] as ID  FROM [GOVS].[dbo].[Books]");
            book_places = Populate("SELECT DISTINCT [ORG_ID] as ID  FROM [GOVS].[dbo].[Books] ");
            
            //book_places = Populate("SELECT   [ORG_ID] as ID  FROM [GOVS].[dbo].[Books]");
            book_places.Columns.Add("Place_Name");
            foreach (DataRow dr in book_places.Rows)
                dr["Place_Name"] = book_place(dr["ID"].ToString());

            DataRow datarow = book_places.NewRow();
            datarow["Place_Name"] = "All Places";
            datarow["ID"] = "0";

            book_places.Rows.Add(datarow);

            DDLPLace.DataTextField = "Place_Name";
            DDLPLace.DataValueField = "ID";
            DDLPLace.DataSource = book_places;
            DDLPLace.DataBind();
        }
        FillGrid();

    }
    void FillGrid()
    {
        if (Request.QueryString.Count != 0)
        {
                book_ds = books_biz.PopulateList("Book_ID = " + Request.QueryString[0] );
            book_grid.DataSource = book_ds.Books;
            DDLCategory.SelectedValue = book_ds.Books[0].Category_ID.ToString ();
            DDLPLace.SelectedValue = book_ds.Books[0].ORG_ID.ToString ();
            book_grid.DataBind();
            return;

        }
        if (DDLCategory.SelectedIndex == DDLCategory.Items.Count - 1 && DDLPLace.SelectedIndex == DDLPLace.Items.Count -1)
            book_ds = books_biz.PopulateList("");
        if (DDLCategory.SelectedIndex != DDLCategory.Items.Count - 1 && DDLPLace.SelectedIndex == DDLPLace.Items.Count - 1)
            book_ds = books_biz.PopulateList("Category_ID  = "+ DDLCategory.SelectedValue );
        if (DDLCategory.SelectedIndex == DDLCategory.Items.Count - 1 && DDLPLace.SelectedIndex != DDLPLace.Items.Count - 1)
            book_ds = books_biz.PopulateList("Org_ID = " + DDLPLace.SelectedValue);
        if (DDLCategory.SelectedIndex != DDLCategory.Items.Count - 1 && DDLPLace.SelectedIndex != DDLPLace.Items.Count - 1)
            book_ds = books_biz.PopulateList("Org_ID = " + DDLPLace.SelectedValue  + " and Category_ID  = "+ DDLCategory.SelectedValue );
        book_grid.DataSource = book_ds.Books;

        book_grid.DataBind();
        

    }
    protected void book_grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        book_grid.PageIndex = e.NewPageIndex;
        book_grid.DataBind();
       
    }
    public string book_place(string Org_ID)
    {
        //decimal num = decimal.Parse(Org_ID);
        OrganizationsDS org_ds = new OrganizationsDS();
        OrganizationsBiz org_biz = new OrganizationsBiz();
        org_ds = org_biz.PopulateList("Org_ID = " + Org_ID );
        if (org_ds.Organizations.Count == 0)
            return "";
        else
        return org_ds.Organizations[0].Org_English_Name ;
   

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
