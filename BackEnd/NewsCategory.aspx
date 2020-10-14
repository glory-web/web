<%@ Page Language="C#" MasterPageFile="~/BackEnd/Master.master" AutoEventWireup="true" CodeFile="NewsCategory.aspx.cs" Inherits="NewsCategory" Title="Untitled Page" %>

<%@ Register Src="UserControls/NewsCategory.ascx" TagName="NewsCategory" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TopNav" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:NewsCategory ID="NewsCategory1" runat="server" />
</asp:Content>

