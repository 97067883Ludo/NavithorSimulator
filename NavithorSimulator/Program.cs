using Autofac;
using Autofac.Extensions.DependencyInjection;
using Contracts.TCP_Contracts;
using Receiving;
using Receiving.ReceiveStrategies;
using Receiving.ReceiveStrategies.GetProductionAreaInformation;
using Receiving.ReceiveStrategies.GetProductionAreaInformation.Handlers;
using Receiving.ReceiveStrategies.Interfaces;
using TcpServer;
using TcpServer.buisnessLogic.Receiving;
using TcpServer.buisnessLogic.Sending;

namespace NavithorSimulator;

public static class Program
{
    private static IContainer _container;
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        var autofacBuilder = new ContainerBuilder();
        
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        autofacBuilder.RegisterType<SymbolicPointInformation>().As<IGetProductionAreaInformationReceiverHandler>().SingleInstance();
        autofacBuilder.RegisterType<GetProductionAreaInformationReceiver>().As<IGetProductionAreaInformationReceiver>().SingleInstance();

        autofacBuilder.RegisterType<GetProductionAreaInformationHandler>().As<IReceiveStrategy>().SingleInstance();
        autofacBuilder.RegisterType<GetVersionStrategy>().As<IReceiveStrategy>().SingleInstance();

        autofacBuilder.RegisterType<TcpSender>().As<ISendingContract>().SingleInstance();
        autofacBuilder.RegisterType<TcpReceiver>().As<IReceivingContract>().SingleInstance();
        
        autofacBuilder.RegisterType<TcpServer.TcpServer>().As<ITcpServer>().SingleInstance().AutoActivate();
        
        _container = autofacBuilder.Build();
        
        WebApplication app = builder.Build();
        
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}