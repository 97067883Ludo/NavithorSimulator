using common.Data.EventArgs;
using common.Data.FrameUtils;
using common.Data.Sending;
using Receiving.ReceiveStrategies.Interfaces;
using TcpServer;

namespace Receiving.ReceiveStrategies;

public class GetVersionStrategy : IReceiveStrategy
{

    public GetVersionStrategy(ITcpServer server)
    {
        Server = server;
    }

    private readonly ITcpServer Server;
    
    public int MessageId { get; set; } = 1;
    public void Execute(Frame frame, byte[] dataReceived)
    {
        SendTask dataToSend = new SendTask();

        dataToSend.frame = ConstructFrame(frame);

        byte[] data = new byte[115];

        byte[] sendFrame = FrameInterpeter.Serialize(dataToSend.frame);

        byte[] sendData = new byte[100];
        
        
        Server.Send(dataToSend);
    }
    
    private Frame ConstructFrame(Frame frame)
    {
        return new Frame()
        {
            Id = 101,
            DataLength = 115,
            MessageType = 1,
            ReceiverId = frame.SenderId,
            SenderId = 1000,
        };
    }
}