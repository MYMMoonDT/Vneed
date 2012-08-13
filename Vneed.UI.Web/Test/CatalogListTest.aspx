<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CatalogListTest.aspx.cs" Inherits="Vneed.UI.Web.Test.CatalogListTest" %>

<%@ Register src="../WebUserControl/CatalogList.ascx" tagname="CatalogList" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:CatalogList ID="CatalogList1" runat="server" />
    <div>
    
    </div>
    </form>
</body>
</html>
