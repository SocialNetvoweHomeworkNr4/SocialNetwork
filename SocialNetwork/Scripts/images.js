var images = (function (settings) {

    var me = {};

    var imageTemplate = Handlebars.compile($("#image-template").html());

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

    $(".image-href").on("click", function (e) {
        e.preventDefault();

        console.log('image ' + $(this).data('image'))
        console.log('user' + $(this).data('userid'))
        var imageId = $(this).data('image');
        var userId = $(this).data('userid');

        var url = "/Image/Edit/" + userId + "/" + imageId;


        $.post(url, function (data) {
            
            var params = {
                ImageName: data.model.FileName,
                Comment: data.model.Comment
            }

            $('#myModal').find('.modal-content').html(imageTemplate(params))

            $('#myModal').modal('show');
        });
    });

    me.init = function (settings) {
        init(settings.userId);
    };

    return me;

})();