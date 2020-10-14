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

public partial class UserControls_Brochures : System.Web.UI.UserControl
{
    
    OrganizationsBiz OrganizationsBizObject = new OrganizationsBiz();
    OrganizationsDS OrganizationsDSObject;
    BrochureFilesDS BrochureFilesDSObject = new BrochureFilesDS();

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

                DDLBrocureCategory.DataSource = BrochuresCategoryDSObject;
                DDLBrocureCategory.DataBind();

                DDLBrocureCategory_SelectedIndexChanged(DDLBrocureCategory, e);


                DDLSource.DataSource = OrganizationsBizObject.PopulateList("Org_Type_ID=6 or Org_Type_ID=7");
                DDLSource.DataBind();
            }
        }
    }
    protected void LTNDalete_Click(object sender, EventArgs e)
    {
        try
        {
            Confirm("åá ÊÑíÏ ÍÐÝ åÐÇ ÇáãäÔæÑ ¿");

            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            BrochuresBiz BrochuresBizObject = new BrochuresBiz();
            BrochuresDS BrochuresDSObject = BrochuresBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());

            int BrochureID = Int32.Parse(BrochuresDSObject.Brochures.Rows[RowIndex]["Brochure_ID"].ToString());


            BrochureFilesBiz BrochureFilesBizObject = new BrochureFilesBiz();
            //BrochureFilesDS 
            BrochureFilesDSObject = BrochureFilesBizObject.PopulateList("Brochure_ID=" + BrochureID.ToString());

            if (BrochureFilesDSObject != null && BrochureFilesDSObject.BrochureFiles.Rows.Count > 0)
            {
                int FileID = Int32.Parse(BrochureFilesDSObject.BrochureFiles.Rows[0]["File_ID"].ToString());

                string SQL = "delete from BrochureFiles where File_ID=" + FileID.ToString();
                Populate(SQL);

                ///////////////////////////////////////////// CV and Photo Not Complete ////////////////////
                if (BrochureFilesDSObject.BrochureFiles.Rows[0]["File_Path"].ToString() != null || BrochureFilesDSObject.BrochureFiles.Rows[0]["File_Path"].ToString() != "")
                {
                    DirectoryInfo DirectoryInfoObject = new DirectoryInfo(Server.MapPath("~//GovsFiles//ORG_" + Session["OrgID"].ToString() + "_Files//Brochures"));
                    if (!DirectoryInfoObject.Exists)
                    {
                        DirectoryInfoObject.Create();
                    }
                    try
                    {
                        FileInfo ServerProjectFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + BrochureFilesDSObject.BrochureFiles.Rows[0]["File_Path"].ToString());
                        if (ServerProjectFile.Exists)
                            ServerProjectFile.Delete();
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            string SQL1 = "delete from Brochures where Brochure_ID=" + BrochureID.ToString();
            Populate(SQL1);

            GridView1.DataSource = BrochuresBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());
            GridView1.DataBind();
            FillHighLights();
        }
        catch (Exception ex)
        {
        }
    }
    protected void LBTNUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            BrochuresBiz BrochuresBizObject = new BrochuresBiz();
            BrochuresDS BrochuresDSObject = BrochuresBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());

            int BrochureID = Int32.Parse(BrochuresDSObject.Brochures.Rows[RowIndex]["Brochure_ID"].ToString());

            ViewState.Add("BrochureID", BrochureID);
            GridView1.EditIndex = RowIndex;

            GridView1.DataSource = BrochuresDSObject;
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
            ViewState["BrochureID"] = null;
        }
        catch (Exception ex)
        {
        }
    }
    void ClearCooperationForm()
    {
        try
        {
            this.TXTBrochureArabicName.Text = "";
            this.TXTBrochureEnglishName.Text = "";
            this.TXTBrochureDate.Text = "";
            this.TXTCost.Text = "";
            //this.TXTExistingPlace.Text = "";
            DDLBrochureType.SelectedIndex = 0;
            DDLSource.SelectedIndex = 0;

            this.BTNAdd.Visible = true; ;
            this.BTNUpdate.Visible = false;


            DDLSource.DataSource = OrganizationsBizObject.PopulateList("Org_Type_ID=6 or Org_Type_ID=7");
            DDLSource.DataBind();
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
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ((Literal)e.Row.FindControl("LITBrochureDate")).Text = ((Literal)e.Row.FindControl("LITBrochureDate")).Text.Substring(6, 4) + "/" + ((Literal)e.Row.FindControl("LITBrochureDate")).Text.Substring(3, 2) + "/" + ((Literal)e.Row.FindControl("LITBrochureDate")).Text.Substring(0, 2);
        }
    }

    protected void LBTNEdit_Click(object sender, EventArgs e)
    {
        try
        {
            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            BrochuresBiz BrochuresBizObject = new BrochuresBiz();
            BrochuresDS BrochuresDSObject = BrochuresBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString());

            string BrochureID = BrochuresDSObject.Brochures.Rows[RowIndex]["Brochure_ID"].ToString();

            ViewState.Add("BrochureID", BrochureID);

            if (FillCooperationForm(BrochureID))
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
            BrochuresBiz BrochuresBizObject = new BrochuresBiz();
            BrochuresDS BrochuresDSObject = BrochuresBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString() + " and Brochure_ID = " + CooperationID);

            this.TXTBrochureArabicName.Text = BrochuresDSObject.Brochures.Rows[0]["Brochure_Arabic_Name"].ToString();
            this.TXTBrochureEnglishName.Text = BrochuresDSObject.Brochures.Rows[0]["Brochure_English_Name"].ToString();
            this.TXTCost.Text = BrochuresDSObject.Brochures.Rows[0]["Brochure_Cost"].ToString();

            //this.TXTExistingPlace.Text = BrochuresDSObject.Brochures.Rows[0]["Brochure_Existance_Place"].ToString();
            if (BrochuresDSObject.Brochures.Rows[0]["Brochure_Existance_Place"].ToString() == "")
                this.DDLSource.SelectedIndex = 0;
            else
                this.DDLSource.SelectedItem.Text = BrochuresDSObject.Brochures.Rows[0]["Brochure_Existance_Place"].ToString();

            if (BrochuresDSObject.Brochures.Rows[0]["Brochure_Type"].ToString() == "True")
            {
                DDLBrochureType.SelectedIndex = 0;
                DDLBrochureType_SelectedIndexChanged(DDLBrochureType, new EventArgs());
            }
            else
            {
                DDLBrochureType.SelectedIndex = 1;
                DDLBrochureType_SelectedIndexChanged(DDLBrochureType, new EventArgs());

            }

            string BrochureDateBeforCut = BrochuresDSObject.Brochures.Rows[0]["Brochure_Date"].ToString();
            //string DTBrochureDate = new DateTime(Int32.Parse(BrochureDateBeforCut.Substring(6, 4)), Int32.Parse(BrochureDateBeforCut.Substring(3, 2)), Int32.Parse(BrochureDateBeforCut.Substring(0, 2))).ToShortDateString();
            string DTBrochureDate = DateTime.Parse(BrochureDateBeforCut).ToShortDateString();

            this.TXTBrochureDate.Text = DTBrochureDate;


            LITFileName.Visible = true;
            BrochureFilesBiz BrochureFilesBizObject = new BrochureFilesBiz();
            BrochureFilesDS BrochureFilesDSObjectM = BrochureFilesBizObject.PopulateList("Brochure_ID=" + CooperationID);
            if (BrochureFilesDSObjectM.BrochureFiles.Count > 0)
            {
                LITFileName.Text = BrochureFilesDSObjectM.BrochureFiles.Rows[0]["File_Path"].ToString();
                FileDel.Visible = true;
            }
            
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
            string BrochureArabicName = TXTBrochureArabicName.Text;
            string BrochureEnglishName = TXTBrochureEnglishName.Text;
            string BrochureDate = TXTBrochureDate.Text;
            string BrochureExistingPlace = DDLSource.SelectedItem.Text;
            //string BrochureExistingPlace = TXTExistingPlace.Text;
            int OrgID = Int32.Parse(Session["OrgID"].ToString());

            string BrochureCost = "";
            if (CostRow.Visible == false)
                BrochureCost = "0";
            else
                BrochureCost = TXTCost.Text;

            //DateTime DTBrochureDate = new DateTime(Int32.Parse(BrochureDate.Substring(6, 4)), Int32.Parse(BrochureDate.Substring(3, 2)), Int32.Parse(BrochureDate.Substring(0, 2)));
            DateTime DTBrochureDate = DateTime.Parse(BrochureDate);

            BrochuresBiz BrochuresBizObject = new BrochuresBiz();
            BrochuresDS BrochuresDSObject = new BrochuresDS();
            BrochuresDS.BrochuresRow BrochureRowOject = BrochuresDSObject.Brochures.NewBrochuresRow();

            BrochureRowOject.ORG_ID = OrgID;
            BrochureRowOject.Cat_ID = Decimal.Parse(DDLBrocureCategory.SelectedValue);
            BrochureRowOject.Brochure_Arabic_Name = BrochureArabicName;
            BrochureRowOject.Brochure_English_Name = BrochureEnglishName;
            BrochureRowOject.Brochure_Date = DTBrochureDate;
            BrochureRowOject.Brochure_Cost = BrochureCost;
            BrochureRowOject.Brochure_Existance_Place = BrochureExistingPlace;
            BrochureRowOject.Brochure_Type = Boolean.Parse(DDLBrochureType.SelectedValue);

            BrochuresDSObject.Brochures.AddBrochuresRow(BrochureRowOject);
            BrochuresDSObject = BrochuresBizObject.InsertBrochures(BrochuresDSObject);

            string FilePath = FUBrochureFile.PostedFile.FileName;

            BrochureFilesBiz BrochuresFileBizObject = new BrochureFilesBiz();
            BrochureFilesDS BrochuresFileDSObject = new BrochureFilesDS();
            BrochureFilesDS.BrochureFilesRow BrochureFilesRowObject = BrochuresFileDSObject.BrochureFiles.NewBrochureFilesRow();

            BrochureFilesRowObject.Brochure_ID = Int32.Parse(BrochuresDSObject.Brochures.Rows[0]["Brochure_ID"].ToString());

            //////////////////////////// Save Uploaded File To Server /////////////////////////////////////

            if (FUBrochureFile.HasFile)
            {
                DirectoryInfo DirectoryInfoObject = new DirectoryInfo(Server.MapPath("~//GovsFiles//ORG_" + Session["OrgID"].ToString() + "_Files//Brochures"));
                if (!DirectoryInfoObject.Exists)
                {
                    DirectoryInfoObject.Create();
                }

                FUBrochureFile.SaveAs(DirectoryInfoObject.FullName + "\\" + FUBrochureFile.FileName);
                BrochureFilesRowObject.File_Path = FUBrochureFile.FileName;
                
                //FileInfo Projectfile = new FileInfo(FUBrochureFile.PostedFile.FileName);
                //if (Projectfile.Exists)
                //{
                //    try
                //    {
                //        FileInfo ServerProjectFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + Projectfile.Name);
                //        if (ServerProjectFile.Exists)
                //            ServerProjectFile.Delete();
                //        Projectfile.CopyTo(DirectoryInfoObject.FullName + "\\" + Projectfile.Name);
                //        BrochureFilesRowObject.File_Path = Projectfile.Name;
                //    }
                //    catch (Exception ex)
                //    {
                //    }
                //}
            }

            ///////////////////////////////////////////////////////////////////////////////////////////////
            BrochuresFileDSObject.BrochureFiles.AddBrochureFilesRow(BrochureFilesRowObject);
            BrochuresFileBizObject.InsertBrochureFiles(BrochuresFileDSObject);

            GridView1.DataSource = BrochuresBizObject.PopulateList("ORG_ID=" + OrgID);
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
            LITFileName.Visible = false;
            string BrochureArabicName = TXTBrochureArabicName.Text;
            string BrochureEnglishName = TXTBrochureEnglishName.Text;
            string BrochureExistingPlace = DDLSource.SelectedItem.Text;
            //string BrochureExistingPlace = TXTExistingPlace.Text;
            string BrochureDate = TXTBrochureDate.Text;
            string BrochureCost = "";
            if (CostRow.Visible == false)
                BrochureCost = "0";
            else
                BrochureCost = TXTCost.Text;

            //DateTime DTBrochureDate = new DateTime(Int32.Parse(BrochureDate.Substring(6, 4)), Int32.Parse(BrochureDate.Substring(3, 2)), Int32.Parse(BrochureDate.Substring(0, 2)));
            DateTime DTBrochureDate = DateTime.Parse(BrochureDate);

            int OrgID = Int32.Parse(Session["OrgID"].ToString());

            BrochuresBiz BrochuresBizObject = new BrochuresBiz();
            BrochuresDS BrochuresDSObject = BrochuresBizObject.Populate(Int32.Parse(ViewState["BrochureID"].ToString()));

            BrochuresDSObject.Brochures[0].ORG_ID = OrgID;
            BrochuresDSObject.Brochures[0].Cat_ID = Decimal.Parse(DDLBrocureCategory.SelectedValue);
            BrochuresDSObject.Brochures[0].Brochure_Arabic_Name = BrochureArabicName;
            BrochuresDSObject.Brochures[0].Brochure_English_Name = BrochureEnglishName;
            BrochuresDSObject.Brochures[0].Brochure_Type = Boolean.Parse(DDLBrochureType.SelectedValue);
            BrochuresDSObject.Brochures[0].Brochure_Cost = BrochureCost;
            BrochuresDSObject.Brochures[0].Brochure_Existance_Place = BrochureExistingPlace;
            BrochuresDSObject.Brochures[0].Brochure_Date = DTBrochureDate;

            BrochuresBizObject.UpdateBrochures(BrochuresDSObject);

            string FilePath = "";
            string OldBrochureFileName = "";
            FileInfo Projectsfile = null;

            if (FUBrochureFile.HasFile)
            {
                FilePath = FUBrochureFile.PostedFile.FileName;
                Projectsfile = new FileInfo(FUBrochureFile.PostedFile.FileName);


                BrochureFilesBiz BrochureFilesBizObject = new BrochureFilesBiz();
                //BrochureFilesDS 
                  BrochureFilesDSObject = BrochureFilesBizObject.PopulateList("Brochure_ID=" + ViewState["BrochureID"].ToString());

                if (BrochureFilesDSObject.BrochureFiles.Rows.Count > 0)
                {
                    int FileID = Int32.Parse(BrochureFilesDSObject.BrochureFiles.Rows[0]["File_ID"].ToString());
                    BrochureFilesDSObject = BrochureFilesBizObject.Populate(FileID);

                    OldBrochureFileName = BrochureFilesDSObject.BrochureFiles[0].File_Path;
                    if (FUBrochureFile.HasFile)
                    {
                        BrochureFilesDSObject.BrochureFiles[0].File_Path = Projectsfile.Name;
                    }
                    else
                    {
                        BrochureFilesDSObject.BrochureFiles[0].File_Path = OldBrochureFileName;
                    }
                    BrochureFilesDSObject.BrochureFiles[0].Brochure_ID = Int32.Parse(ViewState["BrochureID"].ToString());

                    BrochureFilesBizObject.UpdateBrochureFiles(BrochureFilesDSObject);
                }
                else
                {
                    BrochureFilesBizObject = new BrochureFilesBiz();
                    BrochureFilesDSObject = new BrochureFilesDS();
                    BrochureFilesDS.BrochureFilesRow BrochureFilesRowObject = BrochureFilesDSObject.BrochureFiles.NewBrochureFilesRow();

                    BrochureFilesRowObject.Brochure_ID = Int32.Parse(BrochuresDSObject.Brochures.Rows[0]["Brochure_ID"].ToString());

                    if (FUBrochureFile.HasFile)
                    {
                        BrochureFilesRowObject.File_Path = Projectsfile.Name;
                    }
                    else
                    {
                        BrochureFilesRowObject.File_Path = null;
                    }
                    BrochureFilesDSObject.BrochureFiles.AddBrochureFilesRow(BrochureFilesRowObject);
                    BrochureFilesBizObject.InsertBrochureFiles(BrochureFilesDSObject);
                }
                //////////////////////////// Save Uploaded File To Server /////////////////////////////////////

                if (FUBrochureFile.HasFile)
                {
                    DirectoryInfo DirectoryInfoObject = new DirectoryInfo(Server.MapPath("~//GovsFiles//ORG_" + Session["OrgID"].ToString() + "_Files//Brochures"));
                    if (!DirectoryInfoObject.Exists)
                    {
                        DirectoryInfoObject.Create();
                    }

                    FileInfo ServerOrojectsFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + FUBrochureFile.FileName);
                    if (ServerOrojectsFile.Exists)
                        ServerOrojectsFile.Delete();
                    FUBrochureFile.SaveAs(DirectoryInfoObject.FullName + "\\" + FUBrochureFile.FileName);

                    //Projectsfile = new FileInfo(FUBrochureFile.PostedFile.FileName);
                    //if (Projectsfile.Exists)
                    //{
                    //    try
                    //    {
                    //        FileInfo ServerOldProjectsFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + OldBrochureFileName);
                    //        if (ServerOldProjectsFile.Exists)
                    //            ServerOldProjectsFile.Delete();

                    //        FileInfo ServerOrojectsFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + Projectsfile.Name);
                    //        if (ServerOrojectsFile.Exists)
                    //            ServerOrojectsFile.Delete();
                    //        Projectsfile.CopyTo(DirectoryInfoObject.FullName + "\\" + Projectsfile.Name);
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //    }
                    //}
                }
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////

            GridView1.DataSource = BrochuresBizObject.PopulateList("ORG_ID=" + OrgID);
            GridView1.DataBind();
            FillHighLights();

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
    protected void LBTNShowDetails_Click(object sender, EventArgs e)
    {
        try
        {
            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            BrochuresBiz BrochuresBizObject = new BrochuresBiz();
            BrochuresDS BrochuresDSOject = BrochuresBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString());

            string BrochureID = BrochuresDSOject.Brochures.Rows[RowIndex]["Brochure_ID"].ToString();

            BrochuresDSOject = BrochuresBizObject.Populate(Int32.Parse(BrochureID));

            ViewState.Add("BrochureID", BrochureID);

            MultiView1.ActiveViewIndex = 2;

            Repeater1.DataSource = BrochuresDSOject;
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
                string BrochureDateBeforCut = dr["Brochure_Date"].ToString();
                //string DTBrochureDate = new DateTime(Int32.Parse(BrochureDateBeforCut.Substring(6, 4)), Int32.Parse(BrochureDateBeforCut.Substring(3, 2)), Int32.Parse(BrochureDateBeforCut.Substring(0, 2))).ToShortDateString();
                string DTBrochureDate = DateTime.Parse(BrochureDateBeforCut).ToShortDateString();

                ((Literal)e.Item.FindControl("Literal12")).Text = DTBrochureDate;


                BrochureFilesBiz BrochureFilesBizObject = new BrochureFilesBiz();
                BrochureFilesDS BrochureFilesDSOject = BrochureFilesBizObject.PopulateList("Brochure_ID = " + ViewState["BrochureID"].ToString());
                if (BrochureFilesDSOject.BrochureFiles.Rows.Count > 0)
                {
                    BrochureFilesDSOject.BrochureFiles.Columns.Add("ORG_ID");
                    BrochureFilesDSOject.BrochureFiles.Rows[0]["ORG_ID"] = Session["OrgID"].ToString();
                }

                ((Repeater)e.Item.FindControl("Repeater2")).DataSource = BrochureFilesDSOject;
                ((Repeater)e.Item.FindControl("Repeater2")).DataBind();

                string BrochureType = ((Literal)e.Item.FindControl("Literal14")).Text;
                if (BrochureType == "True")
                    ((Literal)e.Item.FindControl("Literal14")).Text = "ãÌÇäíÉ";
                else
                    ((Literal)e.Item.FindControl("Literal14")).Text = "ÈãÞÇÈá ãÇÏì";

            }
            catch (Exception ex)
            {
            }
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

                BrochuresBiz BrochuresBizObject = new BrochuresBiz();
                BrochuresDS BrochuresDSOject = BrochuresBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString());

                decimal RecordID = Decimal.Parse(BrochuresDSOject.Brochures.Rows[RowIndex]["Brochure_ID"].ToString());
                decimal RecordType = 1;
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

                BrochuresBiz BrochuresBizObject = new BrochuresBiz();
                BrochuresDS BrochuresDSOject = BrochuresBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString());

                decimal RecordID = Decimal.Parse(BrochuresDSOject.Brochures.Rows[RowIndex]["Brochure_ID"].ToString());
                string Type = "1";

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

            BrochuresBiz BrochuresBizObject = new BrochuresBiz();
            BrochuresDS BrochuresDSOject = BrochuresBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString());

            decimal RecordID = Decimal.Parse(BrochuresDSOject.Brochures.Rows[RowIndex]["Brochure_ID"].ToString());
            string Type = "1";

            HighLightsBiz HighLightsBizObject = new HighLightsBiz();
            HighLightsDS HighLightsDSObject = HighLightsBizObject.PopulateList("RecordID=" + RecordID + " and Type=" + Type);

            if (HighLightsDSObject != null && HighLightsDSObject.HighLights.Rows.Count > 0)
            {
                ((CheckBox)((GridViewRow)(GVRow)).FindControl("CHBHighlight")).Checked = true;
            }
        }
    }
    protected void DDLBrocureCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BrochuresBiz BrochuresBizObject = new BrochuresBiz();
            BrochuresDS BrochuresDSObject = BrochuresBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());

            if (BrochuresDSObject != null && BrochuresDSObject.Brochures.Rows.Count > 0)
            {
                MultiView1.ActiveViewIndex = 0;
            }
            else
            {
                ClearCooperationForm();
                MultiView1.ActiveViewIndex = 1;

                ViewState["BrochureID"] = null;
            }

            GridView1.DataSource = BrochuresDSObject;
            GridView1.DataBind();
            FillHighLights();
        }
        catch (Exception ex)
        {
        }
    }
    protected void DDLBrochureType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLBrochureType.SelectedIndex == 0)
            CostRow.Visible = false;
        else
            CostRow.Visible = true; ;
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
        string  BrochureID = (ViewState["BrochureID"]).ToString ();
        string SQL = "delete from BrochureFiles where Brochure_ID = " + BrochureID;
        Populate(SQL);

        LITFileName.Text = "";
        
    }
}
