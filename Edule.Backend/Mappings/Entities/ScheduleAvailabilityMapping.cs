using Edule.Backend.Entities;
using Edule.Backend.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Edule.Backend.Mappings.Entities
{
    public class ScheduleAvailabilityMapping : IEntityTypeConfiguration<ScheduleAvailability>
    {
        public void Configure(EntityTypeBuilder<ScheduleAvailability> builder)
        {
            builder.ConfigureStandardFields();

            builder.Property(x => x.WeekDay)
                .IsRequired();

            builder.Property(x => x.Begin)
                .IsRequired();

            builder.Property(x => x.End)
                .IsRequired();

            builder.HasOne(x => x.Schedule)
                .WithMany(x => x.Availabilities)
                .HasForeignKey(x => x.Schedule.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("ScheduleAvailabilities");
        }
    }
}