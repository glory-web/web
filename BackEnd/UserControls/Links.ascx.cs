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

public partial class UserControls_Links : System.Web.UI.UserControl
{
   
    OrganizationsBiz OrganizationsBizObject = new OrganizationsBiz();
    OrganizationsDS OrganizationsDSObject;

    private void TextBoxsTextDirection()
    {
        TXTLinkArabicName.Style["text-align"] = "right";
        TXTLinkEnglishName.Style["text-align"] = "left";
      //  TXTURL.Style["text-align"] = "left";
        TXTLogoArabicTitle.Style["text-align"] = "right";
        TXTLogoEnglishTitle.Style["text-align"] = "left";

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        BaseDAL.ConnectionString = ConfigurationManager.ConnectionStrings["VSConnectionString"].ToString();
        
        TXTLinkEnglishName.Style["text-align"] = "left";
     //   TXTURL.Style["text-align"] = "left";
        TXTLogoEnglishTitle.Style["text-align"] = "left";

        
        if (Session["OrgID"] == null)
        {
            Response.Redirect("~/BackEnd/default.aspx");
        }
        if (Session["OrgID"] != null)
        {

            if (!IsPostBack)
            {
                try
                {
                    LinksBiz LinksBizObject = new LinksBiz();
                    LinksDS LinksDSObject = LinksBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());

                    if (LinksDSObject != null && LinksDSObject.Links.Rows.Count > 0)
                    {
                        MultiView1.ActiveViewIndex = 0;
                    }
                    else
                    {
                        ClearCooperationForm();
                        MultiView1.ActiveViewIndex = 1;

                        ViewState["LinkID"] = null;
                    }

                    GridView1.DataSource = LinksDSObject;
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                }
            }
        }
        TextBoxsTextDirection();
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

