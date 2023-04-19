using Edule.Api.Infra.Data.Entities;
using Edule.Backend.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Edule.Api.Infra.Data.Mappings.Entities
{
    public class ScheduleExceptionMapping : IEntityTypeConfiguration<ScheduleException>
    {
        public void Configure(EntityTypeBuilder<ScheduleException> builder)
        {
            builder.ConfigureStandardFields();

            builder.Property(x => x.Day)
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(x => x.Begin)
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(x => x.End)
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(x => x.Description)
                .StandardVarchar();

            builder.Property(x => x.Frequency)
                .HasConversion<int>()
                .IsRequired();

            builder.Property(x => x.EndRecurrentDate)
                .HasColumnType("date");

            builder.HasOne(x => x.Schedule)
                .WithMany(x => x.Exceptions)
                .HasForeignKey(x => x.Schedule.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("ScheduleExceptions");
        }
    }
}