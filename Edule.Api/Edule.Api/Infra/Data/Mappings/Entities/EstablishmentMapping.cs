using Edule.Api.Infra.Data.Entities;
using Edule.Backend.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Edule.Api.Infra.Data.Mappings.Entities;

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
