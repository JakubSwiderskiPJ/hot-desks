using HotDesks.Context;
using HotDesks.Interfaces;
using HotDesks.Models;
using Microsoft.EntityFrameworkCore;

namespace HotEmployees.Services;

public class EmployeeService : IEmployeeInterface
{
    private readonly DataBaseContext dbContext;

    public EmployeeService(DataBaseContext dataBaseContext)
    {
        this.dbContext = dataBaseContext;
    }
    
    public async Task<Employee> GetEmployee(int id)
    {
        if (dbContext.Employees is null) throw new NullReferenceException();
        return await dbContext.Employees.FirstOrDefaultAsync(X => X.Id == id);
    }

    public async Task<IEnumerable<Employee>> GetEmployees()
    {
        if (dbContext.Employees is null) throw new NullReferenceException();
        return await dbContext.Employees.ToListAsync();
    }

    public async Task PostEmployee(Employee desk)
    {
        if (dbContext.Employees is null)
            throw new NullReferenceException();
        await dbContext.Employees.AddAsync(desk);
        await dbContext.SaveChangesAsync();
    }

    public async Task PutEmployee(int id, Employee desk)
    {
        if (dbContext.Employees is null)
            throw new NullReferenceException();
        Employee? entry = await dbContext.Employees.FirstOrDefaultAsync(X => X.Id == id);

        if (entry == null) throw new NullReferenceException();

        dbContext.Entry(desk).CurrentValues.SetValues(desk);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteEmployee(int id)
    {
        if (dbContext.Employees is null)
            throw new NullReferenceException();
        Employee? employee = await dbContext.Employees.FirstOrDefaultAsync(X => X.Id == id);

        if (employee == null) throw new NullReferenceException();

        dbContext.Employees.Remove(employee);
        await dbContext.SaveChangesAsync();
    }
}