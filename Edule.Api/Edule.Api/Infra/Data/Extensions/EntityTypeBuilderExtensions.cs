using Edule.Api.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Edule.Backend.Infra.Data.Extensions
{
    public static class EntityTypeBuilderExtensions
    {
        public static void ConfigureStandardFields<T>(this EntityTypeBuilder<T> builder) where T : BaseEntity
        {
            builder.Property(x => x.Id).HasColumnName(nameof(BaseEntity.Id));
            builder.Property(x => x.CreatedAt).HasColumnName(nameof(BaseEntity.CreatedAt));
            builder.Property(x => x.CreatedBy).HasColumnName(nameof(BaseEntity.CreatedBy));
            builder.Property(x => x.UpdatedAt).HasColumnName(nameof(BaseEntity.UpdatedAt));
            builder.Property(x => x.UpdatedBy).HasColumnName(nameof(BaseEntity.UpdatedBy));
        }

        public static PropertyBuilder<Guid> StandardGuid(this PropertyBuilder<Guid> builder)
            => builder.HasColumnType("uniqueidentifier");

        public static PropertyBuilder<Guid?> StandardGuid(this PropertyBuilder<Guid?> builder)
            => builder.HasColumnType("uniqueidentifier").IsRequired(false);

        public static PropertyBuilder<DateTime?> StandardDateTime(this PropertyBuilder<DateTime?> builder)
            => builder.HasColumnType("datetime2").IsRequired(false);

        public static PropertyBuilder<DateTime> StandardDateTime(this PropertyBuilder<DateTime> builder)
            => builder.HasColumnType("datetime2");

        public static PropertyBuilder<DateTime?> StandardDate(this PropertyBuilder<DateTime?> builder)
            => builder.HasColumnType("date").IsRequired(false);

        public static PropertyBuilder<DateTime> StandardDate(this PropertyBuilder<DateTime> builder)
            => builder.HasColumnType("date");

        public static PropertyBuilder<string> StandardVarchar(this PropertyBuilder<string> builder)
            => builder.HasColumnType("varchar(250)");

        public static PropertyBuilder<string?> StandardOptionalVarchar(this PropertyBuilder<string?> builder)
            => builder.HasColumnType("varchar(250)").IsRequired(false);

        public static PropertyBuilder<string> CustomVarchar(this PropertyBuilder<string> builder, int size)
        {
            var columnSize = size switch
            {
                <= 0 => "250",
                > 8000 => "max",
                _ => size.ToString()
            };
            return builder.HasColumnType($"varchar({columnSize})");
        }

        public static PropertyBuilder<decimal?> StandardDecimal(this PropertyBuilder<decimal?> builder)
            => builder.HasColumnType("decimal(18,2)");

        public static PropertyBuilder<decimal> StandardDecimal(this PropertyBuilder<decimal> builder)
            => builder.HasColumnType("decimal(18,2)");

        public static PropertyBuilder<int?> StandardInt(this PropertyBuilder<int?> builder)
            => builder.HasColumnType("int");

        public static PropertyBuilder<int> StandardInt(this PropertyBuilder<int> builder)
            => builder.HasColumnType("int");

        public static PropertyBuilder<Guid> StandardInt(this PropertyBuilder<Guid> builder)
            => builder.HasColumnType("int");

        public static PropertyBuilder<long?> StandardBigInt(this PropertyBuilder<long?> builder)
            => builder.HasColumnType("bigint");

        public static PropertyBuilder<long> StandardBigInt(this PropertyBuilder<long> builder)
            => builder.HasColumnType("bigint");

        public static PropertyBuilder<bool> StandardBit(this PropertyBuilder<bool> builder)
            => builder.HasColumnType("bit");
    }
}