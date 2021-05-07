using Application.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Product
{
    public class UploadProductPhoto : IRequest<string>
    {
        [Required]
        public IFormFile File { get; set; }
    }

    public class UploadProductPhotoHandler : IRequestHandler<UploadProductPhoto, string>
    {
        private readonly IImageService _imageService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UploadProductPhotoHandler(IImageService imageService, IHttpContextAccessor httpContextAccessor)
        {
            _imageService = imageService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> Handle(UploadProductPhoto request, CancellationToken cancellationToken)
        {
            string urlResult = await _imageService.SaveFileAsync(request.File, cancellationToken);

            return $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}" + urlResult;
        }
    }
}
