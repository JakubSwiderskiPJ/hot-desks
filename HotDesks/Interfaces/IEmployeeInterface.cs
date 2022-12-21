using HotDesks.Models;

namespace HotDesks.Interfaces;

public interface IEmployeeInterface
{
    public Task<Employee> GetEmployee(int id);
    public Task<IEnumerable<Employee>> GetEmployees();
    public Task PostEmployee(Employee employee);
    public Task PutEmployee(int id, Employee employee);
    public Task DeleteEmployee(int id);
}