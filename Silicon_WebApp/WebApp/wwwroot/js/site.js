document.addEventListener("DOMContentLoaded", function () {
    handleProfileUpload();
})

function handleProfileUpload() {
    try {
        let fileUploader = document.querySelector("#fileUploader");
        if (fileUploader != undefined) {
            fileUploader.addEventListener("change", function () {
                if (this.files.length > 0) {
                    this.form.submit();
                }
            })
        }
    }
    catch {

    }
}