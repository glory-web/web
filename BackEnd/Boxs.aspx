<%@ Page Language="C#" MasterPageFile="~/BackEnd/Master.master" AutoEventWireup="true" CodeFile="Boxs.aspx.cs" Inherits="Boxs" Title="الهيئة العامه للخدمات البيطرية" %>

<%@ Register Src="UserControls/Boxs.ascx" TagName="Boxs" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TopNav" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Boxs ID="Boxs1" runat="server" />
</asp:Content>

