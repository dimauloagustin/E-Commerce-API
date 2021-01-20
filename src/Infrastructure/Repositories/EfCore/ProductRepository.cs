using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Repository.EfCore
{
    public class ProductRepository : GenericEFRepository<Product>, IProductRepository
    {
        public ProductRepository(BasicDbContext sampleDbContext) : base(sampleDbContext)
        {
        }
    }
}
