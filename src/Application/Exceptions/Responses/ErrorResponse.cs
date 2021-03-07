using System;

namespace Application.Exceptions.Responses
{
    public class ErrorResponse
    {
        public string Error { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public string RequestId { get; set; }

        public ErrorResponse(string title)
        {
            Error = title;
        }
    }
}
