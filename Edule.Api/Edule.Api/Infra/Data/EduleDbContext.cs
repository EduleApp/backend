using Edule.Api.Infra.Data.Entities;
using Edule.Api.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Edule.Api.Infra.Data;

public class EduleDbContext : DbContext
{
    public EduleDbContext(DbContextOptions<EduleDbContext> options) : base(options)
    {
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>()
            .AreUnicode(false)
            .HaveMaxLength(250);

        configurationBuilder.Properties<decimal>()
            .HaveColumnType("decimal(18,2)");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.ApplyConfigurationsFromAssembly(typeof(EduleDbContext).Assembly)
        //     .SeedData();
    }

    public DbSet<Address> Address => Set<Address>();
    public DbSet<Establishment> Establishment => Set<Establishment>();
    public DbSet<Event> Event => Set<Event>();
    public DbSet<EventField> EventField => Set<EventField>();
    public DbSet<Schedule> Schedule => Set<Schedule>();
    public DbSet<ScheduleAvailability> ScheduleAvailability => Set<ScheduleAvailability>();
    public DbSet<ScheduleEvent> ScheduleEvent => Set<ScheduleEvent>();
    public DbSet<ScheduleException> ScheduleException => Set<ScheduleException>();
}
