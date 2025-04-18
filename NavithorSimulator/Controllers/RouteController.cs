using System.Text;
using System.Xml;
using Microsoft.AspNetCore.Mvc;

namespace NavithorSimulator.Controllers;

[Route("api/[controller]")]
public class RouteController : ControllerBase
{

    
    [HttpPost]
    public IActionResult Post(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }
        // Process the uploaded file here
        
        string filecontents = NewMethod(file);
        XmlDocument xmlcontent = new XmlDocument();
        xmlcontent.LoadXml(filecontents);

        foreach (object Object in xmlcontent.ChildNodes)
        {
            GetElements(Object);
        }
        
        return Ok();
    }

    private void GetElements(object Objects)
    {
        if (Objects is XmlDeclaration declaration)
        {
            if (declaration.ChildNodes.Count > 0)
            {
                foreach (object childNode in declaration.ChildNodes)
                {
                    
                }
            }

        }
    }

    private string NewMethod(IFormFile file)
    {
        StringBuilder fileContents = new StringBuilder();
        using(var stream = file.OpenReadStream())
        {
            // Read the file stream
            using (var reader = new StreamReader(stream))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    fileContents.AppendLine(line);
                }
            }
        }
        return fileContents.ToString();
    }
}