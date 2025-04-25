using System.Net;
using System.Net.Sockets;
using TcpServer.buisnessLogic.Sending;

namespace TcpServer;

public class TcpServer : ITcpServer
{
    private TcpListener _tcpListener { get; init; }

    private WewoTcpListener _wewoTcpListener { get; set; }

    private TcpSender _tcpSender { get; set; } = new();
    
    protected TcpClient _tcpClient { get; set; }

    public TcpServer()
    {
        _tcpListener = new TcpListener(IPAddress.Any, 8015);
        _tcpListener.Start();
        _wewoTcpListener = new(this);
    }
    
    public bool Send(byte[] dataToSend)
    {
        throw new NotImplementedException();
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
            _wewoTcpListener.StartListing(_tcpClient);
        });
    }
    
}