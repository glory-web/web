<%@ Page Language="C#" MasterPageFile="~/BackEnd/Master.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="News" Title="ÇáÇÎÈÇÑ" %>

<%@ Register Src="UserControls/News.ascx" TagName="News" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TopNav" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:News ID="News1" runat="server" />
</asp:Content>

