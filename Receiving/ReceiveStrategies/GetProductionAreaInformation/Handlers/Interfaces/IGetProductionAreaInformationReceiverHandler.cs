using common.Data.FrameUtils;

namespace Receiving.ReceiveStrategies.GetProductionAreaInformation.Handlers;

public interface IGetProductionAreaInformationReceiverHandler
{
    public void Execute(Frame frame, byte[] dataReceived);
}