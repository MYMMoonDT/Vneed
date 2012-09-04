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
        CheckOrderDetailRadio();
        $(".orderDetailRadioGroup1 input").click(function () {
            $(".orderDetailRadioGroup1 input").removeAttr("checked");
            $(this).attr("checked", "checked");
            CheckOrderDetailRadio();
        });
        $(".orderDetailRadioGroup2 input").click(function () {
            $(".orderDetailRadioGroup2 input").removeAttr("checked");
            $(this).attr("checked", "checked");
            CheckOrderDetailRadio();
        });
    });
    function CheckOrderDetailRadio() {
        var radioList1 = $(".orderDetailRadioGroup1");
        var radioList2 = $(".orderDetailRadioGroup2");
        for (var i = 0; i < radioList1.length; i++) {
            var input1 = $(radioList1[i]).children().get(0);
            var label1 = $(radioList1[i]).children().get(1);
            if ($(input1).attr("checked") == "checked") {
                $(label1).addClass("checked");
            } else {
                $(label1).removeClass("checked");
            }
        }
        for (var i = 0; i < radioList2.length; i++) {
            var input2 = $(radioList2[i]).children().get(0);
            var label2 = $(radioList2[i]).children().get(1);
            if ($(input2).attr("checked") == "checked") {
                $(label2).addClass("checked");
            } else {
                $(label2).removeClass("checked");
            }
        }
    }
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
                                <asp:TextBox ID="NameTextBox" runat="server" CssClass="text orderDetailContactTextBox"></asp:TextBox>
                                <asp:TextBox ID="SchoolTextBox" runat="server" CssClass="text orderDetailContactTextBox"></asp:TextBox>
                                <asp:TextBox ID="ContactTextBox" runat="server" CssClass="text orderDetailContactTextBox"></asp:TextBox>
                                <asp:TextBox ID="MajorTextBox" runat="server" CssClass="text orderDetailContactTextBox"></asp:TextBox>
                                <asp:TextBox ID="GradeTextBox" runat="server" CssClass="text orderDetailContactTextBox"></asp:TextBox>
                            </div>
                        </div>
                    </td>
                    <td class="orderDetailTableRightTD">
                        <div class="orderDetailDistributionDiv">
                            <div class="orderDetailDistributionTitle"><span>配送方式:</span></div>
                            <div>
                                <div><asp:RadioButton ID="RadioButton1" runat="server" GroupName="DistributionGroup" 
                                    Text="普通快递 6元" Checked="True" CssClass="orderDetailRadioGroup1" 
                                        ClientIDMode="Static" /></div>
                                <div>
                                    <asp:RadioButton ID="RadioButton2" runat="server" 
                                    GroupName="DistributionGroup" 
                                    Text="EMS 20元" CssClass="orderDetailRadioGroup1" ClientIDMode="Static"/></div>
                                <div>
                                    <asp:RadioButton ID="RadioButton3" runat="server" 
                                    GroupName="DistributionGroup" 
                                    Text="货物自提" CssClass="orderDetailRadioGroup1" ClientIDMode="Static"/></div>
                            </div>
                        </div>
                        <div class="orderDetailPaymentDiv">
                            <div class="orderDetailPaymentTitle"><span>付款方式:</span></div>
                            <div>
                                <div>
                                    <asp:RadioButton ID="RadioButton4" runat="server" 
                                    GroupName="PaymentGroup" 
                                    Text="线下支付" Checked="True" CssClass="orderDetailRadioGroup2" ClientIDMode="Static" /></div>
                                <div>
                                    <asp:RadioButton ID="RadioButton5" runat="server" 
                                    GroupName="PaymentGroup" 
                                    Text="银联在线" CssClass="orderDetailRadioGroup2" ClientIDMode="Static"/></div>
                                <div>
                                    <asp:RadioButton ID="RadioButton6" runat="server" 
                                    GroupName="PaymentGroup" 
                                    Text="支付宝" CssClass="orderDetailRadioGroup2" ClientIDMode="Static"/></div>
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
                            CssClass="button cartOptionButton orderDetailOptionButton" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
