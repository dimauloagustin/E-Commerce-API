using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Exceptions
{
    public class ModelValidationException : Exception
    {
        public List<ValidationResult> ValidationResults { get; set; }
        public ModelValidationException(List<ValidationResult> validationResults) : base("Validation error")
        {
            ValidationResults = validationResults;
        }
    }
}
