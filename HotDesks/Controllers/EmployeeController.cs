using HotDesks.Interfaces;
using HotDesks.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotEmployee.Controllers;

public class EmployeeController : Controller
{
    private readonly IEmployeeInterface _service;
    private readonly ILogger _logger;

    public EmployeeController(IEmployeeInterface service, ILogger<EmployeeController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet("/Employees")]
    public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
    {
        try
        {
            return Ok(await _service.GetEmployees());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return Problem(ex.Message);
        }
    }

    [HttpGet("/Employee")]
    public async Task<ActionResult<Employee>> GetEmployee(int id)
    {
        try
        {
            return Ok(await _service.GetEmployee(id));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return Problem(ex.Message);
        }
    }

    [HttpPut("/Employee")]
    public async Task<ActionResult> PutEmployee(int id, Employee Employee)
    {
        try
        {
            await _service.PutEmployee(id, Employee);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return Problem(ex.Message);
        }
    }

    [HttpPost("/Employee")]
    public async Task<ActionResult<Employee>> PostEmployee(Employee Employee)
    {
        try
        {
            await _service.PostEmployee(Employee);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return Problem(ex.Message);
        }
    }

    [HttpDelete("/Employee")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        try
        {
            await _service.DeleteEmployee(id);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return Problem(ex.Message);
        }
    }
}