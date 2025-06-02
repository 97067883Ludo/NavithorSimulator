using Autofac;
using Autofac.Extensions.DependencyInjection;
using Contracts.TCP_Contracts;
using DatabaseContext;
using Receiving;
using Receiving.ReceiveStrategies;
using Receiving.ReceiveStrategies.GetProductionAreaInformation;
using Receiving.ReceiveStrategies.GetProductionAreaInformation.Handlers;
using Receiving.ReceiveStrategies.Interfaces;
using Services.SymbolicPointController;
using Services.SymbolicPointController.Contracts;
using TcpServer;
using TcpServer.buisnessLogic.Sending;

namespace NavithorSimulator;

using Autofac.Extensions.DependencyInjection;
// ... other using statements

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Register services with ASP.NET Core DI
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Use Autofac as the DI container
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.Host.ConfigureContainer<ContainerBuilder>(autofacBuilder =>
        {
            autofacBuilder.RegisterType<DataContext>().AsSelf().SingleInstance();
            autofacBuilder.RegisterType<SymbolicPointInformation>().As<IGetProductionAreaInformationReceiverHandler>().SingleInstance();
            autofacBuilder.RegisterType<GetProductionAreaInformationReceiver>().As<IGetProductionAreaInformationReceiver>().SingleInstance();
            autofacBuilder.RegisterType<GetProductionAreaInformationHandler>().As<IReceiveStrategy>().SingleInstance();
            autofacBuilder.RegisterType<GetVersionStrategy>().As<IReceiveStrategy>().SingleInstance();
            autofacBuilder.RegisterType<TcpSender>().As<ISendingContract>().SingleInstance();
            autofacBuilder.RegisterType<TcpReceiver>().As<IReceivingContract>().SingleInstance();
            autofacBuilder.RegisterType<SymbolicpointService>().As<ISymbolicPointServiceContract>().SingleInstance();
            autofacBuilder.RegisterType<TcpServer.TcpServer>().As<ITcpServer>().SingleInstance().AutoActivate();
        });

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}