using System.Net;
using System.Net.Sockets;
using common.Data.EventArgs;
using common.Data.FrameUtils;

namespace TcpServer.buisnessLogic;

public class WewoTcpListener : IWewoTcpListener
{
    public static event OnReceive OnReceive;
    
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
                NetworkStream stream = handler.GetStream();
                byte[] header = new byte[9];
                stream.ReadExactly(header);
                Frame frame = FrameInterpeter.Deserialize(header);
                byte[] data = new byte[frame.DataLength];
                stream.ReadExactly(data);
                OnReceive.Invoke(this, new OnReceiveArgs(frame, data));
            }
        });
    }
}

public delegate void OnReceive(object sender, OnReceiveArgs args);