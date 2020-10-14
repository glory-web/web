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

public partial class BackEnd_UserControls_HighlightSet : System.Web.UI.UserControl
{
    //OrganizationsBiz OrganizationsBizObject = new OrganizationsBiz();
    //OrganizationsDS OrganizationsDSObject = new OrganizationsDS();
    //OrganizationsDS.OrganizationsRow org_row;

    protected void Page_Load(object sender, EventArgs e)
    {
        BaseDAL.ConnectionString = ConfigurationManager.ConnectionStrings["VSConnectionString"].ToString();

        if (Session["OrgID"] == null)
        {
            Response.Redirect("~/BackEnd/default.aspx");
        }
        if (!IsPostBack)
        {
            //ListH.DataSource = ;
            //DataView dv = new DataView(Populate("SELECT Coop_Arabic_Name FROM HighlightView"));
            DataTable dv = new DataTable();
            // Mar  2012 dv = Populate("SELECT * FROM HviewAll");
            dv = Populate("SELECT * FROM HviewAllM");
            ListHall.DataSource = dv;
            ListHall.DataTextField = "News_Arabic_Title";
            ListHall.DataValueField = "HLID";
            ListHall.DataBind();

            DataTable dv1 = new DataTable();
            dv1 = Populate("SELECT * FROM HighlightSet");
            ListHSet.DataSource = dv1;
            ListHSet.DataTextField = "NameAr";
            ListHSet.DataValueField = "HLID";
            ListHSet.DataBind();
            test.Visible = false;
            //GridView1.DataSource = dv1;
            //GridView1.DataBind();
        }
    }
    //
    protected void Add_Click(object sender, EventArgs e)
    {
        ListItem Hitem = new ListItem();

        if (ListHall.SelectedItem == null || ListHSet.Items.Count > 9 ) 
            return;
        Hitem.Text = ListHall.SelectedItem.Text.ToString();
        Hitem.Value = ListHall.SelectedItem.Value.ToString();

        if (!ListHSet.Items.Contains(Hitem))
        {
            ListHSet.Items.Add(Hitem);
            ListHSet.ClearSelection();
        }
        //test.Visible = true;
        //test.Text = Hitem.Text + " " + Hitem.Value;

    }
    
     protected void Del_Click(object sender, EventArgs e)
     {
        if (ListHSet.SelectedItem == null )
            return;
        ListHSet.Items.Remove(ListHSet.SelectedItem);     
     }

     
     protected void Save_Click(object sender, EventArgs e)
     {
      // delete from database
         string SqlW = "delete from HighlightSet";
         Populate(SqlW);

         for (int i = 0; i < ListHSet.Items.Count; i++)
        {
            SqlW = " INSERT INTO HighlightSet (HLID, OrderNo, NameAr) values( " + int.Parse(ListHSet.Items[i].Value.ToString()) + ", " + (i + 1) + " ,N'" + ListHSet.Items[i].Text + "' )";
            Populate(SqlW);

        }
        test.Text = "تم تخزين البيانات";
        test.Visible = true;
     
     }
     
     public static DataTable Populate(string sql)
    {
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["VSConnectionString"].ConnectionString);

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
