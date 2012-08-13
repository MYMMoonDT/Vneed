<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommentBox.ascx.cs" Inherits="Vneed.UI.Web.WebUserControl.CommentBox" %>
<asp:Table ID="TableComment" runat="server">
</asp:Table>
<asp:Label ID="Label1" runat="server" Text="我要留言："></asp:Label>
<br />
<asp:TextBox ID="TextBoxComment" runat="server" Height="123px" 
    TextMode="MultiLine" Width="302px"></asp:TextBox>
<br />
<asp:Button ID="ButtonCommitComment" runat="server" Text="提交" 
    onclick="ButtonCommitComment_Click" />


