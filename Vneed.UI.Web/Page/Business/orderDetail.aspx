<%@ Page Title="" Language="C#" MasterPageFile="~/Template/Template3.master" AutoEventWireup="true" CodeBehind="orderDetail.aspx.cs" Inherits="Vneed.UI.Web.Page.Business.order" %>
<%@ Register src="../../WebUserControl/OrderProcessWebUserControl.ascx" tagname="OrderProcessWebUserControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server">
    <span>订单信息</span>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<script type="text/javascript">
    $(document).ready(function () {
        var orderDetailRadio = new OrderDetailRadio();
        var orderDetailText = new OrderDetailText();
    });
</script>
<script type="text/javascript">
    function OrderDetailText() {
        this.init();
    }
    OrderDetailText.prototype.init = function () {
        var orderDetailTextInfo = [{ id: "#NameTextBox", defaultStr: "姓名" },
                                   { id: "#SchoolTextBox", defaultStr: "学校" },
                                   { id: "#ContactTextBox", defaultStr: "联系方式" },
                                   { id: "#IDNumTextBox", defaultStr: "身份证号(用以报班使用)" },
                                   { id: "#EmailTextBox", defaultStr: "邮箱(选填)"}];
        for (var index = 0; index < orderDetailTextInfo.length; ++index) {
            (function () {
                var orderDetailTextBox = orderDetailTextInfo[index];
                $(orderDetailTextBox.id).blur(function () {
                    if ($(orderDetailTextBox.id).val() == "" || $(orderDetailTextBox.id).val() == orderDetailTextBox.defaultStr) {
                        $(orderDetailTextBox.id).val(orderDetailTextBox.defaultStr);
                        $(orderDetailTextBox.id).addClass("orderDetailContactDefault");
                    }
                }).focus(function () {
                    if ($(orderDetailTextBox.id).val() == orderDetailTextBox.defaultStr) {
                        $(orderDetailTextBox.id).val("");
                        $(orderDetailTextBox.id).removeClass("orderDetailContactDefault");
                    }
                });
            })();
        }
    };

    function OrderDetailRadio() {
        this.init();
    }
    OrderDetailRadio.prototype.init = function () {
        var orderRadio = this;
        orderRadio.check();
        $(".orderDetailRadioGroup2 input").click(function () {
            $(".orderDetailRadioGroup2 input").removeAttr("checked");
            $(this).attr("checked", "checked");
            if (this.id == "OfflinePayRadioButton") {
                $("#orderDetailOfflineLabel").show();
            } else {
                $("#orderDetailOfflineLabel").hide();
            }
            orderRadio.check();
        });
    };
    OrderDetailRadio.prototype.check = function () {
        var radioList2 = $(".orderDetailRadioGroup2");
        for (var i = 0; i < radioList2.length; i++) {
            var input2 = $(radioList2[i]).children().get(0);
            var label2 = $(radioList2[i]).children().get(1);
            if ($(input2).attr("checked") == "checked") {
                $(label2).addClass("checked");
            } else {
                $(label2).removeClass("checked");
            }
        }
    };
