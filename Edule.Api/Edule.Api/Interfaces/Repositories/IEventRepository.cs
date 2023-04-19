using Edule.Api.Infra.Data.Entities;

namespace Edule.Api.Interfaces.Repositories;

public interface IEventRepository
{
    Task<Guid> Create(Event @event);
    Task<List<Event>> GetAllEvents();
    Task<Event?> GetByIdAsync(Guid id);
    Task<bool> Delete(Event existingEvent);
}