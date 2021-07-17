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
    public class UpdateCategoryTest : IClassFixture<MapperFixture>
    {
        private readonly IMapper _mapper;

        public UpdateCategoryTest(MapperFixture mapperFixture)
        {
            _mapper = mapperFixture.Mapper;
        }

        [Fact]
        public void Should_update_category_without_parent()
        {
            // Arrange
            var command = new UpdateCategory
            { 
                Id = 1,
                Name = "test category"
            };

            var entity = new Category { Id = 1, Name = command.Name };

            var fakeRepo = new Mock<ICategoryRepository>();
            fakeRepo.Setup(m => m.Update(It.IsAny<Category>())).Returns(entity.Id);
            fakeRepo.Setup(m => m.Find(entity.Id)).Returns(entity);

            // Act
            var res = Task.Run(() => new UpdateCategoryHandler(fakeRepo.Object, _mapper).Handle(command, default)).Result;

            // Assert
            fakeRepo.Verify(x => x.Update(It.IsAny<Category>()), Times.Once());
            fakeRepo.Verify(x => x.Find(entity.Id), Times.Once());
            Assert.Equal(entity, res);
        }
    }
}
