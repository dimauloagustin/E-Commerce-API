using Domain.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repository.EfCore
{
    public class CategoryRepository : GenericEFRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(BasicDbContext sampleDbContext) : base(sampleDbContext)
        {
        }
    }
}
