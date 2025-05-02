using System.Net;
using System.Net.Sockets;
using common.Data.Sending;
using TcpServer.buisnessLogic.Sending;

namespace TcpServer;

public class TcpServer : ITcpServer
{
    private TcpListener _tcpListener { get; init; }

    private WewoTcpListener _wewoTcpListener { get; set; }

    private TcpSender _tcpSender { get; set; } = new();

    protected TcpClient _tcpClient { get; set; } = new();

    public TcpServer()
    {
        _wewoTcpListener = new WewoTcpListener();
        _tcpListener = new TcpListener(IPAddress.Any, 8015);
        _tcpListener.Start();
    }
    
    public void Send(SendTask dataToSend)
    {
        
        _tcpSender.AddMessageToQueue(dataToSend);
    }
    
    public void StartServer()
    {
        Start();
        Console.WriteLine("Server started");
    }

    public void Start()
    {
        Task.Run(() =>
        {
            _tcpClient = _tcpListener.AcceptTcpClient();
            _tcpSender.Start(_tcpClient);
            _wewoTcpListener.StartListing(_tcpClient);
        });
    }
    
}