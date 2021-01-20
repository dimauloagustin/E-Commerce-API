using Infrastructure.Support.ErrorHandler.ErrorTemplates;
using Microsoft.Extensions.Logging;
using System;

namespace Infrastructure.Support.ErrorHandler
{
    public class ErrorHandler
    {
        private readonly ErrorMapper _mapper;
        private readonly ILogger _logger;
        public ErrorResponse Wrapper { get; set; } = new ErrorResponse();

        public ErrorHandler(ErrorMapper mapper, ILogger<ErrorHandler> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        public void SetException(Exception ex)
        {
            Wrapper = _mapper.MapError(ex);
        }

        public string GenerateResponse()
        {
            ProcessError();

            return Wrapper.GetJsonString();
        }

        private void ProcessError()
        {
            LogError();
        }

        private void LogError()
        {
            _logger.LogError(Wrapper.GetJsonString());
        }
    }
}
