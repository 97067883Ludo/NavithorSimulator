using common.Data.FrameUtils;
using Receiving.ReceiveStrategies.GetProductionAreaInformation.Handlers;

namespace Receiving.ReceiveStrategies.GetProductionAreaInformation;

public class GetProductionAreaInformationReceiver : IGetProductionAreaInformationReceiver
{
    private IEnumerable<IGetProductionAreaInformationReceiverHandler> _handlers { get; init; }

    public GetProductionAreaInformationReceiver(IEnumerable<IGetProductionAreaInformationReceiverHandler> handlers)
    {
        _handlers = handlers;
    }

    public void Execute(Frame frame, byte[] data)
    {
        foreach (IGetProductionAreaInformationReceiverHandler handler in _handlers)
        {
            if (handler.MessageId == frame.Id)
            {
                handler.Execute(frame, data);
                break;
            }
        }
    }
}