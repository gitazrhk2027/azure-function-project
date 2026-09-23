using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace OrderProcessingFunction;

public class ProcessOrder
{
    private readonly ILogger<ProcessOrder> _logger;

    public ProcessOrder(ILogger<ProcessOrder> logger)
    {
        _logger = logger;
    }

    [Function("ProcessOrder")]
    public HttpResponseData Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
    {
        _logger.LogInformation("ProcessOrder function received a request.");

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.WriteString("Order processed successfully!");

        return response;
    }
}
