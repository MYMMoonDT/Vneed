<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BottomBarControl.ascx.cs" Inherits="Vneed.UI.Web.WebUserControl.V2.BottomBarControl" %>
<div id="bottomBarBg">
    <div id="bottomBarContainer">
        <div id="bottomBarContactInfo">
            <asp:HyperLink ID="AboutUsHyperLink" runat="server" NavigateUrl="#">关于我们</asp:HyperLink>
            <asp:HyperLink ID="ContactUsHyperLink" runat="server" NavigateUrl="#">联系我们</asp:HyperLink>
        </div>
        <div id="bottomBarCompanyInfo">
            <asp:Label ID="CompanyInfoLabel" runat="server" 
                Text="&copy; Copyright 2012. www.vneed.org. All Rights Reserved<br/>
                      Design by Vneed Group"></asp:Label>
        </div>
    </div>
</div>