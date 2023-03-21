namespace Edule.Api.Infra.Data.Entities;

public class Schedule : BaseEntity 
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public List<ScheduleAvailability> Availabilities { get; set; } = null!;
    public List<ScheduleEvent> ScheduleEvents { get; set; } = null!;
    public List<ScheduleException> Exceptions { get; set; } = null!;
}