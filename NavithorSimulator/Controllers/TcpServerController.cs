using Microsoft.AspNetCore.Mvc;
using TcpServer;

namespace NavithorSimulator.Controllers;


[Route("api/[controller]")]
public class TcpServerController : ControllerBase
{
    private ITcpServer _tcpServer { get; init; }

    public TcpServerController(ITcpServer tcpListener)
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