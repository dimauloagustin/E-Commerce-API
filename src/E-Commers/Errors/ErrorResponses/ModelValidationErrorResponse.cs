using Application.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commers.Errors.ErrorResponses
{
    public class ModelValidationErrorResponse : ErrorResponse
    {
        public List<ValidationResult> ValidationErrors { get; set; }

        public ModelValidationErrorResponse() : base("Model validation error")
        {
        }

        public override ErrorResponse FillFromException(Exception ex)
        {
            ValidationErrors = ((ModelValidationException)ex).ValidationErrors;
            return this;
        }
    }
}
