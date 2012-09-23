<%@ Page Title="" Language="C#" MasterPageFile="~/Template/Template1.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Vneed.UI.Web.Page.index" %>
<%@ Register src="../WebUserControl/ShowAreaWebUserControl1.ascx" tagname="ShowAreaWebUserControl1" tagprefix="uc1" %>
<%@ Register src="../WebUserControl/RecommendedItemList.ascx" tagname="RecommendedItemList" tagprefix="uc2" %>
<%@ Register src="../WebUserControl/CatalogList.ascx" tagname="CatalogList" tagprefix="uc3" %>
<%@ Register src="../WebUserControl/BestsellerItemList.ascx" tagname="BestsellerItemList" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
        <script src="../Resource/JS/index.js" type="text/javascript"></script>
        <div>
            <uc1:ShowAreaWebUserControl1 ID="ShowAreaWebUserControl11" runat="server" />
        </div>
        <div id="dividerDiv"></div>
    	<div id="mainAreaDiv">
        	<div id="mainAreaContentDiv">
            	<div id="leftAreaDiv">
                	<div id="leftAreaTabsDiv">
                    	<div id="rankTab" class="tabItemSelected">
                        	<span>排行</span>
                        </div>
                        <div id="classTab" class="tabItem">
                        	<span>分类</span>
                        </div>
                    </div>
                    <div id="dividerDiv2"></div>
                    <div id="leftAreaContentDiv">
                        <div id="rankTabContent" style="display:block;">
                    		<%--<!--ProductItem-->
                            <div class="productItem1">
                              <div class="productPicItem1"></div>
                                <div class="productDisItem1">
                                	<span>索尼爱立信S5830s</span>
                                WCDMA/GSM LT18i 3G手机优惠</div>
                                <div class="productItemDivider1"></div>
                            </div>
                            <!--ProductItem-->
                            <div class="productItem1">
                              <div class="productPicItem1"></div>
                                <div class="productDisItem1">
                                	<span>索尼爱立信S5830s</span>
                                WCDMA/GSM LT18i 3G手机优惠</div>
                                <div class="productItemDivider1"></div>
                            </div>
                            <!--ProductItem-->
                            <div class="productItem1">
                              <div class="productPicItem1"></div>
                                <div class="productDisItem1">
                                	<span>索尼爱立信S5830s</span>
                                WCDMA/GSM LT18i 3G手机优惠</div>
                                <div class="productItemDivider1"></div>
                            </div>--%>
                            <uc4:BestsellerItemList ID="BestsellerItemList1" runat="server" />
                        </div>

                        <div id="classTabContent" style="display:none;">
                            <uc3:CatalogList ID="CatalogList1" runat="server" />
                        </div> 
                    </div>
                </div>
                <div id="rightAreaDiv">
                	<div id="dividerDiv3"></div>
                    <div id="rightAreaContentDiv">
                    	<div id="rightAreaItemContainer">                
                            <uc2:RecommendedItemList ID="RecommendedItemList1" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
