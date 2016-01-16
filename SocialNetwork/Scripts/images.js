$(function () {
    'use strict';

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
            userId: 6
        }
    }).prop('disabled', !$.support.fileInput)
        .parent().addClass($.support.fileInput ? undefined : 'disabled');
});