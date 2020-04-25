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
* Next, Navigate ClientChatter project and edit the path variable to point to your c# console bin executable.
* Start the hub server by running ChattingServer project without debugging
* Open in a new chrome tab the JavaScript client
* Finally, Execute 'RunClientChatter.bat' file. to create 2 c# console clients 
```
http://localhost:58878/html/homepage.html
```

## Resources
All images were sourced from various interest sites

## Todo
* Dev test of csharp client
* Add JavaScript signal r logic
* Dev test of JavaScript client
* Dev test server hub

## Authors
* Sashen Govender

