using Application.Entities;
using Application.Interfaces.Repositories;
using Infrastructure.Contexts;

namespace Infrastructure.Repository.EfCore
{
    public class SessionRepository : GenericEFRepository<Session>, ISessionRepository
    {
        public SessionRepository(BasicDbContext sampleDbContext) : base(sampleDbContext)
        {
        }
    }
}
