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
    public class DeleteUserTest : IClassFixture<MapperFixture>
    {
        private readonly IMapper _mapper;

        public DeleteUserTest(MapperFixture mapperFixture)
        {
            _mapper = mapperFixture.Mapper;
        }

        [Fact]
        public void Should_delete_user()
        {
            // Arrange
            var command = new DeleteUser { Id = 1 };

            var entity = new User { Id = 1, Name = "test", Pass = "test pass", Email = "test email" };

            var fakeRepo = new Mock<IUserRepository>();
            fakeRepo.Setup(m => m.Find(entity.Id)).Returns(entity);
            fakeRepo.Setup(m => m.Delete(It.IsAny<User>())).Returns(1);

            // Act
            var res = Task.Run(() => new DeleteUserHandler(fakeRepo.Object, _mapper).Handle(command, default)).Result;

            // Assert
            fakeRepo.Verify(x => x.Delete(It.IsAny<User>()), Times.Once());
            Assert.Equal(entity, res);
        }
    }
}
