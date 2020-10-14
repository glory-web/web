<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChangeUserPassword.ascx.cs" Inherits="UserControls_ChangeUserPassword" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<link href="../../CSS_JAVA/main.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    function valComments_ClientValidate(source, args)
    {
        var UserPassword = '<%=(string)Session["UserPassword"]%>';
        if(args.Value==UserPassword)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }
</script>
<! --------------------------From Here ------><div style="float: right; width:100%;" dir="ltr">
   
      <br />
     <table id="blocks" cellpadding="0" cellspacing="0" class="blocks" dir="rtl" style="height: 500px"
    width="100%">
    <tr>
        <td class="title" align="right" dir="rtl"><center>
      تغيير كلمة مرور المستخدم
        </center></td>
    </tr>
    <tr>
       <td dir="rtl" style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px;
            padding-top: 10px; text-align: right">
            <br />
            
            
      <! --------------------------TO Here ------><table width="100%">
        <tr>
            <td>
                أسم المستخدم:
                <asp:Literal ID="LITAdminName" runat="server"></asp:Literal>
            </td>
            <td>
                أسم الجهة:
                <asp:Literal ID="LITAdminOrg" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Literal ID="Literal1" runat="server" Text="كلمة السر السابقة"></asp:Literal>
            </td>
            <td>
                <asp:TextBox ID="TXTOldPassword" runat="server" Width="441px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXTOldPassword"
                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ChangePassword"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="TXTOldPassword"
                    Display="Dynamic" ErrorMessage="الرجاء ادخال كلمة السر الصحيحة"
                    ValidationGroup="ChangePassword" ClientValidationFunction="valComments_ClientValidate" SetFocusOnError="True" ValidateEmptyText="True"></asp:CustomValidator></td>
            
        </tr>
        <tr>
            <td>
                <asp:Literal ID="Literal2" runat="server" Text="كلمة السر الجديدة"></asp:Literal>
            </td>
            <td>
                <asp:TextBox ID="TXTNewPassword" runat="server" Width="441px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TXTNewPassword"
                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ChangePassword"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TXTNewPassword"
                    ControlToValidate="TXTReNewPassword" Display="Dynamic" ErrorMessage="الرجاء تكرار نفس كلمة السر"
                    SetFocusOnError="True" ValidationGroup="ChangePassword"></asp:CompareValidator></td>
            
        </tr>
        <tr>
            <td>
                <asp:Literal ID="Literal3" runat="server" Text="إعادة كلمة السر الجديدة"></asp:Literal>
            </td>
            <td>
                <asp:TextBox ID="TXTReNewPassword" runat="server" Width="441px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TXTReNewPassword"
                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ChangePassword"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td colspan="2">
                <center>
                    <asp:Button ID="BTNSave" runat="server" Text="تغيير" OnClick="BTNSave_Click" ValidationGroup="ChangePassword" Width="50px" />
                    <asp:Button ID="BTNCancel" runat="server" Text="الغاء" OnClick="BTNCancel_Click" Width="51px" />
                </center>
            </td>
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