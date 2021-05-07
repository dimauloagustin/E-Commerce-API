using Infrastructure.Dependencies.Abstractions;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Infrastructure.Dependencies
{
    [ExcludeFromCodeCoverage]
    public class RealFileStreamFactory : IFileStreamFactory
    {
        public FileStream CreateFileStream(string path, FileMode mode) => new FileStream(path, mode);
    }
}
