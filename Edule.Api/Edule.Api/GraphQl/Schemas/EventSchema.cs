using HotChocolate;
using HotChocolate.Configuration;
using HotChocolate.Execution.Configuration;
using Edule.Api.GraphQl.Queries;
using Edule.Api.GraphQl.Types;
using Edule.Api.Interfaces.Repositories;
using Edule.Api.Interfaces.Services;
using Edule.Api.Services;

namespace Edule.Api.GraphQl.Schemas
{
    public class EventSchema : Schema
    {
        public EventSchema(IEventRepository eventRepository)
            : base(SchemaBuilder.New()
                    .AddQueryType<QueryType>()
                    //.AddMutationType<MutationType>()
                    .AddType<EventType>()
                    .AddType<EventFieldType>()
                    .AddType<UuidType>()
                    .AddServices(new ServiceDescriptor[]
                    {
                        new ServiceDescriptor(typeof(IEventService), typeof(EventService), ServiceLifetime.Scoped),
                        new ServiceDescriptor(typeof(IEventRepository), eventRepository, ServiceLifetime.Scoped)
                    })
                    .Create(),
                new QueryExecutionOptions
                {
                    IncludeExceptionDetails = true,
                    MaxExecutionDepth = 15
                })
        { }
    }
}