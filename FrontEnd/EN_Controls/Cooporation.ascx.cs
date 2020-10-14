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

public partial class Cooporation : System.Web.UI.UserControl
{
     
    CooporationsDS cop_ds = new CooporationsDS();
    CooporationsBiz cop_biz = new CooporationsBiz();

    CooporationCountriesDS cop_conntry_ds = new CooporationCountriesDS();
    CooporationCountriesBiz cop_conntry_biz = new CooporationCountriesBiz();
    string StartTag = "<span style='background-color: #ffff66'>", EndTag = "</span>";
    string build_string(string text, string key)
    {
        //return text;
        string new_string = text;
        int new_index = 0;
        if (text == key)
        {
            new_string = new_string.Insert(0, StartTag);
            new_string = new_string.Insert(key.Length + StartTag.Length, EndTag);

            return new_string;

        }
        if (key == "")
            return text;

        int c = 1;
        int index = text.IndexOf(key);
        if (index == -1)
            return text;
        new_string = new_string.ToLower();
        text = text.ToLower();
        string temp = text.Trim();
        while (temp.Contains(key))
        {
            c++;
            index = temp.IndexOf(key, 0);
            if (temp.StartsWith(key))
            {
                new_string = new_string.Insert(new_index, StartTag);
                new_string = new_string.Insert(new_index + key.Length + StartTag.Length, EndTag);
                new_index += key.Length + StartTag.Length + EndTag.Length + index;
                temp = temp.Substring(index + key.Length);
            }
            else
            {
                temp = temp.Substring(index);
                new_index += index;
            }
        }
        return new_string;

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Text.StringBuilder ss = new System.Text.StringBuilder();
      
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
            cop_ds = cop_biz.PopulateList("Coop_ID = " + Request.QueryString["ID"]);
            if (cop_ds.Cooporations.Count== 0)
                return;
           
           
            
            int Index = 0;
            Label_Coop_Content.Text = Operations.Key_Search_Color(cop_ds.Cooporations[Index].Coop_English_Content.Replace("\n", "<br/>"), txt);
            Label_Coop_Name.Text = Operations.Key_Search_Color(cop_ds.Cooporations[Index].Coop_English_Name, txt);
            Label_Coop_Date.Text =Operations.Key_Search_Color(cop_ds.Cooporations[Index].Coop_Date.ToShortDateString (),txt );
            cop_conntry_ds = cop_conntry_biz.PopulateList("Coop_ID = " + cop_ds.Cooporations[Index].Coop_ID);
            contries_grid.DataSource = cop_conntry_ds.CooporationCountries;
            contries_grid.DataBind();
            MultiView1.ActiveViewIndex = 1;
            return;

        }
        cop_ds = cop_biz.PopulateList("Org_ID = "+Session["Org_ID"]);
        cooperation_grid.DataSource = cop_ds.Cooporations;
        cooperation_grid.DataBind();
        //ViewState["cooperation"] = cop_ds;
        MultiView1.ActiveViewIndex = 0;

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        //cop_ds = (CooporationsDS)ViewState["cooperation"];
        cop_ds = cop_biz.PopulateList("Org_ID = " + Session["Org_ID"]);
        int Index = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        Label_Coop_Content.Text = cop_ds.Cooporations[Index].Coop_English_Content.Replace("\n", "<br/>");
        Label_Coop_Name.Text = cop_ds.Cooporations[Index].Coop_English_Name;
        Label_Coop_Date.Text = cop_ds.Cooporations[Index].Coop_Date.ToShortDateString();
        cop_conntry_ds = cop_conntry_biz.PopulateList("Coop_ID = " + cop_ds.Cooporations[Index].Coop_ID);
        contries_grid.DataSource = cop_conntry_ds.CooporationCountries ;
        contries_grid.DataBind();
        MultiView1.ActiveViewIndex = 1;

    }
}
