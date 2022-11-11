function getAjaxPeopleList(actionUrl) {
    $.get(actionUrl, function (response) {
        console.log("Ajax Response: ", response);
        document.getElementById("result").innerHTML = response;
    });
}

function ajaxPost(actionUrl, idName) {
    let inputElement = $("#" + idName);
    var data = {
        [inputElement.attr("idName")]: inputElement.val()
    }
    $.post(actionUrl, data, function (response) {
        document.getElementById("result").innerHTML = response;
    })
}