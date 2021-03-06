﻿using System;

namespace ClientChatter.Model
{

  /// <summary>
  /// Message Model received from hub
  /// </summary>
  public class ChatRoomMessage
  {
    public string UserName { get; set; }

    public string Message { get; set; }

    public DateTimeOffset TimeSent { get; set; }
  }
}