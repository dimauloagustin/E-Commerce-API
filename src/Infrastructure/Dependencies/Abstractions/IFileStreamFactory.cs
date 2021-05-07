using System.IO;

namespace Infrastructure.Dependencies.Abstractions
{
    public interface IFileStreamFactory
    {
        Stream CreateFileStream(string path, FileMode mode);
    }
}
