﻿const userdataUri = 'api/userdata/all';
const feelingUri = 'api/stery/all';
const seedUri = 'api/seed/all';

let todos = null;
function getCount(data) {
    const el = $('#counter');
    let name = 'to-do';
    if (data) {
        if (data > 1) {
            name = 'to-dos';
        }
        el.text(data + ' ' + name);
    } else {
        el.html('No ' + name);
    }
}

$(document).ready(function () {
    getUserData();
    getSteryData();
    getSeedData();
});

function getUserData() {
    $.ajax({
        type: 'GET',
        url: userdataUri,
        success: function (data) {
            $('#users').empty();
            getCount(data.length);
            $.each(data, function (key, item) {
                $('<tr><td>' + item.id + '</td>' +
                    '<td>' + item.userId + '</td>' +
                    '<td>' + item.userName + '</td>' +
                    '<td>' + item.authType + '</td>' +
                    '<td>' + item.createdTime + '</td>' +
                    '<td>' + item.updatedTime + '</td>' +
                    '</tr>').appendTo($('#users'));
            });

        }
    });
}


function getSteryData() {
    $.ajax({
        type: 'GET',
        url: feelingUri,
        success: function (data) {
            $('#steries').empty();
            getCount(data.length);
            $.each(data, function (key, item) {
                $('<tr><td>' + item.id +'</td>' +
                    '<td>' + item.userName + '</td>' +
                    '<td>' + item.comment1 + '</td>' +
                    '<td>' + item.comment2 + '</td>' +
                    '<td>' + item.comment3 + '</td>' +
                    '<td>' + item.elapsedMilliSec + '</td>' +
                    '<td>' + item.createdTime + '</td>' +
                    '</tr>').appendTo($('#steries'));
            });

            todos = data;
        }
    });
}

function getSeedData() {
    $.ajax({
        type: 'GET',
        url: seedUri,
        success: function (data) {
            $('#seeds').empty();
            getCount(data.length);
            $.each(data, function (key, item) {
                $('<tr><td>' + item.id + '</td>' +
                    '<td>' + item.seedType + '</td>' +
                    '<td>' + item.seedTitle + '</td>' +
                    '<td>' + item.seedUrl + '</td>' +
                    '<td>' + "????" + '</td>' +
                    //'<td>' + item.keySteries + '</td>' +
                    '<td>' + item.uploadUserId + '</td>' +
                    '<td>' + item.uploadUserName + '</td>' +
                    '<td>' + item.createdTime + '</td>' +
                    '<td>' + item.updatedTime + '</td>' +
                    '</tr>').appendTo($('#seeds'));
            });

            todos = data;
        }
    });
}

function addItem() {
    const item = {
        'name': $('#add-name').val(),
        'isComplete': false
    };

    $.ajax({
        type: 'POST',
        accepts: 'application/json',
        url: uri,
        contentType: 'application/json',
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert('here');
        },
        success: function (result) {
            getData();
            $('#add-name').val('');
        }
    });
}

function deleteItem(id) {
    $.ajax({
        url: uri + '/' + id,
        type: 'DELETE',
        success: function (result) {
            getData();
        }
    });
}

function editItem(id) {
    $.each(todos, function (key, item) {
        if (item.id === id) {
            $('#edit-name').val(item.name);
            $('#edit-id').val(item.id);
            $('#edit-isComplete')[0].checked = item.isComplete;
        }
    });
    $('#spoiler').css({ 'display': 'block' });
}

$('.my-form').on('submit', function () {
    const item = {
        'name': $('#edit-name').val(),
        'isComplete': $('#edit-isComplete').is(':checked'),
        'id': $('#edit-id').val()
    };

    $.ajax({
        url: uri + '/' + $('#edit-id').val(),
        type: 'PUT',
        accepts: 'application/json',
        contentType: 'application/json',
        data: JSON.stringify(item),
        success: function (result) {
            getData();
        }
    });

    closeInput();
    return false;
});

function closeInput() {
    $('#spoiler').css({ 'display': 'none' });
}