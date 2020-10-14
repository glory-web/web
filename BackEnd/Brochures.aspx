<%@ Page Language="C#" MasterPageFile="~/BackEnd/Master.master" AutoEventWireup="true" CodeFile="Brochures.aspx.cs" Inherits="Brochures" Title="ÇáãØÈæÚÇÊ" %>

<%@ Register Src="UserControls/Brochures.ascx" TagName="Brochures" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TopNav" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Brochures ID="Brochures1" runat="server" />
</asp:Content>

