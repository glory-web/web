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

public partial class Mangers : System.Web.UI.UserControl
{
    OrganizationMangersDS man_ds = new OrganizationMangersDS();
    OrganizationMangersBiz man_biz = new OrganizationMangersBiz();
    string StartTag = "<b><i>", EndTag = "</b></i>";
    string build_string(string text, string key)
    {
        string new_string;
        new_string = text.ToLower().Replace(key.ToLower(), StartTag + key.ToLower() + EndTag);
        for (int i = StartTag.Length; i < (key.Length + StartTag.Length); i++)
        {

            if (char.IsUpper(text[i - StartTag.Length]))
            {
                new_string = new_string.Insert(i, text[i - StartTag.Length].ToString());
                new_string = new_string.Remove(i + 1, 1);
            }
        }
        return new_string;

    }
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
            man_ds = man_biz.PopulateList("Man_ID = " + Request.QueryString["ID"]);
            if (man_ds.OrganizationMangers .Count == 0)
                return;
            int Index = 0;

            //Maryam if (!man_ds.OrganizationMangers[Index].State)
            Label1.Text = Manger_Type( man_ds.OrganizationMangers[Index].Man_ID.ToString ());
            MList.InnerText = MangerL_Type(man_ds.OrganizationMangers[Index].Man_ID.ToString()); 
            Label_Manger_Name.Text = man_ds.OrganizationMangers[Index].Man_Arabic_Name;
            Label_Manger_StartDate.Text = man_ds.OrganizationMangers[Index].Man_Start_Date.ToShortDateString ();
            Label_Manger_Phone.Text = man_ds.OrganizationMangers[Index].Man_Telephone;
            //if (man_ds.OrganizationMangers[Index].Man_Email == DBNull.Value || man_ds.OrganizationMangers[Index].Man_Email.Trim() == "")
            try
            {
                string EmailS = man_ds.OrganizationMangers[Index].Man_Email;
                if (EmailS.Trim() != "")
                    Label_Manger_Mail.Text = man_ds.OrganizationMangers[Index].Man_Email.ToString();
                else
                {
                    Label_Manger_Mail.Visible = false;
                    Label6.Visible = false;
                }
            }
            catch
            {
                Label_Manger_Mail.Visible = false;
                Label6.Visible = false;
            }

            Mager_Image.ImageUrl = ImagePath (man_ds.OrganizationMangers[Index].Man_ID.ToString()) + man_ds.OrganizationMangers[Index].Man_Photo_Path;
            if (man_ds.OrganizationMangers[Index].State)
            {
                Label4.Visible = false;
                Label_Manger_Phone.Visible = false;

                Label_Manger_EndDate.Text = man_ds.OrganizationMangers[Index].Man_End_Date.ToShortDateString ();
            }
            else
            {
                Label_Manger_EndDate.Visible = false;
                Label3.Visible = false;
            }
            if (System.IO.File.Exists(Server.MapPath(ImagePath(man_ds.OrganizationMangers[Index].Man_ID.ToString()) + man_ds.OrganizationMangers[Index].Man_Photo_Path)))
                Mager_Image.Visible = true;
            else
                Mager_Image.Visible = false;
            //maryam 6/6/2011
            if (man_ds.OrganizationMangers[Index].Man_CV_Path == null || man_ds.OrganizationMangers[Index].Man_CV_Path.Trim() == "")
            {
                CV_Link.Visible = false;
                Label5.Visible = false;
            }
            else
            {
                CV_Link.Visible = true;
                Label5.Visible = true;
                CV_Link.NavigateUrl = CVPath(man_ds.OrganizationMangers[Index].Man_ID.ToString()) + man_ds.OrganizationMangers[Index].Man_CV_Path;
            }
            
            
            MultiView1.ActiveViewIndex = 1;
            return;

        }
        man_ds = man_biz.PopulateList("Org_ID = " + Session["Org_ID"] + " order by [Man_Start_Date] DESC");
        mangers_grid.DataSource = man_ds.OrganizationMangers;
        mangers_grid.DataBind();
        //ViewState["Mangers"] = man_ds;
        MultiView1.ActiveViewIndex = 0;
        //MList.InnerText = Manger_Type(Session["Org_ID"]); 
        
        
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        //man_ds = (OrganizationMangersDS )ViewState["Mangers"];
        man_ds = man_biz.PopulateList("Org_ID = " + Session["Org_ID"] + " order by [Man_Start_Date] DESC");
        int Index = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;

        if (man_ds.OrganizationMangers[Index].State == true  )
        {
            Label4.Visible = false;
            Label_Manger_Phone.Visible = false;

            Label_Manger_EndDate.Text = man_ds.OrganizationMangers[Index].Man_End_Date.ToShortDateString ();
        }
        else
        {
            Label_Manger_EndDate.Visible = false;
            Label3.Visible = false;
        }

        Label1.Text = Manger_Type(man_ds.OrganizationMangers[Index].Man_ID.ToString());
        MList.InnerText = MangerL_Type( man_ds.OrganizationMangers[Index].Man_ID.ToString()); 
        Label_Manger_Name.Text = man_ds.OrganizationMangers[Index].Man_Arabic_Name;
        Label_Manger_StartDate.Text = man_ds.OrganizationMangers[Index].Man_Start_Date.ToShortDateString();
        Label_Manger_Phone.Text = man_ds.OrganizationMangers[Index].Man_Telephone;

        //       Email = man_ds.OrganizationMangers[Index].Man_Email;   "System.DBNull") 
        //System.DbNull.Value; \== System.DBNull.Value)
