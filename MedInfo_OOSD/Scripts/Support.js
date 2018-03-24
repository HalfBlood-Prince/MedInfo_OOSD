
var bridge = $.connection.chatHub;

var con = (function() {

    var con;

    $.connection.hub.start()
        .done(function() {

            con = true;
            console.log("connected");
            bridge.server.addUser();

        })
        .fail(function() {

            con = false;
            alert("Error !");

        });


    return con;

})();


bridge.client.showError = function () {

    var block = "block";
    var none = "none";

    document.getElementById('error-massage').style.display = block;
    var nodes = document.querySelectorAll('.form-control, .chat');

    console.log(nodes);

    for (var i = 0; i < nodes.length; i++) {

        nodes[i].style.display = none;
    }

}

bridge.client.onConnected = function() {

    var block = "block";
    var none = "none";

    document.getElementById('error-massage').style.display = none;
    var nodes = document.querySelectorAll('.chat-box, .chat');

    for (var i = 0; i < nodes.length; i++) {

        nodes[i].style.display = block;
    }

}


bridge.client.writeMassage = function(userName, massage) {


    var html = '<div class="panel panel-default" style ="width: 25%"><div class="panel-heading">' + userName + '</div><div class="panel-body">' + massage + '</div></div>';

    document.getElementById("chat-box").innerHTML += html;
    document.querySelector('.form-control').value = '';

}




document.querySelector(".btn").addEventListener("click", function() {

    sendMassage();

});



document.addEventListener("keypress", function(event) {


    if (event.keyCode === 13) {

        sendMassage();
    }

});


function sendMassage() {

    var massage = document.querySelector(".form-control").value;

    bridge.server.sendMassage(massage);
}