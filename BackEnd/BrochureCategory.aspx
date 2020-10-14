<%@ Page Language="C#" MasterPageFile="~/BackEnd/Master.master" AutoEventWireup="true" CodeFile="BrochureCategory.aspx.cs" Inherits="BackEnd_BrochureCategory" Title="المطبوعات" %>

<%@ Register Src="UserControls/BrochuresCategory.ascx" TagName="BrochuresCategory"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TopNav" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:BrochuresCategory id="BrochuresCategory1" runat="server">
    </uc1:BrochuresCategory>
</asp:Content>

