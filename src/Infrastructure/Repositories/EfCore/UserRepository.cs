using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Repository.EfCore
{
    public class UserRepository : GenericEFRepository<User>, IUserRepository
    {
        public UserRepository(BasicDbContext sampleDbContext) : base(sampleDbContext)
        {
        }
    }
}
