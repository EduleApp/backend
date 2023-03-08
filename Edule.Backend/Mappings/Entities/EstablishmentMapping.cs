using Edule.Backend.Entities;
using Edule.Backend.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Edule.Backend.Mappings.Entities;

public class EstablishmentMapping : IEntityTypeConfiguration<Establishment>
{
    public void Configure(EntityTypeBuilder<Establishment> builder)
    {
        builder.ConfigureStandardFields();

        builder.Property(x => x.Title)
            .StandardVarchar();

        builder.Property(x => x.UserId)
            .StandardGuid();

        builder.ToTable("Establishments");
    }
}
