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

public partial class AR_Controls_NewsDetails : System.Web.UI.UserControl
{
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
        
        if (Request.QueryString.Count == 0)
        {
            MultiView1.ActiveViewIndex = 0;
            news_ds = news_biz.PopulateList("Org_ID = " + Session["Org_ID"] + "  order by [News_Date] desc ");//+ " and IsPublish = 1 and News_ValidTo_Date >= '" + DateTime.Now.ToString("yyyy-dd-MM") + "'");
            news_grid.DataSource = news_ds;
            news_grid.DataBind();
        }
        else
        {
            MultiView1.ActiveViewIndex = 1;
            news_ds = news_biz.PopulateList("News_ID = " + Request.QueryString["id"]);
            News_Title.Text = "<H1>" + news_ds.News[0].News_Arabic_Title + "</H1>";
            News_Content.Text = news_ds.News[0].News_Arabic_Content.Replace("\n", "<br/>");
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //serv_ds = (ServicesDS )ViewState["services"];
        news_ds = news_biz.PopulateList("Org_ID = " + Session["Org_ID"]);
        int Index = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        news_ds = news_biz.PopulateList("News_ID = " + news_ds.News[Index].News_ID);
        
        News_Title.Text = "<H1>" + news_ds.News[0].News_Arabic_Title + "</H1>";
        News_Content.Text = news_ds.News[0].News_Arabic_Content.Replace("\n", "<br/>");
        MultiView1.ActiveViewIndex = 1;

    }
    public string NewsContent(string news_string)
    {
        return news_string;//.Substring(0, 20);
        
    }
    public string ImagePath()
    {
        return "../GovsFiles/ORG_" + Session["Org_ID"].ToString() + "_Files/Images/";
    }
}
