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
using DataAccess;
using Common;
using Businesslayer;

public partial class AR_Controls_Governorate : System.Web.UI.UserControl
{
    OrganizationsDS org_ds = new OrganizationsDS();
    OrganizationsBiz org_biz = new OrganizationsBiz();

    ServicesDS serv_ds = new ServicesDS();
    ServicesBiz serv_biz = new ServicesBiz();

    OrganizationMangersDS manager_ds = new OrganizationMangersDS();
    OrganizationMangersBiz manger_biz = new OrganizationMangersBiz();

    BooksDS book_ds = new BooksDS();
    BooksBiz book_biz = new BooksBiz();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        BaseDAL.ConnectionString = ConfigurationManager.ConnectionStrings["GovsFEConnString"].ToString();
        if (Request.QueryString.Count != 0)
        {
            int temp;
            string txt;
            if (string.IsNullOrEmpty(Request.QueryString["ID"]))
                return;
            if (string.IsNullOrEmpty(Request.QueryString["txt"]))
                txt = "";
            else
                txt = Request.QueryString["txt"];
            if (!int.TryParse(Request.QueryString[0], out temp))
                return;
            org_ds = org_biz.PopulateList("Org_ID = " + Request.QueryString["ID"]);
            if (org_ds.Organizations .Count == 0)
                return;
            int Index = 0;
            manger_HyperLink.Text = manager_ds.OrganizationMangers[0].Man_Arabic_Name;
            manger_HyperLink.NavigateUrl = "../ar/Mangers.aspx?id=" + manager_ds.OrganizationMangers[0].Man_ID; 
            Lit_Telephone.Text = org_ds.Organizations[Index].ORG_Telephone;
            Label_Mail.Text = org_ds.Organizations[Index].ORG_Email;
            Lit_Fax.Text = org_ds.Organizations[Index].ORG_Fax;
            Lit_Addreess.Text = org_ds.Organizations[Index].ORG_Arabic_Address;
            Lit_History.Text = org_ds.Organizations[Index].ORG_Arabic_History;
            /////////////////////////////////////////////////////////////////////////////////
            manager_ds = manger_biz.PopulateList("ORG_ID = " + org_ds.Organizations[Index].ORG_ID + "and State = 0 order by [Man_Start_Date] DESC");

            if (manager_ds.OrganizationMangers.Count > 0)
            {
                Lit_manger_name.Text = manager_ds.OrganizationMangers[0].Man_Arabic_Name ;
                //Manger_Image.ImageUrl = ImagePath() + manager_ds.OrganizationMangers[0].Man_Photo_Path;
                //if (System.IO.File.Exists(Server.MapPath(ImagePath() + manager_ds.OrganizationMangers[0].Man_Photo_Path)))
                //    Manger_Image.Visible = true;
                //else
                //    Manger_Image.Visible = false;
            }
            else
            {
                //Manger_Image.Visible = false;
                Lit_manger_name.Text = "";
            }
            ////////////////////////////////////////////////////////////////////////////////
            org_ds = org_biz.PopulateList("Parent_ORG_ID = " + org_ds.Organizations[Index].ORG_ID);
            gov_dep_grid.DataSource = org_ds.Organizations;
            gov_dep_grid.DataBind();
            ////////////////////////////////////////////////////////////////////////////////////

            MultiView1.ActiveViewIndex = 1;
            return;

        }
        org_ds = org_biz.PopulateList("Org_Type_ID = 2 " );
        //ViewState["org_ds"] = org_ds;
        governorate_grid.DataSource = org_ds.Organizations;
        governorate_grid.DataBind();
        MultiView1.ActiveViewIndex = 0;



    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //org_ds = (OrganizationsDS)ViewState["org_ds"];
        org_ds = org_biz.PopulateList("Org_Type_ID = 2 ");
        int Index = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        ViewState["Selected_ORG"] = org_ds.Organizations[Index].ORG_ID;
        Lit_name.Text = org_ds.Organizations[Index].ORG_Arabic_Name;
        Label_Mail.Text = org_ds.Organizations[Index].ORG_Email;
        Lit_Telephone.Text = org_ds.Organizations[Index].ORG_Telephone;
        Lit_Fax.Text = org_ds.Organizations[Index].ORG_Fax;
        Lit_Addreess.Text = org_ds.Organizations[Index].ORG_Arabic_Address;
        Lit_History.Text = org_ds.Organizations[Index].ORG_Arabic_History;
        /////////////////////////////////////////////////////////////////////////////////
        manager_ds = manger_biz.PopulateList("ORG_ID = " + org_ds.Organizations[Index].ORG_ID + " and State = 0 order by [Man_Start_Date] DESC");

