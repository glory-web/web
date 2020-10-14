<%@ Control Language="C#" AutoEventWireup="true" CodeFile="News.ascx.cs" Inherits="News" %>
<marquee direction="Right" width="99%" scrolldelay="250" id="GoveNews">
<asp:Repeater ID="Repeater1" runat="server">
<ItemTemplate>

<a style=" text-decoration:none" href='<%# string.Concat("NewsDetails.aspx?ID=",Eval("News_ID"))  %>' onmouseout="javascript:ChangeSpeed(200)"  onmouseover="javascript:ChangeSpeed(10000)">
<asp:Label ID="hyberlink1"   runat= "server" Text ='<%#  string.Concat(Eval("News_Arabic_Title")," &nbsp &nbsp &nbsp &nbsp  ")%>' ></asp:Label></a>
</ItemTemplate>

</asp:Repeater>
</marquee>
