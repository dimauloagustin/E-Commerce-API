using Application.Exceptions;
using E_Commers.Errors.ErrorResponses;

namespace E_Commers.Errors
{
    public class ErrorManagerConfiguration
    {
        public ErrorManager Configure(ErrorManager em)
        {
            return em.MapErrorToException<ModelValidationException, ModelValidationErrorResponse>();
        }
    }
}