        if (manager_ds.OrganizationMangers.Count > 0)
        {
            manger_HyperLink.Text = manager_ds.OrganizationMangers[0].Man_Arabic_Name;
            manger_HyperLink.NavigateUrl = "../ar/Mangers.aspx?id=" + manager_ds.OrganizationMangers[0].Man_ID; ;
            //Lit_manger_name.Text = manager_ds.OrganizationMangers[0].Man_Arabic_Name ;
            //Manger_Image.ImageUrl = ImagePath() + manager_ds.OrganizationMangers[0].Man_Photo_Path;
            //if (System.IO.File.Exists(Server.MapPath(ImagePath() + manager_ds.OrganizationMangers[0].Man_Photo_Path)))
            //    Manger_Image.Visible = true;
            //else
            //    Manger_Image.Visible = false;
        }
        else
        {
            //Manger_Image.Visible = false;
            //Lit_manger_name.Text = "";
        }
        ////////////////////////////////////////////////////////////////////////////////
        org_ds = org_biz.PopulateList("Parent_ORG_ID = " + org_ds.Organizations[Index].ORG_ID + " and Org_Type_ID = 3");
        gov_dep_grid.DataSource = org_ds.Organizations;
        gov_dep_grid.DataBind();
        ////////////////////////////////////////////////////////////////////////////////////
        OrganizationsDS org_ds_1 = new OrganizationsDS();
        OrganizationsBiz org_biz_1 = new OrganizationsBiz();
        Control c1 = FindControlRecursive(MultiView2, "DepIdLbe");
        Label DepId = (Label)c1;
        string DepNo;
        if (DepId == null)
            DepNo = "-1";
        else
            DepNo = DepId.Text;
        org_ds_1 = org_biz_1.PopulateList("Org_Type_ID = 4 and Parent_ORG_ID = " + DepNo);
        Control c2 = FindControlRecursive(MultiView2, "Link_Unit");
        LinkButton label = (LinkButton)c2;
        if (org_ds_1.Organizations.Count > 0)
            label.Visible = true;
        //else
        //    label.Visible = false;
        org_ds_1 = org_biz_1.PopulateList("Org_Type_ID = 5 and Parent_ORG_ID = " + DepNo);
        Control c3 = FindControlRecursive(MultiView2, "Link_Sluter");
        LinkButton label2 = (LinkButton)c3;
        if (org_ds_1.Organizations.Count > 0)
            label2.Visible = true;
        //else
        //    label2.Visible = false;

        MultiView1.ActiveViewIndex = 1;

