using Edule.Api.Infra.Data.Entities;
using Edule.Api.Models;

namespace Edule.Api.Interfaces.Services;

public interface IEventService
{
    Task<ResponseContract<EventResponse>> CreateEvent(EventRequest eventRequest);
    Task<IEnumerable<Event>> GetAllEvents();

    Task<Event> GetByIdAsync(Guid id);
}