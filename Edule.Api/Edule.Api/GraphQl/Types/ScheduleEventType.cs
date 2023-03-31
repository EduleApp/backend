using Edule.Api.Infra.Data.Entities;

namespace Edule.Api.GraphQl.Types;

public class ScheduleEventType : ObjectType<ScheduleEvent>
{
    protected override void Configure(IObjectTypeDescriptor<ScheduleEvent> descriptor)
    {
        descriptor.Field(se => se.Id).Type<NonNullType<UuidType>>();
        descriptor.Field(se => se.Schedule).Type<NonNullType<ScheduleType>>();
        descriptor.Field(se => se.Event).Type<NonNullType<EventType>>();
    }
}