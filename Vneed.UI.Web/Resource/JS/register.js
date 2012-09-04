function EndRequestHandler2() {
    var registerInfo = [["#RegisterNameTextBox", "用户名","text"],
                        ["#RegisterPasswordTextBox", "设置密码","password"],
                        ["#RegisterPasswordAgainTextBox", "重复一遍密码","password"],
                        ["#RegisterEmailTextBox", "邮箱","text"]];
    for (var i = 0; i < registerInfo.length; i++) {
        (function () {
            var registerItem = registerInfo[i];
            $(registerItem[0]).focus(function () {
                if ($(registerItem[0]).val() == registerItem[1]) {
                    $(registerItem[0]).val("");
                    if (registerItem[2] == "password")
                        document.getElementById(registerItem[0].substr(1)).type = "password"
                }
            }).blur(function () {
                if ($(registerItem[0]).val() == "") {
                    $(registerItem[0]).val(registerItem[1]);
                    if (registerItem[2] == "password")
                        document.getElementById(registerItem[0].substr(1)).type = "text"
                }
            });
        })();
    }
}
function RegisterValidationFunc() {
    var registerError = ["#registerNameError", "#registerPasswordError", "#registerPassword2Error", "#registerEmailError"];
    for (var j = 0; j < registerError.length; j++) {
        $(registerError[j]).html("");
    }
    var registerInfo = [["#RegisterNameTextBox", "用户名", "请输入用户名", "null", "#registerNameError"],
                        ["#RegisterNameTextBox", "", "用户名长度必须在6~16个字符之间", "length", "#registerNameError"],
                        ["#RegisterPasswordTextBox", "设置密码", "请输入密码", "null", "#registerPasswordError"],
                        ["#RegisterPasswordTextBox", "", "密码长度必须在6~16个字符之间", "length", "#registerPasswordError"],
                        ["#RegisterPasswordAgainTextBox", "重复一遍密码", "请输入密码", "null", "#registerPassword2Error"],
                        ["#RegisterPasswordAgainTextBox", "", "两次密码不一致", "same", "#registerPassword2Error"],
                        ["#RegisterEmailTextBox", "邮箱", "请输入电子邮箱地址", "null", "#registerEmailError"],
                        ["#RegisterEmailTextBox", "", "请输入正确的邮箱地址", "email", "#registerEmailError"]];
    for (var i = 0; i < registerInfo.length; i++) {
        if (registerInfo[i][3] == "null") {
            if ($(registerInfo[i][0]).val() == "" || $(registerInfo[i][0]).val() == registerInfo[i][1]) {
                $(registerInfo[i][4]).html("<div class='error'>" + registerInfo[i][2] + "</div>");
                return false;
            }
        } else if (registerInfo[i][3] == "length") {
            if ($(registerInfo[i][0]).val().length < 6 || $(registerInfo[i][0]).val().length > 16) {
                $(registerInfo[i][4]).html("<div class='error'>"+ registerInfo[i][2] +"</div>");
                return false;
            }
        } else if (registerInfo[i][3] == "same") {
            if ($(registerInfo[i][0]).val() != $("#RegisterPasswordTextBox").val()) {
                $(registerInfo[i][4]).html("<div class='error'>" + registerInfo[i][2] + "</div>");
                return false;
            }
        } else if (registerInfo[i][3] == "email") {
            if (!$(registerInfo[i][0]).val().match(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/)) {
                $(registerInfo[i][4]).html("<div class='error'>" + registerInfo[i][2] + "</div>");
                return false;
            }
        }
    }
}

$(document).ready(function () {
    EndRequestHandler2();
});
        
    