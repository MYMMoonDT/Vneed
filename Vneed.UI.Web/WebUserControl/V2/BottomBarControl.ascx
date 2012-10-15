<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BottomBarControl.ascx.cs" Inherits="Vneed.UI.Web.WebUserControl.V2.BottomBarControl" %>
<div id="bottomBarBg">
    <div id="bottomBarContainer">
        <div id="bottomBarContactInfo">
            <asp:HyperLink ID="AboutUsHyperLink" runat="server" NavigateUrl="~/Page/V2/Help/aboutUs.aspx">关于我们</asp:HyperLink>
            <asp:HyperLink ID="ContactUsHyperLink" runat="server" NavigateUrl="~/Page/V2/Help/contactUs.aspx">联系我们</asp:HyperLink>
            <%--<asp:HyperLink ID="ICPHyperLink" runat="server" NavigateUrl="http://www.miibeian.gov.cn" Target="_blank">沪ICP备12039679号</asp:HyperLink>--%>
        </div>
        <div id="bottomBarCompanyInfo">
            <asp:Label ID="CompanyInfoLabel" runat="server" 
                Text="&copy;2012. www.vneed.org. All Rights Reserved. <a href='http://www.miibeian.gov.cn' target='_blank'>沪ICP备12039679号</a><br/>Design by Vneed Group"></asp:Label>
        </div>
    </div>
</div>