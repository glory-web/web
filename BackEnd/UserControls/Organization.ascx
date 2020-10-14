<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Organization.ascx.cs" Inherits="UserControls_Organization" %>
<link href="../../CSS_JAVA/main.css" rel="stylesheet" type="text/css" />
<! --------------------------From Here ------><div style="float: right; width:100%;">
      <br />
     <table id="blocks" cellpadding="0" cellspacing="0" class="blocks" dir="rtl" style="height: 500px"
    width="100%">
    <tr>
        <td class="title" align="right" dir="rtl"><center>
      تسجيل و تعديل الجهات التابعة للهيئة&nbsp;</center></td>
    </tr>
    <tr>
        <td dir="rtl" style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px;
            padding-top: 10px; text-align: right">
            <br />
            
            
      <! --------------------------TO Here ------><table width="100%">
      <tr runat="server" id="GovarnRow" visible="false"><td>
                                    <asp:LinkButton ID="LBTNEdara" runat="server" OnClick="LBTNEdara_Click">إضافة إدارة</asp:LinkButton></td><td>
                                        &nbsp;<asp:LinkButton ID="LBTNUnit" runat="server" OnClick="LBTNUnit_Click">إضافة وحدة</asp:LinkButton></td><td>
                                        &nbsp;<asp:LinkButton ID="LBTNMagther" runat="server" OnClick="LBTNMagther_Click">إضافة مجازر</asp:LinkButton></td></tr>
      <tr><td colspan="3">
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <asp:GridView ID="org_grid" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                        Width="100%" OnRowDataBound="org_grid_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="اسم الجهة(اللغة ألعربية)">
                                <ItemTemplate>
                                    <asp:Literal ID="LIT_Arabic_Name" runat="server" Text='<%# Bind("ORG_Arabic_Name") %>'></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="اسم الجهة(اللغة الانجليزية)">
                                <ItemTemplate>
                                    <asp:Literal ID="LIT_English_Name" runat="server" Text='<%# Bind("ORG_English_Name") %>'></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الإجراءات">
                                <FooterTemplate>
                                    <asp:LinkButton ID="add_btn" runat="server" OnClick="add_btn_Click">اضافة</asp:LinkButton>
                                </FooterTemplate>
                                <ItemTemplate>
                                    &nbsp;<asp:LinkButton ID="Dlt_btn" runat="server" OnClick="Dlt_btn_Click" OnClientClick="return confirm('هل تريد الحذف ؟');">حذف</asp:LinkButton>
                                    |
                                    <asp:LinkButton ID="Update_btn" runat="server" OnClick="Edit_btn_Click">تعديل</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:Label ID="Label15" runat="server" Text="النوع" Width="91px"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="DDLOrganizationType" runat="server" DataTextField="Type_Arabic_Name"
                                    DataValueField="Org_Type_ID" TabIndex="1">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 137px; height: 36px;">
                                <asp:Label ID="Label6" runat="server" Text="الاسم (العربي)" Width="91px"></asp:Label></td>
                            <td style="width: 334px; height: 36px;">
                                    
                                <asp:TextBox ID="TXT_Arabic_Name" runat="server" TabIndex="2" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="SingleLine" Height="88px" />
                                
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXT_Arabic_Name"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ORGVG"></asp:RequiredFieldValidator>
                                 </td>                                 
                        </tr>
                        <tr>
                            <td style="width: 137px">
                                <asp:Label ID="Label5" runat="server" Text="الاسم (الانجليزية)" Width="91px"></asp:Label></td>
                            <td style="width: 334px">
                                <asp:TextBox ID="TXT_English_Name" runat="server" TabIndex="3" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="SingleLine" Height="88px" />
                                
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TXT_English_Name"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ORGVG"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 137px">
                                <asp:Label ID="Label1" runat="server" Text="تليفون" Width="91px"></asp:Label></td>
                            <td style="width: 334px">
                                <asp:TextBox ID="TXT_Phone" runat="server" Width="441px" TabIndex="4"></asp:TextBox>
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 137px">
                                <asp:Label ID="Label2" runat="server" Text="فاكس" Width="95px"></asp:Label></td>
                            <td style="width: 334px">
                                <asp:TextBox ID="TXT_Fax" runat="server" Width="441px" TabIndex="5"></asp:TextBox>
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 137px">
                                <asp:Label ID="Label3" runat="server" Text="العنوان (العربي)" Width="94px"></asp:Label></td>
                            <td style="width: 334px">
                                <asp:TextBox ID="TXT_Arabic_Address" runat="server" TabIndex="6" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="SingleLine" Height="88px" />
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; height: 18px">
                                <asp:Label ID="Label4" runat="server" Text="العنوان (الانجليزية)" Width="103px"></asp:Label></td>
                            <td style="width: 334px; height: 18px">
                                <asp:TextBox ID="TXT_English_Address" runat="server" TabIndex="7" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="SingleLine" Height="88px" />
                                
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; height: 18px">
                                <asp:Label ID="Label16" runat="server" Text="البريد الألكترونى" Width="103px"></asp:Label></td>
                            <td style="width: 334px; height: 18px">
                                <asp:TextBox ID="TXTEMail" runat="server" TabIndex="8" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="SingleLine"  /></td>
                        </tr>
                        <tr>
                            <td style="width: 137px; height: 18px">
                                <asp:Label ID="Label7" runat="server" Text="الاهداف (اللغة العربية)" Width="141px"></asp:Label></td>
                            <td style="width: 334px; height: 18px">
                                <asp:TextBox ID="TXT_Arabic_Goals" runat="server" TabIndex="9" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="MultiLine" Height="110px" />
                                
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; height: 18px">
                                <asp:Label ID="Label8" runat="server" Text="الاهداف (اللغة الانجليزية)" Width="158px"></asp:Label></td>
                            <td style="width: 334px; height: 18px">
                                
                                <asp:TextBox ID="TXT_English_Goals" runat="server" TabIndex="10" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="MultiLine" Height="110px" />
                                
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; height: 18px">
                                <asp:Label ID="Label9" runat="server" Text="الانجازات (اللغة العربية)" Width="157px"></asp:Label></td>
                            <td style="width: 334px; height: 18px">
                                <asp:TextBox ID="TXT_Arabic_Achivments" runat="server" TabIndex="11" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="MultiLine" Height="110px" />
                                
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; height: 18px">
                                <asp:Label ID="Label12" runat="server" Text="الانجازات (اللغة الانجليزية)" Width="172px"></asp:Label></td>
                            <td style="width: 334px; height: 18px">
                                
                                 <asp:TextBox ID="TXT_English_Achivments" runat="server" TabIndex="12" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="MultiLine" Height="110px" />
                                
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; height: 18px">
                                <asp:Label ID="Label10" runat="server" Text="التاريخ (اللغة العربية)" Width="141px"></asp:Label></td>
                            <td style="width: 334px; height: 18px">
                                 <asp:TextBox ID="TXT_Arabic_History" runat="server" TabIndex="13" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="MultiLine" Height="110px" />
                                
                                
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; height: 18px">
                                <asp:Label ID="Label13" runat="server" Text="التاريخ  (اللغة الانجليزية)" Width="158px"></asp:Label></td>
                            <td style="width: 334px; height: 18px">
                                
                                 <asp:TextBox ID="TXT_English_History" runat="server" TabIndex="14" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="MultiLine" Height="110px" />
                                
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; height: 18px">
                                <asp:Label ID="Label11" runat="server" Text="الأنشطة (اللغة العربية)" Width="141px"></asp:Label></td>
                            <td style="width: 334px; height: 18px">
                                
                                <asp:TextBox ID="TXT_Arabic_Activity" runat="server" TabIndex="15" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="MultiLine" Height="110px" />
                                
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; height: 18px">
                                <asp:Label ID="Label14" runat="server" Text="الأنشطة (اللغة الانجليزية)" Width="158px"></asp:Label></td>
                            <td style="width: 334px; height: 18px">
                                
                                 <asp:TextBox ID="TXT_English_Activity" runat="server" TabIndex="16" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="MultiLine" Height="110px" />
                                 
                                </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 29px"><center>
                                <asp:Button ID="Save" runat="server" OnClick="Save_Click1" Text="إضافة" Width="93px" ValidationGroup="ORGVG" TabIndex="17" />
                                <asp:Button ID="Cancel_Btn" runat="server" OnClick="Cancel_Click" Text="الغاء" Width="86px" TabIndex="18" /></center></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 29px">
                            </td>
                        </tr>
                    </table>
                </asp:View>
                &nbsp;
            </asp:MultiView>
          <br />
          <br />
          <br />
          <br />
          <br />
          <br />
          <table width="100%" runat="server" id="EdaraTable" visible="false" class="blocks">
          <tr>
        <td class="title" align="right" dir="rtl" colspan="2"><center>
      تسجيل و تعديل الأدارات التابعة للمديرية</center></td>
    </tr>
            
            <tr> 
                <td colspan="2">
          <asp:GridView ID="GVEdara" runat="server" AutoGenerateColumns="False" ShowFooter="True" Width="100%">
              <Columns>
                  <asp:TemplateField HeaderText="اسم الأدارة باللغة العربية">
                      <EditItemTemplate>
                          <asp:TextBox ID="TXT_Arabic_Name" runat="server" Text='<%# Bind("ORG_Arabic_Name") %>'></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXT_Arabic_Name"
                              Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="BookCatVGEdit"></asp:RequiredFieldValidator>
                      </EditItemTemplate>
                      <FooterTemplate>
                          <asp:TextBox ID="TXT_Arabic_Name" runat="server"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXT_Arabic_Name"
                              Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="BookCatVG"></asp:RequiredFieldValidator>
                      </FooterTemplate>
                      <ItemTemplate>
                          <asp:Literal ID="LIT_Arabic_Name" runat="server" Text='<%# Bind("ORG_Arabic_Name") %>'></asp:Literal>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="اسم الأدارة باللغة الإنجليزية">
                      <EditItemTemplate>
                          <asp:TextBox ID="TXT_English_Name" runat="server" Text='<%# Bind("Org_English_Name") %>'></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFVb" runat="server" ControlToValidate="TXT_English_Name"
                              Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="BookCatVGEdit"></asp:RequiredFieldValidator>
                      </EditItemTemplate>
                      <FooterTemplate>
                          <asp:TextBox ID="TXT_English_Name" runat="server"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFVb" runat="server" ControlToValidate="TXT_English_Name"
                              Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="BookCatVG"></asp:RequiredFieldValidator>
                      </FooterTemplate>
                      <ItemTemplate>
                          <asp:Literal ID="LIT_English_Name" runat="server" Text='<%# Bind("Org_English_Name") %>'></asp:Literal>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="الإجراءات">
                      <EditItemTemplate>
                          <asp:LinkButton ID="UpdateBtn" runat="server" OnClick="UpdateBtn_Click1" ValidationGroup="BookCatVGEdit">حفظ</asp:LinkButton>
                          |
                          <asp:LinkButton ID="CancelBtn" runat="server" OnClick="CancelBtn_Click1">إلغاء</asp:LinkButton>
                      </EditItemTemplate>
                      <FooterTemplate>
                          <asp:LinkButton ID="AddBtn" runat="server" OnClick="AddBtn_Click1" ValidationGroup="BookCatVG">إضافة</asp:LinkButton>
                      </FooterTemplate>
                      <ItemTemplate>
                          <asp:LinkButton ID="EditBtn" runat="server" OnClick="EditBtn_Click1">تعديل</asp:LinkButton>
                          |
                          <asp:LinkButton ID="DelBtn" runat="server" OnClick="DelBtn_Click1" OnClientClick="return confirm('Are you sure you want to delete?');">حذف</asp:LinkButton>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="ID" Visible="False">
                      <ItemTemplate>
                          <asp:Literal ID="LITOrgID" runat="server" Text='<%# Bind("ORG_ID") %>'></asp:Literal>
                      </ItemTemplate>
                  </asp:TemplateField>
              </Columns>
              <EmptyDataTemplate>
                  <table style="width: 402px">
                      <tr>
                          <td style="width: 130px; height: 26px; text-align: center">
                              <strong>اسم الأدارة باللغة العربية</strong></td>
                          <td style="width: 148px; height: 26px; text-align: center">
                              <strong>اسم الأدارة باللغة الإنجليزية</strong></td>
                          <td style="width: 148px; height: 26px; text-align: center">
                              <strong>الإجراءات</strong></td>
                      </tr>
                      <tr>
                          <td style="width: 130px; height: 26px">
                              <asp:TextBox ID="TXT_Arabic_Name" runat="server"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXT_English_Name"
                                  Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="BookCatVG"></asp:RequiredFieldValidator></td>
                          <td style="width: 148px; height: 26px">
                              <asp:TextBox ID="TXT_English_Name" runat="server"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFVb" runat="server" ControlToValidate="TXT_English_Name"
                                  Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="BookCatVG"></asp:RequiredFieldValidator></td>
                          <td style="width: 148px; height: 26px">
                              <asp:LinkButton ID="AddBtn" runat="server" OnClick="AddBtn_Click1" ValidationGroup="BookCatVG">إضافة</asp:LinkButton></td>
                      </tr>
                  </table>
              </EmptyDataTemplate>
          </asp:GridView>
          </td>
            </tr>
          </table>
          
          <table width="100%" runat="server" id="UnitsTable" visible="false" class="blocks">
          <tr>
        <td class="title" align="right" dir="rtl" colspan="2"><center>
      تسجيل و تعديل الأدارات التابعة للمديرية</center></td>
    </tr>
            <tr>
                <td style="height: 18px">
                    <asp:Label ID="Label17" runat="server" Text="اسم الأدارة" Width="158px"></asp:Label></td>
                <td style="height: 18px">
                    <asp:DropDownList ID="DDLEdarat" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLEdarat_SelectedIndexChanged">
                    </asp:DropDownList></td>
            </tr>
            <tr> 
                <td colspan="2">
                    <asp:GridView ID="GVUnits" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                      Visible="true" Width="100%">
                      <Columns>
                          <asp:TemplateField HeaderText="اسم الوحدة باللغة العربية">
                              <EditItemTemplate>
                                  <asp:TextBox ID="TXT_Arabic_Name" runat="server" Text='<%# Bind("ORG_Arabic_Name") %>'></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXT_Arabic_Name"
                                      Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="BookCatVGEdit"></asp:RequiredFieldValidator>
                              </EditItemTemplate>
                              <FooterTemplate>
                                  <asp:TextBox ID="TXT_Arabic_Name" runat="server"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXT_Arabic_Name"
                                      Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="BookCatVG"></asp:RequiredFieldValidator>
                              </FooterTemplate>
                              <ItemTemplate>
                                  <asp:Literal ID="LIT_Arabic_Name" runat="server" Text='<%# Bind("ORG_Arabic_Name") %>'></asp:Literal>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="اسم الوحدة باللغة الإنجليزية">
                              <EditItemTemplate>
                                  <asp:TextBox ID="TXT_English_Name" runat="server" Text='<%# Bind("Org_English_Name") %>'></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFVb" runat="server" ControlToValidate="TXT_English_Name"
                                      Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="BookCatVGEdit"></asp:RequiredFieldValidator>
                              </EditItemTemplate>
                              <FooterTemplate>
                                  <asp:TextBox ID="TXT_English_Name" runat="server"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFVb" runat="server" ControlToValidate="TXT_English_Name"
                                      Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="BookCatVG"></asp:RequiredFieldValidator>
                              </FooterTemplate>
                              <ItemTemplate>
                                  <asp:Literal ID="LIT_English_Name" runat="server" Text='<%# Bind("Org_English_Name") %>'></asp:Literal>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="الإجراءات">
                              <AlternatingItemTemplate>
                                  <asp:LinkButton ID="EditBtn" runat="server" OnClick="EditBtn_Click">تعديل</asp:LinkButton>
                                  |
                                  <asp:LinkButton ID="DelBtn" runat="server" OnClick="DelBtn_Click" OnClientClick="return confirm('هل تريد الحذف؟');">حذف</asp:LinkButton>
                              </AlternatingItemTemplate>
                              <EditItemTemplate>
                                  <asp:LinkButton ID="UpdateBtn" runat="server" OnClick="UpdateBtn_Click" ValidationGroup="BookCatVGEdit">حفظ</asp:LinkButton>
                                  |
                                  <asp:LinkButton ID="CancelBtn" runat="server" OnClick="CancelBtn_Click">إلغاء</asp:LinkButton>
                              </EditItemTemplate>
                              <FooterTemplate>
                                  <asp:LinkButton ID="AddBtn" runat="server" OnClick="AddBtn_Click" ValidationGroup="BookCatVG">إضافة</asp:LinkButton>
                              </FooterTemplate>
                              <ItemTemplate>
                                  <asp:LinkButton ID="EditBtn" runat="server" OnClick="EditBtn_Click">تعديل</asp:LinkButton>
                                  |
                                  <asp:LinkButton ID="DelBtn" runat="server" OnClick="DelBtn_Click" OnClientClick="return confirm('Are you sure you want to delete?');">حذف</asp:LinkButton>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="ID" Visible="False">
                              <ItemTemplate>
                                  <asp:Literal ID="LITOrgID" runat="server" Text='<%# Bind("ORG_ID") %>'></asp:Literal>
                              </ItemTemplate>
                          </asp:TemplateField>
                      </Columns>
                      <EmptyDataTemplate>
                          <table style="width: 402px">
                              <tr>
                                  <td style="width: 130px; height: 26px; text-align: center">
                                      <strong>اسم الوحدة باللغة العربية</strong></td>
                                  <td style="width: 148px; height: 26px; text-align: center">
                                      <strong>اسم الوحدة باللغة الإنجليزية</strong></td>
                                  <td style="width: 148px; height: 26px; text-align: center">
                                      <strong>الإجراءات</strong></td>
                              </tr>
                              <tr>
                                  <td style="width: 130px; height: 26px">
                                      <asp:TextBox ID="TXT_Arabic_Name" runat="server"></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXT_English_Name"
                                          Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="BookCatVG"></asp:RequiredFieldValidator></td>
                                  <td style="width: 148px; height: 26px">
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
          
          <table width="100%" runat="server" id="MagtherTable" visible="false" class="blocks">
          <tr>
        <td class="title" align="right" dir="rtl" colspan="2"><center>
      تسجيل و تعديل المجازر التابعة للمديرية</center></td>
    </tr>
            <tr>
                <td style="height: 18px">
                    <asp:Label ID="Label18" runat="server" Text="اسم الأدارة" Width="158px"></asp:Label></td>
                <td style="height: 18px">
                    <asp:DropDownList ID="DDLEdarat2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLEdarat2_SelectedIndexChanged">
                    </asp:DropDownList></td>
            </tr>
            <tr> 
                <td colspan="2">
                    <asp:GridView ID="GVMagther" runat="server" AutoGenerateColumns="False" ShowFooter="True"
              Visible="true" Width="100%">
              <Columns>
                  <asp:TemplateField HeaderText="اسم المجزر  باللغة العربية">
                      <EditItemTemplate>
                          <asp:TextBox ID="TXT_Arabic_Name" runat="server" Text='<%# Bind("ORG_Arabic_Name") %>'></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXT_Arabic_Name"
                              Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="BookCatVGEdit"></asp:RequiredFieldValidator>
                      </EditItemTemplate>
                      <FooterTemplate>
                          <asp:TextBox ID="TXT_Arabic_Name" runat="server"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXT_Arabic_Name"
                              Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="BookCatVG"></asp:RequiredFieldValidator>
                      </FooterTemplate>
                      <ItemTemplate>
                          <asp:Literal ID="LIT_Arabic_Name" runat="server" Text='<%# Bind("ORG_Arabic_Name") %>'></asp:Literal>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="اسم المجزر  باللغة الإنجليزية">
                      <EditItemTemplate>
                          <asp:TextBox ID="TXT_English_Name" runat="server" Text='<%# Bind("Org_English_Name") %>'></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFVb" runat="server" ControlToValidate="TXT_English_Name"
                              Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="BookCatVGEdit"></asp:RequiredFieldValidator>
                      </EditItemTemplate>
                      <FooterTemplate>
                          <asp:TextBox ID="TXT_English_Name" runat="server"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFVb" runat="server" ControlToValidate="TXT_English_Name"
                              Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="BookCatVG"></asp:RequiredFieldValidator>
                      </FooterTemplate>
                      <ItemTemplate>
                          <asp:Literal ID="LIT_English_Name" runat="server" Text='<%# Bind("Org_English_Name") %>'></asp:Literal>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="الإجراءات">
                      <EditItemTemplate>
                          <asp:LinkButton ID="UpdateBtn" runat="server" OnClick="UpdateBtn_Click2" ValidationGroup="BookCatVGEdit">حفظ</asp:LinkButton>
                          |
                          <asp:LinkButton ID="CancelBtn" runat="server" OnClick="CancelBtn_Click2">إلغاء</asp:LinkButton>
                      </EditItemTemplate>
                      <FooterTemplate>
                          <asp:LinkButton ID="AddBtn" runat="server" OnClick="AddBtn_Click2" ValidationGroup="BookCatVG">إضافة</asp:LinkButton>
                      </FooterTemplate>
                      <ItemTemplate>
                          <asp:LinkButton ID="EditBtn" runat="server" OnClick="EditBtn_Click2">تعديل</asp:LinkButton>
                          |
                          <asp:LinkButton ID="DelBtn" runat="server" OnClick="DelBtn_Click2" OnClientClick="return confirm('Are you sure you want to delete?');">حذف</asp:LinkButton>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="ID" Visible="False">
                      <ItemTemplate>
                          <asp:Literal ID="LITOrgID" runat="server" Text='<%# Bind("ORG_ID") %>'></asp:Literal>
                      </ItemTemplate>
                  </asp:TemplateField>
              </Columns>
              <EmptyDataTemplate>
                  <table style="width: 402px">
                      <tr>
                          <td style="width: 130px; height: 26px; text-align: center">
                              <strong>اسم المجزر باللغة العربية</strong></td>
                          <td style="width: 148px; height: 26px; text-align: center">
                              <strong>اسم المجزر باللغة الإنجليزية</strong></td>
                          <td style="width: 148px; height: 26px; text-align: center">
                              <strong>الإجراءات</strong></td>
                      </tr>
                      <tr>
                          <td style="width: 130px; height: 26px">
                              <asp:TextBox ID="TXT_Arabic_Name" runat="server"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXT_English_Name"
                                  Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="BookCatVG"></asp:RequiredFieldValidator></td>
                          <td style="width: 148px; height: 26px">
                              <asp:TextBox ID="TXT_English_Name" runat="server"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFVb" runat="server" ControlToValidate="TXT_English_Name"
                                  Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="BookCatVG"></asp:RequiredFieldValidator></td>
                          <td style="width: 148px; height: 26px">
                              <asp:LinkButton ID="AddBtn" runat="server" OnClick="AddBtn_Click2" ValidationGroup="BookCatVG">إضافة</asp:LinkButton></td>
                      </tr>
                  </table>
              </EmptyDataTemplate>
          </asp:GridView>
                </td>
            </tr>
          </table>
          
      </td></tr>
      </table>
            <! --------------------------From Here ------></td>
    </tr>
    <tr>
        <td>
            </td>
    </tr>
</table>
  
</div>