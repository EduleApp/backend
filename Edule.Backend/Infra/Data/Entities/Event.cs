namespace Edule.Backend.Infra.Data.Entities;

public class Event : BaseEntity 
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public int Duration { get; set; } = 15;
    public bool AtHome { get; set; }
    public int? MaxDistance { get; set; }
    public bool Inactive { get; set; } = false;
    public Guid UserId { get; set; }
    public List<EventField> Fields { get; set; } = null!;
    public List<ScheduleEvent> ScheduleEvents { get; set; } = null!;
}