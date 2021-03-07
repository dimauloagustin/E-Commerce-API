using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Exceptions.Responses
{
    public class ModelValidationErrorResponse : ErrorResponse
    {
        public List<ValidationResult> ValidationErrors { get; set; }

        public ModelValidationErrorResponse(List<ValidationResult> validationErrors) : base("Model validation error")
        {
            ValidationErrors = validationErrors;
        }
    }
}
