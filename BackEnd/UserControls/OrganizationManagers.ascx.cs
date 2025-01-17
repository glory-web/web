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

public partial class UserControls_OrganizationManagers : System.Web.UI.UserControl
{
   
    OrganizationsBiz OrganizationsBizObject = new OrganizationsBiz();
    OrganizationsDS OrganizationsDSObject;

    protected void Page_Load(object sender, EventArgs e)
    {
        TXTManagerEnglishName.Style["text-align"] = "left";
        TXTEmail.Style["text-align"] = "left";
        TXTManEnglishWord.Style["text-align"] = "left";

        
        BaseDAL.ConnectionString = ConfigurationManager.ConnectionStrings["VSConnectionString"].ToString();

        if (Session["OrgID"] == null)
        {
            Response.Redirect("~/BackEnd/default.aspx");
        }
        if (Session["OrgID"] != null)
        {
            if (!IsPostBack)
            {
                OrganizationMangersBiz OrganizationMangersBizObject = new OrganizationMangersBiz();
                OrganizationMangersDS OrganizationMangersDSObject = OrganizationMangersBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());

                if (OrganizationMangersDSObject != null && OrganizationMangersDSObject.OrganizationMangers.Rows.Count > 0)
                {
                    MultiView1.ActiveViewIndex = 0;
                }
                else
                {
                    ClearCooperationForm();
                    MultiView1.ActiveViewIndex = 1;

                    ViewState["OrganizationMangerID"] = null;
                }

                GridView1.DataSource = OrganizationMangersDSObject;
                GridView1.DataBind();
            }
        }
        
    }

    void ClearCooperationForm()
    {
        try
        {
            this.TXTManagerArabicName.Text = "";
            this.TXTManagerEnglishName.Text = "";
            this.TXTManagerBirthDate.Text = "01/01/2014";
            this.TXTManagerStartDate.Text = "";
            this.TXTManagerStartDate.Text = "";
            this.TXTManagerEndDate.Text = "";
            this.TXTManagerTelephone.Text = "";
            this.TXTManArabicWord.Text = "";
            this.TXTManEnglishWord.Text = "";

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
            OrganizationMangersBiz OrganizationMangersBizObject = new OrganizationMangersBiz();
            OrganizationMangersDS OrganizationMangersDSOject = OrganizationMangersBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString() + " and Man_ID = " + CooperationID);

            this.TXTManagerArabicName.Text = OrganizationMangersDSOject.OrganizationMangers.Rows[0]["Man_Arabic_Name"].ToString();
            this.TXTManagerEnglishName.Text = OrganizationMangersDSOject.OrganizationMangers.Rows[0]["Man_English_Name"].ToString();
            this.TXTManArabicWord.Text = OrganizationMangersDSOject.OrganizationMangers.Rows[0]["Man_Arabic_Word"].ToString();
            this.TXTManEnglishWord.Text = OrganizationMangersDSOject.OrganizationMangers.Rows[0]["Man_English_Word"].ToString();

            DateTime ManagerBirthDate = new DateTime();
            ManagerBirthDate = DateTime.Parse(OrganizationMangersDSOject.OrganizationMangers.Rows[0]["Man_Birth_Date"].ToString());
            string DTManagerBirthDate = ManagerBirthDate.Day.ToString() + "/" + ManagerBirthDate.Month + "/" + ManagerBirthDate.Year;
            this.TXTManagerBirthDate.Text = DTManagerBirthDate;

            DateTime ManagerStartDate = new DateTime();
            ManagerStartDate= DateTime.Parse(OrganizationMangersDSOject.OrganizationMangers.Rows[0]["Man_Start_Date"].ToString());
            string DTManagerStartDate = ManagerStartDate.Day.ToString() + "/" + ManagerStartDate.Month + "/" + ManagerStartDate.Year;
            this.TXTManagerStartDate.Text = DTManagerStartDate;

            DateTime ManEndDate = new DateTime();
            ManEndDate = DateTime.Parse(OrganizationMangersDSOject.OrganizationMangers.Rows[0]["Man_End_Date"].ToString());
            string DTManEndDate = ManEndDate.Day.ToString() + "/" + ManEndDate.Month + "/" + ManEndDate.Year;

            this.TXTManagerEndDate.Text = DTManEndDate;
            this.TXTManagerTelephone.Text = OrganizationMangersDSOject.OrganizationMangers.Rows[0]["Man_Telephone"].ToString();

            this.TXTEmail.Text = OrganizationMangersDSOject.OrganizationMangers.Rows[0]["Man_Email"].ToString();
            if (Boolean.Parse(OrganizationMangersDSOject.OrganizationMangers.Rows[0]["State"].ToString()) == true)
            {
                this.CheckBox1.Checked = true;
                this.LeaveDate.Visible = true;
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

            OrganizationMangersBiz OrganizationMangersBizObject = new OrganizationMangersBiz();
            OrganizationMangersDS OrganizationMangersDSOject = OrganizationMangersBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString());

            string OrganizationMangerID = OrganizationMangersDSOject.OrganizationMangers.Rows[RowIndex]["Man_ID"].ToString();

            ViewState.Add("OrganizationMangerID", OrganizationMangerID);

            if (FillCooperationForm(OrganizationMangerID))
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

            OrganizationMangersBiz OrganizationMangersBizObject = new OrganizationMangersBiz();
            OrganizationMangersDS OrganizationMangersDSObject = OrganizationMangersBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());

            int OrganizationMangerID = Int32.Parse(OrganizationMangersDSObject.OrganizationMangers.Rows[RowIndex]["Man_ID"].ToString());

            string SQL = "delete from OrganizationMangers where Man_ID=" + OrganizationMangerID.ToString();
            Populate(SQL);

            ///////////////////////////////////////////// CV and Photo Not Complete ////////////////////
            if (OrganizationMangersDSObject.OrganizationMangers.Rows[RowIndex]["Man_CV_Path"].ToString() != null || OrganizationMangersDSObject.OrganizationMangers.Rows[RowIndex]["Man_CV_Path"].ToString() != "")
            {
                DirectoryInfo DirectoryInfoObject = new DirectoryInfo(Server.MapPath("~//GovsFiles//ORG_" + Session["OrgID"].ToString() + "_Files//Managers//CV"));
                if (!DirectoryInfoObject.Exists)
                {
                    DirectoryInfoObject.Create();
                }
                try
                {
                    FileInfo ServerCVFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + OrganizationMangersDSObject.OrganizationMangers.Rows[RowIndex]["Man_CV_Path"].ToString());
                    if (ServerCVFile.Exists)
                        ServerCVFile.Delete();
                }
                catch (Exception ex)
                {
                }
            }
            if (OrganizationMangersDSObject.OrganizationMangers.Rows[RowIndex]["Man_Photo_Path"].ToString() != null || OrganizationMangersDSObject.OrganizationMangers.Rows[RowIndex]["Man_Photo_Path"].ToString() != "")
            {
                DirectoryInfo DirectoryInfoObject = new DirectoryInfo(Server.MapPath("~//GovsFiles//ORG_" + Session["OrgID"].ToString() + "_Files//Managers//Photos"));
                if (!DirectoryInfoObject.Exists)
                {
                    DirectoryInfoObject.Create();
                }
                try
                {
                    FileInfo ServerPhotoFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + OrganizationMangersDSObject.OrganizationMangers.Rows[RowIndex]["Man_Photo_Path"].ToString());
                    if (ServerPhotoFile.Exists)
                        ServerPhotoFile.Delete();
                }
                catch (Exception ex)
                {
                }
            }
            ////////////////////////////////////////////////////////////////////////////////////////////

            GridView1.DataSource = OrganizationMangersBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());
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

            OrganizationMangersBiz OrganizationMangersBizObject = new OrganizationMangersBiz();
            OrganizationMangersDS OrganizationMangersDSOject = OrganizationMangersBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString());

            string ManagerID = OrganizationMangersDSOject.OrganizationMangers.Rows[RowIndex]["Man_ID"].ToString();

            OrganizationMangersDSOject = OrganizationMangersBizObject.Populate(Int32.Parse(ManagerID));

            ViewState.Add("ManagerID", ManagerID);

            MultiView1.ActiveViewIndex = 2;

            Repeater1.DataSource = OrganizationMangersDSOject;
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
            ViewState["OrganizationMangerID"] = null;
        }
        catch (Exception ex)
        {
        }
    }
    protected void BTNAdd_Click(object sender, EventArgs e)
    {
        try
        {
            //if (!FileUpload1.HasFile)
            //{
            //    Page.RegisterStartupScript("ErrorMsg", "<script>alert('لابد من رفع ملف السيرة الذاتية');</script>");
            //    return;
            //}
            //if (!FileUpload2.HasFile)
            //{
            //    Page.RegisterStartupScript("ErrorMsg", "<script>alert('لابد من رفع ملف الصورة');</script>");
            //    return;
            //}
            string ManagerAraicName = TXTManagerArabicName.Text;
            string ManagerEnglishName = TXTManagerEnglishName.Text;
            string ManagerBirthDate = TXTManagerBirthDate.Text;
            string ManagerStartDate = TXTManagerStartDate.Text;
            string ManagerEndDate = TXTManagerEndDate.Text;
            string ManagerTelephone = TXTManagerTelephone.Text;
            string ManagerArabicWord = TXTManArabicWord.Text;
            string ManagerEnglishWord = TXTManEnglishWord.Text;
            string ManagerEmail = TXTEmail.Text;
            bool ManagerState;
            if (CheckBox1.Checked)
                ManagerState = true;
            else
                ManagerState = false;

            int OrgID = Int32.Parse(Session["OrgID"].ToString());
            DateTime DTManagerBirthDate = new DateTime(Int32.Parse(ManagerBirthDate.Substring(6, 4)), Int32.Parse(ManagerBirthDate.Substring(3, 2)), Int32.Parse(ManagerBirthDate.Substring(0, 2)));
            //DateTime DTManagerBirthDate = DateTime.Parse(ManagerBirthDate);
            DateTime DTManagerStartDate = new DateTime(Int32.Parse(ManagerStartDate.Substring(6, 4)), Int32.Parse(ManagerStartDate.Substring(3, 2)), Int32.Parse(ManagerStartDate.Substring(0, 2)));
            //DateTime DTManagerStartDate = DateTime.Parse(ManagerStartDate);
            DateTime DTManagerEndDate = new DateTime(1800,1,1);


            if (ManagerEndDate != "" && LeaveDate.Visible != false)
            {
                DTManagerEndDate = new DateTime(Int32.Parse(ManagerEndDate.Substring(6, 4)), Int32.Parse(ManagerEndDate.Substring(3, 2)), Int32.Parse(ManagerEndDate.Substring(0, 2)));
                //DTManagerEndDate = DateTime.Parse(ManagerEndDate);
            }
            
            OrganizationMangersBiz OrganizationMangersBizObject = new OrganizationMangersBiz();
            OrganizationMangersDS OrganizationMangersDSObject = new OrganizationMangersDS();
            OrganizationMangersDS.OrganizationMangersRow OrganizationMangersRowOject = OrganizationMangersDSObject.OrganizationMangers.NewOrganizationMangersRow();

            OrganizationMangersRowOject.ORG_ID = OrgID;
            OrganizationMangersRowOject.Man_Arabic_Name = ManagerAraicName;
            OrganizationMangersRowOject.Man_English_Name = ManagerEnglishName;
            OrganizationMangersRowOject.Man_Birth_Date = DTManagerBirthDate;
            OrganizationMangersRowOject.Man_Start_Date = DTManagerStartDate;
            OrganizationMangersRowOject.Man_End_Date = DTManagerEndDate;
            OrganizationMangersRowOject.Man_Telephone = ManagerTelephone;
            OrganizationMangersRowOject.State = ManagerState;
            OrganizationMangersRowOject.Man_Arabic_Word = ManagerArabicWord;
            OrganizationMangersRowOject.Man_English_Word = ManagerEnglishWord;
            OrganizationMangersRowOject.Man_Email = ManagerEmail;
            ///////////////////////////////////////////// CV and Photo Not Complete ////////////////////
            if (FileUpload1.HasFile)
            {
                DirectoryInfo DirectoryInfoObject = new DirectoryInfo(Server.MapPath("~//GovsFiles//ORG_" + Session["OrgID"].ToString() + "_Files//Managers//CV"));
                if (!DirectoryInfoObject.Exists)
                {
                    DirectoryInfoObject.Create();
                }

                FileInfo ServerCVFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + FileUpload1.FileName);
                if (ServerCVFile.Exists)
                    ServerCVFile.Delete();
                FileUpload1.SaveAs(DirectoryInfoObject.FullName + "\\" + FileUpload1.FileName);
                OrganizationMangersRowOject.Man_CV_Path = FileUpload1.FileName;
            }
            else
            {
                OrganizationMangersRowOject.Man_CV_Path = "";
            }
            if (FileUpload2.HasFile)
            {
                DirectoryInfo DirectoryInfoObject = new DirectoryInfo(Server.MapPath("~//GovsFiles//ORG_" + Session["OrgID"].ToString() + "_Files//Managers//Photos"));
                if (!DirectoryInfoObject.Exists)
                {
                    DirectoryInfoObject.Create();
                }

                FileInfo ServerPhotoFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + FileUpload2.FileName);
                if (ServerPhotoFile.Exists)
                    ServerPhotoFile.Delete();
                FileUpload2.SaveAs(DirectoryInfoObject.FullName + "\\" + FileUpload2.FileName);
                OrganizationMangersRowOject.Man_Photo_Path = FileUpload2.FileName;
            }
            else
            {
                OrganizationMangersRowOject.Man_Photo_Path = "";
            }
            ////////////////////////////////////////////////////////////////////////////////////////////

            OrganizationMangersDSObject.OrganizationMangers.AddOrganizationMangersRow(OrganizationMangersRowOject);
            OrganizationMangersDSObject = OrganizationMangersBizObject.InsertOrganizationMangers(OrganizationMangersDSObject);

            GridView1.DataSource = OrganizationMangersBizObject.PopulateList("ORG_ID=" + OrgID);
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
            string ManagerAraicName = TXTManagerArabicName.Text;
            string ManagerEnglishName = TXTManagerEnglishName.Text;
            string ManagerBirthDate = TXTManagerBirthDate.Text;
            string ManagerStartDate = TXTManagerStartDate.Text;
            string ManagerEndDate = TXTManagerEndDate.Text;
            string ManagerTelephone = TXTManagerTelephone.Text;
            string ManagerArabicWord = TXTManArabicWord.Text;
            string ManagerEnglishWord = TXTManEnglishWord.Text;
            string ManagerEmail = TXTEmail.Text;
            int OrgID = Int32.Parse(Session["OrgID"].ToString());

            DateTime DTManagerBirthDate = new DateTime(Int32.Parse(ManagerBirthDate.Substring(6, 4)), Int32.Parse(ManagerBirthDate.Substring(3, 2)), Int32.Parse(ManagerBirthDate.Substring(0, 2)));
            //DateTime DTManagerBirthDate = DateTime.Parse(ManagerBirthDate);
            DateTime DTManagerStartDate = new DateTime(Int32.Parse(ManagerStartDate.Substring(6, 4)), Int32.Parse(ManagerStartDate.Substring(3, 2)), Int32.Parse(ManagerStartDate.Substring(0, 2)));
            //DateTime DTManagerStartDate = DateTime.Parse(ManagerStartDate);
            DateTime DTManagerEndDate = new DateTime(1800, 1, 1);
           
            bool ManagerState;
            if (CheckBox1.Checked)
                ManagerState = true;
            else
                ManagerState = false;

            if (ManagerEndDate != "" && LeaveDate.Visible != false)
            {
                DTManagerEndDate = new DateTime(Int32.Parse(ManagerEndDate.Substring(6, 4)), Int32.Parse(ManagerEndDate.Substring(3, 2)), Int32.Parse(ManagerEndDate.Substring(0, 2)));
                //DTManagerEndDate = DateTime.Parse(ManagerEndDate);
            }


            OrganizationMangersBiz OrganizationMangersBizObject = new OrganizationMangersBiz();
            OrganizationMangersDS OrganizationMangersDSObject = OrganizationMangersBizObject.Populate(Int32.Parse(ViewState["OrganizationMangerID"].ToString()));

            OrganizationMangersDSObject.OrganizationMangers[0].ORG_ID = OrgID;
            OrganizationMangersDSObject.OrganizationMangers[0].Man_Arabic_Name = ManagerAraicName;
            OrganizationMangersDSObject.OrganizationMangers[0].Man_English_Name = ManagerEnglishName;
            OrganizationMangersDSObject.OrganizationMangers[0].Man_Birth_Date = DTManagerBirthDate;
            OrganizationMangersDSObject.OrganizationMangers[0].Man_Start_Date = DTManagerStartDate;
            OrganizationMangersDSObject.OrganizationMangers[0].Man_End_Date = DTManagerEndDate;
            OrganizationMangersDSObject.OrganizationMangers[0].Man_Telephone = ManagerTelephone;
            OrganizationMangersDSObject.OrganizationMangers[0].Man_Arabic_Word = ManagerArabicWord;
            OrganizationMangersDSObject.OrganizationMangers[0].Man_English_Word = ManagerEnglishWord;
            OrganizationMangersDSObject.OrganizationMangers[0].State = ManagerState;
            OrganizationMangersDSObject.OrganizationMangers[0].Man_Email = ManagerEmail;
            ///////////////////////////// CV Photo Not Complete //////////////////////////////
            if (FileUpload1.HasFile)
            {
                DirectoryInfo DirectoryInfoObject = new DirectoryInfo(Server.MapPath("~//GovsFiles//ORG_" + Session["OrgID"].ToString() + "_Files//Managers//CV"));
                if (!DirectoryInfoObject.Exists)
                {
                    DirectoryInfoObject.Create();
                }

                FileInfo ServerCVFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + FileUpload1.FileName);
                if (ServerCVFile.Exists)
                    ServerCVFile.Delete();
                FileUpload1.SaveAs(DirectoryInfoObject.FullName + "\\" + FileUpload1.FileName);
                OrganizationMangersDSObject.OrganizationMangers[0].Man_CV_Path = FileUpload1.FileName;

                //FileInfo CVfile = new FileInfo(FileUpload1.PostedFile.FileName);
                //if (CVfile.Exists)
                //{
                //    try
                //    {
                //        FileInfo ServerCVFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + CVfile.Name);
                //        if (ServerCVFile.Exists)
                //            ServerCVFile.Delete();
                //        CVfile.CopyTo(DirectoryInfoObject.FullName + "\\" + CVfile.Name);
                //        OrganizationMangersDSObject.OrganizationMangers[0].Man_CV_Path = CVfile.Name;
                //    }
                //    catch (Exception ex)
                //    {
                //    }
                //}
            }
            if (FileUpload2.HasFile)
            {
                DirectoryInfo DirectoryInfoObject = new DirectoryInfo(Server.MapPath("~//GovsFiles//ORG_" + Session["OrgID"].ToString() + "_Files//Managers//Photos"));
                if (!DirectoryInfoObject.Exists)
                {
                    DirectoryInfoObject.Create();
                }

                FileInfo ServerPhotoFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + FileUpload2.FileName);
                if (ServerPhotoFile.Exists)
                    ServerPhotoFile.Delete();
                FileUpload2.SaveAs(DirectoryInfoObject.FullName + "\\" + FileUpload2.FileName);
                OrganizationMangersDSObject.OrganizationMangers[0].Man_Photo_Path = FileUpload2.FileName;

                //FileInfo Photofile = new FileInfo(FileUpload2.PostedFile.FileName);
                //if (Photofile.Exists)
                //{
                //    try
                //    {
                //        FileInfo ServerPhotoFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + Photofile.Name);
                //        if (ServerPhotoFile.Exists)
                //            ServerPhotoFile.Delete();
                //        Photofile.CopyTo(DirectoryInfoObject.FullName + "\\" + Photofile.Name);
                //        OrganizationMangersDSObject.OrganizationMangers[0].Man_Photo_Path = Photofile.Name;
                //    }
                //    catch (Exception ex)
                //    {
                //    }
                //}
            }
            //////////////////////////////////////////////////////////////////////////////////

            OrganizationMangersBizObject.UpdateOrganizationMangers(OrganizationMangersDSObject);

            GridView1.EditIndex = -1;
            GridView1.DataSource = OrganizationMangersBizObject.PopulateList("ORG_ID=" + OrgID);
            GridView1.DataBind();

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
                string ManBirthDate = dr["Man_Birth_Date"].ToString();
                //string DTManBirthDate = new DateTime(Int32.Parse(ManBirthDate.Substring(6, 4)), Int32.Parse(ManBirthDate.Substring(3, 2)), Int32.Parse(ManBirthDate.Substring(0, 2))).ToShortDateString();
                string DTManBirthDate = DateTime.Parse(ManBirthDate).ToShortDateString();
                ((Literal)e.Item.FindControl("Literal12")).Text = DTManBirthDate;

                string ManStartDate = dr["Man_Start_Date"].ToString();
                //string DTManStartDate = new DateTime(Int32.Parse(ManStartDate.Substring(6, 4)), Int32.Parse(ManStartDate.Substring(3, 2)), Int32.Parse(ManStartDate.Substring(0, 2))).ToShortDateString();
                string DTManStartDate = DateTime.Parse(ManStartDate).ToShortDateString();
                ((Literal)e.Item.FindControl("Literal14")).Text = DTManStartDate;

                if (Boolean.Parse(dr["State"].ToString()) == true)
                {
                    ((Literal)e.Item.FindControl("Literal15")).Visible = false;
                    ((Literal)e.Item.FindControl("Literal16")).Visible = false;
                }

                string ManEndDate = dr["Man_End_Date"].ToString();
                //string DTManEndDate = new DateTime(Int32.Parse(ManEndDate.Substring(6, 4)), Int32.Parse(ManEndDate.Substring(3, 2)), Int32.Parse(ManEndDate.Substring(0, 2))).ToShortDateString();
                string DTManEndDate = DateTime.Parse(ManEndDate).ToShortDateString();
                ((Literal)e.Item.FindControl("Literal16")).Text = DTManEndDate;

                ((CheckBox)e.Item.FindControl("CheckBox2")).Enabled = false;

                OrganizationMangersBiz OrganizationMangersBizObject =   new OrganizationMangersBiz();
                OrganizationMangersDS OrganizationMangersDSOject = OrganizationMangersBizObject.Populate(Int32.Parse(ViewState["ManagerID"].ToString()));

                string PhotoPath = "~//GovsFiles//ORG_" + Session["OrgID"].ToString() + "_Files//Managers//Photos//" + OrganizationMangersDSOject.OrganizationMangers[0]["Man_Photo_Path"].ToString();
                ((Image)e.Item.FindControl("Image1")).ImageUrl = PhotoPath;
                ((Image)e.Item.FindControl("Image1")).DataBind();

            }
            catch (Exception ex)
            {
            }
        }
    }
    //protected void LinkButton1_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string strScript = "@SCRIPT>openupload(); @/SCRIPT>";
    //        Page.RegisterStartupScript("AlertMsg", strScript.Replace("@", "<"));
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked)
        {
            LeaveDate.Visible = true;
        }
        else
        {
            this.TXTManagerEndDate.Text = "";
            LeaveDate.Visible = false; ;
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
