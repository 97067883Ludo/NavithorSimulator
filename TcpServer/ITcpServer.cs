using common.Data.Sending;

namespace TcpServer;

public interface ITcpServer
{
    public void Send(SendTask dataToSend);
    
    public void StartServer();
}