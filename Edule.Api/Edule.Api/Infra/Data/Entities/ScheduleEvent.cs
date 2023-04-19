namespace Edule.Api.Infra.Data.Entities;

public class ScheduleEvent : BaseEntity 
{
    public Schedule Schedule { get; set; } = null!;
    public Event Event { get; set; } = null!;
}