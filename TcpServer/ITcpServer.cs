namespace TcpServer;

public interface ITcpServer
{
    public bool Send(byte[] dataToSend);
    
    public void StartServer();
}