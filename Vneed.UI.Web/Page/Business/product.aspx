﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Template/Template1.Master" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="Vneed.UI.Web.Page.Business.product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Resource/JS/jquery-1.7.2.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#CollectButton").click(function () {
                $("#collectDialogDiv").modal({
                    appendTo: 'form',
                    opacity: 50,
                    overlayCss: { backgroundColor: "#000" },
                    closeHTML: '<a class="modalCloseImg" title="关闭"></a>'
                });
            });
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
        });
    </script>
    <div id="collectDialogDiv">
        <div id="collectDialogTitleDiv">
            <span class="collectDialogTitleFont1">新东方XXXXXXXXX</span>
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
    <div id="productTitleDiv">
    	<div id="productTitleContentDiv">
            <div id="productTitlePicDic"></div>
            <div id="productTitleText1">
                <span class="productTitleFont1">新东方XXXXXX</span>
                <span class="productTitleFont2">培训班</span>
            </div>
            <div id="productTitlePrice">
                <div id="productVneedPriceDiv"><span class="productTitleFont3">Vneed价：$XXXX</span></div>
                <div id="productOfficialPriceDiv"><span class="productTitleFont4">官方价：$XXXX</span></div>
            </div>
        </div>
    </div>
    <div id="dividerDiv4"></div>
    <div id="productMainDiv">
        <div id="productMainContentDiv">
            <div>
         	    <div id="productMainLeftContentDiv">
                <div id="productLeftDiv1">
                    <span>商品详情</span>
                </div>
                <div class="productLeftText">
                    <span>课次：36</span>
                </div>
                <div class="productLeftText">
                    <span>上课时间：2012/5/6至2012/3/5周二至周五9:00-11:00,20:00-21:00(4.30-5.4休息)</span>
                </div>
                <div class="productLeftText">
                    <span>上课地点：VIP黄浦南京东路中心4教(南京东路409号置地广场东16楼)</span>
                </div>
                <div class="productLeftText">
                    <span>报到时间：开课当天至VIP学习中心领教材 021-63513703(南京东路)</span>
                </div>
                <div class="productLeftText">
                    <span>备注：</span>
                </div>
                <div class="productLeftText">
                    <span>课程简介：听力、口语、阅读、写作、词汇共5科，每科6节课（每节课2小时）。</span>
                </div>
                <div class="productLeftText">
                    <span>教学目标：详细讲解托福考试考点，重点培养学生在听说读写方面的能力，讲解托福考试高频核心词汇，为托福强化班方法技巧的讲解做好充分的准备。</span>
                </div>
            </div>
                <div id="productMainRightContentDiv">
                <div id="productRightDiv1">
                	<div id="productRightDiv11">
                        <asp:Button ID="BuyButton" runat="server" Text="立即购买" CssClass="button productButton1"/>
                        <div style="width:30px;float:left;height:30px;"></div>
                        <%--<asp:Button ID="CollectButton" runat="server" Text="收藏" CssClass="button productButton1"/>--%>
                        <input id="CollectButton" type="button" value="收藏" class="button productButton1"/>
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

                   <!--ProductItem-->
                    <div class="productItem3">
                   	  <div class="productItemPic3"></div>
                        <div class="productItemDis3"><span>索尼爱立信S5830s
                                WCDMA/GSM LT18i 3G手机优惠</span></div>
                        <div class="productItemDividerRight3"></div>
                    	<div class="productItemDivider3"></div>
                   </div>

                </div>
            </div>
            </div>
            <div style="clear:both;"></div>
            <div id="dividerDiv5"></div>
            <div id="productCommentDiv1"><span>评论</span></div>
        </div>
    </div>        
</asp:Content>