using System.Net;
using Edule.Api.Infra;
using Edule.Api.Models;
using Edule.Api.Infra.Data.Entities;
using Edule.Api.Interfaces;
using Edule.Api.Interfaces.Repositories;

namespace Edule.Api.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;

    public EventService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<ResponseContract<EventResponse>> CreateEvent(EventRequest eventRequest)
    {
        ResponseContract<EventResponse> response = new();
        
        var newEvent = new Event
        {
            Title = eventRequest.Title,
            Description = eventRequest.Description,
            Slug = eventRequest.Slug,
            Color = eventRequest.Color,
            Duration = eventRequest.Duration,
            AtHome = eventRequest.AtHome,
            MaxDistance = eventRequest.MaxDistance,
            Inactive = eventRequest.Inactive,
            UserId = eventRequest.UserId,
            Fields = eventRequest.Fields?.Select(f => new EventField
            {
                FieldName = f.FieldName,
                FriendlyName = f.FriendlyName,
                Type = f.Type
            }).ToList()
        };

        var result = await _eventRepository.Create(newEvent);

        if (result == Guid.Empty)
        {
            response.SetResponse(valid: false, HttpStatusCode.BadRequest);
            response.AddError(LogEvents.CREATE_EVENT_FAILED.Name!);
            return response;
        }

        response.SetResponse(valid: true, code: HttpStatusCode.Created, message: LogEvents.CREATE_EVENT_SUCCEEDED.Name);
        response.AddData(new EventResponse
        {
            Id = result
        });

        return response;
    }
}
