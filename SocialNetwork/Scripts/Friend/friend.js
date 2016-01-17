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

    function removeFriend(userId) {
        var url = "/Friend/RemoveFriendAccept";
        $.ajax({
            method: "POST",
            url: url,
            data: { userId: userId },
            success: function (data) {
                $("#result-container").html(data);
            }
        })
    }

    function initEvents() {
        $(".remove-friend").on("click", function () {
            var userId = $(this).attr("data-userid");
            removeFriendAcceptionalModal(userId);
            $("#removeFriendModal").modal('show');
        });

        $("#delete-friend-accept").on("click", function () {
            var userId = $(this).attr("data-userid");
            removeFriend(userId);

        });
    }

    me.init = function () {
        initEvents();
    };

    return me;

})();