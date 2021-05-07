using System.IO;

namespace Infrastructure.Dependencies.Abstractions
{
    public interface IFileSystemProvider
    {
        bool Exists(string path);
        DirectoryInfo CreateDirectory(string path);
    }
}
