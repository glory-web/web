<%@ Page Language="C#" MasterPageFile="~/BackEnd/Master.master" AutoEventWireup="true" CodeFile="OrganixationDate.aspx.cs" Inherits="UserControls_OrganixationDate" Title="ÇáÌåÇÊ ÇáÊÇÈÚå" %>


<%@ Register Src="UserControls/Organization.ascx" TagName="Organization" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TopNav" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Organization ID="Organization1" runat="server" />
</asp:Content>

