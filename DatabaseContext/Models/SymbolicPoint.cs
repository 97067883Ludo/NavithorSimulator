using System.ComponentModel.DataAnnotations;

namespace DatabaseContext.Models;

public class SymbolicPoint
{
    [Key]
    public int Id { get; set; }

    public float x { get; set; }
    
    public float y { get; set; }

    public string SymbolicPointName { get; set; }
    public string Type { get; set; }
    public int SymbolicPointId { get; set; }
}