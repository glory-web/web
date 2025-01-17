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

        TXT_English_Name.Style["text-align"] = "left";
        TXT_English_Address.Style["text-align"] = "left";
        TXTEMail.Style["text-align"] = "left";
        TXT_English_Goals.Style["text-align"] = "left";
        TXT_English_Achivments.Style["text-align"] = "left";
        TXT_English_History.Style["text-align"] = "left";
        TXT_English_Activity.Style["text-align"] = "left";


        if (Session["OrgID"] == null)
        {
            Response.Redirect("~/BackEnd/default.aspx");
        }
        if (Session["OrgID"] != null)
        {

            if (!IsPostBack)
            {
                OrganizationsBiz OrganizationsBizObject = new OrganizationsBiz();
                if (Int32.Parse(Session["OrgTypeID"].ToString())==1)
                    OrganizationsDSObject = OrganizationsBizObject.PopulateList("Parent_ORG_ID=" + Session["OrgID"].ToString() + " and Org_Type_ID= 2");
                else
                    OrganizationsDSObject = OrganizationsBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString() + " or Parent_ORG_ID=" + Session["OrgID"].ToString());
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

                //GetOrgTypesList(Int32.Parse(Session["OrgTypeID"].ToString()), "Add");
            }
        }
        
    }
    
    protected void add_btn_Click(object sender, EventArgs e)
    {
        //if (Int32.Parse(Session["OrgTypeID"].ToString()) == 1)
        //{
        //    Organizations_TypesBiz OrganizationsTypesBizObject = new Organizations_TypesBiz();
        //    Organizations_TypesDS OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList("");
        //    OrganizationsTypesDSObject.Organizations_Types.Rows.RemoveAt(2);
        //    OrganizationsTypesDSObject.Organizations_Types.Rows.RemoveAt(2);
        //    OrganizationsTypesDSObject.Organizations_Types.Rows.RemoveAt(2);
        //    OrganizationsTypesDSObject.Organizations_Types.Rows.RemoveAt(2);
        //    OrganizationsTypesDSObject.Organizations_Types.Rows.RemoveAt(2);
        //    OrganizationsTypesDSObject.Organizations_Types.Rows.RemoveAt(0);
        //    DDLOrganizationType.DataSource = OrganizationsTypesDSObject;
        //    DDLOrganizationType.DataBind();
        //}
        GetOrgTypesList(Int32.Parse(Session["OrgTypeID"].ToString()), "Add");
        Clear_Data();
        Save.Text = "إضافة";
        //this.DDLOrganizationType.Enabled = true;
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
        //DDLOrganizationType.SelectedIndex = 0;
    }
    protected void Edit_btn_Click(object sender, EventArgs e)
    {
        //if (Int32.Parse(Session["OrgTypeID"].ToString()) == 1)
        //{
        //    Organizations_TypesBiz OrganizationsTypesBizObject = new Organizations_TypesBiz();
        //    Organizations_TypesDS OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList("");
        //    OrganizationsTypesDSObject.Organizations_Types.Rows.RemoveAt(0);
        //    OrganizationsTypesDSObject.Organizations_Types.Rows.RemoveAt(0);

        //    DDLOrganizationType.DataSource = OrganizationsTypesDSObject;
        //    DDLOrganizationType.DataBind();
        //}
        GetOrgTypesList(Int32.Parse(Session["OrgTypeID"].ToString()), "Update");
        Save.Text = "تعديل";
        int EditIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;

        if (Int32.Parse(Session["OrgTypeID"].ToString()) == 1)
            OrganizationsDSObject = OrganizationsBizObject.PopulateList("Parent_ORG_ID=" + Session["OrgID"].ToString() + " and Org_Type_ID= 2");
        else
            OrganizationsDSObject = OrganizationsBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString() + " or Parent_ORG_ID=" + Session["OrgID"].ToString());

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
        //DDLOrganizationType.SelectedValue = org_row.Org_Type_ID.ToString();

        MultiView1.ActiveViewIndex = 1;

    }
    protected void Dlt_btn_Click(object sender, EventArgs e)
    {
        try
        {
            Confirm("هل تريد الحذف ؟");
            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            if (Int32.Parse(Session["OrgTypeID"].ToString()) == 1)
                OrganizationsDSObject = OrganizationsBizObject.PopulateList("Parent_ORG_ID=" + Session["OrgID"].ToString() + " and Org_Type_ID= 2");
            else
                OrganizationsDSObject = OrganizationsBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString() + " or Parent_ORG_ID=" + Session["OrgID"].ToString());

            int OrganizationID = Int32.Parse(OrganizationsDSObject.Organizations.Rows[RowIndex]["ORG_ID"].ToString());

            string SQL = "delete from Organizations where ORG_ID=" + OrganizationID.ToString();
            Populate(SQL);

            OrganizationsDSObject = OrganizationsBizObject.PopulateList("Parent_ORG_ID=" + Session["OrgID"].ToString() + " and Org_Type_ID= 2");

            if (OrganizationsDSObject.Organizations.Rows.Count <= 0)
            {
                MultiView1.ActiveViewIndex = 1;
            }

            org_grid.DataSource = OrganizationsDSObject;
            org_grid.DataBind();
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

            org_row.Parent_ORG_ID = Int32.Parse(Session["OrgID"].ToString());
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
            org_row.ORG_Email = TXTEMail.Text;
            org_row.Org_Type_ID = 2;

            OrganizationsDSObject.Organizations.AddOrganizationsRow(org_row);
            OrganizationsBizObject.InsertOrganizations(OrganizationsDSObject);
            MultiView1.ActiveViewIndex = 0;

            if (Int32.Parse(Session["OrgTypeID"].ToString()) == 1)
                OrganizationsDSObject = OrganizationsBizObject.PopulateList("Parent_ORG_ID=" + Session["OrgID"].ToString() + " and Org_Type_ID= 2");
            else
                OrganizationsDSObject = OrganizationsBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString() + " or Parent_ORG_ID=" + Session["OrgID"].ToString());

            org_grid.DataSource = OrganizationsDSObject;
            org_grid.DataBind();
        }
        else if (Save.Text.Trim() == "تعديل")
        {
            org_row = OrganizationsDSObject.Organizations.NewOrganizationsRow();
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
            OrganizationsDSObject.Organizations[0].ORG_Email = TXTEMail.Text;
            OrganizationsDSObject.Organizations[0].Org_Type_ID = 2;

            OrganizationsBizObject.UpdateOrganizations(OrganizationsDSObject);


            if (Int32.Parse(Session["OrgTypeID"].ToString()) == 1)
                OrganizationsDSObject = OrganizationsBizObject.PopulateList("Parent_ORG_ID=" + Session["OrgID"].ToString() + " and Org_Type_ID= 2");
            else
                OrganizationsDSObject = OrganizationsBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString() + " or Parent_ORG_ID=" + Session["OrgID"].ToString());

            org_grid.DataSource = OrganizationsDSObject;
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
    void GetOrgTypesList(int CurrentOrgType, string OperationType)
    {
        Organizations_TypesBiz OrganizationsTypesBizObject = new Organizations_TypesBiz();
        Organizations_TypesDS OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList("");

        ///////////////////////////////// Govs Screen //////////////////////////////////

        if (CurrentOrgType == 1 && OperationType == "Add")
        {
            OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList(" Org_Type_ID= 3 or Org_Type_ID= 6 or Org_Type_ID= 7 ");
        }
        else if (CurrentOrgType == 1 && OperationType == "Update")
        {
            OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList(" Org_Type_ID= 1 or Org_Type_ID= 3 or Org_Type_ID= 6 or Org_Type_ID= 7");
        }
        else if (CurrentOrgType == 6 && OperationType == "Add")
        {
            OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList("Org_Type_ID= 7");
        }
        else if (CurrentOrgType == 6 && (OperationType == "Update"))
        {
            OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList("Org_Type_ID= 7 or Org_Type_ID= 6");
        }
        else if (CurrentOrgType == 7 && OperationType == "Add")
        {
            OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList("Org_Type_ID= 3");
        }
        else if (CurrentOrgType == 7 && (OperationType == "Update"))
        {
            OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList("Org_Type_ID= 3 or Org_Type_ID= 7");
        }
        else if (CurrentOrgType == 2 && (OperationType == "Add"))
        {
            OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList(" Org_Type_ID= 3 or Org_Type_ID= 4 or Org_Type_ID= 5");
        }
        else if (CurrentOrgType == 2 && (OperationType == "Update"))
        {
            OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList("Org_Type_ID= 2 or  Org_Type_ID= 3 or Org_Type_ID= 4 or Org_Type_ID= 5");
        }
        else if (CurrentOrgType == 3 && (OperationType == "Add"))
        {
            OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList(" Org_Type_ID= 4 or Org_Type_ID= 5 ");
        }
        else if (CurrentOrgType == 3 && (OperationType == "Update"))
        {
            OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList(" Org_Type_ID= 4 or Org_Type_ID= 5 or Org_Type_ID= 3 ");
        }
        else if (CurrentOrgType == 4 && (OperationType == "Add"))
        {
            OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList(" Org_Type_ID= 5 ");
        }
        else if (CurrentOrgType == 4 && (OperationType == "Update"))
        {
            OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList(" Org_Type_ID= 5 or Org_Type_ID= 4 ");
        }
        else if (CurrentOrgType == 5 && (OperationType == "Add"))
        {
            OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList(" Org_Type_ID= 5 ");
        }
        else if (CurrentOrgType == 5 && (OperationType == "Update"))
        {
            OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList(" Org_Type_ID= 5 ");
        }

        ////////////////////////////////////////////////////////////////////////////////

        DDLOrganizationType.DataSource = OrganizationsTypesDSObject;
        DDLOrganizationType.DataBind();
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
