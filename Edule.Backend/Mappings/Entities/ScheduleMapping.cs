using Edule.Backend.Entities;
using Edule.Backend.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Edule.Backend.Mappings.Entities
{
    public class ScheduleMapping : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ConfigureStandardFields();

            builder.Property(x => x.Title)
                .StandardVarchar();

            builder.Property(x => x.Description)
                .StandardVarchar();

            builder.Property(x => x.Slug)
                .StandardVarchar();

            builder.Property(x => x.UserId)
                .StandardGuid();

            builder.ToTable("Schedules");
        }
    }
}