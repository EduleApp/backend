namespace Edule.Backend.Entities;

public class Address : BaseEntity
{
    public string Postcode { get; set; } = string.Empty;
    public string LineOne { get; set; } = string.Empty;
    public string? LineTwo { get; set; } = string.Empty;
    public string? City { get; set; } = string.Empty;
    public string? State { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string? Geolocation { get; set; } = string.Empty;
    public string FormattedAddress { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public Establishment? Establishment { get; set; }
}