using HotDesks.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using HotDesks.Context;
using HotDesks.Controllers;
using HotDesks.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotDesks.Services
{
    public class HotDeskService : IHotDeskService
    {
        private readonly DataBaseContext dbContext;

        public HotDeskService(DataBaseContext dataBaseContext)
        {
            this.dbContext = dataBaseContext;
        }

        public async Task DeleteDesk(int id)
        {
            if (dbContext.Desks is null)
                throw new NullReferenceException();
            Desk? desk = await dbContext.Desks.FirstOrDefaultAsync(X => X.Id == id);

            if (desk == null) throw new NullReferenceException();

            dbContext.Desks.Remove(desk);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteLocation(int id)
        {
            if (dbContext.Locations is null)
                throw new NullReferenceException();
            Location? location = await dbContext.Locations.FirstOrDefaultAsync(X => X.Id == id);

            if (location == null) throw new NullReferenceException();

            dbContext.Locations.Remove(location);
            await dbContext.SaveChangesAsync();
        }

        public async Task PutDesk(int id, Desk desk)
        {
            if (dbContext.Desks is null)
                throw new NullReferenceException();
            Desk? entry = await dbContext.Desks.FirstOrDefaultAsync(X => X.Id == id);

            if (entry == null) throw new NullReferenceException();

            dbContext.Entry(desk).CurrentValues.SetValues(desk);
            await dbContext.SaveChangesAsync();
        }

        public async Task PostDesk(Desk desk)
        {
            if (dbContext.Desks is null)
                throw new NullReferenceException();
            await dbContext.Desks.AddAsync(desk);
            await dbContext.SaveChangesAsync();
        }

        public async Task PostLocation(Location location)
        {
            if (dbContext.Locations is null) throw new NullReferenceException();
            await dbContext.Locations.AddAsync(location);
            await dbContext.SaveChangesAsync();
        }

        public async Task PutLocation(int id, Location location)
        {
            Location? enter = await dbContext.Locations.FirstOrDefaultAsync(X => X.Id == id);

            if (enter == null) throw new NullReferenceException();

            dbContext.Entry(location).CurrentValues.SetValues(location);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<Desk>>> GetDesks()
        {
            if (dbContext.Desks is null) throw new NullReferenceException();
            return await dbContext.Desks.ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        {
            if (dbContext.Locations is null) throw new NullReferenceException();
            return await dbContext.Locations.ToListAsync();;
        }

        public async Task<Desk> GetDeskById(int id)
        {
            if (dbContext.Desks is null) throw new NullReferenceException();
            return await dbContext.Desks.FirstOrDefaultAsync(X => X.Id == id);
        }

        public async Task<Location> GetLocationById(int id)
        {
            if (dbContext.Locations is null) throw new NullReferenceException();
            return await dbContext.Locations.FirstOrDefaultAsync(X => X.Id == id);
        }
    }
    
}
