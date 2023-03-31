namespace Edule.Api.GraphQl.Types;

public class ScheduleExceptionType : ObjectType<ScheduleException>
{
    protected override void Configure(IObjectTypeDescriptor<ScheduleException> descriptor)
    {
        descriptor.Field(e => e.Id).Type<NonNullType<UuidType>>();
        descriptor.Field(e => e.Day).Type<NonNullType<DateTimeType>>();
        descriptor.Field(e => e.Begin).Type<NonNullType<DateTimeType>>();
        descriptor.Field(e => e.End).Type<NonNullType<DateTimeType>>();
        descriptor.Field(e => e.Description).Type<NonNullType<StringType>>();

        descriptor.Field(e => e.Frequency)
            .Type<EScheduleExceptionsFrequencyType>()
            .Description("Defines the frequency of the exception occurrence");

        descriptor.Field(e => e.EndRecurrentDate)
            .Type<DateTimeType>()
            .Description("Defines the end date for the recurrent occurrences of the exception");

        descriptor.Field(e => e.Schedule).Type<ScheduleType>();
    }
}