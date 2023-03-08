namespace Edule.Backend.Entities;

public class ScheduleAvailability : BaseEntity 
{
    public int WeekDay { get; set; }
    public DateTime Begin { get; set; }
    public DateTime End { get; set; }
    public Schedule Schedule { get; set; } = null!;
}