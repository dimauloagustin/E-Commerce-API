using Infrastructure.Dependencies.Abstractions;
using System.IO;

namespace Infrastructure.Dependencies
{
    public class RealFileStreamFactory : IFileStreamFactory
    {
        public Stream CreateFileStream(string path, FileMode mode) => new FileStream(path, mode);
    }
}
