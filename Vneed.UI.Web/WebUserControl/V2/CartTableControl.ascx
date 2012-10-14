<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CartTableControl.ascx.cs" Inherits="Vneed.UI.Web.WebUserControl.V2.CartTableControl" %>
<%--<asp:UpdatePanel ID="CartTableUpdatePanel" runat="server">
<ContentTemplate>--%>
<div id="cartTableContainer">
    <asp:Table ID="CartTable" runat="server">
    </asp:Table>
    <asp:Panel ID="CartTableBottomPanel" runat="server">
    </asp:Panel>
    <%--<div id="cartTableBottomContainer">
        <div id="cartTableTotalPriceAndOptionContainer">
            <div id="cartTableTotalPriceContainer">
                总计：￥1000
            </div>
            <div id="cartTableOptionContainer">
                <asp:HyperLink ID="ContinueShoppingHyperLink" runat="server">继续购物&gt;</asp:HyperLink>
                <asp:Button ID="PayForProductInCartButton" runat="server" Text="结算" CssClass="cartTableButton"/>
            </div>
        </div>
    </div>--%>
</div>
<%--</ContentTemplate>
</asp:UpdatePanel>--%>
<script type="text/javascript">
    function CartTable() {
        this.Init();
    }
    CartTable.prototype.Init = function () {
        this.numSelector = new NumSelectorPostBack();
    };
</script>
<script type="text/javascript">
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
        var CartTableInst = new CartTable();
    });
</script>
<script type="text/javascript">
    $(document).ready(function () {
        var CartTableInst = new CartTable();
    });
</script>