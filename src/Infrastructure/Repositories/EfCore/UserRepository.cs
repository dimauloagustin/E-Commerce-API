using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Contexts;

namespace Infrastructure.Repository.EfCore
{
    public class UserRepository : GenericEFRepository<User>, IUserRepository
    {
        public UserRepository(BasicDbContext sampleDbContext) : base(sampleDbContext)
        {
        }
    }
}
