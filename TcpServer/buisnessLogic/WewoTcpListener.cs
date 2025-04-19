using System.Net;
using System.Net.Sockets;

namespace TcpServer.buisnessLogic;

public class WewoTcpListener : IWewoTcpListener
{
    private TcpListener _tcpListener { get; init; }

    private bool Listening { get; set; }

    public WewoTcpListener()
    {
        _tcpListener = new TcpListener(IPAddress.Any, 8015);
    }

    public bool StartServer()
    {
        try
        {
            _tcpListener.Start();
            StartListing();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }

        return true;
    }

    private void StartListing()
    {
        Task.Run(async () =>
        {
            while (true)
            {
                Console.WriteLine("Startlistening");
                Listening = true;
                using TcpClient handler = await _tcpListener.AcceptTcpClientAsync();
                await using NetworkStream stream = handler.GetStream();
                byte[] buffer = new byte[9];
                if (stream.Read(buffer) == 9)
                {
                    
                }
            }
        });
    }

}