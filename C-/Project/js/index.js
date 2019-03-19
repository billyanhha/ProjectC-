

$(document).ready(() => {
    loadingResources();
    $('[data-toggle="tooltip"]').tooltip();
});


const loadingResources = () => {
    uploadImage();
    editProfile();
    multiImage();
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

const multiImage = () => {
    //    load data
    function readURL(input , callback) {
        if (input.files && input.files[0]) {
            let index = 0;
            let arr = [...input.files];

            for(let item of arr) {
                let reader = new FileReader();
                reader.onload = function (e) {
                    $(".preview-image").append("<div class=\"preview-image-item\ " + ++index + "\"></div>");
                    $(`.${index}`).attr('style', `background-image: url('${e.target.result}');`);
                };
                reader.readAsDataURL(item);

            }

            callback();

        } else {
            $(".preview-image").empty();
        }
    }

    $(".multiFileUpload").change(function () {
        readURL(this , ()=>            $(".preview-image").append("<i class=\"fas fa-minus-circle  preview-image-clear\"></i>"));
        $(".preview-image-clear").on('click', () => {
            console.log("sss");
            $(".multiFileUpload").replaceWith($(".multiFileUpload").val('').clone(true));
            $(".preview-image").empty();
        });
    });
};

