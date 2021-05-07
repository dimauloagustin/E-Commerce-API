﻿using Application.Features.Product;
using Application.Features.Product.Responses;
using Application.Interfaces.Repositories;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Test.Application.Features.Products.Queries
{
    public class GetProductsTest
    {
        [Fact]
        public void Should_get_all_products()
        {
            // Arrange
            var command = new GetProducts();

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
            var res = Task.Run(() => new GetProductsHandler(fakeRepo.Object, mapper).Handle(command, default)).Result;

            // Assert
            fakeRepo.Verify(x => x.All(), Times.Once());
            Assert.Equal(products.Count(), res.Count);
        }

        [Fact]
        public void Should_get_filter_by_category()
        {
            // Arrange
            var command = new GetProducts();
            command.IncludedCategories = new List<int>() { 1 };

            var entity1 = new Product { Id = 1, Description = "test1", Name = "test1", CategoryId = 1 };
            var entity2 = new Product { Id = 2, Description = "test2", Name = "test2", CategoryId = 2 };
            var entity3 = new Product { Id = 3, Description = "test3", Name = "test3", CategoryId = 2 };
            var products = new List<Product>() { entity1, entity2, entity3 }.AsQueryable();

            var mapperConfig = new MapperConfiguration(opts =>
            {
                opts.AddProfile<GeneralProfile>();
            });

            var mapper = mapperConfig.CreateMapper();

            var fakeRepo = new Mock<IProductRepository>();
            fakeRepo.Setup(m => m.All()).Returns(products);

            // Act
            var res = Task.Run(() => new GetProductsHandler(fakeRepo.Object, mapper).Handle(command, default)).Result;

            // Assert
            fakeRepo.Verify(x => x.All(), Times.Once());
            Assert.Single(res);
            mapper.Map<ProductResponse>(entity1).Should().BeEquivalentTo(res.First());
        }
    }
}
