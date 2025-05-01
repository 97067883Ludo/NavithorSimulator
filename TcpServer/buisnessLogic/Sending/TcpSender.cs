using System.Net.Sockets;
using common.Data.Sending;

namespace TcpServer.buisnessLogic.Sending;

public class TcpSender
{
    private Queue<SendTask> SendQueue { get; set; } = new();

    private TcpClient _tcpClient;
    
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

    public void Start(TcpClient client)
    {
        _tcpClient = client;
        
    }

    public void AddMessageToQueue(SendTask dataToSend)
    {
        SendQueue.Enqueue(dataToSend);
        Send();
    }

}