using Edule.Api.Infra.Data.Entities;

namespace Edule.Api.GraphQl.Types;

public class ScheduleType : ObjectType<Schedule>
{
    protected override void Configure(IObjectTypeDescriptor<Schedule> descriptor)
    {
        descriptor.Field(s => s.Id).Type<NonNullType<UuidType>>();
        descriptor.Field(s => s.Title).Type<NonNullType<StringType>>();
        descriptor.Field(s => s.Description).Type<NonNullType<StringType>>();
        descriptor.Field(s => s.Slug).Type<NonNullType<StringType>>();
        descriptor.Field(s => s.UserId).Type<NonNullType<UuidType>>();
        descriptor.Field(s => s.Availabilities).Type<ListType<ScheduleAvailabilityType>>();
        descriptor.Field(s => s.ScheduleEvents).Type<ListType<ScheduleEventType>>();
        descriptor.Field(s => s.Exceptions).Type<ListType<ScheduleExceptionType>>();
    }
}