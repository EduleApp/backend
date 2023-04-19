using AutoMapper;
using Edule.Api.Infra.Data.Entities;
using Edule.Api.Models;

namespace Edule.Api.Infra.Mappers;

public class EduleProfile : Profile
{
    public EduleProfile()
    {
        CreateMap<EventRequest, Event>();
        CreateMap<EventFieldDto, EventField>();
    }
}