</script>
    <div class="contentWrapperDiv orderDetailContentWrapperDiv">
        <uc1:OrderProcessWebUserControl ID="OrderProcessWebUserControl1" runat="server" />
        <div class="orderDetailContentDiv">
            <table class="orderDetailTable" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="orderDetailTableLeftTD">
                        <div class="orderDetailContactDiv"> 
                            <div class="orderDetailContactTitle"><span>个人资料:</span></div>
                            <div>
                                <asp:TextBox ID="NameTextBox" runat="server" CssClass="text orderDetailContactTextBox orderDetailContactDefault" Text="姓名" ClientIDMode="Static"></asp:TextBox>
                                <asp:TextBox ID="SchoolTextBox" runat="server" CssClass="text orderDetailContactTextBox orderDetailContactDefault" Text="学校" ClientIDMode="Static"></asp:TextBox>
                                <asp:TextBox ID="ContactTextBox" runat="server" CssClass="text orderDetailContactTextBox orderDetailContactDefault" Text="联系方式" ClientIDMode="Static"></asp:TextBox>
                                <asp:TextBox ID="IDNumTextBox" runat="server" CssClass="text orderDetailContactTextBox orderDetailContactDefault" Text="身份证号(用以报班使用)" ClientIDMode="Static"></asp:TextBox>
                                <asp:TextBox ID="EmailTextBox" runat="server" CssClass="text orderDetailContactTextBox orderDetailContactDefault" Text="邮箱(选填)" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                    </td>
                    <td class="orderDetailTableRightTD">
                        <div class="orderDetailPaymentDiv">
                            <div class="orderDetailPaymentTitle"><span>付款方式:</span></div>
                            <div>
                                <div>
                                    <asp:RadioButton ID="OfflinePayRadioButton" runat="server" 
                                    GroupName="PaymentGroup" 
                                    Text="线下支付（请填写个人资料）" Checked="True" CssClass="orderDetailRadioGroup2" ClientIDMode="Static" /></div>
                                <div>
                                    <asp:RadioButton ID="RadioButton6" runat="server" 
                                    GroupName="PaymentGroup" 
                                    Text="支付宝付款" CssClass="orderDetailRadioGroup2" ClientIDMode="Static"/></div>
                            </div>
                            <div id="orderDetailOfflineLabel" class="orderDetailOfflineLabel">
                                <span>若您选择“线下支付”付款方式请填写个人资料后，我们的工作人员会通过电话与您取得联系。</span>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="cartContentDiv">
                <div class="cartContentTitleDiv"><span>商品清单:</span></div>
                 <table id="cartTable" cellpadding="0" cellspacing="0">
                    <tr class="cartTitleTR">
                        <th class="carTitleProductTH">商品</th>
                        <th class="carTitleOtherTH">数量</th>
                        <th class="carTitleOtherTH">Vneed价</th>
                        <th class="carTitleOtherTH">操作</th>
                    </tr>
                    <tr class="cartContentTR">
                        <td class="cartContentTD">
                            <div class="cartProductDiv">
                                <div class="cartProductImage">
                                    <asp:Image ID="cartProductImage" runat="server" ImageUrl="~/Image/ItemImage/default.jpg" />
                                </div>
                                <div class="cartProductTitle"><span>新东方高考英语考前点题走读个性化</span></div>
                            </div>
                        </td>
                        <td class="cartContentTD">1</td>
                        <td class="cartContentTD">$XXXX</td>
                        <td class="cartContentTD"></td>
                    </tr>
                    <tr class="cartContentTR">
                        <td class="cartContentTD">
                            <div class="cartProductDiv">
                                <div class="cartProductImage">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/ItemImage/default.jpg" />
                                </div>
                                <div class="cartProductTitle"><span>新东方高考英语考前点题走读个性化</span></div>
                            </div>
                        </td>
                        <td class="cartContentTD">1</td>
                        <td class="cartContentTD">$XXXX</td>
                        <td class="cartContentTD"></td>
                    </tr>
                    <tr class="cartContentTR">
                        <td class="cartContentTD">
                            <div class="cartProductDiv">
                                <div class="cartProductImage">
                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Image/ItemImage/default.jpg" />
                                </div>
                                <div class="cartProductTitle"><span>新东方高考英语考前点题走读个性化</span></div>
                            </div>
                        </td>
                        <td class="cartContentTD">1</td>
                        <td class="cartContentTD">$XXXX</td>
                        <td class="cartContentTD"></td>
                    </tr>
                </table>
                <div class="cartClearingDiv">
                    <div class="cartClearingPriceDiv">
                        <span>合计:&nbsp</span>
                        <span>$XXXX</span>
                    </div>
                    <div class="cartClearingOptionDiv">
                        <asp:Button ID="Button1" runat="server" Text="确认订单" 
                            CssClass="button orderDetailOptionButton" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
