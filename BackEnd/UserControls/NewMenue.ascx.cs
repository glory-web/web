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
using GOVS;


public partial class UserControls_NewMenue : System.Web.UI.UserControl
{
    string _title = "لوحة التحكم الرئيسية";

    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }
    string _title1 = "بيانات المستخدمين";

    public string Title1
    {
        get { return _title1; }
        set { _title1 = value; }
    }

    string _height = "100%";
    public string T_Height
    {
        get { return _height; }
        set { _height = value; }
    }
    int _width = 170;
    public int T_Width
    {
        get { return _width; }
        set { _width = value; }
    }

    string _image = "admin.jpg";
    public string ImgaeName
    {
        get { return _image; }
        set { _image = value; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            blocks.Style.Add("height", _height);
            blocks.Style.Add("width", _width + "px");

            System.Xml.XmlDocument XmlDocObj = new System.Xml.XmlDocument();
            XmlDocObj.Load(Server.MapPath("~/App_Data/TasksMenue.xml"));
            DataTable MenueTB = new DataTable();

            if (Int32.Parse(Session["OrgTypeID"].ToString()) == 1)
            {
                MenueTB = XMLHelper.xml2Table(XmlDocObj, "//Group", "GroupTitle,IsPublic,ForOrganization", "GroupTitle,IsPublic,ForOrganization", null);
            }
            else
            {
                MenueTB = XMLHelper.xml2Table(XmlDocObj, "//Group[@IsPublic=\"true\"]", "GroupTitle,IsPublic,ForOrganization", "GroupTitle,IsPublic,ForOrganization", null);
            }

            for(int i=MenueTB.Rows.Count-1;i>-1;i--)
            {
                if ((Int32.Parse(MenueTB.Rows[i]["ForOrganization"].ToString()) > 0) && (Int32.Parse(MenueTB.Rows[i]["ForOrganization"].ToString()) != Int32.Parse(Session["OrgID"].ToString())))
                    MenueTB.Rows.RemoveAt(i);
            }
            
            Repeater1.DataSource = MenueTB;
            Repeater1.DataBind();
        }
        catch
        {
        }
        TopImage.ImageUrl = "~/images/" + _image;
        if (TopImage.Width.IsEmpty == true)
        {
            int imagewidth = _width - 16;

            try
            {

                TopImage.Width = Unit.Pixel(imagewidth);
            }
            catch
            {
                TopImage.Width = Unit.Pixel(170);
            }
        }
       
    }
    
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            try
            {
                //string GroupTitle = ((XmlDataSourceNodeDescriptor)e.Item.DataItem)["GroupTitle"].ToString();
                string GroupTitle = ((Label)e.Item.FindControl("LITTitle")).Text;
                Repeater ItemReapeater = (Repeater)e.Item.FindControl("ItemsRepeater");
                if (ItemReapeater != null)
                {
                    System.Xml.XmlDocument XmlDocObj = new System.Xml.XmlDocument();
                    XmlDocObj.Load(Server.MapPath("~/App_Data/TasksMenue.xml"));
                    DataTable Items = new DataTable();
                    if (Int32.Parse(Session["OrgTypeID"].ToString()) == 1)
                    {
                        Items = XMLHelper.xml2Table(XmlDocObj, "//Group[@GroupTitle=\"" + GroupTitle + "\"]/Page", "Path,Title,IsPublic", "Path,Title,IsPublic", null);

                        if (GroupTitle == "بيانات المنظمات")
                            Items.Rows[0]["Title"] = "إدارات الهيئة";
                    }
                    else
                    {
                        Items = XMLHelper.xml2Table(XmlDocObj, "//Group[@GroupTitle=\"" + GroupTitle + "\"]/Page[@IsPublic=\"true\"]", "Path,Title,IsPublic", "Path,Title,IsPublic", null);
                    }

                    ItemReapeater.DataSource = Items;
                    ItemsRepeater.DataBind();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
    
}
