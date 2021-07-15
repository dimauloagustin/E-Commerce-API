using Application.Features.Product;
using Application.Interfaces.Repositories;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using FluentAssertions;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Test.Application.Features.Products
{
    public class CreateProductTest
    {
        [Fact]
        public void Should_create_product()
        {
            // Arrange
            var command = new CreateProduct
            {
                Description = "test1",
                Name = "test1"
            };

            var entity = new Product { Id = 1, Description = "test1", Name = "test1" };

            var mapperConfig = new MapperConfiguration(opts =>
            {
                opts.AddProfile<GeneralProfile>();
            });

            var mapper = mapperConfig.CreateMapper();

            var fakeRepo = new Mock<IProductRepository>();
            fakeRepo.Setup(m => m.AddAsync(It.IsAny<Product>())).Returns(Task.FromResult(entity));

            // Act
            var res = Task.Run(() => new CreateProductHandler(fakeRepo.Object, mapper).Handle(command, default)).Result;

            // Assert
            fakeRepo.Verify(x => x.AddAsync(It.IsAny<Product>()), Times.Once());
            mapper.Map<Product>(entity).Should().BeEquivalentTo(res);
        }
    }
}
