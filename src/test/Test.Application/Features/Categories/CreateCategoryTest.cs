using Application.Commands.Categories;
using Application.Interfaces.Repositories;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using FluentAssertions;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Test.Application.Features.Categories
{
    public class CreateCategoryTest
    {
        [Fact]
        public void Should_create_category_without_parent()
        {
            // Arrange
            var command = new CreateCategory
            { 
                Name = "test category"
            };

            var entity = new Category { Id = 1, Name = command.Name };

            //TODO - move mapper to fixture
            var mapperConfig = new MapperConfiguration(opts =>
            {
                opts.AddProfile<GeneralProfile>();
            });

            var mapper = mapperConfig.CreateMapper();

            var fakeRepo = new Mock<ICategoryRepository>();
            fakeRepo.Setup(m => m.AddAsync(It.IsAny<Category>())).Returns(Task.FromResult(entity));

            // Act
            var res = Task.Run(() => new CreateCategoryHandler(fakeRepo.Object, mapper).Handle(command, default)).Result;

            // Assert
            fakeRepo.Verify(x => x.AddAsync(It.IsAny<Category>()), Times.Once());
            mapper.Map<Category>(entity).Should().BeEquivalentTo(res);
        }
    }
}
