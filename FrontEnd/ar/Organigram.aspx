<%@ Page Language="C#" MasterPageFile="~/FrontEnd/ar/AR_MasterPage.master" Theme="style" AutoEventWireup="true"
    CodeFile="Organigram.aspx.cs" Inherits="ar_Organigram" Title="«беняб «б дўнгн" %>

<%@ Register Src="../AR_Controls/Governorate.ascx" TagName="Governorate" TagPrefix="uc1" %>
<%@ Register Src="../AR_Controls/Organigram.ascx" TagName="Organigram" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2 class="main_title">
        «беняб «б дўнгм ббен∆…</h2>
    <table>
        <tr>
            <td>
                <a href="../ar/img/govs.JPG" target="_blank" ><img src="../ar/img/govs.JPG" alt="" style="width: 519px; height: 481px" /></a>
            </td>
            
            <td valign="top">
                <uc2:Organigram ID="Organigram1" runat="server" />
             </td>   
        </tr>
    </table>
</asp:Content>
