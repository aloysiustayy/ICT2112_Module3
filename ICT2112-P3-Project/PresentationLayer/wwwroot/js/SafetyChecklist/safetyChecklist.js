window.addEventListener('DOMContentLoaded', function () {
    var avatar = document.getElementById('avatar');
    var image = document.getElementById('image');
    var input = document.getElementById('input');
    var $modal = $('#modal');
    var cropper;

    $('[data-toggle="tooltip"]').tooltip();
    $("#submitButton").click(function (e) {

        e.preventDefault();

        // Retrieve the value of the imageURLInput field
        var imageURL = $("#imageURLInput").val().trim(); // Trim to remove any leading/trailing spaces

        // Check if the imageURLInput field is empty
        if (imageURL === '') {
            // Prevent the form from being submitted
            e.preventDefault();
            console.log(imageURL);
            // Display an error message using SweetAlert
            Swal.fire({
                icon: 'error',
                title: 'Error!',
                text: 'Please select a file to upload.',
            });
        } else {

            var formData = new FormData();
            formData.append('imageURLInput', imageURL);

            $.ajax({
                url: '/UploadPhotoInput/AddPhoto',
                type: 'POST',
                data: formData,
                processData: false,
                contentType: false,
                success: function (response) {
                    // Handle success response
                 
                    Swal.fire(
                        'Updated!',
                        'File uploaded successfully!',
                        'success'
                    ).then(function () {
                        window.location.href = '/SafetyChecklist/Index';
                    });
                },
                error: function (xhr, status, error) {
                    // Handle error response
                    console.error('Error uploading file:', error);
                    Swal.fire({
                        icon: 'error',
                        title: 'Error!',
                        text: 'Error uploading file.',
                    });
                  
                }
            });
        }
    });
    input.addEventListener('change', function (e) {
        var fileName = $("#input").val();
        var idxDot = fileName.lastIndexOf(".") + 1;
        var extFile = fileName.substr(idxDot, fileName.length).toLowerCase();
        if (extFile == "jpg" || extFile == "jpeg" || extFile == "png") {
            var files = e.target.files;
            var done = function (url) {
                input.value = '';
                image.src = url;
                $modal.modal('show');
            };
            var reader;
            var file;
            var url;

            if (files && files.length > 0) {
                file = files[0];

                if (URL) {
                    done(URL.createObjectURL(file));
                } else if (FileReader) {
                    reader = new FileReader();
                    reader.onload = function (e) {
                        done(reader.result);
                    };
                    reader.readAsDataURL(file);
                }
            }
        } else {
            Swal.fire({
                icon: 'error',
                title: 'Error!',
                text: 'The uploaded file type is not supported!'
            })
        }
    });

    $modal.on('shown.bs.modal', function () {
        cropper = new Cropper(image, {
            aspectRatio: NaN,
            dragMode: 'move',
            guides: true,
            center: true,
            highlight: true,
            background: true,
            movable: true,
            cropBoxResizable: false,
            toggleDragModeOnDblclick: false,
            data: {
                width: 330,
                height: 450,
            },
        });
    }).on('hidden.bs.modal', function () {
        cropper.destroy();
        cropper = null;
    });

    document.getElementById('crop').addEventListener('click', function () {
        console.log("test")
        var initialAvatarURL;
        var canvas;
        console.log("test")

        $modal.modal('hide');

        if (cropper) {
            canvas = cropper.getCroppedCanvas({
                width: 330,
                height: 450,
            });
            initialAvatarURL = avatar.src;
            avatar.src = canvas.toDataURL();
            var imageURL = document.getElementById("imageURLInput");
            console.log(imageURL)
            imageURL.setAttribute("value", canvas.toDataURL());
        }
    });

    document.getElementById('cancel').addEventListener('click', function () {
        $modal.modal('hide');
    });

    document.getElementById('close').addEventListener('click', function () {
        $modal.modal('hide');
    });

});

//This converts dataURL into a file
function dataURLtoFile(dataurl, filename) {

    var arr = dataurl.split(','),
        mime = arr[0].match(/:(.*?);/)[1],
        bstr = atob(arr[1]),
        n = bstr.length,
        u8arr = new Uint8Array(n);

    while (n--) {
        u8arr[n] = bstr.charCodeAt(n);
    }

    return new File([u8arr], filename, { type: mime });
}
//Upload image code
$("#profileImage").click(function (e) {
    $("#imageUpload").click()
});

function fasterPreview(uploader) {
    if (uploader.files && uploader.files[0]) {
        $('#profileImage').attr('src',
            window.URL.createObjectURL(uploader.files[0]));
    }
}
$("#imageUpload").change(function () {
    fasterPreview(this);
});