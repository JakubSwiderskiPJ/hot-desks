using System.ComponentModel.DataAnnotations;

namespace HotDesks.Models;

public class Reservation
{
    [Key]
    public int Id { get; set; }
    public int DeskId { get; set; }
    public Desk? Desk { get; set; }
    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }

}