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

public partial class UserControls_Books : System.Web.UI.UserControl
{
    BooksBiz books_biz = new BooksBiz();
    BooksDS book_ds = new BooksDS();
    BooksDS.BooksRow book_row;
    //DataTable tb;


    Books_CategoryDS book_category_ds = new Books_CategoryDS();
    Books_CategoryBiz book_category_biz = new Books_CategoryBiz();

    //OrganizationsDS OrganizationsDSObject = new OrganizationsDS();
    //OrganizationsBiz OrganizationsBizObject = new OrganizationsBiz();

    protected void Page_Load(object sender, EventArgs e)
    {
        BaseDAL.ConnectionString = ConfigurationManager.ConnectionStrings["VSConnectionString"].ToString();
        if (Session["OrgID"] == null)
        {
            Response.Redirect("~/BackEnd/default.aspx");
        }
        if (Session["OrgID"] != null)
        {
            if (!IsPostBack)
            {
                book_category_ds = book_category_biz.PopulateList("");
                if (book_category_ds.Books_Category.Count != 0)
                {
                    DDL_Category.DataTextField = "Category_Name_Ar";
                    DDL_Category.DataValueField = "Category_ID";
                    DDL_Category.DataSource = book_category_ds.Books_Category;
                    DDL_Category.DataBind();

                    DDL_Category_SelectedIndexChanged(DDL_Category,e);
                }
            }
        }
    }
    

