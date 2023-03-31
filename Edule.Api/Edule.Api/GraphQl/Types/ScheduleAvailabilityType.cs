using Edule.Api.Infra.Data.Entities;

namespace Edule.Api.GraphQl.Types;

public class ScheduleAvailabilityType : ObjectType<ScheduleAvailability>
{
    protected override void Configure(IObjectTypeDescriptor<ScheduleAvailability> descriptor)
    {
        descriptor.Field(sa => sa.Id).Type<NonNullType<UuidType>>();
        descriptor.Field(sa => sa.WeekDay).Type<NonNullType<IntType>>();
        descriptor.Field(sa => sa.Begin).Type<NonNullType<DateTimeType>>();
        descriptor.Field(sa => sa.End).Type<NonNullType<DateTimeType>>();
        descriptor.Field(e => e.Schedule).Type<ScheduleType>();
    }
}