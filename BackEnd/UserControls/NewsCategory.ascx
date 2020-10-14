<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsCategory.ascx.cs" Inherits="UserControls_NewsCategory" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<link href="../../CSS_JAVA/main.css" rel="stylesheet" type="text/css" />

<! --------------------------From Here ------><div style="float: right; width:100%;" dir="ltr">
   
      <br />
     <table id="blocks" cellpadding="0" cellspacing="0" class="blocks" dir="rtl" style="height: 500px"
    width="100%">
    <tr>
        <td class="title" align="right" dir="rtl"><center>
            تصنيفات
      الأخبار 
        </center></td>
    </tr>
    <tr>
        <td dir="rtl" style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px;
            padding-top: 10px; text-align: right">
            <br />
            
            
      <! --------------------------TO Here ------><asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                    Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="اسم التصنيف باللغة العربية">
                            <EditItemTemplate>
                                <asp:TextBox ID="TXTCatArabicName" runat="server" Text='<%# Bind("Cat_Arabic_Name") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TXTCatArabicName"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="CATVGEdit"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="TXTCatArabicName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TXTCatArabicName"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="CATVG"></asp:RequiredFieldValidator>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Literal ID="LITCatArabicName" runat="server" Text='<%# Bind("Cat_Arabic_Name") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="اسم التصنيف باللغة الإنجليزية">
                            <EditItemTemplate>
                                <asp:TextBox ID="TXTCatEnglishName" runat="server" Text='<%# Bind("Cat_English_Name") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TXTCatEnglishName"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="CATVGEdit"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="TXTCatEnglishName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TXTCatEnglishName"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="CATVG"></asp:RequiredFieldValidator>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Literal ID="LITCatEnglishName" runat="server" Text='<%# Bind("Cat_English_Name") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="الإجراءات">
                            <EditItemTemplate>
                                <asp:LinkButton ID="LBTNSave" runat="server" OnClick="LBTNSave_Click" ValidationGroup="CATVGEdit">حفظ</asp:LinkButton>
                                |
                                <asp:LinkButton ID="LBTNCancel" runat="server" OnClick="LBTNCancel_Click">إلغاء</asp:LinkButton>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:LinkButton ID="LBTNAdd" runat="server" OnClick="LBTNAdd_Click" ValidationGroup="CATVG">إضافة</asp:LinkButton>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LBTNUpdate" runat="server" OnClick="LBTNUpdate_Click">تعديل</asp:LinkButton>
                                |
                                <asp:LinkButton ID="LBTNDelete" runat="server" OnClick="LBTNDelete_Click" OnClientClick="return confirm('هل تريد الحذف ؟');">حذف</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table width="100%">
                            <tr>
                                <td style="height: 15px; text-align: center">
                                    <strong>اسم التصنيف باللغة العربية</strong></td>
                                <td style="height: 15px; text-align: center">
                                    <strong>اسم التصنيف باللغة الإنجليزية</strong></td>
                                <td style="height: 15px; text-align: center">
                                    <strong>الإجراءات</strong></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="TXTCatArabicName" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator5" runat="server" ControlToValidate="TXTCatArabicName"
                                        Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="CATVG"></asp:RequiredFieldValidator></td>
                                <td>
                                    <asp:TextBox ID="TXTCatEnglishName" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator6" runat="server" ControlToValidate="TXTCatEnglishName"
                                        Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="CATVG"></asp:RequiredFieldValidator></td>
                                <td>
                                    <asp:LinkButton ID="LBTNAdd" runat="server" OnClick="LBTNAdd_Click" ValidationGroup="CATVG">إضافة</asp:LinkButton></td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                </asp:GridView>
       <! --------------------------From Here ------></td>
    </tr>
    <tr>
        <td>
            </td>
    </tr>
</table>
  
</div>