        Control con = FindControlRecursive(MultiView2, "MultiView2"); ;
        MultiView multi_view = (MultiView)con;
        multi_view.ActiveViewIndex = 0;
      
    }
    public bool Image_Exist(string Path)
    {
        return System.IO.File.Exists(Server.MapPath(Path));
    }
    public string ImagePath()
    {
        return "~/GovsFiles/ORG_" + Session["Org_ID"].ToString() + "_Files/Managers/Photos/";
    }
    protected void Service_Click(object sender, EventArgs e)
    {
        //decimal  id = (decimal )ViewState["Selected_ORG"];
        //serv_ds = serv_biz.PopulateList("Org_ID = " +id);
        ////serv_ds = (ServicesDS)ViewState["serv_ds"];
        //int Index = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        //Response.Redirect("Service.aspx?ID=" + serv_ds.Services[Index].Service_ID );
    }
    public static void Alert(string p, Control c)
    {
        ScriptManager.RegisterClientScriptBlock(c, c.GetType(), "script", "alert('" + p + "');", true);
        return;
        //Response.Write("<script language=javascript>alert(' ');</script>");
    }
    public static Control FindControlRecursive(Control Root, string Id)
    {
        if (Root.ID == Id)
            return Root;

        foreach (Control Ctl in Root.Controls)
        {
            Control FoundCtl = FindControlRecursive(Ctl, Id);
            if (FoundCtl != null)
                return FoundCtl;
        }

        return null;
    }
    protected void Link_Close_Click(object sender, EventArgs e)
    {
        Control con = FindControlRecursive(MultiView2, "MultiView2"); ;
        MultiView multi_view = (MultiView)con;
        MultiView1.ActiveViewIndex = 1;
        multi_view.ActiveViewIndex = 0;
    }
    protected void Link_Unit_Click(object sender, EventArgs e)
    {
       
        /* org_ds = org_biz.PopulateList("Org_Type_ID = 2 ");*/
        int index = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        Label hh = (Label)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("LinkButton1");
        Label OrgId = (Label)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("OrgIdLbe");
        Label DepId = (Label)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("DepIdLbe");
        //int index = gov_dep_grid.SelectedIndex;
        OrganizationsDS org_ds_1 = new OrganizationsDS();
        OrganizationsBiz org_biz_1 = new OrganizationsBiz();
        org_ds_1 = org_biz_1.PopulateList("Org_Type_ID = 4 and Parent_ORG_ID = " + DepId.Text);
        if (org_ds_1.Organizations.Count > 0)
        {
            Control con = FindControlRecursive(MultiView2, "MultiView2"); ;
            MultiView multi_view = (MultiView)con;
            MultiView1.ActiveViewIndex = 1;
            multi_view.ActiveViewIndex = 1;

            Control c = FindControlRecursive(MultiView2, "Label4");
            Label label = (Label)c;
            label.Text = " «·ÊÕœ«  «· «»⁄Â ·«œ«—… " + hh.Text;
            Control t = FindControlRecursive(MultiView2, "Grid_unit_sluter");
            GridView Grid_unit_sluter = (GridView)t;
            Grid_unit_sluter.DataSource = org_ds_1.Organizations;
            Grid_unit_sluter.DataBind();
        }
        else
        {
            Control con = FindControlRecursive(MultiView2, "MultiView2"); ;
            MultiView multi_view = (MultiView)con;
            MultiView1.ActiveViewIndex = 1;
            multi_view.ActiveViewIndex = 0;
            Alert("·« ÌÊÃœ ÊÕœ«  ·Â–Â «·«œ«—Â",this );
        }



    }
    protected void Link_Sluter_Click(object sender, EventArgs e)
    {
       
        /* org_ds = org_biz.PopulateList("Org_Type_ID = 2 ");*/
        int index = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        Label hh = (Label)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("LinkButton1");
        Label OrgId = (Label)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("OrgIdLbe");
        Label DepId = (Label)((GridViewRow)((LinkButton)sender).Parent.Parent).FindControl("DepIdLbe");
        //int index = gov_dep_grid.SelectedIndex;
        OrganizationsDS org_ds_1 = new OrganizationsDS();
        OrganizationsBiz org_biz_1 = new OrganizationsBiz();
        org_ds_1 = org_biz_1.PopulateList("Org_Type_ID = 5 and Parent_ORG_ID = " + DepId.Text);
        

        if (org_ds_1.Organizations.Count > 0)
        {
            Control con = FindControlRecursive(MultiView2, "MultiView2"); ;
            MultiView multi_view = (MultiView)con;
            MultiView1.ActiveViewIndex = 1;
            multi_view.ActiveViewIndex = 1;

            Control c = FindControlRecursive(MultiView2, "Label4");
            Label label = (Label)c;
            label.Text = " «·„Ã«“— «· «»⁄Â ·«œ«—… " + hh.Text;
            Control t = FindControlRecursive(MultiView2, "Grid_unit_sluter");
            GridView Grid_unit_sluter = (GridView)t;
            Grid_unit_sluter.DataSource = org_ds_1.Organizations;
            Grid_unit_sluter.DataBind();
        }
        else
        {
            Control con = FindControlRecursive(MultiView2, "MultiView2"); ;
            MultiView multi_view = (MultiView)con;
            MultiView1.ActiveViewIndex = 1;
            multi_view.ActiveViewIndex = 0;
            Alert("·« ÌÊÃœ „Ã«“— ·Â–Â «·«œ«—Â", this);
        }
    }
}
