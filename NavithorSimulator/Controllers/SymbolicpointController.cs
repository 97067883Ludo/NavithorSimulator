using System.Text;
using System.Xml;
using System.Xml.Linq;
using DatabaseContext;
using DatabaseContext.Models;
using Microsoft.AspNetCore.Mvc;

namespace NavithorSimulator.Controllers;

[Route("api/[controller]")]
public class SymbolicpointController : ControllerBase
{

    private readonly DataContext _dataContext;

    public SymbolicpointController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpPost]
    public IActionResult Post(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }
        
        XDocument xmlcontent = XDocument.Load(file.OpenReadStream());
        var result = xmlcontent.Root?.Element("symbolic_points").Elements("symbolic_point");
        HashSet<SymbolicPoint> symbolicPoints = [];
        foreach (XElement element in result)
        {
            SymbolicPoint newSymbolicPoint = new SymbolicPoint()
            {
                x = float.Parse(element.Element("x")?.Value ?? ""),
                y = float.Parse(element.Element("y")?.Value ?? ""),
                SymbolicPointName = element.Element("name")?.Value ?? "",
            };
            symbolicPoints.Add(newSymbolicPoint);
        }

        _dataContext.SymbolicPoints.AddRangeAsync(symbolicPoints);
        _dataContext.SaveChangesAsync();
        
        return Ok();
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_dataContext.SymbolicPoints.ToList());
    }
}