﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Template/SubTitleTemplate.master" AutoEventWireup="true" CodeBehind="registerSuccess.aspx.cs" Inherits="Vneed.UI.Web.Page.V2.Help.registerSuccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head2" runat="server">
    <title>注册</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="subHeadLeft" runat="server">
    <asp:Label ID="RegisterVneedLabel" runat="server" Text="注册新用户" CssClass="subTitleFont"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subHeadRight" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
3秒后跳转到主页,你也可以点击下面的按钮直接跳转到主页...
<%
    Response.AddHeader("refresh","3;url=/Page/V2/index.aspx");
%>
</asp:Content>