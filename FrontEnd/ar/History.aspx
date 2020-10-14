<%@ Page Language="C#" MasterPageFile="~/FrontEnd/ar/AR_MasterPage.master" Theme="style" AutoEventWireup="true" CodeFile="History.aspx.cs" Inherits="ar_History" Title="ÊÇÑíÎ ÇáåíÆÉ" %>

<%@ Register Src="../AR_Controls/History.ascx" TagName="History" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
  
<h2 class="main_title" >ÇáåíÆÉ</h2>
<p><uc1:History ID="History1" runat="server" /></p>
            
</asp:Content>

