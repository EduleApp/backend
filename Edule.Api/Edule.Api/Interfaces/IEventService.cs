using Edule.Api.Infra.Data.Entities;
using Edule.Api.Models;

namespace Edule.Api.Interfaces;

public interface IEventService
{
    Task<ResponseContract<EventResponse>> CreateEvent(EventRequest eventRequest);
}