using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DatabaseContext.Models;

public class Agv
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int AgvId { get; set; }
}