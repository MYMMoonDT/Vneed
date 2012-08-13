<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserTest.aspx.cs" Inherits="Vneed.UI.Web.Test.UserTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="TextBoxVerifyUsername" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonVerifyUsername" runat="server" 
            onclick="ButtonVerifyUsername_Click" Text="验证用户名" />
        <asp:Label ID="LabelVerifyUsername" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxVerifyEmail" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonVeryfyEmail" runat="server" 
            onclick="ButtonVeryfyEmail_Click" Text="验证邮箱" />
        <asp:Label ID="LabelVerifyEmail" runat="server" Text="Label"></asp:Label>
    
    </div>
    </form>
</body>
</html>
