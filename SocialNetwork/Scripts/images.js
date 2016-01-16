var images = (function (settings) {

    var me = {};

    function init(userId) {
        var url = '/Image/UploadFiles'
        $('#fileupload').fileupload({
            url: url,
            dataType: 'json',
            done: function (e, data) {
            },
            progressall: function (e, data) {
                var progress = parseInt(data.loaded / data.total * 100, 10);
                $('#progress .progress-bar').css(
                    'width',
                    progress + '%'
                );
            },
            formData: {
                userId: userId
            }
        }).prop('disabled', !$.support.fileInput)
            .parent().addClass($.support.fileInput ? undefined : 'disabled');
    }

    me.init = function (settings) {
        init(settings.userId);
    };

    return me;

})();