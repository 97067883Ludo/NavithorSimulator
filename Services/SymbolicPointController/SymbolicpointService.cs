using System.Xml.Linq;
using common.Data.Dto_s;
using DatabaseContext;
using DatabaseContext.Models;
using Services.SymbolicPointController.Contracts;

namespace Services.SymbolicPointController;

public class SymbolicpointService : ISymbolicPointServiceContract
{

    private DataContext DataContext { get; set; }
    
    public SymbolicpointService(DataContext dataContext)
    {
        DataContext = dataContext;
    }

    public void Create(SymbolicPointCreateArgs symbolicPoint)
    {
        DataContext.Add(ConvertArgsToSymbolicPoint(symbolicPoint));
        DataContext.SaveChanges();
    }

    public void CreateRange(Stream file)
    {
        XDocument xmlcontent = XDocument.Load(file);
        var result = xmlcontent.Root?.Element("symbolic_points")?.Elements("symbolic_point");
        HashSet<SymbolicPoint> symbolicPoints = [];
        foreach (XElement element in result)
        {
            SymbolicPoint newSymbolicPoint = new SymbolicPoint
            {
                x = float.Parse(element.Element("x")?.Value ?? ""),
                y = float.Parse(element.Element("y")?.Value ?? ""),
                SymbolicPointName = element.Element("name")?.Value ?? "",
                Type = element.Element("symboltype")?.ToString() ?? "",
                SymbolicPointId = int.Parse(element.Element("id")?.Value ?? "0")
            };
            symbolicPoints.Add(newSymbolicPoint);
        }

        DataContext.SymbolicPoints.AddRangeAsync(symbolicPoints);
        DataContext.SaveChanges();
    }

    public List<SymbolicPoint> GetAllSymbolicPoints()
    {
        return DataContext.SymbolicPoints.ToList();
    }

    public SymbolicPoint ConvertArgsToSymbolicPoint(SymbolicPointCreateArgs symbolicPoint)
    {
        return new SymbolicPoint
        {
            SymbolicPointName = symbolicPoint.SymbolicPointName,
            x = symbolicPoint.x,
            y = symbolicPoint.y,
            Type = "0"
        };
    }
}