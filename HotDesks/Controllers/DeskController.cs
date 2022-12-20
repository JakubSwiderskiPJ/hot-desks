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

        public DesksController(IHotDeskService service)
        {
            _service = service;
        }

        [HttpGet("/Desks")]
        public async Task<ActionResult<IEnumerable<Desk>>> GetDesk()
        {
            if (_service.DeskDbIsNotNull().Equals(false))
                return NotFound();
            else
                return await _service.GetDesks();
        }

        [HttpGet("/Desks/{id}")]
        public async Task<ActionResult<Desk>> GetDesk(int id)
        {

            if (_service.DeskDbIsNotNull().Equals(false) || _service.DeskExists(id).Equals(false))
                return NotFound();
            else
                return _service.GetDeskById(id);
        }

        [HttpPut("/Desks/{id}")]
        public async Task<IActionResult> PutDesk(int id, Desk desk)
        {
            if (_service.DeskExists(id).Equals(false))
                return NotFound();
            if (id != desk.Id)
                return BadRequest();

            _service.PutDesk(desk);
            return NoContent();

        }

        [HttpPost("/desks")]
        public async Task<ActionResult<Desk>> PostDesk(Desk desk)
        {
            if (_service.DeskDbIsNotNull().Equals(false))
                return Problem("Entity set 'DbContext.Desks'  is null.");
            else
            {
                _service.AddDesk(desk);
                return CreatedAtAction("PostDesk", desk);
            }
        }

        [HttpDelete("/Desks/{id}")]
        public async Task<IActionResult> DeleteDesk(int id)
        {
            if (_service.DeskDbIsNotNull().Equals(false) || _service.DeskExists(id).Equals(false))
                return NotFound();
            else
            {
                _service.DeleteDesk(id);
                return NoContent();
            }
        }

        [HttpGet("/desks/{id}/location")]
        public async Task<ActionResult<IEnumerable<Location>>> GetDeskLocation(int id)
        {

            if (_service.DeskDbIsNotNull().Equals(false) || _service.DeskExists(id).Equals(false))
                return NotFound();
            else
                return await _service.GetLocationFromDesk(id);
        }
    }
}