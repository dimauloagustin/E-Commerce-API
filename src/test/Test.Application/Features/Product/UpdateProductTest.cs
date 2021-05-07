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
    public class UpdateProductTest
    {
        [Fact]
        public void Should_get_all_products()
        {
            // Arrange
            var command = new UpdateProduct();
            command.Id = 1;

            var entity = new Product { Id = 1, Description = "test1", Name = "test1" };

            var mapperConfig = new MapperConfiguration(opts =>
            {
                opts.AddProfile<GeneralProfile>();
            });

            var mapper = mapperConfig.CreateMapper();

            var fakeRepo = new Mock<IProductRepository>();
            fakeRepo.Setup(m => m.Update(It.IsAny<Product>())).Returns(1);
            fakeRepo.Setup(m => m.Find(entity.Id)).Returns(entity);

            // Act
            var res = Task.Run(() => new UpdateProductCommand(fakeRepo.Object, mapper).Handle(command, default)).Result;

            // Assert
            fakeRepo.Verify(x => x.Update(It.IsAny<Product>()), Times.Once());
        }
    }
}
