using System.Net;
using System.Net.Sockets;
using Autofac;
using Contracts.TCP_Contracts;
using TcpServer.buisnessLogic.Receiving;
using TcpServer.buisnessLogic.Sending;

namespace TcpServer;

public class TcpServer : ITcpServer, IStartable
{
    private TcpListener _tcpListener { get; init; }

    private WewoTcpListener _wewoTcpListener { get; }

    private TcpSender _tcpSender { get; }

    private TcpClient _tcpClient { get; set; } = new();

    public TcpServer(ISendingContract sender, IReceivingContract receiver)
    {
        _wewoTcpListener = new WewoTcpListener(receiver); // TODO: Use Autofac to inject the receiver.
        _tcpSender = sender as TcpSender ?? throw new ArgumentNullException(nameof(sender), "Sender must be of type TcpSender");
        _tcpListener = new TcpListener(IPAddress.Any, 8015);
        _tcpListener.Start();
        Start();
    }
    
    public void Start()
    {
        Task.Run(() =>
        {
            while (true) // TODO: make some kind of way to stop the server.
            {
                _tcpClient = _tcpListener.AcceptTcpClient();
                _tcpSender.Start(_tcpClient);
                _wewoTcpListener.StartListing(_tcpClient);
                _wewoTcpListener.Dispose();   
            }
        });
    }
   
}