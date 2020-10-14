<%@ Page Language="C#" MasterPageFile="~/BackEnd/Master.master" AutoEventWireup="true" CodeFile="Governrates.aspx.cs" Inherits="Governrates" Title="ÇáãÏíÑíÇÊ" %>

<%@ Register Src="UserControls/Governrates.ascx" TagName="Governrates" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TopNav" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc2:Governrates ID="Governrates1" runat="server" />
</asp:Content>

