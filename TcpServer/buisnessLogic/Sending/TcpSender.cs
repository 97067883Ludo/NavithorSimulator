using System.Net.Sockets;
using common.Data.Sending;
using Contracts.TCP_Contracts;

namespace TcpServer.buisnessLogic.Sending;

public class TcpSender : ISendingContract
{
    private Queue<SendTask> SendQueue { get; set; } = new();

    private TcpClient _tcpClient;

    private void Send()
    {
        if (!_tcpClient.Connected) return;

        SendTask task = SendQueue.Dequeue();
        
        byte[] data = TaskConverter.ToBytes(task);
        _tcpClient.Client.Send(data);
    }

    public void Start(TcpClient client)
    {
        _tcpClient = client;
        
    }

    private void AddMessageToQueue(SendTask dataToSend)
    {
        SendQueue.Enqueue(dataToSend);
        Send();
    }

    public void SendMessage(SendTask message)
    {
        AddMessageToQueue(message);
    }
}