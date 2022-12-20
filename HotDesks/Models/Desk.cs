namespace HotDesks.Models;

public class Desk
{
    public int Id { get; set; }
    public int LocationId { get; set; }
    public Location Location { get; set; }
    public bool IsAvailable { get; set; }
}