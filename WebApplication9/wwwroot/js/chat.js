"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/Chat").configureLogging(signalR.LogLevel.Information).build();
//var connection = new signalR.HubConnectionBuilder()
//    .withUrl("/Chat", {
//        accessTokenFactory: () => this.accessTokenFactory
//    })
//    .build();

//Disable send button until connection is established  
document.getElementById("sendBtn").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&").replace(/</g, "<").replace(/>/g, ">");
    var encodedMsg = user + " says " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("ulmessages").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("sendBtn").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendBtn").addEventListener("click", function (event) {
    var user = (document.getElementById("txtUserName")).value;
    //var groupElement = document.getElementById("group");
    //var groupValue = groupElement.options[groupElement.selectedIndex].value;
    var message = document.getElementById("txtmessage").value;
    console.error(user);
    console.error(message);
    connection.invoke("SendPrivateMessage","421949b7-9bcb-4e9d-b0ae-0a0f2c5fd0ff",  message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});