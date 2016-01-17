var app = (function (settings) {

    var me = {};

    function init() {
        $('[data-toggle="tooltip"]').tooltip();
    }

    function extensions() {
        $.fn.pressEnter = function (fn) {

            return this.each(function () {
                $(this).bind('enterPress', fn);
                $(this).keyup(function (e) {
                    if (e.keyCode == 13) {
                        $(this).trigger("enterPress");
                    }
                })
            });
        };

        $.fn.focusToEnd = function () {
            return this.each(function () {
                var v = $(this).val();
                $(this).focus().val("").val(v);
            });
        };
    }

    me.init = function (settings) {
        init();
        extensions();
    };

    me.enterKey = function (el, func) {
        enterKey(el, func);
    }

    return me;

})();