using Edule.Backend.Entities;
using Edule.Backend.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Edule.Backend.Mappings.Entities;

public class AddressMapping : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ConfigureStandardFields();

        builder.Property(x => x.Postcode)
            .HasColumnName(nameof(Address.Postcode))
            .StandardVarchar();

        builder.Property(x => x.LineOne)
            .HasColumnName(nameof(Address.LineOne))
            .StandardVarchar();

        builder.Property(x => x.LineTwo)
            .HasColumnName(nameof(Address.LineTwo))!
            .StandardVarchar();

        builder.Property(x => x.City)
            .HasColumnName(nameof(Address.City))!
            .StandardVarchar();

        builder.Property(x => x.State)
            .HasColumnName(nameof(Address.State))!
            .StandardVarchar();

        builder.Property(x => x.Country)
            .HasColumnName(nameof(Address.Country))
            .StandardVarchar();

        builder.Property(x => x.Geolocation)
            .HasColumnName(nameof(Address.Geolocation))!
            .StandardVarchar();

        builder.Property(x => x.FormattedAddress)
            .HasColumnName(nameof(Address.FormattedAddress))
            .StandardVarchar();

        builder.Property(x => x.UserId)
            .HasColumnName(nameof(Address.UserId));

        builder.HasOne(x => x.Establishment)
            .WithMany()
            .HasForeignKey(x => x.Establishment!.Id)
            .OnDelete(DeleteBehavior.SetNull);
    }
}