using System.IO;

namespace Infrastructure.Dependencies.Abstractions
{
    public interface IFileStreamFactory
    {
        FileStream CreateFileStream(string path, FileMode mode);
    }
}
