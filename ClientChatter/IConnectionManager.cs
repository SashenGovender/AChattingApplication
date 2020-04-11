using System.Threading.Tasks;
using ClientChatter.Model;

namespace ClientChatter
{
  public interface IConnectionManager
  {
    void RegisterEventHandlers();
    void RegisterClientMethods();
    Task StartConnection();
    Task Send_MessageToAll_ToServer(ChatRoomMessage message);
  }
}