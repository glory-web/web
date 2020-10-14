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

public partial class UserControls_News : System.Web.UI.UserControl
{
    OrganizationsBiz OrganizationsBizObject = new OrganizationsBiz();
    OrganizationsDS OrganizationsDSObject;
    //Boolean updateN ;
    static public int updateN;

    protected void Page_Load(object sender, EventArgs e)
    {
        BaseDAL.ConnectionString = ConfigurationManager.ConnectionStrings["VSConnectionString"].ToString();
        TXTNewsEnglishTitle.Style["text-align"] = "left";
        TXTNewsEnglishContent.Style["text-align"] = "left";


        if (Session["OrgID"] == null)
        {
            Response.Redirect("~/BackEnd/default.aspx");
        }
        if (Session["OrgID"] != null)
        {

            if (!IsPostBack)
            {
                NewsCategoryBiz NewsCategoryBizObject = new NewsCategoryBiz();
                NewsCategoryDS NewsCategoryDSObject = NewsCategoryBizObject.PopulateList("");

                DDLNewsCategory.DataSource = NewsCategoryDSObject;
                DDLNewsCategory.DataBind();

                DDLNewsCategory_SelectedIndexChanged(DDLNewsCategory, e);
                updateN = 0;
            }
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
            updateN = 1;
            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            NewsBiz NewsBizObject = new NewsBiz();
            NewsDS NewsDSOject = NewsBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString() + "and Cat_ID=" + DDLNewsCategory.SelectedValue);

            string NewsID = NewsDSOject.News.Rows[RowIndex]["News_ID"].ToString();

            ViewState.Add("NewsID", NewsID);

            if (FillCooperationForm(NewsID))
            {
                MultiView1.ActiveViewIndex = 1;
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void LBTNDelete_Click1(object sender, EventArgs e)
    {
        try
        {
            Confirm("åá ÊÑíÏ ÇáÍÐÝ ¿");

            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            NewsBiz NewsBizObject = new NewsBiz();
            NewsDS NewsDSOject = NewsBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString() + "and Cat_ID = " + DDLNewsCategory.SelectedValue);

            string NewsID = NewsDSOject.News.Rows[RowIndex]["News_ID"].ToString();

            ///////////////////////////////// Delete Uploaded News Image //////////////////////////////////
            if (NewsDSOject.News.Rows[0]["ImagePath"].ToString() != null || NewsDSOject.News.Rows[0]["ImagePath"].ToString() != "")
            {
                DirectoryInfo DirectoryInfoObject = new DirectoryInfo(Server.MapPath("~//GovsFiles//ORG_" + Session["OrgID"].ToString() + "_Files//News"));
                if (!DirectoryInfoObject.Exists)
                {
                    DirectoryInfoObject.Create();
                }
                try
                {
                    FileInfo ServerProjectFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + NewsDSOject.News.Rows[0]["ImagePath"].ToString());
                    if (ServerProjectFile.Exists)
                        ServerProjectFile.Delete();
                }
                catch (Exception ex)
                {
                }
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////
            string SQL = "delete from News where News_ID=" + NewsID.ToString();
            Populate(SQL);

            GridView1.DataSource = NewsBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString() + " and Cat_ID = " + DDLNewsCategory.SelectedValue);
            GridView1.DataBind();
            FillHighLights();
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

            NewsBiz NewsBizObject = new NewsBiz();
            NewsDS NewsDSOject = NewsBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString() + "and Cat_ID = " + DDLNewsCategory.SelectedValue);

            string NewsID = NewsDSOject.News.Rows[RowIndex]["News_ID"].ToString();

            NewsDSOject = NewsBizObject.Populate(Int32.Parse(NewsID));

            ViewState.Add("NewsID", NewsID);

            MultiView1.ActiveViewIndex = 2;

            Repeater1.DataSource = NewsDSOject;
            Repeater1.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    protected void LBTNAdd_Click1(object sender, EventArgs e)
    {
        try
        {
            ClearCooperationForm();
            MultiView1.ActiveViewIndex = 1;
            ViewState["NewsID"] = null;
        }
        catch (Exception ex)
        {
        }
    }

    void ClearCooperationForm()
    {
        try
        {
            this.TXTNewsArabicTitle.Text = "";
            this.TXTNewsEnglishTitle.Text = "";
            this.TXTNewsArabicContent.Text = "";
            this.TXTNewsEnglishContent.Text = "";
            this.TXTNewsDate.Text = "";
            this.TXTNewsValidToDate.Text = "";
            this.CHBIsPublished.Checked = false;

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
            NewsBiz NewsBizObject = new NewsBiz();
            NewsDS NewsDSOject = NewsBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString() + " and Cat_ID = " + DDLNewsCategory.SelectedValue + "and News_ID=" + CooperationID);

            this.TXTNewsArabicTitle.Text = NewsDSOject.News.Rows[0]["News_Arabic_Title"].ToString();
            this.TXTNewsEnglishTitle.Text = NewsDSOject.News.Rows[0]["News_English_Title"].ToString();
            this.TXTNewsArabicContent.Text = NewsDSOject.News.Rows[0]["News_Arabic_Content"].ToString();
            this.TXTNewsEnglishContent.Text = NewsDSOject.News.Rows[0]["News_English_Content"].ToString();

           // string NewsDate = NewsDSOject.News.Rows[0]["News_Date"].ToString();
            //string DTNewsDate = new DateTime(Int32.Parse(NewsDate.Substring(6, 4)), Int32.Parse(NewsDate.Substring(3, 2)), Int32.Parse(NewsDate.Substring(0, 2))).ToShortDateString();
         //   string DTNewsDate = DateTime.Parse(NewsDate).ToShortDateString();
            DateTime NewsDate = new DateTime();
            NewsDate = DateTime.Parse(NewsDSOject.News.Rows[0]["News_Date"].ToString());
            string DTNewsDate =NewsDate.Day.ToString()+"/"+NewsDate.Month+"/"+NewsDate.Year;
            this.TXTNewsDate.Text = DTNewsDate;

////////////////////////////////////////////////////////////////////////
            DateTime NewsValidateDate = new DateTime();
            NewsValidateDate = DateTime.Parse(NewsDSOject.News.Rows[0]["News_ValidTo_Date"].ToString());
            string DTNewsValidToDate = NewsValidateDate.Day.ToString() + "/" + NewsValidateDate.Month + "/" + NewsValidateDate.Year; ;
            this.TXTNewsValidToDate.Text = DTNewsValidToDate;
          
            if (Boolean.Parse(NewsDSOject.News.Rows[0]["IsPublish"].ToString()))
                this.CHBIsPublished.Checked = true;

            LITFileName.Visible = true;
            LITFileName.Text = NewsDSOject.News.Rows[0]["ImagePath"].ToString();
            FileDelete.Visible = true;

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
            string NewsArabicTitle = TXTNewsArabicTitle.Text;
            string NewsEnglishTitle = TXTNewsEnglishTitle.Text;
            string NewsArabicContent = TXTNewsArabicContent.Text;
            string NewsEnglishContent = TXTNewsEnglishContent.Text;
            string NewsDate = TXTNewsDate.Text;
            string NewsValidToDate = TXTNewsValidToDate.Text;
            bool NewsISPublished = CHBIsPublished.Checked;
            int OrgID = Int32.Parse(Session["OrgID"].ToString());

            DateTime DTNewsDate = new DateTime(Int32.Parse(NewsDate.Substring(6, 4)), Int32.Parse(NewsDate.Substring(3, 2)), Int32.Parse(NewsDate.Substring(0, 2)));
            DateTime DTNewsValidToDate = new DateTime(Int32.Parse(NewsValidToDate.Substring(6, 4)), Int32.Parse(NewsValidToDate.Substring(3, 2)), Int32.Parse(NewsValidToDate.Substring(0, 2)));

            NewsBiz NewsBizObject = new NewsBiz();
            NewsDS NewsDSObject = new NewsDS();
            NewsDS.NewsRow NewsRowOject = NewsDSObject.News.NewNewsRow();

            NewsRowOject.ORG_ID = OrgID;
            NewsRowOject.Cat_ID = Int32.Parse(DDLNewsCategory.SelectedValue);
            NewsRowOject.News_Arabic_Title = NewsArabicTitle;
            NewsRowOject.News_English_Title = NewsEnglishTitle;
            NewsRowOject.News_Arabic_Content = NewsArabicContent;
            NewsRowOject.News_English_Content = NewsEnglishContent;
            NewsRowOject.News_Date = DTNewsDate;
            NewsRowOject.News_ValidTo_Date = DTNewsValidToDate;
            NewsRowOject.IsPublish = NewsISPublished;

            /////////////////////////////Upload Image ////////////////////////////////
            if (FUNewsImage.HasFile)
            {
                DirectoryInfo DirectoryInfoObject = new DirectoryInfo(Server.MapPath("~//GovsFiles//ORG_" + Session["OrgID"].ToString() + "_Files//News"));
                if (!DirectoryInfoObject.Exists)
                {
                    DirectoryInfoObject.Create();
                }


                FileInfo ServerProjectFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + FUNewsImage.FileName);
                if (ServerProjectFile.Exists)
                    ServerProjectFile.Delete();
                FUNewsImage.SaveAs(DirectoryInfoObject.FullName + "\\" + FUNewsImage.FileName);
                NewsRowOject.ImagePath = FUNewsImage.FileName;
            }
            else
            {
                NewsRowOject.ImagePath = "";
            }
            //////////////////////////////////////////////////////////////////////////

            NewsDSObject.News.AddNewsRow(NewsRowOject);
            NewsDSObject = NewsBizObject.InsertNews(NewsDSObject);

            GridView1.DataSource = NewsBizObject.PopulateList("ORG_ID=" + OrgID + " and Cat_ID = "+DDLNewsCategory.SelectedValue);
            GridView1.DataBind();
            FillHighLights();

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
            string NewsArabicTitle = TXTNewsArabicTitle.Text;
            string NewsEnglishTitle = TXTNewsEnglishTitle.Text;
            string NewsArabicContent = TXTNewsArabicContent.Text;
            string NewsEnglishContent = TXTNewsEnglishContent.Text;
            string NewsDate = TXTNewsDate.Text;
            string NewsValidToDate= TXTNewsValidToDate.Text;
            bool NewsIsPublished = CHBIsPublished.Checked;
            int OrgID = Int32.Parse(Session["OrgID"].ToString());

            DateTime DTNewsDate = new DateTime(Int32.Parse(NewsDate.Substring(6, 4)),Int32.Parse(NewsDate.Substring(3, 2)),Int32.Parse(NewsDate.Substring(0, 2)));

            DateTime DTNewsValidToDate = new DateTime(Int32.Parse(NewsValidToDate.Substring(6, 4)), Int32.Parse(NewsValidToDate.Substring(3, 2)), Int32.Parse(NewsValidToDate.Substring(0, 2)));

            NewsBiz NewsBizObject = new NewsBiz();
            NewsDS NewsDSObject = NewsBizObject.Populate(Int32.Parse(ViewState["NewsID"].ToString()));

            NewsDSObject.News[0].ORG_ID = OrgID;
            NewsDSObject.News[0].Cat_ID = Int32.Parse(DDLNewsCategory.SelectedValue);
            NewsDSObject.News[0].News_Arabic_Title = NewsArabicTitle;
            NewsDSObject.News[0].News_English_Title = NewsEnglishTitle;
            NewsDSObject.News[0].News_Arabic_Content = NewsArabicContent;
            NewsDSObject.News[0].News_English_Content = NewsEnglishContent;
            NewsDSObject.News[0].News_Date = DTNewsDate;
            NewsDSObject.News[0].News_ValidTo_Date = DTNewsValidToDate;
            NewsDSObject.News[0].IsPublish = NewsIsPublished;

            //////////////////////////////////Upload News Image////////////////////////
            if (FUNewsImage.HasFile)
            {
                DirectoryInfo DirectoryInfoObject = new DirectoryInfo(Server.MapPath("~//GovsFiles//ORG_" + Session["OrgID"].ToString() + "_Files//News"));
                if (!DirectoryInfoObject.Exists)
                {
                    DirectoryInfoObject.Create();
                }

                FileInfo ServerOldProjectsFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + NewsDSObject.News[0].ImagePath);
                if (ServerOldProjectsFile.Exists)
                    ServerOldProjectsFile.Delete();

                FileInfo ServerOrojectsFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + FUNewsImage.FileName);
                if (ServerOrojectsFile.Exists)
                    ServerOrojectsFile.Delete();
                FUNewsImage.SaveAs(DirectoryInfoObject.FullName + "\\" + FUNewsImage.FileName);
                NewsDSObject.News[0].ImagePath = FUNewsImage.FileName;
            }
            else
             
            if (LITFileName.Text == "")
            {
                NewsDSObject.News[0].ImagePath = "";
            }
            ///////////////////////////////////////////////////////////////////////////

            NewsBizObject.UpdateNews(NewsDSObject);

            GridView1.EditIndex = -1;
            GridView1.DataSource = NewsBizObject.PopulateList("ORG_ID=" + OrgID + "and Cat_ID="+DDLNewsCategory.SelectedValue);
            GridView1.DataBind();
            FillHighLights();


            updateN = 0;
            ClearCooperationForm();

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
                DataRow dr = ((DataRowView)e.Item.DataItem).Row;
                string NewsDate = dr["News_Date"].ToString();
                string DTNewsDate = DateTime.Parse(NewsDate).ToShortDateString();

                ((Literal)e.Item.FindControl("Literal12")).Text = DTNewsDate;


                string NewsValidToDate = dr["News_ValidTo_Date"].ToString();
                string DTNewsValidToDate = DateTime.Parse(NewsValidToDate).ToShortDateString();

                ((Literal)e.Item.FindControl("Literal14")).Text = DTNewsValidToDate;

                ((CheckBox)e.Item.FindControl("CheckBox2")).Enabled = false;
            }
            catch (Exception ex)
            {
            }
        }
    }
    protected void DDLOrganizationsName_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void DDLNewsCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (updateN==0)
        {
            NewsBiz NewsBizObject = new NewsBiz();
            NewsDS NewsDSObject = NewsBizObject.PopulateList("Cat_ID=" + DDLNewsCategory.SelectedValue + " and ORG_ID=" + Session["OrgID"].ToString());

            if (NewsDSObject != null && NewsDSObject.News.Rows.Count > 0)
            {
                MultiView1.ActiveViewIndex = 0;
            }
            else
            {
                ClearCooperationForm();
                MultiView1.ActiveViewIndex = 1;

                ViewState["NewsID"] = null;
            }

            GridView1.DataSource = NewsDSObject;
            GridView1.DataBind();
            FillHighLights();
        }
    }
    protected void CHBHighlight_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox CHBVisable = ((CheckBox)sender);
            if (CHBVisable.Checked)
            {
                int RowIndex = ((GridViewRow)((CheckBox)sender).Parent.Parent).RowIndex;

                NewsBiz NewsBizObject = new NewsBiz();
                NewsDS NewsDSOject = NewsBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString() + "and Cat_ID = " + DDLNewsCategory.SelectedValue);

                decimal RecordID = Decimal.Parse(NewsDSOject.News.Rows[RowIndex]["News_ID"].ToString());
                decimal RecordType = 4;
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

                NewsBiz NewsBizObject = new NewsBiz();
                NewsDS NewsDSOject = NewsBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString() + "and Cat_ID = " + DDLNewsCategory.SelectedValue);

                decimal RecordID = Decimal.Parse(NewsDSOject.News.Rows[RowIndex]["News_ID"].ToString());
                string Type = "4";

                HighLightsBiz HighLightsBizObject = new HighLightsBiz();
                HighLightsDS HighLightsDSObject = HighLightsBizObject.PopulateList("RecordID=" + RecordID + " and Type=" + Type);

                string HLID = HighLightsDSObject.HighLights.Rows[0]["HLID"].ToString();

                string SQL = "delete from HighLights where HLID=" + HLID;
                Populate(SQL);

                SQL = "delete from HighlightSet where HLID = " + HLID;
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

            NewsBiz NewsBizObject = new NewsBiz();
            NewsDS NewsDSOject = NewsBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString() + "and Cat_ID = " + DDLNewsCategory.SelectedValue);

            decimal RecordID = Decimal.Parse(NewsDSOject.News.Rows[RowIndex]["News_ID"].ToString());
            string Type = "4";

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
    protected void FileDel_Click(object sender, EventArgs e)
    {     
      
        LITFileName.Text = "";
        FileDelete.Visible = false;
    }
}
