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

public partial class UserControls_Users : System.Web.UI.UserControl
{
    OrganizationsBiz OrganizationsBizObject = new OrganizationsBiz();
    OrganizationsDS OrganizationsDSObject;
    protected void Page_Load(object sender, EventArgs e)
    {
        BaseDAL.ConnectionString = ConfigurationManager.ConnectionStrings["VSConnectionString"].ToString();
        if (Session["OrgID"] == null)
        {
            Response.Redirect("~/BackEnd/default.aspx");
        }
        if (!IsPostBack)
        {
            try
            {
                AdministrationBiz AdministrationBizObject = new AdministrationBiz();
                AdministrationDS AdministrationDSObject = AdministrationBizObject.PopulateList("");

                if (AdministrationDSObject != null && AdministrationDSObject.Administration.Rows.Count > 0)
                {
                    MultiView1.ActiveViewIndex = 0;
                }
                else
                {
                    ClearCooperationForm();
                    MultiView1.ActiveViewIndex = 1;

                    ViewState["AdminID"] = null;
                }

                GridView1.DataSource = AdministrationDSObject;
                GridView1.DataBind();

                OrganizationsBiz OrganizationsBizObject = new OrganizationsBiz();
                OrganizationsDS OrganizationsDSObject = OrganizationsBizObject.PopulateList("Org_Type_ID = 2 or Org_Type_ID = 6 or Org_Type_ID = 7 or Org_Type_ID = 3");
                DDLOrganizationName.DataSource = OrganizationsDSObject;
                DDLOrganizationName.DataBind();

                PrivilagesBiz PrivilagesBizObject = new PrivilagesBiz();
                PrivilagesDS PrivilagesDSObject = PrivilagesBizObject.PopulateList("");
                DDLPrevilage.DataSource = PrivilagesDSObject;
                DDLPrevilage.DataBind();
            }
            catch (Exception ex)
            {
            }
        }
    }
    void ClearCooperationForm()
    {
        try
        {
            this.TXTFullName.Text = "";
            this.TXTUserName.Text = "";
            this.TXTPassword.Text = "";
            this.DDLOrganizationName.SelectedIndex = 0;
            this.DDLPrevilage.SelectedIndex = 0;
            this.BTNAdd.Visible = true; ;
            this.BTNUpdate.Visible = false;
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
    protected void LBTNEdit_Click(object sender, EventArgs e)
    {
        try
        {
            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            AdministrationBiz AdministrationBizObject = new AdministrationBiz();
            AdministrationDS AdministrationDSObject = AdministrationBizObject.PopulateList("");

            string AdminID = AdministrationDSObject.Administration.Rows[RowIndex]["Admin_ID"].ToString();

            ViewState.Add("AdminID", AdminID);

            if (FillCooperationForm(AdminID))
            {
                MultiView1.ActiveViewIndex = 1;
            }
        }
        catch (Exception ex)
        {
        }
    }

    bool FillCooperationForm(string CooperationID)
    {
        try
        {
            AdministrationBiz AdministrationBizObject = new AdministrationBiz();
            AdministrationDS AdministrationDSObject = AdministrationBizObject.PopulateList("Admin_ID = " + CooperationID);

            this.TXTFullName.Text = AdministrationDSObject.Administration.Rows[0]["Admin_Name"].ToString();
            this.TXTUserName.Text = AdministrationDSObject.Administration.Rows[0]["Admin_UserName"].ToString();
            this.TXTPassword.Text = AdministrationDSObject.Administration.Rows[0]["Admin_Password"].ToString();
            this.DDLPrevilage.SelectedValue = AdministrationDSObject.Administration.Rows[0]["Privilage_ID"].ToString();
            this.DDLOrganizationName.SelectedValue = AdministrationDSObject.Administration.Rows[0]["ORG_ID"].ToString();

            this.BTNAdd.Visible = false;
            this.BTNUpdate.Visible = true;
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    protected void BTNAdd_Click(object sender, EventArgs e)
    {
        try
        {
            string AdministratorFullName = TXTFullName.Text;
            string AdministratorUseName = TXTUserName.Text;
            string AdministratorPassword = TXTPassword.Text;
            int PrivalageID = 1;
            int OrgID = Int32.Parse(DDLOrganizationName.SelectedValue);

            AdministrationBiz AdministrationBizObject = new AdministrationBiz();
            AdministrationDS AdministrationDSObject = new AdministrationDS();
            AdministrationDS.AdministrationRow AdministrationRowOject = AdministrationDSObject.Administration.NewAdministrationRow();

            AdministrationRowOject.ORG_ID = OrgID;
            AdministrationRowOject.Admin_Name = AdministratorFullName;
            AdministrationRowOject.Admin_UserName = AdministratorUseName;
            AdministrationRowOject.Admin_Password = AdministratorPassword;
            AdministrationRowOject.Privilage_ID = PrivalageID;

            AdministrationDSObject.Administration.AddAdministrationRow(AdministrationRowOject);
            AdministrationDSObject = AdministrationBizObject.InsertAdministration(AdministrationDSObject);

            GridView1.DataSource = AdministrationBizObject.PopulateList("");
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
            string AdministratorFullName = TXTFullName.Text;
            string AdministratorUseName = TXTUserName.Text;
            string AdministratorPassword = TXTPassword.Text;
            int PrivalageID = 1;
            int OrgID = Int32.Parse(DDLOrganizationName.SelectedValue);

            AdministrationBiz AdministrationBizObject = new AdministrationBiz();
            AdministrationDS AdministrationDSObject = AdministrationBizObject.Populate(Int32.Parse(ViewState["AdminID"].ToString()));

            AdministrationDSObject.Administration[0].ORG_ID = OrgID;
            AdministrationDSObject.Administration[0].Privilage_ID = PrivalageID;
            AdministrationDSObject.Administration[0].Admin_Name = AdministratorFullName;
            AdministrationDSObject.Administration[0].Admin_UserName = AdministratorUseName;
            AdministrationDSObject.Administration[0].Admin_Password = AdministratorPassword;

            AdministrationBizObject.UpdateAdministration(AdministrationDSObject);

            ClearCooperationForm();

            MultiView1.ActiveViewIndex = 0;

            GridView1.DataSource = AdministrationBizObject.PopulateList("");
            GridView1.DataBind();


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
    protected void LBTNShowDetails_Click(object sender, EventArgs e)
    {
        try
        {
            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            AdministrationBiz AdministrationBizObject = new AdministrationBiz();
            AdministrationDS AdministrationDSOject = AdministrationBizObject.PopulateList("");

            string AdminID = AdministrationDSOject.Administration.Rows[RowIndex]["Admin_ID"].ToString();

            AdministrationDSOject = AdministrationBizObject.Populate(Int32.Parse(AdminID));

            ViewState.Add("AdminID", AdminID);

            MultiView1.ActiveViewIndex = 2;

            Repeater1.DataSource = AdministrationDSOject;
            Repeater1.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            try
            {
                DataRow dr = ((DataRowView)e.Item.DataItem).Row;
                string OrgID = dr["ORG_ID"].ToString();
                OrganizationsBiz OrganizationsBizObject = new OrganizationsBiz();
                OrganizationsDS OrganizationsDSObject = OrganizationsBizObject.Populate(Int32.Parse(OrgID));
                string OrgName = OrganizationsDSObject.Organizations.Rows[0]["ORG_Arabic_Name"].ToString();

                ((Literal)e.Item.FindControl("Literal4")).Text = OrgName;


                string PrivelageID = dr["Privilage_ID"].ToString();
                PrivilagesBiz PrivilagesBizObject = new PrivilagesBiz();
                PrivilagesDS PrivilagesDSObject = PrivilagesBizObject.Populate(Int32.Parse(PrivelageID));
                string PrivilageName = PrivilagesDSObject.Privilages.Rows[0]["Privilage_Name"].ToString();

                ((Literal)e.Item.FindControl("Literal1")).Text = PrivilageName;
            }
            catch (Exception ex)
            {
            }
        }
    }
    protected void LTNDalete_Click(object sender, EventArgs e)
    {
        try
        {
            Confirm("Â·  —Ìœ «·Õ–› ø");

            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            AdministrationBiz AdministrationBizObject = new AdministrationBiz();
            AdministrationDS AdministrationDSObject = AdministrationBizObject.PopulateList("");

            int AdminID = Int32.Parse(AdministrationDSObject.Administration.Rows[RowIndex]["Admin_ID"].ToString());



            string SQL1 = "delete from Administration where Admin_ID=" + AdminID.ToString();
            Populate(SQL1);

            GridView1.DataSource = AdministrationBizObject.PopulateList("");
            GridView1.DataBind();
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
            ViewState["AdminID"] = null;
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
