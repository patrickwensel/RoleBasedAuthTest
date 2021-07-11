"use strict";

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/Chat?userId=" + btoa((document.getElementById("userID")).value))
    .configureLogging(signalR.LogLevel.Information)
    .build();


//Disable send button until connection is established  
document.getElementById("sendBtn").disabled = true;

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
        document.getElementById("sendBtn").disabled = false;
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

connection.onclose(start);

// Start the connection.
start();

connection.on("broadcastIndividualMessage", (message) => {
    console.log("broadcastIndividualMessage");
    console.log(message);
    var msg = message.replace(/&/g, "&").replace(/</g, "<").replace(/>/g, ">");
    var li = document.createElement("li");
    li.innerHTML = msg;
    document.getElementById("ulmessages").prepend(li);
});

connection.on("offlineUserMessage", (message) => {
    alert(message);
});

connection.on("UserConnected", function (connectionId) {
    //var groupElement = document.getElementById("group");
    //var option = document.createElement("option");
    //option.text = connectionId;
    //option.value = connectionId;
    //groupElement.add(option);   
});

connection.on("UserDisconnected", function (connectionId) {
    //var groupElement = document.getElementById("group");
    //for (var i = 0; i < groupElement.length; i++) {
    //    if (groupElement.options[i].value == connectionId) {
    //        groupElement.remove(i);
    //    }
    //}
});

document.getElementById("sendBtn").addEventListener("click", async function (event) {
    var ddlUserListElement = document.getElementById("ddlUserList");
    var userId = ddlUserListElement.options[ddlUserListElement.selectedIndex].value;
    var message = document.getElementById("txtmessage").value;
    if (message === "") {
        alert("Please enter a valid message");
        return;
    }
    if (userId === "") {
        alert("Please select an User");
        return;
    }
    console.error(userId);
    console.error(message);
    try {
        await connection.invoke("SendIndividualMessage", "test", userId, message).then(function (result) {
            console.log("invocation completed successfully: " + (result === null ? '(null)' : result));
        }).catch(function (err) {
            return console.error(err.toString());
        });
    } catch (err) {
        console.error(err);
    }
    event.preventDefault();
});