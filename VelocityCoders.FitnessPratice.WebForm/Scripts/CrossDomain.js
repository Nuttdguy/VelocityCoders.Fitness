function createCORSRequest(method, url) {
    var xhr = new XMLHttpRequest();

    if ("withCredentials" in xhr) {
        xhr.open(method, url, true);
    } else if (typeof XDomainRequest != "undefined") {
        xhr = new XDomainRequest();
        xhr.open(method, url);
    } else {
        xhr = null;
    }
    return xhr;
}


var request = createCORSRequest("get", "http://www.google.com");

if (request) {
    request.onload = function () { };
    request.send();
}


$.get('http://cors-support.com/api', function (data) {
    alert('Successful cross-domain AJAX request.');
})