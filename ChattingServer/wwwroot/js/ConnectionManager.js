/// <reference path="../lib/signalr/signalr.js" />
/// <reference path="../js/Models/ChatRoomMessage.js"/>

"use strict";

function ConnectionManager() {

    //---------------------------------------------------------------------------------------------------------------------------------------
    //Private Methods and Members

    // Create Hub Connection
    var _clientChatterConnection = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:44333/chatroom")
        .build();


    //Private Functions

    //Move this DisplayMessage Code Out!!!!
    var displayMessage = function (message) {
        var eleTextAreaChatHistory = document.getElementById('chatMsgTextAreaId');
        eleTextAreaChatHistory.value += JSON.stringify(message);
    }


    var handleWelcome = function (message) {
        console.log(`Welcome Received from hub`);
        console.log(`From: ${message.UserName} - Sent: ${message.TimeSent} - Message: ${message.Message}`);
        displayMessage(message);
    }

    var handleReceiveMessage = function (message) {
        console.log(`Received Message Received from hub`);
        console.log(`From: ${message.UserName} - Sent: ${message.TimeSent} - Message: ${message.Message}`);
        displayMessage(message);
    }

    var handleOnClosedEvent = function () {
        console.log(`Received On Closed Event`);
    }



    //---------------------------------------------------------------------------------------------------------------------------------------


    //---------------------------------------------------------------------------------------------------------------------------------------
    //Public Methods
    //Start the Hub Connection
    this.StartConnection = function () {
        _clientChatterConnection.start()
            .catch((err) => console.error(err.toString()));
    }

    this.CloseConnection = function() {
        _clientChatterConnection.stop()
            .catch((err) => console.error(err.toString()));
    }


    this.RegisterClientMethods = function () {
        //Define methods the server/hub calls. Must be specified but before starting the connection.

        console.log(`Registering 'Welcome' Method Handler `);
        _clientChatterConnection.on('Welcome', handleWelcome);

        console.log(`Registering 'ReceiveMessage' Method Handler `);
        _clientChatterConnection.on('ReceiveMessage', handleReceiveMessage);
    }

    this.RegisterEventHandlers = function () {

        console.log(`Registering Closed Event`);
        _clientChatterConnection.onclose(handleOnClosedEvent);

    }

    this.Send_MessageToAll_ToServer = function (fromUsername, message) {
        console.log(`Call to "SendMessageToAll" method on hub/server`);

        var currentTime = new Date();
        var chatRoomMessage = new ChatRoomMessage(fromUsername, message, currentTime);

        _clientChatterConnection.invoke('SendMessageToAll', chatRoomMessage)
            .catch((err) => console.log(err.toString()));

    }

    this.Send_MessageToGroup_ToServer = function (groupName, fromUsername, message) {
        console.log(`Call to "SendMessageToUserGroup" method on hub/server`);

        var currentTime = new Date();
        var chatRoomMessage = new ChatRoomMessage(fromUsername, message, currentTime);

        _clientChatterConnection.invoke('SendMessageToUserGroup', groupName, chatRoomMessage)
            .catch((err) => console.log(err.toString()));

    }
    //---------------------------------------------------------------------------------------------------------------------------------------
}