            LinksBiz LinksBizObject = new LinksBiz();
            LinksDS LinksDSObject = LinksBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());

            int LinkID = Int32.Parse(LinksDSObject.Links.Rows[RowIndex]["Link_ID"].ToString());

            ViewState.Add("LinkID", LinkID);
            GridView1.EditIndex = RowIndex;

            GridView1.DataSource = LinksDSObject;
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    protected void LBTNDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            LinksBiz LinksBizObject = new LinksBiz();
            LinksDS LinksDSObject = LinksBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());

            int LinkID = Int32.Parse(LinksDSObject.Links.Rows[RowIndex]["Link_ID"].ToString());

            string SQL = "delete from Links where Link_ID=" + LinkID.ToString();
            Populate(SQL);

            ///////////////////////////////////////////// CV and Photo Not Complete ////////////////////
            if (LinksDSObject.Links.Rows[RowIndex]["Link_Logo_Path"].ToString() != null || LinksDSObject.Links.Rows[RowIndex]["Link_Logo_Path"].ToString() != "")
            {
                DirectoryInfo DirectoryInfoObject = new DirectoryInfo(Server.MapPath("~//GovsFiles//ORG_" + Session["OrgID"].ToString() + "_Files//Links"));
                if (!DirectoryInfoObject.Exists)
                {
                    DirectoryInfoObject.Create();
                }
                try
                {
                    FileInfo ServerProjectFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + LinksDSObject.Links.Rows[RowIndex]["Link_Logo_Path"].ToString());
                    if (ServerProjectFile.Exists)
                        ServerProjectFile.Delete();
                }
                catch (Exception ex)
                {
                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////////

            GridView1.DataSource = LinksBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    protected void LBTNCancel_Click(object sender, EventArgs e)
    {
        try
        {
            LinksBiz LinksBizObject = new LinksBiz();
            GridView1.EditIndex = -1;
            GridView1.DataSource = LinksBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());
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
            string LinkAraicName = ((TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXTLinkArabicName")).Text;
            string LinkEnglishName = ((TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXTLinkEnglishName")).Text;
            string LinkURL = ((TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXTURL")).Text;
            string LogoArabicName = ((TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXTLogoArabicName")).Text;
            string LogoEnglishName = ((TextBox)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("TXTLogoEnglishName")).Text;
            int OrgID = Int32.Parse(Session["OrgID"].ToString());

            ////////////////////////////////// Logo Upload Not Complete ///////////////////////////////

            LinksBiz LinksBizObject = new LinksBiz();
            LinksDS LinksDSObject = new LinksDS();
            LinksDS.LinksRow LinksRowOject = LinksDSObject.Links.NewLinksRow();

            LinksRowOject.ORG_ID = OrgID;
            LinksRowOject.Link_Arabic_Name = LinkAraicName;
            LinksRowOject.Link_English_Name = LinkEnglishName;
            LinksRowOject.Link_URL = LinkURL;
            LinksRowOject.Link_Logo_Arabic_Title = LogoArabicName;
            LinksRowOject.Link_Logo_English_Title = LogoEnglishName;

            //////////////////////////// Save Uploaded File To Server /////////////////////////////////////
            if (Session["LogoFile"] != null)
            {
                DirectoryInfo DirectoryInfoObject = new DirectoryInfo(Server.MapPath("~//GovsFiles//ORG_" + Session["OrgID"].ToString() + "_Files//Links"));
                if (!DirectoryInfoObject.Exists)
                {
                    DirectoryInfoObject.Create();
                }
                FileInfo Projectfile = new FileInfo(Session["LogoFile"].ToString());
                if (Projectfile.Exists)
                {
                    try
                    {
                        FileInfo ServerProjectFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + Projectfile.Name);
                        if (ServerProjectFile.Exists)
                            ServerProjectFile.Delete();
                        Projectfile.CopyTo(DirectoryInfoObject.FullName + "\\" + Projectfile.Name);
                        LinksRowOject.Link_Logo_Path = Projectfile.Name;
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

            ////////////////////////////////////////////////////////////////////////////////////////////

            LinksDSObject.Links.AddLinksRow(LinksRowOject);
            LinksBizObject.InsertLinks(LinksDSObject);

            GridView1.DataSource = LinksBizObject.PopulateList("ORG_ID=" + OrgID);
            GridView1.DataBind();

        }
        catch (Exception ex)
        {
        }
    }


///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    protected void LBTNEdit_Click1(object sender, EventArgs e)
    {
        try
        {
            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            LinksBiz LinksBizObject = new LinksBiz();
            LinksDS LinksDSOject = LinksBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString());

            string LinkID = LinksDSOject.Links.Rows[RowIndex]["Link_ID"].ToString();

            ViewState.Add("LinkID", LinkID);

            if (FillCooperationForm(LinkID))
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
            LinksBiz LinksBizObject = new LinksBiz();
            LinksDS LinksDSOject = LinksBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString() + " and Link_ID = " + CooperationID);

            this.TXTLinkArabicName.Text = LinksDSOject.Links.Rows[0]["Link_Arabic_Name"].ToString();
            this.TXTLinkEnglishName.Text = LinksDSOject.Links.Rows[0]["Link_English_Name"].ToString();
            this.TXTLogoArabicTitle.Text = LinksDSOject.Links.Rows[0]["Link_Logo_Arabic_Title"].ToString();
            this.TXTLogoEnglishTitle.Text = LinksDSOject.Links.Rows[0]["Link_Logo_English_Title"].ToString();
            this.TXTURL.Text = LinksDSOject.Links.Rows[0]["Link_URL"].ToString();

            this.BTNAdd.Visible = false;
            this.BTNUpdate.Visible = true;
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    void ClearCooperationForm()
    {
        try
        {
            this.TXTLinkArabicName.Text = "";
            this.TXTLinkEnglishName.Text = "";
            this.TXTLogoArabicTitle.Text = "";
            this.TXTLogoEnglishTitle.Text = "";
            this.TXTURL.Text = "http://";

            this.BTNAdd.Visible = true; ;
            this.BTNUpdate.Visible = false;
        }
        catch (Exception ex)
        {
        }
    }
    protected void LTNDalete_Click(object sender, EventArgs e)
    {
        try
        {
            Confirm("Â·  —Ìœ «·Õ–› ø");

            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            LinksBiz LinksBizObject = new LinksBiz();
            LinksDS LinksDSObject = LinksBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());

            int LinkID = Int32.Parse(LinksDSObject.Links.Rows[RowIndex]["Link_ID"].ToString());

            //////////////////////////////////////////// CV and Photo Not Complete ////////////////////
            if (LinksDSObject.Links.Rows[0]["Link_Logo_Path"].ToString() != null || LinksDSObject.Links.Rows[0]["Link_Logo_Path"].ToString() != "")
            {
                DirectoryInfo DirectoryInfoObject = new DirectoryInfo(Server.MapPath("~//GovsFiles//ORG_" + Session["OrgID"].ToString() + "_Files//Links"));
                if (!DirectoryInfoObject.Exists)
                {
                    DirectoryInfoObject.Create();
                }
                try
                {
                    FileInfo ServerProjectFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + LinksDSObject.Links.Rows[0]["Link_Logo_Path"].ToString());
                    if (ServerProjectFile.Exists)
                        ServerProjectFile.Delete();
                }
                catch (Exception ex)
                {
                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////////

            string SQL = "delete from Links where Link_ID=" + LinkID.ToString();
            Populate(SQL);

            LinksDSObject = LinksBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());
            if (LinksDSObject.Links.Rows.Count <= 0)
            {
                MultiView1.ActiveViewIndex = 1;
            }

            GridView1.DataSource = LinksBizObject.PopulateList("ORG_ID=" + Session["OrgID"].ToString());
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

            LinksBiz LinksBizObject = new LinksBiz();
            LinksDS LinksDSObject = LinksBizObject.PopulateList("ORG_ID =" + Session["OrgID"].ToString());

            string LinkID = LinksDSObject.Links.Rows[RowIndex]["Link_ID"].ToString();

            LinksDSObject = LinksBizObject.Populate(Int32.Parse(LinkID));

            ViewState.Add("LinkID", LinkID);

            MultiView1.ActiveViewIndex = 2;

            Repeater1.DataSource = LinksDSObject;
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
            ViewState["LinkID"] = null;
        }
        catch (Exception ex)
        {
        }
    }
    protected void BTNAdd_Click(object sender, EventArgs e)
    {
        try
        {
            string LinkArabicName = TXTLinkArabicName.Text;
            string LinkEnglishName = TXTLinkEnglishName.Text;
            string LinkURL = TXTURL.Text;
            string LinkLogoArabicTitle = TXTLogoArabicTitle.Text;
            string LinkLogoEnglishTitle = TXTLogoEnglishTitle.Text;
            int OrgID = Int32.Parse(Session["OrgID"].ToString());

            LinksBiz LinksBizObject = new LinksBiz();
            LinksDS LinksDSObject = new LinksDS();
            LinksDS.LinksRow LinksRowOject = LinksDSObject.Links.NewLinksRow();

            LinksRowOject.ORG_ID = OrgID;
            LinksRowOject.Link_Arabic_Name = LinkArabicName;
            LinksRowOject.Link_English_Name = LinkEnglishName;
            LinksRowOject.Link_URL = LinkURL;
            LinksRowOject.Link_Logo_Arabic_Title = LinkLogoArabicTitle;
            LinksRowOject.Link_Logo_English_Title = LinkLogoEnglishTitle;

            //////////////////////////// Save Uploaded File To Server /////////////////////////////////////
            if (FUBrochureFile.HasFile)
            {
                DirectoryInfo DirectoryInfoObject = new DirectoryInfo(Server.MapPath("~//GovsFiles//ORG_" + Session["OrgID"].ToString() + "_Files//Links"));
                if (!DirectoryInfoObject.Exists)
                {
                    DirectoryInfoObject.Create();
                }


                FileInfo ServerProjectFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + FUBrochureFile.FileName);
                if (ServerProjectFile.Exists)
                    ServerProjectFile.Delete();
                FUBrochureFile.SaveAs(DirectoryInfoObject.FullName + "\\" + FUBrochureFile.FileName);
                LinksRowOject.Link_Logo_Path = FUBrochureFile.FileName;

                //FileInfo Projectfile = new FileInfo(FUBrochureFile.PostedFile.FileName);
                //if (Projectfile.Exists)
                //{
                //    try
                //    {
                //        FileInfo ServerProjectFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + Projectfile.Name);
                //        if (ServerProjectFile.Exists)
                //            ServerProjectFile.Delete();
                //        Projectfile.CopyTo(DirectoryInfoObject.FullName + "\\" + Projectfile.Name);
                //        LinksRowOject.Link_Logo_Path = Projectfile.Name;
                //    }
                //    catch (Exception ex)
                //    {
                //    }
                //}
            }

            ////////////////////////////////////////////////////////////////////////////////////////////
            LinksDSObject.Links.AddLinksRow(LinksRowOject);
            LinksDSObject = LinksBizObject.InsertLinks(LinksDSObject);

            GridView1.DataSource = LinksBizObject.PopulateList("ORG_ID=" + OrgID);
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
            string LinkArabicName = TXTLinkArabicName.Text;
            string LinkEnglishName = TXTLinkEnglishName.Text;
            string LinkURL = TXTURL.Text;
            string LinkLogoArabicTitle = TXTLogoArabicTitle.Text;
            string LinkLogoEnglishTitle = TXTLogoEnglishTitle.Text;
            int OrgID = Int32.Parse(Session["OrgID"].ToString());

            LinksBiz LinksBizObject = new LinksBiz();
            LinksDS LinksDSObject = LinksBizObject.Populate(Int32.Parse(ViewState["LinkID"].ToString()));

            LinksDSObject.Links[0].ORG_ID = OrgID;
            LinksDSObject.Links[0].Link_Arabic_Name = LinkArabicName;
            LinksDSObject.Links[0].Link_English_Name = LinkEnglishName;
            LinksDSObject.Links[0].Link_URL = LinkURL;
            LinksDSObject.Links[0].Link_Logo_Arabic_Title = LinkLogoArabicTitle;
            LinksDSObject.Links[0].Link_Logo_English_Title = LinkLogoEnglishTitle;



            //////////////////////////// Save Uploaded File To Server /////////////////////////////////////

            if (FUBrochureFile.HasFile)
            {
                DirectoryInfo DirectoryInfoObject = new DirectoryInfo(Server.MapPath("~//GovsFiles//ORG_" + Session["OrgID"].ToString() + "_Files//Links"));
                if (!DirectoryInfoObject.Exists)
                {
                    DirectoryInfoObject.Create();
                }

                FileInfo ServerOldProjectsFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + LinksDSObject.Links[0].Link_Logo_Path);
                if (ServerOldProjectsFile.Exists)
                    ServerOldProjectsFile.Delete();

                FileInfo ServerOrojectsFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + FUBrochureFile.FileName);
                if (ServerOrojectsFile.Exists)
                    ServerOrojectsFile.Delete();
                FUBrochureFile.SaveAs(DirectoryInfoObject.FullName + "\\" + FUBrochureFile.FileName);
                LinksDSObject.Links[0].Link_Logo_Path = FUBrochureFile.FileName;

                //FileInfo Projectsfile = new FileInfo(FUBrochureFile.PostedFile.FileName);
                //if (Projectsfile.Exists)
                //{
                //    try
                //    {
                //        FileInfo ServerOldProjectsFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + LinksDSObject.Links[0].Link_Logo_Path);
                //        if (ServerOldProjectsFile.Exists)
                //            ServerOldProjectsFile.Delete();

                //        FileInfo ServerOrojectsFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + Projectsfile.Name);
                //        if (ServerOrojectsFile.Exists)
                //            ServerOrojectsFile.Delete();
                //        Projectsfile.CopyTo(DirectoryInfoObject.FullName + "\\" + Projectsfile.Name);
                //        LinksDSObject.Links[0].Link_Logo_Path = Projectsfile.Name;
                //    }
                //    catch (Exception ex)
                //    {
                //    }
                //}
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////

            LinksBizObject.UpdateLinks(LinksDSObject);

            GridView1.DataSource = LinksBizObject.PopulateList("ORG_ID=" + OrgID);
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
