using System.Net;
using System.Net.Sockets;
using common.Data.EventArgs;
using common.Data.FrameUtils;

namespace TcpServer;

public class WewoTcpListener : IWewoTcpListener
{
    public static event OnReceive? OnReceive;
    
    private bool Listening { get; set; }
    
    public WewoTcpListener()
    {

    }

    public void StartListing(TcpClient handler)
    {
        while (handler.Connected)
        {
            Listening = true;
            var stream = handler.GetStream();
            var header = new byte[9];
            var frameSize = stream.Read(header);
            while (frameSize < 9)
            {
                frameSize = stream.Read(header);
                if (!handler.Connected) goto EndPoint;
            }

            var frame = FrameInterpeter.Deserialize(header);
            var data = new byte[frame.DataLength];
            var dataSize = stream.Read(data);
            while (dataSize < frame.DataLength)
            {
                dataSize = stream.Read(data);
                if (!handler.Connected) goto EndPoint;
            }

            OnProcessCompleted(frame, data);

            EndPoint: ;
        }

        Console.WriteLine("Stopped Listening");
        handler.Dispose();
    }
    
    protected virtual void OnProcessCompleted(Frame frame, byte[] data)
    {

        OnReceive?.Invoke(this, new OnReceiveArgs(frame, data));
    }
}

public delegate void OnReceive(object sender, OnReceiveArgs args);

