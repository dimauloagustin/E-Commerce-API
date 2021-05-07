using Infrastructure.Dependencies.Abstractions;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Infrastructure.Dependencies
{
    [ExcludeFromCodeCoverage]
    public class DirectoryInfoWrapper : IDirectoryInfo
    {
        public DirectoryInfo DirectoryInfo { get; }

        public DirectoryInfoWrapper(DirectoryInfo directoryInfo)
        {
            DirectoryInfo = directoryInfo;
        }
    }
}
