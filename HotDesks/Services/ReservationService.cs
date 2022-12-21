using HotDesks.Interfaces;
using HotDesks.Models;

namespace HotDesks.Services;

public class ReservationService : IReservationInterface
{
    public Task<IEnumerable<Desk>> AvailableDesks(DateOnly dateFrom, DateOnly dateTo)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Desk>> UnavailableDesks(DateOnly dateFrom, DateOnly dateTo)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Desk>> DesksInLocation(Location location)
    {
        throw new NotImplementedException();
    }

    public Task BookADesk(Desk desk, DateOnly day)
    {
        throw new NotImplementedException();
    }

    public Task BookADeskLongRepiod(Desk desk, DateOnly dateFrom, DateOnly dateTo)
    {
        throw new NotImplementedException();
    }

    public Task ChangeDesk(Desk previousDesk, Desk newDesk)
    {
        throw new NotImplementedException();
    }
}