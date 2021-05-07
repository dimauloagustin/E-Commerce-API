using Infrastructure.Dependencies.Abstractions;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Infrastructure.Dependencies
{
    [ExcludeFromCodeCoverage]
    public class RealFileSystemProvider : IFileSystemProvider
    {
        public bool Exists(string path) => Directory.Exists(path);

        public IDirectoryInfo CreateDirectory(string path) => new DirectoryInfoWrapper(Directory.CreateDirectory(path));
    }
}
