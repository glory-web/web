<%@ Control Language="C#" AutoEventWireup="true" CodeFile="News.ascx.cs" Inherits="UserControls_News" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<link href="../../CSS_JAVA/main.css" rel="stylesheet" type="text/css" />

<! --------------------------From Here ------><div style="float: right; width:100%;" dir="ltr">
    
      <br />
     <table id="blocks" cellpadding="0" cellspacing="0" class="blocks" dir="rtl" style="height: 500px"
    width="100%">
    <tr>
        <td class="title" align="right" dir="rtl"><center>
      الأخبار 
        </center></td>
    </tr>
    <tr>
        <td dir="rtl" style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px;
            padding-top: 10px; text-align: right">
            <br />
            
            
      <! --------------------------TO Here ------><table width="100%">
        <tr>
            <td>
                
                <asp:Literal ID="Literal2" runat="server" Text="اسم التصنيف" meta:resourcekey="Literal2Resource1"></asp:Literal>             
            </td>
            <td>
                <asp:DropDownList ID="DDLNewsCategory" runat="server" AutoPostBack="True" DataTextField="Cat_Arabic_Name"
                    DataValueField="Cat_ID" OnSelectedIndexChanged="DDLNewsCategory_SelectedIndexChanged" meta:resourcekey="DDLNewsCategoryResource1">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                    
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                            Width="100%" meta:resourcekey="GridView1Resource1">
                            <Columns>
                                <asp:TemplateField HeaderText="عنوان الخبر" meta:resourcekey="TemplateFieldResource1">
                                    <ItemTemplate>
                                        <asp:Literal ID="LITCoopArabicName" runat="server" Text='<%# Bind("News_Arabic_Title") %>'></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الإجراءات" meta:resourcekey="TemplateFieldResource2">
                                    <EditItemTemplate>
                                        &nbsp;
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:LinkButton ID="LBTNAdd" runat="server" OnClick="LBTNAdd_Click1" meta:resourcekey="LBTNAddResource1">إضافة</asp:LinkButton>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LBTNEdit" runat="server" OnClick="LBTNEdit_Click" meta:resourcekey="LBTNEditResource1">تعديل</asp:LinkButton>
                                        |
                                        <asp:LinkButton ID="LBTNDelete" runat="server" OnClick="LBTNDelete_Click1" meta:resourcekey="LBTNDeleteResource1" OnClientClick="return confirm('هل تريد الحذف ؟');">حذف</asp:LinkButton>&nbsp;
                                        |
                                        <asp:LinkButton ID="LBTNShowDetails" runat="server" OnClick="LBTNShowDetails_Click" meta:resourcekey="LBTNShowDetailsResource1">التفاصيل</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الظهور فى الصفحة الرئيسية">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CHBHighlight" runat="server" AutoPostBack="True" OnCheckedChanged="CHBHighlight_CheckedChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table width="100%">
                        <tr><td colspan="3"><center><b>بيانات الخبر</b></center></td></tr>
                                        <tr>
                                            <td style="width: 175px">
                                                <asp:Literal ID="LITCoopAraic" runat="server" Text="عنوان الخبر باللغة العربية" meta:resourcekey="LITCoopAraicResource1"></asp:Literal></td>
                                            <td colspan="2">
                                                <asp:TextBox ID="TXTNewsArabicTitle" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="SingleLine" Height="88px" />
                                                            
                                                <asp:RequiredFieldValidator ID="RFVManagerAraicName" runat="server" ControlToValidate="TXTNewsArabicTitle"
                                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV" meta:resourcekey="RFVManagerAraicNameResource1"></asp:RequiredFieldValidator></td>
                                        </tr>
                            <tr>
                                <td style="width: 175px">
                                    <asp:Literal ID="Literal6" runat="server" Text="عنوان الخبر باللغة الإنجليزية" meta:resourcekey="Literal6Resource1"></asp:Literal></td>
                                <td colspan="2">
                                    <asp:TextBox ID="TXTNewsEnglishTitle" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="SingleLine" Height="88px" />
                                                            
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TXTNewsEnglishTitle"
                                        Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV" meta:resourcekey="RequiredFieldValidator3Resource1"></asp:RequiredFieldValidator></td>
                            </tr>
                                        <tr>
                                            <td style="width: 175px">
                                                <asp:Literal ID="Literal3" runat="server" Text="محتوي الخبر باللغة العربية" meta:resourcekey="Literal3Resource1"></asp:Literal></td>
                                            <td colspan="2">
                                                <asp:TextBox ID="TXTNewsArabicContent" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" Height="140px" TextMode="multiLine" />
                                                            
                                                <asp:RequiredFieldValidator ID="RFVManagerEnglishName" runat="server" ControlToValidate="TXTNewsArabicContent"
                                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV" meta:resourcekey="RFVManagerEnglishNameResource1"></asp:RequiredFieldValidator></td>
                                        </tr>
                            <tr>
                                <td style="width: 175px">
                                    <asp:Literal ID="Literal7" runat="server" Text="محتوي الخبر باللغة الإنجليزية" meta:resourcekey="Literal7Resource1"></asp:Literal></td>
                                <td colspan="2">
                                    <asp:TextBox ID="TXTNewsEnglishContent" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" Height="140px" TextMode="multiLine" />
                                                            
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TXTNewsEnglishContent"
                                        Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV" meta:resourcekey="RequiredFieldValidator4Resource1"></asp:RequiredFieldValidator></td>
                            </tr>
                                        <tr>
                                            <td style="height: 15px; width: 175px;">
                                                <asp:Literal ID="Literal4" runat="server" Text="تاريخ الخبر" meta:resourcekey="Literal4Resource1"></asp:Literal></td>
                                            <td style="height: 15px" colspan="2">
                                                <asp:TextBox ID="TXTNewsDate" runat="server" Text='<%# Bind("Brochure_Date") %>' meta:resourcekey="TXTNewsDateResource1"></asp:TextBox><asp:ImageButton
                                                    ID="ImageButton2" runat="server" ImageUrl="~/Images/calendar_ico.png" meta:resourcekey="ImageButton2Resource1" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TXTNewsDate"
                                                    Display="Dynamic" ErrorMessage="yyyy/mm/dd" SetFocusOnError="True" ValidationExpression="(0[1-9]|[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|[1-9]|1[012])[- /.](19|20)[0-9]{2}"
                                                    ValidationGroup="ManagerGV" meta:resourcekey="RegularExpressionValidator1Resource1"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXTNewsDate"
                                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator><cc1:CalendarExtender id="Calendarextender3" runat="server" format="dd/MM/yyyy" popupbuttonid="ImageButton2"
                                                        targetcontrolid="TXTNewsDate" Enabled="True">
                                                    </cc1:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 175px">
                                                <asp:Literal ID="Literal5" runat="server" Text="تاريخ صلاحية الخبر" meta:resourcekey="Literal5Resource1"></asp:Literal></td>
                                            <td colspan="2">
                                                <asp:TextBox ID="TXTNewsValidToDate" runat="server" Text='<%# Bind("Brochure_Date") %>' meta:resourcekey="TXTNewsValidToDateResource1"></asp:TextBox><asp:ImageButton
                                                    ID="IBTNCalender" runat="server" ImageUrl="~/Images/calendar_ico.png" meta:resourcekey="IBTNCalenderResource1" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TXTNewsValidToDate"
                                                    Display="Dynamic" ErrorMessage="yyyy/mm/dd" SetFocusOnError="True" ValidationExpression="(0[1-9]|[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|[1-9]|1[012])[- /.](19|20)[0-9]{2}"
                                                    ValidationGroup="ManagerGV" meta:resourcekey="RegularExpressionValidator2Resource1"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TXTNewsValidToDate"
                                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator><cc1:CalendarExtender
                                                        id="CalendarExtender1" runat="server" format="dd/MM/yyyy" popupbuttonid="IBTNCalender"
                                                        targetcontrolid="TXTNewsValidToDate" Enabled="True">
                                </cc1:CalendarExtender></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="Literal23" runat="server" Text="ينشر" meta:resourcekey="Literal23Resource1"></asp:Literal></td>
                                            <td colspan="2">
                                                <asp:CheckBox ID="CHBIsPublished" runat="server" meta:resourcekey="CHBIsPublishedResource1" /></td>
                                        </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="Literal1" runat="server" meta:resourcekey="Literal23Resource1" Text="رفع صورة الخبر"></asp:Literal></td>
                                <td>
                                    <asp:FileUpload ID="FUNewsImage" runat="server" Width="441px" /></td>
                                <td>
                                    <asp:Button ID="FileDelete" runat="server" onclick="FileDel_Click" 
                                        Text="إلغاء الصورة" Visible="False" Width="96px" />
                                  
                                    <asp:Literal ID="LITFileName" runat="server" Visible="False"></asp:Literal></td>
                            </tr>
                                            <td colspan="3">
                                            <center>
                                                <asp:Button ID="BTNAdd" runat="server" OnClick="BTNAdd_Click" Text="إضافة" Visible="False" ValidationGroup="ManagerGV" meta:resourcekey="BTNAddResource2" />
                                                <asp:Button ID="BTNUpdate" runat="server" OnClick="BTNUpdate_Click" Text="تعديل"
                                                    Visible="False" ValidationGroup="ManagerGV" meta:resourcekey="BTNUpdateResource1" />
                                                <asp:Button ID="BTNCancel" runat="server" OnClick="BTNCancel_Click" Text="إلغاء"
                                                    Width="36px" meta:resourcekey="BTNCancelResource1" /></center></td>

                                        </tr>
                                        <tr>
                                            <td colspan="3" style="height: 15px">
                                                
                                            </td>
                                        </tr>
                                    </table>
                    </asp:View>
                    <asp:View ID="View3" runat="server">
                         <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                                        <ItemTemplate>
                                            <table width="100%" dir="rtl">
                                            <tr><td colspan="2"><center><b>بيانات الخبر التفصيلية</b></center></td></tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal7" runat="server" Text="عنوان الخبر باللغة العربية" meta:resourcekey="Literal7Resource2"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal8" runat="server" Text='<%# Bind("News_Arabic_Title") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal15" runat="server" Text="عنوان الخبر باللغة الإنجليزية" meta:resourcekey="Literal15Resource1"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal16" runat="server" Text='<%# Bind("News_English_Title") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal9" runat="server" Text="محتوي الخبر باللغة العربية" meta:resourcekey="Literal9Resource1"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal10" runat="server" Text='<%# Bind("News_Arabic_Content") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal17" runat="server" Text="محتوي الخبر باللغة الإنجليزية" meta:resourcekey="Literal17Resource1"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal18" runat="server" Text='<%# Bind("News_English_Content") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal11" runat="server" Text="تاريخ الخبر" meta:resourcekey="Literal11Resource1"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal12" runat="server" Text='<%# Bind("News_Date") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal13" runat="server" Text="تاريخ صلاحية الخبر" meta:resourcekey="Literal13Resource1"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal14" runat="server" Text='<%# Bind("News_ValidTo_Date") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal24" runat="server" Text="ينشر" meta:resourcekey="Literal24Resource1"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# Bind("IsPublish") %>' meta:resourcekey="CheckBox2Resource1"/>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <center>
                                        <asp:LinkButton ID="LBTNClose" runat="server" OnClick="LBTNClose_Click" meta:resourcekey="LBTNCloseResource1">Close</asp:LinkButton></center>
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