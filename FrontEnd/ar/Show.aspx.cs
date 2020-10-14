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
using System.Data.SqlClient;

public partial class FrontEnd_ar_Show : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString.Count != 0)
        {
            //id=",Eval("HLID"),"&type
            if ((string.IsNullOrEmpty(Request.QueryString["id"])) || (string.IsNullOrEmpty(Request.QueryString["type"])))
                return;

            //"~//FrontEnd//ar//Cooperation.aspx?id=",Eval("Coop_ID")
            string fileN = "";
            switch (Int32.Parse(Request.QueryString["type"]))
            {
                case 0:
                    fileN = ("~//FrontEnd//ar//Books.aspx?id=" + Request.QueryString["id"].ToString());
                    break;
                case 1:
                    fileN = ("~//FrontEnd//ar//Publications.aspx?id=" + Request.QueryString["id"].ToString());
                    break;
                case 2:
                    fileN =("~//FrontEnd//ar//Cooperation.aspx?id=" + Request.QueryString["id"].ToString());
                    break;
                case 3:
                    DataTable td = new DataTable();
                    td = Populate("Select * from Laws where Law_ID =" + Request.QueryString["id"].ToString());
                    DataRow row = td.Rows[0];

                    if (Boolean.Parse(row["IsLegislation"].ToString()) == false)                        
                        fileN = ("~//FrontEnd//ar//Laws.aspx?id=" + Request.QueryString["id"].ToString());                   
                    else
                        fileN = ("~//FrontEnd//ar//Decs.aspx?id=" + Request.QueryString["id"].ToString());

                    break;
                case 4:
                    fileN = ("~//FrontEnd//ar//NewsDetails.aspx?id=" + Request.QueryString["id"].ToString());
                    break;
                case 5:
                    fileN = ("~//FrontEnd//ar//Projects.aspx?id=" + Request.QueryString["id"].ToString());
                    break;
                case 6:
                    fileN = ("~//FrontEnd//ar//Service.aspx?id=" + Request.QueryString["id"].ToString());
                    break;
            }
            Response.Redirect(fileN);
            //ww.Text = fileN + " - " + Request.QueryString["type"].ToString();

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
