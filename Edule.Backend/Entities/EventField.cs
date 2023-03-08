namespace Edule.Backend.Entities;

public class EventField : BaseEntity 
{
    public string FieldName { get; set; } = string.Empty;
    public string FriendlyName { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public Event Event { get; set; } = null!;
}