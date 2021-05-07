using Infrastructure.Dependencies.Abstractions;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Infrastructure.Dependencies
{
    [ExcludeFromCodeCoverage]
    public class RealFileStreamFactory : IFileStreamFactory
    {
        public Stream CreateFileStream(string path, FileMode mode) => new FileStream(path, mode);
    }
}
