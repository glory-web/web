<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Laws.ascx.cs" Inherits="WebUserControl" %>
    <table> 
     <tr><td colspan="3">
    <asp:Label ID="test" Text="test" runat="server"  Visible="false"/>
    <asp:Label ID="WLawDec" Text="WLawDec" runat="server"  Visible="false"/>
    <asp:Label ID="ALawDec" Text="ALawDec" runat="server" Visible="false"/>
    <asp:Label ID="LawDec" Text="LawDec" runat="server" Visible="false"/>
 
    </td>
    </tr>
    
    <tr style="width: 300px;"> 
    <td>
    <asp:Label ID="YearL" Text="Publication Year" runat="server" />
    <br />
    </td>
    <td  style="width:10px" ></td>
    <td>
    <asp:DropDownList id="DDLYear" runat="server" Width="249px" AutoPostBack="True">
    </asp:DropDownList>
    </td></tr>
    <tr style="width: 300px;">
    <td align="left">
    <asp:Label ID="DepL" Text="Department" runat="server" />
    </td>
    <td  style="width:10px" ></td>
    <td><asp:DropDownList id="DDLDepart" runat="server" Width="249px" AutoPostBack="True">
    </asp:DropDownList></td></tr>
    </table>
    <br />
<asp:MultiView ID="MultiView1" runat="server">
    

    <br/>
    <asp:View ID="View1" runat="server">
        <asp:GridView ID="laws_grid" runat="server" AutoGenerateColumns="False" ShowHeader="False">
            <Columns>
                <asp:TemplateField HeaderText="Laws">
                    <ItemTemplate>
                        <asp:LinkButton CssClass="HighLightsItems" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Text='<%# Bind("law_English_Name") %>'>LinkButton</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:View>
    <asp:View ID="View2" runat="server">

        <table class="front">
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label1" runat="server" Text="Law Name "></asp:Label>
               </td>
               <td class="bg2">
                    <asp:Label CssClass="Label_details" ID="Label_Laws_Name" runat="server"></asp:Label>
                </td>
            </tr>
           <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label2" runat="server" Text="Law Description"></asp:Label>
                </td>
                <td class="bg2">
                   <asp:Label ID="Label_Laws_Title" runat="server" ></asp:Label>
                </td>
            </tr>
           <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label4" runat="server" Text="Law Year"></asp:Label>
                </td>
                <td class="bg2">
                    <asp:Label ID="Label_Laws_date" runat="server"></asp:Label>
                </td>
            </tr>
            
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label6" runat="server" Text="Release Date "></asp:Label>
                </td>
                <td class="bg2">
                    <asp:Label ID="Label_Laws_date2" runat="server"></asp:Label>
                </td>
            </tr>
            
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label12" runat="server" Text="Egyptian Gazette Date"></asp:Label>
                </td>
                <td class="bg2"><asp:Label ID="Label_Laws_date3" runat="server"></asp:Label>
                </td>
            </tr>
            
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label16" runat="server" Text="Place"></asp:Label>
                </td>
                <td class="bg2">
                    <%--Maryam --%>
                  <%--  <asp:Label ID="Label_Laws_DAll" runat="server" Visible="false" Text="fsdfsd"></asp:Label>--%>
                    <%--Maryam --%>
                    <asp:Repeater ID="Repeater3" runat="server">
                    <ItemTemplate >
                          <%--<asp:HyperLink ID="HyperLink1" runat="server" Text ='<%# Bind("File_English_Name") %>' NavigateUrl='<%#string.Concat(FilePath(), Eval("File_English_Name")) %>'>HyperLink</asp:HyperLink></br>--%>
                          <asp:Label ID="Label_Laws_D" runat="server" Text ='<%# Bind("ORG_English_Name") %>' > </asp:Label></br>
                    </ItemTemplate>
                    </asp:Repeater>
                </td>
            </tr>                                 
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label18" runat="server" Text="Deleted by law no. " Visible="False"></asp:Label>
                </td>
                <td class="bg2">
                    <asp:Label ID="Label_Laws_Cancel" runat="server" Visible="false"></asp:Label>
             </td>
            </tr>
            
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label3" runat="server" Text="Files"></asp:Label>
               </td>
                   <td class="bg2">
                    <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate >
                          <%--<asp:HyperLink ID="HyperLink1" runat="server" Text ='<%# Bind("File_English_Name") %>' NavigateUrl='<%#string.Concat(FilePath(), Eval("File_English_Name")) %>'>HyperLink</asp:HyperLink></br>--%>
                          <asp:HyperLink ID="HyperLink1" runat="server" Text ='<%# Bind("File_Path") %>' NavigateUrl='<%#string.Concat(FilePath(), Eval("File_Path")) %>'>HyperLink</asp:HyperLink></br>                          
                    </ItemTemplate>
                    </asp:Repeater>
             </td>
            </tr>
            </table>
    </asp:View>
    
  
  
    
</asp:MultiView>
