using Edule.Api.Infra.Data;
using Edule.Api.Infra.Data.Entities;
using Edule.Api.Interfaces.Repositories;

namespace Edule.Api.Repositories;

public class EventRepository : IEventRepository
{
    private readonly EduleDbContext _context;

    public EventRepository(EduleDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Create(Event @event)
    {
        if (@event == null)
        {
            throw new ArgumentNullException(nameof(@event));
        }

        var result = await _context.Event.AddAsync(@event);
        await _context.SaveChangesAsync();
        return result.Entity.Id;
    }
}