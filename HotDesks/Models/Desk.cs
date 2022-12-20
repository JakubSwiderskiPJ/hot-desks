using System.ComponentModel.DataAnnotations;

namespace HotDesks.Models;

public class Desk
{
    [Key]
    public int Id { get; set; }
    public int LocationId { get; set; }
    public Location? Location { get; set; }
    public bool IsAvailable { get; set; }
    
    public int ReservationId {get; set; }
    public ICollection <Reservation>? Reservation { get; set; }

}