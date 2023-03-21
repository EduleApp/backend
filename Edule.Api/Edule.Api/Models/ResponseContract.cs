using System.Net;

namespace Edule.Api.Models;

public class ResponseContract<T>
{
    public bool Valid { get; private set; }
    public HttpStatusCode ResponseCode { get; private set; }
    public string? Message { get; private set; }
    public List<string> Errors { get; private set; } = new List<string>();
    public T? Data { get; private set; }

    public void SetResponse(bool valid = true, HttpStatusCode code = HttpStatusCode.OK, string? message = null)
    {
        Valid = valid;
        ResponseCode = code;
        Message = message;
    }

    public void AddData(T data)
    {
        Data = data;
    }

    public void AddErrors(IEnumerable<string> errors)
    {
        Errors.AddRange(errors);
    }

    public void AddError(string error)
    {
        Errors.Add(error);
    }
}