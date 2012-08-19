<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowAreaWebUserControl1.ascx.cs" Inherits="Vneed.UI.Web.WebUserControl.ShowAreaWebUserControl1" %>
<script type="text/javascript">
    $(document).ready(function () {
        var currentShowAreaPicIndex = 0;
        var currentShowAreaPicNum = 0;
        var currentShowAreaTimer = null;
        var animateTime = 300;

        InitShowArea();

        $("#showAreaLeftButtonDiv").click(function () {
            MoveShowAreaPic("left");
        });
        $("#showAreaRightButtonDiv").click(function () {
            MoveShowAreaPic("right");
        });
        function MoveShowAreaPic(direction) {
            StopShowAreaTimer();
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
                    }, animateTime, function () {
                        this.className = "showAreaLeftRightImageShow";
                        this.style.left = "";
                    });
                    //centerPic
                    $(rightPic).appendTo($(".showAreaCenterPic")).attr("class", "showAreaCenterImageRightHidden");
                    $(rightPic).animate({
                        left: $(centerPic).css("left")
                    }, animateTime, function () {
                        this.className = "showAreaCenterImageShow";
                        this.style.left = "";
                    });
                    //leftPic
                    $(centerPic).appendTo($(".showAreaLeftPic")).attr("class", "showAreaLeftRightImageRightHidden");
                    $(centerPic).animate({
                        left: $(leftPic).css("left")
                    }, animateTime, function () {
                        this.className = "showAreaLeftRightImageShow";
                        this.style.left = "";
                    });
                    if (morePic) {
                        $(leftPic).prependTo($("#showAreaPicList"));
                    } else {
                        $(leftPic).remove();
                    }
                    currentShowAreaPicIndex = (--currentShowAreaPicIndex < 0) ? currentShowAreaPicNum - 1 : currentShowAreaPicIndex;
                    ChangeBottomButtonChoose();
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
                    }, animateTime, function () {
                        this.className = "showAreaLeftRightImageShow";
                        this.style.left = "";
                    });
                    //centerPic
                    $(leftPic).appendTo($(".showAreaCenterPic")).attr("class", "showAreaCenterImageLeftHidden");
                    $(leftPic).animate({
                        left: $(centerPic).css("left")
                    }, animateTime, function () {
                        this.className = "showAreaCenterImageShow";
                        this.style.left = "";
                    });
                    //rightPic
                    $(centerPic).appendTo($(".showAreaRightPic")).attr("class", "showAreaLeftRightImageLeftHidden");
                    $(centerPic).animate({
                        left: $(rightPic).css("left")
                    }, animateTime, function () {
                        this.className = "showAreaLeftRightImageShow";
                        this.style.left = "";
                    });
                    if (morePic) {
                        $(rightPic).appendTo($("#showAreaPicList"));
                    } else {
                        $(rightPic).remove();
                    }
                    currentShowAreaPicIndex = (++currentShowAreaPicIndex >= currentShowAreaPicNum) ? 0 : currentShowAreaPicIndex;
                    ChangeBottomButtonChoose();
                })();
            }
            StartShowAreaTimer();
        }
        function InitShowArea() {
            currentShowAreaPicNum = $("#showAreaPicList").children().size();
            for (var i = 0; i < currentShowAreaPicNum; i++) {
                $("<div class='showAreaBottomButtonUnChoose'></div>").appendTo($("#showAreaBottomButtons"));
            }
            var bottomButtonsWidth = $("#showAreaPicList").children().size() * 18;
            $("#showAreaBottomButtons").css("width", bottomButtonsWidth);
            ChangeBottomButtonChoose();

            var picList = $("#showAreaPicList").children();
            if (picList[currentShowAreaPicIndex]) {
                $(picList[currentShowAreaPicIndex]).appendTo($(".showAreaRightPic"));
                picList[currentShowAreaPicIndex].className = "showAreaLeftRightImageShow";
            }
            if (picList[currentShowAreaPicIndex + 1]) {
                $(picList[currentShowAreaPicIndex + 1]).appendTo($(".showAreaCenterPic"));
                picList[currentShowAreaPicIndex + 1].className = "showAreaCenterImageShow";
            }
            if (picList[currentShowAreaPicIndex + 2]) {
                $(picList[currentShowAreaPicIndex + 2]).appendTo($(".showAreaLeftPic"));
                picList[currentShowAreaPicIndex + 2].className = "showAreaLeftRightImageShow";
            }
            StartShowAreaTimer();
        }
        function ChangeBottomButtonChoose() {
            $("#showAreaBottomButtons").children().attr("class", "showAreaBottomButtonUnChoose");
            $($("#showAreaBottomButtons").children().get(currentShowAreaPicIndex)).attr("class", "showAreaBottomButtonChoose");
        }
        function StartShowAreaTimer() {
            currentShowAreaTimer = setInterval(function () {
                MoveShowAreaPic("right");
            }, 5000);
        }
        function StopShowAreaTimer() {
            clearInterval(currentShowAreaTimer);
        }
    });
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