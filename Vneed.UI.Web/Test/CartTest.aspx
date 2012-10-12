<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartTest.aspx.cs" Inherits="Vneed.UI.Web.Test.CartTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="添加货物1"></asp:Label>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
        +<br />
        添加货物2<asp:Button ID="Button2" runat="server" Text="Button" 
            onclick="Button2_Click" />
        数量<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        删除货物1<asp:Button ID="Button3" runat="server" Text="Button" 
            onclick="Button3_Click" />
        <br />
        当前购物车内容<br />
        <asp:Table ID="Table1" runat="server">
        </asp:Table>
    
        <asp:TextBox ID="TextBox2" runat="server" AutoPostBack="true" ontextchanged="TextBox2_TextChanged"></asp:TextBox>
    
    </div>
    </form>
</body>
</html>
