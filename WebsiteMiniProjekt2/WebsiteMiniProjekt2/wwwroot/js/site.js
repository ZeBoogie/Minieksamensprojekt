﻿"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/webHub").build();

//Disable the send button until connection is established.
document.getElementById("Submit").disabled = true;



connection.on("ReceiveMessage", function (user, message) {
});

connection.start().then(function () {
    document.getElementById("Submit").disabled = false;
    connection.invoke("PrintString", "connection started").catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

//when submit is clicked (this button is only on landing page (index)) then
//get the code in the forms, and ask the webserver if the code is valid.
//if this is the case, then it switches the current page to waiting page
document.getElementById("Submit").addEventListener("click", function (event) {
    var code = document.getElementById("QuizCode").value //this is a string!
    connection.invoke("AttemptedLogin", code).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});


//when name is submittet, on namepage, this should be called

/* for now this will stop everything wroker, without an error, if it exists...
document.getElementById("submitName").addEventListener("click", function (event) {
    var code = document.getElementById("QuizCode").value //this is a string!
    connection.invoke("AttemptedLogin", code).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});
*/

//method to receive commands on which page the webpage should be on.
connection.on("goToPage", function (nameOfPage) {
    connection.invoke("PrintString", "page to go to is: " + nameOfPage).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
    window.location.replace("/" + nameOfPage);

});

connection.on("wrongStatement", function (errorStatement) {
    var textToShow = "Sorry, that " + errorStatement + " is invalid!";
    document.getElementById("topText").innerHTML =  textToShow;
});