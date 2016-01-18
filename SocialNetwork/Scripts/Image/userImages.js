var userImages = (function (settings) {

    var me = {};

    var imageTemplate = Handlebars.compile($("#image-template").html());
    var commentTemplate = Handlebars.compile($("#comment-template").html())

    function init() {
        
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
       addComment();
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