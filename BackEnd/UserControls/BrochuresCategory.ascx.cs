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
using Common;
using DataAccess;
using Businesslayer;

public partial class BackEnd_UserControls_BrochuresCategory : System.Web.UI.UserControl
{
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
                BrochuresCategoryBiz BrochuresCategoryBizObject = new BrochuresCategoryBiz();
                BrochuresCategoryDS BrochuresCategoryDSObject = BrochuresCategoryBizObject.PopulateList("");

                if (BrochuresCategoryDSObject != null && BrochuresCategoryDSObject.BrochuresCategory.Rows.Count > 0)
                {
                    MultiView1.ActiveViewIndex = 0;
                }
                else
                {
                    ClearCooperationForm();
                    MultiView1.ActiveViewIndex = 1;

                    ViewState["BrochureCateroryID"] = null;
                }

                GridView1.DataSource = BrochuresCategoryDSObject;
                GridView1.DataBind();
            }
        }

    }


    void ClearCooperationForm()
    {
        try
        {
            this.TXTBrochureCategoryArabicName.Text = "";
            this.TXTBrochureCategoryEnglishName.Text = "";

            this.BTNAdd.Visible = true; ;
            this.BTNUpdate.Visible = false;
        }
        catch (Exception ex)
        {
        }
    }
    bool FillCooperationForm(string BrochureCategoryID)
    {
        try
        {
            BrochuresCategoryBiz BrochuresCategoryBizObject = new BrochuresCategoryBiz();
            BrochuresCategoryDS BrochuresCategoryDSOject = BrochuresCategoryBizObject.PopulateList("Cat_ID = " + BrochureCategoryID);

            this.TXTBrochureCategoryArabicName.Text = BrochuresCategoryDSOject.BrochuresCategory.Rows[0]["Cat_Arabic_Name"].ToString();
            this.TXTBrochureCategoryEnglishName.Text = BrochuresCategoryDSOject.BrochuresCategory.Rows[0]["Cat_English_Name"].ToString();


            this.BTNAdd.Visible = false;
            this.BTNUpdate.Visible = true;
            return true;
        }
        catch (Exception ex)
        {
            return false;
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

    protected void LBTNEdit_Click(object sender, EventArgs e)
    {
        try
        {
            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            BrochuresCategoryBiz BrochuresCategoryBizObject = new BrochuresCategoryBiz();
            BrochuresCategoryDS BrochuresCategoryDSOject = BrochuresCategoryBizObject.PopulateList("");

            string BrochureCategoryID = BrochuresCategoryDSOject.BrochuresCategory.Rows[RowIndex]["Cat_ID"].ToString();

            ViewState.Add("BrochureCateroryID", BrochureCategoryID);

            if (FillCooperationForm(BrochureCategoryID))
            {
                MultiView1.ActiveViewIndex = 1;
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void LBTNDelete_Click(object sender, EventArgs e)
    {
        try
        {
            Confirm("هل تريد الحذف ؟");

            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            BrochuresCategoryBiz BrochuresCategoryBizObject = new BrochuresCategoryBiz();
            BrochuresCategoryDS BrochuresCategoryDSObject = BrochuresCategoryBizObject.PopulateList("");

            int BrochureCategoryID = Int32.Parse(BrochuresCategoryDSObject.BrochuresCategory.Rows[RowIndex]["Cat_ID"].ToString());

            string SQL = "delete from BrochuresCategory where Cat_ID=" + BrochureCategoryID.ToString();
            Populate(SQL);

            BrochuresCategoryDSObject = BrochuresCategoryBizObject.PopulateList("");
            if (BrochuresCategoryDSObject.BrochuresCategory.Rows.Count <= 0)
            {
                MultiView1.ActiveViewIndex = 1;
            }

            GridView1.DataSource = BrochuresCategoryBizObject.PopulateList("");
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    protected void LBTNShowDetails_Click(object sender, EventArgs e)
    {
        try
        {
            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            BrochuresCategoryBiz BrochuresCategoryBizObject = new BrochuresCategoryBiz();
            BrochuresCategoryDS BrochuresCategoryDSOject = BrochuresCategoryBizObject.PopulateList("");

            string BrochureCategoryID = BrochuresCategoryDSOject.BrochuresCategory.Rows[RowIndex]["Cat_ID"].ToString();

            BrochuresCategoryDSOject = BrochuresCategoryBizObject.Populate(Int32.Parse(BrochureCategoryID));

            ViewState.Add("BrochureCateroryID", BrochureCategoryID);

            MultiView1.ActiveViewIndex = 2;

            Repeater1.DataSource = BrochuresCategoryDSOject;
            Repeater1.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    protected void LBTNAdd_Click(object sender, EventArgs e)
    {
        try
        {
            ClearCooperationForm();
            MultiView1.ActiveViewIndex = 1;
            ViewState["BrochureCateroryID"] = null;
        }
        catch (Exception ex)
        {
        }
    }
    protected void BTNAdd_Click(object sender, EventArgs e)
    {
        try
        {
            string BrochureCategoryArabicName = TXTBrochureCategoryArabicName.Text;
            string BrochureCategoryEnglishName = TXTBrochureCategoryEnglishName.Text;

            BrochuresCategoryBiz BrochuresCategoryBizObject = new BrochuresCategoryBiz();
            BrochuresCategoryDS BrochuresCategoryDSObject = new BrochuresCategoryDS();
            BrochuresCategoryDS.BrochuresCategoryRow BrochuresCategoryRowObject = BrochuresCategoryDSObject.BrochuresCategory.NewBrochuresCategoryRow();

            BrochuresCategoryRowObject.Cat_Arabic_Name = BrochureCategoryArabicName;
            BrochuresCategoryRowObject.Cat_English_Name = BrochureCategoryEnglishName;


            BrochuresCategoryDSObject.BrochuresCategory.AddBrochuresCategoryRow(BrochuresCategoryRowObject);
            BrochuresCategoryDSObject = BrochuresCategoryBizObject.InsertBrochuresCategory(BrochuresCategoryDSObject);

            GridView1.DataSource = BrochuresCategoryBizObject.PopulateList("");
            GridView1.DataBind();

            ClearCooperationForm();

            MultiView1.ActiveViewIndex = 0;

        }
        catch (Exception ex)
        {
        }
    }
    protected void BTNUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string BrochureCategoryArabicName = TXTBrochureCategoryArabicName.Text;
            string BrochureCategoryEnglishName = TXTBrochureCategoryEnglishName.Text;


            BrochuresCategoryBiz BrochuresCategoryBizObject = new BrochuresCategoryBiz();
            BrochuresCategoryDS BrochuresCategoryDSObject = BrochuresCategoryBizObject.Populate(Int32.Parse(ViewState["BrochureCateroryID"].ToString()));

            BrochuresCategoryDSObject.BrochuresCategory[0].Cat_Arabic_Name = BrochureCategoryArabicName;
            BrochuresCategoryDSObject.BrochuresCategory[0].Cat_English_Name = BrochureCategoryEnglishName;

            BrochuresCategoryBizObject.UpdateBrochuresCategory(BrochuresCategoryDSObject);

            ClearCooperationForm();

            GridView1.DataSource = BrochuresCategoryBizObject.PopulateList("");
            GridView1.DataBind();

            MultiView1.ActiveViewIndex = 0;
        }
        catch (Exception ex)
        {
        }
    }
    protected void BTNCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearCooperationForm();
            MultiView1.ActiveViewIndex = 0;
        }
        catch (Exception ex)
        {
        }
    }
    protected void LBTNClose_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            try
            {
            }
            catch (Exception ex)
            {
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
