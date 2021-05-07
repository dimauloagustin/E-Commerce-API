using Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services
{
    public class LinkProvider : ILinkProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LinkProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Scheme => _httpContextAccessor.HttpContext.Request.Scheme;

        public string Host => _httpContextAccessor.HttpContext.Request.Host.ToString();
    }
}
