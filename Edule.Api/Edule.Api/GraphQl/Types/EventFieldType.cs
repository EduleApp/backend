using Edule.Api.Infra.Data.Entities;

namespace Edule.Api.GraphQl.Types;

public class EventFieldType : ObjectType<EventField>
{
    protected override void Configure(IObjectTypeDescriptor<EventField> descriptor)
    {
        descriptor.Field(ef => ef.Id).Type<NonNullType<UuidType>>();
        descriptor.Field(ef => ef.FieldName).Type<NonNullType<StringType>>();
        descriptor.Field(ef => ef.FriendlyName).Type<NonNullType<StringType>>();
        descriptor.Field(ef => ef.Type).Type<NonNullType<StringType>>();
    }
}