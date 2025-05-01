using common.Data.EventArgs;
using Receiving.ReceiveStrategies.Interfaces;
using TcpServer;

namespace Receiving;

public class TcpReceiver
{
    private IEnumerable<IReceiveStrategy> _receiveStrategies;
    public TcpReceiver(IEnumerable<IReceiveStrategy> receiveStrategies)
    {
        WewoTcpListener.OnReceive += ReceiveTcpMessage;
        _receiveStrategies = receiveStrategies;
    }

    private void ReceiveTcpMessage(object sender, OnReceiveArgs args)
    {
        foreach (IReceiveStrategy receiveStrategy in _receiveStrategies)
        {
            if (receiveStrategy.MessageId == args.Frame.Id)
            {
                receiveStrategy.Execute(args.Frame, args.Data);
            }
        }
    }
}