namespace Edule.Backend.Infra.Data.Entities;

public class Establishment : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}