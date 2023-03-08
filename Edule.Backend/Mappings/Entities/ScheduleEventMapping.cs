using Edule.Backend.Entities;
using Edule.Backend.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Edule.Backend.Mappings.Entities
{
    public class ScheduleEventMapping : IEntityTypeConfiguration<ScheduleEvent>
    {
        public void Configure(EntityTypeBuilder<ScheduleEvent> builder)
        {
            builder.ConfigureStandardFields();

            builder.HasOne(x => x.Schedule)
                .WithMany(x => x.ScheduleEvents)
                .HasForeignKey(x => x.Schedule.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Event)
                .WithMany(x => x.ScheduleEvents)
                .HasForeignKey(x => x.Event.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("ScheduleEvents");
        }
    }
}