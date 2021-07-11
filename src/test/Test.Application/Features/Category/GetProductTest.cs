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
    public class GetCategoryTest
    {
        [Fact]
        public void Should_get_category()
        {
            // Arrange
            var command = new GetCategory
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
            fakeRepo.Setup(m => m.Find(command.Id)).Returns(entity);

            // Act
            var res = Task.Run(() => new GetCategoryHandler(fakeRepo.Object, mapper).Handle(command, default)).Result;

            // Assert
            fakeRepo.Verify(x => x.Find(command.Id), Times.Once());
            mapper.Map<Category>(entity).Should().BeEquivalentTo(res);
        }
    }
}
