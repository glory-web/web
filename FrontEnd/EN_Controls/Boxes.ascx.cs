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
using Businesslayer;
using Common;
using DataAccess;


public partial class Books : System.Web.UI.UserControl
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            BoxsBiz BoxsBizObject = new BoxsBiz();
            BoxsDS BoxsDSObject = BoxsBizObject.PopulateList("");

            BoxsDSObject.Boxs.Columns.Add("Visiblity");
            foreach (DataRow dr in BoxsDSObject.Boxs.Rows)
            {
                switch (Int32.Parse(dr["BoxContent"].ToString()))
                {
                    case 0:
                        {
                            BooksDS book_ds = new BooksDS();
                            BooksBiz book_biz = new BooksBiz();
                            book_ds = book_biz.PopulateList("");
                            if(book_ds.Books.Rows.Count == 0 )
                                dr["Visiblity"] = false;
                            else
                                dr["Visiblity"] = true ;

                        }
                        break;
                    case 1:
                         {
                            BrochuresDS  broch_ds = new BrochuresDS();
                            BrochuresBiz  broch_biz = new BrochuresBiz();
                            broch_ds = broch_biz.PopulateList("");
                            if(broch_ds.Brochures.Rows.Count == 0 )
                                dr["Visiblity"] = false;
                            else
                                dr["Visiblity"] = true ;
                        }
                        break;
                    case 2:
                         {
                            CooporationsDS   coop_ds = new  CooporationsDS();
                            CooporationsBiz   coop_biz = new CooporationsBiz();
                            coop_ds = coop_biz.PopulateList("");
                            if(coop_ds.Cooporations.Rows.Count == 0 )
                                dr["Visiblity"] = false;
                            else
                                dr["Visiblity"] = true ;
                        }
                        break ;
                    case 3:
                        {
                            LawsDS   laws_ds = new  LawsDS();
                            LawsBiz   laws_biz = new LawsBiz();
                            laws_ds = laws_biz.PopulateList("");
                            if(laws_ds.Laws .Rows.Count == 0 )
                                dr["Visiblity"] = false;
                            else
                                dr["Visiblity"] = true ;
                        }
                        break ;
                    case 4:
                       {
                            NewsDS   news_ds = new  NewsDS();
                            NewsBiz   news_biz = new NewsBiz();
                            news_ds = news_biz.PopulateList("");
                            if(news_ds.News .Rows.Count == 0 )
                                dr["Visiblity"] = false;
                            else
                                dr["Visiblity"] = true ;
                        }
                        break ;
                    case 5:
                         {
                            ProjectsDS    proj_ds = new  ProjectsDS();
                            ProjectsBiz   proj_biz = new ProjectsBiz();
                            proj_ds = proj_biz.PopulateList("");
                            if(proj_ds.Projects.Rows.Count == 0 )
                                dr["Visiblity"] = false;
                            else
                                dr["Visiblity"] = true ;
                        }
                        break;
                    case 6:
                        {
                            ServicesDS serv_ds = new ServicesDS();
                            ServicesBiz serv_biz = new ServicesBiz();
                            serv_ds = serv_biz.PopulateList("");
                            if (serv_ds.Services.Rows.Count == 0)
                                dr["Visiblity"] = false;
                            else
                                dr["Visiblity"] = true;
                        }
                        break;
                }
                //dr["Visiblity"] = false;
            }

            Repeater1.DataSource = BoxsDSObject;
            Repeater1.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    public UserControl GetContentControl( int ContentID)
    {
        //UserControl NewsCotrol = 
        switch (ContentID)
        {
            case 0:
                return (UserControl)Page.LoadControl("~//EN_BoxControls//Books.ascx");
            case 1:
                return (UserControl)Page.LoadControl("~//EN_BoxControls//Brochures.ascx");
            case 2:
                return (UserControl)Page.LoadControl("~//EN_BoxControls//Cooporation.ascx");
            case 3:
                return (UserControl)Page.LoadControl("~//EN_BoxControls//Laws.ascx");
            case 4:
                return (UserControl)Page.LoadControl("~//EN_BoxControls//News.ascx");
            case 5:
                return (UserControl)Page.LoadControl("~//EN_BoxControls//Future_Projects.ascx");
            case 6:
                return (UserControl)Page.LoadControl("~//EN_BoxControls//Services.ascx");
        }
        return null;
    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            PlaceHolder ContentObject = (PlaceHolder)e.Item.FindControl("ContentPlaceHolder");
            DataRow dr = ((DataRowView)e.Item.DataItem).Row;
            UserControl ContentControl = GetContentControl(Int32.Parse(dr["BoxContent"].ToString()));
            ContentObject.Controls.Add(ContentControl);
        }
    }
}
