<%@ Page Language="C#" MasterPageFile="~/BackEnd/Master.master" AutoEventWireup="true" CodeFile="inner.aspx.cs"
    Inherits="inner" %>

<%@ Register Src="UserControls/AfterUserLogIn.ascx" TagName="AfterUserLogIn" TagPrefix="uc3" %>

<%@ Register Src="UserControls/ControlPanelMenue.ascx" TagName="ControlPanelMenue"
    TagPrefix="uc2" %>

<%@ Register Src="UserControls/ControlPanel.ascx" TagName="ControlPanel" TagPrefix="uc1" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>

<%@ Register TagName="topnav" TagPrefix="tNav" Src="~/BackEnd/UserControls/topnav.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="TopNav" Runat="Server">
    
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<! --------------------------From Here ------><div dir="ltr" style="float: right;
    width: 100%">
    <br />
    <table id="blocks" cellpadding="0" cellspacing="0" class="blocks" dir="rtl" style="height: 500px"
    width="100%">
        <tr>
            <td align="right" class="title" dir="rtl">
                <center>
                    </center>
            </td>
        </tr>
        <tr>
            <td dir="rtl" style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px;
            padding-top: 10px; text-align: right">
                <br />
                <! --------------------------TO Here ------>
                <table cellpadding="0" cellspacing="0" style="width: 100%; margin-top:45px" dir="ltr">
        <tr>
            <td class="lt" style="padding-left: 35px; height: 180px">
                <uc3:AfterUserLogIn ID="AfterUserLogIn1" runat="server" />
                    
            </td>
            <td rowspan="3">
                <img src="../Images/dvdr_v.jpg" /></td>
            <td>
                <img src="../Images/mainpic1.jpg" /><br />
                <br />
                <br />
                &nbsp;</td>
        </tr>
        <tr>
            <td class="cntr">
                <img src="../Images/dvdr_h.jpg" /></td>
            <td>
                <img src="../Images/dvdr_h.jpg" /></td>
        </tr>
        <tr>
           
            <td style="height: 180px; padding-left: 35px;" class="lt" colspan="3">
                <strong><span style="color: #669900"><span style="text-decoration: underline">Official
                    Sponsors for the Tool:</span><br />
                    <br />
                    
                </span></strong>
           <table cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td class="rt mdl" style="width: 79px; height: 58px">
                                <img src="../Images/logo_CLAES_small.jpg" />&nbsp;
                            </td>
                            <td style="height: 58px" class="mdl lt">
                                The Central Laboratory For Agricultural Expert Systems 
                                <br />
                                Official site: <a href="http://www.claes.sci.eg"><span style="color: #cc6600">www.claes.sci.eg</span></a></td>
                            <td class="mdl lt" style="height: 58px" title="GOFVS">
                                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="top rt" style="width: 79px; padding-top: 5px; height: 51px;">
                                <img src="../Images/logo_ICARDA_small.jpg" />&nbsp;</td>
                            <td style="height: 51px" class="mdl lt">
                                General Organization For Veterinary Services&nbsp;<br />
                                Official site: <a href="http://www.icarda.org"><span style="color: #cc6600">www.Govs.gov.eg</span></a></td>
                            <td class="mdl lt" style="height: 51px">
                            </td>
                        </tr>
                    </table> </td>
        </tr>
    </table>
                <! --------------------------From Here ------></td>
    </tr>
    <tr>
        <td>
            </td>
    </tr>
</table>
  
</div>
                
</asp:Content>


