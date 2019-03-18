

$(document).ready(() => {
    loadingResources();
    $('[data-toggle="tooltip"]').tooltip();
});


const loadingResources = () => {
    uploadImage();
    editProfile();
};

const editProfile = () => {
    $('.editBtn').attr("disabled", "");

    $('.fullname').keyup(() => {
        if ($('.fullname').val().replace(/\s/g, '')) {
            $('.editBtn').removeAttr("disabled");
        } else {
            $('.editBtn').attr("disabled", "");
        }
    });

    $('.phonenum').keyup(() => {
        if ($('.phonenum').val().replace(/\s/g, '')) {
            $('.editBtn').removeAttr("disabled");
        } else {
            $('.editBtn').attr("disabled", "");
        }
    });

    $('.aboutme').keyup(() => {
        if ($('.aboutme').val().replace(/\s/g, '')) {
            $('.editBtn').removeAttr("disabled");
        } else {
            $('.editBtn').attr("disabled", "");
        }
    });

    $('.addressC').keyup(() => {
        if ($('.addressC').val().replace(/\s/g, '')) {
            $('.editBtn').removeAttr("disabled");
        } else {
            $('.editBtn').attr("disabled", "");
        }
    });
}



const uploadImage = () => {
    $('.submitChangeAva').attr("disabled", "");
    //    load data
    function readURL(input) {
        if (input.files && input.files[0]) {
            $('.submitChangeAva').removeAttr("disabled");
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#image_upload_preview').attr('src', e.target.result);
            };

            reader.readAsDataURL(input.files[0]);
        } else {
            $('#image_upload_preview').attr('src', "");
            $('.submitChangeAva').attr("disabled", "");
        }
    }

    $(".uploadAvatar").change(function () {
        readURL(this);
    });
};

