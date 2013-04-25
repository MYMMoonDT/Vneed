<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CoverFlowManagement.aspx.cs" Inherits="Vneed.UI.Web.Admin.CoverFlowManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:Table ID="table" runat="server">
    </asp:Table>

    新项目：<br />
    图片：<asp:FileUpload ID="FileUploadImg" runat="server" />
&nbsp;链接：<asp:TextBox ID="TextBoxUrl" runat="server"></asp:TextBox>
    <asp:Button ID="ButtonAdd" runat="server" onclick="ButtonAdd_Click" Text="添加" />

</asp:Content>
