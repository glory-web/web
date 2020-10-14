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
            ViewState["Selected_ORG"] = org_ds.Organizations[Index].ORG_ID;
            lit_name.Text = org_ds.Organizations[Index].ORG_Arabic_Name;
            lit_address.Text = org_ds.Organizations[Index].ORG_Arabic_Address;
            Lit_Achivments.Text = org_ds.Organizations[Index].ORG_Arabic_Achivments.Replace("\n", "<br/>");
            Lit_Activity.Text = org_ds.Organizations[Index].ORG_Arabic_Activity.Replace("\n", "<br/>");
            Lit_Goals.Text = org_ds.Organizations[Index].ORG_Arabic_Goals.Replace("\n", "<br/>");
            Lit_Histoty.Text = org_ds.Organizations[Index].ORG_Arabic_History.Replace("\n", "<br/>");
            Lit_Telephone.Text = org_ds.Organizations[Index].ORG_Telephone;
            Label_Mail.Text = org_ds.Organizations[Index].ORG_Email;
            Lit_Fax.Text = org_ds.Organizations[Index].ORG_Fax;
            ////////////////////////////////////////////////////////////////////////////////////
            manager_ds = manger_biz.PopulateList("Org_ID = " + org_ds.Organizations[Index].ORG_ID + " and State = 0  order by [Man_Start_Date] DESC");
            if (manager_ds.OrganizationMangers.Count > 0)
            {
                manger_HyperLink.Text = manager_ds.OrganizationMangers[0].Man_Arabic_Name;
                manger_HyperLink.NavigateUrl = "../ar/Mangers.aspx?id=" + manager_ds.OrganizationMangers[0].Man_ID; ;
                Manger_Image.ImageUrl = ImagePath() + manager_ds.OrganizationMangers[0].Man_Photo_Path;
                if (System.IO.File.Exists(Server.MapPath(ImagePath() + manager_ds.OrganizationMangers[0].Man_Photo_Path)))
                    Manger_Image.Visible = true;
                else
                    Manger_Image.Visible = false;

            }
            else
            {
                Manger_Image.Visible = false;
                Label_Manager_Date.Text = "";
            }

            ////////////////////////////////////////////////////////////////////////////////////
            serv_ds = serv_biz.PopulateList("Org_ID = " + org_ds.Organizations[Index].ORG_ID);
            services_grid.DataSource = serv_ds.Services;
            services_grid.DataBind();
            ////////////////////////////////////////////////////////////////////////////////////////
            org_ds = org_biz.PopulateList("Parent_ORG_ID = " + org_ds.Organizations[Index].ORG_ID);
            gov_dep_grid.DataSource = org_ds.Organizations;
            gov_dep_grid.DataBind();
            ///////////////////////////////////////////////////////////////////////////////////////
            MultiView1.ActiveViewIndex = 1;
            return;

        }
        org_ds = org_biz.PopulateList("Org_Type_ID = 7 " );
        //ViewState["org_ds"] = org_ds;
        governorate_grid.DataSource = org_ds.Organizations;
        governorate_grid.DataBind();
        MultiView1.ActiveViewIndex = 0;



    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //org_ds = (OrganizationsDS)ViewState["org_ds"];
        org_ds = org_biz.PopulateList("Org_Type_ID = 7 ");
        int Index = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;

        ViewState["Selected_ORG"] = org_ds.Organizations[Index].ORG_ID;
        lit_name.Text = org_ds.Organizations[Index].ORG_Arabic_Name;
        Lit_Achivments.Text = org_ds.Organizations[Index].ORG_Arabic_Achivments.Replace("\n", "<br/>");
        Lit_Activity.Text = org_ds.Organizations[Index].ORG_Arabic_Activity.Replace("\n", "<br/>");
        Lit_Goals.Text = org_ds.Organizations[Index].ORG_Arabic_Goals.Replace("\n", "<br/>");
        Lit_Histoty.Text = org_ds.Organizations[Index].ORG_Arabic_History.Replace("\n", "<br/>");
        Lit_Telephone.Text = org_ds.Organizations[Index].ORG_Telephone;
        Label_Mail.Text = org_ds.Organizations[Index].ORG_Email;
        Lit_Fax.Text = org_ds.Organizations[Index].ORG_Fax;
        ////////////////////////////////////////////////////////////////////////////////////
        manager_ds = manger_biz.PopulateList("Org_ID = " + org_ds.Organizations[Index].ORG_ID + "  and State = 0  order by [Man_Start_Date] DESC");
        if (manager_ds.OrganizationMangers.Count > 0)
        {
            manger_HyperLink.Text = manager_ds.OrganizationMangers[0].Man_Arabic_Name;
            manger_HyperLink.NavigateUrl = "../ar/Mangers.aspx?id=" + manager_ds.OrganizationMangers[0].Man_ID; ;
            Manger_Image.ImageUrl = ImagePath() + manager_ds.OrganizationMangers[0].Man_Photo_Path;
            if (System.IO.File.Exists(Server.MapPath(ImagePath() + manager_ds.OrganizationMangers[0].Man_Photo_Path)))
                Manger_Image.Visible = true;
            else
                Manger_Image.Visible = false;

        }
        else
        {
            Manger_Image.Visible = false;
            Label_Manager_Date.Text = "";
        }
        
        ////////////////////////////////////////////////////////////////////////////////////
        serv_ds = serv_biz.PopulateList("Org_ID = " + org_ds.Organizations[Index].ORG_ID);
        services_grid.DataSource = serv_ds.Services;
        services_grid.DataBind();
        ////////////////////////////////////////////////////////////////////////////////////////
        org_ds = org_biz.PopulateList("Parent_ORG_ID = " + org_ds.Organizations[Index].ORG_ID);
        gov_dep_grid.DataSource = org_ds.Organizations;
        gov_dep_grid.DataBind();
        ///////////////////////////////////////////////////////////////////////////////////////
        MultiView1.ActiveViewIndex = 1;
    }
    protected void Service_Click(object sender, EventArgs e)
    {
        decimal  id = (decimal )ViewState["Selected_ORG"];
        serv_ds = serv_biz.PopulateList("Org_ID = " +id);
        //serv_ds = (ServicesDS)ViewState["serv_ds"];
        int Index = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        Response.Redirect("Service.aspx?ID=" + serv_ds.Services[Index].Service_ID );
    }
    public string ImagePath()
    {
        return "~/GovsFiles/ORG_" + Session["Org_ID"].ToString() + "_Files/Managers/Photos/";
    }
}
