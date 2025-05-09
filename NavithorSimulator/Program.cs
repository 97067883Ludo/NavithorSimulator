using DatabaseContext;
using DatabaseContext.Factories;
using Microsoft.EntityFrameworkCore;
using NavithorSimulator;
using Receiving;
using Receiving.ReceiveStrategies;
using Receiving.ReceiveStrategies.GetProductionAreaInformation;
using Receiving.ReceiveStrategies.GetProductionAreaInformation.Handlers;
using Receiving.ReceiveStrategies.Interfaces;
using TcpServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDataContextFactory, DataContextFactory>();
builder.Services.AddDbContext<DataContext>();

builder.Services.AddSingleton<ITcpServer, TcpServer.TcpServer>();

RegisterReceiving.RegisterGetProductionAreaInformationHandler(builder.Services);

// Register the receive strategies
builder.Services.AddSingleton<IReceiveStrategy, GetProductionAreaInformationHandler>();
builder.Services.AddSingleton<IReceiveStrategy, GetVersionStrategy>();

// Add the TcpReceiver as a singleton
builder.Services.AddSingleton<TcpReceiver>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();