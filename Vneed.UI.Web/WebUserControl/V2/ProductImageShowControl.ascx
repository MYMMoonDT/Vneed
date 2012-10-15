<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductImageShowControl.ascx.cs" Inherits="Vneed.UI.Web.WebUserControl.V2.ProductImageShow" %>
<link href="../../Resource/NivoSlider/default.css" rel="stylesheet" type="text/css" media="screen"/>
<link href="../../Resource/NivoSlider/nivo-slider.css" rel="stylesheet" type="text/css" media="screen"/>
<asp:Panel ID="productImageShowPanel" runat="server">
</asp:Panel>
<%--<div class="productImageShowBg">
    <div class="productImageShowContainer">
        <div class="productImageShowWrapper">
            <div class="slider-wrapper theme-default">
                <div id="slider" class="nivoSlider">
                    <img src="../../Image/Gallery/toystory.jpg" alt="" />
                    <img src="../../Image/Gallery/up.jpg" alt="" />
                    <img src="../../Image/Gallery/walle.jpg" alt="" />
                </div>
            </div>
        </div>
    </div>
</div>
<div class="productImageShowDivider"></div>--%>
<script type="text/javascript">
    $(document).ready(function () {
        $('#slider').nivoSlider();
    });
</script>