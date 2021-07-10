using Application.Exceptions.Serializables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Application.Exceptions
{
    [Serializable]
    public class ModelValidationException : Exception
    {
        public List<SerializableValidationResult> ValidationErrors { get; set; }

        public ModelValidationException() : base("Validation error") { }

        public ModelValidationException(List<ValidationResult> validationResults) : base("Validation error")
        {
            ValidationErrors = validationResults.Select(x => new SerializableValidationResult(x)).ToList();
        }
    }
}
