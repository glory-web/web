<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OrganizationManagers.ascx.cs" Inherits="UserControls_OrganizationManagers" %>
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
            الرؤساء و الرؤساء السابقين</center></td>
    </tr>
    <tr>
        <td style="text-align:right;padding:10px" dir="rtl">
            <br />
            
            
      <! --------------------------TO Here ------><table width="100%">
        <tr>
            <td colspan="2">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                            Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="اسم الرئيس">
                                    <ItemTemplate>
                                        <asp:Literal ID="LITCoopArabicName" runat="server" Text='<%# Bind("Man_Arabic_Name") %>'></asp:Literal>
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
                            </Columns>
                        </asp:GridView>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table width="100%">
                                        <tr>
                                            <td style="width: 175px">
                                                <asp:Literal ID="LITCoopAraic" runat="server" Text="اسم الرئيس باللغة العربية"></asp:Literal></td>
                                            <td>
                                                <asp:TextBox ID="TXTManagerArabicName" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="singleLine" Height="88px" />
                                                
                                                <asp:RequiredFieldValidator ID="RFVManagerAraicName" runat="server" ControlToValidate="TXTManagerArabicName"
                                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 175px">
                                                <asp:Literal ID="Literal3" runat="server" Text="اسم الرئيس باللغة الإنجليزية"></asp:Literal></td>
                                            <td>
                                                <asp:TextBox ID="TXTManagerEnglishName" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="singleLine" Height="88px" />
                                                
                                                <asp:RequiredFieldValidator ID="RFVManagerEnglishName" runat="server" ControlToValidate="TXTManagerEnglishName"
                                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 15px; width: 175px;">
                                                <asp:Literal ID="Literal4" runat="server" Text="تاريخ الميلاد"></asp:Literal></td>
                                            <td style="height: 15px">
                                                <asp:TextBox ID="TXTManagerBirthDate" runat="server" Text='<%# Bind("Brochure_Date") %>'></asp:TextBox><asp:ImageButton
                                                    ID="ImageButton2" runat="server" ImageUrl="~/Images/calendar_ico.png" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TXTManagerBirthDate"
                                                    Display="Dynamic" ErrorMessage="yyyy/mm/dd" SetFocusOnError="True" ValidationExpression="(0[1-9]|[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|[1-9]|1[012])[- /.](19|20)[0-9]{2}"
                                                    ValidationGroup="ManagerGV"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXTManagerBirthDate"
                                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator><cc1:CalendarExtender id="Calendarextender3" runat="server" format="dd/MM/yyyy" popupbuttonid="ImageButton2"
                                                        targetcontrolid="TXTManagerBirthDate">
                                                    </cc1:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 175px">
                                                <asp:Literal ID="Literal5" runat="server" Text="تاريخ تولي المنصب"></asp:Literal></td>
                                            <td>
                                                <asp:TextBox ID="TXTManagerStartDate" runat="server" Text='<%# Bind("Brochure_Date") %>'></asp:TextBox><asp:ImageButton
                                                    ID="IBTNCalender" runat="server" ImageUrl="~/Images/calendar_ico.png" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TXTManagerStartDate"
                                                    Display="Dynamic" ErrorMessage="yyyy/mm/dd" SetFocusOnError="True" ValidationExpression="(0[1-9]|[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|[1-9]|1[012])[- /.](19|20)[0-9]{2}"
                                                    ValidationGroup="ManagerGV"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TXTManagerStartDate"
                                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator><cc1:CalendarExtender
                                                        id="CalendarExtender1" runat="server" format="dd/MM/yyyy" popupbuttonid="IBTNCalender"
                                                        targetcontrolid="TXTManagerStartDate">
                                </cc1:CalendarExtender></td>
                                        </tr>
                                        <tr >
                                            <td style="height: 20px">
                                                <asp:Literal ID="Literal23" runat="server" Text="سابق"></asp:Literal></td>
                                            <td style="height: 20px">
                                                &nbsp;&nbsp;
                                                <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="True" /></td>
                                        </tr>
                                        <tr id="LeaveDate" runat="server" visible="false">
                                            <td>
                                                <asp:Literal ID="Literal6" runat="server" Text="تاريخ ترك المنصب"></asp:Literal></td>
                                            <td>
                                                <cc1:CalendarExtender id="Calendarextender2" runat="server" format="dd/MM/yyyy" popupbuttonid="ImageButton1"
                                                        targetcontrolid="TXTManagerEndDate">
                                                    </cc1:CalendarExtender>
                                                <asp:TextBox ID="TXTManagerEndDate" runat="server" Text='<%# Bind("Brochure_Date") %>'></asp:TextBox><asp:ImageButton
                                                    ID="ImageButton1" runat="server" ImageUrl="~/Images/calendar_ico.png" /><asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TXTManagerEndDate"
                                                    Display="Dynamic" ErrorMessage="yyyy/mm/dd" SetFocusOnError="True" ValidationExpression="(0[1-9]|[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|[1-9]|1[012])[- /.](19|20)[0-9]{2}"
                                                    ValidationGroup="ManagerGV"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TXTManagerEndDate"
                                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 15px">
                                                <asp:Literal ID="Literal7" runat="server" Text="رقم التليفون الشخصي"></asp:Literal></td>
                                            <td style="height: 15px">
                                                <asp:TextBox ID="TXTManagerTelephone" runat="server" Width="441px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TXTManagerTelephone"
                                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator></td>
                                        </tr>
                            <tr>
                                <td style="height: 15px">
                                    <asp:Literal ID="Literal1" runat="server" Text="البريد الألكترونى"></asp:Literal></td>
                                <td style="height: 15px">
                                    <asp:TextBox ID="TXTEmail" runat="server" Width="441px"></asp:TextBox>
                                    </td>
                            </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="Literal21" runat="server" Text="السيرة الذاتية"></asp:Literal></td>
                                            <td>
                                                <asp:FileUpload ID="FileUpload1" runat="server" Width="441px" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="Literal22" runat="server" Text="الصورة"></asp:Literal></td>
                                            <td>
                                                <asp:FileUpload ID="FileUpload2" runat="server" Width="441px" /></td>
                                        </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="Literal2" runat="server" Text="كلمة الرئيس باللغة العربية"></asp:Literal></td>
                                <td>
                                    <asp:TextBox ID="TXTManArabicWord" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" Height="180px" TextMode="MultiLine" />
                                    
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 15px">
                                    <asp:Literal ID="Literal8" runat="server" Text="كلمة الرئيس باللغة الأنجليزية"></asp:Literal></td>
                                <td style="height: 15px">
                                    <asp:TextBox ID="TXTManEnglishWord" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" Height="180px" TextMode="MultiLine" />
                                    
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
                                        <tr>
                                            <td colspan="2">
                                                
                                            </td>
                                        </tr>
                                    </table>
                    </asp:View>
                    <asp:View ID="View3" runat="server">
                         <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                                        <ItemTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal7" runat="server" Text="اسم الرئيس باللغة العربية"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal8" runat="server" Text='<%#Bind("Man_Arabic_Name") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal9" runat="server" Text="اسم الرئيس باللغة الإنجليزية"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal10" runat="server" Text='<%#Bind("Man_English_Name") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal11" runat="server" Text="تاريخ ميلاد الرئيس"></asp:Literal>
                                                    </td>   
                                                    <td>
                                                        <asp:Literal ID="Literal12" runat="server" Text='<%#Bind("Man_Birth_Date") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal13" runat="server" Text="تاريخ تولى المنصب"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal14" runat="server" Text='<%#Bind("Man_Start_Date") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal15" runat="server" Text="تاريخ ترك المنصب"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal16" runat="server" Text='<%#Bind("Man_End_Date") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal2" runat="server" Text="التليفون"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal17" runat="server" Text='<%#Bind("Man_Telephone") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal24" runat="server" Text="سابق"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%#Bind("State") %>'/>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal19" runat="server" Text="السيرة الذاتية"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <a href="..\GovsFiles\ORG_<%#Eval("ORG_ID") %>_Files\Managers\CV\<%#Eval("Man_CV_Path") %>"><%#Eval("Man_CV_Path") %></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal18" runat="server" Text="الصورة"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Bind("Man_Photo_Path") %>' Width="150px" Height="150px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal20" runat="server" Text="كلمة الرئيس باللغة العربية"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal25" runat="server" Text='<%#Bind("Man_Arabic_Word") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal26" runat="server" Text="كلمة الرئيس باللغة الإنجليزية"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal27" runat="server" Text='<%#Bind("Man_English_Word") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <center>
                                        <asp:LinkButton ID="LBTNClose" runat="server" OnClick="LBTNClose_Click">Close</asp:LinkButton></center>
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