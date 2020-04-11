using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using ClientChatter.Model;
using Microsoft.Extensions.Logging;

namespace ClientChatter
{
  public class Program
  {
    [SuppressMessage("Style", "IDE0060:Remove unused parameter")]
    static async Task Main(string[] args)
    {

      //Create Hub Connection
      var connection = HubConnectionCreater.CreateHubConnection();
      var connectionManager = new ConnectionManager(connection);

      connectionManager.RegisterEventHandlers();

      connectionManager.RegisterClientMethods();

      await connectionManager.StartConnection();

      //await connectionManager.Send_MessageToAll_ToServer(BuildMessage(args[0]));
    }

    public static ChatRoomMessage BuildMessage(string name)
    {
      var message = new ChatRoomMessage
      {
        UserName = name,
        Message = "Hello everyone",
        TimeSent = DateTimeOffset.UtcNow
      };

      return message;
    }
  }
}
