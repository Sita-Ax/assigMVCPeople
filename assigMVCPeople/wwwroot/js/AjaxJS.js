function getAjaxPeopleList(actionUrl) {
    $.get(actionUrl, function (response) {
        console.log("Ajax Response: ", response);
        document.getElementById("result").innerHTML = response;
    });
}

function ajaxPost(actionUrl, idName) {
    let inputElement = $("#" + idName);
    var data = {
        [inputElement.attr("name")]: inputElement.val()
    }
    console.log("inputEl: ", inputElement);
    console.log("data: ", data);
    $.post(actionUrl, data, function (response) {
        console.log("Response", response);
        document.getElementById("result").innerHTML = response;
    })
}

function postSearch(actionUrl, inputSerach) {
    let inputElement = $("#" + inputSerach)
    let data = {
        [inputElement.attr("name")]: inputElement.val()
    }
    console.log("inputEl: ", inputElement);
    console.log("data: ", data);
    $.post(actionUrl + "?serach=" + data.serach, function (response) {
        console.log("Response", response);
        document.getElementById("result").innerHTML = response;
    });
}

function verifyAnswer() {
    document.getElementById("searchName").disabled = true;
    document.getElementById("serachCity").disabled = true;
    var dev = document.getElementById("isActive").checked;
    if (dev == true) {
        document.getElementById("searchName").disabled = false;
        document.getElementById("serachCity").disabled = false;
    }
}