namespace Edule.Api.Infra.Data.Entities;

public class Establishment : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public List<Address> Address { get; set; } = null!;
}