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



public partial class AR_Controls_Search : System.Web.UI.UserControl
{
   
    //protected void LinkButton1_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("NewsDetails.aspx");
    //}
   
 
    protected void Page_Load(object sender, EventArgs e)
    {
        txtSearch.Focus();
    }
    /////////////--------------------------------------------------///////////////////
    /////////////--------------------------------------------------///////////////////

    
   

    /////////////--------------------------------------------------///////////////////
    /////////////--------------------------------------------------///////////////////
    /////////////--------------------------------------------------///////////////////
    /////////////--------------------------------------------------///////////////////
    /////////////--------------------------------------------------///////////////////
    /////////////--------------------------------------------------///////////////////
    /////////////--------------------------------------------------///////////////////
    /////////////--------------------------------------------------///////////////////
    /////////////--------------------------------------------------///////////////////
    /////////////--------------------------------------------------///////////////////

    protected void Button1_Click(object sender, EventArgs e)
    {
        Session.Add("SearchTXT", txtSearch.Text);
        Response.Redirect("SearchResult.aspx");
    }
}
