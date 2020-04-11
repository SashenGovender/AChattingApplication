﻿using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ClientChatter
{
  public class Program
  {
    static async Task Main(string[] args)
    {

      //Create Hub Connection
      var connection = HubConnectionCreater.CreateHubConnection();
      var connectionManager = new ConnectionManager(connection);
      connectionManager.SetUserName(args);

      connectionManager.RegisterEventHandlers();

      connectionManager.RegisterClientMethods();

      await connectionManager.StartConnection();
    }
  }
}
