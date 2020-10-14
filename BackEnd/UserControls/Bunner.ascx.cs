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
using System.IO;
using Businesslayer;
using Common;
using DataAccess;

public partial class UserControls_Bunner : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BunnersBiz BunnersBizObject = new BunnersBiz();
                BunnersDS BunnersDSObject = BunnersBizObject.PopulateList("");

                GVBunners.DataSource = BunnersDSObject;
                GVBunners.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void BTNUpload_Click(object sender, EventArgs e)
    {
        try
        {

            if (!FUBunner.HasFile)
            {
                Page.RegisterStartupScript("ErrorMsg", "<script>alert('لابد من رفع ملف الصورة');</script>");
                return;
            }
            string  BunnerName = FUBunner.FileName;
            bool ShowBunner = false;
            if (CHBShow.Checked)
                ShowBunner = true;
            else
                ShowBunner = false;

            BunnersBiz BunnersBizObject = new BunnersBiz();
            BunnersDS BunnersDSObject = new BunnersDS();
            BunnersDS.BunnersRow BunnersRowObject = BunnersDSObject.Bunners.NewBunnersRow();

            BunnersRowObject.BunnerName = BunnerName;
            BunnersRowObject.Show = ShowBunner;
            ///////////////////////////////////////////// CV and Photo Not Complete ////////////////////
            
            if (FUBunner.HasFile)
            {
                DirectoryInfo DirectoryInfoObject = new DirectoryInfo(Server.MapPath("~//GovsFiles//Bunners"));
                if (!DirectoryInfoObject.Exists)
                {
                    DirectoryInfoObject.Create();
                }

                FUBunner.SaveAs(DirectoryInfoObject.FullName + "\\" + FUBunner.FileName);
            }
            ////////////////////////////////////////////////////////////////////////////////////////////

            BunnersDSObject.Bunners.AddBunnersRow(BunnersRowObject);
            BunnersDSObject = BunnersBizObject.InsertBunners(BunnersDSObject);

            GVBunners.DataSource = BunnersBizObject.PopulateList("");
            GVBunners.DataBind();
            CHBShow.Checked = false;

        }
        catch (Exception ex)
        {
            string errormessage = "<script>alert('" + ex.Message + "');</script>";
            Page.RegisterStartupScript("ErrorMsg", errormessage);
            return;
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            BunnersBiz BunnersBizObject = new BunnersBiz();
            BunnersDS BunnersDSObject = BunnersBizObject.PopulateList("");
            string PhotoPath = "~//GovsFiles//Bunners//" + BunnersDSObject.Bunners[e.Row.RowIndex]["BunnerName"].ToString();
            ((Image)e.Row.FindControl("Image1")).ImageUrl = PhotoPath;
            ((Image)e.Row.FindControl("Image1")).DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    protected void LBTNDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int RowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;

            BunnersBiz BunnersBizObject = new BunnersBiz();
            BunnersDS BunnersDSObject = BunnersBizObject.PopulateList("");

            int BunnerID = Int32.Parse(BunnersDSObject.Bunners.Rows[RowIndex]["BunnerID"].ToString());

            string SQL = "delete from Bunners where BunnerID=" + BunnerID.ToString();
            Populate(SQL);

            ///////////////////////////////////////////// CV and Photo Not Complete ////////////////////
            if (BunnersDSObject.Bunners.Rows[RowIndex]["BunnerName"].ToString() != null || BunnersDSObject.Bunners.Rows[RowIndex]["BunnerName"].ToString() != "")
            {
                DirectoryInfo DirectoryInfoObject = new DirectoryInfo(Server.MapPath("~//GovsFiles//Bunners"));
                if (!DirectoryInfoObject.Exists)
                {
                    DirectoryInfoObject.Create();
                }
                try
                {
                    FileInfo ServerCVFile = new FileInfo(DirectoryInfoObject.FullName + "\\" + BunnersDSObject.Bunners.Rows[RowIndex]["BunnerName"].ToString());
                    if (ServerCVFile.Exists)
                        ServerCVFile.Delete();
                }
                catch (Exception ex)
                {
                }
            }
            ////////////////////////////////////////////////////////////////////////////////////////////

            GVBunners.DataSource = BunnersBizObject.PopulateList("");
            GVBunners.DataBind();
        }
        catch (Exception ex)
        {
        }
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
    protected void CHBShowBunner_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox CHBVisable = ((CheckBox)sender);

            int RowIndex = ((GridViewRow)((CheckBox)sender).Parent.Parent).RowIndex;

            BunnersBiz BunnersBizObject = new BunnersBiz();
            BunnersDS BunnersDSObject = BunnersBizObject.PopulateList("");

            decimal BunnerID = Decimal.Parse(BunnersDSObject.Bunners.Rows[RowIndex]["BunnerID"].ToString());

            BunnersDSObject = BunnersBizObject.Populate(BunnerID);

            if (CHBVisable.Checked)
            {
                BunnersDSObject.Bunners[0].Show = true;
            }
            else
            {
                BunnersDSObject.Bunners[0].Show = false;
            }
            BunnersBizObject.UpdateBunners(BunnersDSObject);

            BunnersDSObject = BunnersBizObject.PopulateList("");

            GVBunners.DataSource = BunnersDSObject;
            GVBunners.DataBind();
        }
        catch (Exception ex)
        {

        }
    }
}
