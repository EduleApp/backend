using Edule.Api.GraphQl.Types;
using Edule.Api.Infra.Data.Entities;
using Edule.Api.Interfaces.Services;

namespace Edule.Api.GraphQl.Queries;

public class EventQuery
{
    private readonly IEventService _eventService;

    public EventQuery(IEventService eventService)
    {
        _eventService = eventService ?? throw new ArgumentNullException(nameof(eventService));
    }

    public async Task<IEnumerable<Event>> GetEvents() => await _eventService.GetAllEvents();

    public async Task<Event> GetEventById(Guid id) => await _eventService.GetByIdAsync(id);
}

public class QueryType : ObjectType<EventQuery>
{
    protected override void Configure(IObjectTypeDescriptor<EventQuery> descriptor)
    {
        descriptor.Field(q => q.GetEvents())
            .Type<ListType<EventType>>()
            .Name("events")
            .Description("Gets all events.");

        descriptor.Field(q => q.GetEventById(default))
            .Type<EventType>()
            .Name("event")
            .Argument("id", arg => arg.Type<NonNullType<UuidType>>())
            .Description("Gets an event by its unique identifier.");
    }
}