    protected void AddBtn_Click(object sender, EventArgs e)
    {
        Save.Text = "اضافة";
        Clear_Data();
        MultiView1.ActiveViewIndex = 1;
        
    }
    void Clear_Data()
    {
        TXT_Arabic_Book_Name.Text = "";
        TXT_English_Book_Name.Text = "";
        TXT_Authour_Arabic_Name.Text = "";
        TXT_Authour_English_Name.Text = "";
        TXT_Publication_Year.Text = "";
        //DDL_Category.SelectedIndex  = 0;

    }
    void FillGrid()
    {
        book_ds = books_biz.PopulateList("Category_ID = " + DDL_Category.SelectedValue + " AND Org_ID = " + Session["OrgID"].ToString());
        if (book_ds.Books.Rows.Count == 0 || book_ds == null)
        {
            MultiView1.ActiveViewIndex = 1;
            Clear_Data();
        }
        else
        {
            MultiView1.ActiveViewIndex = 0;
            book_grid.DataSource = book_ds.Books;
            book_grid.DataBind();
            FillHighLights();
        }
    }
    protected void DDL_Category_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();
    }
    protected void EditBtn_Click(object sender, EventArgs e)
    {
        int EditIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        Save.Text = "تعديل";

        book_ds = books_biz.PopulateList("Category_ID = " + DDL_Category.SelectedValue + " AND Org_ID = " + Session["OrgID"].ToString());
        ViewState["BookID"] = book_ds.Books.Rows[EditIndex]["Book_ID"].ToString();

        book_row = book_ds.Books[EditIndex];

        TXT_Arabic_Book_Name.Text = book_row.Book_Arabic_Name;
        TXT_English_Book_Name.Text = book_row.Book_English_Name;
        TXT_Authour_Arabic_Name.Text = book_row.Authour_Arabic_Name;
        TXT_Authour_English_Name.Text = book_row.Authour_English_Name;
        TXT_Publication_Year.Text = book_row.Publication_Year.ToString();

        MultiView1.ActiveViewIndex = 1;
        
    }
    
    protected void DelBtn_Click(object sender, EventArgs e)
    {
        try
        {
            Confirm("هل تريد حذف هذا الكتاب ؟");

            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            book_ds = books_biz.PopulateList("Category_ID = " + DDL_Category.SelectedValue + " AND Org_ID = " + Session["OrgID"].ToString());

            int BookID = Int32.Parse(book_ds.Books.Rows[RowIndex]["Book_ID"].ToString());

            string SQL = "delete from Books where Book_ID=" + BookID.ToString();
            Populate(SQL);

            book_ds = books_biz.PopulateList("Category_ID = " + DDL_Category.SelectedValue + " AND Org_ID = " + Session["OrgID"].ToString());
            if (book_ds.Books.Rows.Count <= 0)
            {
                MultiView1.ActiveViewIndex = 1;
                Clear_Data();
            }

            book_grid.DataSource = books_biz.PopulateList("Category_ID = " + DDL_Category.SelectedValue + " AND Org_ID = " + Session["OrgID"].ToString());
            book_grid.DataBind();
            FillHighLights();
        }
        catch (Exception ex)
        {
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

    protected void CancelBtn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Save.Text == "اضافة")
        {
            if (TXT_Publication_Year.Text == "")
            {
                TXT_Publication_Year.Text = "0";
            }
            if (TXT_Arabic_Book_Name.Text == "" && TXT_English_Book_Name.Text == "")
            {
                Page.RegisterStartupScript("ErrorMsg", "<script>alert('لابد من إدخال اسم الكتاب باللغة العربية أو الأنجليزية');</script>");
                return;
            }
            if (TXT_Authour_Arabic_Name.Text == "" && TXT_Authour_English_Name.Text == "")
            {
                Page.RegisterStartupScript("ErrorMsg", "<script>alert('لابد من إدخال اسم المؤلف باللغة العربية أو الأنجليزية');</script>");
                return;
            }
            book_row = book_ds.Books.NewBooksRow();
            book_row.Book_Arabic_Name = TXT_Arabic_Book_Name.Text;
            book_row.Book_English_Name = TXT_English_Book_Name.Text;
            book_row.Authour_Arabic_Name = TXT_Authour_Arabic_Name.Text;
            book_row.Authour_English_Name = TXT_Authour_English_Name.Text;
            string BookPublicationYear = TXT_Publication_Year.Text;
            BookPublicationYear = BookPublicationYear.Insert(4, "/");
            book_row.Publication_Year = BookPublicationYear;

            book_row.ORG_ID = decimal.Parse(Session["OrgID"].ToString());
            book_row.Category_ID = decimal.Parse(DDL_Category.SelectedValue);


            book_ds.Books.AddBooksRow(book_row);
            books_biz.InsertBooks(book_ds);
        }
        else if (Save.Text == "تعديل")
        {
            book_ds = books_biz.PopulateList("Book_ID = " + ViewState["BookID"]);

            book_ds.Books[0].Book_Arabic_Name = TXT_Arabic_Book_Name.Text;
            book_ds.Books[0].Book_English_Name = TXT_English_Book_Name.Text;
            book_ds.Books[0].Authour_Arabic_Name = TXT_Authour_Arabic_Name.Text;
            book_ds.Books[0].Authour_English_Name = TXT_Authour_English_Name.Text;
            string BookPublicationYear = TXT_Publication_Year.Text;
            BookPublicationYear = BookPublicationYear.Insert(4, "/");
            book_ds.Books[0].Publication_Year = BookPublicationYear;
            book_ds.Books[0].Category_ID = decimal.Parse(DDL_Category.SelectedValue);
            book_ds.Books[0].ORG_ID = decimal.Parse(Session["OrgID"].ToString());


            books_biz.UpdateBooks(book_ds);

            book_grid.EditIndex = -1;
        }
        FillGrid();
        MultiView1.ActiveViewIndex = 0;
    }
    protected void CHBHighlight_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox CHBVisable = ((CheckBox)sender);
            if (CHBVisable.Checked)
            {
                int RowIndex = ((GridViewRow)((CheckBox)sender).Parent.Parent).RowIndex;

                book_ds = books_biz.PopulateList("Category_ID = " + DDL_Category.SelectedValue + " AND Org_ID = " + Session["OrgID"].ToString());

                decimal RecordID =Decimal.Parse(book_ds.Books.Rows[RowIndex]["Book_ID"].ToString());
                decimal RecordType = 0;
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

                book_ds = books_biz.PopulateList("Category_ID = " + DDL_Category.SelectedValue + " AND Org_ID = " + Session["OrgID"].ToString());

                string RecordID = book_ds.Books.Rows[RowIndex]["Book_ID"].ToString();
                string Type = "0";

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
        foreach (GridViewRow GVRow in book_grid.Rows)
        {
            int RowIndex = GVRow.RowIndex;

            book_ds = books_biz.PopulateList("Category_ID = " + DDL_Category.SelectedValue + " AND Org_ID = " + Session["OrgID"].ToString());

            string RecordID = book_ds.Books.Rows[RowIndex]["Book_ID"].ToString();
            string Type = "0";

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
