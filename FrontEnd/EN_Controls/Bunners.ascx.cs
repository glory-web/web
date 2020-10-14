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

public partial class AR_Controls_Bunners : System.Web.UI.UserControl
{
    BunnersDS bun_ds = new BunnersDS();
    BunnersBiz bun_biz = new BunnersBiz();
    protected void Page_Load(object sender, EventArgs e)
    {
        bun_ds = bun_biz.PopulateList("Show = 1");

        string BunnserNames="";
        foreach (DataRow dr in bun_ds.Bunners.Rows)
        {
            BunnserNames += dr["BunnerName"].ToString() + "#";
        }
        BunnserNames = BunnserNames.Remove(BunnserNames.Length - 1, 1);

        Session.Add("BunnerNames",BunnserNames);
 
    }
}
