using Edule.Api.GraphQl.Types;
using Edule.Api.Interfaces.Services;
using Edule.Api.Models;
using GraphQL;
using GraphQL.Types;

namespace Edule.Api.GraphQl.Mutations;

public class EventMutation : ObjectGraphType
{
    public EventMutation(IEventService eventService)
    {
        Name = "Mutation";
        Description = "Event mutation";

        Field<EventType>(
            name: "createEvent",
            description: "Create a new event",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<EventInputType>> { Name = "event" }
            ),
            resolve: context =>
            {
                var eventRequest = context.GetArgument<EventRequest>("event");
                var response = eventService.CreateEvent(eventRequest).Result;
                if (response.Valid)
                {
                    return response.Data;
                }
                else
                {
                    throw new ExecutionError(string.Join(',', response.Errors));
                }
            });
    }
}