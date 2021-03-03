using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Product.Commands
{
    public class UploadProductPhotoCommand : IRequest<string>
    {
        public IFormFile File { get; set; }
    }

    public class UploadProductPhotoCommandHandler : IRequestHandler<UploadProductPhotoCommand, string>
    {
        private readonly IHostingEnvironment _environment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UploadProductPhotoCommandHandler(IHostingEnvironment environment, IHttpContextAccessor httpContextAccessor)
        {
            _environment = environment;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> Handle(UploadProductPhotoCommand request, CancellationToken cancellationToken)
        {
            string path = Path.Combine(_environment.WebRootPath, "Resourses", "Products");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fileName = Path.GetFileName(request.File.FileName);

            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                await request.File.CopyToAsync(stream, cancellationToken);
            }

            return $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}/Resourses/Products/" + request.File.FileName;
        }
    }
}
