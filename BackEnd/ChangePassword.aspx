<%@ Page Language="C#" MasterPageFile="~/BackEnd/Master.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" Title="المستخدمين" %>

<%@ Register Src="UserControls/ChangeUserPassword.ascx" TagName="ChangeUserPassword"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TopNav" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ChangeUserPassword ID="ChangeUserPassword1" runat="server" />
</asp:Content>

