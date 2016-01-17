var friends = (function (settings) {

    var me = {};

    function removeFriendAcceptionalModal(userId) {
        var url = "/Friend/RemoveFriend";
        $.ajax({
            method: "POST",
            url: url,
            data: { userId: userId },
            success: function (data) {
                $("#removeFriendModal").html(data);
            }
        })
    }

    function initEvents() {
        $(".remove-friend").on("click", function () {
            var userId = $(this).attr("data-userid");
            removeFriendAcceptionalModal(userId);
            $("#removeFriendModal").modal('show');
        });
    }

    me.init = function () {
        initEvents();
    };

    return me;

})();