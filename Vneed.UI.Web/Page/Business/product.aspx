﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Template/Template1.Master" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="Vneed.UI.Web.Page.Business.product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Resource/JS/jquery-1.7.2.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var collectDialog = new CollectDialog();
            var cartDialog = new CartDialog();
            $("#CollectButton").click(function () {
                collectDialog.show();
            });
        });
    </script>
    <script type="text/javascript">

        function ProductNumValidation() {
            if ($("#ProductNumTextBox").val() == "") {
                alert("请输入商品数量");
                return false;
            }
            else {
                return true;
            }
        };

        function CartDialog() {
            this.init();
        }
        CartDialog.prototype.init = function () {
            
        };
        CartDialog.prototype.show = function () {
            $("#cartDialogDiv").modal({
                appendTo: 'form',
                opacity: 50,
                overlayCss: { backgroundColor: "#000" },
                closeHTML: '<a class="modalCloseImg" title="关闭"></a>'
            });
        };

        function CollectDialog() {
            this.init();
        }
        CollectDialog.prototype.show = function () {
            $("#collectDialogDiv").modal({
                appendTo: 'form',
                opacity: 50,
                overlayCss: { backgroundColor: "#000" },
                closeHTML: '<a class="modalCloseImg" title="关闭"></a>'
            });
        };
        CollectDialog.prototype.init = function () {
            $("#CollectTextBox").focus(function () {
                if ($("#CollectTextBox").val() == "收藏理由") {
                    $("#CollectTextBox").val("").removeClass("collectDialogFontTextBoxFont");
                }
            }).blur(function () {
                if ($("#CollectTextBox").val() == "") {
                    $("#CollectTextBox").val("收藏理由").addClass("collectDialogFontTextBoxFont");
                }
            });
            $("#shareRenRenRadio").click(function () {
                if ($("#shareRenRenRadio").hasClass("collectDialogOptionShareItemOn")) {
                    $("#shareRenRenRadio").removeClass("collectDialogOptionShareItemOn").addClass("collectDialogOptionShareItemOff");
                } else {
                    $("#shareRenRenRadio").removeClass("collectDialogOptionShareItemOff").addClass("collectDialogOptionShareItemOn");
                }
            });
            $("#shareWeiboRadio").click(function () {
                if ($("#shareWeiboRadio").hasClass("collectDialogOptionShareItemOn")) {
                    $("#shareWeiboRadio").removeClass("collectDialogOptionShareItemOn").addClass("collectDialogOptionShareItemOff");
                } else {
                    $("#shareWeiboRadio").removeClass("collectDialogOptionShareItemOff").addClass("collectDialogOptionShareItemOn");
                }
            });
        };
    </script>

    <div id="productTitleDiv">
    	<div id="productTitleContentDiv">
            <div id="productTitlePicDic">
                <asp:Image ID="productTitleImage" runat="server" CssClass="productTitlePic"/>
            </div>
            <div id="productTitleText1">
                <asp:Label ID="productTitleLabel" runat="server" Text="" CssClass="productTitleFont1"></asp:Label>
                <span class="productTitleFont2">培训班</span>
            </div>
            <div id="productTitlePrice">
                <div id="productVneedPriceDiv">             
                    <asp:Label ID="productVneedPriceLabel" runat="server" Text="" CssClass="productTitleFont3"></asp:Label>
                    <span class="productTitleFont3">Vneed价:</span>
                </div>
                <div id="productOfficialPriceDiv">
                    <asp:Label ID="productPriceLabel" runat="server" Text="" CssClass="productTitleFont4"></asp:Label>
                    <span class="productTitleFont4">官方价:</span>
                </div>
            </div>
        </div>
    </div>
    <div id="dividerDiv4"></div>
    <div id="productMainDiv">
        <div id="productMainContentDiv">
            <table>
                <tr>
                    <td id="productMainLeftContentDiv">
                        <div id="productLeftDiv1">
                            <span>商品详情</span>
                        </div>
                        <div class="productLeftText">
                            <asp:Label ID="productDescriptionLabel" runat="server" Text=""></asp:Label>
                        </div>
                    </td>
                    <td id="productMainRightContentDiv">
                        <!--collectDialogDiv-->
                        <div id="collectDialogDiv">
                            <div id="collectDialogTitleDiv">
                                <asp:Label ID="collectDialogTitleLabel" runat="server" Text="" CssClass="collectDialogTitleFont1"></asp:Label>
                                <span class="collectDialogTitleFont2">培训班</span>
                            </div>
                            <div id="collectDialogTextBoxDiv">
                                <asp:TextBox ID="CollectTextBox" runat="server" 
                                    CssClass="collectDialogTextBox text collectDialogFontTextBoxFont" ClientIDMode="Static" TextMode="MultiLine">收藏理由</asp:TextBox>
                            </div>
                            <div id="collectDialogOptionDiv">
                                <div class="collectDialogOptionShareItem">
                                    <img alt="" src="../../Resource/Image/pop_up/collection/pop-up_collection_logo_renren.png" class="collectDialogOptionShareItemImage1"/>
                                    <div id="shareRenRenRadio" class="collectDialogOptionShareItemImage2 collectDialogOptionShareItemOn"></div>
                                </div>

                                <div class="collectDialogOptionShareItem">
                                    <img alt="" src="../../Resource/Image/pop_up/collection/pop-up_collection_logo_weibo.png" class="collectDialogOptionShareItemImage1"/>
                                    <div id="shareWeiboRadio" class="collectDialogOptionShareItemImage2 collectDialogOptionShareItemOn"></div>
                                </div>
            
                                <div id="collectDialogOptionButtonDiv">
                                    <asp:Button ID="Button2" runat="server" Text="收藏&分享" CssClass="button collectDialogOptionButton"/>
                                    <asp:Button ID="Button1" runat="server" Text="仅收藏" CssClass="button collectDialogOptionButton"/>
                                </div>

                            </div>
                        </div>
                        <!--cartDialogDiv-->
                        <div id="cartDialogDiv">
                            <div id="cartDialogTitleDiv">
                                <asp:Label ID="cartDialogTitleLabel" runat="server" Text="" CssClass = "collectDialogTitleFont1"></asp:Label>
                                <span class="collectDialogTitleFont2">培训班</span>
                            </div>
                            <div id="cartDialogContentDiv">
                                <div class="cartDialogContentTitle">
                                    <span>购物车中还有:</span>
                                </div>
                                <div class="cartDialogProductContainer">
                                    <asp:Panel ID="CartDialogImgContainerPanel" runat="server" CssClass="cartDialogProductImgContainer">
                                    </asp:Panel>
                                    <asp:Panel ID="CartDialogProductBottomPanel" runat="server" CssClass="cartDialogProductBottom">            
                                        <asp:Panel ID="CartDialogProductBottomButtons" runat="server" CssClass="cartDialogProductBottomButtons">                  
                                        </asp:Panel>
                                    </asp:Panel>
                                    <asp:Panel ID="cartDialogPreButtonPanel" runat="server" CssClass="cartDialogPreButton"></asp:Panel>
                                    <asp:Panel ID="cartDialogNextButtonPanel" runat="server" CssClass="cartDialogNextButton"></asp:Panel>
                                </div>
                                <div class="cartDialogClearingPriceDiv">
                                    <span class="cartDialogClearingPriceFont1">总计:</span>
                                    <span class="cartDialogClearingPriceFont2">$XXXX</span>
                                    <asp:Button ID="Button3" runat="server" Text="去结算" CssClass="button cartDialogClearingButton"/>
                                </div>
                            </div>
                        </div>

                        <div id="productRightDiv1">
                            <div id="productRightDiv11">
                                <asp:Button ID="BuyButton" runat="server" Text="立即购买" 
                                    CssClass="button productButton1" ClientIDMode="Static" 
                                    OnClientClick="return ProductNumValidation();"
                                    onclick="BuyButton_Click"/>
                                <div style="float:left;width:10px;height:30px;"></div>
                                <asp:Button ID="AddCartButton" runat="server" Text="加入购物车" 
                                    CssClass="button productButton1" ClientIDMode="Static" 
                                    OnClientClick="return ProductNumValidation();" 
                                    onclick="AddCartButton_Click"/>
                                <div style="float:left;width:10px;height:30px;"></div>
                                <%--<asp:Button ID="CollectButton" runat="server" Text="收藏" 
                                    CssClass="productButton2" ClientIDMode="Static"/>--%>
                                <input id="CollectButton" type="button" value="收藏" class="productButton2"/>
                            </div>
                            <div id="productRightDiv12">
                                <span>我要买:</span>
                                <asp:TextBox ID="ProductNumTextBox" runat="server" CssClass="text productNumTextBox" 
                                    onkeyup="this.value=this.value.replace(/\D/g,'')"
                                    onafterpaste="this.value=this.value.replace(/\D/g,'')" ClientIDMode="Static"></asp:TextBox>
                                <span>件</span>
                            </div>
                        </div>

                        <div id="productRightDiv2">
                            <div id="productRightDiv21">
                    	        <span>同类型受欢迎商品</span>
                            </div>

                            <!--ProductItem-->
                            <div class="productItem3">
                   	          <div class="productItemPic3"></div>
                                <div class="productItemDis3"><span>索尼爱立信S5830s
                                        WCDMA/GSM LT18i 3G手机优惠</span></div>
                                <div class="productItemDividerRight3"></div>
                    	        <div class="productItemDivider3"></div>
                            </div>

                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div id="dividerDiv5"></div>
                        <div id="productCommentDiv1">
                            <span>评论</span>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>        
</asp:Content>
