﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowAreaWebUserControl1.ascx.cs" Inherits="Vneed.UI.Web.WebUserControl.ShowAreaWebUserControl1" %>
<script type="text/javascript">
    $(document).ready(function () {
        var showArea = new ShowArea();
        $("#showAreaLeftButtonDiv").click(function () {
            showArea.MoveShowAreaPic("left");
        });
        $("#showAreaRightButtonDiv").click(function () {
            showArea.MoveShowAreaPic("right");
        });
        showArea.InitShowArea();
    });
    function ShowArea() {
        this.currentShowAreaPicIndex = 0;
        this.currentShowAreaPicNum = 0;
        this.currentShowAreaTimer = null;
        this.animateTime = 300;
    }
    ShowArea.prototype.InitShowArea = function () {
        this.currentShowAreaPicNum = $("#showAreaPicList").children().size();
        for (var i = 0; i < this.currentShowAreaPicNum; i++) {
            $("<div class='showAreaBottomButtonUnChoose'></div>").appendTo($("#showAreaBottomButtons"));
        }
        var bottomButtonsWidth = $("#showAreaPicList").children().size() * 18;
        $("#showAreaBottomButtons").css("width", bottomButtonsWidth);
        this.ChangeBottomButtonChoose();

        var picList = $("#showAreaPicList").children();
        if (picList[this.currentShowAreaPicIndex]) {
            $(picList[this.currentShowAreaPicIndex]).appendTo($(".showAreaRightPic"));
            picList[this.currentShowAreaPicIndex].className = "showAreaLeftRightImageShow";
        }
        if (picList[this.currentShowAreaPicIndex + 1]) {
            $(picList[this.currentShowAreaPicIndex + 1]).appendTo($(".showAreaCenterPic"));
            picList[this.currentShowAreaPicIndex + 1].className = "showAreaCenterImageShow";
        }
        if (picList[this.currentShowAreaPicIndex + 2]) {
            $(picList[this.currentShowAreaPicIndex + 2]).appendTo($(".showAreaLeftPic"));
            picList[this.currentShowAreaPicIndex + 2].className = "showAreaLeftRightImageShow";
        }
        this.StartShowAreaTimer();
    };
    ShowArea.prototype.StartShowAreaTimer = function () {
        var _this = this;
        var callBack = function () { _this.MoveShowAreaPic("right"); };
        _this.currentShowAreaTimer = setInterval(callBack, 5000);
    };
    ShowArea.prototype.StopShowAreaTimer = function () {
        var _this = this;
        clearInterval(_this.currentShowAreaTimer);
    };
    ShowArea.prototype.ChangeBottomButtonChoose = function () {
        $("#showAreaBottomButtons").children().attr("class", "showAreaBottomButtonUnChoose");
        $($("#showAreaBottomButtons").children().get(this.currentShowAreaPicIndex)).attr("class", "showAreaBottomButtonChoose");
    };
    ShowArea.prototype.MoveShowAreaPic = function (direction) {
        var _this = this;
        _this.StopShowAreaTimer();
        if (direction == "left") {
            (function () {
                var leftPic = $(".showAreaLeftPic").children()[0];
                var centerPic = $(".showAreaCenterPic").children()[0];
                var rightPic = $(".showAreaRightPic").children()[0];
                var appendPic = null;
                var morePic = false;
                //rightPic
                if ($("#showAreaPicList").children().size() > 0) {
                    appendPic = $($("#showAreaPicList").children().get($("#showAreaPicList").children().size() - 1)).appendTo($(".showAreaRightPic")).attr("class", "showAreaLeftRightImageRightHidden");
                    morePic = true;
                } else {
                    appendPic = $(leftPic).clone().appendTo($(".showAreaRightPic")).attr("class", "showAreaLeftRightImageRightHidden");
                    morePic = false;
                }
                $(appendPic).animate({
                    left: $(rightPic).css("left")
                }, 300, function () {
                    this.className = "showAreaLeftRightImageShow";
                    this.style.left = "";
                });
                //centerPic
                $(rightPic).appendTo($(".showAreaCenterPic")).attr("class", "showAreaCenterImageRightHidden");
                $(rightPic).animate({
                    left: $(centerPic).css("left")
                }, 300, function () {
                    this.className = "showAreaCenterImageShow";
                    this.style.left = "";
                });
                //leftPic
                $(centerPic).appendTo($(".showAreaLeftPic")).attr("class", "showAreaLeftRightImageRightHidden");
                $(centerPic).animate({
                    left: $(leftPic).css("left")
                }, 300, function () {
                    this.className = "showAreaLeftRightImageShow";
                    this.style.left = "";
                });
                if (morePic) {
                    $(leftPic).prependTo($("#showAreaPicList"));
                } else {
                    $(leftPic).remove();
                }
                _this.currentShowAreaPicIndex = (--_this.currentShowAreaPicIndex < 0) ? _this.currentShowAreaPicNum - 1 : _this.currentShowAreaPicIndex;
                _this.ChangeBottomButtonChoose();
            })();
        } else if (direction == "right") {
            (function () {
                var leftPic = $(".showAreaLeftPic").children()[0];
                var centerPic = $(".showAreaCenterPic").children()[0];
                var rightPic = $(".showAreaRightPic").children()[0];
                var appendPic = null;
                var morePic = false;
                //leftPic
                if ($("#showAreaPicList").children().size() > 0) {
                    appendPic = $($("#showAreaPicList").children().get(0)).appendTo($(".showAreaLeftPic")).attr("class", "showAreaLeftRightImageLeftHidden");
                    morePic = true;
                } else {
                    appendPic = $(rightPic).clone().appendTo($(".showAreaLeftPic")).attr("class", "showAreaLeftRightImageLeftHidden");
                    morePic = false;
                }
                $(appendPic).animate({
                    left: $(leftPic).css("left")
                }, 300, function () {
                    this.className = "showAreaLeftRightImageShow";
                    this.style.left = "";
                });
                //centerPic
                $(leftPic).appendTo($(".showAreaCenterPic")).attr("class", "showAreaCenterImageLeftHidden");
                $(leftPic).animate({
                    left: $(centerPic).css("left")
                }, 300, function () {
                    this.className = "showAreaCenterImageShow";
                    this.style.left = "";
                });
                //rightPic
                $(centerPic).appendTo($(".showAreaRightPic")).attr("class", "showAreaLeftRightImageLeftHidden");
                $(centerPic).animate({
                    left: $(rightPic).css("left")
                }, 300, function () {
                    this.className = "showAreaLeftRightImageShow";
                    this.style.left = "";
                });
                if (morePic) {
                    $(rightPic).appendTo($("#showAreaPicList"));
                } else {
                    $(rightPic).remove();
                }
                _this.currentShowAreaPicIndex = (++_this.currentShowAreaPicIndex >= _this.currentShowAreaPicNum) ? 0 : _this.currentShowAreaPicIndex;
                _this.ChangeBottomButtonChoose();
            })();
        }
        this.StartShowAreaTimer();
    };
</script>
<div id="showAreaDiv">
    <div id="showAreaContentDiv">
        <div id="showAreaLeftButtonDiv"></div>
        <div id="showAreaRightButtonDiv"></div>
        <div id="showAreaPicsDiv">
            <div class="showAreaLeftPicDiv">
                <div class="showAreaLeftPic">
                    
                </div>
            </div>
            <div class="showAreaCenterPicDiv">
                <div class="showAreaCenterPic">
                    
                </div>
            </div>
            <div class="showAreaRightPicDiv">
                <div class="showAreaRightPic">
                    
                </div>
            </div>
        </div>
        <div style="display:none;">
            <ul id="showAreaPicList">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/Gallery/test1.jpg" />
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Image/Gallery/test2.jpg" />
                <asp:Image ID="Image3" runat="server" ImageUrl="~/Image/Gallery/test3.jpg" />
                <asp:Image ID="Image4" runat="server" ImageUrl="~/Image/Gallery/test4.jpg" />
                <asp:Image ID="Image5" runat="server" ImageUrl="~/Image/Gallery/test5.jpg" />
            </ul>
        </div>
        
        <div id="showAreaBottomButtonsDiv">
            <div id="showAreaBottomButtons">
                
            </div>
        </div>
    </div>
</div>