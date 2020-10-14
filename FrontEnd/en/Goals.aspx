<%@ Page Language="C#" MasterPageFile="~/FrontEnd/en/En_MasterPage.master" Theme="style" AutoEventWireup="true" CodeFile="Goals.aspx.cs" Inherits="en_Goals" Title="Mission" %>

<%@ Register Src="../EN_Controls/Goals.ascx" TagName="Goals" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2 class="main_title">Mission and vision</h2>
				        <p>  <uc1:Goals ID="Goals1" runat="server" /></p>
  
</asp:Content>

