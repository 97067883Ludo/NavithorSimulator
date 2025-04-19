namespace TcpServer;

public interface ITcpServer
{
    public byte[] Receive();

    public bool Send(byte[] dataToSend);
}