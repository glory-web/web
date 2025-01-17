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


public partial class UserControls_Organization : System.Web.UI.UserControl
{
    
    OrganizationsBiz OrganizationsBizObject = new OrganizationsBiz();
    OrganizationsDS OrganizationsDSObject  = new OrganizationsDS();
    OrganizationsDS.OrganizationsRow org_row;

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
                OrganizationsDSObject = OrganizationsBizObject.PopulateList("ORG_ID=" + Session["OrgID"] as string + " or Parent_ORG_ID=" + Session["OrgID"] as string);

                DDLOrganizationsName.DataSource = OrganizationsDSObject;
                DDLOrganizationsName.DataBind();

                DDLOrganizationsName_SelectedIndexChanged(DDLOrganizationsName, e);

                Organizations_TypesBiz OrganizationsTypesBizObject = new Organizations_TypesBiz();
                Organizations_TypesDS OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList("");
                
                if (Int32.Parse(Session["OrgTypeID"].ToString()) == 1)
                {
                    OrganizationsTypesDSObject.Organizations_Types.Rows.RemoveAt(0);
                }
                DDLOrganizationType.DataSource = OrganizationsTypesDSObject;
                DDLOrganizationType.DataBind();
            }
            else
            {
                OrganizationsDSObject = OrganizationsBizObject.PopulateList("ORG_ID=" + DDLOrganizationsName.SelectedValue + " or Parent_ORG_ID=" + DDLOrganizationsName.SelectedValue);

                DDLOrganizationsName.DataSource = OrganizationsDSObject;
                DDLOrganizationsName.DataBind();
            }
            if (Int32.Parse(Session["OrgTypeID"].ToString()) != 1)
            {
                org_grid.FooterRow.Visible = false;
            }
        }
        
    }
    void FillGrid()
    {

        OrganizationsDSObject = OrganizationsBizObject.PopulateList("Org_Type_ID = 1");
        org_grid.DataSource = OrganizationsDSObject.Organizations;
        org_grid.DataBind();
        ViewState["Organizations"] = OrganizationsDSObject.Tables[0];

    }
    protected void add_btn_Click(object sender, EventArgs e)
    {
        if (Int32.Parse(Session["OrgTypeID"].ToString()) == 1)
        {
            Organizations_TypesBiz OrganizationsTypesBizObject = new Organizations_TypesBiz();
            Organizations_TypesDS OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList("");
            OrganizationsTypesDSObject.Organizations_Types.Rows.RemoveAt(0);
            DDLOrganizationType.DataSource = OrganizationsTypesDSObject;
            DDLOrganizationType.DataBind();
        }
        Clear_Data();
        Save.Text = "إضافة";
        this.DDLOrganizationType.Enabled = true;
        MultiView1.ActiveViewIndex = 1;
    }
    void Clear_Data()
    {
        TXT_Arabic_Name.Text = "";
        TXT_English_Name.Text = "";
        TXT_Phone.Text = "";
        TXT_Fax.Text = "";
        TXT_Arabic_Address.Text = "";
        TXT_English_Address.Text = "";
        TXT_Arabic_Achivments.Text = "";
        TXT_English_Achivments.Text = "";
        TXT_Arabic_Activity.Text = "";
        TXT_English_Activity.Text = "";
        TXT_Arabic_Goals.Text = "";
        TXT_English_Goals.Text = "";
        TXT_Arabic_History.Text = "";
        TXT_English_History.Text = "";
        DDLOrganizationType.SelectedIndex = 0;
    }
    protected void Edit_btn_Click(object sender, EventArgs e)
    {
        if (Int32.Parse(Session["OrgTypeID"].ToString()) == 1)
        {
            Organizations_TypesBiz OrganizationsTypesBizObject = new Organizations_TypesBiz();
            Organizations_TypesDS OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList("");

            DDLOrganizationType.DataSource = OrganizationsTypesDSObject;
            DDLOrganizationType.DataBind();
        }
        Save.Text = "تعديل";
        int EditIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        if (Int32.Parse(Session["OrgTypeID"].ToString()) == 1)
        {
            OrganizationsDSObject = OrganizationsBizObject.PopulateList("ORG_ID=" + DDLOrganizationsName.SelectedValue + " or Parent_ORG_ID=" + DDLOrganizationsName.SelectedValue);
        }
        else
        {
            OrganizationsDSObject = OrganizationsBizObject.PopulateList("ORG_ID=" + DDLOrganizationsName.SelectedValue + " or Parent_ORG_ID=" + DDLOrganizationsName.SelectedValue);
        }
        ViewState["OrgID"] = OrganizationsDSObject.Organizations.Rows[EditIndex]["Org_ID"].ToString();
        org_row = OrganizationsDSObject.Organizations[EditIndex];

        this.DDLOrganizationType.Enabled = false;

        TXT_Arabic_Name.Text = org_row.ORG_Arabic_Name;
        TXT_English_Name.Text = org_row.Org_English_Name;
        TXT_Phone.Text = org_row.ORG_Telephone;
        TXT_Fax.Text = org_row.ORG_Fax;
        TXT_Arabic_Address.Text = org_row.ORG_Arabic_Address;
        TXT_English_Address.Text = org_row.ORG_English_Address;
        TXT_Arabic_Achivments.Text = org_row.ORG_Arabic_Achivments;
        TXT_English_Achivments.Text = org_row.ORG_English_Achivments;
        TXT_Arabic_Activity.Text = org_row.ORG_Arabic_Activity;
        TXT_English_Activity.Text = org_row.ORG_English_Activity;
        TXT_Arabic_Goals.Text = org_row.ORG_Arabic_Goals;
        TXT_English_Goals.Text = org_row.ORG_English_Goals;
        TXT_Arabic_History.Text = org_row.ORG_Arabic_History;
        TXT_English_History.Text = org_row.ORG_English_History;
        DDLOrganizationType.SelectedValue = org_row.Org_Type_ID.ToString();

        MultiView1.ActiveViewIndex = 1;

    }
    protected void Dlt_btn_Click(object sender, EventArgs e)
    {
        try
        {
            Confirm("هل تريد الحذف ؟");

            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
            if (Int32.Parse(Session["OrgTypeID"].ToString()) == 1)
            {
                OrganizationsDSObject = OrganizationsBizObject.PopulateList("ORG_ID=" + DDLOrganizationsName.SelectedValue + " or Parent_ORG_ID=" + DDLOrganizationsName.SelectedValue);
            }
            else
            {
                OrganizationsDSObject = OrganizationsBizObject.PopulateList("ORG_ID=" + DDLOrganizationsName.SelectedValue + " or Parent_ORG_ID=" + DDLOrganizationsName.SelectedValue);
            }

            int OrganizationID = Int32.Parse(OrganizationsDSObject.Organizations.Rows[RowIndex]["ORG_ID"].ToString());

            string SQL = "delete from Organizations where ORG_ID=" + OrganizationID.ToString();
            Populate(SQL);
            if (Int32.Parse(Session["OrgTypeID"].ToString()) == 1)
            {
                OrganizationsDSObject = OrganizationsBizObject.PopulateList("ORG_ID=" + DDLOrganizationsName.SelectedValue + " or Parent_ORG_ID=" + DDLOrganizationsName.SelectedValue );
            }
            else
            {
                OrganizationsDSObject = OrganizationsBizObject.PopulateList("ORG_ID=" + DDLOrganizationsName.SelectedValue + " or Parent_ORG_ID=" + DDLOrganizationsName.SelectedValue);
            }
            if (OrganizationsDSObject.Organizations.Rows.Count <= 0)
            {
                MultiView1.ActiveViewIndex = 1;
            }

            org_grid.DataSource = OrganizationsDSObject;
            org_grid.DataBind();

            OrganizationsDSObject = OrganizationsBizObject.PopulateList("ORG_ID=" + Session["OrgID"] as string + " or Parent_ORG_ID=" + Session["OrgID"] as string);

            int OldIndex = DDLOrganizationsName.SelectedIndex;

            DDLOrganizationsName.DataSource = OrganizationsDSObject;
            DDLOrganizationsName.DataBind();

            DDLOrganizationsName.SelectedIndex = OldIndex;
        }
        catch (Exception ex)
        {
            Page.RegisterStartupScript("ErrorMsg", "<script>alert('عفوا لايمكن حذف هذه الهيئة بسبب وجود بعض المعلومات المرتبطة بها');</script>");
            return;
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
            org_row = OrganizationsDSObject.Organizations.NewOrganizationsRow();

            //org_row.Org_Type_ID = 1;
            org_row.Parent_ORG_ID = Int32.Parse(DDLOrganizationsName.SelectedValue);
            org_row.ORG_Arabic_Name = TXT_Arabic_Name.Text;
            org_row.Org_English_Name = TXT_English_Name.Text;
            org_row.ORG_Telephone = TXT_Phone.Text;
            org_row.ORG_Fax = TXT_Fax.Text;
            org_row.ORG_Arabic_Address = TXT_Arabic_Address.Text;
            org_row.ORG_English_Address = TXT_English_Address.Text;
            org_row.ORG_Arabic_Achivments = TXT_Arabic_Achivments.Text;
            org_row.ORG_English_Achivments = TXT_English_Achivments.Text;
            org_row.ORG_Arabic_Goals = TXT_Arabic_Goals.Text;
            org_row.ORG_English_Goals = TXT_English_Goals.Text;
            org_row.ORG_Arabic_Activity = TXT_Arabic_Activity.Text;
            org_row.ORG_English_Activity = TXT_English_Activity.Text;
            org_row.ORG_Arabic_History = TXT_Arabic_History.Text;
            org_row.ORG_English_History = TXT_English_History.Text;
            org_row.Org_Type_ID = Int32.Parse(DDLOrganizationType.SelectedValue);

            OrganizationsDSObject.Organizations.AddOrganizationsRow(org_row);
            OrganizationsBizObject.InsertOrganizations(OrganizationsDSObject);
            MultiView1.ActiveViewIndex = 0;
            if (Int32.Parse(Session["OrgTypeID"].ToString()) == 1)
            {
                OrganizationsDSObject = OrganizationsBizObject.PopulateList("ORG_ID=" + DDLOrganizationsName.SelectedValue + " or Parent_ORG_ID=" + DDLOrganizationsName.SelectedValue );
            }
            else
            {
                OrganizationsDSObject = OrganizationsBizObject.PopulateList("ORG_ID=" + DDLOrganizationsName.SelectedValue + " or Parent_ORG_ID=" + DDLOrganizationsName.SelectedValue);
            }
            org_grid.DataSource = OrganizationsDSObject;
            org_grid.DataBind();

            OrganizationsDSObject = OrganizationsBizObject.PopulateList("ORG_ID=" + Session["OrgID"] as string + " or Parent_ORG_ID=" + Session["OrgID"] as string);

            int OldIndex = DDLOrganizationsName.SelectedIndex;

            DDLOrganizationsName.DataSource = OrganizationsDSObject;
            DDLOrganizationsName.DataBind();

            DDLOrganizationsName.SelectedIndex = OldIndex;
            //FillGKCrid();
        }
        else if (Save.Text.Trim() == "تعديل")
        {
            org_row = OrganizationsDSObject.Organizations.NewOrganizationsRow();
            //if (Int32.Parse(Session["OrgTypeID"].ToString()) == 1)
            //{
            //    OrganizationsDSObject = OrganizationsBizObject.PopulateList("ORG_ID=" + DDLOrganizationsName.SelectedValue + " or Parent_ORG_ID=" + DDLOrganizationsName.SelectedValue );
            //}
            //else
            //{
            //    OrganizationsDSObject = OrganizationsBizObject.PopulateList("ORG_ID =" + ViewState["OrgID"]);
            //}
            OrganizationsDSObject = OrganizationsBizObject.Populate(Int32.Parse(ViewState["OrgID"].ToString()));
            OrganizationsDSObject.Organizations[0].ORG_Arabic_Name = TXT_Arabic_Name.Text;
            OrganizationsDSObject.Organizations[0].Org_English_Name = TXT_English_Name.Text;
            OrganizationsDSObject.Organizations[0].ORG_Telephone = TXT_Phone.Text;
            OrganizationsDSObject.Organizations[0].ORG_Fax = TXT_Fax.Text;
            OrganizationsDSObject.Organizations[0].ORG_Arabic_Address = TXT_Arabic_Address.Text;
            OrganizationsDSObject.Organizations[0].ORG_English_Address = TXT_English_Address.Text;
            OrganizationsDSObject.Organizations[0].ORG_Arabic_Achivments = TXT_Arabic_Achivments.Text;
            OrganizationsDSObject.Organizations[0].ORG_English_Achivments = TXT_English_Achivments.Text;
            OrganizationsDSObject.Organizations[0].ORG_Arabic_Goals = TXT_Arabic_Goals.Text;
            OrganizationsDSObject.Organizations[0].ORG_English_Goals = TXT_English_Goals.Text;
            OrganizationsDSObject.Organizations[0].ORG_Arabic_Activity = TXT_Arabic_Activity.Text;
            OrganizationsDSObject.Organizations[0].ORG_English_Activity = TXT_English_Activity.Text;
            OrganizationsDSObject.Organizations[0].ORG_Arabic_History = TXT_Arabic_History.Text;
            OrganizationsDSObject.Organizations[0].ORG_English_History = TXT_English_History.Text;
            OrganizationsDSObject.Organizations[0].Org_Type_ID = Int32.Parse(DDLOrganizationType.SelectedValue);

            OrganizationsBizObject.UpdateOrganizations(OrganizationsDSObject);

            if (Int32.Parse(Session["OrgTypeID"].ToString()) == 1)
            {
                OrganizationsDSObject = OrganizationsBizObject.PopulateList("ORG_ID=" + DDLOrganizationsName.SelectedValue + " or Parent_ORG_ID=" + DDLOrganizationsName.SelectedValue );
            }
            else
            {
                OrganizationsDSObject=OrganizationsBizObject.PopulateList("ORG_ID=" + DDLOrganizationsName.SelectedValue + " or Parent_ORG_ID=" + DDLOrganizationsName.SelectedValue);
            }
            org_grid.DataSource = OrganizationsDSObject;
            org_grid.DataBind();
            MultiView1.ActiveViewIndex = 0;
            //FillGrid();

            OrganizationsDSObject = OrganizationsBizObject.PopulateList("ORG_ID=" + Session["OrgID"] as string + " or Parent_ORG_ID=" + Session["OrgID"] as string);

            int OldIndex = DDLOrganizationsName.SelectedIndex;

            DDLOrganizationsName.DataSource = OrganizationsDSObject;
            DDLOrganizationsName.DataBind();

            DDLOrganizationsName.SelectedIndex = OldIndex;
            
        }
    }
    protected void Update_Click(object sender, EventArgs e)
    {
        
    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void DDLOrganizationsName_SelectedIndexChanged(object sender, EventArgs e)
    {
        OrganizationsBiz OrganizationsBizObject = new OrganizationsBiz();
        if (Int32.Parse(Session["OrgTypeID"].ToString()) == 1)
        {
            OrganizationsDSObject = OrganizationsBizObject.PopulateList("ORG_ID=" + DDLOrganizationsName.SelectedValue + " or Parent_ORG_ID=" + DDLOrganizationsName.SelectedValue );
        }
        else
        {
            OrganizationsDSObject = OrganizationsBizObject.PopulateList("ORG_ID=" + DDLOrganizationsName.SelectedValue + " or Parent_ORG_ID=" + DDLOrganizationsName.SelectedValue);
        }
        if (OrganizationsDSObject != null && OrganizationsDSObject.Organizations.Rows.Count > 0)
        {
            MultiView1.ActiveViewIndex = 0;
        }
        else
        {
            Clear_Data();
            MultiView1.ActiveViewIndex = 1;

            ViewState["OrganizationID"] = null;
        }

        org_grid.DataSource = OrganizationsDSObject;
        org_grid.DataBind();
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
