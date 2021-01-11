using Application.Exceptions;
using Infrastructure.Support.ErrorHandler.ErrorTemplates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Infrastructure.Support.ErrorHandler.Configuration
{
    public static class ConfigureExceptionHandler
    {
        public static void Configure(ErrorMapper em)
        {
            em.AddToMapper<DummyException>(new ErrorDetail()
            {
                BasicDescription = "Dummy Exception"
            });

            em.AddToMapper<ModelValidationException>(new ErrorDetail()
            {
                BasicDescription = "Validation Error",
                LoadErrorFunction = (Exception ex) =>
                {
                    var validationEx = (ModelValidationException)ex;
                    var errors = new Dictionary<string, string>();
                    validationEx.ValidationResults.ForEach((ValidationResult vr) =>
                    {
                        errors.Add(vr.MemberNames.First(), vr.ErrorMessage);
                    });
                    return errors;
                }
            });
        }
    }
}
