using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.SymbolicPointController.Contracts;

namespace Presentation.WebApi.Symoblicpoint;

[Route("api/[controller]")]
public class SymbolicpointController(ISymbolicPointServiceContract symbolicpointService) : ControllerBase
{
    [HttpPost]
    public IActionResult Post(IFormFile? file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }
        
        symbolicpointService.CreateRange(file.OpenReadStream());
        
        return Ok();
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(symbolicpointService.GetAllSymbolicPoints());
    }
}