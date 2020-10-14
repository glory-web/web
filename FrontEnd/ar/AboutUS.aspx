<%@ Page Language="C#" MasterPageFile="~/FrontEnd/ar/AR_MasterPage.master" Theme="style" AutoEventWireup="true" CodeFile="AboutUS.aspx.cs" Inherits="FrontEnd_ar_AboutUS" Title="« ’· »‰«" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="main_title">« ’· »‰«</h2>
        
        <table dir="rtl" class="front">
            <tr>
                <td class="bg, Label_form" style="width: 153px; height: 25px;">
                    «·⁄‰Ê«‰:</td>
                <td style="text-align: right; text-indent: 15px; height: 25px;">
                    <asp:Label ID="Adreess" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td class="bg, Label_form" style="width: 153px">
                     ·Ì›Ê‰:</td>
                <td style="text-align: right; text-indent: 15px">
                   <asp:Label ID="Telephone" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td class="bg, Label_form" style="width: 153px">
                    ›«ﬂ”:</td>
                <td style="text-align: right; text-indent: 15px">
                    <asp:Label ID="Fax" runat="server" Text="Fax"></asp:Label></td>
            </tr>
            <tr>
                <td class="bg, Label_form" style="width: 153px; height: 25px;">
                    »—Ìœ «·ﬂ —Ê‰Ì:</td>
                <td style="text-align: right; text-indent: 15px; height: 25px;">
                    <a id ="test" href="mailto:govs@govs.gov.eg" runat ="server" ><asp:Label ID="Mail" runat="server" Text="Label"></asp:Label></a></td>
            </tr>
        </table>
        <br />
</asp:Content>



<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link rel="stylesheet" type="text/css" href="style.css" />
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
        <br />
        <br />
        <h2 class="main_title" style="width: 80%">
            « ’· »‰«</h2>
        <table dir="rtl" style="width: 70%" class="front">
            <tr>
                <td class="bg, Label_form" style="width: 153px">
                    «·⁄‰Ê«‰:</td>
                <td style="text-align: right; text-indent: 15px">
                    ..................................................</td>
            </tr>
            <tr>
                <td class="bg, Label_form" style="width: 153px">
                     ·Ì›Ê‰:</td>
                <td style="text-align: right; text-indent: 15px">
                    ...................................................</td>
            </tr>
            <tr>
                <td class="bg, Label_form" style="width: 153px">
                    ›«ﬂ”:</td>
                <td style="text-align: right; text-indent: 15px">
                    ...................................................</td>
            </tr>
            <tr>
                <td class="bg, Label_form" style="width: 153px">
                    »—Ìœ «·ﬂ —Ê‰Ì:</td>
                <td style="text-align: right; text-indent: 15px">
                    <a href="mailto:govs@govs.gov.eg">govs@govs.gov.eg</a></td>
            </tr>
        </table>
    </form>
</body>
</html>--%>
