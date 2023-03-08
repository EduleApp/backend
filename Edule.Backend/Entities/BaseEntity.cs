namespace Edule.Backend.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; }

    public string? CreatedBy { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }
}