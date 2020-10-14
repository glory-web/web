<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Boxs.ascx.cs" Inherits="UserControls_Boxs" %>
<link href="../../CSS_JAVA/main.css" rel="stylesheet" type="text/css" />
<! --------------------------From Here ------><div style="float: right; width:100%;">
      <br />
     <table id="blocks" cellpadding="0" cellspacing="0" class="blocks" dir="rtl" style="height: 500px"
    width="100%">
    <tr>
        <td class="title" align="right" dir="rtl"><center>
      انشاء و تعديل القوائم الجانبية
        </center></td>
    </tr>
    <tr>
        <td dir="rtl" style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px;
            padding-top: 10px; text-align: right">
            <br />
            
            
      <! --------------------------TO Here ------><table width="100%">
      <tr><td colspan="2">
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <asp:GridView ID="org_grid" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                        Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="اسم القائمة(اللغة ألعربية(">
                                <ItemTemplate>
                                    <asp:Literal ID="LIT_Arabic_Name" runat="server" Text='<%# Bind("BoxArabicTitle") %>'></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="اسم القائمة(اللغة الانجليزية)">
                                <ItemTemplate>
                                    <asp:Literal ID="LIT_English_Name" runat="server" Text='<%# Bind("BoxEnglishTitle") %>'></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الأجراءات">
                                <FooterTemplate>
                                    <asp:LinkButton ID="add_btn" runat="server" OnClick="add_btn_Click">اضافة</asp:LinkButton>
                                </FooterTemplate>
                                <ItemTemplate>
                                    &nbsp;<asp:LinkButton ID="Dlt_btn" runat="server" OnClick="Dlt_btn_Click">حذف</asp:LinkButton>
                                    |
                                    <asp:LinkButton ID="Update_btn" runat="server" OnClick="Edit_btn_Click" OnClientClick="return confirm('هل تريد الحذف ؟');">تعديل</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <table width="100%">
                        <tr>
                            <td style="width: 137px; height: 36px;">
                                <asp:Label ID="Label6" runat="server" Text="الاسم (العربي)" Width="91px"></asp:Label></td>
                            <td style="width: 334px; height: 36px;">
                                    
                                <asp:TextBox ID="TXT_Arabic_Name" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="SingleLine" Height="88px" />
                                
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXT_Arabic_Name"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ORGVG"></asp:RequiredFieldValidator>
                                 </td>                                 
                        </tr>
                        <tr>
                            <td style="width: 137px">
                                <asp:Label ID="Label5" runat="server" Text="الاسم (الانجليزية)" Width="91px"></asp:Label></td>
                            <td style="width: 334px">
                                <asp:TextBox ID="TXT_English_Name" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="SingleLine" Height="88px" />
                                
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TXT_English_Name"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ORGVG"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="نوع المحتوى" Width="91px"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="DDLContent" runat="server">
                                    <asp:ListItem Value="0">كتب</asp:ListItem>
                                    <asp:ListItem Value="1">مطبوعات</asp:ListItem>
                                    <asp:ListItem Value="2">تعاون دولي</asp:ListItem>
                                    <asp:ListItem Value="3">قوانين</asp:ListItem>
                                    <asp:ListItem Value="0">الأخبار</asp:ListItem>
                                    <asp:ListItem Value="5">المشاريع</asp:ListItem>
                                    <asp:ListItem Value="6">الخدمات</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 29px"><center>
                                <asp:Button ID="Save" runat="server" OnClick="Save_Click1" Text="إضافة" Width="93px" ValidationGroup="ORGVG" />
                                <asp:Button ID="Cancel_Btn" runat="server" OnClick="Cancel_Click" Text="الغاء" Width="86px" /></center></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 29px">
                            </td>
                        </tr>
                    </table>
                </asp:View>
                &nbsp;
            </asp:MultiView></td></tr>
      </table>
            <! --------------------------From Here ------></td>
    </tr>
    <tr>
        <td>
            </td>
    </tr>
</table>
  
</div>