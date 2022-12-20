namespace HotDesks.Models;

public class Location
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Desk> Desks { get; set; }
    
    public int DeskId { get; set; }
    public Desk Desk { get; set; }
}