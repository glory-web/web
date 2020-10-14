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

public partial class UserControls_Services : System.Web.UI.UserControl
{

    OrganizationsBiz OrganizationsBizObject = new OrganizationsBiz();
    OrganizationsDS OrganizationsDSObject;

    protected void Page_Load(object sender, EventArgs e)
    {
        BaseDAL.ConnectionString = ConfigurationManager.ConnectionStrings["VSConnectionString"].ToString();

        TXTServiceEnglishName.Style["text-align"] = "left";
        TXTServiceEnglishConditions.Style["text-align"] = "left";
        TXTServiceEnglishProcedures.Style["text-align"] = "left";
        TXTEnglishFileName.Style["text-align"] = "left";
        

        if (Session["OrgID"] == null)
        {
            Response.Redirect("~/BackEnd/default.aspx");
        }
        if (Session["OrgID"] != null)
        {
            if (!IsPostBack)
            {
                ServicesBiz ServicesBizObject = new ServicesBiz();
                ServicesDS ServicesDSObject = ServicesBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());

                if (ServicesDSObject != null && ServicesDSObject.Services.Rows.Count > 0)
                {
                    MultiView1.ActiveViewIndex = 0;
                }
                else
                {
                    ClearCooperationForm();
                    MultiView1.ActiveViewIndex = 1;

                    ViewState["ServiceID"] = null;
                    FileDel.Visible = false;
                }

                GridView1.DataSource = ServicesDSObject;
                GridView1.DataBind();
                FillHighLights();
            }
        }
        
    }

    void ClearCooperationForm()
    {
        try
        {
            this.TXTServiceArabicName.Text = "";
            this.TXTServiceEnglishName.Text = "";
            this.TXTServiceAraicConditions.Text = "";
            this.TXTServiceEnglishConditions.Text = "";
            this.TXTServiceArabicProcedures.Text = "";
            this.TXTServiceEnglishProcedures.Text = "";
            this.TXTFileName.Text = "";
            this.TXTEnglishFileName.Text = "";

            ServiceTypeBiz ServiceTypeBizObject = new ServiceTypeBiz();
            ServiceTypeDS ServiceTypeDSObject = ServiceTypeBizObject.PopulateList("");

            DropDownList1.DataSource = ServiceTypeDSObject;
            DropDownList1.DataBind();

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
            ServicesBiz ServicesBizObject = new ServicesBiz();
            ServicesDS ServicesDSOject = ServicesBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString() + " and Service_ID = " + CooperationID);

            this.TXTServiceArabicName.Text = ServicesDSOject.Services.Rows[0]["Service_Arabic_Name"].ToString();
            this.TXTServiceEnglishName.Text = ServicesDSOject.Services.Rows[0]["Service_English_Name"].ToString();
            this.TXTServiceAraicConditions.Text = ServicesDSOject.Services.Rows[0]["Service_Arabic_Conditions"].ToString();
            this.TXTServiceEnglishConditions.Text = ServicesDSOject.Services.Rows[0]["Service_English_Conditions"].ToString();
            this.TXTServiceArabicProcedures.Text = ServicesDSOject.Services.Rows[0]["Service_Arabic_Procedures"].ToString();
            this.TXTServiceEnglishProcedures.Text = ServicesDSOject.Services.Rows[0]["Service_English_Procedures"].ToString();

            ServiceTypeBiz ServiceTypeBizObject = new ServiceTypeBiz();
            ServiceTypeDS ServiceTypeDSObject = ServiceTypeBizObject.PopulateList("");

            DropDownList1.DataSource = ServiceTypeDSObject;
            DropDownList1.DataBind();

            DropDownList1.SelectedValue = ServicesDSOject.Services.Rows[0]["Type_ID"].ToString();


            ServiceFilesBiz ServiceFilesBizObject = new ServiceFilesBiz();
            ServiceFilesDS ServiceFilesDSObject = ServiceFilesBizObject.PopulateList("Service_ID=" + CooperationID);

            if (ServiceFilesDSObject != null && ServiceFilesDSObject.ServiceFiles.Rows.Count > 0)
            {
                this.TXTFileName.Text = ServiceFilesDSObject.ServiceFiles.Rows[0]["File_Arabic_Name"].ToString();
                this.TXTEnglishFileName.Text = ServiceFilesDSObject.ServiceFiles.Rows[0]["File_English_Name"].ToString();
            }

            LITFileName.Visible = true;
            ServiceFilesBizObject = new ServiceFilesBiz();
            ServiceFilesDSObject = ServiceFilesBizObject.PopulateList("Service_ID=" + CooperationID);
            if (ServiceFilesDSObject.ServiceFiles.Count > 0)
            {
                LITFileName.Text = ServiceFilesDSObject.ServiceFiles.Rows[0]["File_Path"].ToString();
                FileDel.Visible = true;
            }

            ViewState.Add("ServiceID", CooperationID);

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

            ServicesBiz ServicesBizObject = new ServicesBiz();
            ServicesDS ServicesDSOject = ServicesBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString());

            string ServiceID = ServicesDSOject.Services.Rows[RowIndex]["Service_ID"].ToString();

            ViewState.Add("ServiceID", ServiceID);

            if (FillCooperationForm(ServiceID))
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
            Confirm("Â·  —Ìœ «·Õ–› ø");

            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            ServicesBiz ServicesBizObject = new ServicesBiz();
            ServicesDS ServicesDSObject = ServicesBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());

            int ServiceID = Int32.Parse(ServicesDSObject.Services.Rows[RowIndex]["Service_ID"].ToString());

            ServiceFilesBiz ServiceFilesBizObject = new ServiceFilesBiz();
            ServiceFilesDS ServiceFilesDSObject = ServiceFilesBizObject.PopulateList("Service_ID=" + ServiceID.ToString());

            int FileID = Int32.Parse(ServiceFilesDSObject.ServiceFiles.Rows[0]["File_ID"].ToString());

            string SQL = "delete from ServiceFiles where File_ID=" + FileID.ToString();
            Populate(SQL);

            ///////////////////////////////////////////// CV and Photo Not Complete ////////////////////
            if (ServiceFilesDSObject.ServiceFiles.Rows[0]["File_Path"].ToString() != null || ServiceFilesDSObject.ServiceFiles.Rows[0]["File_Path"].ToString() != "")
            {
                DirectoryInfo DirectoryInfoObject = new DirectoryInfo(Server.MapPath("~//GovsFiles//ORG_" + Session["OrgID"].ToString() + "_Files//Services"));
                if (!DirectoryInfoObject.Exists)
                {
                    DirectoryInfoObject.Create();
                }
                try
                {
                    FileInfo ServerProjectFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + ServiceFilesDSObject.ServiceFiles.Rows[0]["File_Path"].ToString());
                    if (ServerProjectFile.Exists)
                        ServerProjectFile.Delete();
                }
                catch (Exception ex)
                {
                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////////

            SQL = "delete from Services where Service_ID=" + ServiceID.ToString();
            Populate(SQL);

            ServicesDSObject = ServicesBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());
            if (ServicesDSObject.Services.Rows.Count <= 0)
            {
                MultiView1.ActiveViewIndex = 1;
            }

            GridView1.DataSource = ServicesBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());
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

            ServicesBiz ServicesBizObject = new ServicesBiz();
            ServicesDS ServicesDSOject = ServicesBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString());

            string ServiceID = ServicesDSOject.Services.Rows[RowIndex]["Service_ID"].ToString();

            ServicesDSOject = ServicesBizObject.Populate(Int32.Parse(ServiceID));

            ViewState.Add("ServiceID", ServiceID);

            MultiView1.ActiveViewIndex = 2;

            Repeater1.DataSource = ServicesDSOject;
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
            ViewState["ServiceID"] = null;
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
            string ServiceArabicName = TXTServiceArabicName.Text;
            string ServiceEnglishName = TXTServiceEnglishName.Text;
            string ServiceArabicConditions = TXTServiceAraicConditions.Text;
            string ServiceEnglishConditions = TXTServiceEnglishConditions.Text;
            string ServiceArabicProcedures = TXTServiceArabicProcedures.Text;
            string ServiceEnglishProcedures = TXTServiceEnglishProcedures.Text;
            int OrgID = Int32.Parse(Session["OrgID"].ToString());

            ServicesBiz ServicesBizObject = new ServicesBiz();
            ServicesDS ServicesDSObject = new ServicesDS();
            ServicesDS.ServicesRow ServicesRowOject = ServicesDSObject.Services.NewServicesRow();

            ServicesRowOject.ORG_ID = OrgID;
            ServicesRowOject.Service_Arabic_Name = ServiceArabicName;
            ServicesRowOject.Service_English_Name = ServiceEnglishName;
            ServicesRowOject.Service_Arabic_Conditions = ServiceArabicConditions;
            ServicesRowOject.Service_English_Conditions = ServiceEnglishConditions;
            ServicesRowOject.Service_Arabic_Procedures = ServiceArabicProcedures;
            ServicesRowOject.Service_English_Procedures = ServiceEnglishProcedures;
            ServicesRowOject.Type_ID = Int32.Parse(DropDownList1.SelectedValue);

            ServicesDSObject.Services.AddServicesRow(ServicesRowOject);
            ServicesDSObject = ServicesBizObject.InsertServices(ServicesDSObject);

            GridView1.DataSource = ServicesBizObject.PopulateList("ORG_ID=" + OrgID);
            GridView1.DataBind();
            FillHighLights();

            string FileName = TXTFileName.Text;
            string EnglishFileName = TXTEnglishFileName.Text;
            string FilePath = FUServiceFile.PostedFile.FileName;

            ServiceFilesBiz ServiceFilesBizObject = new ServiceFilesBiz();
            ServiceFilesDS ServiceFilesDSObject = new ServiceFilesDS();
            ServiceFilesDS.ServiceFilesRow ServiceFilesRowObject = ServiceFilesDSObject.ServiceFiles.NewServiceFilesRow();

            ServiceFilesRowObject.Service_ID = Int32.Parse(ServicesDSObject.Services.Rows[0]["Service_ID"].ToString());
            ServiceFilesRowObject.File_Arabic_Name = FileName;
            ServiceFilesRowObject.File_English_Name = EnglishFileName;
            ServiceFilesRowObject.File_Path = FilePath;

            //////////////////////////// Save Uploaded File To Server /////////////////////////////////////
            if (FUServiceFile.HasFile)
            {
                DirectoryInfo DirectoryInfoObject = new DirectoryInfo(Server.MapPath("~//GovsFiles//ORG_" + Session["OrgID"].ToString() + "_Files//Services"));
                if (!DirectoryInfoObject.Exists)
                {
                    DirectoryInfoObject.Create();
                }

                FileInfo ServerProjectFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + FUServiceFile.FileName);
                if (ServerProjectFile.Exists)
                    ServerProjectFile.Delete();
                FUServiceFile.SaveAs(DirectoryInfoObject.FullName + "\\" + FUServiceFile.FileName);
                ServiceFilesRowObject.File_Path = FUServiceFile.FileName;

                //FileInfo Projectfile = new FileInfo(FUServiceFile.PostedFile.FileName);
                //if (Projectfile.Exists)
                //{
                //    try
                //    {
                //        FileInfo ServerProjectFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + Projectfile.Name);
                //        if (ServerProjectFile.Exists)
                //            ServerProjectFile.Delete();
                //        Projectfile.CopyTo(DirectoryInfoObject.FullName + "\\" + Projectfile.Name);
                //        ServiceFilesRowObject.File_Path = Projectfile.Name;
                //    }
                //    catch (Exception ex)
                //    {
                //    }
                //}
            }

            ////////////////////////////////////////////////////////////////////////////////////////////
            ServiceFilesDSObject.ServiceFiles.AddServiceFilesRow(ServiceFilesRowObject);
            ServiceFilesBizObject.InsertServiceFiles(ServiceFilesDSObject);

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
            string ServiveArabicName = TXTServiceArabicName.Text;
            string ServiceEnglishName = TXTServiceEnglishName.Text;
            string ServiceArabicConditions = TXTServiceAraicConditions.Text;
            string ServiceEnglishConditions = TXTServiceEnglishConditions.Text;
            string ServiceArabicProcedures = TXTServiceArabicProcedures.Text;
            string ServiceEnglishProcedures = TXTServiceEnglishProcedures.Text;
            int OrgID = Int32.Parse(Session["OrgID"].ToString());

            ServicesBiz ServicesBizObject = new ServicesBiz();
            ServicesDS ServicesDSObject = ServicesBizObject.Populate(Int32.Parse(ViewState["ServiceID"].ToString()));

            ServicesDSObject.Services[0].ORG_ID = OrgID;
            ServicesDSObject.Services[0].Service_Arabic_Name = ServiveArabicName;
            ServicesDSObject.Services[0].Service_English_Name = ServiceEnglishName;
            ServicesDSObject.Services[0].Service_Arabic_Conditions = ServiceArabicConditions;
            ServicesDSObject.Services[0].Service_English_Conditions = ServiceEnglishConditions;
            ServicesDSObject.Services[0].Service_Arabic_Procedures = ServiceArabicProcedures;
            ServicesDSObject.Services[0].Service_English_Procedures = ServiceEnglishProcedures;
            ServicesDSObject.Services[0].Type_ID = Int32.Parse(DropDownList1.SelectedValue);

            ServicesBizObject.UpdateServices(ServicesDSObject);

            string FileName = TXTFileName.Text;
            string EnglishFileName = TXTEnglishFileName.Text;
            string FilePath = "";
            string OldServiceFileName = "";
            FileInfo Projectsfile = null;
            if (FUServiceFile.HasFile)
            {
                FilePath = FUServiceFile.PostedFile.FileName;
                Projectsfile = new FileInfo(FUServiceFile.PostedFile.FileName);
            }

            ServiceFilesBiz ServiceFilesBizObject = new ServiceFilesBiz();
            ServiceFilesDS ServiceFilesDSObject = ServiceFilesBizObject.PopulateList("Service_ID=" + ViewState["ServiceID"].ToString());

            if (ServiceFilesDSObject.ServiceFiles.Rows.Count > 0)
            {
                int FileID = Int32.Parse(ServiceFilesDSObject.ServiceFiles.Rows[0]["File_ID"].ToString());
                ServiceFilesDSObject = ServiceFilesBizObject.Populate(FileID);

                OldServiceFileName = ServiceFilesDSObject.ServiceFiles[0].File_Path;
                if (FUServiceFile.HasFile)
                {
                    ServiceFilesDSObject.ServiceFiles[0].File_Path = Projectsfile.Name;
                }
                else
                {
                    ServiceFilesDSObject.ServiceFiles[0].File_Path = OldServiceFileName;
                }
                ServiceFilesDSObject.ServiceFiles[0].Service_ID = Int32.Parse(ViewState["ServiceID"].ToString());
                ServiceFilesDSObject.ServiceFiles[0].File_Arabic_Name = FileName;
                ServiceFilesDSObject.ServiceFiles[0].File_English_Name = EnglishFileName;

                ServiceFilesBizObject.UpdateServiceFiles(ServiceFilesDSObject);
            }
            else
            {
                ServiceFilesBizObject = new ServiceFilesBiz();
                ServiceFilesDSObject = new ServiceFilesDS();
                ServiceFilesDS.ServiceFilesRow ServiceFilesRowObject = ServiceFilesDSObject.ServiceFiles.NewServiceFilesRow();

                ServiceFilesRowObject.Service_ID = Int32.Parse(ServicesDSObject.Services.Rows[0]["Service_ID"].ToString());
                ServiceFilesRowObject.File_Arabic_Name = FileName;
                ServiceFilesRowObject.File_English_Name = EnglishFileName;

                if (FUServiceFile.HasFile)
                {
                    ServiceFilesRowObject.File_Path = Projectsfile.Name;
                }
                else
                {
                    ServiceFilesRowObject.File_Path = null;
                }
                ServiceFilesDSObject.ServiceFiles.AddServiceFilesRow(ServiceFilesRowObject);
                ServiceFilesBizObject.InsertServiceFiles(ServiceFilesDSObject);
            }
           //////////////////////////// Save Uploaded File To Server /////////////////////////////////////
            
            if (FUServiceFile.HasFile)
            {
                DirectoryInfo DirectoryInfoObject = new DirectoryInfo(Server.MapPath("~//GovsFiles//ORG_" + Session["OrgID"].ToString() + "_Files//Services"));
                if (!DirectoryInfoObject.Exists)
                {
                    DirectoryInfoObject.Create();
                }

                FileInfo ServerOldProjectsFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + OldServiceFileName);
                if (ServerOldProjectsFile.Exists)
                    ServerOldProjectsFile.Delete();

                FileInfo ServerOrojectsFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + FUServiceFile.FileName);
                if (ServerOrojectsFile.Exists)
                    ServerOrojectsFile.Delete();
                FUServiceFile.SaveAs(DirectoryInfoObject.FullName + "\\" + FUServiceFile.FileName);

                //Projectsfile = new FileInfo(FUServiceFile.PostedFile.FileName);
                //if (Projectsfile.Exists)
                //{
                //    try
                //    {
                //        FileInfo ServerOldProjectsFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + OldServiceFileName);
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

            GridView1.DataSource = ServicesBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());
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
                ServiceFilesBiz ServiceFilesBizObject = new ServiceFilesBiz();
                ServiceFilesDS ServiceFilesDSOject = ServiceFilesBizObject.PopulateList("Service_ID = " + ViewState["ServiceID"].ToString());

                ServiceFilesDSOject.ServiceFiles.Columns.Add("ORG_ID");
                ServiceFilesDSOject.ServiceFiles.Rows[0]["ORG_ID"] = Session["OrgID"].ToString();

                ((Repeater)e.Item.FindControl("Repeater2")).DataSource = ServiceFilesDSOject;
                ((Repeater)e.Item.FindControl("Repeater2")).DataBind();
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

                ServicesBiz ServicesBizObject = new ServicesBiz();
                ServicesDS ServicesDSObject = ServicesBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());

                decimal RecordID = Decimal.Parse(ServicesDSObject.Services.Rows[RowIndex]["Service_ID"].ToString());
                decimal RecordType = 6;
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

                ServicesBiz ServicesBizObject = new ServicesBiz();
                ServicesDS ServicesDSObject = ServicesBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());

                decimal RecordID = Decimal.Parse(ServicesDSObject.Services.Rows[RowIndex]["Service_ID"].ToString());
                string Type = "6";

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

            ServicesBiz ServicesBizObject = new ServicesBiz();
            ServicesDS ServicesDSObject = ServicesBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());

            decimal RecordID = Decimal.Parse(ServicesDSObject.Services.Rows[RowIndex]["Service_ID"].ToString());
            string Type = "6";

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
        string ServiceIS = (ViewState["ServiceID"]).ToString();
        string SQL = "delete from ServiceFiles where Service_ID = " + ServiceIS;
        Populate(SQL);

        LITFileName.Text = "";
    }
}
