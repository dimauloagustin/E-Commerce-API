using Application.Interfaces.Services;
using Infrastructure.Dependencies.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ImageService : IImageService
    {
        private readonly IHostingEnvironment _environment;
        private readonly IFileSystemProvider _fileProvieder;
        private readonly IFileStreamFactory _fileStreamFactory;
        public ImageService(IHostingEnvironment environment, IFileSystemProvider fileProvieder, IFileStreamFactory fileStreamFactory)
        {
            _environment = environment;
            _fileProvieder = fileProvieder;
            _fileStreamFactory = fileStreamFactory;
        }

        public async Task<string> SaveFileAsync(IFormFile image, CancellationToken cancellationToken)
        {
            string path = Path.Combine(_environment.WebRootPath, "Resourses", "Products");

            if (!_fileProvieder.Exists(path))
            {
                _fileProvieder.CreateDirectory(path);
            }

            string fileExtencion = Path.GetExtension(image.FileName);
            string fileName = Path.GetFileName(Guid.NewGuid().ToString() + '.' + fileExtencion);

            using (Stream stream = _fileStreamFactory.CreateFileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                await image.CopyToAsync(stream, cancellationToken);
            }

            return "/Resourses/Products/" + fileName;
        }
    }
}
