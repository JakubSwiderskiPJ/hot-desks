using System.ComponentModel.DataAnnotations;

namespace HotDesks.Models;

public class Employee
{
    [Key]
    public int Id { get; set; }
    
    [StringLength(50)]
    public string? Name { get; set; }
    public ICollection<Reservation>? Reservations { get; set; }

}