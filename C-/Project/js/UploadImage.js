

$(document).ready(() => {
    loadingResources();
    $('[data-toggle="tooltip"]').tooltip();
});


const loadingResources = () => {
    uploadImage();
};



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

