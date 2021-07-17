using Application.Commands.Categories;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Moq;
using System.Threading.Tasks;
using Test.Application.Infrastructure;
using Xunit;

namespace Test.Application.Features.Categories
{
    public class GetCategoryTest : IClassFixture<MapperFixture>
    {
        private readonly IMapper _mapper;

        public GetCategoryTest(MapperFixture mapperFixture)
        {
            _mapper = mapperFixture.Mapper;
        }

        [Fact]
        public void Should_get_category()
        {
            // Arrange
            var command = new GetCategory
            {
                Id = 1
            };

            var entity = new Category { Id = 1, Name = "test category" };

            var fakeRepo = new Mock<ICategoryRepository>();
            fakeRepo.Setup(m => m.Find(command.Id)).Returns(entity);

            // Act
            var res = Task.Run(() => new GetCategoryHandler(fakeRepo.Object, _mapper).Handle(command, default)).Result;

            // Assert
            fakeRepo.Verify(x => x.Find(command.Id), Times.Once());
            Assert.Equal(entity, res);
        }
    }
}
