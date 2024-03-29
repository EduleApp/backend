using System.Text.Json.Serialization;

namespace Edule.Api.Infra.Data.Entities;

public class EventField : BaseEntity 
{
    public string FieldName { get; set; } = string.Empty;
    public string FriendlyName { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    
    [JsonIgnore]
    public Event Event { get; set; } = null!;
}