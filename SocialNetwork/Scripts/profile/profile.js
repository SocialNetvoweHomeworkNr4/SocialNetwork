
    function initEditable() {
        $('#FirstName, #LastName,#PhoneNumber').editable({
            type: 'text',
            pk: 1,
            url: '/profile/editprofile',
            success: function (response, newValue) {
                alert(response.message);
            },
            placement: 'bottom',
            validate: function (value) {
                if ($.trim(value) == '') {
                    return 'Lauks nevar būt tukšs';
                }
            }
        });

        $("#Interests, #About").editable({
            type: 'textarea',
            pk: 1,
            url: '/profile/editprofile',
            success: function (response, newValue) {
                alert(response.message);
            },
            placement: 'bottom',
            validate: function (value) {
                if ($.trim(value) == '') {
                    return 'Lauks nevar būt tukšs';
                }
            }
        });

        $("#DateOfBirth").editable({
            type: 'date',
            format: 'yyyy-mm-dd',    
            viewformat: 'dd/mm/yyyy',
            viewMode: '0',
            datepicker: {
                weekStart: 1
            },
            pk: 1,
            url: '/profile/editprofile',
            success: function (response, newValue) {
                alert(response.message);
            },
            placement: 'bottom',
            validate: function (value) {
                if ($.trim(value) == '') {
                    return 'Lauks nevar būt tukšs';
                }
            }

        });
    }

    function initFileUploader()
    {
        $("#profile-image").fileupload({
            url: '/Profile/UploadAvatar',
            dataType: 'json',
            done: function (e, data) {
                location.href = location;
            },
            progressall: function (e, data) {
                var progress = parseInt(data.loaded / data.total * 100, 10);
                $('#progress .progress-bar').css(
                    'width',
                    progress + '%'
                );
            },
        })
    }
    



$(document).ready(function () {
    initEditable();
    initFileUploader();
});