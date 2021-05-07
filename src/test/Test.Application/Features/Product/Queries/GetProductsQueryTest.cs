using Application.Features.Product.Querries;
using Application.Interfaces.Repositories;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Test.Application.Features.Products.Queries
{
    public class GetProductsQueryTest
    {
        [Fact]
        public void Should_get_all_products()
        {
            // Arrange
            var command = new GetProductsQuerry();

            var entity1 = new Product { Id = 1, Description = "test1", Name = "test1" };
            var entity2 = new Product { Id = 2, Description = "test2", Name = "test2" };
            var entity3 = new Product { Id = 3, Description = "test3", Name = "test3" };
            var products = new List<Product>() { entity1, entity2, entity3 }.AsQueryable();

            var mapperConfig = new MapperConfiguration(opts =>
            {
                opts.AddProfile<GeneralProfile>();
            });

            var mapper = mapperConfig.CreateMapper();

            var fakeRepo = new Mock<IProductRepository>();
            fakeRepo.Setup(m => m.All()).Returns(products);

            // Act
            var res = Task.Run(() => new GetProductCommandHandler(fakeRepo.Object, mapper).Handle(command, default)).Result;

            // Assert
            fakeRepo.Verify(x => x.All(), Times.Once());
            Assert.Equal(products.Count(), res.Count);
        }
    }
}
