using Microsoft.AspNetCore.Mvc;
using HotDesks.Models;
using HotDesks.Interfaces;

namespace HotDesks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DesksController : ControllerBase
    {
        private readonly IHotDeskService _service;
        private readonly ILogger _logger;
        public DesksController(IHotDeskService service, ILogger<DesksController> logger)
        {
            _service = service;
            _logger = logger;
        }
        
        #region Desks
        [HttpGet("/Desks")]
        public async Task<ActionResult<IEnumerable<Desk>>> GetDesks()
        {
            try
            {   
                return Ok(await _service.GetDesks());
            }
            catch (Exception ex) { _logger.LogError(ex.Message); return Problem(ex.Message); }
        }

        [HttpGet("/Desk")]
        public async Task<ActionResult<Desk>> GetDesk(int id)
        {
            try
            {
                return Ok(await _service.GetDeskById(id));
            }
            catch (Exception ex) { _logger.LogError(ex.Message); return Problem(ex.Message); }
        }

        [HttpPut("/Desks")]
        public async Task<ActionResult> PutDesk(int id, Desk desk)
        {
            try
            {
                await _service.PutDesk(id, desk);
                return Ok();
            }
            catch (Exception ex) { _logger.LogError(ex.Message); return Problem(ex.Message); }

        }

        [HttpPost("/Desks")]
        public async Task<ActionResult<Desk>> PostDesk(Desk desk)
        {
            try
            {
                await _service.PostDesk(desk);
                return Ok();
            }
            catch (Exception ex) { _logger.LogError(ex.Message); return Problem(ex.Message); }
        }

        [HttpDelete("/Desks/{id}")]
        public async Task<IActionResult> DeleteDesk(int id)
        {
            try
            {
                await _service.DeleteDesk(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }

        #endregion
        
        #region Locations
        [HttpGet("/Get/Locations")]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        {
            try
            {
                return Ok(await _service.GetLocations());
            }
            catch (Exception ex) { _logger.LogError(ex.Message); return Problem(ex.Message); }
        }

        [HttpGet("/Get/locations/{id}")]
        public async Task<ActionResult<Location>> GetLocation(int id)
        {
            try
            {
                return Ok(await _service.GetLocationById(id));
            }
            catch (Exception ex) { _logger.LogError(ex.Message); return Problem(ex.Message); }
        }

        [HttpPut("Put/Locations/{id}")]
        public async Task<IActionResult> PutLocation(int id, Location location)
        {
            try
            {
                await _service.PutLocation(id, location);
                return Ok();
            }
            catch (Exception ex) { _logger.LogError(ex.Message); return Problem(ex.Message); }

        }

        [HttpPost("/Post/locations")]
        public async Task<ActionResult<Location>> PostLocation(Location location)
        {
            try
            {
                await _service.PostLocation(location);
                return Ok();
            }
            catch (Exception ex) { _logger.LogError(ex.Message); return Problem(ex.Message); }
        }

        [HttpDelete("/Delete/locations/{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            try
            {
                await _service.DeleteLocation(id);
                return Ok();
            }
            catch (Exception ex) { _logger.LogError(ex.Message); return Problem(ex.Message); }
        }
        #endregion
    }
}