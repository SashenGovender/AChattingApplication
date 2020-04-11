using System;
using System.Threading.Tasks;
using ChattingServer.Models;
using Microsoft.AspNetCore.SignalR;

namespace ChattingServer.Hubs
{
  /// <summary>
  /// A hub servicing the chatroom channel that will send client messages based on IChatroomClient signatures. Clients can call methods that are defined as public.
  /// </summary>
  public class ChatRoomHub : Hub<IChatRoomClient>
  {
    //------------------------------------------------------------------------------------------------------------------------------------------------
    public ChatRoomHub()
    {

    }
    //------------------------------------------------------------------------------------------------------------------------------------------------

    //------------------------------------------------------------------------------------------------------------------------------------------------
    // Send Messages to all connected clients
    [HubMethodName("SendMessageToAll")]
    public async Task SendMessage(string userName, string userMessage)
    {
      var message = new ChatRoomMessage
      {
        UserName = userName,
        Message = userMessage,
        TimeSent = DateTimeOffset.UtcNow
      };

      // Broadcast to all clients
      await Clients.All.ReceiveMessage(message);
    }
    //------------------------------------------------------------------------------------------------------------------------------------------------

    //------------------------------------------------------------------------------------------------------------------------------------------------
    // sends a message to all clients in the SignalR Users group
    [HubMethodName("SendMessageToUserGroup")]
    public async Task SendMessageUserGroup(string userMessage)
    {
      var group = "uniquegroup";
      //group = GetGroup(Context.ConnectionId);

      var message = new ChatRoomMessage
      {
        UserName = "chatbot",
        Message = userMessage,
        TimeSent = DateTimeOffset.UtcNow
      };

      await Clients.Group(group).ReceiveMessage(message);

    }
    //------------------------------------------------------------------------------------------------------------------------------------------------

    //------------------------------------------------------------------------------------------------------------------------------------------------
    public override async Task OnDisconnectedAsync(Exception ex)
    {
      await base.OnDisconnectedAsync(ex);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------
    public override async Task OnConnectedAsync()
    {
      //Added new connection to a specific group
      //todo: how do i create unique groups?
      var group = "uniquegroup";
      // group = CreateGroup(Context.ConnectionId);

      await Groups.AddToGroupAsync(Context.ConnectionId, group);

      var message = new ChatRoomMessage
      {
        UserName = "chatbot",
        Message = "Hi there, Welcome to Premium Chat",
        TimeSent = DateTimeOffset.UtcNow
      };

      //sends a message back to the caller
      await Clients.Caller.Welcome(message);

      //await base.OnConnectedAsync();
    }
    //------------------------------------------------------------------------------------------------------------------------------------------------
  }
}