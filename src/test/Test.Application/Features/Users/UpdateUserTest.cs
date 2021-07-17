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
    public class UpdateUserTest : IClassFixture<MapperFixture>
    {
        private readonly IMapper _mapper;

        public UpdateUserTest(MapperFixture mapperFixture)
        {
            _mapper = mapperFixture.Mapper;
        }

        [Fact]
        public void Should_update_user()
        {
            // Arrange
            var command = new UpdateUser
            {
                Id = 1,
                Name = "test",
                Pass = "test pass",
                Email = "test email"
            };

            var entity = new User { Id = 1, Name = command.Name, Pass = command.Pass, Email = command.Email };

            var fakeRepo = new Mock<IUserRepository>();
            fakeRepo.Setup(m => m.Find(entity.Id)).Returns(entity);
            fakeRepo.Setup(m => m.Update(It.IsAny<User>())).Returns(1);

            // Act
            var res = Task.Run(() => new UpdateUserHandler(fakeRepo.Object, _mapper).Handle(command, default)).Result;

            // Assert
            fakeRepo.Verify(x => x.Update(It.IsAny<User>()), Times.Once());
            Assert.Equal(entity, res);
        }
    }
}
