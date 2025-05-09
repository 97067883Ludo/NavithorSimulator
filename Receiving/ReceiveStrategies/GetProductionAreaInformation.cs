using common.Data.FrameUtils;
using Receiving.ReceiveStrategies.GetProductionAreaInformation;
using Receiving.ReceiveStrategies.Interfaces;

namespace Receiving.ReceiveStrategies;

public class GetProductionAreaInformationHandler : IReceiveStrategy // TODO: betere naam bedenken!!
{
    private readonly IGetProductionAreaInformationReceiver _receiver;
    
    public GetProductionAreaInformationHandler(IGetProductionAreaInformationReceiver receiver)
    {
        _receiver = receiver;
    }

    public int MessageId { get; set; } = 52;
    public void Execute(Frame frame, byte[] data)
    {
        _receiver.Execute(frame, data);
    }
}