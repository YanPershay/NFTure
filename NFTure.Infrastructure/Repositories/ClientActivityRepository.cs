using NFTure.Core.Entities;
using NFTure.Core.Interfaces.Repositories;
using NFTure.Infrastructure.Data;
using NFTure.Infrastructure.Repositories.Base;

namespace NFTure.Infrastructure.Repositories
{
    public class ClientActivityRepository : Repository<ClientActivity, int>, IClientActivityRepository
    {
        public ClientActivityRepository(NftureContext context) : base(context) { }

        public async Task<IReadOnlyList<ClientActivity>> GetActivitiesByUserIdAsync(Guid id) =>
            await GetAsync(a => a.UserId.Equals(id));
    }
}
