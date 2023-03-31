using Edule.Api.Infra.Data;
using Edule.Api.Infra.Data.Entities;
using Edule.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

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
    
    public async Task<List<Event>> GetAllEvents()
    {
        return await _context.Event.ToListAsync();
    }

    public async Task<Event?> GetByIdAsync(Guid id)
    {
        return await _context.FindAsync<Event>(id);
    }
        
}