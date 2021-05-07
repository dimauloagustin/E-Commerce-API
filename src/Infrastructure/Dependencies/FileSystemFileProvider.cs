using Infrastructure.Dependencies.Abstractions;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Infrastructure.Dependencies
{
    [ExcludeFromCodeCoverage]
    public class RealFileSystemProvider : IFileSystemProvider
    {
        public bool Exists(string path) => Directory.Exists(path);

        public DirectoryInfo CreateDirectory(string path) => Directory.CreateDirectory(path);
    }
}
