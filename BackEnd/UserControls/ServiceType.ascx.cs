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

public partial class UserControls_ServiceType : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        BaseDAL.ConnectionString = ConfigurationManager.ConnectionStrings["VSConnectionString"].ToString();

        TXTServiceTypeEnglishName.Style["text-align"] = "left";

        if (Session["OrgID"] == null)
        {
            Response.Redirect("~/BackEnd/default.aspx");
        }
        if (Session["OrgID"] != null)
        {

            if (!IsPostBack)
            {
                ServiceTypeBiz ServiceTypeBizObject = new ServiceTypeBiz();
                ServiceTypeDS ServiceTypeDSObject = ServiceTypeBizObject.PopulateList("");

                if (ServiceTypeDSObject != null && ServiceTypeDSObject.ServiceType.Rows.Count > 0)
                {
                    MultiView1.ActiveViewIndex = 0;
                }
                else
                {
                    ClearCooperationForm();
                    MultiView1.ActiveViewIndex = 1;

                    ViewState["ServiceTypeID"] = null;
                }

                GridView1.DataSource = ServiceTypeDSObject;
                GridView1.DataBind();
            }
        }

    }


    void ClearCooperationForm()
    {
        try
        {
            this.TXTServiceTypeArabicName.Text = "";
            this.TXTServiceTypeEnglishName.Text = "";

            this.BTNAdd.Visible = true; ;
            this.BTNUpdate.Visible = false;
        }
        catch (Exception ex)
        {
        }
    }
    bool FillCooperationForm(string CooperationID)
    {
        try
        {
            ServiceTypeBiz ServiceTypeBizObject = new ServiceTypeBiz();
            ServiceTypeDS ServiceTypeDSOject = ServiceTypeBizObject.PopulateList("Type_ID = " + CooperationID);

            this.TXTServiceTypeArabicName.Text = ServiceTypeDSOject.ServiceType.Rows[0]["Service_Type_Arabic_Name"].ToString();
            this.TXTServiceTypeEnglishName.Text = ServiceTypeDSOject.ServiceType.Rows[0]["Service_Type_English_Name"].ToString();


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

            ServiceTypeBiz ServiceTypeBizObject = new ServiceTypeBiz();
            ServiceTypeDS ServiceTypeDSOject = ServiceTypeBizObject.PopulateList("");

            string ServiceTypeID = ServiceTypeDSOject.ServiceType.Rows[RowIndex]["Type_ID"].ToString();

            ViewState.Add("ServiceTypeID", ServiceTypeID);

            if (FillCooperationForm(ServiceTypeID))
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

            ServiceTypeBiz ServiceTypeBizObject = new ServiceTypeBiz();
            ServiceTypeDS ServiceTypeDSObject = ServiceTypeBizObject.PopulateList("");

            int ServiceTypeID = Int32.Parse(ServiceTypeDSObject.ServiceType.Rows[RowIndex]["Type_ID"].ToString());

            string SQL = "delete from ServiceType where Type_ID=" + ServiceTypeID.ToString();
            Populate(SQL);

            ServiceTypeDSObject = ServiceTypeBizObject.PopulateList("");
            if (ServiceTypeDSObject.ServiceType.Rows.Count <= 0)
            {
                MultiView1.ActiveViewIndex = 1;
            }

            GridView1.DataSource = ServiceTypeBizObject.PopulateList("");
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

            ServiceTypeBiz ServiceTypeBizObject = new ServiceTypeBiz();
            ServiceTypeDS ServiceTypeDSOject = ServiceTypeBizObject.PopulateList("");

            string ServiceTypeID = ServiceTypeDSOject.ServiceType.Rows[RowIndex]["Type_ID"].ToString();

            ServiceTypeDSOject = ServiceTypeBizObject.Populate(Int32.Parse(ServiceTypeID));

            ViewState.Add("ServiceTypeID", ServiceTypeID);

            MultiView1.ActiveViewIndex = 2;

            Repeater1.DataSource = ServiceTypeDSOject;
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
            ViewState["ServiceTypeID"] = null;
        }
        catch (Exception ex)
        {
        }
    }
    protected void BTNAdd_Click(object sender, EventArgs e)
    {
        try
        {
            string ServiceTypeArabicName = TXTServiceTypeArabicName.Text;
            string ServiceTypeEnglishName = TXTServiceTypeEnglishName.Text;

            ServiceTypeBiz ServiceTypeBizObject = new ServiceTypeBiz();
            ServiceTypeDS ServiceTypeDSObject = new ServiceTypeDS();
            ServiceTypeDS.ServiceTypeRow ServiceTypeRowOject = ServiceTypeDSObject.ServiceType.NewServiceTypeRow();

            ServiceTypeRowOject.Service_Type_Arabic_Name = ServiceTypeArabicName;
            ServiceTypeRowOject.Service_Type_English_Name = ServiceTypeEnglishName;


            ServiceTypeDSObject.ServiceType.AddServiceTypeRow(ServiceTypeRowOject);
            ServiceTypeDSObject = ServiceTypeBizObject.InsertServiceType(ServiceTypeDSObject);

            GridView1.DataSource = ServiceTypeBizObject.PopulateList("");
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
            string ServiveTypeArabicName = TXTServiceTypeArabicName.Text;
            string ServiceTypeEnglishName = TXTServiceTypeEnglishName.Text;


            ServiceTypeBiz ServiceTypeBizObject = new ServiceTypeBiz();
            ServiceTypeDS ServiceTypeDSObject = ServiceTypeBizObject.Populate(Int32.Parse(ViewState["ServiceTypeID"].ToString()));

            ServiceTypeDSObject.ServiceType[0].Service_Type_Arabic_Name = ServiveTypeArabicName;
            ServiceTypeDSObject.ServiceType[0].Service_Type_English_Name = ServiceTypeEnglishName;

            ServiceTypeBizObject.UpdateServiceType(ServiceTypeDSObject);

            ClearCooperationForm();

            GridView1.DataSource = ServiceTypeBizObject.PopulateList("");
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
