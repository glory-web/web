<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BookCategory.ascx.cs" Inherits="UserControls_BookCategory" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<link href="../../CSS_JAVA/main.css" rel="stylesheet" type="text/css" />
<div style="float: right; width:100%;" dir="ltr">
<table id="blocks" cellpadding="0" cellspacing="0" class="blocks" dir="rtl" style="height: 500px"
    width="100%">
    <tr>
        <td align="right" class="title" dir="rtl">
            <center>
                تصنيفات
                الكتب الخاصة بالهيئة</center>
        </td>
    </tr>
    <tr>
        <td dir="rtl" style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px;
            padding-top: 10px; text-align: right">
            <br />
            <! --------------------------TO Here ------><table width="100%">
                <tr>
                    <td style="height: 139px">
                        <asp:GridView ID="book_category_grid" runat="server" AutoGenerateColumns="False"
                            ShowFooter="True" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="اسم التصنيف باللغة العربية">
                                    <AlternatingItemTemplate>
                                        <asp:Literal ID="LIT_Arabic_Name" runat="server" Text='<%# Bind("Category_Name_Ar") %>'></asp:Literal>
                                    </AlternatingItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TXT_Arabic_Name" runat="server" Text='<%# Bind("Category_Name_Ar") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXT_Arabic_Name"
                                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="BookCatVGEdit"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="TXT_Arabic_Name" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXT_Arabic_Name"
                                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="BookCatVG"></asp:RequiredFieldValidator>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Literal ID="LIT_Arabic_Name" runat="server" Text='<%# Bind("Category_Name_Ar") %>'></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="اسم التصنيف باللغة الإنجليزية">
                                    <AlternatingItemTemplate>
                                        <asp:Literal ID="LIT_English_Name" runat="server" Text='<%# Bind("Category_Name_En") %>'></asp:Literal>
                                    </AlternatingItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TXT_English_Name" runat="server" Text='<%# Bind("Category_Name_En") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFVb" runat="server" ControlToValidate="TXT_English_Name"
                                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="BookCatVGEdit"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="TXT_English_Name" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFVb" runat="server" ControlToValidate="TXT_English_Name"
                                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="BookCatVG"></asp:RequiredFieldValidator>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Literal ID="LIT_English_Name" runat="server" Text='<%# Bind("Category_Name_En") %>'></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الإجراءات">
                                    <AlternatingItemTemplate>
                                        <asp:LinkButton ID="EditBtn" runat="server" OnClick="EditBtn_Click">تعديل</asp:LinkButton>&nbsp;|
                                        <asp:LinkButton ID="DelBtn" runat="server" OnClick="DelBtn_Click" OnClientClick="return confirm('هل تريد الحذف؟');">حذف</asp:LinkButton>
                                    </AlternatingItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="UpdateBtn" runat="server" OnClick="UpdateBtn_Click" ValidationGroup="BookCatVGEdit">حفظ</asp:LinkButton>&nbsp;|
                                        <asp:LinkButton ID="CancelBtn" runat="server" OnClick="CancelBtn_Click">إلغاء</asp:LinkButton>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:LinkButton ID="AddBtn" runat="server" OnClick="AddBtn_Click" ValidationGroup="BookCatVG">إضافة</asp:LinkButton>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="EditBtn" runat="server" OnClick="EditBtn_Click">تعديل</asp:LinkButton>&nbsp;|
                                        <asp:LinkButton ID="DelBtn" runat="server" OnClick="DelBtn_Click" OnClientClick="return confirm('هل تريد الحذف ؟');">حذف</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <table style="width: 402px">
                                    <tr>
                                        <td style="width: 130px; height: 26px; text-align: center;">
                                            <strong>اسم التصنيف باللغة العربية</strong></td>
                                        <td style="width: 148px; height: 26px; text-align: center;">
                                            <strong>اسم التصنيف باللغة الإنجليزية</strong></td>
                                        <td style="width: 148px; height: 26px; text-align: center;">
                                            <strong>الإجراءات</strong></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 130px; height: 26px;">
                                            <asp:TextBox ID="TXT_Arabic_Name" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXT_English_Name"
                                                Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="BookCatVG"></asp:RequiredFieldValidator></td>
                                        <td style="width: 148px; height: 26px;">
                                            <asp:TextBox ID="TXT_English_Name" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFVb" runat="server" ControlToValidate="TXT_English_Name"
                                                Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="BookCatVG"></asp:RequiredFieldValidator></td>
                                        <td style="width: 148px; height: 26px">
                                            <asp:LinkButton ID="AddBtn" runat="server" OnClick="AddBtn_Click" ValidationGroup="BookCatVG">إضافة</asp:LinkButton></td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                        </asp:GridView>
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