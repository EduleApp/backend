using Edule.Api.Infra.Data.Entities;
using Edule.Api.Models;
using GraphQL.Types;

namespace Edule.Api.GraphQl.Types;

public sealed class EventInputType : InputObjectGraphType<EventRequest>
{
    public EventInputType()
    {
        Name = "EventInput";
        Description = "Input for creating or updating an event.";
        Field(x => x.Title).Description("The title of the event.");
        Field(x => x.Description).Description("The description of the event.");
        Field(x => x.Duration, type: typeof(int)).Description("Duration of the event.");
        Field(x => x.Color).Description("Event Color Hexadecimal");
        Field(x => x.AtHome, type: typeof(bool)).Description("This is homework event?.");
        Field(x => x.MaxDistance, type: typeof(int)).Description("if this is homework event, defined max distance.");
        Field(x => x.Inactive, type: typeof(bool)).Description("The end date of the event.");
        Field(x => x.Fields, type: typeof(EventField)).Description("Mandatory fields when contracting the event. For example: name, phone etc.");
    }
}