using System.Reflection;
using System.Text;
using common.Data.EventArgs;
using common.Data.FrameUtils;
using common.Data.Sending;
using common.Data.Utils;
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
        

        UInt16 interfaceVersionMajor = 1;
        UInt16 interfaceVersionMinor = 1;
        string softwareVersion = string.Concat(Assembly.GetEntryAssembly()?.GetName().Name, " ", Assembly.GetEntryAssembly()?.GetName().Version?.ToString() ?? "undefined version");
        UInt16 softwareVersionStringLenght = (UInt16)softwareVersion.Length;
        
        dataToSend.frame = ConstructFrame(frame, (short)(6 + softwareVersionStringLenght));
        byte[] sendData = new byte[6 + softwareVersionStringLenght];
        
        Appender.AppendRange(ref sendData, BitConverter.GetBytes(interfaceVersionMajor));
        Appender.AppendRange(ref sendData, BitConverter.GetBytes(interfaceVersionMinor), 2);
        Appender.AppendRange(ref sendData, BitConverter.GetBytes(softwareVersionStringLenght), 4);
        Appender.AppendRange(ref sendData, Encoding.ASCII.GetBytes(softwareVersion), 6);
        
        dataToSend.data = sendData;
        
        Server.Send(dataToSend);
    }
    
    private Frame ConstructFrame(Frame frame, short dataLength)
    {
        return new Frame()
        {
            Id = 101,
            DataLength = dataLength,
            MessageType = 1,
            ReceiverId = frame.SenderId,
            SenderId = 1000,
        };
    }
}