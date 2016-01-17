
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



$(document).ready(function () {
    initEditable();
});