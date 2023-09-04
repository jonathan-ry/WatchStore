//Show Create Modal
$(function () {
    var DashboardElement = $('#DashboardDiv');
    $('button[data-toggle="ajax-modal"]').click(function (event) {
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            console.log(url);
            console.log(data);
            DashboardElement.html(data);
            DashboardElement.find('.modal').modal('show');
        })
    })
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

//Submit Form from Create Modal
function createFormSubmit() {
    $('#createForm').submit();
}

//Submit Form from Update Modal
function updateFormSubmit() {
    $('#updateForm').submit();
}


var itemIdToDelete;

function showDeleteModal(itemNumber) {
    itemIdToDelete = itemNumber;
    $("#deleteModal").modal('show');
}

function confirmDelete() {
    deleteItem(itemIdToDelete)
}

function deleteItem(itemId) {
    // Send AJAX request to delete item by itemId
    $.ajax({
        url: 'Dashboard/DeleteItem',
        type: 'POST',
        data: { itemId: itemId },
        success: function (result) {
            // Handle success or update the UI
            $("#deleteModal").modal('hide');
            // You might refresh the list or do other actions
        },
        error: function () {
            // Handle error
        }
    });
}

function updateWatch(itemId) {
    var DashboardElement = $('#DashboardDiv');
    // Send AJAX request to update the item by itemId
    $.ajax({
        url: 'Dashboard/Update',
        type: 'POST',
        data: { itemId: itemId },
        success: function (result) {
            // Handle success or update the UI
            // You might refresh the list or do other actions
            console.log("Result:")
            console.log(result);
            DashboardElement.html(result);
            DashboardElement.find('.modal').modal('show');
        },
        error: function () {
            // Handle error
        }
    });
}
