using HotDesks.Models;
using Microsoft.AspNetCore.Mvc;


namespace HotDesks.Interfaces;

public interface IHotDeskService
{
    public Task DeleteDesk(int id);
    public Task DeleteLocation(int id);
    public Task PutDesk(int id, Desk desk);
    public Task PostDesk(Desk desk);
    public Task PostLocation(Location location);
    public Task PutLocation(int id, Location location);
    public Task<ActionResult<IEnumerable<Desk>>> GetDesks();
    public Task<ActionResult<IEnumerable<Location>>> GetLocations();
    public Task<Desk> GetDeskById(int id);
    public Task<Location> GetLocationById(int id);

}