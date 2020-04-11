using System.Threading.Tasks;

namespace ClientChatter
{
  public interface IConnectionManager
  {
    void RegisterEventHandlers();
    void RegisterClientMethods();
    Task StartConnection();
    Task Send_MessageToAll_ToServer();
  }
}