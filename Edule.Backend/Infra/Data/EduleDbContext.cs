using Edule.Backend.Infra.Data.Entities;
using Edule.Backend.Infra.Data.Mappings.Entities;
using Microsoft.EntityFrameworkCore;

namespace Edule.Backend.Infra.Data;

public class EduleDbContext : DbContext
{
    public DbSet<Establishment> Establishments { get; set; } = null!;
    public DbSet<Event> Events { get; set; } = null!;
    public DbSet<EventField> EventFields { get; set; } = null!;
    public DbSet<Schedule> Schedules { get; set; } = null!;
    public DbSet<ScheduleAvailability> ScheduleAvailabilities { get; set; } = null!;
    public DbSet<ScheduleEvent> ScheduleEvents { get; set; } = null!;
    public DbSet<ScheduleException> ScheduleExceptions { get; set; } = null!;

    public EduleDbContext(DbContextOptions<EduleDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new EstablishmentMapping());
        modelBuilder.ApplyConfiguration(new EventMapping());
        modelBuilder.ApplyConfiguration(new EventFieldMapping());
        modelBuilder.ApplyConfiguration(new ScheduleMapping());
        modelBuilder.ApplyConfiguration(new ScheduleAvailabilityMapping());
        modelBuilder.ApplyConfiguration(new ScheduleEventMapping());
        modelBuilder.ApplyConfiguration(new ScheduleExceptionMapping());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySQL("Server=localhost;Database=edule;Uid=eduledbuser;Pwd=secret;");
        }
    }
}
