using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Application.Exceptions
{
    [Serializable]
    public class ModelValidationException : Exception
    {
        public List<ValidationResult> ValidationErrors { get; set; }
        public ModelValidationException(List<ValidationResult> validationResults) : base("Validation error")
        {
            ValidationErrors = validationResults;
        }

        public ModelValidationException() : base("Validation error") { }

        /*public ModelValidationException(string message) : base(message) { }

        public ModelValidationException(string message, Exception innerException) : base(message, innerException) { }

        public ModelValidationException(string message, List<ValidationResult> validationResults) : base(message)
        {
            ValidationErrors = validationResults;
        }

        public ModelValidationException(string message, List<ValidationResult> validationResults, Exception innerException) : base(message, innerException)
        {
            ValidationErrors = validationResults;
        }*/

        [ExcludeFromCodeCoverage] //It is not possible to correct test it since Formaters have benn deprecated
        protected ModelValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            ValidationErrors = (List<ValidationResult>)info.GetValue("ValidationErrors", typeof(List<ValidationResult>));
        }

        [ExcludeFromCodeCoverage] //It is not possible to correct test it since Formaters have benn deprecated
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue("ValidationErrors", ValidationErrors, typeof(List<ValidationResult>));

            base.GetObjectData(info, context);
        }
    }
}
