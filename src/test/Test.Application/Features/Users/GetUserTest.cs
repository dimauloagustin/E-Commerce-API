using Application.Commands.Users;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Moq;
using System.Threading.Tasks;
using Test.Application.Infrastructure;
using Xunit;

namespace Test.Application.Features.Users
{
    public class GetUserTest : IClassFixture<MapperFixture>
    {
        [Fact]
        public void Should_get_user()
        {
            // Arrange
            var command = new GetUser
            {
                Id = 1,
            };

            var entity = new User { Id = 1, Name = "test", Pass = "test pass", Email = "test email" };

            var fakeRepo = new Mock<IUserRepository>();
            fakeRepo.Setup(m => m.Find(entity.Id)).Returns(entity);

            // Act
            var res = Task.Run(() => new GetUserHandler(fakeRepo.Object).Handle(command, default)).Result;

            // Assert
            fakeRepo.Verify(x => x.Find(It.IsAny<int>()), Times.Once());
            Assert.Equal(entity, res);
        }
    }
}
