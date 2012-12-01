<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EasyLogin.aspx.cs" Inherits="Vneed.UI.Web.Test.EasyLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        用户名<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        密码<asp:TextBox ID="TextBox2"
            runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="登录至后台" onclick="Button1_Click" 
            style="height: 26px" />
    </div>
    </form>
</body>
</html>
