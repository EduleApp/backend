using Edule.Api.Infra.Data.Entities;
using Edule.Backend.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Edule.Api.Infra.Data.Mappings.Entities
{
    public class EventMapping : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ConfigureStandardFields();

            builder.Property(x => x.Title)
                .StandardVarchar();

            builder.Property(x => x.Description)
                .StandardVarchar();

            builder.Property(x => x.Slug)
                .StandardVarchar();

            builder.Property(x => x.Color)
                .StandardVarchar();

            builder.Property(x => x.Duration)
                .StandardInt();

            builder.Property(x => x.AtHome)
                .StandardBit();

            builder.Property(x => x.MaxDistance)
                .StandardInt()
                .IsRequired(false);

            builder.Property(x => x.Inactive)
                .StandardBit();

            builder.Property(x => x.UserId)
                .StandardGuid();

            builder.ToTable("Events");
        }
    }
}