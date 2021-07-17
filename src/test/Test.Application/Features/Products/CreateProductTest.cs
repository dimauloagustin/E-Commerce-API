using Application.Features.Product;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Moq;
using System.Threading.Tasks;
using Test.Application.Infrastructure;
using Xunit;

namespace Test.Application.Features.Products
{
    public class CreateProductTest : IClassFixture<MapperFixture>
    {
        private readonly IMapper _mapper;

        public CreateProductTest(MapperFixture mapperFixture)
        {
            _mapper = mapperFixture.Mapper;
        }

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

            var fakeRepo = new Mock<IProductRepository>();
            fakeRepo.Setup(m => m.AddAsync(It.IsAny<Product>())).Returns(Task.FromResult(entity));

            // Act
            var res = Task.Run(() => new CreateProductHandler(fakeRepo.Object, _mapper).Handle(command, default)).Result;

            // Assert
            fakeRepo.Verify(x => x.AddAsync(It.IsAny<Product>()), Times.Once());
            Assert.Equal(entity, res);
        }
    }
}
