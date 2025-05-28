using common.Data.EventArgs;
using Contracts.TCP_Contracts;
using Receiving.ReceiveStrategies.Interfaces;

namespace Receiving;

public class TcpReceiver : IReceivingContract
{
    private IEnumerable<IReceiveStrategy> _receiveStrategies;
    public TcpReceiver(IEnumerable<IReceiveStrategy> receiveStrategies)
    {
        _receiveStrategies = receiveStrategies;
    }

    public void ReceiveMessage(OnReceiveArgs message)
    {
        foreach (IReceiveStrategy receiveStrategy in _receiveStrategies)
        {
            if (receiveStrategy.MessageId == message.Frame.Id)
            {
                receiveStrategy.Execute(message.Frame, message.Data);
            }
        }
    }
}