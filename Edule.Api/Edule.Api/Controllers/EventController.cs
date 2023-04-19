using System.Net;
using Edule.Api.Infra.Data.Entities;
using Edule.Api.Interfaces.Services;
using Edule.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Edule.Api.Controllers;

[ApiController]
[Route("event")]
public class EventController : Controller
{
    private readonly IEventService _eventService;

    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(Event), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> Create([FromBody] EventRequest eventRequest)
    {
        var response = await _eventService.CreateEvent(eventRequest);

        return StatusCode((int)response.ResponseCode, response.Valid ? response.Data : response.Errors);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<Event>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(List<Event>), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> FindAll()
    {
        try
        {
            var result = await _eventService.GetAllEvents();
            if (!result.Any())
            {
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Event), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetEventById(Guid id)
    {
        try
        {
            var result = await _eventService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            var response = await _eventService.DeleteEventById(id);
            if (!response)
            {
                return NotFound();
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
}