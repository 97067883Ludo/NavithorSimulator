using common.Data.FrameUtils;
using common.Data.Sending.SpInformation;
using DatabaseContext.Factories;
using DatabaseContext.Models;

namespace Receiving.ReceiveStrategies.GetProductionAreaInformation.Handlers;

public class SymbolicPointInformation : IGetProductionAreaInformationReceiverHandler
{
    private readonly IDataContextFactory _dbContextFactory;

    public SymbolicPointInformation()
    {
        
    }

    public void Execute(Frame frame, byte[] dataReceived)
    {
        // using var dbContext = _dbContextFactory.CreateDbContext();
        // var symbolicPoint = dbContext.SymbolicPoints.ToList();
        // HashSet<SpInformation> spInformation = new HashSet<SpInformation>();
        // foreach (SymbolicPoint point in symbolicPoint)
        // {
        //     SpInformation newPoint = new SpInformation
        //     {
        //         AvailableForMachineTypes = new int[] { 1 },
        //         AvailableForMachineTypesCount = 1,
        //         Id = (uint)point.Id,
        //         Name = point.SymbolicPointName,
        //         NameStringLength = (short)point.SymbolicPointName.Length,
        //         Type = uint.Parse(point.Type),
        //     };
        //     spInformation.Add(newPoint);
        // }
    }

    public int MessageId { get; set; } = 3;
}