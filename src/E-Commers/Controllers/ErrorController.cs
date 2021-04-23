using Application.Exceptions.Abstractions;
using Application.Exceptions.Responses;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace E_Commers.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [Route("/error")]
        public ObjectResult Error()
        {
            var error = HttpContext.Features.Get<IExceptionHandlerFeature>().Error;
            _logger.LogError(error, "Not suported error");

            if (error.GetType().IsAssignableTo(typeof(IJsonResultConvertible)))
            {
                return ((IJsonResultConvertible)error).ToJsonResult(HttpContext.TraceIdentifier);
            }
            else
            {
                return BadRequest(new GenericErrorResponse() { RequestId = HttpContext.TraceIdentifier });
            }
        }
    }
}
