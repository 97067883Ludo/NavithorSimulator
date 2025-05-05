using Receiving.ReceiveStrategies.GetProductionAreaInformation.Handlers;

namespace Receiving.ReceiveStrategies.GetProductionAreaInformation;

public class GetProductionAreaInformationReceiver : IGetProductionAreaInformationReceiver
{
    private IEnumerable<IGetProductionAreaInformationReceiverHandler> _handlers { get; init; }

    public GetProductionAreaInformationReceiver(IEnumerable<IGetProductionAreaInformationReceiverHandler> handlers)
    {
        _handlers = handlers;
    }

    public void Execute()
    {
        
    }
}