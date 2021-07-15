using Application.Features.Product;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Test.Application.Features.Products
{
    public class UploadProductPhotoTest
    {
        private readonly Mock<ILinkProvider> _linkProviderMock;
        private readonly Mock<IImageService> _imageServiceMock;

        public UploadProductPhotoTest()
        {
            _linkProviderMock = new Mock<ILinkProvider>();
            _linkProviderMock.Setup(_ => _.Scheme).Returns("https");
            _linkProviderMock.Setup(_ => _.Host).Returns("testhost");

            _imageServiceMock = new Mock<IImageService>();
            _imageServiceMock.Setup(_ => _.SaveFileAsync(It.IsAny<IFormFile>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult("/test/result"));
        }

        [Fact]
        public void Should_upload_the_photo()
        {
            // Arrange
            var command = new UploadProductPhoto();

            // Act
            var res = Task.Run(() => new UploadProductPhotoHandler(_imageServiceMock.Object, _linkProviderMock.Object).Handle(command, default)).Result;

            // Assert
            _imageServiceMock.Verify(_ => _.SaveFileAsync(It.IsAny<IFormFile>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public void Should_return_link_to_the_photo()
        {
            // Arrange
            var command = new UploadProductPhoto();

            // Act
            var res = Task.Run(() => new UploadProductPhotoHandler(_imageServiceMock.Object, _linkProviderMock.Object).Handle(command, default)).Result;

            // Assert
            Assert.Equal("https://testhost/test/result", res);
        }
    }
}
