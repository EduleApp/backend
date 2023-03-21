namespace Edule.Api.Models;

public class EventRequest
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public int Duration { get; set; }
    public bool AtHome { get; set; } = false;
    public int? MaxDistance { get; set; }
    public bool Inactive { get; set; } = false;
    public Guid UserId { get; set; }
    public List<EventFieldDto> Fields { get; set; } = null!;
}

public class EventFieldDto
{
    public string FieldName { get; set; } = string.Empty;
    public string FriendlyName { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
}
