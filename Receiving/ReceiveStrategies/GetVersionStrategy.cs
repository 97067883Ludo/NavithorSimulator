using common.Data.EventArgs;
using common.Data.FrameUtils;
using Receiving.ReceiveStrategies.Interfaces;
using TcpServer;

namespace Receiving.ReceiveStrategies;

public class GetVersionStrategy : IReceiveStrategy
{
    public byte MessageType { get; set; } = 1;
    public void Execute(Frame frame, byte[] data)
    {
        
    }
}