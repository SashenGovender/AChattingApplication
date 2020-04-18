/// <reference path="../js/ConnectionManager.js"/>
"use strict";
//---------------------------------------------------------------------------------------------------------------------------------------
//Globals
var connectionManager;
var userName;
//---------------------------------------------------------------------------------------------------------------------------------------

//---------------------------------------------------------------------------------------------------------------------------------------
//Helper Functions
//function GetElementInsideContainer(containerId, childId) {
//    var elm = document.getElementById(childId);
    //var parent = elm ? elm.parentNode : {};
    //return (parent.id && parent.id === containerId) ? elm : {};
 //   return elm;
//}

//---------------------------------------------------------------------------------------------------------------------------------------


//---------------------------------------------------------------------------------------------------------------------------------------
//Modal Logic
//Display a modal for the user to set their username
function DisplayModal() {

    var modal = document.getElementById("userNameModelId"); // Get the modal
    modal.style.display = "block"; //Display the model

    var span = document.getElementsByClassName("close")[0]; // Get the <span> element that closes the modal
    // When the user clicks on <span> (x), close the modal
    span.onclick = function () {
        modal.style.display = "none";
    }

    var eleTextboxName = document.getElementById("userNameInputId");
    // Execute a function when the user releases a key on the keyboard
    eleTextboxName.addEventListener("keyup", function (event) {
        // Number 13 is the "Enter" key on the keyboard
        if (event.keyCode === 13) {
            // Cancel the default action, if needed
            event.preventDefault();
            // Trigger the button element with a click
            document.getElementById("continueBtnId").click();
        }
    });
}
//---------------------------------------------------------------------------------------------------------------------------------------


function CompleteSetup() {
    // remove the model
    var modal = document.getElementById("userNameModelId");
    modal.style.display = "none";

    var username = (document.getElementById("userNameInputId")).value;

    //set username at top left
    var userNameLabel = (document.getElementById("userNameLabelId"));
    userNameLabel.innerHTML = username;
    userName = username; //set global access to user name

}
//---------------------------------------------------------------------------------------------------------------------------------------

// Buttons
function StartConnection() {

    connectionManager = new ConnectionManager();

    connectionManager.RegisterClientMethods();
    connectionManager.RegisterEventHandlers();

    connectionManager.StartConnection();

    var eleBtnCloseConnection = document.getElementById("closeConnectionBtnId");
    eleBtnCloseConnection.removeAttribute("disabled");

    var eleBtnSendMessage = document.getElementById("sendMessageBtnId");
    eleBtnSendMessage.removeAttribute("disabled");
}

function CloseConnection() {
    connectionManager.CloseConnection();

    var eleBtnCloseConnection = document.getElementById("closeConnectionBtnId");
    eleBtnCloseConnection.setAttribute("disabled", "disabled");

    var eleBtnSendMessage = document.getElementById("sendMessageBtnId");
    eleBtnSendMessage.setAttribute("disabled", "disabled");

    var eleBtnStartConnection = document.getElementById("startConnectionBtnId");
    eleBtnStartConnection.removeAttribute("disabled");
}

function SendMessage() {

    var eleRadioAll = document.getElementById("allRadioId");
    var eleRadioGroup = document.getElementById("groupRadioId");
    var eleRadioUser = document.getElementById("userRadioId");

    var eleTextAreaMessageToSend = document.getElementById("messageTextAreaId");
    if (eleRadioAll.checked) {
        connectionManager.Send_MessageToAll_ToServer(userName, eleTextAreaMessageToSend.value);
    }

    else if (eleRadioGroup.checked) {
        var eleTextboxGroup = document.getElementById("groupTextboxId");
        if (eleTextboxGroup.value.length === 0) {
            alert(`Please Specify a Group`);
        } else {
            connectionManager.Send_MessageToGroup_ToServer(eleTextboxGroup.value, userName, eleTextAreaMessageToSend.value);
        }
    }

    else if (eleRadioUser.checked) {
        var eleTextboxUser = document.getElementById("userTextboxId");
        if (eleTextboxUser.value.length === 0) {
            alert(`Please Specify a Group`);
        } else {
            connectionManager.Send_MessageToGroup_ToServer(eleTextboxUser.value, userName, eleTextAreaMessageToSend.value);
        }
    }

    else {
        alert(`Message Audience Not selected`);
        return;
    }






}




//document.addEventListener('DOMContentLoaded', ready);
setTimeout(DisplayModal, 50);