using NFTure.Core.Entities;
using NFTure.Core.Interfaces.Repositories.Base;

namespace NFTure.Core.Interfaces.Repositories
{
    public interface IClientActivityRepository : IRepository<ClientActivity, int>
    {
        Task<IReadOnlyList<ClientActivity>> GetByUserIdAsync(Guid id);
    }
}
