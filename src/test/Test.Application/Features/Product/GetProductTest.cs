using Application.Features.Product;
using Application.Features.Product.Responses;
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
    public class GetProductTest
    {
        [Fact]
        public void Should_get_product()
        {
            // Arrange
            var command = new GetProduct
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
            fakeRepo.Setup(m => m.Find(command.Id)).Returns(entity);

            // Act
            var res = Task.Run(() => new GetProductHandler(fakeRepo.Object, mapper).Handle(command, default)).Result;

            // Assert
            fakeRepo.Verify(x => x.Find(command.Id), Times.Once());
            mapper.Map<ProductResponse>(entity).Should().BeEquivalentTo(res);
        }
    }
}
