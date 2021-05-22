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
    public class HashServiceTest
    {
        [Fact]
        public void Should_hash_and_verify()
        {
            // Arrange
            string pass = "new pass";
            HashService service = new HashService();

            // Act
            string hash = service.Hash(pass);
            bool res = service.Verify(pass, hash);

            // Assert
            Assert.True(res);
        }
    }
}
