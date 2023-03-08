namespace Edule.Backend.Entities;

public class ScheduleEvent : BaseEntity 
{
    public Schedule Schedule { get; set; } = null!;
    public Event Event { get; set; } = null!;
}