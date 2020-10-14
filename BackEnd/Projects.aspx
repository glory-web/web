<%@ Page Language="C#" MasterPageFile="~/BackEnd/Master.master" AutoEventWireup="true" CodeFile="Projects.aspx.cs" Inherits="Projects" Title="ÇáãÔÇÑíÚ" %>

<%@ Register Src="UserControls/Projects.ascx" TagName="Projects" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TopNav" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Projects ID="Projects1" runat="server" />
</asp:Content>

