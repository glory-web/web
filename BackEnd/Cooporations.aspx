<%@ Page Language="C#" MasterPageFile="~/BackEnd/Master.master" AutoEventWireup="true" CodeFile="Cooporations.aspx.cs" Inherits="Cooporations" Title="ÇáÊÚÇæä" %>

<%@ Register Src="UserControls/Cooporations.ascx" TagName="Cooporations" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TopNav" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Cooporations ID="Cooporations1" runat="server" />
</asp:Content>

