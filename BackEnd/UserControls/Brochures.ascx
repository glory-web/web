<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Brochures.ascx.cs" Inherits="UserControls_Brochures" %>
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
      المنشورات
        </center></td>
    </tr>
    <tr>
       <td dir="rtl" style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px;
            padding-top: 10px; text-align: right">
            <br />
            
            
      <! --------------------------TO Here ------><table width="100%">
      <tr>
      <td>تصنيف النشرات</td>
      <td>
          <asp:DropDownList ID="DDLBrocureCategory" runat="server" DataTextField="Cat_Arabic_Name" DataValueField="Cat_ID" OnSelectedIndexChanged="DDLBrocureCategory_SelectedIndexChanged">
          </asp:DropDownList></td>
      </tr>
        <tr>
            <td colspan="2">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                            Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="اسم النشرة">
                                    <ItemTemplate>
                                        <asp:Literal ID="LITCoopArabicName" runat="server" Text='<%# Bind("Brochure_Arabic_Name") %>'></asp:Literal>
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
                                        <asp:LinkButton ID="LBTNDelete" runat="server" OnClick="LTNDalete_Click" OnClientClick="return confirm('هل تريد الحذف ؟');">حذف</asp:LinkButton>&nbsp;
                                        |
                                        <asp:LinkButton ID="LBTNShowDetails" runat="server" OnClick="LBTNShowDetails_Click">التفاصيل</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الظهور فى اصفحة الرئيسية">
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
                                                <asp:Literal ID="LITCoopAraic" runat="server" Text="اسم النشرة باللغة العربية"></asp:Literal></td>
                                            <td colspan="2">
                                                <asp:TextBox ID="TXTBrochureArabicName" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" Width="441px" TextMode="SingleLine" Height="88px" />
                                                
                                                <asp:RequiredFieldValidator ID="RFVManagerAraicName" runat="server" ControlToValidate="TXTBrochureArabicName"
                                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 175px">
                                                <asp:Literal ID="Literal3" runat="server" Text="اسم النشرة باللغة الإنجليزية"></asp:Literal></td>
                                            <td colspan="2">
                                                <asp:TextBox ID="TXTBrochureEnglishName" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" Width="441px" TextMode="SingleLine" Height="88px" />
                                                
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXTBrochureEnglishName"
                                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 175px">
                                                <asp:Literal ID="Literal6" runat="server" Text="تاريخ النشرة"></asp:Literal></td>
                                            <td colspan="2">
                                                <asp:TextBox ID="TXTBrochureDate" runat="server" Text='<%# Bind("Brochure_Date") %>'></asp:TextBox><asp:ImageButton
                                                    ID="IBTNStarDate" runat="server" ImageUrl="~/Images/calendar_ico.png" /><asp:RegularExpressionValidator
                                                        ID="RegularExpressionValidator1" runat="server" ControlToValidate="TXTBrochureDate"
                                                        Display="Dynamic" ErrorMessage="yyyy/mm/dd" SetFocusOnError="True" ValidationExpression="(0[1-9]|[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|[1-9]|1[012])[- /.](19|20)[0-9]{2}"
                                                        ValidationGroup="ManagerGV"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TXTBrochureDate"
                                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ManagerGV"></asp:RequiredFieldValidator><cc1:calendarextender
                                                        id="CalendarExtender1" runat="server" format="dd/MM/yyyy" popupbuttonid="IBTNStarDate"
                                                        targetcontrolid="TXTBrochureDate">
                                </cc1:calendarextender></td>
                                        </tr>
                            <tr>
                                <td style="width: 175px; height: 13px">
                                    <asp:Literal ID="Literal1" runat="server" Text="نوع النشرة"></asp:Literal></td>
                                <td style="height: 13px" colspan="2">
                                    <asp:DropDownList ID="DDLBrochureType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLBrochureType_SelectedIndexChanged">
                                        <asp:ListItem Value="true">مجانية</asp:ListItem>
                                        <asp:ListItem Value="false">بمقابل مادى</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr runat="server" id="CostRow" visible="false">
                                <td style="width: 175px; height: 15px">
                                    <asp:Literal ID="Literal2" runat="server" Text="السعر بالجنية"></asp:Literal></td>
                                <td style="height: 15px" colspan="2">
                                    <asp:TextBox ID="TXTCost" runat="server" ValidationGroup="ManagerGV" Width="441px"></asp:TextBox>
                                    </td>
                            </tr>
                            <tr>
                                <td style="width: 175px; height: 15px">
                                    <asp:Literal ID="Literal4" runat="server" Text="المصدر"></asp:Literal></td>
                                <td style="height: 15px" colspan="2">
                                    <asp:DropDownList ID="DDLSource" runat="server" DataTextField="ORG_Arabic_Name" DataValueField="ORG_ID">
                                    </asp:DropDownList></td>
                            </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="Literal8" runat="server" Text="رفع الملف"></asp:Literal></td>
                                            <td>
                                                <asp:FileUpload ID="FUBrochureFile" runat="server" Width="280px" /></td>
                                            <td>
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
                                                        <asp:Literal ID="Literal7" runat="server" Text="اسم النشرة باللغة العربية"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal8" runat="server" Text='<%#Bind("Brochure_Arabic_Name") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal9" runat="server" Text="اسم النشرة باللغة الإنجليزية"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal10" runat="server" Text='<%#Bind("Brochure_English_Name") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal11" runat="server" Text="تاريخ النشرة"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal12" runat="server" Text='<%#Bind("Brochure_Date") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal5" runat="server" Text="نوع النشرة"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal14" runat="server" Text='<%#Bind("Brochure_Type") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal15" runat="server" Text="التكلفة"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal16" runat="server" Text='<%#Bind("Brochure_Cost") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal17" runat="server" Text="مكان التواجد"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal18" runat="server" Text='<%#Bind("Brochure_Existance_Place") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal13" runat="server" Text="ملف النشرة"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Repeater ID="Repeater2" runat="server">
                                                            <ItemTemplate>
                                                                <a href='../GovsFiles/ORG_<%#Eval("ORG_ID") %>_Files/Brochures/<%#Eval("File_Path") %>'>
                                                                    <asp:Image ID="Image1" runat="server" Width="100px" Height="100px" ImageUrl="~/Images/download.jpg" /></a>
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