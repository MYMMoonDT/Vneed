<%@ Page Title="" Language="C#" MasterPageFile="~/Template/HomeTemplate.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Vneed.UI.Web.Page.V2.index" %>

<%@ Register src="../../WebUserControl/V2/ProductImageShowControl.ascx" tagname="ProductImageShowControl" tagprefix="uc1" %>

<%@ Register src="../../WebUserControl/V2/CatalogListControl.ascx" tagname="CatalogListControl" tagprefix="uc2" %>

<%@ Register src="../../WebUserControl/V2/RecommendedItemListControl.ascx" tagname="RecommendedItemListControl" tagprefix="uc3" %>

<%@ Register src="../../WebUserControl/V2/BestSellerItemListControl.ascx" tagname="BestSellerItemListControl" tagprefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Vneed教育平台</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <uc1:ProductImageShowControl ID="ProductImageShowControl1" runat="server" />

    <div id="indexContentBg" class="contentBg">
        <div id="indexContentContainer" class="contentContainer">
            <div id="indexSideContentContainer">
                <div class="sideTabTitleContainer">
                    <div id="catalogTabTitle" class="tabItemSelected">分类</div>
                    <div id="rankTabTitle" class="tabItem">排行</div>
                </div>
                <div class="sideTabContentContainer">
                    <div id="catalogTabContent">
                        <uc2:CatalogListControl ID="CatalogListControl1" runat="server" />
                    </div>
                    <div id="rankTabContent">
                        <uc4:BestSellerItemListControl ID="BestSellerItemListControl1" runat="server" />
                    </div>
                </div>
            </div>
            <div id="indexMainContentContainer">
                <div class="indexMainContent">
                    <uc3:RecommendedItemListControl ID="RecommendedItemListControl1" runat="server" />
                </div>
            </div>
        </div>
    </div>
<script type="text/javascript">
    function Index() {
        var catalogTab = new Tab("#catalogTabTitle", "#catalogTabContent");
        var rankTab = new Tab("#rankTabTitle", "#rankTabContent");
        var tabList = [catalogTab, rankTab];
        this.sideTabControl = new TabControl({
            TabList: tabList,
            SelectCss: "tabItemSelected", 
            NormalCss: "tabItem"});
    }
</script>
<script type="text/javascript">
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
        var IndexInst = new Index();
    });
</script>
<script type="text/javascript">
    $(document).ready(function () {
        var IndexInst = new Index();
    });
</script>

</asp:Content>
