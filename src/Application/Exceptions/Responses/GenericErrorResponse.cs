using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Exceptions.Responses
{
    public class GenericErrorResponse : ErrorResponse
    {
        public GenericErrorResponse() : base("Not supported error") { }
    }
}
