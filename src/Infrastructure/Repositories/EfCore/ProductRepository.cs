using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Contexts;

namespace Infrastructure.Repository.EfCore
{
    public class ProductRepository : GenericEFRepository<Product>, IProductRepository
    {
        public ProductRepository(BasicDbContext sampleDbContext) : base(sampleDbContext)
        {
        }
    }
}
