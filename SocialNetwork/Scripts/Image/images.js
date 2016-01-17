var images = (function (settings) {

    var me = {};

    var imageTemplate = Handlebars.compile($("#image-template").html()); 
    var commentTemplate = Handlebars.compile($("#comment-template").html())

    function init() {
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
            }
        }).prop('disabled', !$.support.fileInput)
            .parent().addClass($.support.fileInput ? undefined : 'disabled');

        $(".image-edit").on("click", function (e) {
            e.preventDefault();

            var imageId = $(this).data('image');

            var url = "/Image/Edit/" + imageId;


            $.post(url, function (data) {

                var params = {
                    ImageId: data.model.ImageID,
                    ImageName: data.model.FileName,
                    Comment: data.model.Comment,
                    Comments: data.model.Comments
                }

                $('#myModal').find('.modal-content').html(imageTemplate(params))

                $('#myModal').modal('show');

                modalUpdateInit();
            });
        });
    }

    function modalUpdateInit() {
        $('.comment').on('click', function () {
            $('.comment-edit').show();
            $('.comment-update').prev('input').focusToEnd();
            $(this).hide();
        });

        $(".comment-update").on("click", update);

        $(".update-cancel").on("click", function (e) {
            e.preventDefault();

            $('.comment').show();
            $('.comment-edit').hide();
        });

        $('.comment-update').prev('input').pressEnter(update);

        addComment();
    }

    function update(e) {
        e.preventDefault();

        var imageId = $(this).data('image');

        var url = "/Image/Update/" + imageId;

        $.post(url, {
            imageId: imageId, comment: $('.comment-update').prev('input').val()
        }, function (data) {
            if (data.success) {
                $('.comment').html($('.comment-update').prev('input').val()).show();
                $('.comment-edit').hide();
            }
                
        });
    }

    function addComment() {
        $('#add-comment').on('click', function () {
            var imageId = $(this).data('image');

            var url = "/Image/Add/" + imageId;

            $.post(url, {
                imageId: imageId, text: $('#comment').val()
            }, function (data) {
                if (data.success) {
                    var params = {
                        Text: data.text,
                        AuthorName: data.name,
                        Date: data.date,
                    };

                    $('#comments').append(commentTemplate(params));
                    $('#comment').val('');
                }

            });
        });
    }

    

    me.init = function (settings) {
        init();
    };

    return me;

})();