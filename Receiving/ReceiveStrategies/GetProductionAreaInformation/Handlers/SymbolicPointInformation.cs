using common.Data.FrameUtils;

namespace Receiving.ReceiveStrategies.GetProductionAreaInformation.Handlers;

public class SymbolicPointInformation : IGetProductionAreaInformationReceiverHandler
{
    public void Execute(Frame frame, byte[] dataReceived)
    {
        
    }

    public int MessageId { get; set; } = 3;
}