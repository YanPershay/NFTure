using NFTure.Core.Entities;
using NFTure.Core.Interfaces.Repositories.Base;

namespace NFTure.Core.Interfaces.Repositories
{
    public interface INftRepository : IRepository<Nft, Guid>
    {
        Task<IReadOnlyList<Nft>> GetAllUserNftsAsync(Guid userId);
        Task<Nft> GetByIdAsync(Guid id);
    }
}
