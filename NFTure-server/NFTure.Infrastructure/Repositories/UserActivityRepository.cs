using NFTure.Core.Entities;
using NFTure.Core.Interfaces.Repositories;
using NFTure.Infrastructure.Data;
using NFTure.Infrastructure.Repositories.Base;

namespace NFTure.Infrastructure.Repositories
{
    public class UserActivityRepository : Repository<UserActivity, int>, IUserActivityRepository
    {
        public UserActivityRepository(NftureContext context) : base(context) { }

        public async Task<IReadOnlyList<UserActivity>> GetByUserIdAsync(Guid id) =>
            await GetAsync(a => a.UserId.Equals(id));
    }
}
