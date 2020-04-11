using System;
using System.Threading.Tasks;
using ClientChatter.Model;
using Microsoft.AspNetCore.SignalR.Client;

namespace ClientChatter
{
  public class ConnectionManager : IConnectionManager
  {
    private readonly HubConnection _connection;

    public ConnectionManager(HubConnection connection)
    {
      _connection = connection;
    }

    public void RegisterEventHandlers()
    {
      Console.WriteLine($"Registering Reconnecting Event");
      //When a connection is lost , the HubConnection will transition to the HubConnectionState.Reconnecting state and fire
      //the Reconnecting event. This provides an opportunity to warn users that the connection has been lost 
      _connection.Reconnecting += Connection_Reconnecting;

      Console.WriteLine($"Registering Reconnected Event");
      //If the client successfully reconnects within its first four attempts, the HubConnection will transition back to the Connected state
      //and fire the Reconnected event. Since the connection looks entirely new to the server, a new ConnectionId will be provided to the
      //Reconnected event handlers.
      _connection.Reconnected += Connection_Reconnected;

      Console.WriteLine($"Registering Closed Event");
      //If the client doesn't successfully reconnect within its first four attempts, the HubConnection will transition to the Disconnected
      //state and fire the Closed event. This provides an opportunity to attempt to restart the connection 
      _connection.Closed += Connection_Closed;

    }

    //------------------------------------------------------------------------------------------------------------------------------------------------
    public void RegisterClientMethods()
    {
      //Define methods the server/hub calls. Must be specified but before starting the connection.

      Console.WriteLine($"Registering 'Welcome' Method Handler ");
      _connection.On<ChatRoomMessage>("Welcome", (message) =>
      {
        Console.WriteLine($"Message Received from hub");
        Console.WriteLine($"From: {message.UserName} - Sent: {message.TimeSent} - Message: {message.Message}");
      });


      Console.WriteLine($"Registering 'ReceiveMessage' Method Handler ");
      _connection.On<ChatRoomMessage>("ReceiveMessage", (message) =>
      {
        Console.WriteLine($"Message Received from hub");
        Console.WriteLine($"From: {message.UserName} - Sent: {message.TimeSent} - Message: {message.Message}");
      });
    }
    //------------------------------------------------------------------------------------------------------------------------------------------------

    //------------------------------------------------------------------------------------------------------------------------------------------------
    public async Task StartConnection()
    {
      // Starts a connection to the server.
      Console.WriteLine($"Starting Hub Connection ");
      try
      {
        await _connection.StartAsync();
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error when starting connection - {ex}");
      }
    }
    //------------------------------------------------------------------------------------------------------------------------------------------------

    //------------------------------------------------------------------------------------------------------------------------------------------------
    //The client has SendAsync which is fire - and - forget and InvokeAsync which waits for a completion message from the server.https://github.com/aspnet/SignalR/issues/1300
    //Invokes a hub method on the server using the specified method name.
    public async Task Send_MessageToAll_ToServer()
    {
      Console.WriteLine($"Call to 'SendMessageToAll' method on hub/server ");
      try
      {
        await _connection.InvokeAsync("SendMessageToAll", "Hi");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Exception on Send Message: {ex}");
      }
    }
    //------------------------------------------------------------------------------------------------------------------------------------------------

    //------------------------------------------------------------------------------------------------------------------------------------------------
    private static Task Connection_Reconnecting(Exception arg)
    {
      Console.WriteLine($"Reconnecting");
      return Task.CompletedTask;
    }
    //------------------------------------------------------------------------------------------------------------------------------------------------

    //------------------------------------------------------------------------------------------------------------------------------------------------
    private static Task Connection_Reconnected(string arg)
    {
      Console.WriteLine($"Reconnected with connection id {arg} ");
      return Task.CompletedTask;
    }
    //------------------------------------------------------------------------------------------------------------------------------------------------

    //------------------------------------------------------------------------------------------------------------------------------------------------
    private static Task Connection_Closed(Exception arg)
    {
      Console.WriteLine($"Connection Closed ");
      //await Task.Delay(new Random().Next(0, 5) * 1000);
      //await _connection.StartAsync();
      return Task.CompletedTask;
    }
    //------------------------------------------------------------------------------------------------------------------------------------------------
  }
}