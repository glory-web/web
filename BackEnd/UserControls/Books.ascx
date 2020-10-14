<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Books.ascx.cs" Inherits="UserControls_Books" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<link href="../../CSS_JAVA/main.css" rel="stylesheet" type="text/css" />

<link href="../../CSS_JAVA/main.css" rel="stylesheet" type="text/css" />
<div style="float: right; width:100%;" dir="ltr">
<table id="blocks" cellpadding="0" cellspacing="0" class="blocks" dir="rtl" style="height: 500px"
    width="100%">
    <tr>
        <td align="right" class="title" dir="rtl">
            <center>
                الكتب الخاصة بالهيئة</center>
        </td>
    </tr>
    <tr>
        <td dir="rtl" style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px;
            padding-top: 10px; text-align: right">
            <br />
            <! --------------------------TO Here ------><table width="100%">
                <tr>
                    <td>
                        <asp:Label id="Label1" runat="server" Text="اسم التصنيف"></asp:Label></td>
                    <td>
                        <asp:DropDownList DataTextField="Category_Name_Ar" DataValueField="Category_ID" ID="DDL_Category" OnSelectedIndexChanged="DDL_Category_SelectedIndexChanged" runat="server" AutoPostBack="True">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View1" runat="server">
                                <asp:GridView ID="book_grid" runat="server" AutoGenerateColumns="False" HorizontalAlign="Justify" ShowFooter="True" Width="100%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="اسم الكتاب">
                                            <ItemTemplate>
                                                <asp:Literal ID="LIT_Arabic_Book_Name" runat="server" Text='<%# Bind("Book_Arabic_Name") %>'></asp:Literal>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="اسم الكتاب (الانجليزية)" Visible="False">
                                            <ItemTemplate>
                                                <asp:Literal ID="LIT_English_Book_Name" runat="server" Text='<%# Bind("Book_English_Name") %>'></asp:Literal>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="اسم المؤلف(العربية)" Visible="False">
                                            <ItemTemplate>
                                                <asp:Literal ID="LIT_Arabic_Authour_Name" runat="server" Text='<%# Bind("Authour_Arabic_Name") %>'></asp:Literal>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                &nbsp;
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="اسم المؤلف(الانجليزية)" Visible="False">
                                            <ItemTemplate>
                                                <asp:Literal ID="LIT_English_Authour_Name" runat="server" Text='<%# Bind("Authour_English_Name") %>'></asp:Literal>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                &nbsp;
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="سنة النشر" Visible="False">
                                            <ItemTemplate>
                                                <asp:Literal ID="LIT_Publication_Year" runat="server" Text='<%# Bind("Publication_Year") %>'></asp:Literal>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="الاجراءت">
                                            <AlternatingItemTemplate>
                                                <asp:LinkButton ID="EditBtn" runat="server" OnClick="EditBtn_Click">تعديل</asp:LinkButton>
                                                |
                                                <asp:LinkButton ID="DelBtn" runat="server" OnClick="DelBtn_Click" OnClientClick="return confirm('هل تريد الحذف ؟');">حذف</asp:LinkButton>
                                            </AlternatingItemTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="EditBtn" runat="server" OnClick="EditBtn_Click">تعديل</asp:LinkButton>
                                                |&nbsp;
                                                <asp:LinkButton ID="DelBtn" runat="server" OnClick="DelBtn_Click" OnClientClick="return confirm('هل تريد الحذف ؟');">حذف</asp:LinkButton>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                &nbsp; &nbsp;
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:LinkButton ID="AddBtn" runat="server" OnClick="AddBtn_Click">اضافة</asp:LinkButton>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="الظهور فى الصفحة الرئيسية">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CHBHighlight" runat="server" OnCheckedChanged="CHBHighlight_CheckedChanged" AutoPostBack="True" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text="اسم الكتاب(اللغة العربية)"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="TXT_Arabic_Book_Name" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" Height="88px" TextMode="MultiLine"/>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="اسم الكتاب (اللغة الانجليزية)"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="TXT_English_Book_Name" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" Height="88px" TextMode="MultiLine" />
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text="اسم المؤلف(اللغة العربية)"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="TXT_Authour_Arabic_Name" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" Height="88px" TextMode="MultiLine"/>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" Text="اسم المؤلف(اللغة الانجليزية)" Width="155px"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="TXT_Authour_English_Name" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" Height="88px" TextMode="MultiLine"/>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 92px">
                                            <asp:Label ID="Label6" runat="server" Text="سنة النشر / رقم الأصدار"></asp:Label></td>
                                        <td style="height: 92px">
                                            <asp:TextBox ID="TXT_Publication_Year" runat="server" MaxLength="50" Width="441px" ValidationGroup="BookVG"></asp:TextBox>
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" InputDirection="RightToLeft"
                                                Mask="9999/9999" MessageValidatorTip="true" MaskType="Number" TargetControlID="TXT_Publication_Year">
                                            </cc1:MaskedEditExtender>
                                            <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender1"
                                                ControlToValidate="TXT_Publication_Year" Display="Dynamic" ErrorMessage="ادخل سنة الأصدار/رقم الأصدار "
                                                SetFocusOnError="True" ValidationGroup="BookVG" MaximumValueBlurredMessage="ادخل سنة الأصدار/رقم الأصدار " TooltipMessage="ادخل سنة الأصدار/رقم الأصدار "></cc1:MaskedEditValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="TXT_Publication_Year" Display="Dynamic" ValidationGroup="BookVG"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2"><center>
                                            <asp:Button ID="Save" runat="server"  Text="اضافة" Width="43px" OnClick="Button1_Click" ValidationGroup="BookVG" />
                                            <asp:Button ID="Cancel" runat="server"  Text="الغاء" Width="45px" OnClick="CancelBtn_Click" /></center></td>
                                    </tr>
                                </table>
                            </asp:View>
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