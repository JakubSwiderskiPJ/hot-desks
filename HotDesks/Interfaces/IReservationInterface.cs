using HotDesks.Models;

namespace HotDesks.Interfaces;

public interface IReservationInterface
{
    public Task<IEnumerable<Desk>> AvailableDesks(DateOnly dateFrom, DateOnly dateTo);
    public Task<IEnumerable<Desk>> UnavailableDesks(DateOnly dateFrom, DateOnly dateTo);
    public Task<IEnumerable<Desk>> DesksInLocation(Location location);
    public Task BookADesk(Desk desk, DateOnly day, Employee employee);
    public Task BookADeskLongRepiod(Desk desk, DateOnly dateFrom, DateOnly dateTo, Employee employee);
    public Task ChangeDesk(Desk previousDesk, Desk newDesk);
}