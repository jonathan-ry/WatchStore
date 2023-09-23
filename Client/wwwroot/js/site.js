//Create
function create() {
    window.location.href = 'Dashboard/Create';
}

//Submit Form from Create Modal
function createFormSubmit() {
    $('#createForm').submit();
}

var itemIdToDelete;
//Delete Modal Show
function showDeleteModal(itemNumber, url) {
    itemIdToDelete = itemNumber;
    $("#deleteModal").modal('show');
}

//Delete Modal Confirmation
function confirmDelete() {
    deleteItem(itemIdToDelete)
}


function deleteItem(itemId) {
    // Send AJAX request to delete item by itemId
    const windowUrlPattern = href => {
        const url = new URL(href);
        return url.origin
    }
    const route = windowUrlPattern(window.location.href) + '/Dashboard/DeleteItem';

    $.ajax({
        url: route,
        type: 'POST',
        data: { itemId: itemId },
        success: function (result) {
            // Handle success or update the UI
            $("#deleteModal").modal('hide');
            location.reload();
            // You might refresh the list or do other actions
        },
        error: function () {
            // Handle error
        }
    });
}

//Submit Form from Update Modal
function updateFormSubmit() {
    $('#updateForm').submit();
}


//Loading Screen Function
window.addEventListener("load", function () {
    var body = document.body;
    body.style.overflow = "hidden";
    setTimeout(function () {
        body.style.overflow = "hidden";
        var loadingScreen = document.getElementById("loading-screen");
        loadingScreen.style.display = "none";
        body.style.overflow = "auto";
    }, 600);

});


//Dynamically load photo when uploading in the Create Modal
function getFile(input) {
    var file = input.files[0];
    if (file) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#upload-icon').empty(); // Clear previous image if any
            $('#upload-icon').attr('src', e.target.result);
        };

        reader.readAsDataURL(file);
    }
}

$('#homeCarousel').carousel({
    interval: 3000,
    cycle: true
}); 


function sort(value) {
    window.location.href = "/Dashboard/Index?sortOrder=" + value;
}
