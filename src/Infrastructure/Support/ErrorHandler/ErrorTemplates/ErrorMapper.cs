using System;
using System.Collections.Generic;

namespace Infrastructure.Support.ErrorHandler.ErrorTemplates
{
    public class ErrorMapper
    {
        private readonly Dictionary<Type, ErrorDetail> _mapper;

        public ErrorMapper()
        {
            _mapper = new Dictionary<Type, ErrorDetail>();
        }

        public void AddToMapper<T>(ErrorDetail ed)
        {
            _mapper.Add(typeof(T), ed);
        }

        public ErrorResponse MapError(Exception ex)
        {
            ErrorDetail ed = _mapper.GetValueOrDefault(ex.GetType());

            if (ed != null)
                return ed.GetErrorResponse(ex);
            else
                return new ErrorDetail()
                {
                    BasicDescription = "Unespected Exception"
                }.GetErrorResponse(ex);

        }
    }
}
