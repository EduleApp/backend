namespace Edule.Backend.Infra.Data.Entities;

public class ScheduleEvent : BaseEntity 
{
    public Schedule Schedule { get; set; } = null!;
    public Event Event { get; set; } = null!;
}