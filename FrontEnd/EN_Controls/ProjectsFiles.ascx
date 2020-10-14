<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProjectsFiles.ascx.cs" Inherits="FrontEnd_AR_Controls_ProjectDownload" %>
<asp:Label ID="ProjectName" runat="server" Text="                " Font-Bold="True" Height="50px" ></asp:Label>&nbsp;<br />
  <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate >
                        <%--<asp:HyperLink ID="HyperLink1" runat="server" Text ='<%# Bind("File_English_Name")%>'  NavigateUrl='<%NavigateUrl='<%#string.Concat(FilePath() + Eval("Project_ID")+"//", Eval("File_Path"))%>'>HyperLink</asp:HyperLink>--%>
                        <asp:HyperLink ID="HyperLink1" runat="server" Text ='<%# Bind("File_English_Name")%>'  NavigateUrl='<%#string.Concat(FilePath() + Eval("Project_ID")+"//", Eval("File_Path")) %>'>HyperLink</asp:HyperLink>
                        <br />
                    </ItemTemplate>
                    </asp:Repeater>