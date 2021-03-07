using Microsoft.AspNetCore.Mvc;

namespace Application.Exceptions.Abstractions
{
    public interface IJsonResultConvertible
    {
        public ObjectResult ToJsonResult(string requestId);
    }
}
