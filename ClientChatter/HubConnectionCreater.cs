using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;

namespace ClientChatter
{
  public static class HubConnectionCreater
  {
    public static HubConnection CreateHubConnection()
    {

      //Create Hub Connection
      var connection =
        new HubConnectionBuilder() //create a signal r hub. Requires Microsoft.AspNetCore.SignalR.Client nuget
          .WithUrl("https://localhost:44333/chatroom") //The URL the connection will use.
          .ConfigureLogging(logging =>
          {
            logging.AddConsole(); //Add a console logger for signal r. Requires Microsoft.Extensions.Logging.Console nuget
            logging.SetMinimumLevel(LogLevel.Information);
          })
          //The HubConnection can be configured to automatically reconnect.By default AutomaticReconnect configures the client to wait
          //0, 2, 10, and 30 seconds respectively before trying each reconnect attempt, stopping after four failed attempts 
          //.WithAutomaticReconnect()
          .Build();

      return connection;
    }
  }
}