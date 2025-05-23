using DatabaseContext;
using DatabaseContext.Models;
using Microsoft.AspNetCore.Mvc;
using NavithorSimulator.Dtos;

namespace NavithorSimulator.Controllers;

[Route("api/[controller]")]
public class AgvController : ControllerBase
{
    
    private readonly DataContext _context;
    
    public AgvController(DataContext context)
    {
        _context = context;
    }
    
    // GET
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.Agvs.ToList());
    }
    
    // POST
    [HttpPost]
    public IActionResult Post([FromBody] CreateAgv value)
    {
        Agv agv = new Agv
        {
            AgvId = value.AgvId
        };
        
        _context.Agvs.Add(agv);
        _context.SaveChanges();

        return Ok(agv);
    }
}