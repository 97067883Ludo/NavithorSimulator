using common.Data.FrameUtils;

namespace Receiving.ReceiveStrategies.GetProductionAreaInformation;

public interface IGetProductionAreaInformationReceiver
{
    public void Execute(Frame frame, byte[] data);
}