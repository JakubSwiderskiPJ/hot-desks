using HotDesks.Models;
using Microsoft.AspNetCore.Mvc;


namespace HotDesks.Interfaces;

public interface IHotDeskService
{
    public Task AddDesk(Desk desk);
    public Task AddLocation(Location location);
    public Task DeleteDesk(int id);
    public Task DeleteLocation(int id);
    public Task PutDesk(Desk desk);
    public Task PostDesk(Desk desk);
    public Task PutLocation(Location location);
    public Task<ActionResult<IEnumerable<Desk>>> GetDesks();
    public Task<ActionResult<IEnumerable<Location>>> GetLocatoins();
    public Task<Desk> GetDeskById(int id);
    public Task<Location> GetLocationById(int id);
    
    Task<ActionResult<IEnumerable<Location>>> GetLocationFromDesk(int authorId);

}