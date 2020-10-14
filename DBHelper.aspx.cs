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
using System.Collections.Generic;
using System.Data.SqlClient;

public partial class DBHelper : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MultiView1.SetActiveView(View1);
        }

    }
    protected void btn_Execute_Click(object sender, EventArgs e)
    {
        lbl_msg.Text = string.Empty;
        if (string.IsNullOrEmpty(txt_Sql.Text.Trim()))
            return;
        try
        {
            string sql = txt_Sql.Text.Trim();
            if (Radio_Selection.Checked)
            {
                GridView1.DataSource =DBManager.PopulateList(sql);
                GridView1.DataBind();
            }
            else if (Radio_Trans.Checked)
            {
                int x = DBManager.ExecuteTransactionQuery(sql);
                lbl_msg.Text = "Rows Effected : "+x.ToString();
            }
        }
        catch(Exception ex)
        {
            lbl_msg.Text = ex.Message;
        }
    }
    
    protected void btn_Ok_Click(object sender, EventArgs e)
    {
        lbl_Err.Text = string.Empty;
        if (txt_UserName.Text.Trim() == "admin" && txt_Password.Text.Trim() == "admin")
        {
            MultiView1.SetActiveView(View2);
        }
        else
        {
            lbl_Err.Text = "wrong username or password!!!";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable tbl = DBManager.PopulateList("select * From Student");
            for (int x = 0; x < tbl.Rows.Count; x++)
            {
                string un = tbl.Rows[x]["UserName"].ToString();
                string ID = tbl.Rows[x]["Code"].ToString();
                string sql = "Update Student set UserName='" + x + "' where code='" + ID + "'";
                DBManager.ExecuteTransactionQuery(sql);
            }
        }
        catch
        {
            //Helper.Alert(this.Page, "");
        }
    }
}
