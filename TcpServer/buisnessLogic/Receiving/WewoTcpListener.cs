using System.Net.Sockets;
using common.Data.EventArgs;
using common.Data.FrameUtils;
using Contracts.TCP_Contracts;

namespace TcpServer.buisnessLogic.Receiving;

public class WewoTcpListener : IWewoTcpListener, IDisposable
{
    private bool Listening { get; set; }
    
    private IReceivingContract _receivehandler;
    
    public WewoTcpListener(IReceivingContract receivehandler)
    {
        _receivehandler = receivehandler;
    }

    public void StartListing(TcpClient handler)
    {
        NetworkStream stream = handler.GetStream();
        Listening = true;
        while (handler.Connected)
        {
            var header = new byte[9];
            
            if (ReadStreamUntilValidFrame(handler, stream, header)) return;

            var frame = FrameInterpeter.Deserialize(header);
            var data = new byte[frame.DataLength];

            ReadDataUntilComplete(stream, data, frame);

            OnProcessCompleted(frame, data);
        }

        Console.WriteLine("Stopped Listening");
    }

    private bool ReadStreamUntilValidFrame(TcpClient handler, NetworkStream stream, byte[] header)
    {
        try
        {
            handler.GetStream();
            var frameSize = stream.Read(header); //TODO: kijk naar de exceptions die evt. gegooid kunnen worden.
            while (frameSize < 9)
            {
                frameSize = stream.Read(header);
            }
        }
        catch (Exception e)
        {
            //TODO: Handle exception Export to prometheus.
            return true;
        }

        return false;
    }

    private void ReadDataUntilComplete(NetworkStream stream, byte[] data, Frame frame)
    {
        try
        {
            var dataSize = stream.Read(data);
            while (dataSize < frame.DataLength)
            {
                dataSize = stream.Read(data);
            }
        }
        catch (Exception e)
        {
                
        }
    }

    protected virtual void OnProcessCompleted(Frame frame, byte[] data)
    {
        //TODO: Go to Application layer.
        _receivehandler.ReceiveMessage(new OnReceiveArgs(frame, data));
    }

    public void Dispose()
    {
        Listening = false;
    }
}