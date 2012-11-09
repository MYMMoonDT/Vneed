<%@ Page Title="" Language="C#" MasterPageFile="~/Template/SubTitleTemplate.master" AutoEventWireup="true" CodeBehind="handbook.aspx.cs" Inherits="Vneed.UI.Web.Page.V2.Help.handbook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head2" runat="server">
    <title>操作指南</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="subHeadLeft" runat="server">
    <div class="subTitleFont">操作指南</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subHeadRight" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="contentBg">
        <div class="contentContainer handbookContentContainer">
            <div class="handbookContentMainTitle">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;欢迎来到Vneed，通过校园力量，这里为您提供低于市场价格的新东方教育培训课程，请您选择自己的报名状态，按照提示操作。
            </div>
            <div class="handbookContentLink">
                <a href="#signed">已经自行报名</a>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <a href="#unsigned">尚未报名</a>
            </div>
            <div class="handbookSubTitle">
                课程优惠信息现在通过Vneed报名新东方所有课程，可以享受如下优惠！
            </div>
            <div class="handbookSubCotent">
                <table>
                    <tr>
                        <td>课程原价</td>
                        <td>享受优惠</td>
                    </tr>
                    <tr>
                        <td>500-1000元</td>
                        <td>100元</td>
                    </tr>
                    <tr>
                        <td>1000-2000元</td>
                        <td>200元</td>
                    </tr>
                    <tr>
                        <td>2000-3000元</td>
                        <td>300元</td>
                    </tr>
                    <tr>
                        <td>3000-5000元 </td>
                        <td>400元</td>
                    </tr>
                    <tr>
                        <td>5000元以上</td>
                        <td>500元</td>
                    </tr>
                </table>
            </div>
            <div class="handbookSubTitle">
                <a name="signed">已经报名新东方的同学只要提供自己的报名信息即可获得现金返还</a>
            </div>
            <div class="handbookSubCotent">
                <div>1. 注册/登录</div>
                <div>2. 将您报名的班号输入搜索框找到相应班级</div>
                <img src="../../../Resource/Image/handbook/handbook_1.png" alt=""/>
                <div class="handbookRemindInfo">*若搜索不到相应班级请将您的联系方式及班号发送至kf@vneed.org，我们的客服人员会在12小时内与您取得联系</div>
                <div>3. 点击“立即购买”</div>
                <img src="../../../Resource/Image/handbook/handbook_3.png" alt=""/>
                <div>4. 填入个人资料并勾选“是否已经报名该课程”</div>
                <img src="../../../Resource/Image/handbook/handbook_5.png" alt=""/>
                <div>5. 点击“确认订单”，我们客服人员会在12小时内与您联系返款</div>
                <img src="../../../Resource/Image/handbook/handbook_4.png" alt=""/>
            </div>
            <div class="handbookSubTitle">
                <a name="unsigned">尚未报名新东方的同学可以直接在Vneed以优惠后价格报名</a>
            </div>
            <div class="handbookSubCotent">
                <div>1. 注册/登录</div>
                <div>2. 通过搜索或下方分类筛选找到自己需要报名的课程</div>
                <img src="../../../Resource/Image/handbook/handbook_2.png" alt=""/>
                <div>3. 找到课程后点击“立即购买”</div>
                <img src="../../../Resource/Image/handbook/handbook_3.png" alt=""/>
                <div>4. 填入个人资料</div>
                <img src="../../../Resource/Image/handbook/handbook_5.png" alt=""/>
                <div>5. 点击“确认订单”，我们客服人员会在12小时内与您确认报名信息，在您拿到听课证后付款</div>
            </div>
            <%--<table>
                <tr>
                    <td>
                        <div class="handbookSubTitle">已经自行报名</div>
                        <div>已经报名新东方的同学只要提供自己<br/>的报名信息即可获得现金返还</div>
                        <div class="handbookStepTitle">1.注册/登录</div>
                        <div class="handbookStepTitle">2.将您报名的班号输入<br/>&nbsp;&nbsp;搜索框找到相应班级</div>
                        <img src="../../../Resource/Image/handbook/handbook_1.png" alt=""/>
                        <div>*若搜索不到相应班级请将您的联系方式及班号<br/>发送至kf@vneed.org，我们的客服人员会在<br/>12小时内与您取得联系</div>
                        <div class="handbookStepTitle">3.点击“立即购买”</div>
                        <img src="../../../Resource/Image/handbook/handbook_3.png" alt=""/>
                        <div class="handbookStepTitle">4.填入个人资料并勾选<br/>“是否已经报名该课程”</div>
                        <img src="../../../Resource/Image/handbook/handbook_5.png" alt=""/>
                        <div class="handbookStepTitle">5.点击“确认订单”，我们客服<br/>人员会在12小时内与您联系返款</div>
                        <img src="../../../Resource/Image/handbook/handbook_4.png" alt=""/>
                    </td>
                    <td>
                       <div class="handbookSubTitle">尚未报名</div> 
                       <div>尚未报名新东方的同学可以直接在Vneed以<br/>优惠后价格报名</div>
                       <div class="handbookStepTitle">1.注册/登录</div>
                       <div class="handbookStepTitle">2.通过搜索或下方分类筛选找到自己<br/>&nbsp;&nbsp;需要报名的课程</div>
                       <img src="../../../Resource/Image/handbook/handbook_2.png" alt=""/>
                       <div class="handbookStepTitle">3.找到课程后点击“立即购买”</div>
                       <img src="../../../Resource/Image/handbook/handbook_3.png" alt=""/>
                       <div class="handbookStepTitle">4.填入个人资料</div>
                       <img src="../../../Resource/Image/handbook/handbook_5.png" alt=""/>
                       <div class="handbookStepTitle">5.点击“确认订单”，我们<br/>客服人员会在12小时内与您确认<br/>报名信息，在您拿到听课证后付款</div>
                    </td>
                </tr>
            </table>--%>
        </div>
    </div>
</asp:Content>
