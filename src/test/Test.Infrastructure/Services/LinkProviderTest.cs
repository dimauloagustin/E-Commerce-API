using Infrastructure.Dependencies.Abstractions;
using Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Moq;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Test.Infrastructure.Services
{
    public class ImageServiceTest
    {
        private readonly Mock<IHostingEnvironment> _hostingEnviromentMock;
        private readonly Mock<IFileSystemProvider> _fileSistemMock;
        private readonly Mock<IFileStreamFactory> _fileStreamFactoryMock;

        public ImageServiceTest()
        {
            _hostingEnviromentMock = new Mock<IHostingEnvironment>();
            _hostingEnviromentMock.Setup(_ => _.WebRootPath).Returns("");

            _fileSistemMock = new Mock<IFileSystemProvider>();
            _fileSistemMock.Setup(_ => _.Exists(It.IsAny<string>())).Returns(true);

            _fileStreamFactoryMock = new Mock<IFileStreamFactory>();
            _fileStreamFactoryMock.Setup(_ => _.CreateFileStream(It.IsAny<string>(), It.IsAny<FileMode>())).Returns(new MemoryStream());
        }

        [Fact]
        public void Should_save_the_file()
        {
            // Arrange
            var fileMock = new Mock<IFormFile>();
            fileMock.Setup(_ => _.CopyToAsync(It.IsNotNull<Stream>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult<object>(null));

            // Act
            var res = Task.Run(() => new ImageService(_hostingEnviromentMock.Object, _fileSistemMock.Object, _fileStreamFactoryMock.Object).SaveFileAsync(fileMock.Object, default)).Result;

            // Assert
            fileMock.Verify(_ => _.CopyToAsync(It.IsNotNull<Stream>(), It.IsAny<CancellationToken>()), Times.Once);
            Assert.NotNull(res);
        }

        [Fact]
        public void Should_create_directory()
        {
            // Arrange
            var customFileSistemMock = new Mock<IFileSystemProvider>();
            customFileSistemMock.Setup(_ => _.Exists(It.IsAny<string>())).Returns(false);
            customFileSistemMock.Setup(_ => _.CreateDirectory(It.IsAny<string>())).Returns(new Mock<IDirectoryInfo>().Object);

            var fileMock = new Mock<IFormFile>();
            fileMock.Setup(_ => _.CopyToAsync(It.IsNotNull<Stream>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult<object>(null));

            // Act
            var res = Task.Run(() => new ImageService(_hostingEnviromentMock.Object, customFileSistemMock.Object, _fileStreamFactoryMock.Object).SaveFileAsync(fileMock.Object, default)).Result;

            // Assert
            customFileSistemMock.Verify(_ => _.CreateDirectory(It.IsAny<string>()), Times.Once);
            Assert.NotNull(res);
        }
    }
}
