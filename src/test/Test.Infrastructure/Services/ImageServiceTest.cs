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
    public class LinkProviderTest
    {
        private const string _scheme = "https";
        private const string _host = "testhost";
        private readonly Mock<IHttpContextAccessor> _httpContextAccessor;

        public LinkProviderTest()
        {
            var requestMock = new Mock<HttpRequest>();
            requestMock.Setup(_ => _.Scheme).Returns(_scheme);
            requestMock.Setup(_ => _.Host).Returns(new HostString(_host));

            var httpContextMock = new Mock<HttpContext>();
            httpContextMock.Setup(_ => _.Request).Returns(requestMock.Object);

            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            _httpContextAccessor.Setup(_ => _.HttpContext).Returns(httpContextMock.Object);
        }

        [Fact]
        public void Should_retrive_scheme()
        {
            // Arrange
            var fileMock = new Mock<IFormFile>();
            fileMock.Setup(_ => _.CopyToAsync(It.IsNotNull<Stream>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult<object>(null));

            var service = new LinkProvider(_httpContextAccessor.Object);

            // Act
            var res = service.Scheme;

            // Assert
            Assert.Equal(_scheme, res);
        }

        [Fact]
        public void Should_retrive_host()
        {
            // Arrange
            var fileMock = new Mock<IFormFile>();
            fileMock.Setup(_ => _.CopyToAsync(It.IsNotNull<Stream>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult<object>(null));

            var service = new LinkProvider(_httpContextAccessor.Object);

            // Act
            var res = service.Host;

            // Assert
            Assert.Equal(_host, res);
        }
    }
}
