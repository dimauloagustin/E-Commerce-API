using Domain.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repository.EfCore
{
    public class UserRepository : GenericEFRepository<User>, IUserRepository
    {
        public UserRepository(BasicDbContext sampleDbContext) : base(sampleDbContext)
        {
        }
    }
}
