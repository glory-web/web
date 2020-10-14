<%@ Page Language="C#" MasterPageFile="~/BackEnd/Master.master" AutoEventWireup="true" CodeFile="ServiceType.aspx.cs" Inherits="ServiceType" Title="الخدمات" %>

<%@ Register Src="UserControls/ServiceType.ascx" TagName="ServiceType" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TopNav" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ServiceType id="ServiceType1" runat="server">
    </uc1:ServiceType>
</asp:Content>

