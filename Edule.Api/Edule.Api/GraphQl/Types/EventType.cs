using Edule.Api.Infra.Data.Entities;

namespace Edule.Api.GraphQl.Types;

public class EventType : ObjectType<Event>
{
    protected override void Configure(IObjectTypeDescriptor<Event> descriptor)
    {
        descriptor.Field(e => e.Id).Type<NonNullType<UuidType>>();
        descriptor.Field(e => e.Title).Type<NonNullType<StringType>>();
        descriptor.Field(e => e.Description).Type<NonNullType<StringType>>();
        descriptor.Field(e => e.Slug).Type<NonNullType<StringType>>();
        descriptor.Field(e => e.Color).Type<StringType>();
        descriptor.Field(e => e.Duration).Type<NonNullType<IntType>>();
        descriptor.Field(e => e.AtHome).Type<NonNullType<BooleanType>>();
        descriptor.Field(e => e.MaxDistance).Type<IntType>();
        descriptor.Field(e => e.Inactive).Type<NonNullType<BooleanType>>();
        descriptor.Field(e => e.UserId).Type<NonNullType<UuidType>>();
        descriptor.Field(e => e.Fields).Type<ListType<EventFieldType>>();
        descriptor.Field(e => e.ScheduleEvents).Type<ListType<ScheduleEventType>>();
    }
}