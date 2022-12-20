using System.ComponentModel.DataAnnotations;

namespace HotDesks.Models;

public class Location
{
    [Key]
    public int Id { get; set; }
    
    [StringLength(50)]
    public string? Name { get; set; }
    public ICollection<Desk>? Desks { get; set; }
    
}