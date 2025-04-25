using common.Data.FrameUtils;

namespace Receiving.ReceiveStrategies.Interfaces;

public interface IReceiveStrategy
{
    public byte MessageType { get; set; }
    
    public void Execute(Frame frame, byte[] data);
}