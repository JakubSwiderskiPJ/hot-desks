using System.Data;
using HotDesks.Context;
using HotDesks.Interfaces;
using HotDesks.Models;
using HotEmployee.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace HotDesks.Services;

public class ReservationService : IReservationInterface
{
    private readonly DataBaseContext dbContext;

    public ReservationService(DataBaseContext dataBaseContext)
    {
        this.dbContext = dataBaseContext;
    }
    
    public async Task<IEnumerable<Desk>> AvailableDesks(DateOnly dateFrom, DateOnly dateTo)
    {
        if (dbContext.Desks is null) throw new NullReferenceException();
        return await dbContext.Desks.Where(X => X.Reservation.Where(Y=>!(Y.StartDate <= dateTo && dateFrom <= Y.EndDate)).Any()).ToListAsync();
    }

    public async Task<IEnumerable<Desk>> UnavailableDesks(DateOnly dateFrom, DateOnly dateTo)
    {
        if (dbContext.Desks is null) throw new NullReferenceException();
        return await dbContext.Desks.Where(X => X.Reservation.Where(Y=>(Y.StartDate <= dateTo && dateFrom <= Y.EndDate)).Any()).ToListAsync();
    }

    public async Task<IEnumerable<Desk>> DesksInLocation(Location location)
    {
        if (dbContext.Desks is null) throw new NullReferenceException();
        return await dbContext.Desks.Where(X => X.LocationId == location.Id).ToListAsync();

    }

    public async Task BookADesk(Desk desk, DateOnly dateFrom, DateOnly dateTo, Employee employee)
    {
        if (dbContext.Desks is null || dbContext.Employees is null) 
            throw new NullReferenceException();

        if (!dbContext.Employees.Select(X => X.Id == employee.Id).Any())
            throw new NullReferenceException();

        Desk? deskEntity = await dbContext.Desks.FirstOrDefaultAsync(x => x.Id == desk.Id);

        if (deskEntity is null) throw new ArgumentNullException();
        
        if(deskEntity.Reservation.Where(X=>(X.StartDate <= dateTo && dateFrom <= X.EndDate)).Any())
            throw new ArgumentNullException();

        Reservation reservation = new Reservation
        {
            DeskId = deskEntity.Id,
            EmployeeId = employee.Id,
            StartDate = dateFrom,
            EndDate = dateTo
        };

        await dbContext.Reservations.AddAsync(reservation);
        await dbContext.SaveChangesAsync();
    }

    public async Task ChangeDesk(Desk previousDesk, Desk newDesk, Employee employee)
    {
        if (dbContext.Desks is null || dbContext.Employees is null) 
            throw new NullReferenceException();

        if (!dbContext.Employees.Select(X => X.Id == employee.Id).Any())
            throw new NullReferenceException();

        Desk? deskEntity = await dbContext.Desks.FirstOrDefaultAsync(x => x.Id == previousDesk.Id);

        if (deskEntity is null) throw new ArgumentNullException();

        Reservation? reservationEntry = deskEntity.Reservation.FirstOrDefault(X => X.EmployeeId == employee.Id);
        
        if (reservationEntry is null) throw new ArgumentNullException();
        
        if(reservationEntry.StartDate.DayNumber+1 > DateOnly.FromDateTime(DateTime.Now).DayNumber)
            throw new ArgumentNullException();

        reservationEntry.DeskId = newDesk.Id;

        await dbContext.SaveChangesAsync();
    }
}