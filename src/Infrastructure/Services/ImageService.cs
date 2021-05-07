using Application.Interfaces.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ImageService : IImageService
    {
        private readonly IHostingEnvironment _environment;
        public ImageService(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> SaveFileAsync(IFormFile image, CancellationToken cancellationToken)
        {
            string path = Path.Combine(_environment.WebRootPath, "Resourses", "Products");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fileExtencion = Path.GetExtension(image.FileName);
            string fileName = Path.GetFileName(Guid.NewGuid().ToString() + '.' + fileExtencion);

            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                await image.CopyToAsync(stream, cancellationToken);
            }

            return "/Resourses/Products/" + fileName;
        }
    }
}