//|| man_ds.OrganizationMangers[Index].Man_Email.Trim() == "")System.DBNull.Value
        try 
        {
            string EmailS = man_ds.OrganizationMangers[Index].Man_Email;
            if (EmailS.Trim() != "")
                Label_Manger_Mail.Text = man_ds.OrganizationMangers[Index].Man_Email.ToString();
            else
            {
                Label_Manger_Mail.Visible = false;
                Label6.Visible = false;
            }
        }
        catch
        {
            Label_Manger_Mail.Visible = false;
            Label6.Visible = false;
        }
       
        Mager_Image.ImageUrl = ImagePath() + man_ds.OrganizationMangers[Index].Man_Photo_Path;
        if (System.IO.File.Exists(Server.MapPath(ImagePath(man_ds.OrganizationMangers[Index].Man_ID.ToString()) + man_ds.OrganizationMangers[Index].Man_Photo_Path)))
            Mager_Image.Visible = true;
        else
            Mager_Image.Visible = false;
        //maryam 6/6/2011
        if (man_ds.OrganizationMangers[Index].Man_CV_Path == null || man_ds.OrganizationMangers[Index].Man_CV_Path.Trim() == "")
        {
            CV_Link.Visible = false;
            Label5.Visible = false;
        }
        else
        {
            CV_Link.Visible = true;
            Label5.Visible = true;
            CV_Link.NavigateUrl = CVPath(man_ds.OrganizationMangers[Index].Man_ID.ToString()) + man_ds.OrganizationMangers[Index].Man_CV_Path;
        }        
        //CV_Link.NavigateUrl = CVPath(man_ds.OrganizationMangers[Index].Man_ID.ToString()) + man_ds.OrganizationMangers[Index].Man_CV_Path;

        MultiView1.ActiveViewIndex = 1;
        
    }
    public string ImagePath()
    {
        return "~/GovsFiles/ORG_" + Session["Org_ID"].ToString() + "_Files/Managers/Photos/";
    }
    public string ImagePath(string man_id)
    {
        return "~/GovsFiles/ORG_" + Manger_Org(man_id ) + "_Files/Managers/Photos/";
    }
    public string CVPath(string man_id)
    {
        
        //return "~/GovsFiles/ORG_" + Session["Org_ID"].ToString() + "_Files/Managers/CV/";
        return "~/GovsFiles/ORG_" + Manger_Org(man_id) + "_Files/Managers/CV/";
    }
    public bool  MangerState(string ID)
    {
        man_ds = man_biz.PopulateList("Man_ID  = " + ID );
        return man_ds.OrganizationMangers [0].State;
    }

    public bool Image_Exist(string Path)
    {
        //////////  '<%#System.IO.File.Exists(Server.MapPath (string.Concat(ImagePath(), Eval("Man_Photo_Path")))) %>'
        return System.IO.File.Exists(Server.MapPath(Path));

    }
    public string Manger_Type(string ID)
    {
        OrganizationMangersDS  man_ds1 = man_biz.PopulateList ("Man_ID = " +ID);
        OrganizationsDS org_ds = new OrganizationsDS ();
        OrganizationsBiz org_biz =new OrganizationsBiz ();
        org_ds = org_biz.PopulateList("ORG_ID = " + man_ds1.OrganizationMangers[0].ORG_ID );
        switch ( Int32.Parse ( org_ds.Organizations[0].Org_Type_ID.ToString ()))
        {
            case 1:
                return "—∆Ì” «·ÂÌ∆…";
            case 2:
                return "„œÌ— «·„œÌ—Ì…";
            case 6:
                return "ÊﬂÌ· Ê“«—…";
            case 7:
                return "„œÌ— ⁄«„";
            default :
                return "„œÌ—";
        }
    }

    public string MangerL_Type(string ID)
    {
        OrganizationMangersDS man_ds1 = man_biz.PopulateList("Man_ID = " + ID);
        OrganizationsDS org_ds = new OrganizationsDS();
        OrganizationsBiz org_biz = new OrganizationsBiz();
        org_ds = org_biz.PopulateList("ORG_ID = " + man_ds1.OrganizationMangers[0].ORG_ID);
        switch (Int32.Parse(org_ds.Organizations[0].Org_Type_ID.ToString()))
        {
            case 1:
                return "»Ì«‰«  —∆Ì” «·ÂÌ∆…";
            //case 2:
            //    return "»Ì«‰«  «·„œÌ—";
            //case 6:
            //    return "ÊﬂÌ· Ê“«—…";
            //case 7:
            //    return "„œÌ— ⁄«„";
            default:
                return "»Ì«‰«  «·„œÌ—";
        }
    }


    public string Manger_Org(string ID)
    {
        OrganizationMangersDS man_ds1 = man_biz.PopulateList("Man_ID = " + ID);
        OrganizationsDS org_ds = new OrganizationsDS();
        OrganizationsBiz org_biz = new OrganizationsBiz();
        org_ds = org_biz.PopulateList("ORG_ID = " + man_ds1.OrganizationMangers[0].ORG_ID);
        return org_ds.Organizations[0].ORG_ID.ToString (); 
    }
    
}
