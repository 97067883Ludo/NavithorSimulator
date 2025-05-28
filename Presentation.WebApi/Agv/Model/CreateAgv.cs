using System.ComponentModel.DataAnnotations;

namespace Presentation.WebApi.Agv.Model;

public class CreateAgv
{
    [Required]
    public int AgvId { get; set; }
}