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

public partial class UserControls_Cooporations : System.Web.UI.UserControl
{
    
    OrganizationsBiz OrganizationsBizObject = new OrganizationsBiz();
    OrganizationsDS OrganizationsDSObject;

    protected void Page_Load(object sender, EventArgs e)
    {
        TXTCoopEnglishName.Style["text-align"] = "left";
        TXTCoopEnglishContent.Style["text-align"] = "left";


        
        BaseDAL.ConnectionString = ConfigurationManager.ConnectionStrings["VSConnectionString"].ToString();

        if (Session["OrgID"] == null)
        {
            Response.Redirect("~/BackEnd/default.aspx");
        }
        if (Session["OrgID"] != null)
        {

            if (!IsPostBack)
            {
                CooporationsBiz CooporationsBizObject = new CooporationsBiz();
                CooporationsDS CooporationsDSObject = CooporationsBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());

                if (CooporationsDSObject != null && CooporationsDSObject.Cooporations.Rows.Count > 0)
                {
                    MultiView1.ActiveViewIndex = 0;
                }
                else
                {
                    ClearCooperationForm();
                    MultiView1.ActiveViewIndex = 1;

                    ViewState["CooporationID"] = null;
                }

                GridView1.DataSource = CooporationsDSObject;
                GridView1.DataBind();
                FillHighLights();
            }
        }
        
    }
   
    void ClearCooperationForm()
    {
        try
        {
            this.TXTCoopArabicName.Text = "";
            this.TXTCoopEnglishName.Text = "";
            this.TXTCoopAraicContent.Text = "";
            this.TXTCoopEnglishContent.Text = "";
            this.TXTCoopDate.Text = "";


            this.GridView2.DataSource = null;
            this.GridView2.DataBind();

            this.BTNAdd.Visible = true;;
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
            CooporationsBiz CooporationsBizObject = new CooporationsBiz();
            CooporationsDS CooporationsDSOject = CooporationsBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString() + " and Coop_ID = " + CooperationID);

            this.TXTCoopArabicName.Text = CooporationsDSOject.Cooporations.Rows[0]["Coop_Arabic_Name"].ToString();
            this.TXTCoopEnglishName.Text = CooporationsDSOject.Cooporations.Rows[0]["Coop_English_Name"].ToString();
            this.TXTCoopAraicContent.Text = CooporationsDSOject.Cooporations.Rows[0]["Coop_Arabic_Content"].ToString();
            this.TXTCoopEnglishContent.Text = CooporationsDSOject.Cooporations.Rows[0]["Coop_English_Content"].ToString();

            DateTime CoopDate = new DateTime();
            CoopDate = DateTime.Parse(CooporationsDSOject.Cooporations.Rows[0]["Coop_Date"].ToString());
            string DTCoopDate = CoopDate.Day.ToString() + "/" + CoopDate.Month + "/" + CoopDate.Year;

            //string CoopDate = CooporationsDSOject.Cooporations.Rows[0]["Coop_Date"].ToString();
            //string DTCoopDate = new DateTime(Int32.Parse(CoopDate.Substring(6, 4)), Int32.Parse(CoopDate.Substring(3, 2)), Int32.Parse(CoopDate.Substring(0, 2))).ToShortDateString();
            //string DTCoopDate = DateTime.Parse(CoopDate).ToShortDateString();
            this.TXTCoopDate.Text = DTCoopDate;

            CooporationCountriesBiz CooporationCountriesBizObject = new CooporationCountriesBiz();
            CooporationCountriesDS CooporationCountriesDSOject = CooporationCountriesBizObject.PopulateList("Coop_ID = " + CooperationID);

            GridView2.DataSource = CooporationCountriesDSOject;
            GridView2.DataBind();

            this.BTNAdd.Visible = false;
            this.BTNUpdate.Visible = true;
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    protected void LBTNEdit_Click(object sender, EventArgs e)
    {
        try
        {
            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            CooporationsBiz CooporationsBizObject = new CooporationsBiz();
            CooporationsDS CooporationsDSOject = CooporationsBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString());

            string CooperationID = CooporationsDSOject.Cooporations.Rows[RowIndex]["Coop_ID"].ToString();

            ViewState.Add("CooporationID", CooperationID);

            if (FillCooperationForm(CooperationID))
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
            Confirm("åá ÊÑíÏ ÇáÍÐÝ ¿");
            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            CooporationsBiz CooporationsBizObject = new CooporationsBiz();
            CooporationsDS CooporationsDSObject = CooporationsBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());

            int CooporationID = Int32.Parse(CooporationsDSObject.Cooporations.Rows[RowIndex]["Coop_ID"].ToString());

            string SQL = "delete from CooporationCountries where Coop_ID=" + CooporationID.ToString();
            Populate(SQL);

            SQL = "delete from Cooporations where Coop_ID=" + CooporationID.ToString();
            Populate(SQL);

            GridView1.DataSource = CooporationsBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());
            GridView1.DataBind();
            FillHighLights();
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
            ViewState["CooporationID"] = null;
        }
        catch (Exception ex)
        {
        }
    }
    protected void LBTNEdit_Click1(object sender, EventArgs e)
    {
        try
        {
            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            DataTable CountriesDT = new DataTable();
            CountriesDT = (DataTable)Session["CountriesDT"];
            GridView2.EditIndex = RowIndex;

            GridView2.DataSource = CountriesDT;
            GridView2.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    protected void LBTNDelete_Click1(object sender, EventArgs e)
    {
        try
        {
            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            DataTable CountriesDT = new DataTable();
            CountriesDT = (DataTable)Session["CountriesDT"];
            CountriesDT.Rows.RemoveAt(RowIndex);
            GridView2.DataSource = CountriesDT;
            GridView2.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    protected void LBTNCancel_Click1(object sender, EventArgs e)
    {
        try
        {
            DataTable CountriesDT = new DataTable();
            CountriesDT = (DataTable)Session["CountriesDT"];
            GridView2.EditIndex = -1;
            GridView2.DataSource = CountriesDT;
            GridView2.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    protected void LBTNSave_Click1(object sender, EventArgs e)
    {
        try
        {
            DataTable CountriesDT = new DataTable();
            CountriesDT = (DataTable)Session["CountriesDT"];
            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
            CountriesDT.Rows[RowIndex][0] = ((TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXTCountryArabicName")).Text;
            CountriesDT.Rows[RowIndex][1] = ((TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXTCountryEnglishName")).Text;

            GridView2.EditIndex = -1;
            GridView2.DataSource = CountriesDT;
            GridView2.DataBind();
        //    ClearCooperationForm();


        }
        catch (Exception ex)
        {
        }
    }
    protected void LBTNAdd_Click1(object sender, EventArgs e)
    {
        try
        {
            DataTable CountriesDT = new DataTable();
            CountriesDT = new DataTable();
            CountriesDT.Columns.Add("Second_Org_Arabic_Name");
            CountriesDT.Columns.Add("Second_Org_English_Name");
            foreach (GridViewRow row in GridView2.Rows)
            {
                DataRow Row = CountriesDT.NewRow();
                Row[0] = ((Literal)(row.Controls[0].Controls[1])).Text;
                Row[1] = ((Literal)(row.Controls[1].Controls[1])).Text;
                CountriesDT.Rows.Add(Row);
            }
            DataRow Row1 = CountriesDT.NewRow();
            Row1[0] = ((TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXTCountryArabicName")).Text;
            Row1[1] = ((TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXTCountryEnglishName")).Text;
            CountriesDT.Rows.Add(Row1);

            Session.Add("CountriesDT", CountriesDT);
            GridView2.DataSource = CountriesDT;
            GridView2.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    protected void BTNAdd_Click(object sender, EventArgs e)
    {
        try
        {
            string CoopArabicName = TXTCoopArabicName.Text;
            string CoopEnglishName = TXTCoopEnglishName.Text;
            string CoopArabicContent = TXTCoopAraicContent.Text;
            string CoopEnglishContent = TXTCoopEnglishContent.Text;
            string CoopDate = TXTCoopDate.Text;
            int OrgID = Int32.Parse(Session["OrgID"].ToString());

            DateTime DTCoopDate = new DateTime(Int32.Parse(CoopDate.Substring(6, 4)), Int32.Parse(CoopDate.Substring(3, 2)), Int32.Parse(CoopDate.Substring(0, 2)));
            //DateTime DTCoopDate = DateTime.Parse(CoopDate);

            CooporationsBiz CooporationsBizObject = new CooporationsBiz();
            CooporationsDS CooporationsDSObject = new CooporationsDS();
            CooporationsDS.CooporationsRow CooporationsRowOject = CooporationsDSObject.Cooporations.NewCooporationsRow();

            CooporationsRowOject.ORG_ID = OrgID;
            CooporationsRowOject.Coop_Arabic_Name = CoopArabicName;
            CooporationsRowOject.Coop_English_Name = CoopEnglishName;
            CooporationsRowOject.Coop_Arabic_Content = CoopArabicContent;
            CooporationsRowOject.Coop_English_Content = CoopEnglishContent;
            CooporationsRowOject.Coop_Date = DTCoopDate;

            CooporationsDSObject.Cooporations.AddCooporationsRow(CooporationsRowOject);
            CooporationsDSObject = CooporationsBizObject.InsertCooporations(CooporationsDSObject);

            GridView1.DataSource = CooporationsBizObject.PopulateList("ORG_ID=" + OrgID);
            GridView1.DataBind();
            FillHighLights();

            CooporationCountriesBiz CooporationCountriesBizObject = new CooporationCountriesBiz();
            CooporationCountriesDS CooporationCountriesDSObject = new CooporationCountriesDS();
           
            string SqlW = "";
            foreach (GridViewRow GVRow in GridView2.Rows)
            {
                      //mar 2014 
                //CooporationCountriesDS.CooporationCountriesRow CooporationCountriesRowObject = CooporationCountriesDSObject.CooporationCountries.NewCooporationCountriesRow();             
                //CooporationCountriesRowObject.Coop_Country_ID = Decimal.Parse(M_C.ToString()); 
                //CooporationCountriesRowObject.Coop_ID = Int32.Parse(CooporationsDSObject.Cooporations.Rows[0]["Coop_ID"].ToString());
                //CooporationCountriesRowObject.Second_Org_Arabic_Name = ((Literal)(GVRow.Controls[0].Controls[1])).Text;
                //CooporationCountriesRowObject.Second_Org_English_Name = ((Literal)(GVRow.Controls[1].Controls[1])).Text; 
                //CooporationCountriesDSObject.CooporationCountries.AddCooporationCountriesRow(CooporationCountriesRowObject);
               //Alaa 2014
             //  CooporationCountriesBizObject.InsertCooporationCountries(CooporationCountriesDSObject);
              SqlW = " INSERT INTO CooporationCountries (Coop_ID, Second_Org_Arabic_Name, Second_Org_English_Name) values( " + Int32.Parse(CooporationsDSObject.Cooporations.Rows[0]["Coop_ID"].ToString()) + ", '" + ((Literal)(GVRow.Controls[0].Controls[1])).Text + "' ,'" + ((Literal)(GVRow.Controls[1].Controls[1])).Text + "' )";
               Populate(SqlW); 
              //test.Text = test.Text + SqlW;
              //test.Visible = true;
         
              
            }
         //   test.Visible = true;
            ClearCooperationForm();
            MultiView1.ActiveViewIndex = 0;
        //    CoId.clear();
           Response.Redirect("Cooporations.aspx");
          

        }
        catch (Exception ex)
        {
        }
    }
    protected void BTNUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string CoopArabicName = TXTCoopArabicName.Text;
            string CoopEnglishName = TXTCoopEnglishName.Text;
            string CoopArabicContent = TXTCoopAraicContent.Text;
            string CoopEnglishContent = TXTCoopEnglishContent.Text;
            string CoopDate = TXTCoopDate.Text;
            int OrgID = Int32.Parse(Session["OrgID"].ToString());

            DateTime DTCoopDate = new DateTime(Int32.Parse(CoopDate.Substring(6, 4)), Int32.Parse(CoopDate.Substring(3, 2)), Int32.Parse(CoopDate.Substring(0, 2)));
            //DateTime DTCoopDate = DateTime.Parse(CoopDate);

            CooporationsBiz CooporationsBizObject = new CooporationsBiz();
            CooporationsDS CooporationsDSObject = CooporationsBizObject.Populate(Int32.Parse(ViewState["CooporationID"].ToString()));

            CooporationsDSObject.Cooporations[0].ORG_ID = OrgID;
            CooporationsDSObject.Cooporations[0].Coop_Arabic_Name = CoopArabicName;
            CooporationsDSObject.Cooporations[0].Coop_English_Name = CoopEnglishName;
            CooporationsDSObject.Cooporations[0].Coop_Arabic_Content = CoopArabicContent;
            CooporationsDSObject.Cooporations[0].Coop_English_Content = CoopEnglishContent;
            CooporationsDSObject.Cooporations[0].Coop_Date = DTCoopDate;

            CooporationsBizObject.UpdateCooporations(CooporationsDSObject);

            string SQL = "delete from CooporationCountries where Coop_ID=" + ViewState["CooporationID"].ToString();
            Populate(SQL);

            CooporationCountriesBiz CooporationCountriesBizObject = new CooporationCountriesBiz();
            CooporationCountriesDS CooporationCountriesDSObject = new CooporationCountriesDS();

            foreach (GridViewRow GVRow in GridView2.Rows)
            {
                //mar 2014
                //CooporationCountriesDS.CooporationCountriesRow CooporationCountriesRowObject = CooporationCountriesDSObject.CooporationCountries.NewCooporationCountriesRow();
                //CooporationCountriesRowObject.Coop_Country_ID = Int32.Parse('1'.ToString()); 
                //CooporationCountriesRowObject.Coop_ID = Int32.Parse(CooporationsDSObject.Cooporations.Rows[0]["Coop_ID"].ToString());
                //CooporationCountriesRowObject.Second_Org_Arabic_Name = ((Literal)(GVRow.Controls[0].Controls[1])).Text;
                //CooporationCountriesRowObject.Second_Org_English_Name = ((Literal)(GVRow.Controls[1].Controls[1])).Text;
                //CooporationCountriesDSObject.CooporationCountries.AddCooporationCountriesRow(CooporationCountriesRowObject);
                //CooporationCountriesBizObject.InsertCooporationCountries(CooporationCountriesDSObject);
                SQL = " INSERT INTO CooporationCountries (Coop_ID, Second_Org_Arabic_Name, Second_Org_English_Name) values( " + Int32.Parse(CooporationsDSObject.Cooporations.Rows[0]["Coop_ID"].ToString()) + ", '" + ((Literal)(GVRow.Controls[0].Controls[1])).Text + "' ,'" + ((Literal)(GVRow.Controls[1].Controls[1])).Text + "' )";
                Populate(SQL); 
            }

            GridView1.EditIndex = -1;
            GridView1.DataSource = CooporationsBizObject.PopulateList("ORG_ID=" + OrgID);
            GridView1.DataBind();
            FillHighLights();

            ClearCooperationForm();

            MultiView1.ActiveViewIndex = 0;
            Response.Redirect("Cooporations.aspx");

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
    protected void lBTNSecondCountry_Click(object sender, EventArgs e)
    {
        try
        {
            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            CooporationsBiz CooporationsBizObject = new CooporationsBiz();
            CooporationsDS CooporationsDSOject = CooporationsBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString());

            string CooperationID = CooporationsDSOject.Cooporations.Rows[RowIndex]["Coop_ID"].ToString();

            ViewState.Add("CooporationID", CooperationID);

            CooporationCountriesBiz CooporationCountriesBizObject = new CooporationCountriesBiz();
            CooporationCountriesDS CooporationCountriesDSObject = CooporationCountriesBizObject.PopulateList("Coop_ID =" + CooperationID);

            this.GridView2.DataSource = CooporationCountriesDSObject;
            this.GridView2.DataBind();
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

            CooporationsBiz CooporationsBizObject = new CooporationsBiz();
            CooporationsDS CooporationsDSOject = CooporationsBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString());

            string CooperationID = CooporationsDSOject.Cooporations.Rows[RowIndex]["Coop_ID"].ToString();

            CooporationsDSOject = CooporationsBizObject.Populate(Int32.Parse(CooperationID));

            ViewState.Add("CooporationID", CooperationID);

            MultiView1.ActiveViewIndex = 2;

            Repeater1.DataSource = CooporationsDSOject;
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
                CooporationCountriesBiz CooporationCountriesBizObject = new CooporationCountriesBiz();
                CooporationCountriesDS CooporationCountriesDSOject = CooporationCountriesBizObject.PopulateList("Coop_ID = " + ViewState["CooporationID"].ToString());

                ((Repeater)e.Item.FindControl("Repeater2")).DataSource = CooporationCountriesDSOject;
                ((Repeater)e.Item.FindControl("Repeater2")).DataBind();

                DataRow dr = ((DataRowView)e.Item.DataItem).Row;
                string CoopDate = dr["Coop_Date"].ToString();
                //string DTCoopDate = new DateTime(Int32.Parse(CoopDate.Substring(6, 4)), Int32.Parse(CoopDate.Substring(3, 2)), Int32.Parse(CoopDate.Substring(0, 2))).ToShortDateString();
                string DTCoopDate = DateTime.Parse(CoopDate).ToShortDateString();
                ((Literal)e.Item.FindControl("Literal16")).Text = DTCoopDate;
            }
            catch (Exception ex)
            {
            }
        }
    }
    protected void LBTNClose_Click(object sender, EventArgs e)
    {
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

                CooporationsBiz CooporationsBizObject = new CooporationsBiz();
                CooporationsDS CooporationsDSOject = CooporationsBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString());

                decimal RecordID = Decimal.Parse(CooporationsDSOject.Cooporations.Rows[RowIndex]["Coop_ID"].ToString());
                decimal RecordType = 2;
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

                CooporationsBiz CooporationsBizObject = new CooporationsBiz();
                CooporationsDS CooporationsDSOject = CooporationsBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString());

                decimal RecordID = Decimal.Parse(CooporationsDSOject.Cooporations.Rows[RowIndex]["Coop_ID"].ToString());
                string Type = "2";

                HighLightsBiz HighLightsBizObject = new HighLightsBiz();
                HighLightsDS HighLightsDSObject = HighLightsBizObject.PopulateList("RecordID=" + RecordID + " and Type=" + Type);

                string HLID = HighLightsDSObject.HighLights.Rows[0]["HLID"].ToString();

                string SQL = "delete from HighLights where HLID=" + HLID;
                Populate(SQL);
            }

        }
        catch (Exception ex)
        {
        }
    }
    void FillHighLights()
    {
        foreach (GridViewRow GVRow in GridView1.Rows)
        {
            int RowIndex = GVRow.RowIndex;

            CooporationsBiz CooporationsBizObject = new CooporationsBiz();
            CooporationsDS CooporationsDSOject = CooporationsBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString());

            decimal RecordID = Decimal.Parse(CooporationsDSOject.Cooporations.Rows[RowIndex]["Coop_ID"].ToString());
            string Type = "2";

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
