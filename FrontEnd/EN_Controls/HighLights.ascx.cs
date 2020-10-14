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
using System.Data.SqlClient;

public partial class AR_Controls_HighLights : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //HighLightsBiz high_biz = new HighLightsBiz();
        //HighLightsDS high_ds = new HighLightsDS();

        //Repeater1.DataSource = Populate("SELECT min([Type]) as Type FROM HighLights where visible = 1 group by [type] ");
        //Repeater1.DataBind();

    }
    public UserControl GetContentControl(int ContentID)
    {
        //UserControl NewsCotrol = 
        switch (ContentID)
        {
            case 0:
                return (UserControl)Page.LoadControl("~//FrontEnd//EN_BoxControls//Books.ascx");
            case 1:
                return (UserControl)Page.LoadControl("~//FrontEnd//EN_BoxControls//Brochures.ascx");
            case 2:
                return (UserControl)Page.LoadControl("~//FrontEnd//EN_BoxControls//Cooporation.ascx");
            case 3:
                return (UserControl)Page.LoadControl("~//FrontEnd//EN_BoxControls//Laws.ascx");
            case 4:
                return (UserControl)Page.LoadControl("~//FrontEnd//EN_BoxControls//News.ascx");
            case 5:
                return (UserControl)Page.LoadControl("~//FrontEnd//EN_BoxControls//Projects.ascx");
            case 6:
                return (UserControl)Page.LoadControl("~//FrontEnd//EN_BoxControls//Services.ascx");
        }
        return null;
    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            PlaceHolder ContentObject = (PlaceHolder)e.Item.FindControl("ContentPlaceHolder");
            DataRow dr = ((DataRowView)e.Item.DataItem).Row;
            UserControl ContentControl = GetContentControl(Int32.Parse(dr["Type"].ToString()));
            ContentObject.Controls.Add(ContentControl);
        }
    }
    public static DataTable Populate(string sql)
    {
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GovsFEConnString"].ConnectionString);

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
}
