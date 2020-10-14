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

public partial class UserControls_Boxs : System.Web.UI.UserControl
{
    BoxsBiz BoxsBizObject = new BoxsBiz();
    BoxsDS BoxsDSObject = new BoxsDS();
    BoxsDS.BoxsRow org_row;
    
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
                if (Int32.Parse(Session["OrgTypeID"].ToString()) == 1)
                {
                    BoxsDSObject = BoxsBizObject.PopulateList("");

                    if (BoxsDSObject != null && BoxsDSObject.Boxs.Rows.Count > 0)
                    {
                        MultiView1.ActiveViewIndex = 0;
                    }
                    else
                    {
                        Clear_Data();
                        MultiView1.ActiveViewIndex = 1;

                        ViewState["BoxID"] = null;
                    }

                    org_grid.DataSource = BoxsDSObject;
                    org_grid.DataBind();
                }
                
            }
            
        }

    }
    void FillGrid()
    {

        BoxsDSObject = BoxsBizObject.PopulateList("");
        org_grid.DataSource = BoxsDSObject.Boxs;
        org_grid.DataBind();
        ViewState["Boxs"] = BoxsDSObject.Tables[0];

    }
    protected void add_btn_Click(object sender, EventArgs e)
    {
        
        Clear_Data();
        Save.Text = "إضافة";
        MultiView1.ActiveViewIndex = 1;
    }
    void Clear_Data()
    {
        TXT_Arabic_Name.Text = "";
        TXT_English_Name.Text = "";
    }
    protected void Edit_btn_Click(object sender, EventArgs e)
    {
        try
        {
            Save.Text = "تعديل";
            int EditIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
            BoxsDSObject = BoxsBizObject.PopulateList("");

            ViewState["BoxID"] = BoxsDSObject.Boxs.Rows[EditIndex]["BoxID"].ToString();
            org_row = BoxsDSObject.Boxs[EditIndex];

            TXT_Arabic_Name.Text = org_row.BoxArabicTitle;
            TXT_English_Name.Text = org_row.BoxEnglishTitle;
            DDLContent.SelectedIndex = Int32.Parse(org_row.BoxContent.ToString());

            MultiView1.ActiveViewIndex = 1;
        }
        catch (Exception ex)
        {
        }
    }
    protected void Dlt_btn_Click(object sender, EventArgs e)
    {
        try
        {
            Confirm("هل تريد حذف هذا المحتوى ؟");

            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
               
            BoxsDSObject = BoxsBizObject.PopulateList("");

            int BoxID = Int32.Parse(BoxsDSObject.Boxs.Rows[RowIndex]["BoxID"].ToString());

            string SQL = "delete from Boxs where BoxID=" + BoxID.ToString();
            Populate(SQL);
                BoxsDSObject = BoxsBizObject.PopulateList("");
            if (BoxsDSObject.Boxs.Rows.Count <= 0)
            {
                MultiView1.ActiveViewIndex = 1;
            }

            org_grid.DataSource = BoxsDSObject;
            org_grid.DataBind();

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
    protected void Save_Click1(object sender, EventArgs e)
    {
        if (Save.Text.Trim() == "إضافة")
        {
            org_row = BoxsDSObject.Boxs.NewBoxsRow();

            //org_row.Org_Type_ID = 1;
            org_row.BoxArabicTitle = TXT_Arabic_Name.Text;
            org_row.BoxEnglishTitle = TXT_English_Name.Text;
            org_row.BoxContent = Int32.Parse(DDLContent.SelectedValue);

            BoxsDSObject.Boxs.AddBoxsRow(org_row);
            BoxsBizObject.InsertBoxs(BoxsDSObject);
            MultiView1.ActiveViewIndex = 0;
            BoxsDSObject = BoxsBizObject.PopulateList("");

            org_grid.DataSource = BoxsDSObject;
            org_grid.DataBind();

        }
        else if (Save.Text.Trim() == "تعديل")
        {
            BoxsDSObject = BoxsBizObject.Populate(Int32.Parse(ViewState["BoxID"].ToString()));
            BoxsDSObject.Boxs[0].BoxArabicTitle = TXT_Arabic_Name.Text;
            BoxsDSObject.Boxs[0].BoxEnglishTitle = TXT_English_Name.Text;
            BoxsDSObject.Boxs[0].BoxContent = Int32.Parse(DDLContent.SelectedValue);

            BoxsBizObject.UpdateBoxs(BoxsDSObject);

            BoxsDSObject = BoxsBizObject.PopulateList("");

            org_grid.DataSource = BoxsDSObject;
            org_grid.DataBind();
            MultiView1.ActiveViewIndex = 0;

        }
    }
    protected void Update_Click(object sender, EventArgs e)
    {

    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
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
