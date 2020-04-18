using Newtonsoft.Json;
using System;

namespace ChattingServer.Models
{
  /// <summary>
  ///  Model used to represent a chat room message. This model is sent to the client
  /// </summary>
  public class ChatRoomMessage
  {
    [JsonProperty(PropertyName = "govender")]
    public string UserName { get; set; }

    [JsonProperty(PropertyName = "Message")]
    public string Message { get; set; }

    [JsonProperty(PropertyName = "TimeSent")]
    public DateTimeOffset TimeSent { get; set; }
  }
}