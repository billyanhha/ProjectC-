

$(document).ready(() => {
    loadingResources();
    $('[data-toggle="tooltip"]').tooltip();
    $('.category-product-item-image').Lazy({
        // your configuration goes here
        scrollDirection: 'vertical',
        effect: 'fadeIn',
        visibleOnly: true,
        onError: function (element) {
            console.log('error loading ' + element.data('src'));
        }
    });
});


const loadingResources = () => {
    uploadImage();
    multiImage();
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

const multiImage = () => {

    let imageList = [];


    //    load data
    function readURL(input) {
        if (input.files && input.files[0]) {
            $(".preview-image").empty();

            $(".preview-image").append("<i class=\"fas fa-minus-circle  preview-image-clear\"></i>")

            let arr = [...input.files];
            imageList = [...imageList, ...arr];

            for (let i = 0 ; i < imageList.length ; i++) {
                let reader = new FileReader();
                reader.onload = function (e) {
                    $(".preview-image").append("<div class=\"preview-image-item\" id = \"" + i + "\" style = \"background-image: url('" + e.target.result + "')\" ></div>");
                };
                reader.readAsDataURL(imageList[i]);
            }



        } else {
            $(".preview-image").empty();
        }
    }


    $(".multiFileUpload").change(function () {
        readURL(this);
        this.files[0] = imageList;

        $(".preview-image-clear").on('click', () => {
            $(".multiFileUpload").replaceWith($(".multiFileUpload").val('').clone(true));
            imageList = [];
            $(".preview-image").empty();
        });
    });
};




