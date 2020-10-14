<%@ Page Language="C#" MasterPageFile="~/BackEnd/Master.master" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="Users" Title="ÇáãÓÊÎÏãíä" %>

<%@ Register Src="UserControls/Users.ascx" TagName="Users" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TopNav" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Users ID="Users1" runat="server" />
</asp:Content>

