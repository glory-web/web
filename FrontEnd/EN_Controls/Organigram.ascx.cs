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

public partial class AR_Controls_Organigram : System.Web.UI.UserControl
{
    OrganizationsDS org_ds = new OrganizationsDS();
    OrganizationsBiz org_biz = new OrganizationsBiz();
    protected void Page_Load(object sender, EventArgs e)
    {
        BaseDAL.ConnectionString = ConfigurationManager.ConnectionStrings["GovsFEConnString"].ToString();
        if (!IsPostBack)
        {
            org_ds = org_biz.PopulateList("Org_Type_ID = 2");
            //DDLGovernate.DataTextField = "ORG_English_Name";
            //DDLGovernate.DataValueField = "ORG_ID";
            //DDLGovernate.DataSource = org_ds.Organizations;
            //DDLGovernate.DataBind();
        }
        FillTree("1");
    }
    ///////////////////////////////////////////////////////////////
    private DataTable getOrgChildern(string ParentID)
    {
        org_ds = org_biz.PopulateList("Parent_ORG_ID = " + ParentID + " and  Org_ID <> " + ParentID + " order by [Org_Type_ID] ASC");
        return org_ds.Organizations;
    }
    private DataTable getParent()
    {
        org_ds = org_biz.PopulateList("Org_ID = 1 ");
        return org_ds.Organizations;
    }
    private void FillOrganizationTree(TreeNode TN, string ParentID)
    {
        DataTable SubOrg = getOrgChildern(ParentID);
        if (SubOrg.Rows.Count <= 0)
            return;
        else
        {
            for (int i = 0; i < SubOrg.Rows.Count; i++)
            {
                TN.ChildNodes.Add(new TreeNode(SubOrg.Rows[i]["ORG_English_Name"].ToString(), "", "", "../en/General_Governorate.aspx?id="+SubOrg.Rows[i]["ORG_ID"].ToString(), ""));
                FillOrganizationTree(TN.ChildNodes[i], SubOrg.Rows[i]["ORG_ID"].ToString());
            }
        }
    }
    private void FillTree(string ID)
    {
        TreeView1.Nodes.Clear();
        DataTable SubOrg = getParent();//getOrgChildern(ID );
        // Add root node
        TreeNode RooNode = new TreeNode();
        if (SubOrg.Rows.Count > 0)
        {
            RooNode.Text = SubOrg.Rows[0]["ORG_English_Name"].ToString();
            RooNode.Value = SubOrg.Rows[0]["ORG_English_Name"].ToString();

            TreeView1.Nodes.Add(RooNode);

            ///////Add first level of tree //////////////////////////////////////////////// 
            org_ds = org_biz.PopulateList("Parent_ORG_ID = " + SubOrg.Rows[0]["ORG_ID"].ToString() + " and  (Org_Type_ID=6 or Org_Type_ID=7) and Parent_ORG_ID = 1" + " order by [Org_Type_ID] ASC");
            SubOrg = org_ds.Organizations;

            for (int i = 0; i < SubOrg.Rows.Count; i++)
            {
                if (int.Parse( SubOrg.Rows[i]["ORG_Type_ID"].ToString()) == 6) // = ãÑßÒíå
                     RooNode.ChildNodes.Add(new TreeNode(SubOrg.Rows[i]["ORG_English_Name"].ToString(), "", "", "../en/Central_Governorate.aspx?id=" + SubOrg.Rows[i]["ORG_ID"].ToString(), ""));
                else //7 = ÚÇãå
                     RooNode.ChildNodes.Add(new TreeNode(SubOrg.Rows[i]["ORG_English_Name"].ToString(), "", "", "../en/General_Governorate.aspx?id=" + SubOrg.Rows[i]["ORG_ID"].ToString(), ""));
                FillOrganizationTree(RooNode.ChildNodes[i], SubOrg.Rows[i]["ORG_ID"].ToString());
            }
        }
        ///////////////////////////////////////
        //   FillOrganizationTree(TreeView1.Nodes[i], SubOrg.Rows[i]["ORG_ID"].ToString());
    }
}
