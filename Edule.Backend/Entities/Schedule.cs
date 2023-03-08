namespace Edule.Backend.Entities;

public class Schedule : BaseEntity 
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}