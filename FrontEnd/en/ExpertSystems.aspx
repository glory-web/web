<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExpertSystems.aspx.cs" Theme="style"  MasterPageFile="~/FrontEnd/en/EN_MasterPage.master" Inherits="FrontEnd_en_ExpertSystems" %>

<%@ Register Src="~/FrontEnd/EN_Controls/ExepertLinks.ascx"  TagName="ExepertLinks" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--<h2 class="main_title">  Exepert Links</h2>--%>
    <uc1:ExepertLinks ID="ExepertLinks1" runat="server" />
</asp:Content> 