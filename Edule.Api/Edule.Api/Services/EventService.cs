using System.Net;
using AutoMapper;
using Edule.Api.Infra;
using Edule.Api.Infra.Data.Entities;
using Edule.Api.Interfaces.Repositories;
using Edule.Api.Interfaces.Services;
using Edule.Api.Models;

namespace Edule.Api.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;

    public EventService(
        IEventRepository eventRepository,
        IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }

    public async Task<ResponseContract<EventResponse>> CreateEvent(EventRequest eventRequest)
    {
        ResponseContract<EventResponse> response = new();
        var newEvent = _mapper.Map<Event>(eventRequest);
        newEvent.Fields = _mapper.Map<List<EventField>?>(eventRequest.Fields);

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
    
    public async Task<IEnumerable<Event>> GetAllEvents()
    {
        return await _eventRepository.GetAllEvents();
    }
    
    public async Task<Event> GetByIdAsync(Guid id)
    {
        return (await _eventRepository.GetByIdAsync(id))!;
    }
}
