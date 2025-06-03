using common.Data.FrameUtils;
using common.Data.Sending;
using common.Data.Sending.SpInformation;
using common.Data.Utils;
using Contracts.TCP_Contracts;
using Helpers.ReceivingHelpers;
using Services.SymbolicPointController.Contracts;

namespace Receiving.ReceiveStrategies.GetProductionAreaInformation.Handlers;

public class SymbolicPointSpatialInformation(ISymbolicPointServiceContract symbolicPointService, ISendingContract sending) : IGetProductionAreaInformationReceiverHandler
{
    public void Execute(Frame frame, byte[] dataReceived)
    {
        var symbolicPoint = symbolicPointService.GetAllSymbolicPoints();
        
        byte[] data = BitConverter.GetBytes((short)symbolicPoint.Count);

        foreach (var point in symbolicPoint)
        {
            var newPoint = new SpSpatialInformation
            {
                Id = point.Id,
                X = point.x,
                Y = point.y,
                Z = 0,
                Level = 0
            };
            byte[] symbolicpoint = SymoblicPointHelper.ConvertSymbolicPointToByteArray(newPoint);
            data = Appender.AppendRange(data, symbolicpoint, data.Length);
        }
        
        sending.SendMessage(new SendTask() { frame = ConstructFrame(frame, (short)data.Length), data = data });
    }

    private Frame ConstructFrame(Frame frame, short dataLength)
    {
        return new Frame()
        {
            Id = 340,
            DataLength = dataLength,
            MessageType = 1,
            ReceiverId = frame.SenderId,
            SenderId = 1000,
        };
    }
    
    public int MessageId { get; set; } = 5;
}