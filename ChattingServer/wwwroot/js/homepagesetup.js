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
}

function CompleteSetup() {
    // remove the model
    var modal = document.getElementById("userNameModelId");
    modal.style.display = "none";

    var userName = (document.getElementById("userNameInputId")).value;

    //set username at top left
    var userNameLabel = (document.getElementById("userNameLabelId"));
    userNameLabel.innerHTML = userName;
}

// Buttons
function StartConnection() {

}

function CloseConnection() {

}

function SendMessage() {

}

//document.addEventListener('DOMContentLoaded', ready);
setTimeout(DisplayModal, 50);