function Tab(titleID, contentID) {
    this.titleID = titleID;
    this.contentID = contentID;
}

function TabControl(options) {
    this.TabList = options.TabList;
    this.SelectCss = options.SelectCss;
    this.NormalCss = options.NormalCss;
    this.Init();
}
TabControl.prototype.Init = function () {
    var tabList = this.TabList;
    var tabControl = this;

    $(tabList[0].titleID).siblings().removeClass(tabControl.SelectCss).addClass(tabControl.NormalCss);
    $(tabList[0].contentID).siblings().hide();
    $(tabList[0].titleID).removeClass(tabControl.NormalCss).addClass(tabControl.SelectCss);
    $(tabList[0].contentID).show();

    for (var index = 0; index < tabList.length; index++) {
        (function () {
            var tab = tabList[index];
            $(tab.titleID).click(function () {
                $(tab.titleID).siblings().removeClass(tabControl.SelectCss).addClass(tabControl.NormalCss);
                $(tab.contentID).siblings().hide();
                $(tab.titleID).removeClass(tabControl.NormalCss).addClass(tabControl.SelectCss);
                $(tab.contentID).show();
            });
        })();
    }
};

function Validator(options) {
    this.id = options.id;
    this.type = options.type;
    this.defaultStr = options.defaultStr;
    this.minLength = options.minLength;
    this.maxLength = options.maxLength;
    this.compareId = options.compareId;
    this.regexp = options.regexp;
}
Validator.prototype.Validation = function () {
    if (this.type == "required") {
        if ($(this.id).val() == "" || (this.defaultStr && $(this.id).val() == this.defaultStr))
            return false;
        else
            return true;
    }
    if (this.type == "range") {
        if ($(this.id).val().length > this.maxLength || $(this.id).val().length < this.minLength)
            return false;
        else
            return true;
    }
    if (this.type == "compare") {
        if (this.compareId && $(this.id).val() != $(this.compareId).val())
            return false;
        else
            return true;
    }
    if (this.type == "regexp") {
        if (this.regexp && $(this.id).val().match(this.regexp))
            return true;
        else
            return false;
    }
};


function TextBox(options) {
    this.id = options.id;
    this.defaultStr = options.defaultStr;
    this.type = options.type;
    this.Init();
}
TextBox.prototype.Init = function () {
    if (this.type == "text") {
        if ($(this.id).val() == "")
            $(this.id).val(this.defaultStr);
    } else if (this.type == "password") {
        var passwordShowID = this.id + "Show";
        var passwordHideID = this.id + "Hide";
        $(passwordShowID).val(this.defaultStr);
    }
    if (this.type == "text") {
        var textBox = this;
        $(this.id).blur(function () {
            if ($(textBox.id).val() == "")
                $(textBox.id).val(textBox.defaultStr);
        }).focus(function () {
            if ($(textBox.id).val() == textBox.defaultStr)
                $(textBox.id).val("");
        });
    } else if (this.type == "password") {
        var passwordShowID = this.id + "Show";
        var passwordHideID = this.id + "Hide";
        $(passwordShowID).focus(function () {
            $(passwordHideID).show().focus();
            $(passwordShowID).hide();
        });
        $(passwordHideID).blur(function () {
            if ($(passwordHideID).val() == "") {
                $(passwordShowID).show();
                $(passwordHideID).hide();
            }
        });
    }
};

function NumSelector() {
    this.Init();
}
NumSelector.prototype.Init = function () {
    $(".productDetailProductNumText").keyup(function () {
        this.value = this.value.replace(/\D/g, '');
        if (this.value == '') {
            this.value = '1';
        } else if (parseInt(this.value) > 99) {
            this.value = '99';
        }
    });

    $(".productDetailMinusProductIcon").click(function () {
        var numInput = $(this).parent().next().children().children()[0];
        var num = parseInt($(numInput).val()) - 1;
        if (num >= 1) {
            $(numInput).val(num);
        }

    });
    $(".productDetailPlusProductIcon").click(function () {
        var numInput = $(this).parent().prev().children().children()[0];
        var num = parseInt($(numInput).val()) + 1;
        if (num <= 99) {
            $(numInput).val(num);
        }
    });
};

function NumSelectorPostBack() {
    this.Init();
}
NumSelectorPostBack.prototype.Init = function () {
    $(".productDetailProductNumText").keyup(function () {

        this.value = this.value.replace(/\D/g, '');
        if (this.value == '') {
            this.value = '1';
        } else if (parseInt(this.value) > 99) {
            this.value = '99';
        }

        var name = $(this).attr("name");
        var func = "__doPostBack('" + name + "','')";
        setTimeout(func, 0);
    });

    $(".productDetailMinusProductIcon").click(function () {
        var numInput = $(this).parent().next().children().children()[0];
        var num = parseInt($(numInput).val()) - 1;
        if (num >= 1) {
            $(numInput).val(num);
            var name = $(numInput).attr("name");
            var func = "__doPostBack('" + name + "','')";
            setTimeout(func, 0);
        }

    });
    $(".productDetailPlusProductIcon").click(function () {
        var numInput = $(this).parent().prev().children().children()[0];
        var num = parseInt($(numInput).val()) + 1;
        if (num <= 99) {
            $(numInput).val(num);
            var name = $(numInput).attr("name");
            var func = "__doPostBack('" + name + "','')";
            setTimeout(func, 0);
        }
    });
};

function RadioManager() {
    this.Init();
}

RadioManager.prototype.Init = function () {
    this.Show();
    $(".VneedRadio").click(function () {
        var children = $(this).children();
        var input = children[0];
        var label = children[1];

        var inputName = $(input).attr("name");
        var inputs = $(".VneedRadio input");
        var labels = $(".VneedRadio label");
        for (var i = 0; i < inputs.length; i++) {
            if ($(inputs[i]).attr("name") == inputName && inputs[i] != input) {
                $(inputs[i]).removeAttr("checked");
                $(labels[i]).removeClass("checked");
            }
        }

        $(input).attr("checked", "checked");
        $(label).addClass("checked");
    });
};

RadioManager.prototype.Show = function () {
    var inputs = $(".VneedRadio input");
    var labels = $(".VneedRadio label");
    for (var i = 0; i < inputs.length; i++) {
        if ($(inputs[i]).attr("checked") == "checked") {
            $(labels[i]).addClass("checked");
        }
    }
};

$.extend({
    getUrlVars: function(){
        var vars = [], hash;
        var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
	    for(var i = 0; i < hashes.length; i++)
	    {
	        hash = hashes[i].split('=');
	        vars.push(hash[0]);
	        vars[hash[0]] = hash[1];
	    }
	    return vars;
    },

	getUrlVar: function(name){
	    return $.getUrlVars()[name];
	}    
});