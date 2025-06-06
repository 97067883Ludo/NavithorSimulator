using common.Data.FrameUtils;
using common.Data.Sending;
using common.Data.Sending.SpInformation;
using common.Data.Utils;
using Contracts.TCP_Contracts;
using DatabaseContext;
using DatabaseContext.Models;
using Helpers.ReceivingHelpers;
using Services.SymbolicPointController.Contracts;
using SQLitePCL;

namespace Receiving.ReceiveStrategies.GetProductionAreaInformation.Handlers;

public class SymbolicPointInformation(ISymbolicPointServiceContract symbolicPointService, ISendingContract sending)
    : IGetProductionAreaInformationReceiverHandler
{
    
    public void Execute(Frame frame, byte[] dataReceived)
    {
        var symbolicPoint = symbolicPointService.GetAllSymbolicPoints();
        
        byte[] data = BitConverter.GetBytes((short)symbolicPoint.Count);
        
        foreach (SymbolicPoint point in symbolicPoint)
        {
            SpInformation newPoint = new SpInformation
            {
                AvailableForMachineTypes = [1],
                AvailableForMachineTypesCount = 1,
                Id = (uint)point.Id,
                Name = point.SymbolicPointName,
                NameStringLength = (short)point.SymbolicPointName.Length,
                Type = uint.Parse(point.Type),
            };
            byte[] symbolicpoint = SymoblicPointHelper.ConvertSymbolicPointToByteArray(newPoint);
            data = Appender.AppendRange(data, symbolicpoint, data.Length);
        }
        
        sending.SendMessage(new SendTask() { frame = ConstructFrame(frame, (short)data.Length), data = data});
    }
    
    private Frame ConstructFrame(Frame frame, short dataLength)
    {
        return new Frame()
        {
            Id = 338,
            DataLength = dataLength,
            MessageType = 1,
            ReceiverId = frame.SenderId,
            SenderId = 1000,
        };
    }
    
    public int MessageId { get; set; } = 3;
}