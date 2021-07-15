using Infrastructure.Dependencies.Abstractions;
using System.IO;

namespace Infrastructure.Dependencies
{
    public class DirectoryInfoWrapper : IDirectoryInfo
    {
        public DirectoryInfo DirectoryInfo { get; }

        public DirectoryInfoWrapper(DirectoryInfo directoryInfo)
        {
            DirectoryInfo = directoryInfo;
        }
    }
}
