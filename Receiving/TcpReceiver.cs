using common.Data.EventArgs;
using Microsoft.Extensions.Hosting;
using Receiving.ReceiveStrategies.Interfaces;
using TcpServer;

namespace Receiving;

public class TcpReceiver : BackgroundService
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
            if (receiveStrategy.MessageType == args.Frame.MessageType)
            {
                receiveStrategy.Execute(args.Frame, args.Data);
            }
        }
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return Task.CompletedTask;
    }
}