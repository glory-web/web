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

public partial class AR_Controls_Organigram_1 : System.Web.UI.UserControl
{
    OrganizationsDS org_ds = new OrganizationsDS();
    OrganizationsBiz org_biz = new OrganizationsBiz();
    protected void Page_Load(object sender, EventArgs e)
    {
        FillTree();
        BaseDAL.ConnectionString = ConfigurationManager.ConnectionStrings["GovsFEConnString"].ToString();
         
        org_ds = org_biz.PopulateList("Org_Type_ID = 2");
        DDLGovernate.DataTextField = "ORG_Arabic_Name";
        DDLGovernate.DataValueField = "ORG_ID";
        DDLGovernate.DataSource = org_ds.Organizations;
        DDLGovernate.DataBind();
        DDLGovernate_SelectedIndexChanged(null, null);

    }
    protected void DDLGovernate_SelectedIndexChanged(object sender, EventArgs e)
    {
        org_ds = org_biz.PopulateList("Parent_ORG_ID = " + DDLGovernate.SelectedValue);
        DDLDirectorate.DataTextField = "ORG_Arabic_Name";
        DDLDirectorate.DataValueField = "Org_ID";
        DDLDirectorate.DataSource = org_ds.Organizations;
        DDLDirectorate.DataBind();
        DDLDirectorate_SelectedIndexChanged(null, null);
    }
    protected void DDLDirectorate_SelectedIndexChanged(object sender, EventArgs e)
    {
        org_ds = org_biz.PopulateList("Parent_ORG_ID = " + DDLDirectorate.SelectedValue);
        DDLUnit.DataTextField = "ORG_Arabic_Name";
        DDLUnit.DataValueField = "Org_ID";
        DDLUnit.DataSource = org_ds.Organizations;
        DDLUnit.DataBind();
        DDLUnit_SelectedIndexChanged(null ,null );
    }
    protected void DDLUnit_SelectedIndexChanged(object sender, EventArgs e)
    {
        org_ds = org_biz.PopulateList("Parent_ORG_ID = " + DDLUnit .SelectedValue);
        DDLSlaughter.DataTextField = "ORG_Arabic_Name";
        DDLSlaughter.DataValueField = "Org_ID";
        DDLSlaughter.DataSource = org_ds.Organizations;
        DDLSlaughter.DataBind();
        DDLSlaughter_SelectedIndexChanged(null ,null );
    }
    protected void DDLSlaughter_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    ///////////////////////////////////////////////////////////////

    private DataTable getOrgChildern(int  ParentID)
    {

        org_ds = org_biz.PopulateList("Parent_ORG_ID = " + ParentID + " and Org_ID <> " + ParentID);
        return org_ds.Organizations;
    }

    private void FillOrganizationTree(TreeNode TN, int ParentID)
    {
        DataTable SubOrg = getOrgChildern(ParentID);
        if (SubOrg.Rows.Count <= 0)
            return;
        else
        {
            for (int i = 0; i < SubOrg.Rows.Count; i++)
            {
                TN.ChildNodes.Add(new TreeNode(SubOrg.Rows[i]["ORG_Arabic_Name"].ToString()));
                FillOrganizationTree(TN.ChildNodes[i], Int32.Parse(SubOrg.Rows[i]["ORG_ID"].ToString()));
            }
        }
    }
    private void FillTree()
    {
        TreeView1.Nodes.Clear();
        DataTable SubOrg = getOrgChildern(1);
        for (int i = 0; i < SubOrg.Rows.Count; i++)
        {
            TreeView1.Nodes.Add(new TreeNode(SubOrg.Rows[i]["ORG_Arabic_Name"].ToString()));
            FillOrganizationTree(TreeView1.Nodes[i], Int32.Parse(SubOrg.Rows[i]["ORG_ID"].ToString()));
        }
    }
}
