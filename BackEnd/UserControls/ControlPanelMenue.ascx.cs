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

public partial class UserControls_ControlPanelMenue : System.Web.UI.UserControl
{
    string _title = "لوحة التحكم الرئيسية";

    public string Title
    {
        get { return _title; }
        set { _title = value; }
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
        if (Session["OrgID"] == null)
        {
            Response.Redirect("~/BackEnd/default.aspx");
        }
        try
        {
            blocks.Style.Add("height", _height);
            blocks.Style.Add("width", _width + "px");
            System.Xml.XmlDocument XmlDocObj = new System.Xml.XmlDocument();
            XmlDocObj.Load(Server.MapPath("~/App_Data/TasksMenue.xml"));
            DataTable Items = XMLHelper.xml2Table(XmlDocObj, "//Group/Page", "Path,Title", "Path,Title", null);

            Repeater1.DataSource = Items;
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

    public void Link_OnClick(object sender, EventArgs e)
    {

    }
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            try
            {
                ////string GroupTitle = ((XmlDataSourceNodeDescriptor)e.Item.DataItem)["GroupTitle"].ToString();
                //string GroupTitle = ((Label)e.Item.FindControl("LITTitle")).Text;
                //Repeater ItemReapeater = (Repeater)e.Item.FindControl("ItemsRepeater");
                //if (ItemReapeater != null)
                //{
                //    System.Xml.XmlDocument XmlDocObj = new System.Xml.XmlDocument();
                //    XmlDocObj.Load(Server.MapPath("~/App_Data/ExpertsMenu.xml"));
                //    DataTable Items = XMLHelper.xml2Table(XmlDocObj, "//Group[@GroupTitle=\"" + GroupTitle + "\"]/Page", "Path,Title", "Path,Title", null);

                //    ItemReapeater.DataSource = Items;
                //    ItemsRepeater.DataBind();
                //}
            }
            catch (Exception ex)
            {
            }
        }
    }
}
