<%@ Page Language="C#" MasterPageFile="~/FrontEnd/en/EN_MasterPage.master" Theme="style" AutoEventWireup="true" CodeFile="Old_Projects.aspx.cs" Inherits="ar_Old_Projects" Title="Achieved Projects" %>

<%@ Register Src="../EN_Controls/Old_Projects.ascx" TagName="Old_Projects" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Old_Projects ID="Old_Projects1" runat="server" />
</asp:Content>

