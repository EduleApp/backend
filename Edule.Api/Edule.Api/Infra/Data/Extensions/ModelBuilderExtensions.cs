using Edule.Api.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Edule.Api.Infra.Data.Extensions;

public static class ModelBuilderExtensions
{
    private const string MigrationUser = "MIGRATION";

    public static ModelBuilder SeedData(this ModelBuilder modelBuilder)
    {
        DateTime creationDate = new(2023, 2, 1, 18, 21, 33, 664, DateTimeKind.Utc);

        // Enum entities
        SetEvent(modelBuilder, creationDate);
        return modelBuilder;
    }
    
    private static void SetEvent(ModelBuilder modelBuilder, DateTime creationDate)
        => modelBuilder.Entity<Event>()
        .HasData(new[]
        {
            new Event() 
            { 
                Id = new Guid("50cb4fcc-9187-4f4c-83a2-adc9f7f38bfc"), 
                Description = "Evento Teste",
                CreatedAt = creationDate, 
                CreatedBy = MigrationUser 
            },
            new Event
            {
                Id = new Guid("50cb4fcc-9187-4f4c-83a2-adc9f7f38bfc"),
                CreatedBy = MigrationUser,
                CreatedAt = creationDate,
                Title = "Evento Teste",
                Description = "Evento Teste",
                Slug = "evento-teste",
                Color = "Red",
                Duration = 0,
                AtHome = false,
                MaxDistance = null,
                Inactive = false,
                UserId = new Guid("50cb4fcc-9187-4f4c-83a2-adc9f7f38bfc")
            }
        });
}
