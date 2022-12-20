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
        
        [HttpGet("/Desks")]
        public async Task<ActionResult<IEnumerable<Desk>>> GetDesks()
        {
            try
            {
                return Ok(await _service.GetDesks());
            }
            catch (Exception ex) { _logger.LogError(ex.Message); return Problem(ex.Message); }
        }

        [HttpGet("/Desks/{id}")]
        public async Task<ActionResult<Desk>> GetDesk(int id)
        {
            try
            {
                return Ok(await _service.GetDeskById(id));
            }
            catch (Exception ex) { _logger.LogError(ex.Message); return Problem(ex.Message); }
        }

        [HttpPut("/Desks/{id}")]
        public async Task<IActionResult> PutDesk(int id, Desk desk)
        {
            try
            {
                return Ok(await _service.GetDesks());
            }
            catch (Exception ex) { _logger.LogError(ex.Message); return Problem(ex.Message); }

        }

        [HttpPost("/desks")]
        public async Task<ActionResult<Desk>> PostDesk(Desk desk)
        {
            try
            {
                return Ok(await _service.GetDesks());
            }
            catch (Exception ex) { _logger.LogError(ex.Message); return Problem(ex.Message); }
        }

        [HttpDelete("/Desks/{id}")]
        public async Task<IActionResult> DeleteDesk(int id)
        {
            try
            {
                return Ok(await _service.GetDesks());
            }
            catch (Exception ex) { _logger.LogError(ex.Message); return Problem(ex.Message); }
        }

        [HttpGet("/desks/{id}/location")]
        public async Task<ActionResult<IEnumerable<Location>>> GetDeskLocation(int id)
        {

            try
            {
                return Ok(await _service.GetDesks());
            }
            catch (Exception ex) { _logger.LogError(ex.Message); return Problem(ex.Message); }
        }
    }
}