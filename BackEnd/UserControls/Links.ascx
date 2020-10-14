<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Links.ascx.cs" Inherits="UserControls_Links" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<link href="../../CSS_JAVA/main.css" rel="stylesheet" type="text/css" />

<script language="javascript" type="text/javascript">
    function openupload(CV)
    {
        var WinSettings = "left=150,top=150,width=530px,menubar=no,location=no,resizable=no,scrollbars=yes,status=no"
	    window.open("UserControls/UploadFiles.aspx?FileType="+CV, "Child", WinSettings);
	}
</script>
<! --------------------------From Here ------><div style="float: right; width:100%;" dir="ltr">
      <br />
     <table id="blocks" cellpadding="0" cellspacing="0" class="blocks" dir="rtl" style="height: 500px"
    width="100%">
    <tr>
        <td class="title" align="right" dir="rtl"><center>
      الروابط الخاصة بالهيئة
        </center></td>
    </tr>
    <tr>
        <td dir="rtl" style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px;
            padding-top: 10px; text-align: right">
            <br />
            
            
      <! --------------------------TO Here ------><table width="100%">
        <tr>
            <td colspan="2">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                            Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="اسم الرابط">
                                    <ItemTemplate>
                                        <asp:Literal ID="LITCoopArabicName" runat="server" Text='<%# Bind("Link_Arabic_Name") %>'></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الإجراءات">
                                    <EditItemTemplate>
                                        &nbsp;
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:LinkButton ID="LBTNAdd" runat="server" OnClick="LBTNAdd_Click1">إضافة</asp:LinkButton>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LBTNEdit" runat="server" OnClick="LBTNEdit_Click1">تعديل</asp:LinkButton>
                                        |
                                        <asp:LinkButton ID="LBTNDelete" runat="server" OnClick="LTNDalete_Click" OnClientClick="return confirm('هل تريد الحذف ؟');">حذف</asp:LinkButton>
                                        |
                                        <asp:LinkButton ID="LBTNShowDetails" runat="server" OnClick="LBTNShowDetails_Click">التفاصيل</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table width="100%">
                                        <tr>
                                            <td style="width: 175px; height: 26px;">
                                                <asp:Literal ID="LITCoopAraic" runat="server" Text="اسم الرابط باللغة العربية"></asp:Literal></td>
                                            <td style="height: 26px">
                                                <asp:TextBox ID="TXTLinkArabicName" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="singleLine" Height="88px" />
                                                
                                                <asp:RequiredFieldValidator ID="RFVManagerAraicName" runat="server" ControlToValidate="TXTLinkArabicName"
                                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 175px">
                                                <asp:Literal ID="Literal3" runat="server" Text="اسم الرابط باللغة الإنجليزية"></asp:Literal></td>
                                            <td>
                                                <asp:TextBox ID="TXTLinkEnglishName" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="singleLine" Height="88px" />
                                                
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXTLinkEnglishName"
                                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator></td>
                                        </tr>
                            <tr>
                                <td style="width: 175px">
                                    <asp:Literal ID="Literal4" runat="server" Text="الرابط"></asp:Literal></td>
                                <td>
                                    <asp:TextBox ID="TXTURL" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="singleLine" />
                                    
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3a" runat="server" ControlToValidate="TXTLogoEnglishTitle"
                                        Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="LinksVGEdit"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TXTURL"
                                        Display="Dynamic" ErrorMessage="اسم الموقع غير صحيح" SetFocusOnError="True" ValidationExpression="((https?|ftp|gopher|telnet|file|notes|ms-help):((//)|(\\\\))+[\w\d:#@%/;$()~_?\+-=\\\.&]*)"
                                        ValidationGroup="LinksVGEdit"></asp:RegularExpressionValidator></td>
                            </tr>
                                        <tr>
                                            <td style="width: 175px; height: 26px;">
                                                <asp:Literal ID="Literal6" runat="server" Text="عنوان الرابط باللغة العربية"></asp:Literal></td>
                                            <td style="height: 26px">
                                                <asp:TextBox ID="TXTLogoArabicTitle" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="singleLine" Height="88px" />
                                                            
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TXTLogoArabicTitle"
                                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 15px">
                                                <asp:Literal ID="Literal7" runat="server" Text="عنوان الرابط باللغة الإنجليزية"></asp:Literal></td>
                                            <td style="height: 15px">
                                                <asp:TextBox ID="TXTLogoEnglishTitle" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="singleLine" Height="88px" />
                                                           
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TXTLogoEnglishTitle"
                                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="Literal8" runat="server" Text="رفع الملف"></asp:Literal></td>
                                            <td>
                                                &nbsp;<asp:FileUpload ID="FUBrochureFile" runat="server" Width="441px" /></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                            <center>
                                                <asp:Button ID="BTNAdd" runat="server" OnClick="BTNAdd_Click" Text="إضافة" Visible="False" ValidationGroup="ManagerGV" />
                                                <asp:Button ID="BTNUpdate" runat="server" OnClick="BTNUpdate_Click" Text="تعديل"
                                                    Visible="False" ValidationGroup="ManagerGV" />
                                                <asp:Button ID="BTNCancel" runat="server" OnClick="BTNCancel_Click" Text="إلغاء"
                                                    Width="36px" /></center></td>
                                        </tr>
                                        
                                    </table>
                    </asp:View>
                    <asp:View ID="View3" runat="server">
                         <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                                        <ItemTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal7" runat="server" Text="اسم الرابط باللغة العربية"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal8" runat="server" Text='<%#Bind("Link_Arabic_Name") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal9" runat="server" Text="اسم الرابط باللغة الإنجليزية"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal10" runat="server" Text='<%#Bind("Link_English_Name") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal11" runat="server" Text="الرابط"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal12" runat="server" Text='<%#Bind("Link_URL") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal1" runat="server" Text="عنوان الشعار باللغة العربية"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal5" runat="server" Text='<%#Bind("Link_Logo_Arabic_Title") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal14" runat="server" Text="عنوان الشعار باللغة الإنجليزية"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal15" runat="server" Text='<%#Bind("Link_Logo_English_Title") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal13" runat="server" Text="ملف النشرة"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <a href='..\GovsFiles\ORG_<%#Eval("ORG_ID") %>_Files\Links\<%#Eval("Link_Logo_Path") %>'><%#Eval("Link_Logo_Path")%></a>                                                        
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <center>
                                        <asp:LinkButton ID="LBTNClose" runat="server" OnClick="LBTNClose_Click">Close</asp:LinkButton></center>
                    </asp:View>
                    &nbsp;
                </asp:MultiView>
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