using Application.Commands.Categories;
using Application.Interfaces.Repositories;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Test.Application.Features.Categories
{
    public class DeleteProductTest
    {
        [Fact]
        public void Should_delete_category()
        {
            // Arrange
            var command = new DeleteCategory
            {
                Id = 1
            };

            var entity = new Category { Id = 1, Name = "test category" };

            var mapperConfig = new MapperConfiguration(opts =>
            {
                opts.AddProfile<GeneralProfile>();
            });

            var mapper = mapperConfig.CreateMapper();

            var fakeRepo = new Mock<ICategoryRepository>();
            fakeRepo.Setup(m => m.Delete(It.IsAny<Category>())).Returns(1);
            fakeRepo.Setup(m => m.Find(entity.Id)).Returns(entity);

            // Act
            var res = Task.Run(() => new DeleteCategoryHandler(fakeRepo.Object, mapper).Handle(command, default)).Result;

            // Assert
            fakeRepo.Verify(x => x.Delete(It.IsAny<Category>()), Times.Once());
            fakeRepo.Verify(x => x.Find(entity.Id), Times.Once());
        }
    }
}
