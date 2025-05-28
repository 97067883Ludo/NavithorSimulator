using DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApi.Agv.Model;

namespace Presentation.WebApi.Agv;

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
        DatabaseContext.Models.Agv agv = new DatabaseContext.Models.Agv
        {
            AgvId = value.AgvId
        };
        
        _context.Agvs.Add(agv);
        _context.SaveChanges();

        return Ok(agv);
    }
}