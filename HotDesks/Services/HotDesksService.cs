using HotDesks.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using HotDesks.Context;
using HotDesks.Interfaces;
using HotDesks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;


namespace HotDesks.Services
{
    public class HotDeskService : IHotDeskService
    {
        private readonly DataBaseContext dbContext;

        public HotDeskService(DataBaseContext dataBaseContext)
        {
            this.dbContext = dataBaseContext;
        }
        
        public async Task AddDesk(Desk desk)
        {
            if (dbContext.Desks is null)
                throw new NullReferenceException();
            await dbContext.Desks.AddAsync(desk);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddLocation(Location location)
        {
            if (dbContext.Locations is null) throw new NullReferenceException();
            await dbContext.Locations.AddAsync(location);
            await dbContext.SaveChangesAsync();
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

        public async Task PutDesk(Desk desk)
        {
            Desk? entry = await dbContext.Desks.FirstOrDefaultAsync(X => X.Id == desk.Id);

            if (entry == null) throw new NullReferenceException();

            dbContext.Entry(desk).CurrentValues.SetValues(desk);
            await dbContext.SaveChangesAsync();
        }

        public Task PostDesk(Desk desk)
        {
            throw new NotImplementedException();
        }

        public async Task PutLocation(Location location)
        {
            Location? enter = await dbContext.Locations.FirstOrDefaultAsync(X => X.Id == location.Id);

            if (enter == null) throw new NullReferenceException();

            dbContext.Entry(location).CurrentValues.SetValues(location);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<Desk>>> GetDesks()
        {
            if (dbContext.Desks is null) throw new NullReferenceException();
            return await dbContext.Desks.ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Location>>> GetLocatoins()
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

        public async Task<ActionResult<IEnumerable<Location>>> GetLocationFromDesk(int authorId)
        {
            throw new NotImplementedException();
        }
        
    }
}
