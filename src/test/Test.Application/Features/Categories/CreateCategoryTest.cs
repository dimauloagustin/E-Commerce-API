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
    public class CreateCategoryTest : IClassFixture<MapperFixture>
    {
        private readonly IMapper _mapper;

        public CreateCategoryTest(MapperFixture mapperFixture)
        {
            _mapper = mapperFixture.Mapper;
        }

        [Fact]
        public void Should_create_category_without_parent()
        {
            // Arrange
            var command = new CreateCategory
            { 
                Name = "test category"
            };

            var entity = new Category { Id = 1, Name = command.Name };

            var fakeRepo = new Mock<ICategoryRepository>();
            fakeRepo.Setup(m => m.AddAsync(It.IsAny<Category>())).Returns(Task.FromResult(entity));

            // Act
            var res = Task.Run(() => new CreateCategoryHandler(fakeRepo.Object, _mapper).Handle(command, default)).Result;

            // Assert
            fakeRepo.Verify(x => x.AddAsync(It.IsAny<Category>()), Times.Once());
            Assert.Equal(entity, res);
        }
    }
}
