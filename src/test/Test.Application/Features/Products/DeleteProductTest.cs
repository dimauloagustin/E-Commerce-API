using Application.Features.Product;
using Application.Interfaces.Repositories;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Test.Application.Features.Products
{
    public class DeleteProductTest
    {
        [Fact]
        public void Should_delete_product()
        {
            // Arrange
            var command = new DeleteProduct
            {
                Id = 1
            };

            var entity = new Product { Id = 1, Description = "test1", Name = "test1" };

            var mapperConfig = new MapperConfiguration(opts =>
            {
                opts.AddProfile<GeneralProfile>();
            });

            var mapper = mapperConfig.CreateMapper();

            var fakeRepo = new Mock<IProductRepository>();
            fakeRepo.Setup(m => m.Delete(It.IsAny<Product>())).Returns(1);
            fakeRepo.Setup(m => m.Find(entity.Id)).Returns(entity);

            // Act
            var res = Task.Run(() => new DeleteProductHandler(fakeRepo.Object, mapper).Handle(command, default)).Result;

            // Assert
            fakeRepo.Verify(x => x.Delete(It.IsAny<Product>()), Times.Once());
            fakeRepo.Verify(x => x.Find(entity.Id), Times.Once());
        }
    }
}
