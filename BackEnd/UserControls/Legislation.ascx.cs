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

public partial class UserControls_Legislation : System.Web.UI.UserControl
{
    
    OrganizationsBiz OrganizationsBizObject = new OrganizationsBiz();
    OrganizationsDS OrganizationsDSObject;
    DataTable LawOrganizations = new DataTable();

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
                LawsBiz LawsBizObject = new LawsBiz();
                LawsDS LawsDSObject = LawsBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString() + " and IsLegislation=1");

                if (LawsDSObject != null && LawsDSObject.Laws.Rows.Count > 0)
                {
                    MultiView1.ActiveViewIndex = 0;
                }
                else
                {
                    ClearCooperationForm();
                    MultiView1.ActiveViewIndex = 1;

                    ViewState["LawID"] = null;
                    FileDel.Visible = false;
                }

                GridView1.DataSource = LawsDSObject;
                GridView1.DataBind();
                FillHighLights();

                LawOrganizations.Columns.Add("OrgID");

                Session.Add("LawOrganizations", LawOrganizations);
            }
        }
    }

    void ClearCooperationForm()
    {
        try
        {
            this.TXTLawArabicName.Text = "";
            this.TXTLawEnglishName.Text = "";
            this.TXTLawArabicContent.Text = "";
            this.TXTLawEnglishContent.Text = "";
            this.TXTLawVersionYear.Text = "";
            this.CHBWorkOrCanceled.Checked = false;
            this.TXTCancelationNumber.Text = "";

            this.TXTPublishDate.Text = "";
            this.TXTReleaseDate.Text = "";
            

            OrgList.ClearSelection();

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
            LawsBiz LawsBizObject = new LawsBiz();
            LawsDS LawsDSOject = LawsBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString() + " and Law_ID = " + CooperationID + " and IsLegislation=1");

            this.TXTLawArabicName.Text = LawsDSOject.Laws.Rows[0]["Law_Arabic_Name"].ToString();
            this.TXTLawEnglishName.Text = LawsDSOject.Laws.Rows[0]["Law_English_Name"].ToString();
            this.TXTLawArabicContent.Text = LawsDSOject.Laws.Rows[0]["Law_Arabic_Title"].ToString();
            this.TXTLawEnglishContent.Text = LawsDSOject.Laws.Rows[0]["Law_English_Title"].ToString();
            this.TXTLawVersionYear.Text = LawsDSOject.Laws.Rows[0]["Law_Version_Year"].ToString();

            DateTime ReleaseDate = new DateTime();
            ReleaseDate = DateTime.Parse(LawsDSOject.Laws.Rows[0]["Release_Date"].ToString());
            string DTReleaseDate = ReleaseDate.Day.ToString() + "/" + ReleaseDate.Month + "/" + ReleaseDate.Year;



            //string ReleaseDate = LawsDSOject.Laws.Rows[0]["Release_Date"].ToString();
            //string DTReleaseDate = new DateTime(Int32.Parse(ReleaseDate.Substring(6, 4)), Int32.Parse(ReleaseDate.Substring(3, 2)), Int32.Parse(ReleaseDate.Substring(0, 2))).ToShortDateString();
            //string DTReleaseDate = DateTime.Parse(ReleaseDate).ToShortDateString();
            this.TXTReleaseDate.Text = DTReleaseDate;


            DateTime PublishDate = new DateTime();
            PublishDate = DateTime.Parse(LawsDSOject.Laws.Rows[0]["Publish_Date"].ToString());
            string DTPublishDate = PublishDate.Day.ToString() + "/" + PublishDate.Month + "/" + PublishDate.Year;

            //string PublishDate = LawsDSOject.Laws.Rows[0]["Publish_Date"].ToString();
            //string DTPublishDate = new DateTime(Int32.Parse(PublishDate.Substring(6, 4)), Int32.Parse(PublishDate.Substring(3, 2)), Int32.Parse(PublishDate.Substring(0, 2))).ToShortDateString();
            //string DTPublishDate = DateTime.Parse(PublishDate).ToShortDateString();
            this.TXTPublishDate.Text = DTPublishDate;

            if (LawsDSOject.Laws.Rows[0]["Law_Type"].ToString() == "True")
                CHBWorkOrCanceled.Checked = true;
            else
                CHBWorkOrCanceled.Checked = false;

            this.TXTCancelationNumber.Text = LawsDSOject.Laws.Rows[0]["Law_CancelationLawNumbe"].ToString();

            LawOrganizationsBiz LawOrganizationsBizObject = new LawOrganizationsBiz();
            LawOrganizationsDS LawOrganizationsDSObject = new LawOrganizationsDS();

            LawOrganizationsDSObject = LawOrganizationsBizObject.PopulateList("LawID=" + CooperationID);

            OrgList.ClearSelection();

            if (OrgList.Items.Count - 1 == LawOrganizationsDSObject.LawOrganizations.Rows.Count)
            {
                OrgList.Items[0].Selected = true;
            }
            else
            {
                foreach (DataRow dr in LawOrganizationsDSObject.LawOrganizations.Rows)
                {
                    string LawOrgID = dr["OrgID"].ToString();
                    foreach (ListItem LI in OrgList.Items)
                    {
                        if (LI.Value == LawOrgID)
                            LI.Selected = true;
                    }
                }
            }

            LITFileName.Visible = true;
            LawFilesBiz LawFilesBizObject = new LawFilesBiz();
            LawFilesDS LawFilesDSObject = LawFilesBizObject.PopulateList("Law_ID=" + CooperationID);

            if (LawFilesDSObject.LawFiles.Count > 0)
            {
           
            LITFileName.Text = LawFilesDSObject.LawFiles.Rows[0]["File_Path"].ToString();
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

    protected void LBTNEdit_Click(object sender, EventArgs e)
    {
        try
        {
            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            LawsBiz LawsBizObject = new LawsBiz();
            LawsDS LawsDSOject = LawsBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString() + " and IsLegislation=1");

            string LawID = LawsDSOject.Laws.Rows[RowIndex]["Law_ID"].ToString();

            ViewState.Add("LawID", LawID);

            if (FillCooperationForm(LawID))
            {
                MultiView1.ActiveViewIndex = 1;
            }
        }
        catch(Exception ex)
        {
            
        }
    }

    protected void LBTNDelete_Click(object sender, EventArgs e)
    {
        try
        {
            Confirm("هل تريد الحذف ؟");
            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            LawsBiz LawsBizObject = new LawsBiz();
            LawsDS LawsDSOject = LawsBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString() + " and IsLegislation=1");

            string LawID = LawsDSOject.Laws.Rows[RowIndex]["Law_ID"].ToString();

            LawFilesBiz LawFilesBizObject = new LawFilesBiz();
            LawFilesDS LawFilesDSObject = LawFilesBizObject.PopulateList("Law_ID=" + LawID.ToString());

            if (LawFilesDSObject != null && LawFilesDSObject.LawFiles.Rows.Count > 0)
            {
                int FileID = Int32.Parse(LawFilesDSObject.LawFiles.Rows[0]["File_ID"].ToString());

                string SQL = "delete from LawFiles where File_ID=" + FileID.ToString();
                Populate(SQL);

                ///////////////////////////////////////////// CV and Photo Not Complete ////////////////////
                if (LawFilesDSObject.LawFiles.Rows[0]["File_Path"].ToString() != null || LawFilesDSObject.LawFiles.Rows[0]["File_Path"].ToString() != "")
                {
                    DirectoryInfo DirectoryInfoObject = new DirectoryInfo(Server.MapPath("~//GovsFiles//ORG_" + Session["OrgID"].ToString() + "_Files//Laws"));
                    if (!DirectoryInfoObject.Exists)
                    {
                        DirectoryInfoObject.Create();
                    }
                    try
                    {
                        FileInfo ServerProjectFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + LawFilesDSObject.LawFiles.Rows[0]["File_Path"].ToString());
                        if (ServerProjectFile.Exists)
                            ServerProjectFile.Delete();
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
            }

            LawOrganizationsBiz LawOrganizationsBizObject = new LawOrganizationsBiz();
            LawOrganizationsDS LawOrganizationsDSObject = new LawOrganizationsDS();

            LawOrganizationsDSObject = LawOrganizationsBizObject.PopulateList("LawID=" + LawID.ToString());

            foreach (DataRow dr in LawOrganizationsDSObject.LawOrganizations.Rows)
            {
                string SQL = "delete from LawOrganizations where Law_Org_ID=" + dr["Law_Org_ID"].ToString();
                Populate(SQL);
            }


            string SQL1 = "delete from Laws where Law_ID=" + LawID.ToString();
            Populate(SQL1);

            GridView1.DataSource = LawsBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString() + " and IsLegislation=1");
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

            LawsBiz LawsBizObject = new LawsBiz();
            LawsDS LawsDSOject = LawsBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString() + " and IsLegislation=1");

            string LawID = LawsDSOject.Laws.Rows[RowIndex]["Law_ID"].ToString();

            LawsDSOject = LawsBizObject.Populate(Int32.Parse(LawID));

            ViewState.Add("LawID", LawID);

            MultiView1.ActiveViewIndex = 2;

            Repeater1.DataSource = LawsDSOject;
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
            ViewState["ProjectID"] = null;
            FileDel.Visible = false;
        }
        catch (Exception ex)
        {
            
        }
    }

    protected void BTNAdd_Click(object sender, EventArgs e)
    {
        try
        {
            string LawArabicName = TXTLawArabicName.Text;
            string LawEnglishName = TXTLawEnglishName.Text;
            string LawArabicTitle = TXTLawArabicContent.Text;
            string LawEnglishTitle = TXTLawEnglishContent.Text;
            string LawVersionYear = TXTLawVersionYear.Text;
            string LawCancelationNumber = TXTCancelationNumber.Text;
            string ReleaseDate = TXTReleaseDate.Text;
            string PublishDate = TXTPublishDate.Text;
            string LawType = "";
            if (CHBWorkOrCanceled.Checked)
                LawType = "True";
            else
                LawType = "False";

            int OrgID = Int32.Parse(Session["OrgID"].ToString());

            DateTime DTReleaseDate = new DateTime(Int32.Parse(ReleaseDate.Substring(6, 4)), Int32.Parse(ReleaseDate.Substring(3, 2)), Int32.Parse(ReleaseDate.Substring(0, 2)));
            //DateTime DTReleaseDate = DateTime.Parse(ReleaseDate);
            DateTime DTPublishdate = new DateTime(Int32.Parse(PublishDate.Substring(6, 4)), Int32.Parse(PublishDate.Substring(3, 2)), Int32.Parse(PublishDate.Substring(0, 2)));
            //DateTime DTPublishdate = DateTime.Parse(PublishDate);

            LawsBiz LawsBizObject = new LawsBiz();
            LawsDS LawsDSObject = new LawsDS();
            LawsDS.LawsRow LawsRowOject = LawsDSObject.Laws.NewLawsRow();

            LawsRowOject.ORG_ID = OrgID;
            LawsRowOject.Law_Arabic_Name = LawArabicName;
            LawsRowOject.Law_English_Name = LawEnglishName;
            LawsRowOject.Law_Arabic_Title = LawArabicTitle;
            LawsRowOject.Law_English_Title = LawEnglishTitle;
            LawsRowOject.Law_Version_Year = LawVersionYear;
            LawsRowOject.Law_Type = Boolean.Parse(LawType);
            if (LawType == "True")
                LawsRowOject.Law_CancelationLawNumbe = decimal.Parse(LawCancelationNumber);
            else
                LawsRowOject.Law_CancelationLawNumbe = 0;

            LawsRowOject.Release_Date = DTReleaseDate;
            LawsRowOject.Publish_Date = DTPublishdate;
            LawsRowOject.IsLegislation = true;


            LawsDSObject.Laws.AddLawsRow(LawsRowOject);
            LawsDSObject = LawsBizObject.InsertLaws(LawsDSObject);

            LawOrganizationsBiz LawOrganizationsBizObject = new LawOrganizationsBiz();
            LawOrganizationsDS LawOrganizationsDSObject = new LawOrganizationsDS();

            if (OrgList.Items[0].Selected)
            {
                OrganizationsDSObject = OrganizationsBizObject.PopulateList("Org_Type_ID=6 or Org_Type_ID=7");
                foreach (DataRow dr in OrganizationsDSObject.Organizations.Rows)
                {
                    LawOrganizationsDS.LawOrganizationsRow LawOrgRow = LawOrganizationsDSObject.LawOrganizations.NewLawOrganizationsRow();

                    LawOrgRow.OrgID = Decimal.Parse(dr["ORG_ID"].ToString());
                    LawOrgRow.LawID = Decimal.Parse(LawsDSObject.Laws.Rows[0]["Law_ID"].ToString());

                    LawOrganizationsDSObject.LawOrganizations.AddLawOrganizationsRow(LawOrgRow);
                    LawOrganizationsDSObject = LawOrganizationsBizObject.InsertLawOrganizations(LawOrganizationsDSObject);
                }
            }
            else
            {
                foreach (ListItem LI in OrgList.Items)
                {
                    if (LI.Selected)
                    {
                        LawOrganizationsDS.LawOrganizationsRow LawOrgRow = LawOrganizationsDSObject.LawOrganizations.NewLawOrganizationsRow();

                        LawOrgRow.OrgID = Decimal.Parse(LI.Value);
                        LawOrgRow.LawID = Decimal.Parse(LawsDSObject.Laws.Rows[0]["Law_ID"].ToString());

                        LawOrganizationsDSObject.LawOrganizations.AddLawOrganizationsRow(LawOrgRow);
                        LawOrganizationsDSObject = LawOrganizationsBizObject.InsertLawOrganizations(LawOrganizationsDSObject);
                    }
                }
            }
            if (FULawFile.HasFile)
            {
                string FilePath = FULawFile.PostedFile.FileName;

                LawFilesBiz LawFilesBizObject = new LawFilesBiz();
                LawFilesDS LawFilesDSObject = new LawFilesDS();
                LawFilesDS.LawFilesRow LawFilesRowObject = LawFilesDSObject.LawFiles.NewLawFilesRow();

                LawFilesRowObject.Law_ID = Int32.Parse(LawsDSObject.Laws.Rows[0]["Law_ID"].ToString());

                //////////////////////////// Save Uploaded File To Server /////////////////////////////////////

                if (FULawFile.HasFile)
                {
                    DirectoryInfo DirectoryInfoObject = new DirectoryInfo(Server.MapPath("~//GovsFiles//ORG_" + Session["OrgID"].ToString() + "_Files//Laws"));
                    if (!DirectoryInfoObject.Exists)
                    {
                        DirectoryInfoObject.Create();
                    }

                    FULawFile.SaveAs(DirectoryInfoObject.FullName + "\\" + FULawFile.FileName);
                    LawFilesRowObject.File_Path = FULawFile.FileName;

                    //FileInfo Projectfile = new FileInfo(FULawFile.PostedFile.FileName);
                    //if (Projectfile.Exists)
                    //{
                    //    try
                    //    {
                    //        FileInfo ServerProjectFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + Projectfile.Name);
                    //        if (ServerProjectFile.Exists)
                    //            ServerProjectFile.Delete();
                    //        Projectfile.CopyTo(DirectoryInfoObject.FullName + "\\" + Projectfile.Name);
                    //        LawFilesRowObject.File_Path = Projectfile.Name;
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //    }
                    //}
                }

                ///////////////////////////////////////////////////////////////////////////////////////////////
                LawFilesDSObject.LawFiles.AddLawFilesRow(LawFilesRowObject);
                LawFilesBizObject.InsertLawFiles(LawFilesDSObject);
            }
            GridView1.DataSource = LawsBizObject.PopulateList("ORG_ID=" + OrgID + " and IsLegislation=1");
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
            string LawArabicName = TXTLawArabicName.Text;
            string LawEnglishName = TXTLawEnglishName.Text;
            string LawArabicTitle = TXTLawArabicContent.Text;
            string LawEnglishTitle = TXTLawEnglishContent.Text;
            string LawVersionYear = TXTLawVersionYear.Text;

            string LawCancelationNumber = TXTCancelationNumber.Text;
            string ReleaseDate = TXTReleaseDate.Text;
            string PublishDate = TXTPublishDate.Text;
            string LawType = "";
            if (CHBWorkOrCanceled.Checked)
                LawType = "True";
            else
                LawType = "False";

            int OrgID = Int32.Parse(Session["OrgID"].ToString());

            DateTime DTReleaseDate = new DateTime(Int32.Parse(ReleaseDate.Substring(6, 4)), Int32.Parse(ReleaseDate.Substring(3, 2)), Int32.Parse(ReleaseDate.Substring(0, 2)));
            //DateTime DTReleaseDate = DateTime.Parse(ReleaseDate);
            DateTime DTPublishdate = new DateTime(Int32.Parse(PublishDate.Substring(6, 4)), Int32.Parse(PublishDate.Substring(3, 2)), Int32.Parse(PublishDate.Substring(0, 2)));
            //DateTime DTPublishdate = DateTime.Parse(PublishDate);

            LawsBiz LawsBizObject = new LawsBiz();
            LawsDS LawsDSObject = LawsBizObject.Populate(Int32.Parse(ViewState["LawID"].ToString()));

            LawsDSObject.Laws[0].ORG_ID = OrgID;
            LawsDSObject.Laws[0].Law_Arabic_Name = LawArabicName;
            LawsDSObject.Laws[0].Law_English_Name = LawEnglishName;
            LawsDSObject.Laws[0].Law_Arabic_Title = LawArabicTitle;
            LawsDSObject.Laws[0].Law_English_Title = LawEnglishTitle;
            LawsDSObject.Laws[0].Law_Version_Year = LawVersionYear;
            LawsDSObject.Laws[0].Law_Type = Boolean.Parse(LawType);
            if (LawType == "True")
                LawsDSObject.Laws[0].Law_CancelationLawNumbe = decimal.Parse(LawCancelationNumber);
            else
                LawsDSObject.Laws[0].Law_CancelationLawNumbe = 0;

            LawsDSObject.Laws[0].Release_Date = DTReleaseDate;
            LawsDSObject.Laws[0].Publish_Date = DTPublishdate;
            LawsDSObject.Laws[0].IsLegislation = true;

            LawsBizObject.UpdateLaws(LawsDSObject);



            LawOrganizationsBiz LawOrganizationsBizObject = new LawOrganizationsBiz();
            LawOrganizationsDS LawOrganizationsDSObject = new LawOrganizationsDS();

            LawOrganizationsDSObject = LawOrganizationsBizObject.PopulateList("LawID=" + LawsDSObject.Laws.Rows[0]["Law_ID"].ToString());

            foreach (DataRow dr in LawOrganizationsDSObject.LawOrganizations.Rows)
            {
                string SQL = "delete from LawOrganizations where Law_Org_ID=" + dr["Law_Org_ID"].ToString();
                Populate(SQL);
            }

            if (OrgList.Items[0].Selected)
            {
                OrganizationsDSObject = OrganizationsBizObject.PopulateList("Org_Type_ID=6 or Org_Type_ID=7");
                foreach (DataRow dr in OrganizationsDSObject.Organizations.Rows)
                {
                    LawOrganizationsDS.LawOrganizationsRow LawOrgRow = LawOrganizationsDSObject.LawOrganizations.NewLawOrganizationsRow();

                    LawOrgRow.OrgID = Decimal.Parse(dr["ORG_ID"].ToString());
                    LawOrgRow.LawID = Decimal.Parse(LawsDSObject.Laws.Rows[0]["Law_ID"].ToString());

                    LawOrganizationsDSObject.LawOrganizations.AddLawOrganizationsRow(LawOrgRow);
                    LawOrganizationsDSObject = LawOrganizationsBizObject.InsertLawOrganizations(LawOrganizationsDSObject);
                }
            }
            else
            {
                foreach (ListItem LI in OrgList.Items)
                {
                    if (LI.Selected)
                    {
                        LawOrganizationsDS.LawOrganizationsRow LawOrgRow = LawOrganizationsDSObject.LawOrganizations.NewLawOrganizationsRow();

                        LawOrgRow.OrgID = Decimal.Parse(LI.Value);
                        LawOrgRow.LawID = Decimal.Parse(LawsDSObject.Laws.Rows[0]["Law_ID"].ToString());

                        LawOrganizationsDSObject.LawOrganizations.AddLawOrganizationsRow(LawOrgRow);
                        LawOrganizationsDSObject = LawOrganizationsBizObject.InsertLawOrganizations(LawOrganizationsDSObject);
                    }
                }
            }


            string FilePath = "";
            string OldLawFileName = "";
            FileInfo Projectsfile = null;


            if (FULawFile.HasFile)
            {
                FilePath = FULawFile.PostedFile.FileName;
                Projectsfile = new FileInfo(FULawFile.PostedFile.FileName);


                LawFilesBiz LawFilesBizObject = new LawFilesBiz();
                LawFilesDS LawFilesDSObject = LawFilesBizObject.PopulateList("Law_ID=" + ViewState["LawID"].ToString());

                if (LawFilesDSObject.LawFiles.Rows.Count > 0)
                {
                    int FileID = Int32.Parse(LawFilesDSObject.LawFiles.Rows[0]["File_ID"].ToString());
                    LawFilesDSObject = LawFilesBizObject.Populate(FileID);

                    OldLawFileName = LawFilesDSObject.LawFiles[0].File_Path;

                    if (FULawFile.HasFile)
                    {
                        LawFilesDSObject.LawFiles[0].File_Path = Projectsfile.Name;
                    }
                    else
                    {
                        LawFilesDSObject.LawFiles[0].File_Path = OldLawFileName;
                    }
                    LawFilesDSObject.LawFiles[0].Law_ID = Int32.Parse(ViewState["LawID"].ToString());

                    LawFilesBizObject.UpdateLawFiles(LawFilesDSObject);
                }
                else
                {
                    LawFilesBizObject = new LawFilesBiz();
                    LawFilesDSObject = new LawFilesDS();
                    LawFilesDS.LawFilesRow LawFilesRowObject = LawFilesDSObject.LawFiles.NewLawFilesRow();

                    LawFilesRowObject.Law_ID = Int32.Parse(LawsDSObject.Laws.Rows[0]["Law_ID"].ToString());

                    if (FULawFile.HasFile)
                    {
                        LawFilesRowObject.File_Path = Projectsfile.Name;
                    }
                    else
                    {
                        LawFilesRowObject.File_Path = null;
                    }
                    LawFilesDSObject.LawFiles.AddLawFilesRow(LawFilesRowObject);
                    LawFilesBizObject.InsertLawFiles(LawFilesDSObject);
                }
            }
            //////////////////////////// Save Uploaded File To Server /////////////////////////////////////

            if (FULawFile.HasFile)
            {
                DirectoryInfo DirectoryInfoObject = new DirectoryInfo(Server.MapPath("~//GovsFiles//ORG_" + Session["OrgID"].ToString() + "_Files//Laws"));
                if (!DirectoryInfoObject.Exists)
                {
                    DirectoryInfoObject.Create();
                }

                FileInfo ServerOrojectsFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + FULawFile.FileName);
                if (ServerOrojectsFile.Exists)
                    ServerOrojectsFile.Delete();
                FULawFile.SaveAs(DirectoryInfoObject.FullName + "\\" + FULawFile.FileName);

                //Projectsfile = new FileInfo(FULawFile.PostedFile.FileName);
                //if (Projectsfile.Exists)
                //{
                //    try
                //    {
                //        FileInfo ServerOldProjectsFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + OldLawFileName);
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
            ///////////////////////////////////////////////////////////////////////////////////////////////

            GridView1.EditIndex = -1;
            GridView1.DataSource = LawsBizObject.PopulateList("ORG_ID=" + OrgID + " and IsLegislation=1");
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

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            try
            {
                LawFilesBiz LawFilesBizObject = new LawFilesBiz();
                LawFilesDS LawFilesDSOject = LawFilesBizObject.PopulateList("Law_ID = " + ViewState["LawID"].ToString());
                if (LawFilesDSOject.LawFiles.Rows.Count > 0)
                {
                    LawFilesDSOject.LawFiles.Columns.Add("ORG_ID");
                    LawFilesDSOject.LawFiles.Rows[0]["ORG_ID"] = Session["OrgID"].ToString();

                    ((Repeater)e.Item.FindControl("Repeater2")).DataSource = LawFilesDSOject;
                    ((Repeater)e.Item.FindControl("Repeater2")).DataBind();
                }
                if (((Literal)e.Item.FindControl("Literal19")).Text == "True")
                    ((Literal)e.Item.FindControl("Literal19")).Text = "تم إلغاء القرار";
                else
                    ((Literal)e.Item.FindControl("Literal19")).Text = "لايزال معمل بالقرار";
                
            }
            catch (Exception ex)
            {
                
            }
        }
    }
    protected void LBTNFiles_Click(object sender, EventArgs e)
    {
        try
        {
            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            LawsBiz LawsBizObject = new LawsBiz();
            LawsDS LawsDSObject = LawsBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString() + " and IsLegislation=1");

            int LawID = Int32.Parse(LawsDSObject.Laws.Rows[RowIndex]["Law_ID"].ToString());
            ViewState.Add("LawID", LawID);

            LawFilesBiz LawFilesBizObject = new LawFilesBiz();
            LawFilesDS LawFilesDSObject = LawFilesBizObject.PopulateList("Law_ID =" + LawID);

            MultiView1.ActiveViewIndex = 3;
            GridView2.DataSource = LawFilesDSObject;
            GridView2.DataBind();
        }
        catch (Exception ex)
        {
            
        }
    }

    protected void LBTNUpdate_Click1(object sender, EventArgs e)
    {
        try
        {
            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            LawFilesBiz LawFilesBizObject = new LawFilesBiz();
            LawFilesDS LawFilesDSObject = LawFilesBizObject.PopulateList("Law_ID=" + ViewState["LawID"].ToString());

            int FileID = Int32.Parse(LawFilesDSObject.LawFiles.Rows[RowIndex]["File_ID"].ToString());

            ViewState.Add("LawFileID", FileID);
            GridView2.EditIndex = RowIndex;

            GridView2.DataSource = LawFilesDSObject;
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

            LawFilesBiz LawFilesBizObject = new LawFilesBiz();
            LawFilesDS LawFilesDSObject = LawFilesBizObject.PopulateList("Law_ID=" + ViewState["LawID"].ToString());

            int FileID = Int32.Parse(LawFilesDSObject.LawFiles.Rows[RowIndex]["File_ID"].ToString());

            string SQL = "delete from LawFiles where File_ID=" + FileID.ToString();
            Populate(SQL);

            ///////////////////////////////////////////// CV and Photo Not Complete ////////////////////
            if (LawFilesDSObject.LawFiles.Rows[RowIndex]["File_Path"].ToString() != null || LawFilesDSObject.LawFiles.Rows[RowIndex]["File_Path"].ToString() != "")
            {
                DirectoryInfo DirectoryInfoObject = new DirectoryInfo(Server.MapPath("~//GovsFiles//ORG_" + Session["OrgID"].ToString() + "_Files//Laws"));
                if (!DirectoryInfoObject.Exists)
                {
                    DirectoryInfoObject.Create();
                }
                try
                {
                    FileInfo ServerProjectFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + LawFilesDSObject.LawFiles.Rows[RowIndex]["File_Path"].ToString());
                    if (ServerProjectFile.Exists)
                        ServerProjectFile.Delete();
                }
                catch (Exception ex)
                {
                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////////
            GridView2.DataSource = LawFilesBizObject.PopulateList("Law_ID=" + ViewState["LawID"].ToString());
            GridView2.DataBind();
        }
        catch (Exception ex)
        {
            
        }
    }

    protected void LBTNSava_Click1(object sender, EventArgs e)
    {
        try
        {
            string FileName = ((TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXTFileName")).Text;
            string FilePath = ""/* = ((RadUpload)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("RUFile")).UploadedFiles[0].FileName*/;

            LawFilesBiz LawFilesBizObject = new LawFilesBiz();
            LawFilesDS LawFilesDSObject = LawFilesBizObject.Populate(Int32.Parse(ViewState["LawFileID"].ToString()));

            //////////////////////////// Save Uploaded File To Server /////////////////////////////////////

            if (Session["LawsFile"] != null)
            {
                DirectoryInfo DirectoryInfoObject = new DirectoryInfo(Server.MapPath("~//GovsFiles//ORG_" + Session["OrgID"].ToString() + "_Files//Laws"));
                if (!DirectoryInfoObject.Exists)
                {
                    DirectoryInfoObject.Create();
                }
                FileInfo Projectsfile = new FileInfo(Session["LawsFile"].ToString());
                if (Projectsfile.Exists)
                {
                    try
                    {
                        FileInfo ServerOldProjectsFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + LawFilesDSObject.LawFiles[0].File_Path);
                        if (ServerOldProjectsFile.Exists)
                            ServerOldProjectsFile.Delete();

                        FileInfo ServerOrojectsFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + Projectsfile.Name);
                        if (ServerOrojectsFile.Exists)
                            ServerOrojectsFile.Delete();
                        Projectsfile.CopyTo(DirectoryInfoObject.FullName + "\\" + Projectsfile.Name);
                        LawFilesDSObject.LawFiles[0].File_Path = Projectsfile.Name;
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////
            LawFilesDSObject.LawFiles[0].Law_ID = Int32.Parse(ViewState["LawID"].ToString());

            LawFilesBizObject.UpdateLawFiles(LawFilesDSObject);

            GridView2.EditIndex = -1;
            GridView2.DataSource = LawFilesBizObject.PopulateList("Law_ID=" + ViewState["LawID"].ToString());
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
            LawFilesBiz LawFilesBizObject = new LawFilesBiz();
            GridView2.EditIndex = -1;
            GridView2.DataSource = LawFilesBizObject.PopulateList("Law_ID=" + ViewState["LawID"].ToString());
            GridView2.DataBind();
        }
        catch (Exception ex)
        {
            
        }
    }

    protected void LBTNAdd_Click1(object sender, EventArgs e)
    {
        try
        {
            if (Session["LawsFile"] == null)
            {
                Page.RegisterStartupScript("ErrorMsg", "<script>alert('لابد من رفع ملف السيرة الذاتية');</script>");
                return;
            }
            string FileName = ((TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXTFileName")).Text;
            string FilePath = ""/* ((RadUpload)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("RUFile")).UploadedFiles[0].FileName*/;

            LawFilesBiz LawFilesBizObject = new LawFilesBiz();
            LawFilesDS LawFilesDSObject = new LawFilesDS();
            LawFilesDS.LawFilesRow LawFilesRowObject = LawFilesDSObject.LawFiles.NewLawFilesRow();

            LawFilesRowObject.Law_ID = Int32.Parse(ViewState["LawID"].ToString());

            //////////////////////////// Save Uploaded File To Server /////////////////////////////////////
            if (Session["LawsFile"] != null)
            {
                DirectoryInfo DirectoryInfoObject = new DirectoryInfo(Server.MapPath("~//GovsFiles//ORG_" + Session["OrgID"].ToString() + "_Files//Laws"));
                if (!DirectoryInfoObject.Exists)
                {
                    DirectoryInfoObject.Create();
                }
                FileInfo Projectfile = new FileInfo(Session["LawsFile"].ToString());
                if (Projectfile.Exists)
                {
                    try
                    {
                        FileInfo ServerProjectFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + Projectfile.Name);
                        if (ServerProjectFile.Exists)
                            ServerProjectFile.Delete();
                        Projectfile.CopyTo(DirectoryInfoObject.FullName + "\\" + Projectfile.Name);
                        LawFilesRowObject.File_Path = Projectfile.Name;
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
            }

            ////////////////////////////////////////////////////////////////////////////////////////////
            LawFilesDSObject.LawFiles.AddLawFilesRow(LawFilesRowObject);
            LawFilesBizObject.InsertLawFiles(LawFilesDSObject);

            GridView2.DataSource = LawFilesBizObject.PopulateList("Law_ID=" + ViewState["LawID"].ToString());
            GridView2.DataBind();

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
    protected void CHBHighlight_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox CHBVisable = ((CheckBox)sender);
            if (CHBVisable.Checked)
            {
                int RowIndex = ((GridViewRow)((CheckBox)sender).Parent.Parent).RowIndex;

                LawsBiz LawsBizObject = new LawsBiz();
                LawsDS LawsDSObject = LawsBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString() + " and IsLegislation=1");

                decimal RecordID = Decimal.Parse(LawsDSObject.Laws.Rows[RowIndex]["Law_ID"].ToString());
                decimal RecordType = 3;
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

                LawsBiz LawsBizObject = new LawsBiz();
                LawsDS LawsDSObject = LawsBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString() + " and IsLegislation=1");

                decimal RecordID = Decimal.Parse(LawsDSObject.Laws.Rows[RowIndex]["Law_ID"].ToString());
                string Type = "3";

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

            LawsBiz LawsBizObject = new LawsBiz();
            LawsDS LawsDSObject = LawsBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString() + " and IsLegislation=1");

            decimal RecordID = Decimal.Parse(LawsDSObject.Laws.Rows[RowIndex]["Law_ID"].ToString());
            string Type = "3";

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
    // maryam
    protected void FileDel_Click(object sender, EventArgs e)
    {
        string LawID = (ViewState["LawID"]).ToString();
        string SQL = "delete from LawFiles where Law_ID = " + LawID;
        Populate(SQL);

        LITFileName.Text = "";

    }
}
