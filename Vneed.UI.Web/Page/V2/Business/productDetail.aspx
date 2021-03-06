﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Template/SubTitleTemplate.master" AutoEventWireup="true" CodeBehind="productDetail.aspx.cs" Inherits="Vneed.UI.Web.Page.V2.Business.productDetail" %>
<%@ Register src="../../../WebUserControl/V2/SimilarProductsControl.ascx" tagname="SimilarProductsControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head2" runat="server">
    <title>商品详情</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="subHeadLeft" runat="server">
    <div class="productDetailImageContainer">
        <asp:Image ID="productDetailImage" runat="server" />
    </div>
    <div class="productDetailTitleContainer">
        <asp:Label ID="productDetailTitleLabel" runat="server" Text="" CssClass="productDetailTitleFont"></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subHeadRight" runat="server">
    <div class="productDetailPriceContainer">
        <table>
            <tr>
                <td>
                    <div class="productDetailVneedPriceFont">
                        Vneed价：<asp:Label ID="ProductVneedPriceLabel" runat="server" Text=""></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                   <div class="productDetailOfficialPriceFont">
                        官方价：<asp:Label ID="ProductOfficialPriceLabel" runat="server" Text=""></asp:Label>
                    </div> 
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
   <div id="productDetailBg" class="contentBg">
    <div id="productDetailContainer" class="contentContainer">
        <table>
            <tr>
                <td class="productDetailMainContentContainer">
                    <div class="productDetailMainSubTitle">商品详情</div>
                    <div class="productDetailMainDescription">
                        <asp:Label ID="productDetailDescriptionLabel" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td class="productDetailSideContentContainer">
                    <div class="productDetailSideOptionContainer">
                        <table>
                            <tr>
                                <td>                     
                                    <div class="productDetailProductNumOptionContainer">
                                        <table>
                                            <tr>
                                                <td>
                                                    <div>我要买:&nbsp;</div>
                                                </td>
                                                <td>
                                                    <div class="productDetailMinusProductIcon"></div>
                                                </td>
                                                <td>
                                                    <div><asp:TextBox ID="productDetailProductNumTextBox" runat="server" CssClass="productDetailProductNumText" Text="1"></asp:TextBox></div>
                                                </td>
                                                <td>    
                                                    <div class="productDetailPlusProductIcon"></div>
                                                </td>
                                            </tr>
                                        </table>
                                   </div> 
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div id="productDetailProductProcessOptionContainer">
                                        <table>
                                        <tr>
                                        <td>
                                            <%--<asp:Button ID="ProductDetailBuyNowButton" runat="server" Text="立即购买" 
                                                CssClass="productDetailOptionBuyNowButton"/>--%>
                                            <input id="ProductDetailBuyNowButton" 
                                                type="button" 
                                                value="立即购买" 
                                                class="productDetailOptionBuyNowButton"/>
                                        </td>
                                        <td>
                                            <%--<asp:Button ID="ProductDetailAddCartButton" runat="server" Text="加入购物车" 
                                                CssClass="productDetailOptionAddCartButton"/>--%>
                                            <input id="ProductDetailAddCartButton" 
                                                type="button" 
                                                value="加入购物车" 
                                                class="productDetailOptionAddCartButton"/>
                                        </td>
                                        <td><asp:Button ID="ProductDetailCollectButton" runat="server" Text="收藏" CssClass="productDetailOptionCollectButton"/></td>
                                        </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    
                </td>
            </tr>
            </table>
    </div>
    <div class="productDetailDivider"></div>
   </div>
<script type="text/javascript">
    function ProductDetail() {
        this.Init();
    }
    ProductDetail.prototype.Init = function () {
        this.numSelector = new NumSelector();
        $("#ProductDetailBuyNowButton").click(function () {
            var productID = $.getUrlVar('product');
            var productNum = $("#ContentPlaceHolder1_ContentPlaceHolder2_productDetailProductNumTextBox").val();
            $.ajax({
                type: "post",
                url: "productDetail.aspx/ProductDetailBuyNowButton_Click",
                contentType: "application/json; charset=utf-8",
                data: "{ 'productID': '" + productID + "', 'productNum':'" + productNum + "'}",
                dataType: "json",
                success: function (data) {
                    if (data.d == false) {
                        $("#TopBarControl1_LoginVneedHyperLink").click();
                    } else {
                        window.location.href = "/Page/V2/Business/orderDetail.aspx";
                    }
                }
            });
        });
        $("#ProductDetailAddCartButton").click(function () {
            var productID = $.getUrlVar('product');
            var productNum = $("#ContentPlaceHolder1_ContentPlaceHolder2_productDetailProductNumTextBox").val();
            $.ajax({
                type: "post",
                url: "productDetail.aspx/ProductDetailAddCartButton_Click",
                contentType: "application/json; charset=utf-8",
                data: "{ 'productID': '" + productID + "', 'productNum':'" + productNum + "'}",
                dataType: "json",
                success: function (data) {
                    if (data.d == false) {
                        $("#TopBarControl1_LoginVneedHyperLink").click();
                    } else {
                        window.location.href = "/Page/V2/Business/cartDetail.aspx";
                    }
                }
            });
        });
    };
</script>
<script type="text/javascript">
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
        var ProductDetailInst = new ProductDetail();
    });
</script>
<script type="text/javascript">
    $(document).ready(function () {
        var ProductDetailInst = new ProductDetail();
    });
</script>
</asp:Content>