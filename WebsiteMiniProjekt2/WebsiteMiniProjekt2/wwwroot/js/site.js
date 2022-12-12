"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/webHub").build();

//Disable the send button until connection is established.

connection.on("ReceiveMessage", function (user, message) {
});

connection.start().then(function () {
    connection.invoke("PrintString", 123).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

document.getElementById("sendMessageButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

connection.on("checkYourCode", function (code) {
    connection.invoke("PrintString", code).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});