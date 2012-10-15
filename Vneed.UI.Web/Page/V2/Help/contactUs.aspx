<%@ Page Title="" Language="C#" MasterPageFile="~/Template/SubTitleTemplate.master" AutoEventWireup="true" CodeBehind="contactUs.aspx.cs" Inherits="Vneed.UI.Web.Page.V2.Help.contactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head2" runat="server">
    <title>联系我们</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="subHeadLeft" runat="server">
    <div class="subTitleFont">联系我们</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subHeadRight" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="contentBg">
        <div class="contentContainer contactUsContentContainer">
            <div class="contactUsMainContentContainer">
                商务合作：
                <br/>
                电子邮箱：hz@vneed.org
                <br/>
                售后服务：
                <br/>
                电子邮箱：kf@vneed.org
                <br/>
                <div class="contactUsCodeImageContainer">
                    <img src="../../../Resource/Image/icon/contact_code.png" alt="Vneed二维码"/>
                </div>
                <br/>
            </div>
        </div>
    </div>
</asp:Content>
