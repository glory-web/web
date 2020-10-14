<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MangerNews.ascx.cs" Inherits="Mangers" %>

<asp:Repeater id="Repeater1" runat="server">
<ItemTemplate>
                   <asp:Label ID="Label1" runat="server"  Text='<%# Bind("News_Arabic_Title") %>'></asp:Label><br/>
                   <asp:Label ID="Label2" runat="server"  Text='<%# Bind("News_Arabic_Content") %>'></asp:Label><br/>
                   <asp:LinkButton CssClass="links_form" ID="LinkButton1" runat="server" PostBackUrl='<%# string.Concat("NewsDetails.aspx?ID=",Eval("News_ID"))  %>' > ›«’Ì·</asp:LinkButton><br/>
                   <asp:Image ID="Image1" runat="server" ImageUrl ='<%# String.Concat(ImagePath() ,Eval("ImagePath"))%>'> </asp:Image>

</ItemTemplate>

</asp:Repeater>