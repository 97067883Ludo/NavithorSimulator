using Microsoft.AspNetCore.Mvc;
using Receiving;
using TcpServer;

namespace NavithorSimulator.Controllers;


[Route("api/[controller]")]
public class TcpServerController : ControllerBase
{
    private ITcpServer _tcpServer { get; init; }

    public TcpServerController(ITcpServer tcpListener, TcpReceiver tcpReceiver) //TODO: create an instance of the TcpReceiver somewhere else...
    {
        _tcpServer = tcpListener;
    }

    [HttpPost]
    public IActionResult StartServer()
    {
        _tcpServer.StartServer();
        return Ok();
    }
}