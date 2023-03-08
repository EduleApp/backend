using Edule.Backend.Entities;
using Edule.Backend.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Edule.Backend.Mappings.Entities
{
    public class EventFieldMapping : IEntityTypeConfiguration<EventField>
    {
        public void Configure(EntityTypeBuilder<EventField> builder)
        {
            builder.ConfigureStandardFields();

            builder.Property(x => x.FieldName)
                .StandardVarchar();

            builder.Property(x => x.FriendlyName)
                .StandardVarchar();

            builder.Property(x => x.Type)
                .StandardVarchar();

            builder.HasOne(x => x.Event)
                .WithMany(x => x.Fields)
                .HasForeignKey(x => x.Event.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("EventFields");
        }
    }
}