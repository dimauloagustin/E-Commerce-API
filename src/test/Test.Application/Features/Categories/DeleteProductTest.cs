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
    public class DeleteProductTest : IClassFixture<MapperFixture>
    {
        private readonly IMapper _mapper;

        public DeleteProductTest(MapperFixture mapperFixture)
        {
            _mapper = mapperFixture.Mapper;
        }

        [Fact]
        public void Should_delete_category()
        {
            // Arrange
            var command = new DeleteCategory
            {
                Id = 1
            };

            var entity = new Category { Id = 1, Name = "test category" };

            var fakeRepo = new Mock<ICategoryRepository>();
            fakeRepo.Setup(m => m.Delete(It.IsAny<Category>())).Returns(1);
            fakeRepo.Setup(m => m.Find(entity.Id)).Returns(entity);

            // Act
            var res = Task.Run(() => new DeleteCategoryHandler(fakeRepo.Object, _mapper).Handle(command, default)).Result;

            // Assert
            fakeRepo.Verify(x => x.Delete(It.IsAny<Category>()), Times.Once());
            fakeRepo.Verify(x => x.Find(entity.Id), Times.Once());
            Assert.Equal(entity, res);
        }
    }
}
