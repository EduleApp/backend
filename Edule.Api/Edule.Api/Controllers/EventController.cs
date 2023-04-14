using System.Net;
using Edule.Api.Infra.Data.Entities;
using Edule.Api.Interfaces;
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
}