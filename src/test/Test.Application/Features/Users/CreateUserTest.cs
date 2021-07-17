using Application.Commands.Users;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using Moq;
using System.Threading.Tasks;
using Test.Application.Infrastructure;
using Xunit;

namespace Test.Application.Features.Users
{
    public class CreateUserTest : IClassFixture<MapperFixture>
    {
        private readonly IMapper _mapper;

        public CreateUserTest(MapperFixture mapperFixture)
        {
            _mapper = mapperFixture.Mapper;
        }

        [Fact]
        public void Should_create_user()
        {
            // Arrange
            string hashedPass = "hashed test pass";
            var command = new CreateUser
            {
                Name = "test",
                Pass = "test pass",
                Email = "test email"
            };

            var entity = new User { Id = 1, Name = command.Name, Pass = hashedPass, Email = command.Email };

            var fakeRepo = new Mock<IUserRepository>();
            fakeRepo.Setup(m => m.AddAsync(It.IsAny<User>())).Returns(Task.FromResult(entity));

            var fakeHashService = new Mock<IHashService>();
            fakeHashService.Setup(m => m.Hash(command.Pass)).Returns(hashedPass);

            // Act
            var res = Task.Run(() => new CreateUserHandler(fakeRepo.Object, _mapper, fakeHashService.Object).Handle(command, default)).Result;

            // Assert
            fakeRepo.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once());
            Assert.Equal(entity, res);
        }
    }
}
