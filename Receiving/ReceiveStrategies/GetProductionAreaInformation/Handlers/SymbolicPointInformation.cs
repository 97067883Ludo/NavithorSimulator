using common.Data.FrameUtils;
using common.Data.Sending.SpInformation;
using DatabaseContext;
using DatabaseContext.Models;

namespace Receiving.ReceiveStrategies.GetProductionAreaInformation.Handlers;

public class SymbolicPointInformation : IGetProductionAreaInformationReceiverHandler
{

    private DataContext _dbContext;
        
    public SymbolicPointInformation(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Execute(Frame frame, byte[] dataReceived)
    {
        var symbolicPoint = _dbContext.SymbolicPoints.ToList();
        
        HashSet<SpInformation> spInformation = new HashSet<SpInformation>();
        foreach (SymbolicPoint point in symbolicPoint)
        {
            SpInformation newPoint = new SpInformation
            {
                AvailableForMachineTypes = new int[] { 1 },
                AvailableForMachineTypesCount = 1,
                Id = (uint)point.Id,
                Name = point.SymbolicPointName,
                NameStringLength = (short)point.SymbolicPointName.Length,
                Type = uint.Parse(point.Type),
            };
            spInformation.Add(newPoint);
        }
    }

    public int MessageId { get; set; } = 3;
}