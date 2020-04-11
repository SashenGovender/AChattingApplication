using System;

namespace ChattingServer.Models
{
  /// <summary>
  ///  Model used to represent a chat room message. This model is sent to the client
  /// </summary>
  public class ChatRoomMessage
  {
    public string UserName { get; set; }

    public string Message { get; set; }

    public DateTimeOffset TimeSent { get; set; }
  }
}