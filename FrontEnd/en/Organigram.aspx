<%@ Page Language="C#" MasterPageFile="~/FrontEnd/en/EN_MasterPage.master" Theme="style" AutoEventWireup="true" CodeFile="Organigram.aspx.cs" Inherits="en_Organigram" Title="Organigram" %>

<%@ Register Src="../EN_Controls/Governorate.ascx" TagName="Governorate" TagPrefix="uc1" %>
<%@ Register Src="../EN_Controls/Organigram.ascx" TagName="Organigram" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

				<%--<p><a href="Organigram.aspx"><uc2:Organigram ID="Organigram1" runat="server" /></a></p>--%>
			
			<h2 class="main_title"> Organigram</h2>
    <table>
        <tr>
            <td>
                <a href="../en/img/govsE.JPG"><img src="../en/img/govsE.JPG" alt="" style="width: 519px; height: 481px" /></a>
            </td>
            
            <td valign="top">
                <uc2:Organigram ID="Organigram1" runat="server" />
             </td>   
        </tr>
    </table>
			
</asp:Content>

