using NFTure.Core.Entities;
using NFTure.Core.Interfaces.Repositories.Base;

namespace NFTure.Core.Interfaces.Repositories
{
    public interface IUserActivityRepository : IRepository<UserActivity, int>
    {
        Task<IReadOnlyList<UserActivity>> GetByUserIdAsync(Guid id);
    }
}
