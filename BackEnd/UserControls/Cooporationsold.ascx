<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Cooporations.ascx.cs" Inherits="UserControls_Cooporations" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<link href="../../CSS_JAVA/main.css" rel="stylesheet" type="text/css" />
<! --------------------------From Here ------><div dir="ltr" style="float: right;
    width: 100%">

    <br />
    <table id="blocks" cellpadding="0" cellspacing="0" class="blocks" dir="rtl" style="height: 500px"
    width="100%">
        <tr>
            <td align="right" class="title" dir="rtl">
                <center>
                    التعاون الدولى الخاص بالهيئة
                </center>
            </td>
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
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" ShowFooter="True">
                                        <Columns>
                                            <asp:TemplateField HeaderText="اسم التعاون">
                                                <ItemTemplate>
                                                    <asp:Literal ID="LITCoopArabicName" runat="server" Text='<%# Bind("Coop_Arabic_Name") %>'></asp:Literal>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="الإجراءات">
                                                <EditItemTemplate>
                                                    &nbsp;
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:LinkButton ID="LBTNAdd" runat="server" OnClick="LBTNAdd_Click">إضافة</asp:LinkButton>
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LBTNEdit" runat="server" OnClick="LBTNEdit_Click">تعديل</asp:LinkButton>
                                                    |
                                                    <asp:LinkButton ID="LBTNDelete" runat="server" OnClick="LBTNDelete_Click" OnClientClick="return confirm('هل تريد الحذف ؟');">حذف</asp:LinkButton>&nbsp;
                                                    |
                                                    <asp:LinkButton ID="LBTNShowDetails" runat="server" OnClick="LBTNShowDetails_Click">التفاصيل</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="الظهور فى الصفحة الرئيسية">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CHBHighlight" runat="server" AutoPostBack="True" OnCheckedChanged="CHBHighlight_CheckedChanged" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                        </td>
                                    </tr>
                                    
                                </table>
                                    
                                </asp:View>
                                <asp:View ID="View2" runat="server">
                                    <table width="100%">
                                        <tr>
                                            <td style="width: 175px">
                                                <asp:Literal ID="LITCoopAraic" runat="server" Text="اسم التعاون باللغة العربية"></asp:Literal></td>
                                            <td>
                                                <asp:TextBox ID="TXTCoopArabicName" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="SingleLine" Height="88px" />
                                                
                                                <asp:RequiredFieldValidator ID="RFVManagerAraicName" runat="server" ControlToValidate="TXTCoopArabicName"
                                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 175px">
                                                <asp:Literal ID="Literal3" runat="server" Text="اسم التعاون باللغة الإنجليزية"></asp:Literal></td>
                                            <td>
                                                <asp:TextBox ID="TXTCoopEnglishName" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="SingleLine" Height="88px" />
                                                
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXTCoopEnglishName"
                                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 15px; width: 175px;">
                                                <asp:Literal ID="Literal4" runat="server" Text="وصف التعاون باللغة العربية"></asp:Literal></td>
                                            <td style="height: 15px">
                                                <asp:TextBox ID="TXTCoopAraicContent" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px"  Height="140px" TextMode="MultiLine" />
                                                
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TXTCoopAraicContent"
                                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 175px">
                                                <asp:Literal ID="Literal2" runat="server" Text="وصف التعاون باللغة الإنجليزية"></asp:Literal></td>
                                            <td>
                                                <asp:TextBox ID="TXTCoopEnglishContent" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px"  Height="140px" TextMode="MultiLine" />
                                                
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TXTCoopEnglishContent"
                                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 175px">
                                                <asp:Literal ID="Literal5" runat="server" Text="تاريخ التعاون"></asp:Literal></td>
                                            <td>
                                                <asp:TextBox ID="TXTCoopDate" runat="server" Text='<%# Bind("Brochure_Date") %>'></asp:TextBox><asp:ImageButton
                                                    ID="IBTNCalender" runat="server" ImageUrl="~/Images/calendar_ico.png" /><asp:RegularExpressionValidator
                                                        ID="RegularExpressionValidator2" runat="server" ControlToValidate="TXTCoopDate"
                                                        Display="Dynamic" ErrorMessage="yyyy/mm/dd" SetFocusOnError="True" ValidationExpression="(0[1-9]|[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|[1-9]|1[012])[- /.](19|20)[0-9]{2}"
                                                        ValidationGroup="ManagerGV"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TXTCoopDate"
                                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator><cc1:calendarextender
                                                        id="CalendarExtender1" runat="server" format="dd/MM/yyyy" popupbuttonid="IBTNCalender"
                                                        targetcontrolid="TXTCoopDate">
                                </cc1:calendarextender></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="Literal6" runat="server" Text="الدول أو الجهات المشاركة فى التعاون"></asp:Literal></td>
                                            <td>
                                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                                                    Width="100%">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="اسم الدولة او الجهة باللغة العربية">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TXTCountryArabicName" runat="server" Text='<%# Bind("Second_Org_Arabic_Name") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="TXTCountryArabicName" runat="server"></asp:TextBox>
                                                            </FooterTemplate>
                                                            <ItemTemplate>
                                                                <asp:Literal ID="LITCountryArabicName" runat="server" Text='<%# Bind("Second_Org_Arabic_Name") %>'></asp:Literal>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="اسم الدولة أو الجهة باللغة الأنجليزية">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TXTCountryEnglishName" runat="server" Text='<%# Bind("Second_Org_English_Name") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="TXTCountryEnglishName" runat="server"></asp:TextBox>
                                                            </FooterTemplate>
                                                            <ItemTemplate>
                                                                <asp:Literal ID="LITCountryEnglishName" runat="server" Text='<%# Bind("Second_Org_English_Name") %>'></asp:Literal>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="الإجراءات">
                                                            <EditItemTemplate>
                                                                <asp:LinkButton ID="LBTNCancel" runat="server" OnClick="LBTNCancel_Click1">إلغاء</asp:LinkButton>
                                                                |
                                                                <asp:LinkButton ID="LBTNSave" runat="server" OnClick="LBTNSave_Click1">حفظ</asp:LinkButton>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:LinkButton ID="LBTNAdd" runat="server" OnClick="LBTNAdd_Click1">إضافة</asp:LinkButton>
                                                            </FooterTemplate>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LBTNEdit" runat="server" OnClick="LBTNEdit_Click1">تعديل</asp:LinkButton>
                                                                |
                                                                <asp:LinkButton ID="LBTNDelete" runat="server" OnClick="LBTNDelete_Click1">حذف</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <table width="100%">
                                                            <tr>
                                                                <td>اسم الدولة أو الجهة باللغة العربية</td>
                                                                <td>اسم الدولة أو الجهة باللغة الإنجليزية</td>
                                                                <td>الإجراءات</td>
                                                            </tr>
                                                             <tr>
                                                                <td><asp:TextBox ID="TXTCountryArabicName" runat="server"></asp:TextBox></td>
                                                                <td><asp:TextBox ID="TXTCountryEnglishName" runat="server"></asp:TextBox></td>
                                                                <td><asp:LinkButton ID="LBTNAdd" runat="server" OnClick="LBTNAdd_Click1">إضافة</asp:LinkButton></td>
                                                            </tr>
                                                        </table>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </td>
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
                                                        <asp:Literal ID="Literal7" runat="server" Text="اسم التعاون باللغة العربية"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal8" runat="server" Text='<%#Bind("Coop_Arabic_Name") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal9" runat="server" Text="اسم التعاون باللغة الإنجليزية"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal10" runat="server" Text='<%#Bind("Coop_English_Name") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal11" runat="server" Text="وصف التعاون باللغة العربية"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal12" runat="server" Text='<%#Bind("Coop_Arabic_Content") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal13" runat="server" Text="وصف التعاون باللغة الإنجليزية"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal14" runat="server" Text='<%#Bind("Coop_English_Content") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal15" runat="server" Text="تاريخ التعاون"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal16" runat="server" Text='<%#Bind("Coop_Date") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal18" runat="server" Text="الدول و الهيئات المشاركة فى التعاون"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Repeater ID="Repeater2" runat="server">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="Literal17" runat="server" Text='<%# Bind("Second_Org_Arabic_Name") %>'></asp:Literal>, 
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <center>
                                        <asp:LinkButton ID="LBTNClose" runat="server" OnClick="LBTNClose_Click">Close</asp:LinkButton></center>
                                </asp:View>
                            </asp:MultiView></td>
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