<%@ Page Language="C#" MasterPageFile="~/BackEnd/Master.master" AutoEventWireup="true" CodeFile="Links.aspx.cs" Inherits="Links" Title="ÇáÑæÇÈØ" %>

<%@ Register Src="UserControls/Links.ascx" TagName="Links" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TopNav" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Links ID="Links1" runat="server" />
</asp:Content>

