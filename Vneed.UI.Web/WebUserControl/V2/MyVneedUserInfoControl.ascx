<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyVneedUserInfoControl.ascx.cs" Inherits="Vneed.UI.Web.WebUserControl.V2.MyVneedUserInfoControl" %>
<div id="myVneedSubTitleRightContainer">
        <div class="myVneedSubTitleUserNameContainer">
            <asp:Label ID="myVneedSubTitleUserNameLabel" runat="server" Text="" CssClass="myVneedSubTitleUserName"></asp:Label>
            <br/>
            <asp:Label ID="myVneedSubTitleUserTypeLabel" runat="server" Text="" CssClass="myVneedSubTitleUserType"></asp:Label>
        </div>
        <div class="myVneedSubTitleUserImageContainer">
            <asp:Image ID="myVneedSubTitleUserImage" runat="server" />
        </div>
</div>