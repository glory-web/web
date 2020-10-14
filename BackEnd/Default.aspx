<%@ Page Language="C#" MasterPageFile="~/BackEnd/DefaultMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="الهيئة العامه للخدمات البيطرية" %>

<%@ Register Src="UserControls/login.ascx" TagName="login" TagPrefix="uc1" %>
<%@ Register TagName="topnav" TagPrefix="tNav" Src="~/BackEnd/UserControls/topnav.ascx" %>



<asp:Content ID="Content2" ContentPlaceHolderID="TopNav" Runat="Server">

<script language="javascript" type="text/javascript">
// <!CDATA[

function IMG1_onclick() {

}

// ]]>
</script>
</asp:Content>





<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0" style="width: 100%; margin-top:45px">
        <tr>
            <td class="lt" style="padding-left: 35px; height: 180px">
                    <uc1:login ID="Login2" runat="server" />
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

</asp:Content>

