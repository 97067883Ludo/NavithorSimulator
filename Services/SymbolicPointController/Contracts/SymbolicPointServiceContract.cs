using common.Data.Dto_s;
using DatabaseContext.Models;

namespace Services.SymbolicPointController.Contracts;

public interface ISymbolicPointServiceContract
{
    public void Create(SymbolicPointCreateArgs symbolicPoint);
    
    public void CreateRange(Stream symbolicPoints);

    public List<SymbolicPoint> GetAllSymbolicPoints();
}