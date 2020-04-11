using System.Threading.Tasks;
using ChattingServer.Models;

namespace ChattingServer.Hubs
{
  /// <summary>
  /// Defines a contract representing the client side method signatures
  /// </summary>
  public interface IChatRoomClient
  {
    Task Welcome(ChatRoomMessage chatMessage);
    Task ReceiveMessage(ChatRoomMessage message);
  }
}