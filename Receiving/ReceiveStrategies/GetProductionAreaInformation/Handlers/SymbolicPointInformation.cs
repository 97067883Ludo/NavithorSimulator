using common.Data.FrameUtils;
using common.Data.Sending.SpInformation;
using DatabaseContext;
using DatabaseContext.Factories;
using DatabaseContext.Models;

namespace Receiving.ReceiveStrategies.GetProductionAreaInformation.Handlers;

public class SymbolicPointInformation : IGetProductionAreaInformationReceiverHandler
{
    private readonly IDataContextFactory _dbContextFactory;

    public SymbolicPointInformation(IDataContextFactory dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public void Execute(Frame frame, byte[] dataReceived)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();
        var symbolicPoint = dbContext.SymbolicPoints.ToList();
        HashSet<SpInformation> spInformation = new HashSet<SpInformation>();
        foreach (SymbolicPoint point in symbolicPoint)
        {
            SpInformation newPoint = new SpInformation
            {
                Id = (uint)point.Id
            };
        }
    }

    public int MessageId { get; set; } = 3;
}