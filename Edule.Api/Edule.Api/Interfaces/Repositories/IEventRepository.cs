using Edule.Api.Infra.Data.Entities;

namespace Edule.Api.Interfaces.Repositories;

public interface IEventRepository
{
    Task<Guid> Create(Event @event);
}