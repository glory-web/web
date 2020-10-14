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

public partial class UserControls_NewsCategory : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["OrgID"] == null)
        {
            Response.Redirect("~/BackEnd/default.aspx");
        }
        if (!IsPostBack)
        {
            NewsCategoryBiz NewsCategoryBizObject = new NewsCategoryBiz();
            NewsCategoryDS NewsCategoryDSObject = NewsCategoryBizObject.PopulateList("");

            GridView2.DataSource = NewsCategoryDSObject;
            GridView2.DataBind();
        }
    }

    protected void LBTNUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            NewsCategoryBiz NewsCategoryBizObject = new NewsCategoryBiz();
            NewsCategoryDS NewsCategoryDSObject = NewsCategoryBizObject.PopulateList("");

            int CategoryID = Int32.Parse(NewsCategoryDSObject.NewsCategory.Rows[RowIndex]["Cat_ID"].ToString());

            ViewState.Add("CategoryID", CategoryID);
            GridView2.EditIndex = RowIndex;

            GridView2.DataSource = NewsCategoryDSObject;
            GridView2.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    protected void LBTNDelete_Click(object sender, EventArgs e)
    {
        try
        {
            Confirm("åá ÊÑíÏ ÇáÍÐÝ ¿");

            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            NewsCategoryBiz NewsCategoryBizObject = new NewsCategoryBiz();
            NewsCategoryDS NewsCategoryDSOject = NewsCategoryBizObject.PopulateList("");

            string CategoryID = NewsCategoryDSOject.NewsCategory.Rows[RowIndex]["Cat_ID"].ToString();

            string SQL = "delete from NewsCategory where Cat_ID=" + CategoryID.ToString();
            Populate(SQL);

            GridView2.DataSource = NewsCategoryBizObject.PopulateList("");
            GridView2.DataBind();
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
    protected void LBTNSave_Click(object sender, EventArgs e)
    {
        try
        {
            string CatArabicName = ((TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXTCatArabicName")).Text;
            string CatEnglishName = ((TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXTCatEnglishName")).Text;

            NewsCategoryBiz NewsCategoryBizObject = new NewsCategoryBiz();
            NewsCategoryDS NewsCategoryDSObject = NewsCategoryBizObject.Populate(Int32.Parse(ViewState["CategoryID"].ToString()));

            NewsCategoryDSObject.NewsCategory[0].Cat_Arabic_Name = CatArabicName;
            NewsCategoryDSObject.NewsCategory[0].Cat_English_Name = CatEnglishName;

            NewsCategoryBizObject.UpdateNewsCategory(NewsCategoryDSObject);

            GridView2.EditIndex = -1;
            GridView2.DataSource = NewsCategoryBizObject.PopulateList("");
            GridView2.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    protected void LBTNCancel_Click(object sender, EventArgs e)
    {
        try
        {
            NewsCategoryBiz NewsCategoryBizObject = new NewsCategoryBiz();
            GridView2.EditIndex = -1;
            GridView2.DataSource = NewsCategoryBizObject.PopulateList("");
            GridView2.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    protected void LBTNAdd_Click(object sender, EventArgs e)
    {
        try
        {

            string CatArabicName = ((TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXTCatArabicName")).Text;
            string CatEnglishName = ((TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXTCatEnglishName")).Text;

            NewsCategoryBiz NewsCategoryBizObject = new NewsCategoryBiz();
            NewsCategoryDS NewsCategoryDSObject = new NewsCategoryDS();
            NewsCategoryDS.NewsCategoryRow NewsCategoryRowObject = NewsCategoryDSObject.NewsCategory.NewNewsCategoryRow();

            NewsCategoryRowObject.Cat_Arabic_Name = CatArabicName;
            NewsCategoryRowObject.Cat_English_Name = CatEnglishName;

            NewsCategoryDSObject.NewsCategory.AddNewsCategoryRow(NewsCategoryRowObject);
            NewsCategoryBizObject.InsertNewsCategory(NewsCategoryDSObject);

            GridView2.DataSource = NewsCategoryBizObject.PopulateList("");
            GridView2.DataBind();

        }
        catch (Exception ex)
        {
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
