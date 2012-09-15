<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BestsellerListTestaspx.aspx.cs" Inherits="Vneed.UI.Web.Test.BestsellerListTestaspx" %>

<%@ Register src="../WebUserControl/BestsellerItemList.ascx" tagname="BestsellerItemList" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:BestsellerItemList ID="BestsellerItemList1" runat="server" />
    
    </div>
    </form>
</body>
</html>
