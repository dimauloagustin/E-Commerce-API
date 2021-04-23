using Application.Exceptions.Abstractions;
using Application.Exceptions.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Exceptions
{
    public class ModelValidationException : Exception, IJsonResultConvertible
    {
        public List<ValidationResult> ValidationErrors { get; set; }
        public ModelValidationException(List<ValidationResult> validationResults) : base("Validation error")
        {
            ValidationErrors = validationResults;
        }

        public ObjectResult ToJsonResult(string requestId) => new UnprocessableEntityObjectResult(new ModelValidationErrorResponse(ValidationErrors) { RequestId = requestId });
    }
}
