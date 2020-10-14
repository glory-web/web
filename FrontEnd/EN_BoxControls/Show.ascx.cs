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

public partial class Show : System.Web.UI.UserControl
{
     
    CooporationsDS cop_ds = new CooporationsDS();
    CooporationsBiz cop_biz = new CooporationsBiz();
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
        BaseDAL.ConnectionString = ConfigurationManager.ConnectionStrings["GovsFEConnString"].ToString();        
        cop_ds = cop_biz.PopulateList("Org_ID = "+Session["Org_ID"]);
        //cooperation_grid.DataSource = Populate("select top 3 * from Cooporations where ORG_ID=" + Session["Org_ID"].ToString()); ;        
        // 
        string Con = "";
        DataTable td = new DataTable();
        //td = Populate("Select * from HighFE2 where OrderNo = 1 ");
        //int MId = Select Min(OrderNo) from HighFE2
        //mar 2012 td = Populate("Select * from HighFE2 where OrderNo =  (SELECT MIN(OrderNO) FROM HighFE2)  ");
        td = Populate("Select * from HighFEM where OrderNo =  (SELECT MIN(OrderNO) FROM HighFEM)  ");
        if (td.Rows.Count == 0)
        {
            //News_Title.Text = "General Organization Veterinary Services";
            NewsTitleLink.Text = "General Organization Veterinary Services";
            News_Content.InnerHtml = "The decision of the President of the Arab Republic of Egypt No. 187 of 1984 - where the Commission aims to protect livestock and their products through the protection of this national wealth of communicable and infectious diseases - as well as treatment of this wealth of cases, the bar and sexually transmitted diseases and diseases that lead to the deterioration of productivity . Which lead to the development of national economy and increase production rates, where less and less reliance on imported meat and meat products from outside the country. The multi-function devices available, including its potential human and material to increase the national income - In order that multiple activities performed by the Veterinary Authority";
            News_Image.ImageUrl = "~/FrontEnd/ar/img/NewsPic.jpg";
            return;
        }
        DataRow row = td.Rows[0];
        if (Int32.Parse(row["Type"].ToString()) == 4)
        {
            //mar 2012 Con = " where OrderNo > (SELECT MIN(OrderNO) FROM HighFE2) ORDER BY OrderNo";
            Con = " where OrderNo > (SELECT MIN(OrderNO) FROM HighFEM) ORDER BY OrderNo";
            DataTable Ntd = new DataTable();
            Ntd = Populate("Select * from News where News_ID =" + row["News_ID"].ToString());
            DataRow Nrow = Ntd.Rows[0];
            //News_ID 6/2011
            //NewsTitleLink.NavigateUrl = "~//FrontEnd//en//Show.aspx?id=" + Nrow["News_ID"].ToString() + "&type=4";
            //News_Title.Text = Nrow["News_English_Title"].ToString();
             NewsTitleLink.Text = Nrow["News_English_Title"].ToString();
             NewsTitleLink.PostBackUrl = "~//FrontEnd//en//Show.aspx?id=" + Nrow["News_ID"].ToString() + "&type=4";
            
            News_Content.InnerHtml = Nrow["News_English_Content"].ToString();
            News_Image.ImageUrl = (ImagePath() + Nrow["ImagePath"].ToString());
            if (Nrow["ImagePath"].ToString() == "" || Nrow["ImagePath"].ToString() == null)
                News_Image.ImageUrl = "~/FrontEnd/ar/img/NewsPic.jpg";
            //News_Image.ImageUrl = "~/FrontEnd/ar/img/NewsPic.jpg";
        }
        else
        {
            //News_Title.Text = "General Organization Veterinary Services";
            NewsTitleLink.Text = "General Organization Veterinary Services";
            
            News_Content.InnerHtml = "The decision of the President of the Arab Republic of Egypt No. 187 of 1984 - where the Commission aims to protect livestock and their products through the protection of this national wealth of communicable and infectious diseases - as well as treatment of this wealth of cases, the bar and sexually transmitted diseases and diseases that lead to the deterioration of productivity . Which lead to the development of national economy and increase production rates, where less and less reliance on imported meat and meat products from outside the country. The multi-function devices available, including its potential human and material to increase the national income - In order that multiple activities performed by the Veterinary Authority";
            News_Image.ImageUrl = "~/FrontEnd/ar/img/NewsPic.jpg";
        }
        //mar 3 2012 cooperation_grid.DataSource = Populate("Select * from HighFE2" + Con);
        cooperation_grid.DataSource = Populate("Select * from HighFEM" + Con);
        cooperation_grid.DataBind();
        
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

    public string ImagePath()
    {
        return "~/GovsFiles/ORG_" + Session["Org_ID"].ToString() + "_Files/News/";
    }
}
