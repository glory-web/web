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
    NewsCategoryDS news_cat_ds = new NewsCategoryDS();
    NewsCategoryBiz news_cat_biz = new NewsCategoryBiz();
    GridView news_grid;
 
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


        news_cat_ds = news_cat_biz.PopulateList("");
        Repeater1.DataSource = news_cat_ds.NewsCategory;
        Repeater1.DataBind();
        
        if (Request.QueryString.Count == 0)
        {
            
            MultiView1.ActiveViewIndex = 0;
            news_ds = news_biz.PopulateList("Org_ID = " + Session["Org_ID"] + " and IsPublish = 1 and News_ValidTo_Date >= '" + DateTime.Now.ToString("yyyy-dd-MM") + "'  order by [News_Date] desc");

          
        }
        else
        {
            MultiView1.ActiveViewIndex = 1;
            news_ds = news_biz.PopulateList("News_ID = " + Request.QueryString["id"]);
            News_Title.Text = news_ds.News[0].News_English_Title;
            News_Content.Text = news_ds.News[0].News_English_Content.Replace("\n", "<br/>");
            News_Date.Text = news_ds.News[0].News_Date.ToShortDateString() ;
            News_Image.ImageUrl = (ImagePath() + news_ds.News[0].ImagePath); 
            //if (System.IO.File.Exists(Server.MapPath(ImagePath() + news_ds.News[0].ImagePath)))
            //    News_Image.Visible = true;
            //else
            //    News_Image.Visible = false;
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //serv_ds = (ServicesDS )ViewState["services"];
        LinkButton l = (LinkButton)sender;
        Control  gr =  l.Parent.Parent ;
        news_ds = news_biz.PopulateList("News_English_Title like '" + l.Text+"'" );
        //news_ds = news_biz.PopulateList("Cat_ID = " + ViewState["Cat_ID"]); //+ " and IsPublish = 1 and News_ValidTo_Date >= '" + DateTime.Now.ToString("yyyy-dd-MM") + "'");
        int Index = ((GridViewRow)((LinkButton)sender).Parent.Parent).DataItemIndex;
        
        Label id = (Label)((LinkButton)sender).Parent.Parent.FindControl("News_ID");
        news_ds = news_biz.PopulateList("News_ID = " +id.Text );
        News_Title.Text = news_ds.News[0].News_English_Title;
        News_Content.Text = news_ds.News[0].News_English_Content.Replace("\n", "<br/>");
        News_Date.Text = news_ds.News[0].News_Date.ToShortDateString ();
        News_Image.ImageUrl = ((ImagePath() + news_ds.News[0].ImagePath)); //ImagePath()+ news_ds.News[0].ImagePath;
        MultiView1.ActiveViewIndex = 1;

    }
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {     
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            news_grid = (GridView)e.Item.FindControl("news_grid");
            DataRow dr = ((DataRowView)e.Item.DataItem).Row;
            ViewState["Cat_ID"] = dr["Cat_ID"];
            news_ds = news_biz.PopulateList("Cat_ID = " + dr["Cat_ID"] + " and IsPublish = 1 and News_ValidTo_Date >= '" + DateTime.Now.ToString("yyyy-dd-MM") + "'  order by [News_Date] desc");
            news_grid.DataSource  = news_ds.News;
            news_grid.DataBind();     
        }
    }
    public string ImagePath()
    {
        return "../../GovsFiles/ORG_" + Session["Org_ID"].ToString() + "_Files/News/";
    }
    public bool TextVisible(string ID)
    {
        news_ds = news_biz.PopulateList("Cat_ID = " + ID +" and IsPublish = 1 and News_ValidTo_Date >= '" + DateTime.Now.ToString("yyyy-dd-MM") + "'");
        if (news_ds.News.Count == 0)
            return false;
        else
            return true;
    }
    public string NewsContent(string news_string)
    {
        //int c = news_string.IndexOf(" ");
        
        string new_s = Operations.FirstDot (news_string);
        if (string.IsNullOrEmpty(new_s))
            return news_string;
        else
            return new_s;
        //return news_string;//.Substring(0, 20);

    }

}
