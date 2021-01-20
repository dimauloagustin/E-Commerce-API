using System;
using System.Collections.Generic;

namespace Infrastructure.Support.ErrorHandler.ErrorTemplates
{
    public class ErrorDetail
    {
        public string BasicDescription { get; set; }
        public Func<Exception, object> LoadErrorFunction { get; set; } = (Exception ex) => ex.Message;

        public ErrorResponse GetErrorResponse(Exception ex)
        {
            return new ErrorResponse()
            {
                Description = BasicDescription,
                Error = LoadErrorFunction(ex)
            };
        }
    }
}
