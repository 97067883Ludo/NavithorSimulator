using common.Data.FrameUtils;

namespace Receiving.ReceiveStrategies.Interfaces;

public interface IReceiveStrategy
{
    public int MessageId { get; set; }
    
    public void Execute(Frame frame, byte[] data);
}