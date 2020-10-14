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

    NewsDS news_ds = new NewsDS();
    NewsBiz news_biz = new NewsBiz();
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
        news_ds = news_biz.PopulateList("Cat_ID = 4");
        Repeater1.DataSource = news_ds.News;
        Repeater1.DataBind();

    }
   
    public string ImagePath()
    {
        return "../GovsFiles/ORG_" + Session["Org_ID"].ToString() + "_Files/Managers/Photos/";
    }
    public string CVPath()
    {
        
        return "../GovsFiles/ORG_" + Session["Org_ID"].ToString() + "_Files/Managers/CV/";
    }


    public bool Image_Exist(string Path)
    {
        //////////  '<%#System.IO.File.Exists(Server.MapPath (string.Concat(ImagePath(), Eval("Man_Photo_Path")))) %>'
        return System.IO.File.Exists(Server.MapPath ( Path));
    }
    
}
