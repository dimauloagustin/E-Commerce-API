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
    public class DeleteProductTest : IClassFixture<MapperFixture>
    {
        private readonly IMapper _mapper;

        public DeleteProductTest(MapperFixture mapperFixture)
        {
            _mapper = mapperFixture.Mapper;
        }

        [Fact]
        public void Should_delete_product()
        {
            // Arrange
            var command = new DeleteProduct
            {
                Id = 1
            };

            var entity = new Product { Id = 1, Description = "test1", Name = "test1" };

            var fakeRepo = new Mock<IProductRepository>();
            fakeRepo.Setup(m => m.Find(entity.Id)).Returns(entity);
            fakeRepo.Setup(m => m.Delete(It.IsAny<Product>())).Returns(1);

            // Act
            var res = Task.Run(() => new DeleteProductHandler(fakeRepo.Object, _mapper).Handle(command, default)).Result;

            // Assert
            fakeRepo.Verify(x => x.Delete(It.IsAny<Product>()), Times.Once());
            fakeRepo.Verify(x => x.Find(entity.Id), Times.Once());
            Assert.Equal(entity, res);
        }
    }
}
