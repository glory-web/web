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
        //http://www.beansoftware.com/ASP.NET-FAQ/Align-Right-Center-TextBox.aspx
        
        TXT_English_Name.Style["text-align"] = "left";
        TXT_English_Address.Style["text-align"] = "left";
        TXT_English_Goals.Style["text-align"] = "left";
        TXT_English_Achivments.Style["text-align"] = "left";
        TXT_English_History.Style["text-align"] = "left";
        TXT_English_Activity.Style["text-align"] = "left";



        if (Int32.Parse(Session["OrgTypeID"].ToString()) == 2)
        {
            GovarnRow.Visible = true;
        }
        UnitsTable.Visible = false;
        EdaraTable.Visible = false;
        MagtherTable.Visible = false;
        BaseDAL.ConnectionString = ConfigurationManager.ConnectionStrings["VSConnectionString"].ToString();

        if (Session["OrgID"] == null)
        {
            Response.Redirect("~/BackEnd/default.aspx");
        }
        if (Session["OrgID"] != null)
        {

            if (!IsPostBack)
            {
                
                OrganizationsBiz OrganizationsBizObject = new OrganizationsBiz();
                if (Int32.Parse(Session["OrgTypeID"].ToString()) == 1)
                    OrganizationsDSObject = OrganizationsBizObject.PopulateList("Org_Type_ID != 2 and Parent_ORG_ID=" + Session["OrgID"].ToString());
                else
                    OrganizationsDSObject = OrganizationsBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString() + " or Parent_ORG_ID=" + Session["OrgID"].ToString() + " and Org_Type_ID != 2");

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
        }
        
    }
    
    protected void add_btn_Click(object sender, EventArgs e)
    {
        //Organizations_TypesBiz OrganizationsTypesBizObject = new Organizations_TypesBiz();
        //Organizations_TypesDS OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList("");
        //if (Int32.Parse(Session["OrgTypeID"].ToString()) == 1)
        //{
        //    OrganizationsTypesDSObject.Organizations_Types.Rows.RemoveAt(0);
        //    OrganizationsTypesDSObject.Organizations_Types.Rows.RemoveAt(0);
        //    OrganizationsTypesDSObject.Organizations_Types.Rows.RemoveAt(0);
        //    OrganizationsTypesDSObject.Organizations_Types.Rows.RemoveAt(0);
        //    OrganizationsTypesDSObject.Organizations_Types.Rows.RemoveAt(0);
        //}
        //else if ((Int32.Parse(Session["OrgTypeID"].ToString()) != 1))
        //{
        //    OrganizationsTypesDSObject.Organizations_Types.Rows.RemoveAt(5);
        //    OrganizationsTypesDSObject.Organizations_Types.Rows.RemoveAt(5);
        //    OrganizationsTypesDSObject.Organizations_Types.Rows.RemoveAt(0);
        //    OrganizationsTypesDSObject.Organizations_Types.Rows.RemoveAt(0);
        //}
        GetOrgTypesList(Int32.Parse(Session["OrgTypeID"].ToString()), "Add");
        //DDLOrganizationType.DataSource = OrganizationsTypesDSObject;
        //DDLOrganizationType.DataBind();
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
        int EditIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;

        GetOrgTypesList(Int32.Parse(Session["OrgTypeID"].ToString()), "Update");

        Save.Text = "تعديل";

        if (Int32.Parse(Session["OrgTypeID"].ToString()) == 1)
            OrganizationsDSObject = OrganizationsBizObject.PopulateList("Org_Type_ID != 2 and Parent_ORG_ID=" + Session["OrgID"].ToString());
        else
            OrganizationsDSObject = OrganizationsBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString() + " or Parent_ORG_ID=" + Session["OrgID"].ToString() + " and Org_Type_ID != 2");
        
        ViewState["OrgID"] = OrganizationsDSObject.Organizations.Rows[EditIndex]["Org_ID"].ToString();
        org_row = OrganizationsDSObject.Organizations[EditIndex];

        this.DDLOrganizationType.Enabled = false;

        TXT_Arabic_Name.Text = org_row.ORG_Arabic_Name;
        TXT_English_Name.Text = org_row.Org_English_Name;
        TXT_Phone.Text = org_row.ORG_Telephone;
        TXT_Fax.Text = org_row.ORG_Fax;
        TXTEMail.Text = org_row.ORG_Email;
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
                OrganizationsDSObject = OrganizationsBizObject.PopulateList("Org_Type_ID != 2 and Parent_ORG_ID=" + Session["OrgID"].ToString());
            else
                OrganizationsDSObject = OrganizationsBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString() + " or Parent_ORG_ID=" + Session["OrgID"].ToString() + " and Org_Type_ID != 2");

            int OrganizationID = Int32.Parse(OrganizationsDSObject.Organizations.Rows[RowIndex]["ORG_ID"].ToString());

            if (OrganizationID == 1)
            {
                Page.RegisterStartupScript("ErrorMsg", "<script>alert('عفوا لا يمكنك حذف بيانات الهيئة العامة للخدمات البيطرية');</script>");
                return;
            }

            if (OrganizationID == 2 || OrganizationID == 3)
            {
                Page.RegisterStartupScript("ErrorMsg", "<script>alert('عفوا لا يمكنك حذف هذة الأدارة');</script>");
                return;
            }

            string SQL = "delete from Organizations where ORG_ID=" + OrganizationID.ToString();
            Populate(SQL);

            OrganizationsDSObject = OrganizationsBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString() + " or Parent_ORG_ID=" + Session["OrgID"].ToString() + " and Org_Type_ID != 2");

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
            org_row.Org_Type_ID = Int32.Parse(DDLOrganizationType.SelectedValue);
            org_row.ORG_Email = TXTEMail.Text;

            OrganizationsDSObject.Organizations.AddOrganizationsRow(org_row);
            OrganizationsBizObject.InsertOrganizations(OrganizationsDSObject);
            MultiView1.ActiveViewIndex = 0;

            if (Int32.Parse(Session["OrgTypeID"].ToString()) == 1)
                OrganizationsDSObject = OrganizationsBizObject.PopulateList("Org_Type_ID != 2 and Parent_ORG_ID=" + Session["OrgID"].ToString());
            else
                OrganizationsDSObject = OrganizationsBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString() + " or Parent_ORG_ID=" + Session["OrgID"].ToString() + " and Org_Type_ID != 2");

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
            OrganizationsDSObject.Organizations[0].Org_Type_ID = Int32.Parse(DDLOrganizationType.SelectedValue);
            OrganizationsDSObject.Organizations[0].ORG_Email = TXTEMail.Text;

            OrganizationsBizObject.UpdateOrganizations(OrganizationsDSObject);


            if (Int32.Parse(Session["OrgTypeID"].ToString()) == 1)
                OrganizationsDSObject = OrganizationsBizObject.PopulateList("Org_Type_ID != 2 and Parent_ORG_ID=" + Session["OrgID"].ToString());
            else
                OrganizationsDSObject = OrganizationsBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString() + " or Parent_ORG_ID=" + Session["OrgID"].ToString() + " and Org_Type_ID != 2");

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

    void GetOrgTypesList(int CurrentOrgType,string OperationType)
    {
        Organizations_TypesBiz OrganizationsTypesBizObject = new Organizations_TypesBiz();
        Organizations_TypesDS OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList("");

        /*
 * 
 * 
1   GOVS    هيئة
2   Governerate     مديرية
3   Directorate   //  إدارة
4   Unit          //  وحدة
5   Sluter      //    مجزر
6   Centralized Directorate     إدارة مركزية
7   Public Directorate      إدارة عامة

*/
        
        ///////////////////////////////// Govs Screen //////////////////////////////////

        if (CurrentOrgType == 1 && OperationType == "Add") // GOV
        {
            OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList(" Org_Type_ID= 3 or Org_Type_ID= 6 or Org_Type_ID= 7 ");
        }
        else if (CurrentOrgType == 1 && OperationType == "Update")// GOV
        {
            OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList(" Org_Type_ID= 1 or Org_Type_ID= 3 or Org_Type_ID= 6 or Org_Type_ID= 7");
        }
        else if (CurrentOrgType == 6 && OperationType == "Add") // إدارة مركزية
        {
            OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList("Org_Type_ID = 7");
        }
        else if (CurrentOrgType == 6 && (OperationType == "Update")) // إدارة مركزية
        {
            OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList("Org_Type_ID = 7 or Org_Type_ID= 6");
        }
        else if (CurrentOrgType == 7 && OperationType == "Add") // إدارة عامة
        {
            // Maraym OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList("Org_Type_ID= 3");
            OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList(" Org_Type_ID= 3"); // maryam 8/2012 add Org_Type_ID= 3 and remove Org_Type_ID = 7 or 
        }
        else if (CurrentOrgType == 7 && (OperationType == "Update"))// إدارة عامة
        {
            // Maraym OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList("Org_Type_ID= 3 or Org_Type_ID= 7");
            OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList("Org_Type_ID = 7 or Org_Type_ID= 3"); // maryam 8/2012 or Org_Type_ID= 3
        }
        else if (CurrentOrgType == 2 && (OperationType == "Add"))// مديرية
        {
            OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList(" Org_Type_ID= 3 or Org_Type_ID= 4 or Org_Type_ID= 5");            
        }
        else if (CurrentOrgType == 2 && (OperationType == "Update"))// مديرية
        {            
            OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList("Org_Type_ID= 2 or  Org_Type_ID= 3 ");
        }
        else if (CurrentOrgType == 3 && (OperationType == "Add"))//  إدارة
        {
            OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList(" Org_Type_ID= 4 or Org_Type_ID= 5 ");
        }
        else if (CurrentOrgType == 3 && (OperationType == "Update"))//  إدارة
        {
            OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList(" Org_Type_ID= 4 or Org_Type_ID= 5 or Org_Type_ID= 3 ");
        }
        else if (CurrentOrgType == 4 && (OperationType == "Add")) //  وحدة
        {            
            OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList(" Org_Type_ID= 4 ");
        }
        else if (CurrentOrgType == 4 && (OperationType == "Update")) //  وحدة
        {         
            OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList(" Org_Type_ID= 4 ");
        }
        else if (CurrentOrgType == 5 && (OperationType == "Add")) //    مجزر
        {
            OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList(" Org_Type_ID= 5 ");
        }
        else if (CurrentOrgType == 5 && (OperationType == "Update")) //    مجزر
        {
            OrganizationsTypesDSObject = OrganizationsTypesBizObject.PopulateList(" Org_Type_ID= 5 ");
        }
        
        ////////////////////////////////////////////////////////////////////////////////

        DDLOrganizationType.DataSource = OrganizationsTypesDSObject;
        DDLOrganizationType.DataBind();
    }

    protected void LBTNEdara_Click(object sender, EventArgs e)
    {
        try
        {
            EdaraTable.Visible = true;
            
            int OrganizationID = Int32.Parse(Session["OrgID"].ToString());

            OrganizationsDSObject = OrganizationsBizObject.PopulateList("Parent_ORG_ID=" + OrganizationID.ToString() + " and Org_Type_ID= 3");

            GVEdara.DataSource = OrganizationsDSObject;
            GVEdara.DataBind();
            BindMainGrid();
        }
        catch (Exception ex)
        {
        }
    }
    protected void LBTNUnit_Click(object sender, EventArgs e)
    {
        try
        {
            UnitsTable.Visible = true;

            int OrganizationID = Int32.Parse(Session["OrgID"].ToString());

            OrganizationsDSObject = OrganizationsBizObject.PopulateList("Parent_ORG_ID=" + OrganizationID.ToString() + " and Org_Type_ID= 3");

            DDLEdarat.DataTextField = "ORG_Arabic_Name";
            DDLEdarat.DataValueField = "ORG_ID";
            DDLEdarat.DataSource = OrganizationsDSObject;
            DDLEdarat.DataBind();
            DDLEdarat_SelectedIndexChanged(DDLEdarat, e);


        }
        catch (Exception ex)
        {
        }
    }
    protected void LBTNMagther_Click(object sender, EventArgs e)
    {
        try
        {
            MagtherTable.Visible =true;

            int OrganizationID = Int32.Parse(Session["OrgID"].ToString());

            OrganizationsDSObject = OrganizationsBizObject.PopulateList("Parent_ORG_ID=" + OrganizationID.ToString() + " and Org_Type_ID= 3");

            DDLEdarat2.DataTextField = "ORG_Arabic_Name";
            DDLEdarat2.DataValueField = "ORG_ID";
            DDLEdarat2.DataSource = OrganizationsDSObject;
            DDLEdarat2.DataBind();

            DDLEdarat2_SelectedIndexChanged(DDLEdarat2, e);
        }
        catch (Exception ex)
        {
        }
    }
    protected void AddBtn_Click(object sender, EventArgs e)
    {
        try
        {
            UnitsTable.Visible = true;
            TextBox txt_Arabic_Name = (TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXT_Arabic_Name");
            TextBox txt_English_Name = (TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXT_English_Name");

            int OrganizationID = Int32.Parse(Session["OrgID"].ToString());

            org_row = OrganizationsDSObject.Organizations.NewOrganizationsRow();

            org_row.Parent_ORG_ID = Decimal.Parse(DDLEdarat.SelectedValue);
            org_row.ORG_Arabic_Name = txt_Arabic_Name.Text;
            org_row.Org_English_Name = txt_English_Name.Text;
            org_row.ORG_Telephone = "";
            org_row.ORG_Fax = "";
            org_row.ORG_Arabic_Address = "";
            org_row.ORG_English_Address = "";
            org_row.ORG_Arabic_Achivments = "";
            org_row.ORG_English_Achivments = "";
            org_row.ORG_Arabic_Goals = "";
            org_row.ORG_English_Goals = "";
            org_row.ORG_Arabic_Activity = "";
            org_row.ORG_English_Activity = "";
            org_row.ORG_Arabic_History = "";
            org_row.ORG_English_History = "";
            org_row.ORG_Email = "";
            org_row.Org_Type_ID = 4;

            OrganizationsDSObject.Organizations.AddOrganizationsRow(org_row);
            OrganizationsBizObject.InsertOrganizations(OrganizationsDSObject);

            GVUnits.DataSource = GetUnitDataSet(Int32.Parse(DDLEdarat.SelectedValue));
            GVUnits.DataBind();
            BindMainGrid();
        }
        catch (Exception ex)
        {
        }
    }
    protected void EditBtn_Click(object sender, EventArgs e)
    {
        try
        {
            UnitsTable.Visible = true;
            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
            GVUnits.EditIndex = RowIndex;

            int OrganizationID = Int32.Parse(Session["OrgID"].ToString());
            GVUnits.DataSource = GetUnitDataSet(Int32.Parse(DDLEdarat.SelectedValue));
            GVUnits.DataBind();
            BindMainGrid();
        }
        catch (Exception ex)
        {
        }
    }
    protected void DelBtn_Click(object sender, EventArgs e)
    {
        try
        {
            UnitsTable.Visible = true;
            Literal OrgID = (Literal)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("LITOrgID");


            string SQL = "delete from Organizations where ORG_ID=" + OrgID.Text;
            Populate(SQL);

            int OrganizationID = Int32.Parse(Session["OrgID"].ToString());
            GVUnits.DataSource = GetUnitDataSet(Int32.Parse(DDLEdarat.SelectedValue));
            GVUnits.DataBind();
            BindMainGrid();

        }
        catch (Exception ex)
        {
        }
    }
    protected void UpdateBtn_Click(object sender, EventArgs e)
    {
        try
        {
            UnitsTable.Visible = true;
            int UNRowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
            TextBox txt_Arabic_Name = (TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXT_Arabic_Name");
            TextBox txt_English_Name = (TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXT_English_Name");

            org_row = OrganizationsDSObject.Organizations.NewOrganizationsRow();

            int OrganizationID = Int32.Parse(Session["OrgID"].ToString());

            OrganizationsDSObject = GetUnitDataSet(Int32.Parse(DDLEdarat.SelectedValue));
            OrganizationsDSObject.Organizations[UNRowIndex].ORG_Arabic_Name = txt_Arabic_Name.Text;
            OrganizationsDSObject.Organizations[UNRowIndex].Org_English_Name = txt_English_Name.Text;
            OrganizationsDSObject.Organizations[UNRowIndex].Org_Type_ID = 4;

            OrganizationsBizObject.UpdateOrganizations(OrganizationsDSObject);

            GVUnits.EditIndex = -1;

            GVUnits.DataSource = GetUnitDataSet(Int32.Parse(DDLEdarat.SelectedValue));
            GVUnits.DataBind();
            BindMainGrid();
        }
        catch (Exception ex)
        {
        }
    }
    protected void CancelBtn_Click(object sender, EventArgs e)
    {
        try
        {
            UnitsTable.Visible = true;
            GVUnits.EditIndex = -1;

            int OrganizationID = Int32.Parse(Session["OrgID"].ToString());
            GVUnits.DataSource = GetUnitDataSet(Int32.Parse(DDLEdarat.SelectedValue));
            GVUnits.DataBind();
            BindMainGrid();
        }
        catch (Exception ex)
        {
        }
    }

    public OrganizationsDS GetUnitDataSet(int OrganizationID)
    {
        OrganizationsDSObject = OrganizationsBizObject.PopulateList("Parent_ORG_ID=" + OrganizationID.ToString() + " and Org_Type_ID= 4");
        return OrganizationsDSObject;
    }
    protected void EditBtn_Click1(object sender, EventArgs e)
    {
        try
        {
            EdaraTable.Visible = true;
            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
            GVEdara.EditIndex = RowIndex;

            int OrganizationID = Int32.Parse(Session["OrgID"].ToString());
            GVEdara.DataSource = GetEdaraDataSet(OrganizationID);
            GVEdara.DataBind();
            BindMainGrid();
        }
        catch (Exception ex)
        {
        }
    }

    private OrganizationsDS GetEdaraDataSet(int OrganizationID)
    {
        OrganizationsDSObject = OrganizationsBizObject.PopulateList("Parent_ORG_ID=" + OrganizationID.ToString() + " and Org_Type_ID= 3");
        return OrganizationsDSObject;
    }
    protected void DelBtn_Click1(object sender, EventArgs e)
    {
        try
        {
            EdaraTable.Visible = true;
            Literal OrgID = (Literal)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("LITOrgID");


            string SQL = "delete from Organizations where ORG_ID=" + OrgID.Text;
            Populate(SQL);

            int OrganizationID = Int32.Parse(Session["OrgID"].ToString());
            GVEdara.DataSource = GetEdaraDataSet(OrganizationID);
            GVEdara.DataBind();
            BindMainGrid();

        }
        catch (Exception ex)
        {
        }
    }
    protected void UpdateBtn_Click1(object sender, EventArgs e)
    {
        try
        {
            EdaraTable.Visible = true;
            int UNRowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
            TextBox txt_Arabic_Name = (TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXT_Arabic_Name");
            TextBox txt_English_Name = (TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXT_English_Name");

            org_row = OrganizationsDSObject.Organizations.NewOrganizationsRow();

            int OrganizationID = Int32.Parse(Session["OrgID"].ToString());

            OrganizationsDSObject = GetEdaraDataSet(OrganizationID);
            OrganizationsDSObject.Organizations[UNRowIndex].ORG_Arabic_Name = txt_Arabic_Name.Text;
            OrganizationsDSObject.Organizations[UNRowIndex].Org_English_Name = txt_English_Name.Text;
            OrganizationsDSObject.Organizations[UNRowIndex].Org_Type_ID = 3;

            OrganizationsBizObject.UpdateOrganizations(OrganizationsDSObject);

            GVEdara.EditIndex = -1;

            GVEdara.DataSource = GetEdaraDataSet(OrganizationID);
            GVEdara.DataBind();
            BindMainGrid();
        }
        catch (Exception ex)
        {
        }
    }
    protected void CancelBtn_Click1(object sender, EventArgs e)
    {
        try
        {
            EdaraTable.Visible = true;
            GVEdara.EditIndex = -1;

            int OrganizationID = Int32.Parse(Session["OrgID"].ToString());
            GVEdara.DataSource = GetEdaraDataSet(OrganizationID);
            GVEdara.DataBind();
            BindMainGrid();
        }
        catch (Exception ex)
        {
        }
    }
    protected void AddBtn_Click1(object sender, EventArgs e)
    {
        try
        {
            EdaraTable.Visible = true;
            TextBox txt_Arabic_Name = (TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXT_Arabic_Name");
            TextBox txt_English_Name = (TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXT_English_Name");

            int OrganizationID = Int32.Parse(Session["OrgID"].ToString());

            org_row = OrganizationsDSObject.Organizations.NewOrganizationsRow();

            org_row.Parent_ORG_ID = OrganizationID;
            org_row.ORG_Arabic_Name = txt_Arabic_Name.Text;
            org_row.Org_English_Name = txt_English_Name.Text;
            org_row.ORG_Telephone = "";
            org_row.ORG_Fax = "";
            org_row.ORG_Arabic_Address = "";
            org_row.ORG_English_Address = "";
            org_row.ORG_Arabic_Achivments = "";
            org_row.ORG_English_Achivments = "";
            org_row.ORG_Arabic_Goals = "";
            org_row.ORG_English_Goals = "";
            org_row.ORG_Arabic_Activity = "";
            org_row.ORG_English_Activity = "";
            org_row.ORG_Arabic_History = "";
            org_row.ORG_English_History = "";
            org_row.ORG_Email = "";
            org_row.Org_Type_ID = 3;

            OrganizationsDSObject.Organizations.AddOrganizationsRow(org_row);
            OrganizationsBizObject.InsertOrganizations(OrganizationsDSObject);

            OrganizationsDSObject = OrganizationsBizObject.PopulateList("Parent_ORG_ID=" + OrganizationID.ToString() + " and Org_Type_ID= 3");

            GVEdara.DataSource = OrganizationsDSObject;
            GVEdara.DataBind();
            BindMainGrid();
        }
        catch (Exception ex)
        {
        }
    }
    protected void EditBtn_Click2(object sender, EventArgs e)
    {
        try
        {
            MagtherTable.Visible =true;
            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
            GVMagther.EditIndex = RowIndex;

            int OrganizationID = Int32.Parse(Session["OrgID"].ToString());
            GVMagther.DataSource = GetMagtherDataSet(Int32.Parse(DDLEdarat2.SelectedValue));
            GVMagther.DataBind();
            BindMainGrid();
        }
        catch (Exception ex)
        {
        }
    }

    private OrganizationsDS GetMagtherDataSet(int OrganizationID)
    {
        OrganizationsDSObject = OrganizationsBizObject.PopulateList("Parent_ORG_ID=" + OrganizationID.ToString() + " and Org_Type_ID= 5");
        return OrganizationsDSObject;
    }
    protected void DelBtn_Click2(object sender, EventArgs e)
    {
        try
        {
            MagtherTable.Visible =true;
            Literal OrgID = (Literal)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("LITOrgID");


            string SQL = "delete from Organizations where ORG_ID=" + OrgID.Text;
            Populate(SQL);

            int OrganizationID = Int32.Parse(Session["OrgID"].ToString());
            GVMagther.DataSource = GetMagtherDataSet(Int32.Parse(DDLEdarat2.SelectedValue));
            GVMagther.DataBind();
            BindMainGrid();

        }
        catch (Exception ex)
        {
        }
    }
    protected void UpdateBtn_Click2(object sender, EventArgs e)
    {
        try
        {
            MagtherTable.Visible =true;
            int UNRowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
            TextBox txt_Arabic_Name = (TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXT_Arabic_Name");
            TextBox txt_English_Name = (TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXT_English_Name");

            org_row = OrganizationsDSObject.Organizations.NewOrganizationsRow();


            int OrganizationID = Int32.Parse(Session["OrgID"].ToString());
            OrganizationsDSObject = GetMagtherDataSet(Int32.Parse(DDLEdarat2.SelectedValue));
            OrganizationsDSObject.Organizations[UNRowIndex].ORG_Arabic_Name = txt_Arabic_Name.Text;
            OrganizationsDSObject.Organizations[UNRowIndex].Org_English_Name = txt_English_Name.Text;
            OrganizationsDSObject.Organizations[UNRowIndex].Org_Type_ID = 5;

            OrganizationsBizObject.UpdateOrganizations(OrganizationsDSObject);

            GVMagther.EditIndex = -1;

            GVMagther.DataSource = GetMagtherDataSet(Int32.Parse(DDLEdarat2.SelectedValue));
            GVMagther.DataBind();
            BindMainGrid();
        }
        catch (Exception ex)
        {
        }
    }
    protected void CancelBtn_Click2(object sender, EventArgs e)
    {
        try
        {
            MagtherTable.Visible =true;
            GVMagther.EditIndex = -1;

            int OrganizationID = Int32.Parse(Session["OrgID"].ToString());
            GVMagther.DataSource = GetMagtherDataSet(Int32.Parse(DDLEdarat2.SelectedValue));
            GVMagther.DataBind();
            BindMainGrid();
        }
        catch (Exception ex)
        {
        }
    }
    protected void AddBtn_Click2(object sender, EventArgs e)
    {
        try
        {
            MagtherTable.Visible =true;
            TextBox txt_Arabic_Name = (TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXT_Arabic_Name");
            TextBox txt_English_Name = (TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXT_English_Name");

            int OrganizationID = Int32.Parse(Session["OrgID"].ToString());

            org_row = OrganizationsDSObject.Organizations.NewOrganizationsRow();

            org_row.Parent_ORG_ID = Decimal.Parse(DDLEdarat2.SelectedValue);
            org_row.ORG_Arabic_Name = txt_Arabic_Name.Text;
            org_row.Org_English_Name = txt_English_Name.Text;
            org_row.ORG_Telephone = "";
            org_row.ORG_Fax = "";
            org_row.ORG_Arabic_Address = "";
            org_row.ORG_English_Address = "";
            org_row.ORG_Arabic_Achivments = "";
            org_row.ORG_English_Achivments = "";
            org_row.ORG_Arabic_Goals = "";
            org_row.ORG_English_Goals = "";
            org_row.ORG_Arabic_Activity = "";
            org_row.ORG_English_Activity = "";
            org_row.ORG_Arabic_History = "";
            org_row.ORG_English_History = "";
            org_row.ORG_Email = "";
            org_row.Org_Type_ID = 5;

            OrganizationsDSObject.Organizations.AddOrganizationsRow(org_row);
            OrganizationsBizObject.InsertOrganizations(OrganizationsDSObject);

            GVMagther.DataSource = GetMagtherDataSet(Int32.Parse(DDLEdarat2.SelectedValue));
            GVMagther.DataBind();
            BindMainGrid();
        }
        catch (Exception ex)
        {
        }
    }
    void BindMainGrid()
    {
        OrganizationsDSObject = OrganizationsBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString() + " or Parent_ORG_ID=" + Session["OrgID"].ToString() + " and Org_Type_ID != 2");

        if (OrganizationsDSObject.Organizations.Rows.Count <= 0)
        {
            MultiView1.ActiveViewIndex = 1;
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
    protected void DDLEdarat_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            UnitsTable.Visible = true;

            OrganizationsDSObject = OrganizationsBizObject.PopulateList("Parent_ORG_ID=" + DDLEdarat.SelectedValue + " and Org_Type_ID= 4");

            GVUnits.DataSource = OrganizationsDSObject;
            GVUnits.DataBind();
            BindMainGrid();

        }
        catch (Exception ex)
        {
        }
    }
    protected void DDLEdarat2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            MagtherTable.Visible = true;
            OrganizationsDSObject = OrganizationsBizObject.PopulateList("Parent_ORG_ID=" + DDLEdarat2.SelectedValue + " and Org_Type_ID= 5");

            GVMagther.DataSource = OrganizationsDSObject;
            GVMagther.DataBind();
            BindMainGrid();
        }
        catch (Exception ex)
        {
        }
    }
    
    protected void org_grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (Int32.Parse(Session["OrgTypeID"].ToString()) == 2 || Int32.Parse(Session["OrgTypeID"].ToString()) == 7)
            {
                if (e.Row.RowType == DataControlRowType.Footer)
                    e.Row.Visible = false;
                if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != 0)
                    e.Row.Visible = false;
            }
        }
        catch (Exception ex)
        {
        }
    }
}
/*
 * 
 * 
1   GOVS    هيئة
2   Governerate     مديرية
3   Directorate     إدارة
4   Unit            وحدة
5   Sluter          مجزر
6   Centralized Directorate     إدارة مركزية
7   Public Directorate      إدارة عامة

*/