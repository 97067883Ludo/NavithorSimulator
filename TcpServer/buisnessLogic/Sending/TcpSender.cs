using common.Data.Sending;

namespace TcpServer.buisnessLogic.Sending;

public class TcpSender : TcpServer
{
    public static Queue<SendTask> SendQueue { get; set; } = new();
    
    public TcpSender()
    {
        
    }
    
    public void Send()
    {
        SendTask task = SendQueue.Dequeue();

        if (_tcpClient.Connected)
        {
            _tcpClient.Client.Send(TaskConverter.ToBytes(task));
        }
    }
}