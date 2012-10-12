<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ModifyItem.aspx.cs" Inherits="Vneed.UI.Web.Admin.ModifyItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:Label ID="LabelTitle" runat="server" Text="商品名称"></asp:Label>
    <asp:TextBox ID="TextBoxTitle" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="LabelDescription" runat="server" Text="商品描述"></asp:Label>
    <br />
    <CKEditor:CKEditorControl ID="TextBoxDescription" runat="server" Height="200">
	</CKEditor:CKEditorControl>
    <br />
    <asp:Label ID="LabelPrice" runat="server" Text="售价"></asp:Label>
    <asp:TextBox ID="TextBoxPrice" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="LabelOriginalPrice" runat="server" Text="原价"></asp:Label>
    <asp:TextBox ID="TextBoxOriginalPrice" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="LabelCatalog" runat="server" Text="所属分类"></asp:Label>
    <asp:DropDownList ID="DropDownListCatalog" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownListCatalog_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    属性1：<asp:DropDownList ID="DropDownListAttr1" runat="server">
    </asp:DropDownList>
    属性2：<asp:DropDownList ID="DropDownListAttr2" runat="server">
    </asp:DropDownList>
    属性3：<asp:DropDownList ID="DropDownListAttr3" runat="server">
    </asp:DropDownList>
    <br />
    <asp:Label ID="LabelImage" runat="server" Text="图片"></asp:Label>
    <asp:FileUpload ID="FileUploadImage" runat="server" />
    <br />
    <asp:Button ID="ButtonModify" runat="server" Text="更新" 
        onclick="ButtonModify_Click"/>
    <br />
</asp:Content>
