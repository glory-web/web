<%@ Page Language="C#" MasterPageFile="~/BackEnd/Master.master" AutoEventWireup="true" CodeFile="Services.aspx.cs" Inherits="Services" Title="ÇáÎÏãÇÊ" %>

<%@ Register Src="UserControls/Services.ascx" TagName="Services" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TopNav" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Services ID="Services1" runat="server" />
</asp:Content>

