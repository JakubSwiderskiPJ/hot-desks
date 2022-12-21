using HotDesks.Interfaces;
using HotDesks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace HotDesks.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservationController : Controller
{
    private readonly IReservationInterface _service;
    private readonly ILogger _logger;
    public ReservationController(IReservationInterface service, ILogger<DesksController> logger)
    {
        _service = service;
        _logger = logger;
    }
    
    [HttpGet("/AvailableDesks")]
    public async Task<ActionResult<IEnumerable<Desk>>> AvailableDesks(DateOnly dateTo, DateOnly dateFrom)
    {
        try
        {
            return Ok(await _service.AvailableDesks(dateFrom, dateTo));
        }
        catch (Exception ex) { _logger.LogError(ex.Message); return Problem(ex.Message); }
    }    
    
    [HttpGet("/UnavailableDesks")]
    public async Task<ActionResult<IEnumerable<Desk>>> UnavailableDesks(DateOnly dateTo, DateOnly dateFrom)
    {
        try
        {
            return Ok(await _service.UnavailableDesks(dateFrom, dateTo));
        }
        catch (Exception ex) { _logger.LogError(ex.Message); return Problem(ex.Message); }
    }    
    
    [HttpGet("/DesksInLocation")]
    public async Task<ActionResult<IEnumerable<Desk>>> DesksInLocation(Location location)
    {
        try
        {
            return Ok(await _service.DesksInLocation(location));
        }
        catch (Exception ex) { _logger.LogError(ex.Message); return Problem(ex.Message); }
    }    
    
    [HttpPut("/BookADesk")]
    public async Task<ActionResult> BookADesk(Desk desk, DateOnly when, Employee employee)
    {
        try
        {
            await _service.BookADesk(desk, when, when, employee);
            return Ok();
        }
        catch (Exception ex) { _logger.LogError(ex.Message); return Problem(ex.Message); }
    }  
    
    [HttpPut("/BookADeskLongRepiod")]
    public async Task<ActionResult<IEnumerable<Location>>> BookADeskLongRepiod(Desk desk, DateOnly dateFrom, DateOnly dateTo, Employee employee)
    {
        try
        {
            await _service.BookADesk(desk, dateFrom, dateTo, employee);
            return Ok();
        }
        catch (Exception ex) { _logger.LogError(ex.Message); return Problem(ex.Message); }
    }
    
    [HttpGet("/ChangeDesk")]
    public async Task<ActionResult<IEnumerable<Location>>> ChangeDesk(Desk previousDesk, Desk newDesk, Employee employee)
    {
        try
        {
            await _service.ChangeDesk(previousDesk, newDesk, employee);
            return Ok();
        }
        catch (Exception ex) { _logger.LogError(ex.Message); return Problem(ex.Message); }
    }
}