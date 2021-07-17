using Infrastructure.Dependencies.Abstractions;
using System.IO;

namespace Infrastructure.Dependencies
{
    public class RealFileSystemProvider : IFileSystemProvider
    {
        public bool Exists(string path) => Directory.Exists(path);

        public IDirectoryInfo CreateDirectory(string path) => new DirectoryInfoWrapper(Directory.CreateDirectory(path));
    }
}
