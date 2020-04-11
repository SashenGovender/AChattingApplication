# A Chatting Application
This project servers as an introduction into real time messaging using signal r. It is a simple chat application that consists the following
* A c# core console application client that will receive messages
* A JavaScript signal r client that will send messages to all other clients
* A c# core web api that will act as the server hub for message processing

The JavaScript client provides options to target messages at
* Group - All clients connections that are part of the same signal r group
* User - A specific user connection
* All - All connected client connections 

## Getting Started
Please follow the below steps to setup the solution on your machine

### Prerequisites
* Visual Studio 
* Chrome

### Installing
* Pull the code from github into your ide
* Restore Nuget Packages
* Build Solution
* Next, Navigate to the console bin folder and execute the ClientChatter.exe using the command prompt. This allows you to set the clients user name
...
ClientChatter.exe emily
... 
* Start the hub server by running ChattingServer project without debugging
* Lastly, open in a new chrome tab the JavaScript client
...
http://localhost:5000/homepage.html
...

## Deployment
Add additional notes about how to deploy this on a live system

## Resources
All images were sourced from various interest sites

## Todo
* Dev test of csharp client
* Add JavaScript signal r logic
* Dev test of JavaScript client
* Dev test server hub

## Authors
* Sashen Govender

