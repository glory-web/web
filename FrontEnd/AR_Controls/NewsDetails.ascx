<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsDetails.ascx.cs" Inherits="AR_Controls_NewsDetails" %>
<br />
<asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="View1" runat="server">
        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
            <ItemTemplate>
                <asp:Label ID="Label1" CssClass="GridViewH HighLightsHead" Width="100%" runat="server" Text='<%# Bind("Cat_Arabic_Name") %>' Visible='<%# TextVisible(Eval("Cat_ID").ToString()) %>'></asp:Label>
                <asp:GridView ID="news_grid" runat="server" AutoGenerateColumns="False" ShowHeader="false" >
                    <Columns>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton CssClass="HighLightsItems" ID="LinkButton1" runat="server" Text='<%# Bind("News_Arabic_Title") %>'
                                    OnClick="LinkButton1_Click">LinkButton</asp:LinkButton>
                                    
                                  <p class="NewsContent"><asp:Label ID="Label2" runat="server" Text='<%# NewsContent(Eval("News_Arabic_Content").ToString()) %>'></asp:Label></p>
                                  <asp:Label ID="News_ID" runat="server" Text='<%# Eval("News_ID") %>' Visible="false" ></asp:Label>
                      
                                <!-- <asp:Image ID="News_Image"  runat="server" ImageUrl = '<%#string.Concat(ImagePath(), Eval("ImagePath"))  %>'   Visible ='<%#System.IO.File.Exists(Server.MapPath (string.Concat(ImagePath(), Eval("ImagePath")))) %>' /> -->
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ItemTemplate>
        </asp:Repeater>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <h2 class="NewsLabel"><asp:Literal ID="News_Title" runat="server"></asp:Literal></h2>
        <p class="NewsDate"><asp:Literal ID="News_Date" runat="server"></asp:Literal></p>
        <div style="text-align:center"><asp:Image ID="News_Image" runat="server"></asp:Image></div>
        <p class="NewsContent"><asp:Literal ID="News_Content" runat="server"></asp:Literal></p>
        
    </asp:View>
</asp:MultiView>
