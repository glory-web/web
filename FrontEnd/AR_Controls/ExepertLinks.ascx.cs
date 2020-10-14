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

public partial class Links : System.Web.UI.UserControl
{
    ExpertSystemsDS link_ds = new ExpertSystemsDS();
    ExpertSystemsBiz  link_biz = new ExpertSystemsBiz ();

    protected void Page_Load(object sender, EventArgs e)
    {
        BaseDAL.ConnectionString = ConfigurationManager.ConnectionStrings["GovsFEConnString"].ToString();
        link_ds = link_biz.PopulateList("");
        links_grid.DataSource = link_ds.ExpertSystems;
        links_grid.DataBind();
    }
    public string ImagePath()
    {
        return "~/GovsFiles/ORG_" + Session["Org_ID"].ToString() + "_Files/Links/";
    }
}
