<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Legislation.ascx.cs" Inherits="UserControls_Legislation" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<link href="../../CSS_JAVA/main.css" rel="stylesheet" type="text/css" />

<script language="javascript" type="text/javascript">
    function openupload(CV)
    {
        var WinSettings = "left=150,top=150,width=530px,menubar=no,location=no,resizable=no,scrollbars=yes,status=no"
	    window.open("UserControls/UploadFiles.aspx?FileType="+CV, "Child", WinSettings);
	}
</script>
<! --------------------------From Here ------><div dir="ltr" style="float: right;
    width: 100%">
    <br />
    <table id="blocks" cellpadding="0" cellspacing="0" class="blocks" dir="rtl" style="height: 500px"
    width="100%">
        <tr>
            <td align="right" class="title" dir="rtl">
                <center>
                    القرارات</center>
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
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                                        Width="100%">
                                        <Columns>
                                            <asp:TemplateField HeaderText="اسم القرار">
                                                <ItemTemplate>
                                                    <asp:Literal ID="LITCoopArabicName" runat="server" Text='<%# Bind("Law_Arabic_Name") %>'></asp:Literal>
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
                                </asp:View>
                                <asp:View ID="View2" runat="server">
                                    <table width="100%">
                                                    <tr>
                                                        <td style="width: 175px; height: 22px;">
                                                            <asp:Literal ID="LITCoopAraic" runat="server" Text="اسم القرار باللغة العربية"></asp:Literal></td>
                                                        <td style="height: 22px" colspan="2">
                                                            <asp:TextBox ID="TXTLawArabicName" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="SingleLine" Height="88px" />
                                                            
                                                            <asp:RequiredFieldValidator ID="RFVManagerAraicName" runat="server" ControlToValidate="TXTLawArabicName"
                                                                Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 175px">
                                                            <asp:Literal ID="Literal3" runat="server" Text="اسم القرار باللغة الإنجليزية"></asp:Literal></td>
                                                        <td colspan="2">
                                                            <asp:TextBox ID="TXTLawEnglishName" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="SingleLine" Height="88px" />
                                                            
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXTLawEnglishName"
                                                                Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 15px; width: 175px;">
                                                            <asp:Literal ID="Literal4" runat="server" Text="ملخص القرار باللغة العربية"></asp:Literal></td>
                                                        <td style="height: 15px" colspan="2">
                                                            <asp:TextBox ID="TXTLawArabicContent" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Height="140px" Width="441px" TextMode="multiline" />
                                                            
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TXTLawArabicContent"
                                                                Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 175px">
                                                            <asp:Literal ID="Literal2" runat="server" Text="ملخص القرار باللغة الإنجليزية"></asp:Literal></td>
                                                        <td colspan="2">
                                                            <asp:TextBox ID="TXTLawEnglishContent" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Height="140px" Width="441px" TextMode="multiline" />
                                                            
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TXTLawEnglishContent"
                                                                Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 175px; height: 26px;">
                                                            <asp:Literal ID="Literal5" runat="server" Text="سنة إصدار القرار"></asp:Literal></td>
                                                        <td style="height: 26px" colspan="2">
                                                            <asp:TextBox ID="TXTLawVersionYear" runat="server" Text='<%# Bind("Brochure_Date") %>'></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TXTLawVersionYear"
                                                                Display="Dynamic" ErrorMessage="السنة غير صحيحة" SetFocusOnError="True" ValidationExpression="^\d+$"
                                                                ValidationGroup="ManagerGV"></asp:RegularExpressionValidator>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TXTLawVersionYear"
                                                                Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator>
                                                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TXTLawVersionYear"
                                                                Display="Dynamic" ErrorMessage="السنة غير صحيحة" MaximumValue="9999" MinimumValue="1572"
                                                                SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RangeValidator></td>
                                                    </tr>
                                        <tr>
                                            <td style="width: 175px; height: 26px">
                                                <asp:Literal ID="Literal8" runat="server" Text="تاريخ الاصدار"></asp:Literal></td>
                                            <td style="height: 26px" colspan="2">
                                                <asp:TextBox ID="TXTReleaseDate" runat="server" Text='<%# Bind("Brochure_Date") %>'></asp:TextBox><asp:ImageButton
                                                    ID="ImageButton2" runat="server" ImageUrl="~/Images/calendar_ico.png" /><asp:RegularExpressionValidator
                                                        ID="RegularExpressionValidator2" runat="server" ControlToValidate="TXTReleaseDate"
                                                        Display="Dynamic" ErrorMessage="yyyy/mm/dd" SetFocusOnError="True" ValidationExpression="(0[1-9]|[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|[1-9]|1[012])[- /.](19|20)[0-9]{2}"
                                                        ValidationGroup="ManagerGV"></asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                                            ID="RequiredFieldValidator6" runat="server" ControlToValidate="TXTReleaseDate"
                                                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator><cc1:CalendarExtender
                                                                ID="Calendarextender3" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton2"
                                                                TargetControlID="TXTReleaseDate">
                                                            </cc1:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 175px; height: 26px">
                                                <asp:Literal ID="Literal9" runat="server" Text="تاريخ النشر بالوقائع المصرية"></asp:Literal></td>
                                            <td style="height: 26px" colspan="2">
                                                <asp:TextBox ID="TXTPublishDate" runat="server" Text='<%# Bind("Brochure_Date") %>'></asp:TextBox><asp:ImageButton
                                                    ID="ImageButton1" runat="server" ImageUrl="~/Images/calendar_ico.png" /><asp:RegularExpressionValidator
                                                        ID="RegularExpressionValidator3" runat="server" ControlToValidate="TXTPublishDate"
                                                        Display="Dynamic" ErrorMessage="yyyy/mm/dd" SetFocusOnError="True" ValidationExpression="(0[1-9]|[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|[1-9]|1[012])[- /.](19|20)[0-9]{2}"
                                                        ValidationGroup="ManagerGV"></asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                                            ID="RequiredFieldValidator7" runat="server" ControlToValidate="TXTPublishDate"
                                                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator><cc1:CalendarExtender
                                                                ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton1"
                                                                TargetControlID="TXTPublishDate">
                                                            </cc1:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="Literal10" runat="server" Text="الجهة"></asp:Literal></td>
                                            <td colspan="2">
                                                &nbsp;&nbsp;<asp:ListBox ID="OrgList" runat="server" DataSourceID="SqlDataSource1"
                                                    DataTextField="ORG_Arabic_Name" DataValueField="ORG_ID" Height="200px" SelectionMode="Multiple"
                                                    Width="100%" AppendDataBoundItems="True">
                                                        <asp:ListItem Text="عام" Value="-1"></asp:ListItem>
                                                    </asp:ListBox><asp:SqlDataSource ID="SqlDataSource1" runat="server"
                                                        ConnectionString="<%$ ConnectionStrings:VSConnectionString %>" SelectCommand="SELECT [ORG_ID], [ORG_Arabic_Name] FROM [Organizations] WHERE ([Org_Type_ID] >= @Org_Type_ID)">
                                                        <SelectParameters>
                                                            <asp:Parameter DefaultValue="6" Name="Org_Type_ID" Type="Decimal" />
                                                        </SelectParameters>
                                                    </asp:SqlDataSource>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 175px; height: 26px">
                                                <asp:Literal ID="Literal1" runat="server" Text=" تم الغاء القانون"></asp:Literal></td>
                                            <td style="height: 26px" colspan="2">
                                                <asp:CheckBox ID="CHBWorkOrCanceled" runat="server" /></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 175px; height: 26px">
                                                <asp:Literal ID="Literal6" runat="server" Text="رقم قرار الإلغاء"></asp:Literal></td>
                                            <td style="height: 26px" colspan="2">
                                                <asp:TextBox ID="TXTCancelationNumber" runat="server" Text='<%# Bind("Brochure_Date") %>'
                                                    Width="441px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 175px; height: 26px">
                                                <asp:Literal ID="Literal7" runat="server" Text="رفع الملف"></asp:Literal></td>
                                            <td style="height: 26px">
                                                <asp:FileUpload ID="FULawFile" runat="server" Width="441px" /></td>
                                            <td style="height: 26px">
                                                <asp:Literal ID="LITFileName" runat="server" Visible="False"></asp:Literal>
                                                <asp:Button ID="FileDel" runat="server" Text="إلغاء الملف" Width="96px" 
                                                    onclick="FileDel_Click" Visible="False"/>
                                                
                                                </td>
                                        </tr>
                                                    <tr>
                                                        <td colspan="3">
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
                                                                    <asp:Literal ID="Literal7" runat="server" Text="اسم القرار باللغة العربية"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="Literal8" runat="server" Text='<%#Bind("Law_Arabic_Name") %>'></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="Literal9" runat="server" Text="اسم القرار باللغة الإنجليزية"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="Literal10" runat="server" Text='<%#Bind("Law_English_Name") %>'></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="Literal11" runat="server" Text="تفاصيل القرار باللغة العربية"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="Literal12" runat="server" Text='<%#Bind("Law_Arabic_Title") %>'></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="Literal13" runat="server" Text="تفاصيل القرار باللغة الإنجليزية"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="Literal14" runat="server" Text='<%#Bind("Law_English_Title") %>'></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="Literal15" runat="server" Text="سنة إصدار القرار"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="Literal16" runat="server" Text='<%#Bind("Law_Version_Year") %>'></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="Literal18" runat="server" Text="نوع القرار تم إلغاءة أو معمل به"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="Literal19" runat="server" Text='<%#Bind("Law_Type") %>'></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="Literal20" runat="server" Text="رقم قرار الإلغاء"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="Literal21" runat="server" Text='<%#Bind("Law_CancelationLawNumbe") %>'></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="Literal17" runat="server" Text="ملف القرار"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:Repeater ID="Repeater2" runat="server">
                                                                        <ItemTemplate>
                                                                            <a href='...\GovsFiles\ORG_<%#Eval("ORG_ID") %>_Files\Laws\<%#Eval("File_Path") %>'><asp:Image ID="Image1" runat="server" Width="100px" Height="100px" ImageUrl="~/Images/download.jpg" /></a>
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
                                <asp:View ID="View4" runat="server">
                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                                        Width="100%">
                                        <Columns>
                                            <asp:TemplateField HeaderText="الملف">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TXTFileName" runat="server" Text='<%# Bind("File_Name") %>'></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TXTFileName"
                                                        Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="FileVG"></asp:RequiredFieldValidator>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="TXTFileName" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TXTFileName"
                                                        Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="FileVG"></asp:RequiredFieldValidator>
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <asp:Literal ID="LITFileName" runat="server" Text='<%# Bind("File_Name") %>'></asp:Literal>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="رفع الملف">
                                                <EditItemTemplate>
                                                    <a href="#" onclick="javascript:openupload('Laws')">رفع الملف</a>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <a href="#" onclick="javascript:openupload('Laws')">رفع الملف</a>
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <asp:Literal ID="LITFilePath" runat="server" Text='<%# Bind("File_Path") %>'></asp:Literal>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="الإجراءات">
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="LBTNSava" runat="server" OnClick="LBTNSava_Click1" ValidationGroup="FileVG">حفظ</asp:LinkButton>
                                                    |
                                                    <asp:LinkButton ID="LBTNCancel" runat="server" OnClick="LBTNCancel_Click1">إلغاء</asp:LinkButton>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:LinkButton ID="LBTNAdd" runat="server" OnClick="LBTNAdd_Click1" ValidationGroup="FileVG">إضافة</asp:LinkButton>
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LBTNUpdate" runat="server" OnClick="LBTNUpdate_Click1">تعديل</asp:LinkButton>
                                                    |
                                                    <asp:LinkButton ID="LBTNDelete" runat="server" OnClick="LBTNDelete_Click1">حذف</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td style="height: 15px; text-align: center">
                                                        <strong>الملف</strong></td>
                                                    <td style="height: 15px; text-align: center">
                                                        <strong>رفع الملف</strong></td>
                                                    <td style="height: 15px; text-align: center">
                                                        <strong>اللإجراءات</strong></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="TXTFileName" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TXTFileName"
                                                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="FileVG"></asp:RequiredFieldValidator></td>
                                                    <td>
                                                        <a href="#" onclick="javascript:openupload('Laws')">رفع الملف</a></td>
                                                    <td>
                                                        <asp:LinkButton ID="LBTNAdd" runat="server" OnClick="LBTNAdd_Click1" ValidationGroup="FileVG">إضافة</asp:LinkButton></td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    <center>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LBTNClose_Click">Close</asp:LinkButton></center>
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