"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

// Disable send buttion until connection is established
document.getElementById("sendButton").disable = true;

connection.on("ReceiveMessage", function(user, message){
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " says" + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messageList").appendChild(li);
});

connection.start().then(function(){
    document.getElementById("sendButton").disable = false;
}).catch(function(err){
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function(event){
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err){
        return console.error(err.toString());
    });

    event.preventDefault();
})