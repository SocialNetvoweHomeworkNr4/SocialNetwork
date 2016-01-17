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

    function addFriendModal(userId) {

        $.ajax({
            method: "POST",
            url: "/Friend/AddFriend",
            data: { userId: userId },
            success: function (data) {
                if (data.result == null)
                    $("#add-friend-modal").modal('show');

                else
                    console.log(data);
            }
        })

    }

    function filterPeople(page, firstName, lastName, gender) {

        $.ajax({
            url: "/Friend/FilterPeople",
            type: "GET",
            data: {
                page: page,
                firstName: !firstName ? null : firstName,
                lastName: !lastName ? null : lastName,
                gender: gender != "Select gender" ? gender : null
            },
            success: function (data) {
                $("#result-container").html(data)
            },
            error: function (error) {
                console.log(error);
            }
        })

    }

    function removeFriend(userId) {
        var url = "/Friend/RemoveFriendAccept";
        var page = $(".pagination").find(".active a").html();
        $.ajax({
            method: "POST",
            url: url,
            data: { userId: userId, page: page },
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

        $("[id^='search'], #search-gender").bind("keyup change", function () {
            filterPeople($(".pagination").find(".active a").html(), $("#search-name").val(), $("#search-last-name").val(), $("#search-gender").val());
        });

        $(".add-friend").on("click", function () {
            var userId = $(this).attr("data-userid");

            addFriendModal(userId);
        });

        $("#add-friend-finish").on("click", function () {
            location.reload();
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