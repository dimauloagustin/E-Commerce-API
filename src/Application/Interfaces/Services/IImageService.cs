using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IImageService
    {
        Task<string> SaveFileAsync(IFormFile image, CancellationToken cancellationToken);
    }
}
