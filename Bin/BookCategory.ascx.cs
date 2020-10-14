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
using DataAccess;
using Businesslayer;
using System.Data.SqlClient;

public partial class UserControls_BookCategory : System.Web.UI.UserControl
{
    Books_CategoryDS book_category_ds = new Books_CategoryDS();
    Books_CategoryBiz book_category_biz = new Books_CategoryBiz();
    Books_CategoryDS.Books_CategoryRow book_category_row;

    protected void Page_Load(object sender, EventArgs e)
    {
        BaseDAL.ConnectionString = ConfigurationManager.ConnectionStrings["VSConnectionString"].ToString();

        if (Session["OrgID"] == null)
        {
            Response.Redirect("~/BackEnd/default.aspx");
        }

        if (!IsPostBack)
        {
            FillGrid();
        }
    }

    private void FillGrid()
    {


        book_category_ds = book_category_biz.PopulateList("");

        book_category_grid.DataSource = book_category_ds.Books_Category;
        book_category_grid.DataBind();
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


    protected void AddBtn_Click(object sender, EventArgs e)
    {
        TextBox txt_Arabic_Name = (TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXT_Arabic_Name");
        TextBox txt_English_Name = (TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXT_English_Name");

        book_category_row = book_category_ds.Books_Category.NewBooks_CategoryRow();

        book_category_row.Category_Name_Ar = txt_Arabic_Name.Text;
        book_category_row.Category_Name_En = txt_English_Name.Text;

        book_category_ds.Books_Category.AddBooks_CategoryRow(book_category_row);
        book_category_biz.InsertBooks_Category(book_category_ds);
        FillGrid();


    }
    protected void DelBtn_Click(object sender, EventArgs e)
    {   
        Confirm("åá ÊÑíÏ ÍÐÝ åÐÇ ÇáÊÕäíÝ ¿");
        Literal txt_Arabic_Name = (Literal)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("LIT_Arabic_Name");

        book_category_ds = book_category_biz.PopulateList("Category_Name_Ar  like '" + txt_Arabic_Name.Text + "'");
        BooksDS books_ds = new BooksDS();
        BooksBiz books_biz = new BooksBiz();
        //mar 3/2012
        int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
       
        /*Books_CategoryBiz NewsCategoryBizObject = new Books_CategoryBiz();
         
        NewsCategoryDS NewsCategoryDSOject = NewsCategoryBizObject.PopulateList("");*/
         
        string CategoryID = book_category_ds.Rows[RowIndex]["Category_ID"].ToString();

        books_ds = books_biz.PopulateList("Category_ID = " + book_category_ds.Books_Category[0].Category_ID);
        if (books_ds.Books.Count > 0)
        {
            Alert("åÐÇ ÇáÊÕäíÝ íÍÊæí Úáí ßÊÈ - ÇãÓÍ ÌãíÚ ÇáßÊÈ ÊÍÊ åÐÇ ÇáÊÕäíÝ");

        }
        else
        {
            int EditIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
            book_category_ds = book_category_biz.PopulateList("");
           //Mar 3/2012 book_category_ds.Books_Category[EditIndex].Delete();
            //Mar 3 /2012 book_category_biz.DeleteBooks_Category(book_category_ds);
            //string SqlW = "delete from Books_Category where Category_ID = " + CategoryID ; //book_category_ds.Books_Category[0].Category_ID;
            Alert(CategoryID);
            // Populate(SqlW);
        }
        FillGrid();
    }
    protected void EditBtn_Click(object sender, EventArgs e)
    {
        int EditIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        book_category_grid.EditIndex = EditIndex;
        FillGrid();
    }
    protected void UpdateBtn_Click(object sender, EventArgs e)
    {
        int EditIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        book_category_row = book_category_ds.Books_Category.NewBooks_CategoryRow();

        TextBox txt_Arabic_Name = (TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXT_Arabic_Name");
        TextBox txt_English_Name = (TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXT_English_Name");

        book_category_ds = book_category_biz.PopulateList("");

        book_category_ds.Books_Category[EditIndex].Category_Name_Ar = txt_Arabic_Name.Text;
        book_category_ds.Books_Category[EditIndex].Category_Name_En = txt_English_Name.Text;

        book_category_biz.UpdateBooks_Category(book_category_ds);

        book_category_grid.EditIndex = -1;
        FillGrid();




    }
    protected void CancelBtn_Click(object sender, EventArgs e)
    {
        book_category_grid.EditIndex = -1;
        FillGrid();
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

}
