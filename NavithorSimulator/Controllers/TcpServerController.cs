using Microsoft.AspNetCore.Mvc;
using TcpServer.buisnessLogic;

namespace NavithorSimulator.Controllers;


[Route("api/[controller]")]
public class TcpServerController : ControllerBase
{
    private IWewoTcpListener _tcpListener { get; init; }

    public TcpServerController(IWewoTcpListener tcpListener)
    {
        _tcpListener = tcpListener;
    }

    [HttpPost]
    public IActionResult StartServer()
    {
        _tcpListener.StartServer();
        return Ok();
    }
}