namespace Edule.Api.Infra;

public static class LogEvents
{
    public static EventId CREATE_EVENT_SUCCEEDED => new(1000, "Create Event Succeeded");
    public static EventId CREATE_EVENT_FAILED => new(1001, "Create Event Failed");
}