<%@ Page Language="C#" MasterPageFile="~/FrontEnd/en/en_MasterPage.master" Theme="style" AutoEventWireup="true" CodeFile="Activity.aspx.cs" Inherits="en_Activity" Title="Activities" %>

<%@ Register Src="../en_Controls/Activity.ascx" TagName="Activity" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <h2 class="main_title">Activities</h2>
				        <p><uc1:Activity ID="Activity1" runat="server" /></p>
    	
</asp:Content>

