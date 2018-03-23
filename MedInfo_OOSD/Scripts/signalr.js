
var con = $.connection.chatHub;

function hub (massage) {

    $.connection.hub.start()
        .done(function() {

            con.server.announce(massage)
                .done(function() {

                    console.log("Sent");
                })
                .fail(function() {

                    console.log("failed");
                });

        })
        .fail(function() {

            alert("Error !");
        });
}


hub('');

con.client.addMassage = function(userName, massage) {

    if (massage === '') {
        return;
    }

    var text =
        '<div class="panel panel-default" style ="width: 25%"><div class="panel-heading">'+userName+'</div><div class="panel-body">'+massage+'</div></div>';

    document.getElementById("chat-box").innerHTML += text;

    document.querySelector('.form-control').value = '';
}


document.querySelector(".btn").addEventListener("click", function() {

    sendMassage();

});


document.addEventListener("keypress",function(event) {

    if (event.keyCode === 13) {

        sendMassage();

    }

});


function sendMassage() {

    var massage = document.querySelector(".form-control").value;
    hub(massage);

}



