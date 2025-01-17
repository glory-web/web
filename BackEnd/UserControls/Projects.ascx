<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Projects.ascx.cs" Inherits="UserControls_Projects" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<link href="../../CSS_JAVA/main.css" rel="stylesheet" type="text/css" />

<! --------------------------From Here ------><div style="float: right; width:100%;" dir="ltr">
   
      <br />
     <table id="blocks" cellpadding="0" cellspacing="0" class="blocks" dir="rtl" style="height: 500px"
    width="100%">
    <tr>
        <td class="title" align="right" dir="rtl"><center>
            المشروعات الخاصة بالهيئة</center></td>
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
                                <asp:TemplateField HeaderText="اسم المشروع">
                                    <ItemTemplate>
                                        <asp:Literal ID="LITCoopArabicName" runat="server" Text='<%# Bind("Project_Arabic_Name") %>'></asp:Literal>
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
                                        |
                                        <asp:LinkButton ID="LBTNFiles" runat="server" OnClick="LBTNFiles_Click">الملفات</asp:LinkButton>
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
                                            <td style="width: 175px">
                                                <asp:Literal ID="LITCoopAraic" runat="server" Text="اسم المشروع باللغة العربية"></asp:Literal></td>
                                            <td><asp:TextBox ID="TXTProjectArabicName" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="singleLine" Height="88px" />
                                                
                                                <asp:RequiredFieldValidator ID="RFVManagerAraicName" runat="server" ControlToValidate="TXTProjectArabicName"
                                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 175px">
                                                <asp:Literal ID="Literal3" runat="server" Text="اسم المشروع باللغة الإنجليزية"></asp:Literal></td>
                                            <td>
                                                <asp:TextBox ID="TXTProjectEnglishName" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="singleLine" Height="88px" />
                                                
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXTProjectEnglishName"
                                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 15px; width: 175px;">
                                                <asp:Literal ID="Literal4" runat="server" Text="تفاصيل المشروع باللغة العربية"></asp:Literal></td>
                                            <td style="height: 15px">
                                                <asp:TextBox ID="TXTProjectAraicContent" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" Height="140px" TextMode="MultiLine" />
                                                
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TXTProjectAraicContent"
                                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 175px">
                                                <asp:Literal ID="Literal2" runat="server" Text="تفاصيل المشروع باللغة الإنجليزية"></asp:Literal></td>
                                            <td>
                                                <asp:TextBox ID="TXTProjectEnglishContent" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" Height="140px" TextMode="MultiLine" />
                                                
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TXTProjectEnglishContent"
                                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 175px">
                                                <asp:Literal ID="Literal5" runat="server" Text="تاريخ بداية المشروع"></asp:Literal></td>
                                            <td>
                                                <asp:TextBox ID="TXTProjectStartDate" runat="server" Text='<%# Bind("Brochure_Date") %>'></asp:TextBox><asp:ImageButton
                                                    ID="IBTNStarDate" runat="server" ImageUrl="~/Images/calendar_ico.png" /><asp:RegularExpressionValidator
                                                        ID="RegularExpressionValidator1" runat="server" ControlToValidate="TXTProjectStartDate"
                                                        Display="Dynamic" ErrorMessage="yyyy/mm/dd" SetFocusOnError="True" ValidationExpression="(0[1-9]|[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|[1-9]|1[012])[- /.](19|20)[0-9]{2}"
                                                        ValidationGroup="ManagerGV"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TXTProjectStartDate"
                                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator><cc1:calendarextender
                                                        id="CalendarExtender1" runat="server" format="dd/MM/yyyy" popupbuttonid="IBTNStarDate"
                                                        targetcontrolid="TXTProjectStartDate">
                                </cc1:calendarextender></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="Literal6" runat="server" Text="تاريخ الإنتهاء من المشروع"></asp:Literal></td>
                                            <td>
                                                <asp:TextBox ID="TXTProjectEndDate" runat="server" Text='<%# Bind("Brochure_Date") %>'></asp:TextBox><asp:ImageButton
                                                    ID="IBTNEndDate" runat="server" ImageUrl="~/Images/calendar_ico.png" /><asp:RegularExpressionValidator
                                                        ID="RegularExpressionValidator2" runat="server" ControlToValidate="TXTProjectEndDate"
                                                        Display="Dynamic" ErrorMessage="yyyy/mm/dd" SetFocusOnError="True" ValidationExpression="(0[1-9]|[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|[1-9]|1[012])[- /.](19|20)[0-9]{2}"
                                                        ValidationGroup="ManagerGV"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TXTProjectEndDate"
                                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator><cc1:calendarextender
                                                        id="Calendarextender2" runat="server" format="dd/MM/yyyy" popupbuttonid="IBTNEndDate"
                                                        targetcontrolid="TXTProjectEndDate">
                                                    </cc1:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="Literal7" runat="server" Text="العنوان الإلكترونى للمشروع"></asp:Literal></td>
                                            <td>
                                                <asp:TextBox ID="TXTProjectURL" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="singleline" />
                                                
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TXTProjectURL"
                                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TXTProjectURL"
                                                    Display="Dynamic" ErrorMessage="اسم الموقع غير صحيح" SetFocusOnError="True" ValidationExpression="((https?|ftp|gopher|telnet|file|notes|ms-help):((//)|(\\\\))+[\w\d:#@%/;$()~_?\+-=\\\.&]*)"
                                                    ValidationGroup="ManagerGV"></asp:RegularExpressionValidator></td>
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
                                                        <asp:Literal ID="Literal7" runat="server" Text="اسم المشروع باللغة العربية"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal8" runat="server" Text='<%#Bind("Project_Arabic_Name") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal9" runat="server" Text="اسم المشروع باللغة الإنجليزية"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal10" runat="server" Text='<%#Bind("Project_English_Name") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal11" runat="server" Text="تفاصيل المشروع باللغة العربية"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal12" runat="server" Text='<%#Bind("Project_Arabic_Discreption") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal13" runat="server" Text="تفاصيل المشروع باللغة الإنجليزية"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal14" runat="server" Text='<%#Bind("Project_English_Discreption") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal15" runat="server" Text="تاريخ بدأ المشروع"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal16" runat="server" Text='<%#Bind("Project_Start_Date") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal19" runat="server" Text="تاريخ إنهاء المشروع"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal20" runat="server" Text='<%#Bind("Project_End_Date") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal18" runat="server" Text="العنوان الإلكتروني للمشروع"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal17" runat="server" Text='<%# Bind("Project_URL") %>'></asp:Literal>, 
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
                                <asp:TemplateField HeaderText="اسم الملف باللغة العربية">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TXTFileName" runat="server" Text='<%# Bind("File_Arabic_Name") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TXTFileName"
                                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="FilesVGEdit"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="TXTFileName" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TXTFileName"
                                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="FilesVG"></asp:RequiredFieldValidator>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Literal ID="LITFileName" runat="server" Text='<%# Bind("File_Arabic_Name") %>'></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="اسم الملف باللغة الإنجليزية">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TXTFileEnglishName" runat="server" Text='<%# Bind("File_English_Name") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7e" runat="server" ControlToValidate="TXTFileEnglishName"
                                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="FilesVGEdit"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="TXTFileEnglishName" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7ea" runat="server" ControlToValidate="TXTFileEnglishName"
                                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="FilesVG"></asp:RequiredFieldValidator>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Literal ID="LITFileEnglishName" runat="server" Text='<%# Bind("File_English_Name") %>'></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="رفع الملف">
                                    <EditItemTemplate>
                                        <asp:FileUpload ID="FUProjectFile" runat="server" />
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:FileUpload ID="FUProjectFile" runat="server" />
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Literal ID="LITFilePath" runat="server" Text='<%# Bind("File_Path") %>'></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الإجراءات">
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="LBTNSava" runat="server" OnClick="LBTNSava_Click1" ValidationGroup="FilesVGEdit">حفظ</asp:LinkButton>
                                        |
                                        <asp:LinkButton ID="LBTNCancel" runat="server" OnClick="LBTNCancel_Click1">إلغاء</asp:LinkButton>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:LinkButton ID="LBTNAdd" runat="server" OnClick="LBTNAdd_Click1" ValidationGroup="FilesVG">إضافة</asp:LinkButton>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LBTNUpdate" runat="server" OnClick="LBTNUpdate_Click1" ValidationGroup="FilesVGEdit">تعديل</asp:LinkButton>
                                        |
                                        <asp:LinkButton ID="LBTNDelete" runat="server" OnClick="LBTNDelete_Click1">حذف</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <table width="100%">
                                    <tr>
                                        <td style="height: 15px; text-align: center">
                                            <strong>اسم الملف باللغة العربية</strong></td>
                                        <td style="height: 15px; text-align: center">
                                            <strong>اسم الملف&nbsp; باللغة الإنجليزية</strong></td>
                                        <td style="height: 15px; text-align: center">
                                            <strong>رفع الملف</strong></td>
                                        <td style="height: 15px; text-align: center">
                                            <strong>اللإجراءات</strong></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TXTFileName" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TXTFileName"
                                                Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="FilesVG"></asp:RequiredFieldValidator></td>
                                        <td>
                                            <asp:TextBox ID="TXTFileEnglishName" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator8" runat="server" ControlToValidate="TXTFileEnglishName"
                                                Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="FilesVG"></asp:RequiredFieldValidator></td>
                                        <td>
                                            <asp:FileUpload ID="FUProjectFile" runat="server" /></td>
                                        <td>
                                            <asp:LinkButton ID="LBTNAdd" runat="server" OnClick="LBTNAdd_Click1" ValidationGroup="FilesVG">إضافة</asp:LinkButton></td>
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