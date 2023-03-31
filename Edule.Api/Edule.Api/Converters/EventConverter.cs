using System.Text.Json;
using System.Text.Json.Serialization;
using Edule.Api.Infra.Data.Entities;

namespace Edule.Api.Converters;

public class EventConverter : JsonConverter<Event>
{
    public override Event Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, Event value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}