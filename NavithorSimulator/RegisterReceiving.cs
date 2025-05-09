using Receiving.ReceiveStrategies.GetProductionAreaInformation;
using Receiving.ReceiveStrategies.GetProductionAreaInformation.Handlers;

namespace NavithorSimulator;

public static class RegisterReceiving
{
    public static void RegisterGetProductionAreaInformationHandler(IServiceCollection services)
    {
        services.AddSingleton<IGetProductionAreaInformationReceiverHandler, SymbolicPointInformation>();
        
        services.AddSingleton<IGetProductionAreaInformationReceiver, GetProductionAreaInformationReceiver>();
    }
}