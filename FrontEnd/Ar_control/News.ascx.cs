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
using System.Data.SqlClient;

public partial class News : System.Web.UI.UserControl
{
    NewsDS news_ds = new NewsDS();
    NewsBiz news_biz = new NewsBiz();
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

    protected void Page_Load(object sender, EventArgs e)
    {
        
        BaseDAL.ConnectionString = ConfigurationManager.ConnectionStrings["GovsFEConnString"].ToString();
        news_ds = news_biz.PopulateList("Org_ID = " + Session["Org_ID"]); //  + " and IsPublish = 1 and News_ValidTo_Date >= '" + DateTime.Now.ToString("yyyy-dd-MM") + "' order by [News_Date] desc");
        
        Repeater1.DataSource =  Populate("select top 5 * from news where org_ID=1 and IsPublish = 1  order by [News_Date] desc") ;
        //Repeater1.DataSource = news_ds;
        Repeater1.DataBind();
     
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("NewsDetails.aspx");
    }
   
}
