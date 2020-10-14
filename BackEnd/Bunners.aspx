<%@ Page Language="C#" MasterPageFile="~/BackEnd/Master.master" AutoEventWireup="true" CodeFile="Bunners.aspx.cs" Inherits="Bunners" Title="الهيئة العامه للخدمات البيطرية" %>

<%@ Register Src="UserControls/Bunner.ascx" TagName="Bunner" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TopNav" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Bunner id="Bunner1" runat="server">
    </uc1:Bunner>
</asp:Content>

