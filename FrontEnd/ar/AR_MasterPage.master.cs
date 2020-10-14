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

public partial class ar_AR_MasterPage : System.Web.UI.MasterPage
{
    OrganizationsDS org_ds = new OrganizationsDS();
    OrganizationsBiz org_biz = new OrganizationsBiz();
    BunnersDS bun_ds = new BunnersDS();
    BunnersBiz bun_biz = new BunnersBiz();

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("NewsDetails.aspx");
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Search.Focus();
        BaseDAL.ConnectionString = ConfigurationManager.ConnectionStrings["GovsFEConnString"].ToString();
        org_ds = org_biz.PopulateList("Org_Type_ID = 1");
        //Session["Org_ID"] =2;
        Session["Org_ID"] = org_ds.Organizations[0].ORG_ID;

        try
        {
            bun_ds = bun_biz.PopulateList("Show = 1");

            string BunnserNames = "";
            foreach (DataRow dr in bun_ds.Bunners.Rows)
            {
                BunnserNames += dr["BunnerName"].ToString() + "#";
            }
            //BunnserNames = BunnserNames.Remove(BunnserNames.Length - 1, 1);

            Session.Add("BunnerNames", BunnserNames);
            Session.Add("Count", bun_ds.Bunners.Rows.Count );
        }
        catch (Exception ex)
        {
        }
        Search.Focus();
    }
}
