using HotChocolate.Execution;
using HotChocolate.Language;
using Microsoft.AspNetCore.Mvc;

namespace Edule.Api.Controllers;

[ApiController]
[Route("graphql")]
public class GraphQlController : ControllerBase
{
    private readonly IRequestExecutor _executor;

    public GraphQlController(IRequestExecutor executor)
    {
        _executor = executor;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] GraphQLRequest request)
    {
        var inputs = request.Variables != null
            ? request.Variables
                .ToDictionary(k => k.Key, v => v.Value)!
            : new Dictionary<string, object>();

        var document = Utf8GraphQLParser.Parse(request.Query!.ToString());

        var result = await _executor.ExecuteAsync(new QueryRequest(document, inputs));

        //var result = await _executor.ExecuteAsync(new QueryRequest(document, inputs));
        return Ok(result);
    }
}