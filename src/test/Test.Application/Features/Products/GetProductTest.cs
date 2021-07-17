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
    public class GetProductTest : IClassFixture<MapperFixture>
    {
        private readonly IMapper _mapper;

        public GetProductTest(MapperFixture mapperFixture)
        {
            _mapper = mapperFixture.Mapper;
        }

        [Fact]
        public void Should_get_product()
        {
            // Arrange
            var command = new GetProduct
            {
                Id = 1
            };

            var entity = new Product { Id = 1, Description = "test1", Name = "test1" };

            var fakeRepo = new Mock<IProductRepository>();
            fakeRepo.Setup(m => m.Find(command.Id)).Returns(entity);

            // Act
            var res = Task.Run(() => new GetProductHandler(fakeRepo.Object, _mapper).Handle(command, default)).Result;

            // Assert
            fakeRepo.Verify(x => x.Find(command.Id), Times.Once());
            Assert.Equal(entity, res);
        }
    }
}
