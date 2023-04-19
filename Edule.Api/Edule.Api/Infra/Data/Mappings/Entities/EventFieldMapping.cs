using Edule.Api.Infra.Data.Entities;
using Edule.Backend.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Edule.Api.Infra.Data.Mappings.Entities
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
                .WithMany(t=>t.Fields)
                .HasForeignKey(x => x.Event.Id)
                .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable("EventFields");
        }
    }
}