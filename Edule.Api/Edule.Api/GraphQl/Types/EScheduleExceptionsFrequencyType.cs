using Edule.Api.Infra.Data.Entities;

namespace Edule.Api.GraphQl.Types;

public class EScheduleExceptionsFrequencyType : EnumType<EScheduleExceptionsFrequency>
{
    protected override void Configure(IEnumTypeDescriptor<EScheduleExceptionsFrequency> descriptor)
    {
        descriptor.Name("EScheduleExceptionsFrequency");
        descriptor.Description("Enum that defines the frequency of the exception occurrence");

        descriptor
            .Value(EScheduleExceptionsFrequency.Daily)
            .Description("Occurs daily");

        descriptor
            .Value(EScheduleExceptionsFrequency.Weekly)
            .Description("Occurs every week");

        descriptor
            .Value(EScheduleExceptionsFrequency.Monthly)
            .Description("Occurs every month");

        descriptor
            .Value(EScheduleExceptionsFrequency.Bimonthly)
            .Description("Occurs every two months");

        descriptor
            .Value(EScheduleExceptionsFrequency.Quarterly)
            .Description("Occurs every four months");

        descriptor
            .Value(EScheduleExceptionsFrequency.Biannual)
            .Description("Occurs every six months");

        descriptor
            .Value(EScheduleExceptionsFrequency.Yearly)
            .Description("Occurs every year");
    }
}