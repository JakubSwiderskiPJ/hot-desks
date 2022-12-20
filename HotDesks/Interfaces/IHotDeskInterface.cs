using HotDesks.Models;
using Microsoft.AspNetCore.Mvc;


namespace HotDesks.Interfaces;

public interface IHotDeskService
{
    public bool DeskDbIsNotNull();
    public bool EmployeeDbIsNotNull();
    public bool LocationDbIsNotNull();
    public bool ReservationDbIsNotNull();
    public bool DeskExists(int id);
    public bool LocationExists(int id);
    void AddDesk(Desk desk);
    void AddLocation(Location location);
    void DeleteDesk(int id);
    void DeleteLocation(int id);
    void PutDesk(Desk desk);
    void PutLocation(Location location);
    Task<ActionResult<IEnumerable<Desk>>> GetDesks();
    Task<ActionResult<IEnumerable<Location>>> GetLocatoins();
    Desk GetDeskById(int id);
    Location GetLocationById(int id);
    
    Task<ActionResult<IEnumerable<Location>>> GetLocationFromDesk(int authorId);
}