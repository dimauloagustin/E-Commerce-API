using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Contexts;

namespace Infrastructure.Repository.EfCore
{
    public class CategoryRepository : GenericEFRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(BasicDbContext sampleDbContext) : base(sampleDbContext)
        {
        }
    }
}
