using Domain.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repository.EfCore
{
    public class ProductRepository : GenericEFRepository<Product>, IProductRepository
    {
        public ProductRepository(BasicDbContext sampleDbContext) : base(sampleDbContext)
        {
        }
    }
}
