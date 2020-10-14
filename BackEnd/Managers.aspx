<%@ Page Language="C#" MasterPageFile="~/BackEnd/Master.master" AutoEventWireup="true" CodeFile="Managers.aspx.cs" Inherits="Managers" Title="ÇáãÏíÑíä" %>

<%@ Register Src="UserControls/OrganizationManagers.ascx" TagName="OrganizationManagers"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TopNav" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:OrganizationManagers ID="OrganizationManagers1" runat="server" />
</asp:Content>

