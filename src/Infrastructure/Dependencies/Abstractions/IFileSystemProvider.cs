using System.IO;

namespace Infrastructure.Dependencies.Abstractions
{
    public interface IFileSystemProvider
    {
        bool Exists(string path);
        IDirectoryInfo CreateDirectory(string path);
    }
}
